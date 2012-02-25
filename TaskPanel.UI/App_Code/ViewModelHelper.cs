using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesktopCore;
using TaskPanel.Core.Domain;
using TaskPanel.Core.Domain.Repository;
using System.Xml;
using System.IO;
using System.ComponentModel;
using System.Windows.Data;
using System.Threading;
using System.IO.IsolatedStorage;
using System.Reflection;

namespace TaskPanel.UI
{
    public static class ViewModelHelper
    {
        public const string ConfigurationFileName = "TaskPanel.Configuration.xml";

        /// <summary>
        /// Filtrování prvků podle typu <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Typ pro filtroání</typeparam>
        /// <param name="items">Kolekce prvků</param>
        public static IEnumerable<T> FilterItems<T>(IEnumerable items) where T : class
        {
            foreach (object item in items)
            {
                if (item is T)
                    yield return (item as T);
            }
        }

        public static void SortItems<T, TKey>(ObservableCollection<T> items, Func<T, TKey> sorter, bool desc = false)
        {
            IEnumerable<T> sorted = desc ? items.OrderByDescending(t => sorter(t)).ToArray() : items.OrderBy(t => sorter(t)).ToArray();
            items.Clear();
            items.AddRange(sorted);
        }

        /// <summary>
        /// Vyfiltruje úkoly podle vygrané skupiny a stavů.
        /// </summary>
        /// <param name="repository">Repositář s prvky</param>
        /// <param name="model">View model, ze kterého bere parametry pro filtrování</param>
        public static void UpdateTasks(IRepository repository, MainViewModel model)
        {
            model.Tasks.Clear();

            IEnumerable<ITaskState> states = model.CheckableTaskStates.Where(c => c.IsChecked).Select(c => c.Data);
            IQueryable<ITask> filtered = repository.Tasks.Where(t => states.Contains(t.State) && t.Priority >= model.Configuration.MinimumPriority);

            if (model.SelectedGroup == null)
                model.Tasks.AddRange(filtered);
            else
                model.Tasks.AddRange(filtered.Where(t => t.Group == model.SelectedGroup));
        }

        #region ViewState

        public static void SaveViewState(MainViewModel model)
        {
            XmlDocument doc = XmlHelper.CreateDocument();
            XmlElement conf = doc.CreateElement("Configuration");
            doc.AppendChild(conf);

            XmlHelper.SetAttributes(doc, conf, "Location", model.UserInfo, (m, x) =>
            {
                XmlHelper.SetAttribute(doc, x, "UserName", m.UserName);
                XmlHelper.SetAttribute(doc, x, "File", m.File);
                XmlHelper.SetAttribute(doc, x, "SavePassword", m.SavePassword);
                XmlHelper.SetAttribute(doc, x, "AutoLogin", m.AutoLogin);

                if (m.SavePassword)
                    XmlHelper.SetAttribute(doc, x, "Password", m.Password);
            });

            XmlHelper.SetAttributes(doc, conf, "Tasks", model.Configuration, (m, x) =>
            {
                XmlHelper.SetAttribute(doc, x, "ShowTaskInNewWindow", m.ShowTaskInNewWindow);
                XmlHelper.SetAttribute(doc, x, "MinimumPriority", m.MinimumPriority);
            });

            XmlHelper.SetAttributes(doc, conf, "Group", model.Configuration, (m, x) =>
            {
                XmlHelper.SetAttribute(doc, x, "ShowGroupAll", m.ShowGroupAll);
            });

            XmlHelper.SetAttributes(doc, conf, "Windows", model.Configuration, (m, x) =>
            {
                XmlHelper.SetAttribute(doc, x, "ShowInWindowList", m.ShowInWindowList);
                XmlHelper.SetAttribute(doc, x, "ShowInTaskbar", m.ShowInTaskbar);
                XmlHelper.SetAttribute(doc, x, "ShowInTray", m.ShowInTray);
                XmlHelper.SetAttribute(doc, x, "ShowButtonsText", m.ShowButtonsText);
            });

            XmlHelper.SetAttributes(doc, conf, "MainWindow", model.Configuration, (m, x) =>
            {
                XmlHelper.SetAttribute(doc, x, "Left", m.MainLeft);
                XmlHelper.SetAttribute(doc, x, "Top", m.MainTop);
                XmlHelper.SetAttribute(doc, x, "Width", m.MainWidth);
                XmlHelper.SetAttribute(doc, x, "Height", m.MainHeight);
            });

            XmlHelper.SetAttributes(doc, conf, "Groups", model.Configuration, (m, x) =>
            {
                XmlHelper.SetAttribute(doc, x, "Sorted", m.GroupsSort);
                XmlHelper.SetAttribute(doc, x, "SortedDirection", m.GroupsSortDirection);
            });

            XmlHelper.SetAttributes(doc, conf, "Locale", model.Configuration.Locale, (m, x) =>
            {
                XmlHelper.SetAttribute(doc, x, "Value", m.Name);
            });

            XmlHelper.SetAttributes(doc, conf, "DetailWindow", model.Configuration, (m, x) =>
            {
                XmlHelper.SetAttribute(doc, x, "Width", m.DetailWidth);
                XmlHelper.SetAttribute(doc, x, "Height", m.DetailHeight);
            });

            XmlHelper.SetAttributes(doc, conf, "CheckedTaskStates", "TaskState", model.CheckableTaskStates.Where(s => s.IsChecked), (m, x) =>
            {
                XmlHelper.SetAttribute(doc, x, "ID", m.Data.ID);
            });

            if (model.SelectedGroup != null)
            {
                XmlHelper.SetAttributes(doc, conf, "SelectedGroup", model.SelectedGroup, (m, x) =>
                {
                    XmlHelper.SetAttribute(doc, x, "ID", m.ID);
                });
            }

            ICollectionView view = CollectionViewSource.GetDefaultView(model.Tasks);
            if (view != null)
            {
                XmlHelper.SetAttributes(doc, conf, "TasksSort", "SortDescription", view.SortDescriptions, (sd, x) =>
                {
                    XmlHelper.SetAttribute(doc, x, "Property", sd.PropertyName);
                    XmlHelper.SetAttribute(doc, x, "Direction", sd.Direction.ToString());
                });
            }

            IsolatedStorageFile f = IsolatedStorageFile.GetUserStoreForAssembly();
            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(ConfigurationFileName, FileMode.Create, f))
                doc.Save(stream);
        }

