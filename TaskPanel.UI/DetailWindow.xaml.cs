using System;
using System.Windows;
using DesktopCore;
using TaskPanel.Core.Domain;
using TaskPanel.Core.Domain.Repository;

namespace TaskPanel.UI
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        public static readonly RoutedEvent SaveClickEvent = EventManager.RegisterRoutedEvent("SaveClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DetailWindow));
        public static readonly RoutedEvent CloseClickEvent = EventManager.RegisterRoutedEvent("CloseClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DetailWindow));

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

        public IRepository Repository { get; protected set; }

        public DetailViewModel ViewModel { get; protected set; }

        public DetailWindow(IRepository repository, Configuration configuration, ITask task, ObservableCollection<ITaskState> taskStates, ObservableCollection<IGroup> groups)
        {
            InitializeComponent();

            Repository = repository;
            ViewModel = new DetailViewModel
            {
                Configuration = configuration,
                Task = task,
                TaskStates = taskStates,
                Groups = groups
            };
            DataContext = ViewModel;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            WindowHelper.ExtendGlassFrame(this);
            Width = ViewModel.Configuration.DetailWidth;
            Height = ViewModel.Configuration.DetailHeight;
        }

        private void tskDetail_SaveClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SaveClickEvent));
            Close();
        }

        private void tskDetail_CloseClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(CloseClickEvent));
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ViewModel.Configuration.DetailWidth = ActualWidth;
            ViewModel.Configuration.DetailHeight = ActualHeight;
        }
    }
}
