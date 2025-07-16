using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortal.Utilities
{
    /** This Factory class is used to initialize 
     * WebDriver instances based on browser type.
     */
    public class BrowserFactory
    {
        /** Returns a configured WebDriver instance based on the specified browser name.
         * @param browser : name of the browser
         * return : IWebDriver instance for specific browser
         */
        public static IWebDriver BrowserOption(string browser)
        {
            switch (browser.ToLower())
            {

                case "chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddUserProfilePreference("profile.password_manager_leak_detection", false);
                    return new ChromeDriver(chromeOptions);

                case "firefox":
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    return new FirefoxDriver(firefoxOptions);

                case "edge":
                    EdgeOptions edgeOptions = new EdgeOptions();
                    return new EdgeDriver(edgeOptions);

                default:
                    throw new ArgumentException("Unsupported browser: " + browser);

            }
        }
    }
}
