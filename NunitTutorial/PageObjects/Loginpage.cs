using NunitTutorial.Model;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using NunitTutorial.Helper;
using NunitTutorial.Model;
using OpenQA.Selenium.Interactions;
using NunitTutorial.Action;

namespace NunitTutorial.PageObjects
{
    
    public class Loginpage
    {
        IWebDriver driver;
        int timeout;
           
        List<Login> loginlist = new List<Login>();
       Login login=new Login();
    
        public Loginpage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//input[@id='username']")]
        public IWebElement UserName { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@id='password']")]
        public IWebElement Password { get; set; }  //button[@id='signInBtn']
       
        [FindsBy(How = How.XPath, Using = "//button[@id='signInBtn']")]
        public IWebElement SignInBtn { get; set; }

        public HomePage LoginToApplication(string testName)
        {
            try
            {
                var readData = new ReadDataExcel("NunitTutorial", "Login");
                //var dt = readData.GetTestData(testName);
                List<Login> loginlist = readData.GetTestData(testName);
                string text = loginlist[0].UserName;
                CommonAction.type(UserName, text);
                string text1 = loginlist[0].Password;
                CommonAction.type(Password, text1);
                //  CommonAction.ExplicitWait(driver,SignInBtn,10);

                //SignInBtn.Click();
              CommonAction.JSClick(driver, SignInBtn);
                Thread.Sleep(20000);
                //CommonAction.ImplicitWait(driver, timeout);

                HomePage homePage = new HomePage(driver);
              // CommonAction.ImplicitWait(driver,timeout);
               // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                return homePage;
            }
            catch(Exception e)
            {
                throw;
            }
           


        }

    }
}
