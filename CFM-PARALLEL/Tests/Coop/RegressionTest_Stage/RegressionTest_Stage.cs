using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CFM_PARALLEL.Tests.Coop.RegressionTest_Stage
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
   
    public class RegressionTest_Stage: Base
    {
        [Test, Parallelizable] // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_MASCO_Dashboard()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateCorporateUser);
                Pages.MS_Dashboard().DashBoard_Validation();
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_Dashboard TestCase " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_MASCO_Program()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateCorporateUser);
                Pages.MS_Programs().Validate_Programs();
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_Program TestCase " + ex.Message);
                throw;
            }

        } // end of test case



        [Test, Parallelizable] // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_MASCO_Fundsnapshot()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateCorporateUser);
                Pages.MS_Dashboard().FundSnapshot_Validation();
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_Fundsnapshot TestCase " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable]  // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_MASCO_FundRequest_Approve()
        {
            try
            {
                double finalApprovedAmount =  61.88;
                Pages.BrowserURLLaunch().BrowserURL_MASCO("STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateAccountUser2);// Account user 

                double AmountBeforeApproval = Convert.ToDouble(Pages.CommonFunctions().GetAvailableFunds(Parameters.MS_FR_ProgramName));
                Console.WriteLine("Amount before Approval = " + AmountBeforeApproval);

                string FundRequestId = Pages.MS_FundRequest().Create_FundRequest(Parameters.MS_FR_RequestedAmount, Parameters.MS_FR_StoreName, Parameters.MS_FR_ProgramName, true, "STAGE");

                Pages.MS_FundRequest().Process_FundRequest_WorkFlow(Parameters.Masco_EmulateCorporateUser, FundRequestId, "Approve", "62", 1);// Ist Reviewer
                Pages.MS_FundRequest().Process_FundRequest_WorkFlow(Parameters.Masco_EmulateDistrictManager, FundRequestId, "Approve", "60", 2);// 2nd Reviewer
                Pages.MS_FundRequest().Process_FundRequest_WorkFlow(Parameters.Masco_EmulateDirector, FundRequestId, "Approve", "58", 3);// 3rd Reviewer
              //  Pages.MS_FundRequest().Process_FundRequest_WorkFlow(Parameters.Masco_EmulateVP, FundRequestId, "Approve", "5500", 4);// 4th Reviewer
                Pages.MS_FundRequest().Process_FundRequest_WorkFlow(Parameters.Masco_EmulateFinance, FundRequestId, "Approve","61.88", 4);// 5th Reviewer

                Pages.CommonFunctions().ExitEmulation();
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateAccountUser2);// Account user 

                double AmountAfterApproval = Convert.ToDouble(Pages.CommonFunctions().GetAvailableFunds(Parameters.MS_FR_ProgramName));

                Console.WriteLine("Expected Amount  = " + (AmountBeforeApproval + finalApprovedAmount));
                Console.WriteLine("Actual Amount  = " + AmountAfterApproval);
                double ExpectedAmount = AmountBeforeApproval + finalApprovedAmount;
                //Assert.AreEqual(ExpectedAmount, AmountAfterApproval);
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_FundRequest_Approve TestCase " + ex.Message);
                throw;
            }
        } // end of test case

        
        [Test, Parallelizable]  // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_MASCO_FPA_Hold_Approve()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.MS_EmulateDealer2);

                List<double> initialAmountList = Pages.MS_Dashboard().FundCalculation();

                string FPAId1 = Pages.MS_FundPreApproval().Create_FPA("STAGE", Parameters.MS_RequestedAmount); // Create FPA
                List<double> finalAmountList = Pages.MS_Dashboard().FundCalculation();

                double expectedAvailableFund = initialAmountList[0] - Double.Parse(Parameters.MS_RequestedAmount);
                double expectedFrozenFund = initialAmountList[1] + Double.Parse(Parameters.MS_RequestedAmount);

                Assert.AreEqual(expectedAvailableFund, finalAmountList[0]);
                Assert.AreEqual(expectedFrozenFund, finalAmountList[1]);

                string FPAId2 = Pages.MS_FundPreApproval().Clone_FPA(FPAId1); // clone FPA
                Pages.CommonFunctions().ExitEmulation();
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateCorporateUser); // approver

                Pages.MS_FundPreApproval().Review_FPA(FPAId1, "Approve");
                Pages.MS_FundPreApproval().Review_FPA(FPAId2, "Hold");

            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_FPA_HoldAndApprove TestCase " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable]  // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_MASCO_FPA_NeedsChange_Resubmit_Deny()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.MS_EmulateDealer2);// submitter

                List<double> initialAmountList = Pages.MS_Dashboard().FundCalculation();
                string FPAId1 = Pages.MS_FundPreApproval().Create_FPA("STAGE", Parameters.MS_RequestedAmount); // Create FPA
                List<double> finalAmountList = Pages.MS_Dashboard().FundCalculation();

                double expectedAvailableFund = initialAmountList[0] - Double.Parse(Parameters.MS_RequestedAmount);
                double expectedFrozenFund = initialAmountList[1] + Double.Parse(Parameters.MS_RequestedAmount);

                Assert.AreEqual(expectedAvailableFund, finalAmountList[0]);
                Assert.AreEqual(expectedFrozenFund, finalAmountList[1]);

                string FPAId2 = Pages.MS_FundPreApproval().Clone_FPA(FPAId1); // clone FPA
                Pages.CommonFunctions().ExitEmulation();

                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateCorporateUser); // approver               
                Pages.MS_FundPreApproval().Review_FPA(FPAId1, "Needs Change");//needs change   , FPA id 1= Needs Change
                Pages.MS_FundPreApproval().Review_FPA(FPAId2, "Deny");// FPA id 2= Deny
                Pages.CommonFunctions().ExitEmulation();

                Pages.CommonFunctions().EmulateUser(Parameters.MS_EmulateDealer2); 
                Pages.MS_FundPreApproval().Resubmit_FPA(FPAId1);// resubmit  , FPA id 1= Resubmit

            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_FPA_NeedsChange_Resubmit_Deny TestCase " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_NATIONWIDE_Disbursement_And_Payments()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_NATIONWIDE("LME1", "STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.NW_Business_Unit);
                //Pages.CommonFunctions().EmulateUser(Parameters.NW_EmulateUser1); // emulating ist user 
                //Pages.BrowserURLLaunch().Click_CFMLink();
                //string claimid1 = Pages.NW_Claims().NW_Claim_FullFlow(Parameters.NW_Prod_AgencyName1, true);    // creating claim 1 
                //Pages.CommonFunctions().ExitEmulation();

                //Pages.CommonFunctions().EmulateUser(Parameters.NW_EmulateUser2); // emulating 2nd user 
                //Pages.BrowserURLLaunch().Click_CFMLink();
                //string claimid2 = Pages.NW_Claims().NW_Claim_FullFlow(Parameters.NW_Prod_AgencyName2, true);    // creating claim 2
                //Pages.CommonFunctions().ExitEmulation();
                Pages.BrowserURLLaunch().Click_CFMLink();  //  login as admin  

                string claimid1 = "CL-139075";
                string claimid2 = "CL-139074";

                //Pages.NW_Claims().Review_Claim(claimid1, "Approve");
                Pages.NW_Claims().Review_Claim(claimid2, "Approve");

                Pages.ManualDisbursement().Navigate_To_Disbursement_Page();
                string disbursement_id = Pages.NW_Disbursements().CreateNationWideDisbursementWorkflow(claimid1, claimid2);//create Disbursement

                Pages.CommonFunctions().EmulateUser(Parameters.NW_EmulateFirstApprover, true); // emulating user 1
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.NW_Disbursements().ProcessDisbursements(disbursement_id, "Approve");
                Pages.CommonFunctions().ExitEmulation();

                Pages.CommonFunctions().EmulateUser(Parameters.NW_EmulateSecondApprover); // emulating user 2
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.NW_Disbursements().ProcessDisbursements(disbursement_id, "Approve");
                Pages.CommonFunctions().ExitEmulation();

                Pages.BrowserURLLaunch().Click_CFMLink();  // admin
                Pages.NW_Disbursements().ProcessDisbursements(disbursement_id, "Approve");
                Pages.NW_Payments().Validate_EFT_And_PaperCheck(disbursement_id);// papaer check and EFT validation
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in NATIONWIDE_Disbursement_And_Payments Test Case " + ex.Message);
                throw;
            }

        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_MASCO_DisplayClaim_Hold_Approve()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateAccountUser1);
                string DisplayClaimID1 = Pages.MS_DisplayClaims().Create_DisplayClaim(Parameters.MS_DC_StoreName, Parameters.MS_ProgramName);
                string DisplayClaimID2 = Pages.MS_DisplayClaims().Clone_DisplayClaim(DisplayClaimID1); // clone
                Pages.CommonFunctions().ExitEmulation();
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateCorporateUser);
                Pages.MS_DisplayClaims().Review_DisplayClaim(DisplayClaimID1, "Hold"); // Display Claim id 1 = hold
                Pages.MS_DisplayClaims().Review_DisplayClaim(DisplayClaimID2, "Approve"); //  Display Claim id 1 = approve

            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_DisplayClaim_Hold_Approve TestCase " + ex.Message);
                throw;
            }
        } // end of test case


        [Test, Parallelizable] // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_MASCO_DisplayClaim_NeedsChange_Resubmit_Deny()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateAccountUser1);
                string DisplayClaimID1 = Pages.MS_DisplayClaims().Create_DisplayClaim(Parameters.MS_DC_StoreName, Parameters.MS_ProgramName);
                string DisplayClaimID2 = Pages.MS_DisplayClaims().Clone_DisplayClaim(DisplayClaimID1);

                Pages.CommonFunctions().ExitEmulation();
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateCorporateUser);
                Pages.MS_DisplayClaims().Review_DisplayClaim(DisplayClaimID1, "Needs Change"); //  Display Claim id 1 = needs change
                Pages.MS_DisplayClaims().Review_DisplayClaim(DisplayClaimID2, "Deny");// display claim id 2= deny
                Pages.CommonFunctions().ExitEmulation();

                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateAccountUser1);
                Pages.MS_DisplayClaims().Resubmit_DisplayClaim(DisplayClaimID1);//  Display Claim id 1 = resubmit

            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_DisplayClaim_NeedsChange_Resubmit_Approve TestCase " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_MASCO_BPA_Hold_Approve()
        {
            try
            {             
                Pages.BrowserURLLaunch().BrowserURL_MASCO("STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.MS_EmulateDealer2);
                string BPAId1 = Pages.MS_BrandPreApproval().Create_BPA(); // create
                string BPAId2 = Pages.MS_BrandPreApproval().Clone_BPA(BPAId1); // clone
                Pages.CommonFunctions().ExitEmulation();
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateCorporateUser); // approver
                Pages.MS_BrandPreApproval().Review_BPA(BPAId1, "Approve");
                Pages.MS_BrandPreApproval().Review_BPA(BPAId2, "Hold");
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_BrandPreApproval TestCase " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_MASCO_BPA_NeedsChange_Resubmit_Deny()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.MS_EmulateDealer2);
                string BPAId1 = Pages.MS_BrandPreApproval().Create_BPA(); // create
                string BPAId2 = Pages.MS_BrandPreApproval().Clone_BPA(BPAId1); // clone
                Pages.CommonFunctions().ExitEmulation();
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateCorporateUser); // approver
                Pages.MS_BrandPreApproval().Review_BPA(BPAId1, "Needs Change");
                Pages.MS_BrandPreApproval().Review_BPA(BPAId2, "Deny");
                Pages.CommonFunctions().ExitEmulation();
                Pages.CommonFunctions().EmulateUser(Parameters.MS_EmulateDealer2);
                Pages.MS_BrandPreApproval().Resubmit_BPA(BPAId1);

            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_BrandPreApproval TestCase " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_MASCO_Transaction_Accrual()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateCorporateUser);
                Pages.MS_Transaction().Process_Transaction("Accrual");// checking positive accrual under this method
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_Transaction_Accrual Test Case " + ex.Message);
                throw;
            }

        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_MASCO_Transaction_Adjustments()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateCorporateUser);
                Pages.MS_Transaction().Process_Transaction("Adjustments"); // checking negative adujustment under this method
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_Transaction_Adjustments Test Case " + ex.Message);
                throw;
            }

        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_MASCO_Transaction_Transfer()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateCorporateUser);
                Pages.MS_Transaction().Process_Transaction("Transfers");
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_Transaction_Transfer Test Case " + ex.Message);
                throw;
            }

        } // end of test case

        [Test, Parallelizable]  // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_MASCO_Claim_Hold_Approve()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateDealerUser);

                double AmountBeforeApproval = Convert.ToDouble(Pages.CommonFunctions().GetAvailableFunds(Parameters.MS_ProgramName));
                Console.WriteLine("Amount before Approval = " + AmountBeforeApproval);
                string ClaimID = Pages.MS_Claims().Create_Claim(Parameters.MS_RequestedAmount, Parameters.MS_InvoiceNummber);
                Pages.MS_Claims().validate_Claim_ViewDetailed_Report("Open", Parameters.MS_RequestedAmount, ClaimID);// amount and claimID validation

                Pages.CommonFunctions().ExitEmulation();

                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateCorporateUser);
                Pages.MS_Claims().Review_Claim(ClaimID,"Hold");
                Pages.MS_Claims().Review_Claim(ClaimID,"Approve");
                Pages.CommonFunctions().ExitEmulation();

                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateDealerUser);
                double AmountAfterApproval = Convert.ToDouble(Pages.CommonFunctions().GetAvailableFunds(Parameters.MS_ProgramName));// actual amount
                double ExpectedAmount = AmountBeforeApproval - double.Parse(Parameters.MS_RequestedAmount);
                Console.WriteLine("Asserting for exped and actual amount in ST_TC_MASCO_Claim test case");
                Assert.AreEqual(ExpectedAmount, AmountAfterApproval);

                Pages.MS_Claims().validate_Claim_ViewDetailed_Report("Approved",Parameters.MS_RequestedAmount, ClaimID); //amount and claimID validation

            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_Claim method  test case" + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable]  // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_MASCO_ClaimWithBPA()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                Pages.MS_Dashboard().SelectSearchUserFrom_BM_AdminDropdown();
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateDealerUser);
                String bpaID = Pages.MS_FundPreApproval().Get_PreApprovalID("BPA");
                Pages.MS_Claims().Create_Claim(Parameters.MS_RequestedAmount,Parameters.MS_InvoiceNummber,"Y", bpaID); // claim with BPA

            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_ClaimWithBPA method  test case" + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable]  // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_MASCO_ClaimWithFPA()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateDealerUser);
                String FPA_ID = Pages.MS_FundPreApproval().Get_PreApprovalID("FPA");
                Pages.MS_Claims().Create_Claim(Parameters.MS_RequestedAmount, Parameters.MS_InvoiceNummber, "Y", FPA_ID);// Claim with FPA

            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_Claim method  test case" + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable]  // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_ACE_Disbursement_Hold_Deny()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_ACE("InternalUser", "STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown("ACE");
                Pages.CommonFunctions().EmulateUser(Parameters.EmulateACE_CorporateUser);      //Emulate User      
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM LinK

                Pages.ManualDisbursement().Navigate_To_Disbursement_Page();
                String DisbID = Pages.ManualDisbursement().CreateDisbursementWorkflow();
                Pages.CommonFunctions().ExitEmulation();

                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM LinK with internal user
                Pages.ManualDisbursement().Navigate_To_Disbursement_Page();

                Pages.ManualDisbursement().OpenReviewPageWorkFlow(DisbID,true); // passing true flag to validate Claim Status after creating
                Pages.ManualDisbursement().ReviewProcessWorkFlow("Hold", DisbID); // Hold for the Disbursment
                Pages.ManualDisbursement().OpenReviewPageWorkFlow(DisbID);
                Pages.ManualDisbursement().ReviewProcessWorkFlow("Deny", DisbID); // Deny for the Disbursment

            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in ACE_Disbursement_Hold_Deny TestCase " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable]  // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_ACE_Disbursement_NeedsChange_Approve()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_ACE("InternalUser", "STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown("ACE");
                Pages.CommonFunctions().EmulateUser(Parameters.EmulateACE_CorporateUser);      //Emulate User      
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM LinK

                Pages.ManualDisbursement().Navigate_To_Disbursement_Page();
                string DisbID = Pages.ManualDisbursement().CreateDisbursementWorkflow();
                Pages.CommonFunctions().ExitEmulation();

                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM LinK with internal user
                Pages.ManualDisbursement().Navigate_To_Disbursement_Page();
                Pages.ManualDisbursement().OpenReviewPageWorkFlow(DisbID, true); // passing true param to validate Claim Status after creating 
                Pages.ManualDisbursement().ReviewProcessWorkFlow("Needs change", DisbID); // Need change for the Disbursment

                Pages.CommonFunctions().EmulateUser(Parameters.EmulateACE_CorporateUser);      //Emulate User      
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM LinK
                Pages.ManualDisbursement().Navigate_To_Disbursement_Page();
                Pages.ManualDisbursement().ResubmitDisbursementWorkflow(DisbID);//resubmit
                Pages.CommonFunctions().ExitEmulation();
                Pages.BrowserURLLaunch().Click_CFMLink();         //Click CFM LinK with internal user
                Pages.ManualDisbursement().Navigate_To_Disbursement_Page();
                Pages.ManualDisbursement().OpenReviewPageWorkFlow(DisbID); // passing true param to validate Claim Status after creating 

                Pages.ManualDisbursement().ReviewProcessWorkFlow("Approve", DisbID); // Approve for Disbursment
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in ACE_Disbursement_NeedsChange_Approve TestCase " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable]  // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_GEICO_NoAccrualProgram_Claim()
        { string Geico_RequestedAmount = "10";

            try
            {
                Pages.BrowserURLLaunch().BrowserURL_Geico("GFR");
                string TotalSpent_Before = Pages.Geico_Dashboard().Get_TotalSpent_Dashboard().Split('$')[1].Replace(",", "");// calculate total spent amount on dashboard
                Console.WriteLine("Total Spent before Claim creation = " + TotalSpent_Before);
                string ClaimID = Pages.Geico_Claims().Create_Claim();// create claim 
                Driver_CleanUp(); // explicitly called for logout 

                Driver_SetUp(); // explicitly called for open browser
                Pages.BrowserURLLaunch().BrowserURL_Geico("LEAD");// Reviewer1
                Pages.Geico_Claims().Review_Claim(ClaimID, "Approve");
                Driver_CleanUp(); // explicitly called for logout 

                Driver_SetUp(); // explicitly called for open browser
                Pages.BrowserURLLaunch().BrowserURL_Geico("SUPERVISOR");// Reviewer2
                Pages.Geico_Claims().Review_Claim(ClaimID, "Approve");
                Driver_CleanUp(); // explicitly called for logout 

                Driver_SetUp(); // explicitly called for open browser
                Pages.BrowserURLLaunch().BrowserURL_Geico("MANAGEMENT");// Reviewer3
                Pages.Geico_Claims().Review_Claim(ClaimID, "Approve");
                Driver_CleanUp(); // explicitly called for logout 

                Driver_SetUp(); // explicitly called for open browser
                Pages.BrowserURLLaunch().BrowserURL_Geico("GFR");
                string TotalSpent_After = Pages.Geico_Dashboard().Get_TotalSpent_Dashboard().Split('$')[1].Replace(",", "");// calculate total spent amount on dashboard
                Console.WriteLine("Total Spent before Claim creation = " + TotalSpent_Before);

                Assert.AreEqual(TotalSpent_Before + Geico_RequestedAmount, TotalSpent_After);

            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in Geico_NoAccrualProgram_Claim TestCase " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of the test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_BOBCAT_BulkClaim()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_BOBCAT("CORPORATE1", "Bobcat", "STAGE");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.BC_Claim().Create_BulkClaim();
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Error Message with an exception in RT_TC_BobCat_BulkClaim Test Case: " + ex.Message);
                throw;
            }
        }// end of the test case

        [Test, Parallelizable]  // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_ACE_BulkAccrual()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_ACE("InternalUser", "STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown("ACE");
                Pages.CommonFunctions().EmulateUser(Parameters.EmulateACE_CorporateUser);      //Emulate User      
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM LinK
                Pages.Transaction_Accrual().Create_BulkAccrual();
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in RT_TC_ACE_BulkAccrual Test Case " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable]  // begin of test case
        [Category("CFM_REGRESSION_TEST_STAGE")]
        public void RT_TC_ACE_ReverseClaim()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_ACE("InternalUser", "STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown("ACE");
                Pages.CommonFunctions().EmulateUser(Parameters.EmulateACE_LMEUser);      //Emulate User      
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM LinK
                Pages.Claim_FullFlow().Ace_Claim_FullFlow("N", string.Empty, "NO", "STAGE");
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in RT_TC_ACE_ReverseClaim Test Case " + ex.Message);
                throw;
            }
        } // end of test case
    }
}

