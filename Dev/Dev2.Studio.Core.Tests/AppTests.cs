﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dev2.Core.Tests
{
    [TestClass]
    public class AppTests
    {
        [TestMethod]
        public void AppConstructor_With_AppAlreadyRunning_Expected_OneAppInProcesses()
        {
            //string processPath = Path.GetDirectoryName(new Uri(System.Reflection.Assembly.GetExecutingAssembly().Location).LocalPath) + "\\Dev2.Studio.exe";

            //ProcessStartInfo startInfo = new ProcessStartInfo(processPath);
            //startInfo.WorkingDirectory = Path.GetDirectoryName(processPath);
            //startInfo.WindowStyle = ProcessWindowStyle.Normal;

            //Process process1 = Process.Start(startInfo);
            //Process.Start(startInfo);
            //Process[] processes = Process.GetProcessesByName(process1.ProcessName);

            //int actual = processes.Length;
            //int expected = 1;

            ////foreach (Process process in processes)
            ////{
            ////    process.Kill();
            ////}

            Assert.Inconclusive("Ashley please move to integration test project.");
            //Assert.AreEqual(expected, actual);
        }
    }
}
