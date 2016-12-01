using System;
using System.Linq;
using System.Windows;
using ErieGarbageOnline.Models;
using ErieGarbageOnline.Views.Customer;
using Complaint = ErieGarbageOnline.Models.Complaint;
using Dispute = ErieGarbageOnline.Models.Dispute;
using Suspension = ErieGarbageOnline.Models.Suspension;

namespace ErieGarbageOnline.Controllers
{
    public class CustomerController : SharedController
    {
        private readonly CustomerWindow view;
        public CustomerController(Customer customer)
        {
            view = new CustomerWindow(this) { WelcomeLabel = { Content = "Welcome, " + customer.Email } };
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
                    SuspensionEnds = (DateTime) view.Suspension.SuspensionDate.SelectedDate
                });
            }
            if (success)
            {
                MessageBox.Show(view, "Message sent successfully.", "Message Sent", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }
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
            {
                view.Dispute.Visibility = Visibility.Visible;
                view.Dispute.BillIdBox.ItemsSource = Database.Bills().Where(b => b.CustomerId == User.Id).Select(b => b.Id);
            }
            else if (view.SuspensionButton.IsChecked == true)
                view.Suspension.Visibility = Visibility.Visible;
        }

        public void GetBills()
        {
            view.Bills.ItemsSource = Database.Bills().Where(b => b.CustomerId == User.Id);
        }

        public void OpenBill()
        {
            var bill = view.Bills.SelectedItem as Bill;
            var billwindow = new ViewBill(bill);
            billwindow.ShowDialog();
            GetBills();
        }
    }
}
