using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ErieGarbageOnline.Database;
using ErieGarbageOnline.Models;
using ErieGarbageOnline.Views;

namespace ErieGarbageOnline.Controllers
{
    public class CustomerController : SharedController
    {
        private readonly CustomerWindow view;
        private readonly Customer user;
        private readonly EGODatabase database = EGODatabase.Create();
        public CustomerController(Customer customer)
        {
            view = new CustomerWindow(this);
            user = customer;
            view.Show();
        }

        public void SendMessage()
        {
            bool success = false;
            if (view.ComplaintButton.IsChecked == true)
            {
                success = database.AddComplaint(new Complaint
                {
                    MessageBody = view.Complaint.Message.Text,
                    CustomerId = user.Id
                });
            }
            else if (view.DisputeButton.IsChecked == true)
            {
                success = database.AddDispute(new Dispute
                {
                    MessageBody = view.Dispute.Message.Text,
                    BillId = int.Parse(view.Dispute.BillIdBox.Text),
                    CustomerId = user.Id
                });
            }
            else if (view.SuspensionButton.IsChecked == true)
            {
                success = database.AddSuspension(new Suspension
                {
                    MessageBody = view.Suspension.Message.Text,
                    CustomerId = user.Id,
                    SuspensionEnds = view.Suspension.SuspensionDate.DisplayDate
                });
            }
            if (success) return;
            MessageBox.Show(view, "Error: Failed to send message.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void MessageType()
        {
            view.Complaint.Visibility = Visibility.Hidden;
            view.Dispute.Visibility = Visibility.Hidden;
            view.Suspension.Visibility = Visibility.Hidden;
            if (view.ComplaintButton.IsChecked == true)
                view.Complaint.Visibility = Visibility.Visible;
            else if (view.DisputeButton.IsChecked == true)
                view.Dispute.Visibility = Visibility.Visible;
            else if (view.SuspensionButton.IsChecked == true)
                view.Suspension.Visibility = Visibility.Visible;
        }
    }
}
