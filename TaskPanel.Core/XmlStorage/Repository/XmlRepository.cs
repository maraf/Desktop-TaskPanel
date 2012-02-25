using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskPanel.Core.Domain.Repository;
using TaskPanel.Core.Domain;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;
using DesktopCore;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TaskPanel.Core.XmlStorage.Repository
{
    public class XmlRepository : IRepository
    {
        private string location;
        private string username;
        private string password;
        private bool loaded;

        private IUser user;
        private List<ITask> tasks = new List<ITask>();
        private List<IGroup> groups = new List<IGroup>();
        private List<ITaskState> states = new List<ITaskState>();

        public IUser User { get { return user; } }

        public IQueryable<ITask> Tasks { get { return tasks.AsQueryable(); } }

        public IQueryable<IGroup> Groups { get { return groups.AsQueryable(); } }

        public IQueryable<ITaskState> TaskStates { get { return states.AsQueryable(); } }

        public bool Encrypted { get; set; }

        public bool Load(string location, string username, string password)
        {
            if (File.Exists(location))
            {
                this.location = location;

                XmlDocument doc = new XmlDocument();
                doc.Load(location);

                Encrypted = XmlHelper.GetAttributeBool(doc.DocumentElement, "Encrypted", false);
                if (Encrypted)
                {
                    string content;
                    if (CryptoHelper.Decrypt(doc.DocumentElement.InnerXml, password, out content))
                        doc.DocumentElement.InnerXml = content;
                }

                foreach (XmlElement item in doc.GetElementsByTagName("User"))
                {
                    if (XmlHelper.GetAttributeValue(item, "UserName") == username && XmlHelper.GetAttributeValue(item, "Password") == password)
                    {
                        this.username = username;
                        this.password = password;

                        //User
                        user = new User
                        {
                            ID = XmlHelper.GetAttributeInt(item, "ID", -1),
                            UserName = username,
                            Password = password,
                            FirstName = XmlHelper.GetAttributeValue(item, "FirstName"),
                            LastName = XmlHelper.GetAttributeValue(item, "LastName")
                        };

                        //TaskState
                        foreach (XmlElement state in item.GetElementsByTagName("TaskState"))
                        {
                            states.Add(new TaskState
                            {
                                ID = XmlHelper.GetAttributeInt(state, "ID", -1),
                                Name = XmlHelper.GetAttributeValue(state, "Name"),
                                ImagePath = XmlHelper.GetAttributeValue(state, "ImagePath"),
                                Flag = XmlHelper.GetAttributeEnum<TaskStateFlag>(state, "Flag", TaskStateFlag.None),
                                Priority = XmlHelper.GetAttributeDecimal(state, "Priority", 1)
                            });
                        }

                        //Group
                        foreach (XmlElement group in item.GetElementsByTagName("Group"))
                        {
                            groups.Add(new Group
                            {
                                ID = XmlHelper.GetAttributeInt(group, "ID", -1),
                                Name = XmlHelper.GetAttributeValue(group, "Name"),
                                ImagePath = XmlHelper.GetAttributeValue(group, "ImagePath"),
                                Flag = XmlHelper.GetAttributeEnum<GroupFlag>(group, "Flag", GroupFlag.None),
                                Priority = XmlHelper.GetAttributeDecimal(group, "Priority", 1)
                            });
                        }

                        //Task
                        foreach (XmlElement task in item.GetElementsByTagName("Task"))
                        {
                            tasks.Add(new Task
                            {
                                ID = XmlHelper.GetAttributeInt(task, "ID", -1),
                                Content = XmlHelper.GetAttributeValue(task, "Content"),
                                Solution = XmlHelper.GetAttributeValue(task, "Solution"),
                                Created = XmlHelper.GetAttributeDateTime(task, "Created"),
                                Modified = XmlHelper.GetAttributeDateTime(task, "Modified"),
                                Deadline = XmlHelper.GetAttributeDateTimeNull(task, "Deadline"),
                                Group = Groups.First(g => g.ID == XmlHelper.GetAttributeInt(task, "GroupID", 1)),
                                User = user,
                                State = TaskStates.First(s => s.ID == XmlHelper.GetAttributeInt(task, "TaskStateID", 1)),
                                Priority = XmlHelper.GetAttributeDecimal(task, "Priority", 1)
                            });
                        }

                        loaded = true;
                        break;
                    }
                }

                if (user == null)
                    loaded = false;
            }

            return loaded;
        }

        public bool Register(string location, string username, string password)
        {
            if (!File.Exists(location) && !String.IsNullOrEmpty(username))
            {
                this.location = location;
                this.username = username;
                this.password = password;

                user = new User
                {
                    UserName = username,
                    Password = password
                };
                tasks = new List<ITask>();
                groups = new List<IGroup>();
                states = new List<ITaskState>();
                loaded = true;

                return true;
            }
            return false;
        }

        public void Commit()
        {
            if (!loaded)
                return;

            if (File.Exists(location))
                File.Copy(location, location + ".bak");

            XmlDocument doc = XmlHelper.CreateDocument();

            XmlElement xpanel = doc.CreateElement("TaskPanel");
            doc.AppendChild(xpanel);

            //User
            XmlElement xuser = XmlHelper.SetAttributes(doc, xpanel, "User", User, (u, x) =>
            {
                XmlHelper.SetAttribute(doc, x, "ID", u.ID);
                XmlHelper.SetAttribute(doc, x, "UserName", u.UserName);
                XmlHelper.SetAttribute(doc, x, "Password", u.Password);
                XmlHelper.SetAttribute(doc, x, "FirstName", u.FirstName);
                XmlHelper.SetAttribute(doc, x, "LastName", u.LastName);
                return x;
            });

            //TaskState
            XmlHelper.SetAttributes(doc, xuser, "TaskStates", "TaskState", TaskStates, (s, x) =>
            {
                XmlHelper.SetAttribute(doc, x, "ID", s.ID);
                XmlHelper.SetAttribute(doc, x, "Name", s.Name);
                XmlHelper.SetAttribute(doc, x, "ImagePath", (s as TaskState).ImagePath);
                XmlHelper.SetAttribute(doc, x, "Flag", s.Flag.ToString());
                XmlHelper.SetAttribute(doc, x, "Priority", s.Priority);
            });

            //Group
            XmlHelper.SetAttributes<IGroup>(doc, xuser, "Groups", "Group", Groups, (g, x) =>
            {
                XmlHelper.SetAttribute(doc, x, "ID", g.ID);
                XmlHelper.SetAttribute(doc, x, "Name", g.Name);
                XmlHelper.SetAttribute(doc, x, "ImagePath", (g as Group).ImagePath);
                XmlHelper.SetAttribute(doc, x, "Flag", g.Flag.ToString());
                XmlHelper.SetAttribute(doc, x, "Priority", g.Priority);
            });

            //Task
            XmlHelper.SetAttributes<ITask>(doc, xuser, "Tasks", "Task", Tasks, (t, x) =>
            {
                XmlHelper.SetAttribute(doc, x, "ID", t.ID);
                XmlHelper.SetAttribute(doc, x, "Content", t.Content);
                XmlHelper.SetAttribute(doc, x, "Solution", t.Solution);
                XmlHelper.SetAttribute(doc, x, "Created", t.Created.Ticks);
                XmlHelper.SetAttribute(doc, x, "Modified", t.Modified.Ticks);
                XmlHelper.SetAttribute(doc, x, "Deadline", t.Deadline != null ? t.Deadline.Value.Ticks.ToString() : null);
                XmlHelper.SetAttribute(doc, x, "GroupID", t.Group.ID);
                XmlHelper.SetAttribute(doc, x, "TaskStateID", t.State.ID);
                XmlHelper.SetAttribute(doc, x, "UserID", t.User.ID);
                XmlHelper.SetAttribute(doc, x, "Priority", t.Priority);
            });

            doc.Save(location);

            if (File.Exists(location + ".bak"))
                File.Delete(location + ".bak");
        }

        public void Save(ITask task)
        {
            task.Modified = DateTime.Now;
            if (task.ID == 0)
            {
                if (tasks.Count > 0)
                    task.ID = Tasks.Max(t => t.ID) + 1;
                else
                    task.ID = 1;
                task.Created = DateTime.Now;
                if (task.User == null)
                    task.User = user;

                tasks.Add(task);
            }
        }

        public void Save(IGroup group)
        {
            if (group.ID == 0)
            {
                if (groups.Count > 0)
                    group.ID = Groups.Max(g => g.ID) + 1;
                else
                    group.ID = 1;
                groups.Add(group);
            }
        }

        public void Save(ITaskState state)
        {
            if (state.ID == 0)
            {
                if (states.Count > 0)
                    state.ID = TaskStates.Max(s => s.ID) + 1;
                else
                    state.ID = 1;
                states.Add(state);
            }
        }

        public void Delete(ITask task)
        {
            tasks.Remove(task);
        }

        public void Delete(IGroup group)
        {
            foreach (ITask task in Tasks.Where(t => t.Group == group).ToArray())
                Delete(task);

            groups.Remove(group);
        }

        public void Delete(ITaskState state)
        {
            ITaskState newState = TaskStates.FirstOrDefault(s => s.Flag == TaskStateFlag.Initial);

            foreach (ITask task in Tasks.Where(t => t.State == state).ToArray())
            {
                if(newState != null)
                    task.State = newState;
                else
                    tasks.Remove(task);
            }

            states.Remove(state);
        }
    }
}
