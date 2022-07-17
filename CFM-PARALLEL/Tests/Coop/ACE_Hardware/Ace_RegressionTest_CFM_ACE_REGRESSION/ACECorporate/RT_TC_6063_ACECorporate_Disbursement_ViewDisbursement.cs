using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.StartUp;
using CFMAutomation.PageObject.UI.Ace.Disbursement;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.CFMIndependent
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [Category("CFM_ACE_REGRESSION")]
    public class RT_TC_6063_ACECorporate_Disbursement_Negative:Base
    { 
        [Test]
        public void RT_TC_LME_Disbursement_NoPermissionToViewDisbursement()
        {
            IWebDriver Driver = null;
            try
            {
                //Base bs1 = new Base();
                Driver = OpenBrowser();

                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURL_ACE("LME1");
                Disbursement_Negative disbursement_Negative = new Disbursement_Negative(Driver);
                disbursement_Negative.Disbursement_Negative_ViewDisbursement("ACECorporate");
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);       Driver.Quit();;
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