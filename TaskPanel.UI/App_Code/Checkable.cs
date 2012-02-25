using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesktopCore;

namespace TaskPanel.UI
{
    public class Checkable
    {
        public static Checkable<T> Create<T>(T item, bool isChecked) where T : class
        {
            return new Checkable<T> { Data = item, IsChecked = isChecked };
        }

        public static IEnumerable<Checkable<T>> Create<T>(IEnumerable<T> items, bool isChecked) where T : class
        {
            foreach (T item in items)
                yield return Checkable.Create(item, isChecked);
        }
    }

    public class Checkable<T> : NotifyPropertyChanged where T : class
    {
        private bool isChecked;
        private T data;

        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                FirePropertyChanged("IsChecked");
            }
        }

        public T Data
        {
            get { return data; }
            set
            {
                data = value;
                FirePropertyChanged("Data");
            }
        }
    }
}
