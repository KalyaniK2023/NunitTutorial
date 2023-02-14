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
        int timeout,i;
           
        List<Login> loginlist = new List<Login>();
       Login login=new Login("","");
    
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

        public HomePage Login_tc120RLZ32851(string testName,int row)
        {
            try
            {
                var readData = new ReadDataExcel("NunitTutorial", "Login");
                List<Login> loginlist = readData.GetTestData(testName);
                i = row;
                for (int j = i; j <= i; j++)
                {
                    string text = loginlist[j].UserName;
                    CommonAction.type(UserName, text);
                    string text1 = loginlist[j].Password;
                    CommonAction.type(Password, text1);
                }
                CommonAction.JSClick(driver, SignInBtn);
                Thread.Sleep(20000);
                //CommonAction.ImplicitWait(driver, timeout);

                HomePage homePage = new HomePage(driver);
                return homePage;
            }
            catch(Exception e)
            {
                throw;
            }
           


        }
        public static string GetProfileName(string testName, int row)
        {
            string text = null;
            int i;
            try
            {
                var readData = new ReadDataExcel("NunitTutorial", "Login");
                List<Login> loginlist = readData.GetTestData(testName);
                i = row;
                for (int j = i; j <= i; j++)
                {
                     text = loginlist[j].UserName;
                }
                string[] FirstName = text.Split("_");
                text= FirstName[1];

               return text;
            }
            catch(Exception ex)
            {
                return text;
            }
        }

    }
}
