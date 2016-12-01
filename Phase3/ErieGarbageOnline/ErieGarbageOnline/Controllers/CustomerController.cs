using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using ErieGarbageOnline.Models;
using ErieGarbageOnline.Views;

namespace ErieGarbageOnline.Controllers
{
    public class CustomerController : SharedController
    {
        private readonly CustomerWindow view;
        public CustomerController(Customer customer)
        {
            view = new CustomerWindow(this);
            User = customer;
            GetBills();
            view.Show();
        }

        public void SendMessage()
        {
            bool success = false;
            if (view.ComplaintButton.IsChecked == true)
            {
                success = Database.AddComplaint(new Complaint
                {
                    MessageBody = view.Complaint.Message.Text,
                    CustomerId = User.Id
                });
            }
            else if (view.DisputeButton.IsChecked == true)
            {
                success = Database.AddDispute(new Dispute
                {
                    MessageBody = view.Dispute.Message.Text,
                    BillId = int.Parse(view.Dispute.BillIdBox.Text),
                    CustomerId = User.Id
                });
            }
            else if (view.SuspensionButton.IsChecked == true)
            {
                success = Database.AddSuspension(new Suspension
                {
                    MessageBody = view.Suspension.Message.Text,
                    CustomerId = User.Id,
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

        public void GetBills()
        {
            view.Bills.Items.Clear();
            view.Bills.ItemsSource = Database.Bills().Where(b => b.CustomerId == User.Id);
        }
    }
}
