using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesktopCore;
using TaskPanel.Core.Domain;

namespace TaskPanel.UI
{
    public class DetailViewModel : NotifyPropertyChanged
    {
        private Configuration configuration;
        private ITask task;
        private ObservableCollection<ITaskState> taskStates;
        private ObservableCollection<IGroup> groups;

        public Configuration Configuration
        {
            get { return configuration; }
            set
            {
                configuration = value;
                FirePropertyChanged("Configuration");
            }
        }

        public ITask Task
        {
            get { return task; }
            set
            {
                task = value;
                FirePropertyChanged("Task");
            }
        }

        public ObservableCollection<ITaskState> TaskStates
        {
            get { return taskStates; }
            set
            {
                taskStates = value;
                FirePropertyChanged("TaskStates");
            }
        }

        public ObservableCollection<IGroup> Groups
        {
            get { return groups; }
            set
            {
                groups = value;
                FirePropertyChanged("Groups");
            }
        }
    }
}
