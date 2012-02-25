using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace TaskPanel.UI
{
    public enum MessageType
    {
        Success, Error, Warning, Note
    }

    public static class MessageTypeExtensions
    {
        public static Color ToColor(this MessageType type)
        {
            switch (type)
            {
                case MessageType.Success:
                    return Colors.LightGreen;
                case MessageType.Error:
                    return Colors.Red;
                case MessageType.Warning:
                    return Colors.Orange;
                case MessageType.Note:
                    return Colors.White;
                default:
                    return Colors.White;
            }
        }
    }
}
