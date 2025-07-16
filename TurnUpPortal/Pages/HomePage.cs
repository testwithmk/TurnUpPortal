using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortal.Utilities;

namespace TurnUpPortal.Pages
{
    /** This page has methods related to Home Page functionality
     */
    public class HomePage
    {

        private By turnUpLocator = By.XPath("//a[contains(text(),'TurnUp')]");

        /**Navigates to the Home Page 
         * by clicking on the "TurnUp" link
         */
        public void NavigateToHomePage()
        {
            DriverUtil.Driver.FindElement(turnUpLocator).Click();
        }
    }
}
