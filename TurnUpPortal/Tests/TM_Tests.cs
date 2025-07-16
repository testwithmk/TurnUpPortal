using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortal.Pages;

namespace TurnUpPortal.Tests
{
    /** This test class verifies the creation, editing, and deletion of Time and Materials (TM) records
     * on the TurnUp portal. It inherits common setup/teardown from BaseTest.
    */
    [TestFixture]
    public class TM_Tests : BaseTest
    {
        // Test data and result variables
        private string code;
        private string description;
        private string price;
        private string recordCode;
        private string recordDescription;
        private string recordPrice;

        private TMPage tMPageObj;

        /**Initializes fresh test data and 
         * navigates to the TM page before each test.
         */
        [SetUp]
        public void TestLogin()
        {
            // Initialize new test data
            code = "Test" + Guid.NewGuid().ToString().Substring(0, 6);
            description = Guid.NewGuid().ToString("N").Substring(0, 10);
            price = new string(Guid.NewGuid().ToString("N").Where(char.IsDigit).Take(4).ToArray());

            // Initialize TM page object
            tMPageObj = new TMPage();
            tMPageObj.NavigateToTMPage();
        }

        [Test, Description("This test verifies creation of a new Time record")]
        public void CreateTM_Test()
        {
            tMPageObj.CreateTMRecord(code, description, price);

            recordCode = tMPageObj.GetCodeForTMRecord();
            recordDescription = tMPageObj.GetDescriptionForTMRecord();

            Assert.That(recordCode == code && recordDescription == description, $"New TM record has not created. Found Code : {recordCode}, Description : {recordDescription}");
        }

        [Test, Description("This test verifies creation of a new Time record and then edit that record")]
        public void EditTM_Test()
        {
            // Create new TM record first to edit
            tMPageObj.CreateTMRecord(code, description, price);

            //New values
            string updatedCode = code + "_Edited";
            string updateddescription = code + "_Updated Description";

            tMPageObj.EditTMRecord(updatedCode, updateddescription);

            recordCode = tMPageObj.GetCodeForTMRecord();
            recordDescription = tMPageObj.GetDescriptionForTMRecord();
            Assert.That(recordCode == updatedCode && recordDescription == updateddescription, $"TM record has been not edited. Found Code : {recordCode}, Description : {recordDescription}");
        }

        [Test, Description("This test verifies creation of a new Time record and then deletes that record")]
        public void DeleteTM_Test()
        {
            // Create new TM record first to delete
            tMPageObj.CreateTMRecord(code, description, price);

            tMPageObj.DeleteTMRecord();

            recordCode = tMPageObj.GetCodeForTMRecord();
            recordPrice = tMPageObj.GetPriceForTMRecord();
            Assert.That(recordCode != code && recordPrice != price, $"T&M Record has not been deleted. Found Code : {recordCode}, Price : {recordPrice} ");

        }
    }
}
