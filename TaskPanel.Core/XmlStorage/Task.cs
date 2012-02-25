using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using DesktopCore;
using TaskPanel.Core.Domain;

namespace TaskPanel.Core.XmlStorage
{
    public class Task : NotifyPropertyChanged, ITask
    {
        private int id;
        private string content;
        private string solution;
        private DateTime created;
        private DateTime modified;
        private DateTime? deadline;
        private decimal priority;

        private IGroup group;
        private IUser user;
        private ITaskState state;

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                FirePropertyChanged("ID");
            }
        }

        public string Content
        {
            get { return content; }
            set
            {
                content = value;
                FirePropertyChanged("Content");
            }
        }

        public string Solution
        {
            get { return solution; }
            set
            {
                solution = value;
                FirePropertyChanged("Solution");
            }
        }

        public DateTime Created
        {
            get { return created; }
            set
            {
                created = value;
                FirePropertyChanged("Created");
            }
        }

        public DateTime Modified
        {
            get { return modified; }
            set
            {
                modified = value;
                FirePropertyChanged("Modified");
            }
        }

        public DateTime? Deadline
        {
            get { return deadline; }
            set
            {
                deadline = value;
                FirePropertyChanged("Deadline");
            }
        }

        public decimal Priority
        {
            get { return priority; }
            set
            {
                priority = value;
                FirePropertyChanged("Priority");
            }
        }

        public decimal TotalPriority
        {
            get
            {
                decimal result = priority;

                if (Group != null)
                    result *= Group.Priority;

                if (State != null)
                    result *= State.Priority;

                return result;
            }
        }

        public IGroup Group
        {
            get { return group; }
            set
            {
                group = value;
                FirePropertyChanged("Group");
            }
        }

        public IUser User
        {
            get { return user; }
            set
            {
                user = value;
                FirePropertyChanged("User");
            }
        }

        public ITaskState State
        {
            get { return state; }
            set
            {
                state = value;
                FirePropertyChanged("State");
            }
        }
    }
}
