using System;
using System.Collections.Generic;
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
using TaskPanel.Core.Domain;
using TaskPanel.Core.Domain.Repository;
using TaskPanel.Core.Ninject;
using DesktopCore;

namespace TaskPanel.UI.Controls
{
    /// <summary>
    /// Interaction logic for TaskDetail.xaml
    /// </summary>
    public partial class TaskDetail : UserControl
    {
        public static readonly DependencyProperty TaskProperty = DependencyProperty.Register("Task", typeof(ITask), typeof(TaskDetail));
        public static readonly DependencyProperty TaskStatesProperty = DependencyProperty.Register("TaskStates", typeof(ObservableCollection<ITaskState>), typeof(TaskDetail));
        public static readonly DependencyProperty GroupsProperty = DependencyProperty.Register("Groups", typeof(ObservableCollection<IGroup>), typeof(TaskDetail));

        public static readonly RoutedEvent SaveClickEvent = EventManager.RegisterRoutedEvent("SaveClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskDetail));
        public static readonly RoutedEvent CloseClickEvent = EventManager.RegisterRoutedEvent("CloseClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskDetail));

        public IRepository Repository { get; protected set; }
        
        public ITask Task
        {
            get { return (ITask)GetValue(TaskProperty); }
            set { SetValue(TaskProperty, value); }
        }

        public ObservableCollection<ITaskState> TaskStates
        {
            get { return (ObservableCollection<ITaskState>)GetValue(TaskStatesProperty); }
            set { SetValue(TaskStatesProperty, value); }
        }

        public ObservableCollection<IGroup> Groups
        {
            get { return (ObservableCollection<IGroup>)GetValue(GroupsProperty); }
            set { SetValue(GroupsProperty, value); }
        }

        public event RoutedEventHandler SaveClick
        {
            add { AddHandler(SaveClickEvent, value); }
            remove { RemoveHandler(SaveClickEvent, value); }
        }

        public event RoutedEventHandler CloseClick
        {
            add { AddHandler(CloseClickEvent, value); }
            remove { RemoveHandler(CloseClickEvent, value); }
        }

        public TaskDetail()
        {
            InitializeComponent();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                FocusManager.SetFocusedElement(this, tbxContent);
                Keyboard.Focus(tbxContent);
            }
        }

        private void btnSaveTask_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            RoutedEventArgs re = new RoutedEventArgs(SaveClickEvent);
            RaiseEvent(re);
        }

        private void btnCloseTask_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            RoutedEventArgs re = new RoutedEventArgs(CloseClickEvent);
            RaiseEvent(re);
        }
    }
}
