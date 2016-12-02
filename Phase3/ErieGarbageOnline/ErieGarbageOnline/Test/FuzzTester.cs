using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using ErieGarbageOnline.Views;

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
                    r = new Random();
                    login.EmailField.Text = GetRandomString(r.Next(100));
                    login.PasswordField.Password = GetRandomString(r.Next(100));

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
            WriteLog(sb.ToString());
        }

        private string GetRandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwzyz0123456789?><!@#$%^&*()_+-=~`';:,./\\[]{}";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray()); 
        }

        private void WriteLog(string log)
        {
            File.WriteAllText("fuzzTest.txt", log);
        }
    }
}
