using NunitTutorial.Action;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitTutorial.PageObjects
{
    public class HomePage
    {
        IWebDriver driver;
        public string getCurrentURL()
        {
            driver= new ChromeDriver();
            string homePageURL = CommonAction.getURL(driver);
            return homePageURL;
        }
    }
}
