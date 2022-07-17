using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.PageObject.UI.Ace.Claim;
using CFM_PARALLEL.PageObject.UI.Ace.Dashboard;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.BrandMuscleAdmin
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    //[Category("CFM_ACE_REGRESSION")]
    public class RT_TC_5990_BrandMuscleAdmin_Claim:Base
    {
        public string claimID = string.Empty;

        [Test, Parallelizable]
        [Category("CFM_ACE_REGRESSION")]

        public void RT_TC_BrandMuscleAdmin_Claim_PendingReview()
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
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURL_ACE("CORPORATE1");
                Claim_PerformAction claim_PerformAction = new Claim_PerformAction();
                claim_PerformAction.ACE_Claim_PendingReview(claimID);
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

        //Validating the Available Fund Reduction after Calim Creation
        [Test, NonParallelizable]
        [Category("CFM_ACE_REGRESSION")]
        public void RT_TC_LME_ClaimCreation_CheckingFunds()
        {
            IWebDriver Driver = null;


            try
            {

                //Base bs1 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURL_ACE("LME1");
                Claim_FullFlow claim_FullFlow = new Claim_FullFlow(Driver);
                CommonFunctions cf = new CommonFunctions();
                Dashboard_Landing dl = new Dashboard_Landing();
                string AvailableFundsBeforeClaimsCreation = cf.GetAvailableFunds(Parameters.Ace_ProgramName());

                claimID = claim_FullFlow.Ace_Claim_FullFlow("N", string.Empty);
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                //Verifying the Fund Deducted correctly
                //Navigating Back to DashBoard
                dl.NavigatingToDashBoard();

                Thread.Sleep(10000);
                string AvailableFindsAfterClaimCreation = cf.GetAvailableFunds(Parameters.Ace_ProgramName());
                Assert.True(Convert.ToDouble(AvailableFindsAfterClaimCreation.Replace("$", "")) == (Convert.ToDouble(AvailableFundsBeforeClaimsCreation.Replace("$", "")) - Convert.ToDouble(Parameters.ClaimRequestedAmount_ACE().Replace("$", ""))));

                Console.WriteLine("Calim Requested Amount Deducted from Available Funds Correctly");
CommonUtilities.Logout(Driver);       Driver.Quit();

                //Base bs2 = new Base();
                Driver=OpenBrowser();
                Claim_FullFlow claim_FullFlow2 = new Claim_FullFlow(Driver);
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                Claim_PerformAction claim_PerformAction = new Claim_PerformAction();

                bl2.BrowserURL_ACE("CORPORATE1");
                //Approve ClaimID 
                claim_PerformAction.ACE_Claim_Approve(claimID, "Approve", "34", Parameters.ClaimApprovalAmount_ACE);

CommonUtilities.Logout(Driver);       Driver.Quit();


                //Login with LME again to verify the Funds After Approval

                //Base bs3 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bl3 = new BrowserURLLaunch(Driver);
                bl3.BrowserURL_ACE("LME1");
                CommonFunctions cf2 = new CommonFunctions();

                //Get Funds After Approval
                string AvailableFundsAfterApproval = cf2.GetAvailableFunds(Parameters.Pandora_ProgramName());
                //verifying After Approval the remaining amount is added to Available Balance
                Assert.True(Convert.ToDouble(AvailableFundsAfterApproval.Replace("$", "")) == (Convert.ToDouble(AvailableFundsBeforeClaimsCreation.Replace("$", "")) - Convert.ToDouble(Parameters.ClaimApprovalAmount_ACE.Replace("$", ""))));
                Console.WriteLine("Calim Approval Amount Deducted from Available Funds Correctly");
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