using NunitTutorial.Action;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using SeleniumExtras.PageObjects;
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
        bool flag;
        int timeOut;
        string text = "Tuition";
        string actualURL,actualURL1;
        int count = 0;
        string expectedURL = "https://mysavvastraining.com/",expectedURL1 = "https://support.savvas.com/support/s/contactsupport", expectedURL2 = "https://mysavvastraining.com/chat/index";
        string ParentURL = "https://nightly-www.savvasrealizedev.com/dashboard/viewer";
        public HomePage()
        { }
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.TagName, Using = "shell-cel-navbar")]
        [FindsBy(How = How.CssSelector, Using = "shell-cel-floating-modal[class='floatingModal hydrated']")]
        public IWebElement ShellcellNavbar { get; set; }
        public IWebElement shellcelfloatingmodal {get; set;}


        public bool ValidateHelpIcon()
        {
            flag = false;
           var ShadowDom1 = ShellcellNavbar.GetShadowRoot();
           var helpbutton = ShadowDom1.FindElement(By.CssSelector("div.right-container > div:nth-child(3) > div > shell-cel-icon-button"));
            string colour = helpbutton.GetCssValue("style");

            String parentWindowHandle = driver.CurrentWindowHandle;
            string[] ExpectedURL = new string[] { "https://mysavvastraining.com/", "https://support.savvas.com/support/s/contactsupport", "https://mysavvastraining.com/chat/index" };
            try
            {
                 if (helpbutton != null)
                 {
                    if (helpbutton.Displayed && helpbutton.Enabled)
                     {
                         CommonAction.ExplicitWait(driver, helpbutton, timeOut);
                         
                         CommonAction.MouseOver(driver, helpbutton);
                         helpbutton.Click();
                        var input = ShadowDom1.FindElement(By.CssSelector("[data-field-placeholder='Search Help']")).GetShadowRoot().FindElement(By.CssSelector("input#cel-sf-0[placeholder='Search Help']"));
                        var Search= ShadowDom1.FindElement(By.CssSelector("[data-field-placeholder='Search Help']")).GetShadowRoot().FindElement(By.CssSelector("shell-cel-icon-button[data-name='search']"));
                        
                       
                        if (input.Displayed && input.Enabled && Search.Enabled && Search.Displayed)
                          {

                              CommonAction.MouseOver(driver, Search);
                            
                              CommonAction.ExplicitWait(driver, Search, timeOut);
                              Search.Click();
                              CommonAction.ExplicitWait(driver, input, timeOut);
                              input.Click();
                              CommonAction.type(input, text);
                              input.Submit();
                              var closebtn = driver.FindElement(By.CssSelector("shell-cel-floating-modal[class='floatingModal hydrated']"));
                              var CloseButton = closebtn.GetShadowRoot().FindElement(By.CssSelector("shell-cel-icon-button[data-name='close']"));
                              CloseButton.Click();

                         /*   helpbutton.Click();
                            var DropDownValue1 = ShadowDom1.FindElement(By.CssSelector("div.right-container > div:nth-child(3) > div > div > ul > li:nth-child(1) > a"));
                            DropDownValue1.Click();

                            for (int i = 0; i < 3; i++)
                            {
                                try
                                {
                                    driver.Navigate().Refresh();
                                    CloseButton.Click();
                                }
                                catch (StaleElementReferenceException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            Thread.Sleep(20000);*/

                            helpbutton.Click();
                            var DropDownValue2 = ShadowDom1.FindElement(By.CssSelector("div.right-container > div:nth-child(3) > div > div > ul > li:nth-child(2) > a"));
                            DropDownValue2.Click();

                            List<string> lstWindow = driver.WindowHandles.ToList();

                            foreach (var handle in lstWindow)
                            {

                                driver.SwitchTo().Window(handle);
                                actualURL = driver.Url;
                                Console.WriteLine(actualURL);                              
                            }
                            Assert.AreEqual(expectedURL, actualURL);

                            driver.SwitchTo().Window(parentWindowHandle);
                           
                            helpbutton.Click();
                            var DropDownValue3 = ShadowDom1.FindElement(By.CssSelector("div.right-container > div:nth-child(3) > div > div > ul > li:nth-child(3) > a"));
                            DropDownValue3.Click();

                          List<string> lstWindow1 = driver.WindowHandles.ToList();

                            foreach (var handle in lstWindow1)
                            {

                                driver.SwitchTo().Window(handle);
                                actualURL = driver.Url;

                            }
                                                        
                            Assert.AreEqual(expectedURL1, actualURL);
                            driver.SwitchTo().Window(parentWindowHandle);

                            helpbutton.Click();
                            var DropDownValue4 = ShadowDom1.FindElement(By.CssSelector("div.right-container > div:nth-child(3) > div > div > ul > li:nth-child(4) > a"));
                            DropDownValue4.Click();
                            driver.SwitchTo().NewWindow(WindowType.Window);
                            driver.Navigate().GoToUrl("https://mysavvastraining.com/chat/index");
                            actualURL = CommonAction.getURL(driver);
                            /* List<string> lstWindow2 = driver.WindowHandles.ToList();

                             foreach (var handle in lstWindow2)
                             {

                                 driver.SwitchTo().NewWindow(WindowType.Window);   //.Window(handle);
                                 actualURL = CommonAction.getURL(driver);

                             }*/

                            Assert.AreEqual(expectedURL2, actualURL);
                            driver.SwitchTo().Window(parentWindowHandle);

                           
                            // CommonAction.ImplicitWait(driver, timeOut);
                            //Thread.Sleep(20000);
                           



                        }

                    }

                         flag=true;
                 }

                 return flag;
             }

             catch(Exception e)
             {
                 throw;
             }
          

        }
        public string getCurrentURL(IWebDriver driver)
        {
            
            string homePageURL = CommonAction.getURL(driver);
            CommonAction.ImplicitWait(driver, timeOut);
            return homePageURL;
        }
    }
}
