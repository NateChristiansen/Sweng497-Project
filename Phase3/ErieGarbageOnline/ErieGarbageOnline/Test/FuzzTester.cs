using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using ErieGarbageOnline.Controllers;
using ErieGarbageOnline.Views;
using ErieGarbageOnline.Views.Login;

namespace ErieGarbageOnline.Test
{
    class FuzzTester
    {
        public void TestLogin(LoginWindow login, int amountToRun, int type)
        {
            StringBuilder sb = new StringBuilder();
            Random r;
            int index = 0;
            int fails = 0;
            while (index <= amountToRun)
            {
                try
                {
                    r = new Random(Guid.NewGuid().GetHashCode());
                    login.EmailField.Text = GetRandomString(r.Next(1000));
                    login.PasswordField.Password = GetRandomString(r.Next(1000));

                    login.LoginButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    sb.Append("SUCCESS: EMAIL: " + login.EmailField.Text + " PASSWORD: " + login.PasswordField.Password + "\n");
                    Thread.Sleep(200);
                    index++;

                }
                catch (Exception e)
                {
                    sb.Append("FAIL: EMAIL: " + login.EmailField.Text + " PASSWORD: " + login.PasswordField.Password + "\n");
                    sb.Append(e);
                    fails++;
                }
            }
            MessageBox.Show("Fuzz testing complete. Check log file.");
            sb.Append("NUMBER OF FAILURES: " + fails + "\n");
            WriteLog(sb.ToString(), "fuzzTest.txt");
        }

        public void TestRegisterForm(Register reg, int amountToRun, int type)
        {


            StringBuilder sb = new StringBuilder();
            Random r;
            int index = 0;
            int fails = 0;

            while (index <= amountToRun)
            {
                try
                {
                    r = new Random(Guid.NewGuid().GetHashCode());
                    reg.FirstNameBox.Text = GetRandomString(r.Next(1000));
                    reg.LastNameBox.Text = GetRandomString(r.Next(1000));
                    reg.AddressBox.Text = GetRandomString(r.Next(1000));
                    reg.CityBox.Text = GetRandomString(r.Next(1000));
                    reg.StateBox.Text = GetRandomString(r.Next(1000));
                    reg.CountryBox.Text = GetRandomString(r.Next(1000));
                    reg.PostalCodeBox.Text = GetRandomString(r.Next(1000));

                    reg.EmailBox.Text = GetRandomString(r.Next(1000));
                    reg.PasswordBox.Password = GetRandomString(r.Next(1000));

                    reg.RegisterButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    sb.Append(RegisterToString(reg, true));
                    Thread.Sleep(200);
                    index++;
                }
                catch (Exception e)
                {
                    sb.Append(RegisterToString(reg, true));
                    sb.Append("EXCEPTION: " + e);
                    fails++;
                }
            }
            MessageBox.Show("Fuzz testing complete. Check log file.");
            sb.Append("NUMBER OF FAILURES: " + fails + "\n");
            WriteLog(sb.ToString(), "fuzzTestRegister.txt");
        }

        private string RegisterToString(Register reg, bool success)
        {
            var sb = new StringBuilder();

            sb.Append(success ? "************** SUCCESS **************" : "************** FAIL **************");
            sb.Append(" \n FIRST: "+ reg.FirstNameBox.Text + "\n");
            sb.Append("LAST: " + reg.LastNameBox.Text + "\n");
            sb.Append("ADDRESS: " + reg.AddressBox.Text + "\n");
            sb.Append("CITY: " + reg.CityBox.Text + "\n");
            sb.Append("STATE: " + reg.StateBox.Text + "\n");
            sb.Append("COUNTRY: " + reg.CountryBox.Text + "\n");
            sb.Append("POSTAL: " + reg.PostalCodeBox.Text + "\n");
            sb.Append("EMAIL: " + reg.EmailBox.Text + "\n");
            sb.Append("PASS: " + reg.PasswordBox.Password + "\n");
            sb.Append("\n");

            return sb.ToString();
        }

        private string GetRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwzyz0123456789?><!@#$%^&*()_+-=~`';:,./\\[]{}";
            var random = new Random(Guid.NewGuid().GetHashCode());

            return new string(Enumerable.Repeat(chars, length)
       .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void WriteLog(string log, string location)
        {
            File.WriteAllText(location, log);
        }
    }
}
