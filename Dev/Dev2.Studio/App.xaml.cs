﻿using Dev2.Data;
using Dev2.Diagnostics;
using Dev2.Studio.Core.AppResources.Browsers;
using Dev2.Studio.Factory;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Dev2.Studio
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private static Mutex _processGuard;
        public App()
        {
            //CheckForDuplicateProcess();//Bug 8403
            bool createdNew;
            Mutex localprocessGuard = new Mutex(true, "Dev2.Studio", out createdNew);
            if (createdNew)
            {
                _processGuard = localprocessGuard;
            }
            else
            {
                Environment.Exit(Environment.ExitCode);
            }
            InitializeComponent();
        }

#if DEBUG
        public static bool IsAutomationMode
        {
            get
            {
                return true;
            }
        }
#else

        public static bool IsAutomationMode
        {
            get
            {
                return false;
            }
        }
#endif


        protected override void OnStartup(StartupEventArgs e)
        {
            Browser.Startup();

            new Bootstrapper().Start();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            DebugDispatcher.Instance.Shutdown();
           // BackgroundDispatcher.Instance.Shutdown();
            Browser.Shutdown();
            base.OnExit(e);
        }

        private void OnApplicationDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                ExceptionFactory.CreateViewModel(e.Exception).Show();
                e.Handled = true;
                //TODO Log
            }
            catch (Exception)
            {
                if (Current == null || Dispatcher.CurrentDispatcher.HasShutdownStarted || Dispatcher.CurrentDispatcher.HasShutdownFinished)
                {
                    // Do nothing if shutdown is in progress
                    return;
                }

                MessageBox.Show(
                    "An unexpected unrecoverable exception has been encountered. The application will now shut down;");
                Current.Shutdown();
            }
        }
        private void CheckForDuplicateProcess()
        {
            //Bug 8403
            var studioProcesses = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            if (studioProcesses.Length > 1)
            {
                SetForegroundWindow(studioProcesses[0].MainWindowHandle);
                SetForegroundWindow(studioProcesses[1].MainWindowHandle);
                Current.Shutdown();
            }
        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
