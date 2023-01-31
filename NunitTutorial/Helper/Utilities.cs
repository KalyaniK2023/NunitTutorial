using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NunitTutorial.Helper
{
    public class Utilities
    {
        IWebDriver driver;
         

        public static string ExtentReportFilePath()
        {
            var dirPath = Assembly.GetExecutingAssembly().Location;
            int index = dirPath.IndexOf("NunitTutorial");
            string _filePath = dirPath.Remove(index) + "NunitTutorial\\ExtentReports";
            return _filePath;
        }
        
        public static void NavigateToBaseUrl(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

        }
    }
}
