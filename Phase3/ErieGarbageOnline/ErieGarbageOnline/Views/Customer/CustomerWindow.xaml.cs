using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ErieGarbageOnline.Controllers;

namespace ErieGarbageOnline.Views
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private readonly CustomerController controller;
        public CustomerWindow(CustomerController controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        private void MessageTypeClicked(object sender, RoutedEventArgs e)
        {
            controller.MessageType();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            controller.SendMessage();
        }
    }
}
