using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.PageObject.UI.Ace.Claim;
using CFM_PARALLEL.StartUp;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.BrandMuscleAdmin
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [Category("CFM_ACE_REGRESSION")]
    public class RT_TC_6183_BrandMuscleAdmin_Claim:Base
    {
        public string claimID = string.Empty;

        [Test, Parallelizable]
        public void RT_TC_BrandMuscleAdmin_Claim_NeedsChange()
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
CommonUtilities.Logout(Driver);       Driver.Quit();

                //Base bs2 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURL_ACE("CORPORATE1");
                Claim_PerformAction claim_PerformAction = new Claim_PerformAction();
                claim_PerformAction.ACE_Claim_PerformAction(claimID, "Needs Change");
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

        [Test]
        //[Category("CFM_ACE_SMOKE")]
        public void RT_TC_LME_Claim_Clone()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURL_ACE("LME1");
                Claim_PerformAction cp = new Claim_PerformAction();
                Claim_FullFlow cf = new Claim_FullFlow(Driver);
                claimID = cf.Ace_Claim_FullFlow("N", string.Empty);

                //claimID = cp.SearchAndGetClaimIdofPendingReviewClaim();
                //if (claimID == null)
                //{
                //    Claim_FullFlow cf = new Claim_FullFlow(Driver);
                //    claimID = cf.Ace_Claim_FullFlow("N", string.Empty);
                //                    CommonUtilities.Logout(Driver);       Driver.Quit();;
                //    Thread.Sleep(5000);
                //}
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                //Thread.Sleep(5000);

                ////Base bs1 = new Base();
                //Driver=OpenBrowser();
                //BrowserURLLaunch bll = new BrowserURLLaunch(Driver);
                //bll.BrowserURLACE("LME1");

                Claim_Clone cc = new Claim_Clone(Driver);
                cc.NavigatingBackToDashBoard();
                cc.ACE_Claim_Clone(claimID);
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