﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesktopCore;
using TaskPanel.Core.Domain;
using System.Windows.Media.Imaging;
using System.IO;

namespace TaskPanel.Core.XmlStorage
{
    public class Group : NotifyPropertyChanged, IGroup
    {
        private int id;
        private string name;
        private BitmapImage image;
        private string imagePath;
        private GroupFlag flag;
        private decimal priority;

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                FirePropertyChanged("ID");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                FirePropertyChanged("Name");
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

        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                FirePropertyChanged("ImagePath");

                try
                {
                    Image = new BitmapImage();
                    Image.BeginInit();
                    Image.UriSource = new Uri(ImagePath);
                    Image.EndInit();
                }
                catch (Exception)
                {
                    Image = null;
                }
            }
        }

        public GroupFlag Flag
        {
            get { return flag; }
            set
            {
                flag = value;
                FirePropertyChanged("Flag");
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
    }
}
