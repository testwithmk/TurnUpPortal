using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortal.Pages;
using TurnUpPortal.Utilities;

namespace TurnUpPortal.Tests
{
    /** This class contains common setup and teardown methods 
     * for all test classes.
    */
    public class BaseTest
    {
        /**This method runs once before any tests in the class are executed.
         * It initializes the WebDriver based on the browser configuration,
         * maximizes the browser window, and login into the TurnUp portal.
        */
        [OneTimeSetUp]
        public void GlobalSetUp()
        {
            // Get browser
            string browser = ConfigReader.GetValue("Browser");

            DriverUtil.Driver = BrowserFactory.BrowserOption(browser);
            DriverUtil.Driver.Manage().Window.Maximize();

            //Login page initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginAsUser();
        }

        /**This method runs once after all tests in the class have finished executing.
         * It closes the WebDriver instance.
        */
        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            if (DriverUtil.Driver != null)
            {
                DriverUtil.Driver.Quit();
                DriverUtil.Driver = null;
            }
        }
    }
}
