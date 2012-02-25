using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DesktopCore;
using DesktopCore.Data;
using TaskPanel.Core.Domain;
using TaskPanel.Core.Domain.Repository;
using TaskPanel.Core.Ninject;
using System.Windows.Media.Animation;
using System.Diagnostics;

namespace TaskPanel.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IRepository Repository { get; protected set; }

        public MainViewModel ViewModel { get; protected set; }

        public System.Windows.Forms.NotifyIcon NotifyIcon { get; protected set; }

        public MainWindow()
        {
            InitializeComponent();

            //Title = String.Format("TaskPanel :: build {0} {1}", VersionInfo.BuildDate.ToShortDateString(), VersionInfo.Version);
            Repository = NinjectFactory.Instance.Get<IRepository>();
            ViewModel = new MainViewModel(this, Repository.Tasks, Repository.Groups, Repository.TaskStates, new Configuration());
            DataContext = ViewModel;

            NotifyIcon = new System.Windows.Forms.NotifyIcon();
            NotifyIcon.Text = "TaskPanel";
            NotifyIcon.Icon = new System.Drawing.Icon("TaskPanel.ico");
            NotifyIcon.Visible = ViewModel.Configuration.ShowInTray;
            NotifyIcon.Click += new EventHandler(delegate
            {
                Show();
                Activate();
            });
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            ViewModel.Configuration.PropertyChanged += new PropertyChangedEventHandler(delegate(object sender, PropertyChangedEventArgs pcea)
            {
                if (pcea.PropertyName == "ShowInTray")
                    NotifyIcon.Visible = ViewModel.Configuration.ShowInTray;
                else if (pcea.PropertyName == "GroupsSort" || pcea.PropertyName == "GroupsSortDirection")
                    ViewModel.SetGroupsSort();
                else if (pcea.PropertyName == "Locale")
                    ViewModel.SetLocale();
                else if(pcea.PropertyName == "MinimumPriority")
                    ViewModelHelper.UpdateTasks(Repository, ViewModel);
            });

            WindowHelper.ExtendGlassFrame(this);
            CollectionHelper.SortCollection(CollectionViewSource.GetDefaultView(ViewModel.Tasks), "Created", true);
            ViewModelHelper.LoadViewState(ViewModel);
            ViewModelHelper.UpdateTasks(Repository, ViewModel);

            if (ViewModel.UserInfo.AutoLogin)
                Login();

            Left = ViewModel.Configuration.MainLeft;
            Top = ViewModel.Configuration.MainTop;
            Width = ViewModel.Configuration.MainWidth;
            Height = ViewModel.Configuration.MainHeight;
        }

        private void Login()
        {
            if (ViewModel.UserInfo.IsSet())
            {
                if (Repository.Load(ViewModel.UserInfo.File, ViewModel.UserInfo.UserName, ViewModel.UserInfo.Password))
                    SetupAfterLogin();
            }
        }

        private void Register()
        {
            if (ViewModel.UserInfo.IsSet())
            {
                if (Repository.Register(ViewModel.UserInfo.File, ViewModel.UserInfo.UserName, ViewModel.UserInfo.Password))
                    SetupAfterLogin();
            }
        }

        private void SetupAfterLogin()
        {
            grdLogin.Visibility = Visibility.Hidden;
            ViewModel.SetTasks(Repository.Tasks);
            ViewModel.SetGroups(Repository.Groups);
            ViewModel.SetTaskStates(Repository.TaskStates);

            ViewModelHelper.LoadRepositoryViewState(ViewModel);
            ViewModelHelper.UpdateTasks(Repository, ViewModel);
        }

        private void ShowTaskDetail()
        {
            if (ViewModel.Configuration.ShowTaskInNewWindow)
            {
                if (ViewModel.OpenedTasks.ContainsKey(ViewModel.EditedTask))
                {
                    ViewModel.OpenedTasks[ViewModel.EditedTask].Activate();
                }
                else
                {
                    DetailWindow window = new DetailWindow(Repository, ViewModel.Configuration, ViewModel.EditedTask, ViewModel.TaskStates, ViewModel.Groups);
                    window.Closed += delegate
                    {
                        ViewModel.OpenedTasks.Remove(window.ViewModel.Task);
                        window = null;
                    };
                    window.SaveClick += new RoutedEventHandler(btnSaveTask_Click);
                    window.CloseClick += new RoutedEventHandler(btnCloseTask_Click);
                    window.Show();
                    ViewModel.OpenedTasks.Add(ViewModel.EditedTask, window);
                }
            }
            else
            {
                tskDetail.Visibility = Visibility.Visible;
                tskDetail.Focus();
                ViewModel.ControlsEnabled = false;
            }
        }

        private void HideTaskDetail()
        {
            tskDetail.Visibility = Visibility.Hidden;
            ViewModel.ControlsEnabled = true;
        }

        private void EditTask()
        {
            if (lvwTasks.SelectedItem != null)
            {
                ViewModel.EditedTask = lvwTasks.SelectedItem as ITask;
                ShowTaskDetail();
            }
        }

        private void CreateTask()
        {
            ITask task = NinjectFactory.Instance.Get<ITask>();
            task.Group = lvwGroups.SelectedItem as IGroup;
            task.State = Repository.TaskStates.FirstOrDefault(s => s.Flag == TaskStateFlag.Initial);
            task.Priority = 1;
            ViewModel.EditedTask = task;
            ShowTaskDetail();
        }

        public void ShowMessage(string message, MessageType type = MessageType.Note)
        {
            lblMessage.Content = message;
            lblMessage.Visibility = Visibility.Visible;
            lblMessage.Opacity = 1d;
            lblMessage.Foreground = new SolidColorBrush(type.ToColor());

            DoubleAnimation anim = new DoubleAnimation();
            anim.From = 1d;
            anim.To = 0d;
            anim.AutoReverse = false;
            anim.FillBehavior = FillBehavior.Stop;
            anim.BeginTime = new TimeSpan(0, 0, 0, 5);
            anim.Completed += new EventHandler(delegate
            {
                lblMessage.Visibility = Visibility.Collapsed;
            });
            lblMessage.BeginAnimation(Label.OpacityProperty, anim);
        }

        public void SortTasks(SortItem item, bool? desc = null)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(ViewModel.Tasks);
            if (view != null)
            {
                SortDescription sortDesc = CollectionHelper.SortCollection(view, item.Property, item.StartDescending);
                ViewModel.Sorts.SortBy(sortDesc.PropertyName, desc != null ? desc.Value : sortDesc.Direction == ListSortDirection.Descending);
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (ViewModel.OpenedTasks.Count > 0)
            {
                if (MessageBox.Show("There are still some opened tasks, do you really want to exit?", "TaskPanel", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }

                DetailWindow[] windows = ViewModel.OpenedTasks.Values.ToArray();
                for (int i = 0; i < windows.Length; i++)
                    windows[i].Close();
            }

            NotifyIcon.Dispose();

            Repository.Commit();

            ViewModel.Configuration.MainLeft = Left;
            ViewModel.Configuration.MainTop = Top;
            ViewModel.Configuration.MainWidth = ActualWidth;
            ViewModel.Configuration.MainHeight = ActualHeight;
            ViewModelHelper.SaveViewState(ViewModel);
        }

        private void mniCreateGroup_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow dialog = new PromptWindow("+Create Group", "Group name:", "", "+Create");
            if (dialog.ShowDialog() == true)
            {
                IGroup group = NinjectFactory.Instance.Get<IGroup>();
                group.Name = dialog.Model.Text;
                Repository.Save(group);
                ViewModel.Groups.Add(group);
            }
        }

        private void lvwGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //IGroup[] groups = ViewModelHelper.FilterItems<IGroup>(lvwGroups.SelectedItems).ToArray(); -- .Where(t => groups.Length > 0 || groups.Contains(t.Group))
            ViewModelHelper.UpdateTasks(Repository, ViewModel);
        }

        private void btnCreateTask_Click(object sender, RoutedEventArgs e)
        {
            //Window1 w = new Window1();
            //w.Show();
            CreateTask();
        }

        private void btnDeleteTask_Click(object sender, RoutedEventArgs e)
        {
            ITask task = lvwTasks.SelectedItem as ITask;
            if (task != null && MessageBox.Show("Delete selected task?", "Delete Task", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Repository.Delete(task);
                ViewModel.Tasks.Remove(task);
            }
        }

        private void btnEditTask_Click(object sender, RoutedEventArgs e)
        {
            EditTask();
        }

        private void lvwTasks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditTask();
        }

        private void btnSaveTask_Click(object sender, RoutedEventArgs e)
        {
            ITask task = ViewModel.EditedTask;
            if (task != null)
            {
                if (task.ID == 0 && lvwGroups.SelectedItem == task.Group)
                    ViewModel.Tasks.Add(task);

                Repository.Save(task);
                ViewModelHelper.UpdateTasks(Repository, ViewModel);
                lvwTasks.SelectedItem = task;
            }
            HideTaskDetail();
        }

        private void btnCloseTask_Click(object sender, RoutedEventArgs e)
        {
            HideTaskDetail();
        }

        private void cbxSelectState_Checked(object sender, RoutedEventArgs e)
        {
            ViewModelHelper.UpdateTasks(Repository, ViewModel);
        }

        private void btnCompleteTask_Click(object sender, RoutedEventArgs e)
        {
            ITask task = (sender as Button).Tag as ITask;
            ITaskState state = Repository.TaskStates.FirstOrDefault(s => s.Flag == TaskStateFlag.Completed);

            if (task != null && state != null && task.State != state)
            {
                task.State = state;
                Repository.Save(task);
                ViewModelHelper.UpdateTasks(Repository, ViewModel);
            }
        }

        private void btnAllTasks_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedGroup = null;
            ViewModelHelper.UpdateTasks(Repository, ViewModel);
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            SortItem item = (sender as Button).Tag as SortItem;
            if (item != null)
                SortTasks(item);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Repository.Commit();

            stopwatch.Stop();
            ShowMessage(String.Format("Tasks saved, it tooked {0}ms!", stopwatch.ElapsedMilliseconds), MessageType.Success);
        }

        private void btnSave_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            ViewModelHelper.SaveViewState(ViewModel);

            stopwatch.Stop();
            ShowMessage(String.Format("Configuration saved, it tooked {0}ms!", stopwatch.ElapsedMilliseconds), MessageType.Success);
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            //ShowMessage("Not yet implemented!", MessageType.Warning);
            ConfigurationWindow window = new ConfigurationWindow(Repository, ViewModel);
            window.Closed += new EventHandler(delegate
            {
                window = null;
            });
            window.ShowDialog();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            ShowMessage("Not yet implemented!", MessageType.Error);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Register();
        }
    }
}
