
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using DocumentFormat.OpenXml.Spreadsheet;

using NUnit.Framework.Internal;
using NunitTutorial.BaseClass;
using NunitTutorial.Helper;
using NunitTutorial.PageObjects;

using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections;
using System.Data;
using System.Data.OleDb;


namespace NunitTutorial
{
    [TestFixture]
    public class Tests : BaseTest
    {

        string filename = "C:\\Users\\DELL\\source\\repos\\NunitTutorial\\NunitTutorial\\Asset\\Login.xlsx";
        ExtentReports extent = null;
        ExtentTest test = null;
        private HomePage homePage;
        private static readonly Lazy<ExtentReports> _lazy = new Lazy<ExtentReports>(() => new ExtentReports());
        public static ExtentReports Instance { get { return _lazy.Value; } }

        public Tests() 
        {
        }

        [OneTimeSetUp]

        public void ExtentStart()
        {
            extent = new ExtentReports();
            //var htmlReporter = new ExtentHtmlReporter(Utilities.ExtentReportFilePath());
            var logDirectoryPath = Path.Combine(Utilities.ExtentReportFilePath(), "Logs", DateTime.Today.Year.ToString(), DateTime.Today.Month.ToString(), DateTime.Today.Day.ToString());

            var logFilePath = Path.Combine(logDirectoryPath, DateTime.Now.ToString("yyyyMMddHHmmss") + ". html");
            var htmlReporter = new ExtentHtmlReporter(logFilePath);

            //var extentReportConfigPath = Path.Combine(Utilities.ExtentReportFilePath(), "extent-config.xml");
            //htmlReporter.LoadConfig(extentReportConfigPath);

            Instance.AttachReporter(htmlReporter);
            Instance.AddSystemInfo("Operting system", "Windows 10");
            Instance.AddSystemInfo("Browser", "Chrome");
            //@"C:\Users\DELL\source\repos\NunitTutorial\NunitTutorial\ExtentReports\NunitTutorial.html");
            //extent.AttachReporter(htmlReporter);

        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }

        [Test, Category("UnitTest")]
        
        public void Login()
        {
            DateTime time = DateTime.Now;
            string fileName = "Login_Screenshot" + time.ToString("h_mm_ss") + ".png";
            try
            {
                test = extent.CreateTest("Login").Info("Test Started");
                test.Log(Status.Info, "Chrome Started");
                Utilities.NavigateToBaseUrl(driver, "https://nightly-www.savvasrealizedev.com/community");
                test.Log(Status.Info, "URL lanuched");
                var loginPage = new Loginpage(driver);
                test.Log(Status.Info, "Email and Password Entered");
                homePage = loginPage.LoginToApplication("Sheet1");
                test.Log(Status.Info, "Verifying if user is able to login");
                test.Log(Status.Pass, "Successfully Entered Email and Passord");
                

                //string actualURL = homePage.getCurrentURL();
                //string expectedURL = "https://nightly-www.savvasrealizedev.com/dashboard/viewer";
                //Assert.AreEqual(expectedURL, actualURL);
                //test.Log(Status.Pass,"Login is Sucess");

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "UnSuccessfully Entered Email and Passord");
                test.Fail("Test failed", captureScreenShot(driver, fileName));
            }

           
           // Assert.Fail("Entered Email and Password UnSuccessfully");       
                      
        }           
            
    }
}