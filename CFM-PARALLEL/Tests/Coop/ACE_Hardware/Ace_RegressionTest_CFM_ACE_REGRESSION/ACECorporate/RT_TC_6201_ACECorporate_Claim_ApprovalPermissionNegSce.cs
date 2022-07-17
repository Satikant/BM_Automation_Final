using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.PageObject.UI.Ace.Claim;
using CFM_PARALLEL.StartUp;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.ACECorporate
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [Category("CFM_ACE_REGRESSION")]
    public class RT_TC_6201_ACECorporate_Claim:Base
    {
        public string claimID = string.Empty;

        [Test]
        public void RT_TC_LME_Claim_ApprovalPermissionNegSce()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs1 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURL_ACE("LME1");
                Claim_FullFlow claim_FullFlow = new Claim_FullFlow(Driver);
                claimID = claim_FullFlow.Ace_Claim_FullFlow("N", string.Empty);
                Claim_ApprovalPermission claim_ApprovalPermission = new Claim_ApprovalPermission(Driver);
                claim_ApprovalPermission.Ace_Claim_ApprovalPermission(claimID, "Approve", "34");
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