using NunitTutorial.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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

                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].click();", signInBtn);
                // driver.executeAsyncScript("arguments[0].click();", element);

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
