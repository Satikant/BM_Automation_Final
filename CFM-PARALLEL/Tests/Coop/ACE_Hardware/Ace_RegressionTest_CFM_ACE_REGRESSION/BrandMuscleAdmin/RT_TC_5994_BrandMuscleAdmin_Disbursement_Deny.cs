using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.PageObject.UI.Ace.Claim;
using CFM_PARALLEL.PageObject.UI.Ace.Dashboard;
using CFM_PARALLEL.StartUp;
using CFMAutomation.PageObject.UI.Ace.Disbursement;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.BrandMuscleAdmin
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [Category("CFM_ACE_REGRESSION")]
    public class RT_TC_5994_BrandMuscleAdmin_Disbursement:Base
    {
        public string claimID = string.Empty;
        [Test]
        public void RT_TC_BrandMuscleAdmin_Disbursement_Deny()
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
                CommonUtilities.Logout(Driver);
                Driver.Quit();

                Thread.Sleep(20000);
                //Base bs2 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURL_ACE("CORPORATE1");
                Claim_PerformAction claim_PerformAction = new Claim_PerformAction();
                claim_PerformAction.ACE_Claim_PerformAction(claimID, "Approve");
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Dashboard_Landing dl = new Dashboard_Landing();
                dl.NavigatingToDashBoard();
                Thread.Sleep(10000);
                ////Base bs3 = new Base();
                //Driver=OpenBrowser();
                //BrowserURLLaunch bl3 = new BrowserURLLaunch(Driver);
                //bl3.BrowserURLACE("CORPORATE1");
                Disbursement_Fullflow disbursement_Fullflow = new Disbursement_Fullflow(Driver);
                disbursement_Fullflow.Ace_Disbursement_Fullflow("Deny", claimID);
                CommonUtilities.Logout(Driver);
                Driver.Quit();

                Driver = OpenBrowser();
                BrowserURLLaunch bl3 = new BrowserURLLaunch(Driver);
                bl3.BrowserURL_ACE("LME1");
                Claim_PerformAction cp = new Claim_PerformAction();
                string ClaimStatusAfterDisbursement = cp.GetClaimStatus(claimID);
                Assert.IsTrue(ClaimStatusAfterDisbursement.ToUpper().Contains("Approved".ToUpper()));
                Console.WriteLine("Claim Status Changed to Approved After disbursement Rejected");
                CommonUtilities.Logout(Driver);
                Driver.Quit();
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