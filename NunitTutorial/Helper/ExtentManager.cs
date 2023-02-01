using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitTutorial.Helper
{
   public class ExtentManager
    {
        public static ExtentReports extent;
        public static ExtentTest test;
        public static ExtentHtmlReporter htmlReporter;
        private static readonly Lazy<ExtentReports> _lazy = new Lazy<ExtentReports>(() => new ExtentReports());
        public static ExtentReports Instance { get { return _lazy.Value; } }
     

        public static void ExtentStart()
        {
            extent = new ExtentReports();
            htmlReporter = new ExtentHtmlReporter(Utilities.ExtentReportFilePath());
            var logDirectoryPath = Path.Combine(Utilities.ExtentReportFilePath(), "Logs", DateTime.Today.Year.ToString(), DateTime.Today.Month.ToString(), DateTime.Today.Day.ToString());

            var logFilePath = Path.Combine(logDirectoryPath, DateTime.Now.ToString("yyyyMMddHHmmss") + "MyReport. html");
             htmlReporter = new ExtentHtmlReporter(logFilePath);

            var extentReportConfigPath = Path.Combine(Utilities.ExtentReportFilePath(), "extent-config.xml");
            htmlReporter.LoadConfig(extentReportConfigPath);

            Instance.AttachReporter(htmlReporter);
            Instance.AddSystemInfo("Operting system", "Windows 10");
            Instance.AddSystemInfo("Browser", "Chrome");
            //@"C:\Users\DELL\source\repos\NunitTutorial\NunitTutorial\ExtentReports\NunitTutorial.html");
            //extent.AttachReporter(htmlReporter);

        }

        
        public static void ExtentClose()
        {
            extent.Flush();
        }

    }
}
