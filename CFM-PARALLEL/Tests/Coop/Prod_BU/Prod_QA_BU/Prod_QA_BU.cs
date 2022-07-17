using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CFM_PARALLEL.Tests.Coop.Prod_QA_BU
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures)]
    public class Prod_QA_BU : Base
    {
        [Test, Parallelizable] // begin of test case
        [Category("CFM_BUCFM_SMOKE_PROD")]
        public void ST_TC_Prod_BU_Dashboard()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CHILD");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.MS_Dashboard().DashBoard_Validation();// using masco dashboard object
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in ST_TC_PROD_BU_Dashboard:" + ex.Message);
                throw;
            }           
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_BUCFM_SMOKE_PROD")]
        public void ST_TC_Prod_BU_BPA_Hold_Approve()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CHILD");
                Pages.BrowserURLLaunch().Click_CFMLink();
                //string BPA_ID1 = Pages.Prod_BU_BPA().Create_BPA();
                string BPA_ID1 = "BPA-5112";

                string BPA_ID2 = Pages.MS_BrandPreApproval().Clone_BPA(BPA_ID1);

                Driver_CleanUp(); // explicitly called for logout 
                Driver_SetUp(); // explicitly called for open browser

                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CORPORATE1");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.MS_BrandPreApproval().Review_BPA(BPA_ID1,"Hold");
                Pages.MS_BrandPreApproval().Review_BPA(BPA_ID2,"Approve");                    
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in ST_TC_PROD_BU_BPA_Hold_Approve method " + ex.Message);
                throw;
            }            
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_BUCFM_SMOKE_PROD")]
        public void ST_TC_Prod_BU_BPA_NeedsChange_Resubmit_Deny()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CHILD");
                Pages.BrowserURLLaunch().Click_CFMLink();
                string BPA_ID1 = Pages.Prod_BU_BPA().Create_BPA();
                string BPA_ID2 = Pages.MS_BrandPreApproval().Clone_BPA(BPA_ID1);

                Driver_CleanUp(); // explicitly called for logout 
                Driver_SetUp(); // explicitly called for open browser

                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CORPORATE1");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.MS_BrandPreApproval().Review_BPA(BPA_ID1, "Needs Change");
                Pages.MS_BrandPreApproval().Review_BPA(BPA_ID2, "Deny");

                Driver_CleanUp(); // explicitly called for logout 
                Driver_SetUp(); // explicitly called for open browser

                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CHILD");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.MS_BrandPreApproval().Resubmit_BPA(BPA_ID1);
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in ST_TC_PROD_BU_BPA_Hold_Approve method " + ex.Message);
                throw;
            }

        } // end of test case

        [Test, Parallelizable]  // begin of test case
        [Category("CFM_BUCFM_SMOKE_PROD")]
        public void ST_TC_Prod_BU_FPA_Hold_Approve()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CHILD");
                Pages.BrowserURLLaunch().Click_CFMLink();

                List<double> initialAmountList = Pages.MS_Dashboard().FundCalculation();

                string FPAId1 = Pages.Prod_BU_BPA().Create_FPA("FPA"); // Create FPA
                List<double> finalAmountList = Pages.MS_Dashboard().FundCalculation();

                double expectedAvailableFund = initialAmountList[0] - Double.Parse(Parameters.MS_RequestedAmount);
                double expectedFrozenFund = initialAmountList[1] + Double.Parse(Parameters.MS_RequestedAmount);

                //Assert.AreEqual(expectedAvailableFund, finalAmountList[0]);
                //Assert.AreEqual(expectedFrozenFund, finalAmountList[1]);

                string FPAId2 = Pages.MS_FundPreApproval().Clone_FPA(FPAId1); // clone FPA

                Driver_CleanUp(); // explicitly called for logout 
                Driver_SetUp(); // explicitly called for open browser

                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CORPORATE1");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.MS_FundPreApproval().Review_FPA(FPAId1, "Approve");
                Pages.MS_FundPreApproval().Review_FPA(FPAId2, "Hold");
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in ST_TC_Prod_BU_FPA_Hold_Approve TestCase " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable]  // begin of test case
        [Category("CFM_BUCFM_SMOKE_PROD")]
        public void ST_TC_Prod_BU_FPA_NeedsChange_Resubmit_Deny()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CHILD");
                Pages.BrowserURLLaunch().Click_CFMLink();
                string FPAId1 = Pages.Prod_BU_BPA().Create_FPA("FPA"); // Create FPA
                string FPAId2 = Pages.MS_FundPreApproval().Clone_FPA(FPAId1); // clone FPA

                Driver_CleanUp(); // explicitly called for logout 
                Driver_SetUp(); // explicitly called for open browser

                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CORPORATE1");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.MS_FundPreApproval().Review_FPA(FPAId1, "Needs Change");
                Pages.MS_FundPreApproval().Review_FPA(FPAId2, "Deny");

                Driver_CleanUp(); // explicitly called for logout 
                Driver_SetUp(); // explicitly called for open browser

                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CHILD");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.MS_FundPreApproval().Resubmit_FPA(FPAId1);// resubmit                                
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in ST_TC_Prod_BU_FPA_NeedsChange_Resubmit_Deny TestCase " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_BUCFM_SMOKE_PROD")]
        public void ST_TC_Prod_BU_Fundsnapshot()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CORPORATE1");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.MS_Dashboard().FundSnapshot_Validation(); // using masco dashboard object
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in ST_TC_Prod_BU_Fundsnapshot method " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_BUCFM_SMOKE_PROD")]
        public void ST_TC_Prod_BU_Program()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CORPORATE1");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.MS_Programs().Validate_Programs(); // using masco program object
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in ST_TC_Prod_BU_Program method " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_BUCFM_SMOKE_PROD")]
        public void ST_TC_Prod_BU_DisplayClaim_Hold_Approve()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CHILD");
                Pages.BrowserURLLaunch().Click_CFMLink();
                string DisplayClaimID1 = Pages.Claims_DisplayClaim().Create_DisplayClaim(Parameters.Prod_BU_StoreName, Parameters.Prod_BU_ProgramName);
                string DisplayClaimID2 = Pages.Claims_DisplayClaim().Clone_DisplayClaim(DisplayClaimID1); // clone

                Driver_CleanUp(); // explicitly called for logout 
                Driver_SetUp(); // explicitly called for open browser

                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CORPORATE1");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.Claims_DisplayClaim().Review_DisplayClaim(DisplayClaimID1, "Hold"); // Display Claim id 1 = hold
                Pages.Claims_DisplayClaim().Review_DisplayClaim(DisplayClaimID2, "Approve"); //  Display Claim id 1 = approve
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in ST_TC_Prod_BU_DisplayClaim_Hold_Approve method " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_BUCFM_SMOKE_PROD")]
        public void ST_TC_Prod_BU_DisplayClaim_NeedsChange_Resubmit_Deny()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CHILD");
                Pages.BrowserURLLaunch().Click_CFMLink();

                string DisplayClaimID1 = Pages.Claims_DisplayClaim().Create_DisplayClaim(Parameters.Prod_BU_StoreName, Parameters.Prod_BU_ProgramName);
                string DisplayClaimID2 = Pages.Claims_DisplayClaim().Clone_DisplayClaim(DisplayClaimID1); // clone

                Driver_CleanUp(); // explicitly called for logout 
                Driver_SetUp(); // explicitly called for open browser

                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CORPORATE1");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.Claims_DisplayClaim().Review_DisplayClaim(DisplayClaimID1, "Needs Change");
                Pages.Claims_DisplayClaim().Review_DisplayClaim(DisplayClaimID2, "Deny");

                Driver_CleanUp(); // explicitly called for logout 
                Driver_SetUp(); // explicitly called for open browser

                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CHILD");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.Claims_DisplayClaim().Resubmit_DisplayClaim(DisplayClaimID1);
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in ST_TC_Prod_BU_DisplayClaim_NeedsChange_Resubmit_Deny method " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_BUCFM_SMOKE_PROD")]
        public void ST_TC_Prod_BU_FundRequestApprove()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CHILD");
                Pages.BrowserURLLaunch().Click_CFMLink();
                double AmountBeforeApproval = Convert.ToDouble(Pages.CommonFunctions().DashboardAvailableFunds(Parameters.Prod_BU_ProgramName));
                Console.WriteLine("Amount before approval = "+ AmountBeforeApproval);

                string FundRequestId = Pages.MS_FundRequest().Create_FundRequest(Parameters.MS_FR_RequestedAmount,Parameters.Prod_BU_StoreName,Parameters.Prod_BU_ProgramName,true);

                Driver_CleanUp(); // explicitly called for logout 
                Driver_SetUp(); // explicitly called for open browser

                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CORPORATE1");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.NW_FundRequest().Review_FundRequest(FundRequestId, "Approve");

                Driver_CleanUp(); // explicitly called for logout 
                Driver_SetUp(); // explicitly called for open browser

                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CHILD");
                Pages.BrowserURLLaunch().Click_CFMLink();
                double AmountAfterApproval = Convert.ToDouble(Pages.CommonFunctions().DashboardAvailableFunds(Parameters.Prod_BU_ProgramName));
                double ExpectedAmount = AmountBeforeApproval + double.Parse(Parameters.MS_RequestedAmount);
                Console.WriteLine("Amount after approval = " +AmountAfterApproval);
                //Assert.AreEqual(ExpectedAmount, AmountAfterApproval);
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in ST_TC_Prod_BU_FundRequestApprove method " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_BUCFM_SMOKE_PROD")]
        public void ST_TC_Prod_BU_FundRequest_Deny()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CHILD");
                Pages.BrowserURLLaunch().Click_CFMLink();
                double AmountBeforeApproval = Convert.ToDouble(Pages.CommonFunctions().DashboardAvailableFunds(Parameters.Prod_BU_ProgramName));
                Console.WriteLine("Amount before approval = " + AmountBeforeApproval);

                string FundRequestId = Pages.MS_FundRequest().Create_FundRequest(Parameters.MS_FR_RequestedAmount, Parameters.Prod_BU_StoreName, Parameters.Prod_BU_ProgramName, true);

                Driver_CleanUp(); // explicitly called for logout 
                Driver_SetUp(); // explicitly called for open browser

                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CORPORATE1");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.NW_FundRequest().Review_FundRequest(FundRequestId, "Reject");
                
                Driver_CleanUp(); // explicitly called for logout 
                Driver_SetUp(); // explicitly called for open browser

                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CHILD");
                Pages.BrowserURLLaunch().Click_CFMLink();
                double AmountAfterApproval = Convert.ToDouble(Pages.CommonFunctions().DashboardAvailableFunds(Parameters.Prod_BU_ProgramName));
                double ExpectedAmount = AmountBeforeApproval + double.Parse(Parameters.MS_RequestedAmount);
                Console.WriteLine("Amount after approval = " + AmountAfterApproval);
                Assert.AreEqual(AmountBeforeApproval,AmountAfterApproval);
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in ST_TC_Prod_BU_FundRequestApprove method " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_BUCFM_SMOKE_PROD")]
        public void ST_TC_Prod_BU_Claim_Hold_Approve()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CHILD");
                Pages.BrowserURLLaunch().Click_CFMLink();
                double AmountBeforeApproval = Convert.ToDouble(Pages.CommonFunctions().DashboardAvailableFunds(Parameters.Prod_BU_ProgramName));
                Console.WriteLine("Amount before Approval = " + AmountBeforeApproval);
                string claim_ID = Pages.Claims_DisplayClaim().Prod_BU_CreateClaim();
                Pages.MS_Claims().validate_Claim_ViewDetailed_Report("Open", Parameters.MS_RequestedAmount, claim_ID);// amount and claimID validation

                Driver_CleanUp(); // explicitly called for logout 
                Driver_SetUp(); // explicitly called for open browser

                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CORPORATE1");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.MS_Claims().Review_Claim(claim_ID, "Hold"); // using masco claim object
                Pages.MS_Claims().Review_Claim(claim_ID, "Approve"); // using masco claim object

                double AmountAfterApproval = Convert.ToDouble(Pages.CommonFunctions().GetAvailableFunds(Parameters.Prod_BU_ProgramName));// actual amount
                double ExpectedAmount = AmountBeforeApproval - double.Parse(Parameters.MS_RequestedAmount);
                Console.WriteLine("Asserting for exped and actual amount in ST_TC_Prod_Claim_Hold_Approve test case");
                Assert.AreEqual(ExpectedAmount, AmountAfterApproval);

                Pages.MS_Claims().validate_Claim_ViewDetailed_Report("Approved", Parameters.MS_RequestedAmount, claim_ID); //amount and claimID validation
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in ST_TC_Prod_BU_Program method " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_BUCFM_SMOKE_PROD")]
        public void ST_TC_Prod_BU_Claim_NeedsChange_Resubmit_Deny()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CHILD");
                Pages.BrowserURLLaunch().Click_CFMLink();
                string claim_ID = Pages.Claims_DisplayClaim().Prod_BU_CreateClaim();

                Driver_CleanUp(); // explicitly called for logout 
                Driver_SetUp(); // explicitly called for open browser

                Pages.BrowserURLLaunch().BrowserURL_Prod_QA_BU("CORPORATE1");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.MS_Claims().Review_Claim(claim_ID, "Deny"); // using masco claim object
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in ST_TC_Prod_BU_Program method " + ex.Message);
                throw;
            }
        } // end of test case
    }
}
