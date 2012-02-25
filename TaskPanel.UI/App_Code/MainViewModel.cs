using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesktopCore;
using TaskPanel.Core.Domain;
using System.ComponentModel;
using System.Windows.Data;
using System.Threading;

namespace TaskPanel.UI
{
    public class MainViewModel : NotifyPropertyChanged
    {
        private ITask editedTask;
        private IGroup editedGroup;
        private ITaskState editedTaskState;

        private IGroup selectedGroup;

        private bool controlsEnabled = true;
        private Configuration configuration;

        private Dictionary<ITask, DetailWindow> openedTasks;

        private UserInfo userInfo;

        public MainWindow Window { get; protected set; }

        public ObservableCollection<ITask> Tasks { get; protected set; }

        public ObservableCollection<IGroup> Groups { get; protected set; }

        public ObservableCollection<ITaskState> TaskStates { get; protected set; }

        public ObservableCollection<Checkable<ITaskState>> CheckableTaskStates { get; protected set; }

        public SortCollection Sorts { get; protected set; }

        public ITask EditedTask
        {
            get { return editedTask; }
            set
            {
                editedTask = value;
                FirePropertyChanged("EditedTask");
            }
        }

        public IGroup EditedGroup
        {
            get { return editedGroup; }
            set
            {
                editedGroup = value;
                FirePropertyChanged("EditedGroup");
            }
        }

        public ITaskState EditedTaskState
        {
            get { return editedTaskState; }
            set
            {
                editedTaskState = value;
                FirePropertyChanged("EditedTaskState");
            }
        }

        public IGroup SelectedGroup
        {
            get { return selectedGroup; }
            set
            {
                selectedGroup = value;
                FirePropertyChanged("SelectedGroup");
            }
        }

        public bool ControlsEnabled
        {
            get { return controlsEnabled; }
            set
            {
                controlsEnabled = value;
                FirePropertyChanged("ControlsEnabled");
            }
        }

        public Configuration Configuration
        {
            get { return configuration; }
            protected set
            {
                configuration = value;
                FirePropertyChanged("Configuration");
            }
        }

        public Dictionary<ITask, DetailWindow> OpenedTasks
        {
            get { return openedTasks; }
            set
            {
                openedTasks = value;
                FirePropertyChanged("OpenedTasks");
            }
        }

        public UserInfo UserInfo
        {
            get { return userInfo; }
            set
            {
                userInfo = value;
                FirePropertyChanged("UserInfo");
            }
        }

        public MainViewModel(MainWindow window, IEnumerable<ITask> tasks, IEnumerable<IGroup> groups, IEnumerable<ITaskState> taskStates, Configuration configuration)
        {
            Window = window;
            Configuration = configuration;
            OpenedTasks = new Dictionary<ITask, DetailWindow>();

            SetTasks(tasks);
            SetGroups(groups);
            SetTaskStates(taskStates);

            Sorts = new SortCollection();
            Sorts.Add(new SortItem
            {
                Caption = Resource.Get("Sort.Content"),
                Property = "Content"
            });
            Sorts.Add(new SortItem
            {
                Caption = Resource.Get("Sort.Created"),
                Property = "Created"
            });
            Sorts.Add(new SortItem
            {
                Caption = Resource.Get("Sort.Modified"),
                Property = "Modified"
            });
            Sorts.Add(new SortItem
            {
                Caption = Resource.Get("Sort.Priority"),
                Property = "Priority",
                StartDescending = true
            });

            UserInfo = new UserInfo();
        }

        public void SetGroupsSort()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(Groups);
            if (view != null)
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(Configuration.GroupsSort, Configuration.GroupsSortDirection));
            }
        }

        public void SetLocale()
        {
            Thread.CurrentThread.CurrentCulture = Configuration.Locale;
            Thread.CurrentThread.CurrentUICulture = Configuration.Locale;
            Resource.Load("Resources/Resources");
            Resource.ReProvideAll();
        }

        public void SetTasks(IEnumerable<ITask> tasks)
        {
            if(Tasks == null)
                Tasks = new ObservableCollection<ITask>();

            if (tasks != null)
            {
                Tasks.Clear();
                Tasks.AddRange(tasks);

                ICollectionView view = CollectionViewSource.GetDefaultView(Tasks);
                if (view != null)
                {
                    view.GroupDescriptions.Clear();
                    view.GroupDescriptions.Add(new PropertyGroupDescription("Priority"));
                }
            }
        }

        public void SetGroups(IEnumerable<IGroup> groups)
        {
            if (Groups == null)
                Groups = new ObservableCollection<IGroup>();

            if (groups != null)
            {
                Groups.Clear();
                Groups.AddRange(groups);
            }
        }

        public void SetTaskStates(IEnumerable<ITaskState> taskStates)
        {
            if (TaskStates == null)
                TaskStates = new ObservableCollection<ITaskState>();

            if (CheckableTaskStates == null)
                CheckableTaskStates = new ObservableCollection<Checkable<ITaskState>>();

            if (taskStates != null)
            {
                TaskStates.Clear();
                TaskStates.AddRange(taskStates);

                CheckableTaskStates.AddRange(Checkable.Create(taskStates, true));
            }
        }
    }
}
