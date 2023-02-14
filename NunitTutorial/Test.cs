
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using DocumentFormat.OpenXml.Spreadsheet;

using NUnit.Framework.Internal;
using NunitTutorial.BaseClass;
using NunitTutorial.Helper;
using NunitTutorial.Model;
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
        //ExtentReports extent ;
       // ExtentTest test ;
        private HomePage homePage;
        private ClassesPage classesPage;
        bool flag;



        public Tests() 
        {
        }

        public static String getFileName()
        {
            DateTime time = DateTime.Now;
            String fileName = "Login_Screenshot" + time.ToString("h_mm_ss") + ".png";
            return fileName;
        }


        [Test, Category("UnitTest")]
        
        public void tc120RLZ32851()
        {
          

            try
            {

                test.Log(Status.Info, "Chrome Started");
                test.Log(Status.Info, "URL lanuched");
                var loginPage = new Loginpage(driver);
                test.Log(Status.Info, "Email and Password Entered");
                test.Log(Status.Info, "Email and Password Entered");
                homePage = loginPage.Login_tc120RLZ32851("Sheet1", 0);
                test.Log(Status.Info, "Verifying if user is able to login");
                string actualURL = homePage.getCurrentURL(driver);
                string expectedURL = "https://nightly-www.savvasrealizedev.com/dashboard/viewer";
                Assert.AreEqual(expectedURL, actualURL);
                test.Pass("Test Passed", captureScreenShot(driver, Tests.getFileName()));
                flag = homePage.Validate_tc120RLZ32851();
                Assert.That(flag, Is.EqualTo(true));
                test.Pass("Test Passed", captureScreenShot(driver, Tests.getFileName()));

            }
            catch (Exception e)
            {
                test.Fail("Test failed", captureScreenShot(driver, Tests.getFileName()));
            }                                          
        }

        [Test, Category("UnitTest")]

        public void tc020RLZ33166()
        {
            try
            {



                test.Log(Status.Info, "Chrome Started");

                test.Log(Status.Info, "URL lanuched");
                var loginPage = new Loginpage(driver);
                test.Log(Status.Info, "Email and Password Entered");
                homePage = loginPage.Login_tc120RLZ32851("Sheet1",1);
                test.Log(Status.Info, "Verifying if user is able to login");
                string actualURL = homePage.getCurrentURL(driver);
                string expectedURL = "https://nightly-www.savvasrealizedev.com/dashboard/viewer";
                Assert.AreEqual(expectedURL, actualURL);
                test.Pass("Test Passed", captureScreenShot(driver, Tests.getFileName()));
                flag = homePage.Validate_Teacher_tc020RLZ33166();
                Assert.That(flag, Is.EqualTo(true));
                 test.Pass("Test Passed", captureScreenShot(driver, Tests.getFileName()));
                Utilities.NavigateToBaseUrl(driver, "https://nightly-www.savvasrealizedev.com/community");
                test.Log(Status.Info, "Email and Password Entered");
                homePage = loginPage.Login_tc120RLZ32851("Sheet1", 2);
                flag =homePage.Validate_Student_tc020RLZ33166();
                Assert.That(flag, Is.EqualTo(true));
                test.Pass("Test Passed", captureScreenShot(driver, Tests.getFileName()));
            }
            catch (Exception e)
            {
                test.Fail("Test failed", captureScreenShot(driver, Tests.getFileName()));
            }
        }

        [Test, Category("UnitTest")]

        public void tc110RLZ34301()
        {
            try
            {
                test.Log(Status.Info, "Chrome Started");

                test.Log(Status.Info, "URL lanuched");
                var loginPage = new Loginpage(driver);
                test.Log(Status.Info, "Email and Password Entered");
                homePage = loginPage.Login_tc120RLZ32851("Sheet1", 2);
                test.Log(Status.Info, "Verifying if user is able to login");
                string actualURL = homePage.getCurrentURL(driver);
                string expectedURL = "https://nightly-www.savvasrealizedev.com/dashboard/viewer";
                Assert.AreEqual(expectedURL, actualURL);
                test.Pass("Test Passed", captureScreenShot(driver, Tests.getFileName()));
                bool flag = homePage.Validate_tc110RLZ34301();
                Assert.That(flag, Is.EqualTo(true));
                test.Pass("Test Passed", captureScreenShot(driver, Tests.getFileName()));
            }
            catch (Exception e)
            {
                test.Fail("Test failed", captureScreenShot(driver, Tests.getFileName()));
            }
        }

        [Test, Category("UnitTest")]

        public void tc010RLZ36955()
        {
            try
            {



                test.Log(Status.Info, "Chrome Started");

                test.Log(Status.Info, "URL lanuched");
                var loginPage = new Loginpage(driver);
                test.Log(Status.Info, "Email and Password Entered");
                homePage = loginPage.Login_tc120RLZ32851("Sheet1", 0);
                test.Log(Status.Info, "Verifying if user is able to login");
                string actualURL = homePage.getCurrentURL(driver);
                string expectedURL = "https://nightly-www.savvasrealizedev.com/dashboard/viewer";
                Assert.AreEqual(expectedURL, actualURL);
                test.Pass("Test Passed", captureScreenShot(driver, Tests.getFileName()));                
                 string Class_Title = homePage.Validate_tc010RLZ36955();
                var classesPage = new ClassesPage(driver);
                string Class_Assignment_Title=classesPage.Validate_tc010RLZ36955();
                Assert.AreEqual(Class_Title, Class_Assignment_Title);
                test.Pass("Test Passed", captureScreenShot(driver, Tests.getFileName()));

            }
            catch(Exception ex)
            {
                test.Fail("Test failed", captureScreenShot(driver, Tests.getFileName()));
            }
        }


    }
}