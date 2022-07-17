using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.Ace.Claim;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFMAutomation.Common;
using OpenQA.Selenium;
using System;

namespace CFM_PARALLEL.PageObject.UI.Functions.Geico.Claims
{
    public class Geico_Claims
    {
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private OBJ_Common oBJ_Common;
        private Claim_PerformAction obj_claimPerformAction;

        //Constructor
        public Geico_Claims()
        {
            obj_dashboard = new OBJ_Dashboard();
            obj_claims = new OBJ_Claims();
            oBJ_Common = new OBJ_Common();
            obj_claimPerformAction = new Claim_PerformAction();
        }

        public string Create_Claim()
        {
            try
            {
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmitClaim);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmitClaim);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);

                SelectStoreAndProgram_Claim();
                EnterDetails_Claim();
                AddingAttachment_Claim();
                string ClaimID= Submit_Claim();
                return ClaimID;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Create_Claim method:" + ex.Message);
                throw;
            }
        }

        public void SelectStoreAndProgram_Claim()
        {
            try
            {
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitVisible(obj_claims.DdlStoreName);
                Pages.BasicInteractions().Click(obj_claims.DdlStoreName);
                Pages.BasicInteractions().WaitVisible(obj_claims.TxbSearchStoreName);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchStoreName, Parameters.SOB_Name);
                Pages.BasicInteractions().Type(obj_claims.TxbSearchStoreName, Keys.Enter);
                Pages.BasicInteractions().WaitVisible(obj_claims.DdlProgramName);
                Pages.BasicInteractions().Click(obj_claims.DdlProgramName);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchProgramName, Parameters.Geico_ProgramName);
                Pages.BasicInteractions().Type(obj_claims.TxbSearchProgramName, Keys.Enter);

                Pages.BasicInteractions().WaitVisible(obj_claims.BtnNext1);
                Pages.BasicInteractions().Click(obj_claims.BtnNext1);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Message with an exception in SelectStoreAndProgram_Claim method: " + ex.Message);
                throw;

            }
        }

        public void EnterDetails_Claim()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.TxbClaimDescription);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbClaimDescription, "Claim Ref Number-1234");

                Pages.BasicInteractions().WaitVisible(obj_claims.Category_Dropdown);
                Pages.BasicInteractions().Click(obj_claims.Category_Dropdown);
                Pages.BasicInteractions().WaitVisible(obj_claims.Category_Textbox);
                Pages.BasicInteractions().TypeClear(obj_claims.Category_Textbox, "Military");
                Pages.BasicInteractions().Type(obj_claims.Category_Textbox, Keys.Enter);
                Pages.BasicInteractions().WaitTime(2);

                Pages.BasicInteractions().WaitVisible(obj_claims.Geico_MediaType);
                Pages.BasicInteractions().Click(obj_claims.Geico_MediaType);
                Pages.BasicInteractions().WaitVisible(obj_claims.Geico_MediaTypeTextbox);
                Pages.BasicInteractions().TypeClear(obj_claims.Geico_MediaTypeTextbox, "Events");
                Pages.BasicInteractions().Type(obj_claims.Geico_MediaTypeTextbox, Keys.Enter);
                Pages.BasicInteractions().WaitTime(2);

                // claim start date and end date selection
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().TypeClear(obj_claims.Geico_VendorName,"Test");

                Pages.BasicInteractions().TypeClear(obj_claims.ClaimTotalActivityCost, Parameters.Geico_ActivityCost);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().TypeClear(obj_claims.ClaimRequestedAmount, Parameters.Geico_RequestedAmount);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.Geico_NextButton2);
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
                Pages.BasicInteractions().Type(obj_claims.ClaimInvoice, "Claim-13445");
                Pages.BasicInteractions().WaitTime(2);

                Pages.BasicInteractions().WaitVisible(obj_claims.PaymentDate);
                Pages.BasicInteractions().Click(obj_claims.PaymentDate);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.PaymentDateSelection());
                Pages.BasicInteractions().WaitTime(5);



                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimUpload);
                Pages.BasicInteractions().Click(obj_claims.ClaimUpload);
                Pages.BasicInteractions().WaitTime(3);
                //File Upload
                CommonUtilities.UploadFileInChrome("CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimComments);
                Pages.BasicInteractions().Type(obj_claims.ClaimComments, "Claim-Comments");
                Pages.BasicInteractions().WaitVisible(obj_claims.BtnNext3);
                Pages.BasicInteractions().Click(obj_claims.BtnNext3);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message in AddingAttachment_Claim method: " + ex.Message);
                throw;
            }
        }

        public string Submit_Claim()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.BtnSubmit);
                if (Pages.BasicInteractions().IsElementPresent(obj_claims.ChbAknowledgeForDuplicateInvoice))
                {
                    Pages.BasicInteractions().Click(obj_claims.ChbAknowledgeForDuplicateInvoice);
                    Pages.BasicInteractions().WaitTime(5);
                }
                Pages.BasicInteractions().WaitVisible(obj_claims.BtnSubmit);
                Pages.BasicInteractions().Click(obj_claims.BtnSubmit);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(10);
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
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_claims.LeftNavClaim);
                Pages.BasicInteractions().Click(obj_claims.LeftNavClaim);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                Pages.BasicInteractions().WaitTime(10);

                //Simple Search 
                Pages.BasicInteractions().WaitVisible(obj_claims.SimpleSearchTextbox);
                Pages.BasicInteractions().Click(obj_claims.SimpleSearchTextbox);
                Pages.BasicInteractions().Type(obj_claims.SimpleSearchTextbox, ClaimID);
                Pages.BasicInteractions().WaitTime(2);
                 Pages.BasicInteractions().Click(obj_claims.SimpleSearchButton);
                Pages.BasicInteractions().WaitTime(5);
                Console.WriteLine("Search Claim - done successfully");

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
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(oBJ_Common.MoreDetailsLink);
                Pages.BasicInteractions().WaitVisible(obj_claims.ViewReviewButton);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.ViewReviewButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);
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
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().Type(obj_claimPerformAction.ClaimReviewCodeText, Keys.Tab);

                Pages.BasicInteractions().Click(obj_claimPerformAction.ClaimReviewCodeTextSelect);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().Click(obj_claimPerformAction.ClaimSendResponseButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                Pages.BasicInteractions().WaitTime(15);
                Console.WriteLine("Claim Reviewed is done successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Process_Claim method " + ex.Message);
                throw;
            }

        }

    }
}
