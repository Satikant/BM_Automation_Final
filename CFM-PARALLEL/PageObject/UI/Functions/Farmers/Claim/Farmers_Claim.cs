using System;
using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.Ace.Claim;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Transactions;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;

namespace CFM_PARALLEL.PageObject.UI.Functions.Farmers.Claim
{
    public class Farmers_Claim
    {
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private OBJ_Common oBJ_Common;
        private Claim_PerformAction obj_claimPerformAction;

        public Farmers_Claim()
        {
            obj_dashboard = new OBJ_Dashboard();
            obj_claims = new OBJ_Claims();
            oBJ_Common = new OBJ_Common();
            obj_claimPerformAction = new Claim_PerformAction();
        }

        public string Create_Claim(string RequestedAmount)
        {
            try
            {

                Masco_Claim_Fullflow(RequestedAmount);
                string ClaimID = Submit_Claim();
                return ClaimID;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Create_Claim method" + ex.Message);
                throw;
            }
            

        }

        public void Masco_Claim_Fullflow(string RequestedAmount)
        {
            try
            {
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmitFundingRequest);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmitFundingRequest);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                SelectStoreAndProgram_Claim();
                
                EnterDetails_Claim(RequestedAmount);

                //Adding Attachment
                AddingAttachment_Claim();

                Assert.True(Pages.BasicInteractions().IsElementDisplayed(obj_claims.FR_Submit));
                Console.WriteLine("Submit Button Available");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }


