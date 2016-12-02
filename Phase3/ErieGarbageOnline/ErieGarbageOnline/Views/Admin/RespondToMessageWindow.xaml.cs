using System.Windows;
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
        private readonly EGODatabase _database = EGODatabase.Create();
        public RespondToMessageWindow(Message msg)
        {
            _msg = msg;
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
            Close();
        }
    }
}
