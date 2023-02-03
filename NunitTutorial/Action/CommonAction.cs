using NunitTutorial.Model;
using OpenQA.Selenium;
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
                    //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                    // wait.Until(IWebDriver-> (IJavaScriptExecutor).executeScript("return document.readyState").equals("complete"));
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                    executor.ExecuteScript("arguments[0].click();", signInBtn);
                    // driver.executeAsyncScript("arguments[0].click();", element);

                }
               ;
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
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                
                
                                element.Click();
            }
            catch (Exception e)
            {
                Debug.WriteLine("some error:" + e.Message);
            }

        }

        
        public static void ExplicitWait(IWebDriver driver, IWebElement element,int timeout)
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

        }
        public static string getURL(IWebDriver driver)
        {
            bool flag = false;
            

            string text =  driver.Url;
                
            if (flag)
            {
                Console.WriteLine("Current URL is: \"" + text + "\"");
            }
            return text;
        }
    }

}
