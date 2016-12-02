using System.Globalization;
using System.Windows;
using ErieGarbageOnline.Database;
using ErieGarbageOnline.Models;

namespace ErieGarbageOnline.Views.Customer
{
    /// <summary>
    /// Interaction logic for ViewBill.xaml
    /// </summary>
    public partial class ViewBill : Window
    {
        private readonly Bill bill;
        public ViewBill(Bill b)
        {
            bill = b;
            InitializeComponent();
            AmountDueBox.Text = bill.Amount.ToString(CultureInfo.CurrentCulture);
            DueDateBox.Text = bill.DateDue.Date.ToString(CultureInfo.CurrentCulture);
            PayBillButton.Visibility = bill.Paid ? Visibility.Hidden : Visibility.Visible;
        }

        private void PayBillButton_Click(object sender, RoutedEventArgs e)
        {
            if (!EGODatabase.Create().PayBill(bill))
                MessageBox.Show(this, "Error: Unable to pay bill.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            Close();
        }

        private void CacnelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
