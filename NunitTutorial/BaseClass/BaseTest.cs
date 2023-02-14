using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Core;
using NUnit.Framework.Interfaces;
using NunitTutorial.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace NunitTutorial.BaseClass
{

    public class BaseTest
    {

        protected string _browserName;
        public ExtentReports extent;
        public ExtentTest test;


        protected IWebDriver driver { get; set; }
        public BaseTest(string browser)
        {
            _browserName = browser.ToLower();
        }
        public BaseTest()
        { }
        [OneTimeSetUp]

        public void ExtentStart()
        {


            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "Kalyani");
        }
       
        [SetUp]
        public void Open()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            var driver = GetDriver("chrome");
            //Delete all the cookies
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            //PageLoad TimeOuts
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);            
        }
        private IWebDriver GetDriver(string browser)
        {
            _browserName = browser;

            switch (_browserName)
            {

                case "Firefox":

                    driver = new FirefoxDriver();
                    break;

                case "Edge":

                    driver = new EdgeDriver();
                    break;

                default:
                    //driver = new ChromeDriver();
                    ChromeOptions chromoeoptions = new ChromeOptions();
                    chromoeoptions.AddArgument("--ignore-ssl-errors=yes");
                    chromoeoptions.AddArgument("--ignore-certificate-errors");
                    driver = new ChromeDriver(chromoeoptions);
                    break;

            }
            //Launching the URL
            Utilities.NavigateToBaseUrl(driver, "https://nightly-www.savvasrealizedev.com/community");


            return driver;
        }


        [TearDown]
        public void AfterTest()

        {
            driver.Quit();
            
        }
        [OneTimeTearDown]
        public void ExtentClosed()
        {
            extent.Flush();
        }

        public MediaEntityModelProvider captureScreenShot(IWebDriver driver, String screenShotName)

            {
                
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                var screenshot = ts.GetScreenshot().AsBase64EncodedString;

                return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();

            }
       


        }
    }


