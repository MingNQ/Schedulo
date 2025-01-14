using Schedulo.Common;
using Schedulo.Models;
using Schedulo.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Schedulo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Mutex mutex;
        private const int SW_RESTORE = 9;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var app = Assembly.GetExecutingAssembly().GetName().Name;
            mutex = new Mutex(false, app);
            
            if (mutex.WaitOne(TimeSpan.Zero) == false)
            {
                this.ActivatePrevProcess();
                Environment.Exit(0);
            }

            MainWindow mainWindow = new MainWindow();
            WindowManger windowManger = new WindowManger();
            windowManger.Window = mainWindow;

            mainWindow.Show();

            LoginView loginView = new LoginView();
            windowManger.ShowDialog(loginView);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            mutex.ReleaseMutex();
            mutex = null;
            base.OnExit(e);
        }

        /// <summary>
        /// Activate Previous Process
        /// </summary>
        private void ActivatePrevProcess()
        {
            // Find Process
            Process currentProcess = Process.GetCurrentProcess();
            var appName = currentProcess.ProcessName;
            Process[] processes = Process.GetProcessesByName(appName);

            // Activate Previous Process If Exist
            foreach (var process in processes)
            {
                if (process.Id != currentProcess.Id)
                {
                    IntPtr handle = process.MainWindowHandle;
                    if (handle != IntPtr.Zero)
                    {
                        NativeMethod.ShowWindowAsync(handle, SW_RESTORE);
                        NativeMethod.SetForegroundWindow(handle);
                    }
                    break;
                }
            }
        }
    }
}
