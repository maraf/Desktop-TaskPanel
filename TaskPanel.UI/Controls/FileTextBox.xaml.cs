using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows.Data;
using DesktopCore.Data;

namespace TaskPanel.UI.Controls
{
    [System.Windows.Markup.ContentProperty("FileName")]
    public partial class FileTextBox : UserControl
    {
        public string FileName
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }

        public bool CheckPathExists
        {
            get { return (bool)GetValue(CheckPathExistsProperty); }
            set { SetValue(CheckPathExistsProperty, value); }
        }

        public bool CheckFileExists
        {
            get { return (bool)GetValue(CheckFileExistsProperty); }
            set { SetValue(CheckFileExistsProperty, value); }
        }
            

        public event RoutedEventHandler FileNameChanged
        {
            add { AddHandler(FileNameChangedEvent, value); }
            remove { RemoveHandler(FileNameChangedEvent, value); }
        }

        public FileTextBox()
        {
            InitializeComponent();
            tbxPath.TextChanged += new TextChangedEventHandler(OnTextChanged);
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.CheckPathExists = CheckPathExists;
            d.CheckFileExists = CheckFileExists;
            d.FileName = System.IO.Path.GetFileName(FileName);
            d.InitialDirectory = System.IO.Path.GetDirectoryName(FileName);

            if (d.ShowDialog() == true)
            {
                if (BindingOperations.IsDataBound(this, FileNameProperty))
                    BindingManager.SetValue(BindingOperations.GetBindingExpression(this, FileNameProperty), d.FileName);
                else
                    FileName = d.FileName;
            }
        }
        
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (BindingOperations.IsDataBound(this, FileNameProperty))
                BindingManager.SetValue(BindingOperations.GetBindingExpression(this, FileNameProperty), tbxPath.Text);
            else
                FileName = tbxPath.Text;

            e.Handled = true;
            RoutedEventArgs args = new RoutedEventArgs(FileNameChangedEvent);
            RaiseEvent(args);
        }

        public static readonly DependencyProperty FileNameProperty = DependencyProperty.Register("FileName", typeof(string), typeof(FileTextBox));
        public static readonly DependencyProperty CheckPathExistsProperty = DependencyProperty.Register("CheckPathExists", typeof(bool), typeof(FileTextBox), new PropertyMetadata(true));
        public static readonly DependencyProperty CheckFileExistsProperty = DependencyProperty.Register("CheckFileExists", typeof(bool), typeof(FileTextBox), new PropertyMetadata(true));
        
        public static readonly RoutedEvent FileNameChangedEvent = EventManager.RegisterRoutedEvent("FileNameChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FileTextBox));
    }
}