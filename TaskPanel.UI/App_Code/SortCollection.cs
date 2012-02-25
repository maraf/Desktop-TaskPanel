using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesktopCore;

namespace TaskPanel.UI
{
    public class SortCollection : ObservableCollection<SortItem>
    {
        public void SortBy(string property, bool desc)
        {
            ClearSort();

            SortItem item = this.FirstOrDefault(i => i.Property == property);
            if (item != null)
            {
                item.SortedAscending = !desc;
                item.SortedDescending = desc;
            }
        }

        public void ClearSort()
        {
            foreach (SortItem item in Items)
            {
                item.SortedAscending = false;
                item.SortedDescending = false;
            }
        }
    }

    public class SortItem : NotifyPropertyChanged
    {
        private string property;
        private string caption;
        private bool startDescending;
        private bool sortedAscending;
        private bool sortedDescending;

        public string Property
        {
            get { return property; }
            set
            {
                property = value;
                FirePropertyChanged("Property");
            }
        }

        public string Caption
        {
            get { return caption; }
            set
            {
                caption = value;
                FirePropertyChanged("Caption");
            }
        }

        public bool StartDescending
        {
            get { return startDescending; }
            set
            {
                startDescending = value;
                FirePropertyChanged("StartDescending");
            }
        }

        public bool SortedAscending
        {
            get { return sortedAscending; }
            set
            {
                sortedAscending = value;
                FirePropertyChanged("SortedAscending");
            }
        }

        public bool SortedDescending
        {
            get { return sortedDescending; }
            set
            {
                sortedDescending = value;
                FirePropertyChanged("SortedDescending");
            }
        }

        public bool Sorted
        {
            get { return SortedAscending || SortedDescending; }
        }
    }
}
