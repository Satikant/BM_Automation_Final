using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.StartUp;
using CFMAutomation.PageObject.UI.Ace.Transactions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.ACECorporate
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [Category("CFM_ACE_REGRESSION")]
    public class RT_TC_6045_ACECorporate_Transactions:Base
    {
        [Test]
        public void RT_TC_LME_Transactions_NegativeScenario()
        {
            IWebDriver Driver = null;
            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURL_ACE("LME1");

                Transaction_Negative transaction_Negative = new Transaction_Negative(Driver);
                transaction_Negative.Transaction_NegativeScenario_LeftNavValidation();
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