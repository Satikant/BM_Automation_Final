using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.PageObject.UI.Ace.Claim;
using CFM_PARALLEL.PageObject.UI.Ace.Dashboard;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.CFMChainHQ
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [Category("CFM_ACE_REGRESSION")]
    public class RT_TC_1_CFMChainHQ_ClaimProgramOverdrawnNeedChange :Base
    {
        public string claimID = string.Empty;

        [Test]
        public void RT_TC_CFMChainHQ_ClaimProgramOverdrawn_NeedChange()
        {
            IWebDriver Driver = null;
            string claimID = string.Empty;
            try
            {
                //Base bs3 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl3 = new BrowserURLLaunch(Driver);
                bl3.BrowserURL_ACE("LME1");
                Claim_PerformAction claim_PerformAction = new Claim_PerformAction();
                CommonFunctions cf = new CommonFunctions();
                double AmountBeforeApproval = Convert.ToDouble(cf.GetAvailableFunds(Parameters.Ace_ProgramName("YES")));

                Claim_FullFlow claim_FullFlow = new Claim_FullFlow(Driver);
                claimID = claim_FullFlow.Ace_Claim_FullFlow("N", string.Empty, ProgramOverDrawn: "YES");
CommonUtilities.Logout(Driver);       Driver.Quit();

                //Base bs2 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURL_ACE("CORPORATE1");
                Claim_PerformAction claim_PerformAction2 = new Claim_PerformAction();

                claim_PerformAction2.ACE_Claim_PerformActionOD(claimID, "Needs Change", "10", AmountBeforeApproval, expectation: "AmountAfterNeedChange");
CommonUtilities.Logout(Driver);       Driver.Quit();


                //Base bs = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURL_ACE("LME1");
                //Dashboard_Landing dl = new Dashboard_Landing(Driver);
                //dl.NavigatingToDashBoard();
                CommonFunctions cf1 = new CommonFunctions();

                double AmountAfterApproval = Convert.ToDouble(cf1.GetAvailableFunds(Parameters.Ace_ProgramName("YES")));

                Assert.AreEqual(AmountAfterApproval, (AmountBeforeApproval - Convert.ToDouble(Parameters.ClaimRequestedAmount_ACE("YES"))));
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

        [Test, NonParallelizable]
        //[Category("CFM_ACE_SMOKE")]
        public void RT_TC_CFMChainHQ_ClaimProgramOverdrawn_Clone()
        {
            IWebDriver Driver = null;
            try
            {
                string claimID = string.Empty;
                //Base bs3 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl3 = new BrowserURLLaunch(Driver);
                bl3.BrowserURL_ACE("LME1");
                Claim_PerformAction claim_PerformAction = new Claim_PerformAction();
                CommonFunctions cf = new CommonFunctions();
                //double AmountBeforeApproval = Convert.ToDouble(cf.GetAvailableFunds(Parameters.Ace_ProgramName("YES")));

                Claim_FullFlow claim_FullFlow = new Claim_FullFlow(Driver);
                claimID = claim_FullFlow.Ace_Claim_FullFlow("N", string.Empty, ProgramOverDrawn: "YES");
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;

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


        [Test]
        public void RT_TC_CFMChainHQ_ClaimProgramOverdrawn_Resubmitted()
        {
            IWebDriver Driver = null;

            string claimID = string.Empty;
            try
            {
                //Base bs3 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl3 = new BrowserURLLaunch(Driver);
                bl3.BrowserURL_ACE("LME1");
                Claim_PerformAction claim_PerformAction = new Claim_PerformAction();
                CommonFunctions cf = new CommonFunctions();
                double AmountBeforeApproval = Convert.ToDouble(cf.GetAvailableFunds(Parameters.Ace_ProgramName("YES")));

                Claim_FullFlow claim_FullFlow = new Claim_FullFlow(Driver);
                claimID = claim_FullFlow.Ace_Claim_FullFlow("N", string.Empty, ProgramOverDrawn: "YES");
CommonUtilities.Logout(Driver);       Driver.Quit();

                //Base bs2 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURL_ACE("CORPORATE1");
                Claim_PerformAction claim_PerformAction2 = new Claim_PerformAction();

                claim_PerformAction2.ACE_Claim_PerformActionOD(claimID, "Needs Change", "10", AmountBeforeApproval, expectation: "AmountAfterNeedChange");
CommonUtilities.Logout(Driver);       Driver.Quit();


                //Base bs = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURL_ACE("LME1");
                //Dashboard_Landing dl = new Dashboard_Landing(Driver);
                //dl.NavigatingToDashBoard();
                CommonFunctions cf1 = new CommonFunctions();

                double AmountAfterApproval = Convert.ToDouble(cf1.GetAvailableFunds(Parameters.Ace_ProgramName("YES")));

                Assert.AreEqual(AmountAfterApproval, (AmountBeforeApproval - Convert.ToDouble(Parameters.ClaimRequestedAmount_ACE("YES"))));
                Claim_Resubmitted claim_Resubmitted = new Claim_Resubmitted(Driver);
                string ResubmittedClaimID = claim_Resubmitted.Ace_Claim_Resubmitted(claimID);
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