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
using System.Windows.Shapes;
using DesktopCore;
using TaskPanel.Core.Domain.Repository;
using TaskPanel.Core.Domain;
using TaskPanel.Core.Ninject;
using System.ComponentModel;

namespace TaskPanel.UI
{
    /// <summary>
    /// Interaction logic for ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : Window
    {
        public IRepository Repository { get; protected set; }

        public ConfigurationViewModel ViewModel { get; protected set; }

        public ConfigurationWindow(IRepository repository, MainViewModel viewModel)
        {
            InitializeComponent();

            Repository = repository;

            ViewModel = new ConfigurationViewModel(viewModel);
            DataContext = ViewModel;

            coxLanguages.ItemsSource = DesktopCore.Resources.GetSupportedLocales("Resources/Resources", "en-US");
            coxGroupFlag.ItemsSource = DesktopCore.ResourceHelper.GetEnum<GroupFlag>(DesktopCore.Resource.Resources);
            coxStateFlag.ItemsSource = DesktopCore.ResourceHelper.GetEnum<TaskStateFlag>(DesktopCore.Resource.Resources);

            coxGroupsSort.Items.Add(new NameValueItem { Name = Resource.Get("Common.Name"), Value = "Name" });
            coxGroupsSort.Items.Add(new NameValueItem { Name = Resource.Get("Common.Priority"), Value = "Priority" });

            coxGroupsSortDirection.Items.Add(new NameValueItem { Name = Resource.Get("Sort.Ascending"), Value = ListSortDirection.Ascending });
            coxGroupsSortDirection.Items.Add(new NameValueItem { Name = Resource.Get("Sort.Descending"), Value = ListSortDirection.Descending });

            lblVersion.Content = String.Format("Version: build {0} {1}", VersionInfo.BuildDate.ToShortDateString(), VersionInfo.Version);
            tbxConfigFile.Text = ViewModelHelper.GetViewStateFile();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            WindowHelper.ExtendGlassFrame(this);
        }

        #region Group

        private void btnGroupCreate_Click(object sender, RoutedEventArgs e)
        {
            IGroup group = NinjectFactory.Instance.Get<IGroup>();
            group.Name = "New Group";
            group.Priority = 1.5M;
            ViewModel.Groups.Add(group);
            ViewModel.SelectedGroup = group;
            Repository.Save(group);
        }

        private void btnGroupDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvwGroups.SelectedItem != null)
            {
                Repository.Delete(lvwGroups.SelectedItem as IGroup);
                ViewModel.Groups.Remove(lvwGroups.SelectedItem as IGroup);
            }
        }

        private void sldGroupPriority_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ViewModel != null)
            {
                ICollectionView view = CollectionViewSource.GetDefaultView(ViewModel.Groups);
                if (view != null)
                    view.Refresh();
            }
        }

        private void lvwGroupIcons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.SelectedGroup.ImagePath = (lvwGroupIcons.SelectedItem as IconImage).ImagePath;
        }

        #endregion

        #region TaskState

        private void btnStateCreate_Click(object sender, RoutedEventArgs e)
        {
            ITaskState state = NinjectFactory.Instance.Get<ITaskState>();
            state.Name = "New task state";
            state.Priority = 1.5M;
            ViewModel.TaskStates.Add(state);
            ViewModel.CheckableTaskStates.Add(Checkable.Create(state, true));
            ViewModel.SelectedTaskState = state;
            Repository.Save(state);
        }

        private void btnStateDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvwStates.SelectedItem != null)
            {
                Repository.Delete(lvwStates.SelectedItem as ITaskState);
                ViewModel.TaskStates.Remove(lvwStates.SelectedItem as ITaskState);
            }
        }

        private void sldStatePriority_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ViewModel != null)
            {
                ICollectionView view = CollectionViewSource.GetDefaultView(ViewModel.TaskStates);
                if (view != null)
                    view.Refresh();
            }
        }

        private void lvwStateIcons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.SelectedTaskState.ImagePath = (lvwStateIcons.SelectedItem as IconImage).ImagePath;
        }

        #endregion

        private void btnCopyConfig_Click(object sender, RoutedEventArgs e)
        {
            ClipboardHelper.CopyFiles(ViewModelHelper.GetViewStateFile());
        }

        private void btnDeleteConfig_Click(object sender, RoutedEventArgs e)
        {
            ViewModelHelper.DeleteViewStateFile();
        }
    }
}
