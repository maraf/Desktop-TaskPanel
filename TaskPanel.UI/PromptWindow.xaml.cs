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

namespace TaskPanel.UI
{
    /// <summary>
    /// Interaction logic for PromptWindow.xaml
    /// </summary>
    public partial class PromptWindow : Window
    {
        public PromptModel Model { get; set; }

        public PromptWindow(string title, string label, string text, string button)
        {
            InitializeComponent();

            Model = new PromptModel { Title = title, Label = label, Text = text, Button = button };
            DataContext = Model;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }

    public class PromptModel
    {
        public string Title { get; set; }
        public string Label { get; set; }
        public string Text { get; set; }
        public string Button { get; set; }
    }
}
