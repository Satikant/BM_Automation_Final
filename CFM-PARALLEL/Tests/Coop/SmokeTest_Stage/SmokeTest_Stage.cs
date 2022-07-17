using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using System;

namespace CFM_PARALLEL.Tests.Coop.SmokeTest_Stage
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]

    public class SmokeTest_Stage: Base
    {
        [Test, Parallelizable] // begin of test case
        [Category("CFM_SMOKE_TEST_STAGE")]

        public void ST_TC_MASCO_Dashboard()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                // Pages.MS_Dashboard().SelectSearchUserFrom_BM_AdminDropdown();
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateCorporateUser);
                Pages.MS_Dashboard().DashBoard_Validation();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception in MASCO_Dashboard TestCase " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_SMOKE_TEST_STAGE")]
        public void ST_TC_MASCO_Program()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                //Pages.MS_Dashboard().SelectSearchUserFrom_BM_AdminDropdown();
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateCorporateUser);
                Pages.MS_Programs().Validate_Programs();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in MASCO_Program TestCase " + ex.Message);
                throw;
            }

        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_SMOKE_TEST_STAGE")]
        public void ST_TC_MASCO_Fundsnapshot()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                // Pages.MS_Dashboard().SelectSearchUserFrom_BM_AdminDropdown();
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateCorporateUser);
                Pages.MS_Dashboard().FundSnapshot_Validation();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in MASCO_Fundsnapshot TestCase " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable]  // begin of test case
        [Category("CFM_SMOKE_TEST_STAGE")]
        public void ST_TC_ACE_BulkAccrual()
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
                Console.WriteLine("Exception in ST_TC_ACE_BulkAccrual Test Case " + ex.Message);
                throw;
            }

        } // end of test case

        [Test, Parallelizable]  // begin of test case
        [Category("CFM_SMOKE_TEST_STAGE")]
        public void ST_TC_ACE_Disbursement()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_ACE("InternalUser", "STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown("ACE");
                Pages.CommonFunctions().EmulateUser(Parameters.EmulateACE_CorporateUser);      //Emulate User      
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM LinK

                Pages.ManualDisbursement().Navigate_To_Disbursement_Page();
               String DisbId= Pages.ManualDisbursement().CreateDisbursementWorkflow();// create disbursement
                Pages.ManualDisbursement().OpenReviewPageWorkFlow(DisbId,true); // passing true flag to validate Claim Status after creating
                Pages.ManualDisbursement().ReviewProcessWorkFlow("Approve", DisbId); // Deny for the Disbursment
                Pages.ManualDisbursement().OpenReviewPageWorkFlow(DisbId, true); // passing true flag to validate Claim Status after approved
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in ST_TC_ACE_Disbursement TestCase " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of the test case
        [Category("CFM_SMOKE_TEST_STAGE")]
        public void ST_TC_BobCat_BulkClaim()
        {
            try
            {     
                Pages.BrowserURLLaunch().BrowserURL_BOBCAT("CORPORATE1", "Bobcat", "STAGE");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.BC_Claim().Create_BulkClaim();

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error Message with an exception in ST_TC_BobCat_BulkClaim Test Case: " + ex.Message);
                throw;
            }
        }// end of the test case

        [Test, Parallelizable]  // begin of test case
        [Category("CFM_SMOKE_TEST_STAGE")]
        public void ST_TC_MASCO_FundRequest()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                //Pages.MS_Dashboard().SelectSearchUserFrom_BM_AdminDropdown();
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateAccountUser2);// Account user 
                string FundRequestId = Pages.MS_FundRequest().Create_FundRequest(Parameters.MS_FR_RequestedAmount, Parameters.MS_FR_StoreName, Parameters.MS_FR_ProgramName, true, "STAGE");

;               Pages.MS_FundRequest().Process_FundRequest_WorkFlow(Parameters.Masco_EmulateCorporateUser, FundRequestId, "Approve", "62", 1);// Ist Reviewer
                Pages.MS_FundRequest().Process_FundRequest_WorkFlow(Parameters.Masco_EmulateDistrictManager, FundRequestId, "Approve", "60", 2);// 2nd Reviewer
                Pages.MS_FundRequest().Process_FundRequest_WorkFlow(Parameters.Masco_EmulateDirector, FundRequestId, "Approve", "58", 3);// 3rd Reviewer
                //Pages.MS_FundRequest().Process_FundRequest_WorkFlow(Parameters.Masco_EmulateVP, FundRequestId, "Approve", "5500", 4);// 4th Reviewer
                Pages.MS_FundRequest().Process_FundRequest_WorkFlow(Parameters.Masco_EmulateFinance, FundRequestId, "Approve", "61.88", 4);// 5th Reviewer
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in ST_TC_MASCO_FundRequest Test Case " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_SMOKE_TEST_STAGE")]
        public void ST_TC_NATIONWIDE_Disbursement_And_Payments()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_NATIONWIDE("LME1", "STAGE");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.NW_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.NW_EmulateUser1); // emulating ist user 
                Pages.BrowserURLLaunch().Click_CFMLink();
                string claimid1 = Pages.NW_Claims().NW_Claim_FullFlow(Parameters.NW_Prod_AgencyName1, true);    // creating claim 1 
                Pages.CommonFunctions().ExitEmulation();

                Pages.CommonFunctions().EmulateUser(Parameters.NW_EmulateUser2); // emulating 2nd user 
                Pages.BrowserURLLaunch().Click_CFMLink();
                string claimid2 = Pages.NW_Claims().NW_Claim_FullFlow(Parameters.NW_Prod_AgencyName2, true);    // creating claim 2
                Pages.CommonFunctions().ExitEmulation();

                Pages.BrowserURLLaunch().Click_CFMLink();  //  login as admin        
                Pages.NW_Claims().Review_Claim(claimid1, "Approve");
                Pages.NW_Claims().Review_Claim(claimid2, "Approve");

                Pages.ManualDisbursement().Navigate_To_Disbursement_Page();
                String disbursement_id = Pages.NW_Disbursements().CreateNationWideDisbursementWorkflow(claimid1, claimid2);

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
                Pages.NW_Payments().Validate_EFT_And_PaperCheck(disbursement_id);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in ST_TC_NATIONWIDE_Disbursement_And_Payments Test Case " + ex.Message);
                throw;
            }

        } // end of test case


    }
}
