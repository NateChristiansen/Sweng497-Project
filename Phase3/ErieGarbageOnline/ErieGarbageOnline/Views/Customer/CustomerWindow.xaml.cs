using System.Windows;
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

        private void RefreshBills_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
