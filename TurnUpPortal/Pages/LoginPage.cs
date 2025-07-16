using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V136.WebAuthn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortal.Utilities;

namespace TurnUpPortal.Pages
{
 
    /** This page has methods related to Login page functionality 
     */
     public class LoginPage : WaitUtil
    {
        // locators
        private By usernameTextBoxLocator = By.Id("UserName");
        private By pwdTextBoxLocator = By.Id("Password");
        private By loginBtnLocator = By.XPath("//input[@value='Log in']");

        // Reference to WebDriver instance
        private IWebDriver driver = DriverUtil.Driver;

        private string url = ConfigReader.GetValue("Url");

        /** Log in to the TurnUp Portal using credentials from the configuration file.
         * Navigates to the login page, enters credentials, and clicks the login button.
         */
        public void LoginAsUser()
        {
            //Launch the TurnUp Portal
            driver.Navigate().GoToUrl(url);

            string username = ConfigReader.GetValue("Username");
            string password = ConfigReader.GetValue("Password");

            try
            {
                //Identify username textbox and enter valid username
                WaitToBeVisible(usernameTextBoxLocator, 5);
                driver.FindElement(usernameTextBoxLocator).SendKeys(username);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Username textbox is not located.");
            }
            //Enter valid password and click login
            driver.FindElement(pwdTextBoxLocator).SendKeys(password);
            driver.FindElement(loginBtnLocator).Click();


        }
    }
}
