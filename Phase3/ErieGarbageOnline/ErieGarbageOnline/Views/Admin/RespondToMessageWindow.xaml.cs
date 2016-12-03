using System.Windows;
using ErieGarbageOnline.Controllers;
using ErieGarbageOnline.Database;
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
        private readonly EGODatabase _database = EGODatabase.Create();
        public RespondToMessageWindow(Message msg, AdminController a)
        {
            _msg = msg;
            _database.SetMessageViewed(_msg);
            _adminController = a;
            InitializeComponent();
            InitializeMessageResponseWindow();
            _database.ViewMessage(msg);
        }

        private void InitializeMessageResponseWindow()
        {
            MsgCustomerIdBox.Text = _msg.CustomerId.ToString();
            MsgDateSentBox.Text = _msg.Date.ToLongDateString();
            MsgTypeBox.Text = _msg.GetType().Name;
            MsgCustomerBody.Text = _msg.MessageBody;
        }

        private void RespondToMsgButton_Click(object sender, RoutedEventArgs e)
        {
            _adminController.RespondToMessage(_msg, this);
        }
    }
}
