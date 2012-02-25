using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace TaskPanel.Core.Domain
{
    public interface IGroup
    {
        int ID { get; set; }

        string Name { get; set; }

        BitmapImage Image { get; set; }

        string ImagePath { get; set; }

        GroupFlag Flag { get; set; }

        decimal Priority { get; set; }
    }
}
