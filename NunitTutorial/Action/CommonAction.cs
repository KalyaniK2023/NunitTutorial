using NunitTutorial.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NunitTutorial.Action
{
    public class CommonAction
    {
        // IWebDriver driver;
        public static int timeOut = 20;
        public IWebElement element;
        public static bool type(IWebElement ele, String text)
        {
            bool flag = false;
            try
            {
                flag = ele.Displayed;
                ele.Clear();
                ele.SendKeys(text);
                // logger.info("Entered text :"+text);
                flag = true;
            }
            catch (Exception e)
            {

                Console.WriteLine("Location Not found");
                flag = false;
            }
            finally
            {
                if (flag)
                {

                    Console.WriteLine("Successfully entered value");
                }
                else
                {

                    Console.WriteLine("Unable to enter value");
                }

            }
            return flag;
        }
        public static bool type(IWebElement ele, IWebElement ele1, List<Login> loginlist)
        {
            bool flag = false;
            try
            {
                if (ele.Displayed && ele1.Displayed)
                {
                    ele.Clear();
                    ele.SendKeys(loginlist[0].UserName);
                    Thread.Sleep(1000);
                    ele1.Clear();
                    ele1.SendKeys(loginlist[0].Password);
                    flag = true;
                }
                else
                    flag = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Location Not found");
                flag = false;
            }
            finally
            {
                if (flag)
                {
                    Console.WriteLine("Successfully entered value");
                }
                else
                {
                    Console.WriteLine("Unable to enter value");
                }

            }
            return flag;
        }

        public static bool JSClick(IWebDriver driver, IWebElement signInBtn)
        {

            bool flag = false;
            try
            {



                if (signInBtn.Enabled)
                {
                    
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                    executor.ExecuteScript("arguments[0].click();", signInBtn);
                    

                }
                flag = true;

            }

            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                if (flag)
                {
                    Console.WriteLine("Click Action is performed");
                }
                else if (!flag)
                {
                    Console.WriteLine("Click Action is not performed");
                }
            }
            return flag;
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
                element.Click();
            }
            catch (Exception e)
            {
                Debug.WriteLine("some error:" + e.Message);
            }

        }


        /* public static void ExplicitWait(IWebDriver driver, IWebElement element,int timeout)
         {

             try
             {
                 if (element.Enabled)
                 {

                     WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                     wait.Until(ExpectedConditions.ElementToBeClickable(element));

                     IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                     executor.ExecuteScript("arguments[0].click();", element);
                 }
             }
             catch (Exception e)
             {
                 Debug.WriteLine("some error:" + e.Message);
             }

         }*/
        public static string getURL(IWebDriver driver)
        {
            bool flag = false;


            string text = driver.Url;

            if (flag)
            {
                Console.WriteLine("Current URL is: \"" + text + "\"");
            }

            return text;
        }
        public static void ImplicitWait(IWebDriver driver, int timeOut)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public static void ExplicitWait(IWebDriver driver, IWebElement element, int timeOut)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));

        }
        public static bool ElementClickable(IWebDriver driver, IWebElement element, int timeOut)
        {
            bool flag = false;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            if (wait.Until(ExpectedConditions.ElementToBeClickable(element)) == null)
            {
                flag = true;
            }
            return flag;

        }
        public static void ElementVisible(IWebDriver driver, IWebElement element, int timeOut)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible((By)element));

        }
        //public static void Elementexist(IWebDriver driver, IWebElement element, int timeOut)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //    wait.Until(element.Displayed);

        //}
        
        public static void ElementSelected(IWebDriver driver, IWebElement element, int timeOut)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeSelected(element));

        }
        public static void ElementStaleness(IWebDriver driver, IWebElement element, int timeOut)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.StalenessOf(element));

        }

        public static void pageLoadTimeOut(IWebDriver driver, int timeOut)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        public static ISearchContext GetShadowDom(IWebElement element, IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            ISearchContext ele = (ISearchContext)js.ExecuteScript("return arguments[0].shadowRoot", element);
            return ele;



        }

        public static bool MouseOver(IWebDriver driver, IWebElement ele)
        {
            bool flag = false;
            try
            {
                new Actions(driver).MoveToElement(ele).Build().Perform();
                flag = true;
                return flag;
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }

}



