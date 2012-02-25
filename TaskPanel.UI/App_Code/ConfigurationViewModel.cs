using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using DesktopCore;
using TaskPanel.Core.Domain;
using System.Windows.Media.Imaging;
using System.IO;

namespace TaskPanel.UI
{
    public class ConfigurationViewModel : NotifyPropertyChanged
    {
        private Configuration configuration;
        private IGroup selectedGroup;
        private ITaskState selectedTaskState;

        public Configuration Configuration
        {
            get { return configuration; }
            set
            {
                configuration = value;
                FirePropertyChanged("Configuration");
            }
        }

        public ObservableCollection<IGroup> Groups { get; protected set; }

        public ObservableCollection<ITaskState> TaskStates { get; protected set; }

        public ObservableCollection<Checkable<ITaskState>> CheckableTaskStates { get; protected set; }

        public ObservableCollection<IconImage> GroupIcons { get; protected set; }

        public ObservableCollection<IconImage> TaskStateIcons { get; protected set; }

        public IGroup SelectedGroup
        {
            get { return selectedGroup; }
            set
            {
                selectedGroup = value;
                FirePropertyChanged("SelectedGroup");
            }
        }

        public ITaskState SelectedTaskState
        {
            get { return selectedTaskState; }
            set
            {
                selectedTaskState = value;
                FirePropertyChanged("SelectedTaskState");
            }
        }

        //public ConfigurationViewModel(Configuration configuration, IEnumerable<IGroup> groups, IEnumerable<ITaskState> taskStates)
        //{
        //    Configuration = configuration;

        //    Groups = new ObservableCollection<IGroup>(groups);
        //    TaskStates = new ObservableCollection<ITaskState>(taskStates);

        //    //TODO: Remove
        //    ICollectionView view = CollectionViewSource.GetDefaultView(Groups);
        //    if (view != null)
        //        view.SortDescriptions.Add(new SortDescription("Priority", ListSortDirection.Descending));

        //    LoadIcons();
        //}

        public ConfigurationViewModel(MainViewModel viewModel)
        {
            Configuration = viewModel.Configuration;
            Groups = viewModel.Groups;
            TaskStates = viewModel.TaskStates;
            CheckableTaskStates = viewModel.CheckableTaskStates;

            LoadIcons();
        }

        private void LoadIcons()
        {
            string states = Path.Combine(Environment.CurrentDirectory, "Resources/Icons/TaskStates");
            string groups = Path.Combine(Environment.CurrentDirectory, "Resources/Icons/Groups");

            GroupIcons = new ObservableCollection<IconImage>();
            foreach (string file in Directory.GetFiles(groups, "*.png"))
                GroupIcons.Add(new IconImage(file));

            TaskStateIcons = new ObservableCollection<IconImage>();
            foreach (string file in Directory.GetFiles(states, "*.png"))
                TaskStateIcons.Add(new IconImage(file));
        }
    }

    public class IconImage : NotifyPropertyChanged
    {
        private string imagePath;
        private BitmapImage image;

        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                FirePropertyChanged("ImagePath");

                if (ImagePath != null)
                {
                    try
                    {
                        Image = new BitmapImage();
                        Image.BeginInit();
                        Image.UriSource = new Uri(value);
                        Image.EndInit();
                    }
                    catch (FileNotFoundException e)
                    {
                        Image = null;
                    }
                }
            }
        }

        public BitmapImage Image
        {
            get { return image; }
            set
            {
                image = value;
                FirePropertyChanged("Image");
            }
        }

        public IconImage()
        {

        }

        public IconImage(string imagePath)
        {
            ImagePath = imagePath;
        }
    }
}
