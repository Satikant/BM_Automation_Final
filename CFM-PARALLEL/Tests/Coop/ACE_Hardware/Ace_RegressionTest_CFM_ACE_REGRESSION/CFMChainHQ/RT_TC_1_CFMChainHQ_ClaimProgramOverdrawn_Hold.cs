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
    public class RT_TC_1_CFMChainHQ_ClaimProgramOverdrawnHold:Base
    {
        public string claimID = string.Empty;
        [Test, NonParallelizable]
        public void RT_TC_CFMChainHQ_ClaimProgramOverdrawn_Hold()
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

                claim_PerformAction2.ACE_Claim_PerformActionOD(claimID, "Hold", "36", AmountBeforeApproval, expectation: "hold");
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


    }
}