using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using CFMAutomation.PageObject.UI.Ace.Transactions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.BrandMuscleAdmin
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class RT_TC_6001_Transactions:Base
    {
        [Test, NonParallelizable]
        [Category("CFM_ACE_REGRESSION")]
        public void RT_TC_BrandMuscleAdmin_Transactions_VerifyingAdjustmentEntryInFundSnapShot() {
            IWebDriver Driver = null;
            try
            {
                //Base bs1 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURL_ACE("CORPORATE1");
                Transaction_Adjustment transaction_Adjustment = new Transaction_Adjustment(Driver);
                transaction_Adjustment.Transaction_AllocateAdjustment("Flat", Parameters.Ace_AccrualPositive_Amount);
                transaction_Adjustment.VerifyingAdjustmentEntryUnderDetailedReport();

CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }
    }
}