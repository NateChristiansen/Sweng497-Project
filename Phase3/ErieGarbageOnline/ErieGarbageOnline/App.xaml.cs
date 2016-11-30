using System;
using System.IO;
using System.Reflection;
using System.Windows;
using ErieGarbageOnline.Controllers;

namespace ErieGarbageOnline
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ShutdownMode = ShutdownMode.OnLastWindowClose;
            new LoginController();
        }
    }
}
