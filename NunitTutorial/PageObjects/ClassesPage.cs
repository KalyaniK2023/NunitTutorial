using NunitTutorial.Action;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitTutorial.PageObjects
{
    public class ClassesPage
    {
        IWebDriver driver;
        int timeOut;
        public ClassesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string Validate_tc010RLZ36955()
        {
            CommonAction.pageLoadTimeOut(driver,timeOut);
            var Class_Assignment_Title = driver.FindElement(By.CssSelector("app-class-header > div > div > div.class-name > h1"));

            return Class_Assignment_Title.Text.ToString();      
        }
    }
}
