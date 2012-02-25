using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesktopCore;
using System.ComponentModel;
using System.Globalization;
using System.Threading;

namespace TaskPanel.UI
{
    public class Configuration : NotifyPropertyChanged
    {
        private double mainLeft;
        private double mainTop;
        private double mainWidth = 700;
        private double mainHeight = 500;

        private double detailWidth = 600;
        private double detailHeight = 500;

        private bool showInTaskBar;
        private bool showInWindowList;
        private bool showInTray;

        private bool showTaskInNewWindow;
        private string groupsSort = "Priority";
        private ListSortDirection groupsSortDirection;

        private bool showGroupAll = true;
        private bool showButtonsText = true;

        private CultureInfo locale = Thread.CurrentThread.CurrentCulture;

        private decimal minimumPriority = 1;


        public double MainLeft
        {
            get { return mainLeft; }
            set
            {
                mainLeft = value;
                FirePropertyChanged("MainLeft");
            }
        }

        public double MainTop
        {
            get { return mainTop; }
            set
            {
                mainTop = value;
                FirePropertyChanged("MainTop");
            }
        }

        public double MainWidth
        {
            get { return mainWidth; }
            set
            {
                mainWidth = value;
                FirePropertyChanged("MainWidth");
            }
        }

        public double MainHeight
        {
            get { return mainHeight; }
            set
            {
                mainHeight = value;
                FirePropertyChanged("MainHeight");
            }
        }

        public double DetailWidth
        {
            get { return detailWidth; }
            set
            {
                detailWidth = value;
                FirePropertyChanged("DetailWidth");
            }
        }

        public double DetailHeight
        {
            get { return detailHeight; }
            set
            {
                detailHeight = value;
                FirePropertyChanged("DetailHeight");
            }
        }

        public bool ShowInTaskbar
        {
            get { return showInTaskBar; }
            set
            {
                showInTaskBar = value;
                FirePropertyChanged("ShowInTaskbar");
            }
        }

        public bool ShowInWindowList
        {
            get { return showInWindowList; }
            set
            {
                showInWindowList = value;
                FirePropertyChanged("ShowInWindowList");
            }
        }

        public bool ShowInTray
        {
            get { return showInTray; }
            set
            {
                showInTray = value;
                FirePropertyChanged("ShowInTray");
            }
        }

        public bool ShowTaskInNewWindow
        {
            get { return showTaskInNewWindow; }
            set
            {
                showTaskInNewWindow = value;
                FirePropertyChanged("ShowTaskInNewWindow");
            }
        }

        public string GroupsSort
        {
            get { return groupsSort; }
            set
            {
                groupsSort = value;
                FirePropertyChanged("GroupsSort");
            }
        }

        public ListSortDirection GroupsSortDirection
        {
            get { return groupsSortDirection; }
            set
            {
                groupsSortDirection = value;
                FirePropertyChanged("GroupsSortDirection");
            }
        }

        public bool ShowGroupAll
        {
            get { return showGroupAll; }
            set
            {
                showGroupAll = value;
                FirePropertyChanged("ShowGroupAll");
            }
        }

        public bool ShowButtonsText
        {
            get { return showButtonsText; }
            set
            {
                showButtonsText = value;
                FirePropertyChanged("ShowButtonsText");
            }
        }

        public CultureInfo Locale
        {
            get { return locale; }
            set
            {
                locale = value;
                FirePropertyChanged("Locale");
            }
        }

        public decimal MinimumPriority
        {
            get { return minimumPriority; }
            set
            {
                minimumPriority = value;
                FirePropertyChanged("MinimumPriority");
            }
        }

        public Configuration()
        {
            DetailWidth = 600;
            DetailHeight = 500;

            ShowInTaskbar = true;
            ShowInWindowList = true;
        }
    }
}