        public void SelectStoreAndProgram_Claim()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.MarketingStore);
                Pages.BasicInteractions().Click(obj_claims.MarketingStore);
                Pages.BasicInteractions().WaitVisible(obj_claims.CommunityEngagement);
                Pages.BasicInteractions().Click(obj_claims.CommunityEngagement);

                Pages.BasicInteractions().WaitVisible(obj_claims.AdBuilder);
                Pages.BasicInteractions().Click(obj_claims.AdBuilder);
                Pages.BasicInteractions().WaitVisible(obj_claims.AgentName);
                // Pages.BasicInteractions().Click(obj_claims.AgentName);

                Pages.BasicInteractions().WaitVisible(obj_claims.FundingType);
                Pages.BasicInteractions().Click(obj_claims.FundingType);
                Pages.BasicInteractions().TypeClear(obj_claims.FundingTypeTextBox, Parameters.Farmers_ProgramName);
                Pages.BasicInteractions().Type(obj_claims.FundingTypeTextBox, Keys.Enter);
                Pages.BasicInteractions().WaitVisible(obj_claims.FR_NextButton1);
                Pages.BasicInteractions().Click(obj_claims.FR_NextButton1);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in SelectStoreAndProgram_Claim method: " + ex.Message);
                throw;
            }
        }


        public void EnterDetails_Claim(string RequestedAmount)
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimRequestedAmount);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbClaimDescription, "Claim Ref Number-1234");

                Pages.BasicInteractions().WaitVisible(obj_claims.FR_ActivityType);
                Pages.BasicInteractions().Click(obj_claims.FR_ActivityType);
                Pages.BasicInteractions().WaitVisible(obj_claims.FR_ActivityTypeTextBox);
                Pages.BasicInteractions().TypeClear(obj_claims.FR_ActivityTypeTextBox, "BRANDED ITEMS");
                Pages.BasicInteractions().Type(obj_claims.FR_ActivityTypeTextBox, Keys.Enter);            

                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));

                //Element not visible
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));

                Pages.BasicInteractions().TypeClear(obj_claims.ClaimVendorName, "Test");

                // Eligible Amount
                Pages.BasicInteractions().WaitVisible(obj_claims.FR_ActivityCost);
                Pages.BasicInteractions().TypeClear(obj_claims.FR_ActivityCost, Parameters.Farmers_ActivityCost);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().TypeClear(obj_claims.ClaimRequestedAmount, RequestedAmount);
                Pages.BasicInteractions().Click(obj_claims.FR_NextButton2);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in EnterDetails_Claim method: " + ex.Message);
                throw;
            }
        }


        public void AddingAttachment_Claim()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimComments);
                Pages.BasicInteractions().WaitVisible(obj_claims.FR_ClaimUpload);

                //File Upload
                CommonUtilities.UploadFile(oBJ_Common.FileUploadInput, "CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                Pages.BasicInteractions().WaitUntilElementVisible(obj_claims.FileUploadedSuccessfully, 120);
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimComments);
                Pages.BasicInteractions().Type(obj_claims.ClaimComments, "Claim-Comments");
                Pages.BasicInteractions().WaitUntilElementVisible(obj_claims.FR_NextButton3, 120);
                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().Click(obj_claims.FR_NextButton3);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in AddingAttachment_Claim method: " + ex.Message);
                throw;
            }
        }

        public string Submit_Claim()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.FR_Submit);
                if (Pages.BasicInteractions().IsElementPresent(obj_claims.ChbAknowledgeForDuplicateInvoice))
                {
                    Pages.BasicInteractions().Click(obj_claims.ChbAknowledgeForDuplicateInvoice);
                    Pages.BasicInteractions().WaitTime(5);
                }
                Pages.BasicInteractions().WaitVisible(obj_claims.FR_Submit);
                Pages.BasicInteractions().Click(obj_claims.FR_Submit);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimSuccessfulMessage);
                Console.WriteLine(Pages.BasicInteractions().GetText(obj_claims.ClaimSuccessfulMessage));
                string str = Pages.BasicInteractions().GetText(obj_claims.ClaimSuccessfulMessage);
                string[] str1 = str.Split(' ');
                Console.WriteLine(str1[0]);
                return str1[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Submit_Claim method:" + ex.Message);
                throw;
            }
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
                Pages.BasicInteractions().Click(obj_claims.FR_SimpleSearch);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
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
                Pages.BasicInteractions().WaitVisible(oBJ_Common.MoreDetailsLink);
                Pages.BasicInteractions().Click(oBJ_Common.MoreDetailsLink);

                Pages.BasicInteractions().WaitVisible(obj_claims.ViewReviewButton);
                Pages.BasicInteractions().Click(obj_claims.ViewReviewButton);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitVisible(obj_claimPerformAction.ClaimResponseDropdown);
                Pages.BasicInteractions().Click(obj_claimPerformAction.ClaimResponseDropdown);
                Pages.BasicInteractions().Click(obj_claimPerformAction.ClaimResponse(Action));
                if (Action.Equals("Approve"))
                {
                    Pages.BasicInteractions().Clear(obj_claimPerformAction.ClaimApprovedAmount);
                    Pages.BasicInteractions().Type(obj_claimPerformAction.ClaimApprovedAmount, "10.99");
                }
                Pages.BasicInteractions().WaitVisible(obj_claimPerformAction.ClaimSendResponseButton);
                Pages.BasicInteractions().Click(obj_claimPerformAction.ClaimReviewCodeDropdown);
                Pages.BasicInteractions().Type(obj_claimPerformAction.ClaimReviewCodeText, Keys.Tab);
                Pages.BasicInteractions().Click(obj_claimPerformAction.ClaimReviewCodeTextSelect);

                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_claimPerformAction.ClaimReviewCodeDropdown);
                Pages.BasicInteractions().WaitTime(2);

                //if (Action.Equals("Approve"))
                //{
                //    Pages.BasicInteractions().WaitVisible(obj_claimPerformAction.CostCenterTextbox);
                //    Pages.BasicInteractions().Click(obj_claimPerformAction.CostCenterTextbox);
                //    Pages.BasicInteractions().Type(obj_claimPerformAction.CostCenterTextbox,"Test@123_CostCenter");
                //}

                Pages.BasicInteractions().WaitVisible(obj_claimPerformAction.ClaimSendResponseButton);
                Pages.BasicInteractions().Click(obj_claimPerformAction.ClaimSendResponseButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Process_Claim method " + ex.Message);
                throw;
            }
        }


    }
}



