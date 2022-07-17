using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.Ace.Claim;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using CFMAutomation.PageObject.UI.Ace.Transactions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;

namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.BrandMuscleAdmin
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    
    public class RT_TC_6004_BrandMuscleAdmin_Claim:Base
    {
        public string claimID = string.Empty;
        public By Dashboard { get { return (By.Id("dashboard")); } }

        [Test, NonParallelizable]
        [Category("CFM_ACE_REGRESSION")]
        public void RT_TC_BrandMuscleAdmin_Claim_VerifyingApprovedAmountNotGreaterThanRequestedAmount()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs1 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURL_ACE("LME1");
                Claim_FullFlow claim_FullFlow = new Claim_FullFlow(Driver);
                BasicInteractions Bi = new BasicInteractions(Driver);
                CommonFunctions cf = new CommonFunctions();
                Transaction_Accrual ta = new Transaction_Accrual();
                //bi.WaitVisible(Dashboard);
                //bi.Click(Dashboard);
                ////Get Available Funds Before Creating Claim
                //Double AvailableFundsBeforeClaimCreation = ta.GetAvailableFunds(Parameters.Ace_ProgramName());
                claimID = claim_FullFlow.Ace_Claim_FullFlow("N", string.Empty);

                ////get Available Funds After Creating Claim

                //bi.WaitVisible(Dashboard);
                //bi.Click(Dashboard);

                //Double AvailableFindsAfterClaimCreation = ta.GetAvailableFunds(Parameters.Ace_ProgramName());
                //Assert.True(Convert.ToDouble(AvailableFindsAfterClaimCreation) == (Convert.ToDouble(AvailableFundsBeforeClaimCreation)- Convert.ToDouble(Parameters.ClaimRequestedAmount_ACE()) ));
                //Console.WriteLine("Calim Amount Deducted from Available Funds Correctly");
CommonUtilities.Logout(Driver);       Driver.Quit();

                //Base bs2 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURL_ACE("CORPORATE1");
                Claim_Validations claim_Validation = new Claim_Validations(Driver);
                claim_Validation.ClaimApprovalAmountValidation(claimID, "Approve", "34");
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