using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NUnit.Framework.Constraints.Tolerance;

namespace TurnUpPortal.Utilities
{
    /** Utility class to manage the WebDriver instance across the framework.
     */
    public class DriverUtil
    {
        // WebDriver instance
        private static IWebDriver driver;

        /** Gets or sets the WebDriver instance.
         * Throws an exception if accessed before initialization.
        */
        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new Exception("WebDriver is not initialized.");
                return driver;
            }
            set
            {
                driver = value;
            }
        }
    }
}
