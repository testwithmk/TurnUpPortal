using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortal.Utilities;

namespace TurnUpPortal.Pages
{
    /** This page contains methods related to the Time and Materials (TM) page functionalities 
     */
    public class TMPage : WaitUtil
    {
        // Locators
        private By administrationLocator = By.XPath("//a[contains(text(), 'Administration ')]");
        private By timeAndMaterialLocator = By.XPath("//a[contains(text(),'Time & Materials')]");
        private By createNewBtnLocator = By.XPath("//a[contains(text(),'Create New')]");
        private By typeCodeDropDownLocator = By.XPath("//span[@aria-activedescendant='TypeCode_option_selected']");
        private By timeOptionLocator = By.XPath("//li[text()='Time']");
        private By codeTxtboxLocator = By.Id("Code");
        private By descriptionTxtboxLocator = By.Id("Description");
        private By priceUnitTxtboxLocator = By.XPath("//input[@class='k-formatted-value k-input']");
        private By saveBtnLocator = By.Id("SaveButton");
        private By lastPageLinkLocator = By.XPath("//span[contains(text(),'Go to the last page')]");
        private By getRecordCodeLocator = By.XPath("//*[@id='tmsGrid']//table/tbody/tr[last()]/td[1]");
        private By editBtnLocator = By.XPath("(//a[contains(text(),'Edit')])[last()]");
        private By getRecordDescriptionLocator = By.XPath("//*[@id='tmsGrid']//table/tbody/tr[last()]/td[3]");
        private By getRecordPriceLocator = By.XPath("//*[@id='tmsGrid']//table/tbody/tr[last()]/td[4]");
        private By deleteBtnLocator = By.XPath("(//a[contains(text(),'Delete')])[last()]");

        // WebDriver instance
        private IWebDriver driver = DriverUtil.Driver;

        /** Navigates to the Time and Materials page by first clicking Administration, 
         * then Time & Materials.
         */
        public void NavigateToTMPage()
        {

            // Navigate to Time and Material page
            driver.FindElement(administrationLocator).Click();

            WaitToBeClickable(timeAndMaterialLocator, 5);
            driver.FindElement(timeAndMaterialLocator).Click();

        }
        /** Creates a new Time and Material record with the provided code, description, and price.
         * @param code : Code for the TM record
         * @param description : Description of TM record
         * @param price : Price for the TM record
         */
        public void CreateTMRecord(string code, string description, string price)
        {
            try
            {
                // Click on Create New button
                WaitToBeVisible(createNewBtnLocator, 5);
                driver.FindElement(createNewBtnLocator).Click();

            }
            catch (Exception NoSuchElementException)
            {
                Assert.Fail("Create New Button has not been found");
            }

            // Select time for TypeCode dropdown
            driver.FindElement(typeCodeDropDownLocator).Click();

            WaitToBeVisible(timeOptionLocator, 5);
            driver.FindElement(timeOptionLocator).Click();

            // Add value in Code textbox
            driver.FindElement(codeTxtboxLocator).SendKeys(code);

            // Add value in Description textbox
            driver.FindElement(descriptionTxtboxLocator).SendKeys(description);

            // Type price in Price textbox
            driver.FindElement(priceUnitTxtboxLocator).SendKeys(price);

            // Click on Save button
            driver.FindElement(saveBtnLocator).Click();
            WaitToBeVisible(lastPageLinkLocator, 5);

            // Go to last page of T&M records and verify the new record created
            driver.FindElement(lastPageLinkLocator).Click();
            WaitForPageToLoad();
        }

        /**Gets the code value of the last Time and Material record in the list.
         * return : Code of the last TM record
         */
        public string GetCodeForTMRecord()
        {
            return driver.FindElement(getRecordCodeLocator).Text;

        }

        /**Gets the description of the last Time and Material record in the list.
         * return : description of the last TM record
         */
        public string GetDescriptionForTMRecord()
        {
            return driver.FindElement(getRecordDescriptionLocator).Text;

        }

        /**Gets the price of the last Time and Material record in the list.
         * return : price of the last TM record
         */
        public string GetPriceForTMRecord()
        {
            return driver.FindElement(getRecordPriceLocator).Text;

        }

        /** Edit the last Time and Material record with new code and description.
         * @param code : New Code to set
         * @param description : New Description set
         */
        public void EditTMRecord(string code, string description)
        {
            // Select a TM record and edit the record
            driver.FindElement(lastPageLinkLocator).Click();
            WaitForPageToLoad();

            //Click on Edit button
            driver.FindElement(editBtnLocator).Click();
            WaitToBeVisible(codeTxtboxLocator, 5);

            // Edit value in Code textbox
            driver.FindElement(codeTxtboxLocator).Clear();
            driver.FindElement(codeTxtboxLocator).SendKeys(code);

            // Edit value in Description textbox
            driver.FindElement(descriptionTxtboxLocator).Clear();
            driver.FindElement(descriptionTxtboxLocator).SendKeys(description);

            // Click on Save button
            driver.FindElement(By.Id("SaveButton")).Click();
            WaitForPageToLoad();

            // Go to last page of T&M records and verify the edited record 
            driver.FindElement(lastPageLinkLocator).Click();
            WaitForPageToLoad();
        }

        /** Delete the last Time and Material record in the list.
         */
        public void DeleteTMRecord()
        {
            // Select a TM record and delete the record
            WaitToBeClickable(lastPageLinkLocator, 5);
            driver.FindElement(lastPageLinkLocator).Click();
            WaitForPageToLoad();

            //Click on Delete button
            driver.FindElement(deleteBtnLocator).Click();

            //Select Ok to Delete
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            driver.Navigate().Refresh();
            WaitForPageToLoad();

            //Check if the record is deleted
            driver.FindElement(lastPageLinkLocator).Click();
            WaitForPageToLoad();

        }
    }
}