        public static void LoadViewState(MainViewModel model)
        {
            IsolatedStorageFile f = IsolatedStorageFile.GetUserStoreForAssembly();
            if (f.FileExists(ConfigurationFileName))
            {
                XmlDocument doc = null;
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(ConfigurationFileName, FileMode.OpenOrCreate, f))
                {
                    try
                    {
                        doc = new XmlDocument();
                        doc.Load(stream);
                    }
                    catch (Exception)
                    {
                        doc = null;
                    }
                }

                if (doc == null)
                    return;

                XmlHelper.ElementByName(doc.DocumentElement, "Location", model.UserInfo, (m, x) =>
                {
                    m.AutoLogin = XmlHelper.GetAttributeBool(x, "AutoLogin", false);
                    m.SavePassword = XmlHelper.GetAttributeBool(x, "SavePassword", false);

                    m.UserName = XmlHelper.GetAttributeValue(x, "UserName");
                    m.File = XmlHelper.GetAttributeValue(x, "File");

                    if (m.SavePassword)
                        m.Password = XmlHelper.GetAttributeValue(x, "Password");
                });

                XmlHelper.ElementByName(doc.DocumentElement, "Tasks", model.Configuration, (m, x) =>
                {
                    m.ShowTaskInNewWindow = XmlHelper.GetAttributeBool(x, "ShowTaskInNewWindow", false);
                    m.MinimumPriority = XmlHelper.GetAttributeDecimal(x, "MinimumPriority", 1);
                });

                XmlHelper.ElementByName(doc.DocumentElement, "Group", model.Configuration, (m, x) =>
                {
                    m.ShowGroupAll = XmlHelper.GetAttributeBool(x, "ShowGroupAll", true);
                });

                XmlHelper.ElementByName(doc.DocumentElement, "Windows", model.Configuration, (m, x) =>
                {
                    m.ShowInWindowList = XmlHelper.GetAttributeBool(x, "ShowInWindowList", true);
                    m.ShowInTaskbar = XmlHelper.GetAttributeBool(x, "ShowInTaskbar", true);
                    m.ShowInTray = XmlHelper.GetAttributeBool(x, "ShowInTray", false);
                    m.ShowButtonsText = XmlHelper.GetAttributeBool(x, "ShowButtonsText", true);
                });

                XmlHelper.ElementByName(doc.DocumentElement, "Groups", model.Configuration, (m, x) =>
                {
                    m.GroupsSort = XmlHelper.GetAttributeValue(x, "Sorted", model.Configuration.GroupsSort);
                    m.GroupsSortDirection = XmlHelper.GetAttributeEnum<ListSortDirection>(x, "SortedDirection", ListSortDirection.Descending);
                });

                XmlHelper.ElementByName(doc.DocumentElement, "MainWindow", model.Configuration, (m, x) =>
                {
                    m.MainLeft = XmlHelper.GetAttributeDouble(x, "Left", model.Window.Left);
                    m.MainTop = XmlHelper.GetAttributeDouble(x, "Top", model.Window.Top);
                    m.MainWidth = XmlHelper.GetAttributeDouble(x, "Width", model.Window.Width);
                    m.MainHeight = XmlHelper.GetAttributeDouble(x, "Height", model.Window.Height);
                });

                XmlHelper.ElementByName(doc.DocumentElement, "Locale", model.Configuration, (m, x) =>
                {
                    m.Locale = XmlHelper.GetAttributeCulture(x, "Value", Thread.CurrentThread.CurrentCulture);
                });

                XmlHelper.ElementByName(doc.DocumentElement, "DetailWindow", model.Configuration, (m, x) =>
                {
                    m.DetailWidth = XmlHelper.GetAttributeDouble(x, "Width", model.Window.Width);
                    m.DetailHeight = XmlHelper.GetAttributeDouble(x, "Height", model.Window.Height);
                });

                ICollectionView view = CollectionViewSource.GetDefaultView(model.Tasks);
                if (view != null)
                {
                    XmlNodeList xsort = doc.GetElementsByTagName("TasksSort");
                    if (xsort.Count == 1)
                    {
                        view.SortDescriptions.Clear();
                        foreach (XmlElement item in ((XmlElement)xsort[0]).GetElementsByTagName("SortDescription"))
                        {
                            string propertyName = XmlHelper.GetAttributeValue(item, "Property", "Priority");
                            ListSortDirection direction = XmlHelper.GetAttributeEnum<ListSortDirection>(item, "Direction", ListSortDirection.Descending);
                            model.Window.SortTasks(model.Sorts.First(i => i.Property == propertyName), direction == ListSortDirection.Descending);
                        }
                    }
                }
            }
        }

        public static void LoadRepositoryViewState(MainViewModel model)
        {
            IsolatedStorageFile f = IsolatedStorageFile.GetUserStoreForAssembly();
            if (f.FileExists(ConfigurationFileName))
            {
                XmlDocument doc = null;
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(ConfigurationFileName, FileMode.OpenOrCreate, f))
                {
                    try
                    {
                        doc = new XmlDocument();
                        doc.Load(stream);
                    }
                    catch (Exception)
                    {
                        doc = null;
                    }
                }

                if (doc == null)
                    return;

                XmlNodeList xchecked = doc.GetElementsByTagName("CheckedTaskStates");
                if (xchecked.Count == 1)
                {
                    foreach (Checkable<ITaskState> item in model.CheckableTaskStates)
                        item.IsChecked = false;

                    foreach (XmlElement state in ((XmlElement)xchecked[0]).GetElementsByTagName("TaskState"))
                    {
                        int id = XmlHelper.GetAttributeInt(state, "ID", -1);
                        if (id != -1)
                        {
                            Checkable<ITaskState> item = model.CheckableTaskStates.FirstOrDefault(c => c.Data.ID == id);
                            if (item != null)
                                item.IsChecked = true;
                        }
                    }
                }

                XmlHelper.ElementByName(doc.DocumentElement, "SelectedGroup", model, (m, x) =>
                {
                    m.SelectedGroup = model.Groups.FirstOrDefault(g => g.ID == XmlHelper.GetAttributeInt(x, "ID", -1));
                });
            }
        }

        public static string GetViewStateFile()
        {
            string filePath = null;
            IsolatedStorageFile f = IsolatedStorageFile.GetUserStoreForAssembly();
            if (f.FileExists(ConfigurationFileName))
            {
                try
                {
                    using (IsolatedStorageFileStream oStream = new IsolatedStorageFileStream(ConfigurationFileName, FileMode.Open, f))
                        filePath = oStream.GetType().GetField("m_FullPath", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(oStream).ToString();
                }
                catch (Exception) { }
            }

            return filePath;
        }

        public static void DeleteViewStateFile()
        {
            IsolatedStorageFile f = IsolatedStorageFile.GetUserStoreForAssembly();
            f.DeleteFile(ConfigurationFileName);
        }

        #endregion
    }
}
