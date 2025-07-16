using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortal.Utilities
{
    /**This class contains utility methods
     * for common wait operations used across multiple pages.
     */
    public class WaitUtil
    {
        private WebDriverWait wait;

        /** Waits for the entire page to be fully loaded 
         * @param timeoutSeconds: to give time in seconds
         */
        public void WaitForPageToLoad(int timeoutSeconds = 10)
        {

            wait = new WebDriverWait(DriverUtil.Driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(d =>
            ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString() == "complete"

    );
        }

        /** Waits until the specified element becomes clickable. 
         *  @param locatorValue: locator of the element to wait
         *  @param seconds : time duration in seconds
         */
        public static void WaitToBeClickable(By locatorValue, int seconds)
        {
            var wait = new WebDriverWait(DriverUtil.Driver, new TimeSpan(0, 0, seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locatorValue));

        }

        /** Waits until the specified element becomes visible on the page. 
        *  @param locatorValue: locator of the element to wait
        *  @param seconds : time duration in seconds
        */
        public static void WaitToBeVisible(By locatorValue, int seconds)
        {
            var wait = new WebDriverWait(DriverUtil.Driver, new TimeSpan(0, 0, seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible((locatorValue)));
        }
    }
}
