using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitTutorial.Helper
{
   public class ExplicitWaitHelper
    {
        private IWebDriver driver;

        public ExplicitWaitHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitForUntilElementFind(IWebDriver driver, By element)
        {
            try
            {
                Thread.Sleep(2000);
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
                fluentWait.Timeout = TimeSpan.FromMinutes(3);
                fluentWait.PollingInterval = TimeSpan.FromMinutes(3);
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                fluentWait.Until(ExpectedConditions.ElementIsVisible(element));
            }
            catch (Exception e)
            {
                Debug.WriteLine("some error:" + e.Message);
            }

        }

        public static void WaitUntilButtonToBeClickBle(IWebDriver driver, IWebElement element)
        {
            try
            {
                Thread.Sleep(2000);
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
                fluentWait.Timeout = TimeSpan.FromMinutes(3);
                fluentWait.PollingInterval = TimeSpan.FromMinutes(3);
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                fluentWait.Message = "Element to be searched not found";
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception e)
            {
                Debug.WriteLine("some error:" + e.Message);
            }

        }

        public static void WaitForElementIsVisible(IWebDriver driver, By element)
        {
            try
            {
                Thread.Sleep(2000);
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
                fluentWait.Timeout = TimeSpan.FromMinutes(3);
                fluentWait.PollingInterval = TimeSpan.FromMinutes(3);
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                fluentWait.Message = "Element to be searched not found";
                fluentWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
            }
            catch (Exception e)
            {
                Debug.WriteLine("some error:" + e.Message);
            }
        }
    }
}

