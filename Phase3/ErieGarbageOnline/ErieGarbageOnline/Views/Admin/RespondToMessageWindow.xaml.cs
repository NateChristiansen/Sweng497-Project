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
using ErieGarbageOnline.Models;

namespace ErieGarbageOnline.Views
{
    /// <summary>
    /// Interaction logic for RespondToMessageWindow.xaml
    /// </summary>
    public partial class RespondToMessageWindow : Window
    {
        private readonly Message _msg;
        private AdminController _adminController;
        public RespondToMessageWindow(Message msg, AdminController adminController)
        {
            _msg = msg;
            _adminController = adminController;
            InitializeComponent();
            InitializeMessageResponseWindow();
        }

        private void InitializeMessageResponseWindow()
        {
            this.MsgCustomerIdBox.Text = _msg.CustomerId.ToString();
            this.MsgDateSentBox.Text = _msg.Date.ToLongDateString();
            this.MsgTypeBox.Text = _msg.GetType().Name;
            this.MsgCustomerBody.Text = _msg.MessageBody;
        }

        private void RespondToMsgButton_Click(object sender, RoutedEventArgs e)
        {
            _adminController.RespondToMessage(_msg, this);
        }
    }
}
