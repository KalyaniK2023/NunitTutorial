using AventStack.ExtentReports;
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
            //this.driver = driver;
        }
        public BaseTest()
        { }

        [SetUp]
        public void Open()
        {
            var driver = GetDriver("chrome");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            //var URL= ReadDataExcel.GetUrl();
           
           // driver.Navigate().GoToUrl("https://nightly-www.savvasrealizedev.com/community");

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
                    driver = new ChromeDriver();
                    break;

            }

           
            return driver;
        }
        [TearDown]
        public void AfterTest()

        {
           /* var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;



            DateTime time = DateTime.Now;
            string fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if (status == TestStatus.Failed)
            {

                test.Fail("Test failed", captureScreenShot(driver, fileName));
                test.Log(Status.Fail, "test failed with logtrace" + stackTrace);

            }
            else if (status == TestStatus.Passed)
            {

            }*/

           
            driver.Quit();
        }

        public MediaEntityModelProvider captureScreenShot(IWebDriver driver, string? screenShotName)

        {
            //var directoryPath = Path.Combine(extentreportPath, "Screenshots", DateTime.Today.Year.ToString(), DateTime.Today.Month.ToString(), DateTime.Today.Day.ToString());
            //var filePath = Path.Combine(directoryPath, $"Screenshot_{DateTime.Now.ToString("yyyyMMddHHmmss")}.jpg");

            //Take screenshot
           // Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            //screenShot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();




        }

       
    }
}
