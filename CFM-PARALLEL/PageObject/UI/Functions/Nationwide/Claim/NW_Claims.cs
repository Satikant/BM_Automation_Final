using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.Ace.Claim;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFM_PARALLEL.PageObject.UI.Functions.Nationwide
{
   public class NW_Claims
    {      
        private OBJ_Claims obj_claims;
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Common obj_Common;
        private Claim_PerformAction obj_claimPerformAction;

        //Constructor
        public NW_Claims(IWebDriver Driver)
        {
          
            obj_claims = new OBJ_Claims();
            obj_dashboard = new OBJ_Dashboard();
            obj_Common = new OBJ_Common();
            obj_claimPerformAction = new Claim_PerformAction();
        }


        //Claim Full flow Validation 
        public String NW_Claim_FullFlow(String agencyName,Boolean isSubmitFlow=false)
        {
            String claimID = null;
            try
            {
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmitClaim);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmitClaim);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                FillClaimDetails(Parameters.NW_ClaimTotalActivityCost, Parameters.NW_ClaimRequestedAmount, agencyName);

                Pages.BasicInteractions().IsElementDisplayed(obj_claims.BtnSubmit);
                Console.WriteLine("Submit Button Available");
                if (isSubmitFlow)
                {
                    Pages.BasicInteractions().Click(obj_claims.BtnSubmit);
                    Pages.BasicInteractions().WaitUntilElementVisible(obj_claims.ClaimIDGeneratedSuccessMessage,240);
                    claimID = Pages.BasicInteractions().GetText(obj_claims.ClaimIDGeneratedSuccessMessage).Trim().Split(' ')[0];
                }
                return claimID;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message in Claim_FullFlow_Validation method : " + ex.Message);
                throw;
            }
        }

        public void FillClaimDetails(string TotalActivityCost, string RequestedAmount,String agencyName)
        {
            try
            {
                //Select store and Program
                SelectStoreAndProgram_Claim(agencyName);

                //Entering Details
                 EnterDetails_Claim(TotalActivityCost,RequestedAmount);

                //Adding Attachment
                AddingAttachment_Claim();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void SelectStoreAndProgram_Claim(String agencyName)
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.DdlStoreName);
                Pages.BasicInteractions().Click(obj_claims.DdlStoreName);
                Pages.BasicInteractions().WaitVisible(obj_claims.TxbSearchStoreName);
                if (BrowserURLLaunch.EXECUTIONENVIRONMENT.ToUpper() == "PROD".ToUpper() || BrowserURLLaunch.EXECUTIONENVIRONMENT.ToUpper() == "STAGE".ToUpper())
                {
                    Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchStoreName, agencyName);
                    Pages.BasicInteractions().Type(obj_claims.TxbSearchStoreName, Keys.Enter);

                    Pages.BasicInteractions().WaitVisible(obj_claims.DdlProgramName);
                    Pages.BasicInteractions().Click(obj_claims.DdlProgramName);
                    Pages.BasicInteractions().WaitTime(2);
                    Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchProgramName, Parameters.NW_Prod_ProgramName);
                    Pages.BasicInteractions().Type(obj_claims.TxbSearchProgramName, Keys.Enter);
                }
                else
                {
                    Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchStoreName, Parameters.NW_StoreName);
                    Pages.BasicInteractions().Type(obj_claims.TxbSearchStoreName, Keys.Enter);

                    Pages.BasicInteractions().WaitVisible(obj_claims.DdlProgramName);
                    Pages.BasicInteractions().Click(obj_claims.DdlProgramName);
                    Pages.BasicInteractions().WaitTime(2);
                    Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchProgramName, Parameters.NW_ProgramName);
                    Pages.BasicInteractions().Type(obj_claims.TxbSearchProgramName, Keys.Enter);
                }
                Pages.BasicInteractions().WaitVisible(obj_claims.BtnNext1);
                Pages.BasicInteractions().Click(obj_claims.BtnNext1);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message in SelectStoreAndProgram_Claim method : " + ex.Message);
                throw;
            }
        }
        public void EnterDetails_Claim(string TotalActivityCost, string RequestedAmount)
        {            
            try
            {
                Pages.BasicInteractions().WaitUntilElementVisible(obj_claims.TxbClaimDescription,120);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbClaimDescription, "Claim Ref No 1234");

                Pages.BasicInteractions().WaitVisible(obj_claims.ActivityCategory);
                Pages.BasicInteractions().Click(obj_claims.ActivityCategory);
                Pages.BasicInteractions().WaitVisible(obj_claims.ActivityCategoryTextbox);
                Pages.BasicInteractions().Type(obj_claims.ActivityCategoryTextbox, Parameters.NW_ActivityCategory);
                Pages.BasicInteractions().Type(obj_claims.ActivityCategoryTextbox, Keys.Enter);
                Pages.BasicInteractions().WaitTime(2);

                Pages.BasicInteractions().WaitVisible(obj_claims.ActivityType);
                Pages.BasicInteractions().Click(obj_claims.ActivityType);
                Pages.BasicInteractions().WaitVisible(obj_claims.ActivityTypeTextbox);
                Pages.BasicInteractions().Type(obj_claims.ActivityTypeTextbox, Parameters.NW_ActivityType);
                Pages.BasicInteractions().Type(obj_claims.ActivityTypeTextbox, Keys.Enter);
                Pages.BasicInteractions().WaitTime(2);

                Pages.BasicInteractions().WaitVisible(obj_claims.ProductType);
                Pages.BasicInteractions().Click(obj_claims.ProductType);
                Pages.BasicInteractions().WaitVisible(obj_claims.ProductTypeTextbox);
                Pages.BasicInteractions().Type(obj_claims.ProductTypeTextbox, Parameters.NW_ProductType);
                Pages.BasicInteractions().Type(obj_claims.ProductTypeTextbox, Keys.Enter);
                                
                // claim start date and end date selection
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));

                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
               
                Pages.BasicInteractions().TypeClear(obj_claims.ClaimTotalActivityCost, TotalActivityCost);
                Pages.BasicInteractions().WaitTime(1);

                Pages.BasicInteractions().TypeClear(obj_claims.ClaimRequestedAmount, RequestedAmount);
                Pages.BasicInteractions().WaitVisible(obj_claims.BtnNext2);
                Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message in EnterDetails_Claim method: " + ex.Message);
                throw;
            }
        }

        public void AddingAttachment_Claim()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimComments);
                Pages.BasicInteractions().Type(obj_claims.ClaimInvoice, "Claim-13445");
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimUpload);

                //File Upload
                CommonUtilities.UploadFile(obj_Common.FileUploadInput, "CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                Pages.BasicInteractions().WaitUntilElementVisible(obj_claims.FileUploadedSuccessfully, 120);
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimComments);
                Pages.BasicInteractions().Type(obj_claims.ClaimComments, "Claim-Comments");
                Pages.BasicInteractions().WaitVisible(obj_claims.BtnNext3);

                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().Click(obj_claims.BtnNext3);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message in AddingAttachment_Claim method: " + ex.Message);
                throw;
            }
        }

        public void Validate_Claims()
        {                    
            Pages.Dashboard_Landing().ClickParticularValueSection("CLAIMS");
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            Pages.Dashboard_Landing().ValidatePageHeadSectionValues("Pending");
            Pages.Dashboard_Landing().ValidatePageHeadSectionValues("InProcess");
            Pages.Dashboard_Landing().ValidatePageHeadSectionValues("Completed");
            Pages.Dashboard_Landing().ValidatePageHeadSectionValues("Declined");

            Pages.BasicInteractions().Click(Pages.Dashboard_Landing().InProcessStatusTabs);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

            Pages.BasicInteractions().Click(Pages.Dashboard_Landing().DeclinedStatusTabs);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

            Pages.BasicInteractions().Click(Pages.Dashboard_Landing().PendingStatusTabs);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

            Pages.BasicInteractions().Click(Pages.Dashboard_Landing().CompletedStatusTabs);
            Pages.BasicInteractions().WaitUntilElementVisible(obj_Common.MoreDetailsLink, 120);
            Pages.BasicInteractions().Click(obj_Common.MoreDetailsLink);
            Pages.BasicInteractions().WaitUntilElementVisible(obj_Common.AuditTrailLink, 120);
            Pages.BasicInteractions().Click(obj_Common.AuditTrailLink);
            Pages.BasicInteractions().WaitUntilElementVisible(obj_Common.AuditHistoryLabel,120);
            Assert.AreEqual(true, Pages.BasicInteractions().IsElementDisplayed(obj_Common.AuditHistoryLabel));
            Pages.BasicInteractions().Click(obj_Common.CloseButton);
            Pages.BasicInteractions().WaitUntilElementVisible(obj_Common.ClaimDetailsPageStatus, 120);
            string ExpectedStatus = Pages.BasicInteractions().GetText(obj_Common.ClaimDetailsPageStatus);
            Pages.BasicInteractions().Click(obj_Common.ViewButton);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            Pages.BasicInteractions().WaitUntilElementVisible(obj_claims.ClaimStatusOnClaimReviewPage,120);
            string ActualStatus = Pages.BasicInteractions().GetText(obj_claims.ClaimStatusOnClaimReviewPage);
            Assert.AreEqual(ExpectedStatus, ActualStatus);
        }

        //Claim review 
        public void Review_Claim(String ClaimID, String Action)
        {
            try
            {
                Search_Claim(ClaimID);
                Process_Claim(Action);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Review_Claim method" + ex.Message);
                throw;
            }
        }

        public void Search_Claim(String ClaimID)
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.LeftNavClaim);
                Pages.BasicInteractions().Click(obj_claims.LeftNavClaim);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                //Simple Search 
                Pages.BasicInteractions().WaitVisible(obj_claims.SimpleSearchTextbox);
                Pages.BasicInteractions().Click(obj_claims.SimpleSearchTextbox);
                Pages.BasicInteractions().Type(obj_claims.SimpleSearchTextbox, ClaimID);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_claims.SimpleSearchButton);
                Pages.BasicInteractions().WaitTime(5);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Search_Claim method " + ex.Message);
                throw;
            }
        }

        public void Process_Claim(string Action)
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_Common.MoreDetailsLink);
                Pages.BasicInteractions().Click(obj_Common.MoreDetailsLink);
                Pages.BasicInteractions().WaitTime(3);

                Pages.BasicInteractions().WaitVisible(obj_claims.ViewReviewButton);
                Pages.BasicInteractions().Click(obj_claims.ViewReviewButton);
                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().WaitVisible(obj_claimPerformAction.ClaimResponseDropdown);
                Pages.BasicInteractions().Click(obj_claimPerformAction.ClaimResponseDropdown);
                Pages.BasicInteractions().Click(obj_claimPerformAction.ClaimResponse(Action));
                if (Action.Equals("Approve"))
                {
                    Pages.BasicInteractions().Clear(obj_claimPerformAction.ClaimApprovedAmount);
                    Pages.BasicInteractions().Type(obj_claimPerformAction.ClaimApprovedAmount, "10");
                }
                Pages.BasicInteractions().WaitVisible(obj_claimPerformAction.ClaimSendResponseButton);
                Pages.BasicInteractions().Click(obj_claimPerformAction.ClaimReviewCodeDropdown);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Type(obj_claimPerformAction.ClaimReviewCodeText, Keys.Tab);

                Pages.BasicInteractions().Click(obj_claimPerformAction.ClaimReviewCodeTextSelect);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_claimPerformAction.ClaimSendResponseButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Process_Claim method " + ex.Message);
                throw;
            }
        }
    }
}
