using NunitTutorial.Action;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
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
        int timeOut, count = 0;
        string text = "Tuition", actualURL, actualURL1;       
       
        string expectedURL = "https://mysavvastraining.com/", expectedURL1 = "https://support.savvas.com/support/s/contactsupport", expectedURL2 = "https://mysavvastraining.com/chat/index";

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
        [FindsBy(How =How.XPath, Using="//div//span[@data-e2e-id='Class RGHT-140750010922123713ylT']")]
        public IWebElement ShellcellNavbar { get; set; }
        public IWebElement shellcelfloatingmodal { get; set; }
        public IWebElement Class_Title { get; set; }


        public bool Validate_tc120RLZ32851()  //RegSuite1
        {
            flag = false;
           IWebElement helpbutton, CloseButton, closebtn;
            var ShadowDom1 = ShellcellNavbar.GetShadowRoot();
             helpbutton = ShadowDom1.FindElement(By.CssSelector("div.right-container > div:nth-child(3) > div > shell-cel-icon-button"));
            //string colour = helpbutton.GetCssValue("style");
            //string Expected_Color = "#213FA3";
            //Assert.AreEqual(Expected_Color, colour);

            String parentWindowHandle = driver.CurrentWindowHandle;
            try
            {
                if (helpbutton != null)
                {
                    if (helpbutton.Displayed && helpbutton.Enabled)
                    {
                       
                        CommonAction.MouseOver(driver, helpbutton);
                        //Assert.AreEqual("rgb(33, 80, 163)",helpbutton.GetCssValue("color"));
                        Console.WriteLine(helpbutton.GetCssValue("color"));
                        Console.WriteLine(helpbutton.GetAttribute("style"));
                        CommonAction.ExplicitWait(driver, helpbutton, timeOut);                        
                        helpbutton.Click();
                        var input = ShadowDom1.FindElement(By.CssSelector("[data-field-placeholder='Search Help']")).GetShadowRoot().FindElement(By.CssSelector("input#cel-sf-0[placeholder='Search Help']"));
                        var Search = ShadowDom1.FindElement(By.CssSelector("[data-field-placeholder='Search Help']")).GetShadowRoot().FindElement(By.CssSelector("shell-cel-icon-button[data-name='search']"));


                        if (input.Displayed && input.Enabled && Search.Enabled && Search.Displayed)
                        {

                            CommonAction.MouseOver(driver, Search);
                            //Assert.AreEqual("rgb(33, 80, 163)", Search.GetCssValue("color"));                         
                            Console.WriteLine(Search.GetCssValue("color"));
                            CommonAction.ExplicitWait(driver, Search, timeOut);
                            Search.Click();
                            CommonAction.ExplicitWait(driver, input, timeOut);
                            input.Click();
                            CommonAction.type(input, text);
                            input.Submit();
                            closebtn = driver.FindElement(By.CssSelector("shell-cel-floating-modal[class='floatingModal hydrated']"));
                            CloseButton = closebtn.GetShadowRoot().FindElement(By.CssSelector("shell-cel-icon-button[data-name='close']"));
                            CloseButton.Click();
                            helpbutton = ShadowDom1.FindElement(By.CssSelector("div.right-container > div:nth-child(3) > div > shell-cel-icon-button"));
                            helpbutton.Click();
                            var DropDownValue1 = ShadowDom1.FindElement(By.CssSelector("div.right-container > div:nth-child(3) > div > div > ul > li:nth-child(1) > a"));
                            DropDownValue1.Click();
                            closebtn = driver.FindElement(By.CssSelector("shell-cel-floating-modal[class='floatingModal hydrated']"));
                            CloseButton = closebtn.GetShadowRoot().FindElement(By.CssSelector("shell-cel-icon-button[data-name='close']"));
                            CloseButton.Click();
                           
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
                           

                            Assert.AreEqual(expectedURL2, actualURL);
                            driver.SwitchTo().Window(parentWindowHandle);
                        }

                    }

                    flag = true;
                }

                return flag;
            }

            catch (Exception e)
            {
                throw;
            }


        }

       
        public bool Validate_Teacher_tc020RLZ33166()
        {
            flag = false;
            IWebElement Logo_Img, SaveBtn, Assignments;
            Language_Change();
            var Spanish_Lang = driver.FindElement(By.CssSelector("div:nth-child(5) > ul > li > ul > li:nth-child(2) > a"));
            Spanish_Lang.Click();
            SaveBtn = driver.FindElement(By.XPath("//button[@data-e2e-id='save']"));
            //CommonAction.ExplicitWait(driver, SaveBtn, timeOut);
             SaveBtn.Click();
            Thread.Sleep(5000);
            CommonAction.pageLoadTimeOut(driver, timeOut);           
            Logo_Img = driver.FindElement(By.CssSelector("#globalNav > realize-main-nav > div > div > cel-platform-navbar")).GetShadowRoot().FindElement(By.CssSelector("#platformNavLogo > img"));
            Logo_Img.Click();
             Assignments = driver.FindElement(By.XPath("//span[@class='gridCard__text']"));
            Assert.AreEqual("Asignaciones", Assignments.Text.ToString());
            var Student_Groups = driver.FindElement(By.XPath("//app-links//ul//div[2]//span")).Text;
            Assert.AreEqual("Estudiantes y grupos", Student_Groups.ToString());
            var Data_Option = driver.FindElement(By.XPath("//app-links//ul//div[3]//span")).Text;
            Assert.AreEqual("Datos", Data_Option.ToString());
            var Program_Option = driver.FindElement(By.XPath("//programs-dropdown//span"));
            Assert.AreEqual("Programas", Program_Option.Text.ToString());
            Language_Change();
            var English_Lang = driver.FindElement(By.CssSelector("div:nth-child(5) > ul > li > ul > li:nth-child(1) > a"));
            English_Lang.Click();
            SaveBtn = driver.FindElement(By.XPath("//div[@class='button-bar bottom bottom-border']//button[@data-e2e-id='save']"));
            SaveBtn.Click();
            Thread.Sleep(5000);            
            Logo_Img = driver.FindElement(By.CssSelector("#globalNav > realize-main-nav > div > div > cel-platform-navbar")).GetShadowRoot().FindElement(By.CssSelector("#platformNavLogo > img"));
            Logo_Img.Click();
            Assignments = driver.FindElement(By.XPath("//span[@class='gridCard__text']"));
            Assert.AreEqual("Assignments", Assignments.Text.ToString());
            var UserProfileBtn = ShellcellNavbar.GetShadowRoot().FindElement(By.CssSelector("div.profile-container-wrapper > button"));
            UserProfileBtn.Click();
            var Signout = driver.FindElement(By.CssSelector("body > app-root > app-home > app-header > shell-cel-navbar")).GetShadowRoot().FindElement(By.CssSelector("div.right-container > div.profile-container-wrapper > shell-cel-menu")).GetShadowRoot().FindElement(By.CssSelector("ul > li:nth-child(3) > a"));
                //driver.FindElement(By.CssSelector("#globalNav > realize-main-nav > div > div > cel-platform-navbar")).GetShadowRoot().FindElement(By.CssSelector("header > div > cel-utility-nav-item.platform__navbar--profileUtility.hydrated")).GetShadowRoot().FindElement(By.CssSelector("#signOut"));
            Signout.Click();
            //driver.Navigate().Refresh();
            //CommonAction.pageLoadTimeOut(driver, timeOut);
            Thread.Sleep(10000);
            return true;
        }


        public bool Validate_Student_tc020RLZ33166() ///edit on 17fab
        {
            flag = false;
            IWebElement Logo_Img, SaveBtn, Assignments;
            Language_Change();
            var Spanish_Lang = driver.FindElement(By.CssSelector("#personalInfo > div.stepInner.clearfix > div:nth-child(3) > div > ul > li > ul > li:nth-child(2) > a"));
            Spanish_Lang.Click();
            SaveBtn = driver.FindElement(By.CssSelector("#personalInfo > div.button-bar.top > div > button"));
            //CommonAction.ExplicitWait(driver, SaveBtn, timeOut);
            SaveBtn.Click();
            Thread.Sleep(5000);
            CommonAction.pageLoadTimeOut(driver, timeOut);
            Logo_Img = driver.FindElement(By.CssSelector("#globalNav > realize-main-nav > div > div > cel-platform-navbar")).GetShadowRoot().FindElement(By.CssSelector("#platformNavLogo > img"));
            Logo_Img.Click();
            Assignments = driver.FindElement(By.XPath("//span[@class='gridCard__text']"));
            Assert.AreEqual("Asignaciones", Assignments.Text.ToString());
            var Student_Groups = driver.FindElement(By.XPath("//app-links//ul//div[2]//span")).Text;
            Assert.AreEqual("Comentar", Student_Groups.ToString());
            var Data_Option = driver.FindElement(By.XPath("//app-links//ul//div[3]//span")).Text;
            Assert.AreEqual("Datos", Data_Option.ToString());
            var Program_Option = driver.FindElement(By.XPath("//programs-dropdown//span"));
            Assert.AreEqual("Programas", Program_Option.Text.ToString());
            Language_Change();
            var English_Lang = driver.FindElement(By.CssSelector("div:nth-child(5) > ul > li > ul > li:nth-child(1) > a"));
            English_Lang.Click();
            SaveBtn = driver.FindElement(By.XPath("//div[@class='button-bar bottom bottom-border']//button[@data-e2e-id='save']"));
            SaveBtn.Click();
            Thread.Sleep(5000);
            Logo_Img = driver.FindElement(By.CssSelector("#globalNav > realize-main-nav > div > div > cel-platform-navbar")).GetShadowRoot().FindElement(By.CssSelector("#platformNavLogo > img"));
            Logo_Img.Click();
            Assignments = driver.FindElement(By.XPath("//span[@class='gridCard__text']"));
            Assert.AreEqual("Assignments", Assignments.Text.ToString());
            var UserProfileBtn = ShellcellNavbar.GetShadowRoot().FindElement(By.CssSelector("div.profile-container-wrapper > button"));
            UserProfileBtn.Click();
            var Signout = driver.FindElement(By.CssSelector("body > app-root > app-home > app-header > shell-cel-navbar")).GetShadowRoot().FindElement(By.CssSelector("div.right-container > div.profile-container-wrapper > shell-cel-menu")).GetShadowRoot().FindElement(By.CssSelector("ul > li:nth-child(3) > a"));
            //driver.FindElement(By.CssSelector("#globalNav > realize-main-nav > div > div > cel-platform-navbar")).GetShadowRoot().FindElement(By.CssSelector("header > div > cel-utility-nav-item.platform__navbar--profileUtility.hydrated")).GetShadowRoot().FindElement(By.CssSelector("#signOut"));
            Signout.Click();
            //driver.Navigate().Refresh();
            //CommonAction.pageLoadTimeOut(driver, timeOut);
            Thread.Sleep(10000);
            return true;
        }








        public void Language_Change()
        {

            var ShadowDom1 = ShellcellNavbar.GetShadowRoot();
            var UserProfileBtn = ShadowDom1.FindElement(By.CssSelector("div.profile-container-wrapper > button"));
            UserProfileBtn.Click();
            var Setting_List = ShadowDom1.FindElement(By.CssSelector("div.right-container > div.profile-container-wrapper > shell-cel-menu")).GetShadowRoot().FindElement(By.CssSelector("ul > li:nth-child(1) > a"));
            Setting_List.Click();
            actualURL = CommonAction.getURL(driver);
            string expectedURL = "https://nightly-www.savvasrealizedev.com/community/profile";
            Assert.AreEqual(expectedURL, actualURL);
            var Lang_Dropdown = driver.FindElement(By.CssSelector("#languageDropdown"));
            Lang_Dropdown.Click();
        }

        public bool Validate_tc110RLZ34301()
        {
            flag = false;
            IWebElement ProfileBtn;
            string firstName;            
            var ShadowDom1 = ShellcellNavbar.GetShadowRoot();
            ProfileBtn = ShadowDom1.FindElement(By.CssSelector("div.right-container > div.profile-container-wrapper > button[data-utility-id='profile']"));
            ProfileBtn.Click();
            var Setting_List = ShadowDom1.FindElement(By.CssSelector("div.right-container > div.profile-container-wrapper > shell-cel-menu")).GetShadowRoot().FindElement(By.CssSelector("ul > li:nth-child(1) > a")); 
            Setting_List.Click();
            string StudentName = driver.FindElement(By.CssSelector("#studentName")).Text.ToString();
            string[] FirstName = StudentName.Split(" ");
            firstName = FirstName[0];
            var Logo_Img = driver.FindElement(By.CssSelector("#globalNav > realize-main-nav > div > div > cel-platform-navbar")).GetShadowRoot().FindElement(By.CssSelector("#platformNavLogo > img"));
            Logo_Img.Click();
            CommonAction.pageLoadTimeOut(driver, timeOut);
            driver.Navigate().Refresh();
             ProfileBtn = driver.FindElement(By.CssSelector("body > app-root > app-home > app-header > shell-cel-navbar")).GetShadowRoot().FindElement(By.CssSelector("div.right-container > div.profile-container-wrapper > button[data-utility-id='profile'] > span"));
            Assert.AreEqual(firstName, ProfileBtn.Text.ToString());
            var BrowseMenu = ShellcellNavbar.GetShadowRoot().FindElement(By.CssSelector("div.left-container > ul > li:nth-child(2) > a"));
            BrowseMenu.Click();
            ProfileBtn = ShellcellNavbar.GetShadowRoot().FindElement(By.CssSelector("div.right-container > div.profile-container-wrapper >  button[data-utility-id='profile'] > span"));
            Assert.AreEqual(firstName, ProfileBtn.Text.ToString());
            var ClassesMenu = ShellcellNavbar.GetShadowRoot().FindElement(By.CssSelector("div.left-container > ul > li:nth-child(3) > a"));
            ClassesMenu.Click();
            ProfileBtn = driver.FindElement(By.CssSelector("#globalNav > realize-main-nav > div > div > cel-platform-navbar")).GetShadowRoot().FindElement(By.CssSelector("header > div > cel-utility-nav-item.platform__navbar--profileUtility.hydrated")).GetShadowRoot().FindElement(By.CssSelector("#usernameDropdown > div.utility__item--userLabel.row-center > span"));
            Assert.AreEqual(firstName, ProfileBtn.Text.ToString());
            var GradesMenu = driver.FindElement(By.CssSelector("#globalNav > realize-main-nav > div > div > cel-platform-navbar")).GetShadowRoot().FindElement(By.CssSelector("#grades > div > span"));
            GradesMenu.Click();
            driver.Navigate().Refresh();
            ProfileBtn = driver.FindElement(By.CssSelector("#globalNav > realize-main-nav > div > div > cel-platform-navbar")).GetShadowRoot().FindElement(By.CssSelector("header > div > cel-utility-nav-item.platform__navbar--profileUtility.hydrated")).GetShadowRoot().FindElement(By.CssSelector("#usernameDropdown > div.utility__item--userLabel.row-center > span"));
            Assert.AreEqual(firstName, ProfileBtn.Text.ToString());
            
            return true;
        }

        public string Validate_tc010RLZ36955()
        {

            flag = false;
            Class_Title = driver.FindElement(By.XPath("//div//span[@data-e2e-id='Class RGHT-140750010922123713ylT']"));
            CommonAction.MouseOver(driver, Class_Title);            
            Assert.AreEqual("pointer", Class_Title.GetCssValue("cursor"));
            Assert.AreEqual("underline", Class_Title.GetCssValue("text-decoration-line"));
            Assert.AreEqual("rgb(255, 255, 255)", Class_Title.GetCssValue("text-decoration-color"));
            var Class_Image = driver.FindElement(By.CssSelector("app-rostering > div > div > div > div:nth-child(1) > div > div.row.classHeader > div.h-100.pl-0.pr-0.card__image.col-2 > img"));
            Assert.AreEqual(false, CommonAction.ElementClickable(driver, Class_Image, timeOut));
            Class_Title.Click();
            //var Class_Assignment_Title = driver.FindElement(By.CssSelector("app-class-header > div > div > div.class-name > h1"));
            //Assert.AreEqual(Class_Title.Text.ToString(), Class_Assignment_Title.Text.ToString());
            ClassesPage classesPage = new ClassesPage(driver);
            return Class_Title.Text.ToString();


        }

        public string getCurrentURL(IWebDriver driver)
    {

        string homePageURL = CommonAction.getURL(driver);
        CommonAction.ImplicitWait(driver, timeOut);
        return homePageURL;
    }
}
}
