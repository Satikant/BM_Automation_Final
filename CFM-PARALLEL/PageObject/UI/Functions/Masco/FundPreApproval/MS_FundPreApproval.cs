using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.Ace.Claim;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Pre_Approvals;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace CFM_PARALLEL.PageObject.UI.Functions.Masco.FundPreApproval
{
    public class MS_FundPreApproval
    {
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private OBJ_PreApprovals obj_PreApprovals;
        private Claim_PerformAction obj_claimPerformAction;
        private OBJ_Common oBJ_Common;

        //Constructor
        public MS_FundPreApproval()
        {
            obj_dashboard = new OBJ_Dashboard();
            obj_claims = new OBJ_Claims();
            obj_PreApprovals = new OBJ_PreApprovals();
            obj_claimPerformAction = new Claim_PerformAction();
            oBJ_Common = new OBJ_Common();
        }

        public void FPA_FullFlow_Validation(String Env, string RequestedAmount)
        {
            try
            {
                //Navigating to Fund Submit PreApproval Screen
                Pages.BasicInteractions().WaitUntilElementVisible(obj_dashboard.BtnSubmit,240);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.SubmiFundPreapproval);
                Pages.BasicInteractions().Click(obj_dashboard.SubmiFundPreapproval);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                //Entering Details for FPA
                FPA_Fill_Form_Details_WorkFlow(Env,RequestedAmount);

                //Adding Attachment
                AddingAttachment();

                //Checking Submit Button Visibility
                Assert.True(Pages.BasicInteractions().IsElementDisplayed(obj_PreApprovals.SubmitButton1));
                Console.WriteLine("User Able to Pass Fund Pre Approval Values till Submit Button: PASSED");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in FPA_FullFlow_Validation method: " + ex.Message);
                throw;
            }
        }

        public void FPA_Fill_Form_Details_WorkFlow(string Env, string RequestedAmount)
        {
            try
            {
                //Entering Details for FPA

                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.FPA_Store);
                Pages.BasicInteractions().Click(obj_PreApprovals.FPA_Store);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.FPA_StoreTextbox);

                if (Env.Equals("PROD"))
                {

                    Pages.BasicInteractions().TypeClear(obj_PreApprovals.FPA_StoreTextbox, Parameters.MS_StoreName2);
                    Pages.BasicInteractions().Type(obj_PreApprovals.FPA_StoreTextbox, Keys.Enter);
                    Pages.BasicInteractions().WaitTime(3);
                }
                else if (Env.Equals("STAGE"))
                {

                    Pages.BasicInteractions().TypeClear(obj_PreApprovals.FPA_StoreTextbox, Parameters.MS_stage_StoreName);
                    Pages.BasicInteractions().Type(obj_PreApprovals.FPA_StoreTextbox, Keys.Enter);
                    Pages.BasicInteractions().WaitTime(3);
                }

                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.FPA_Program);
                Pages.BasicInteractions().Click(obj_PreApprovals.FPA_Program);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.FPA_ProgramTextbox);
                Pages.BasicInteractions().TypeClear(obj_PreApprovals.FPA_ProgramTextbox, Parameters.MS_ProgramName);
                Pages.BasicInteractions().Type(obj_PreApprovals.FPA_ProgramTextbox, Keys.Enter);

                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.FPA_NextButton1);
                Pages.BasicInteractions().Click(obj_PreApprovals.FPA_NextButton1);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.PreApprovalReferenceTextbox);
                Pages.BasicInteractions().Click(obj_PreApprovals.PreApprovalReferenceTextbox);
                Pages.BasicInteractions().TypeClear(obj_PreApprovals.PreApprovalReferenceTextbox, "Test123");
                Pages.BasicInteractions().WaitTime(2);

                Pages.BasicInteractions().Click(obj_PreApprovals.BrandName);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.BrandNameTextbox);
                if (Env.Equals("PROD"))
                {
                    Pages.BasicInteractions().TypeClear(obj_PreApprovals.BrandNameTextbox, "KraftMaid");
                    Pages.BasicInteractions().Type(obj_PreApprovals.BrandNameTextbox, Keys.Enter);
                    Pages.BasicInteractions().WaitTime(2);
                }
                else
                {
                    Pages.BasicInteractions().TypeClear(obj_PreApprovals.BrandNameTextbox, "KraftMaid");
                    Pages.BasicInteractions().Type(obj_PreApprovals.BrandNameTextbox, Keys.Enter);
                    Pages.BasicInteractions().WaitTime(2);
                }

                Pages.BasicInteractions().Click(obj_PreApprovals.AccountNumber);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.AccountNumberTextbox);

                if (Env.Equals("PROD"))
                {
                    Pages.BasicInteractions().TypeClear(obj_PreApprovals.AccountNumberTextbox, "3147");
                    Pages.BasicInteractions().Type(obj_PreApprovals.AccountNumberTextbox, Keys.Enter);
                    Pages.BasicInteractions().WaitTime(2);
                }
                else if (Env.Equals("STAGE"))
                {
                    Pages.BasicInteractions().TypeClear(obj_PreApprovals.AccountNumberTextbox, "13412");
                    Pages.BasicInteractions().Type(obj_PreApprovals.AccountNumberTextbox, Keys.Enter);
                    Pages.BasicInteractions().WaitTime(2);
                }

                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.BPA_MediaType);
                Pages.BasicInteractions().Click(obj_PreApprovals.BPA_MediaType);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.BPA_MediaTypeTextbox);
                Pages.BasicInteractions().TypeClear(obj_PreApprovals.BPA_MediaTypeTextbox, "Advertising");
                Pages.BasicInteractions().Type(obj_PreApprovals.BPA_MediaTypeTextbox, Keys.Enter);

                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.BPA_ActivityType);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_PreApprovals.BPA_ActivityType);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.BPA_ActivityTypeTextbox);
                Pages.BasicInteractions().TypeClear(obj_PreApprovals.BPA_ActivityTypeTextbox, "Templates");
                Pages.BasicInteractions().Type(obj_PreApprovals.BPA_ActivityTypeTextbox, Keys.Enter);

                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.FPA_StartDate);
                Pages.BasicInteractions().Click(obj_PreApprovals.FPA_StartDate);
                Pages.BasicInteractions().Click(obj_PreApprovals.BPAStartDateSelection(DateSelection.Ace_DateSelection_bpaStartDate()));
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.FPA_EndDate);
                Pages.BasicInteractions().Click(obj_PreApprovals.FPA_EndDate);
                Pages.BasicInteractions().Click(obj_PreApprovals.BPAEndDateSelection(DateSelection.Ace_DateSelection_bpaEndDate()));
                Pages.BasicInteractions().WaitTime(2);

                // Eligible Amount
                Pages.BasicInteractions().TypeClear(obj_PreApprovals.FPA_TotalActivityCost, Parameters.MS_TotalActivityCost);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().TypeClear(obj_PreApprovals.FPA_RequestedAmount, RequestedAmount);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.FPA_NextButton2);

                Pages.BasicInteractions().Click(obj_PreApprovals.FPA_NextButton2);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in FPAEnterDetails method: " + ex.Message);
                throw;
            }
        }

        public void AddingAttachment()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.Comment);

                //File Upload                
                CommonUtilities.UploadFile(oBJ_Common.FileUploadInput,"CoOpGuidelines_LCP_2018_Q1_R6.pdf");

                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.Comment);
                Pages.BasicInteractions().Type(obj_PreApprovals.Comment, "FPA-Comments");
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.FPA_NextButton3);
                Pages.BasicInteractions().Click(obj_PreApprovals.FPA_NextButton3);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.SubmitButton1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in AddingAttachment method: " + ex.Message);
                throw;
            }
        }

        public void Select_AccountNumber(string Env)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                if (Env == "STAGE")
                {

                    Pages.BasicInteractions().Click(obj_PreApprovals.AccountNumber);
                    Pages.BasicInteractions().WaitVisible(obj_PreApprovals.AccountNumberTextbox);
                    Pages.BasicInteractions().TypeClear(obj_PreApprovals.AccountNumberTextbox, "254532");
                    Pages.BasicInteractions().Type(obj_PreApprovals.AccountNumberTextbox, Keys.Enter);
                    Pages.BasicInteractions().WaitTime(2);
                }
                else
                {
                    Pages.BasicInteractions().Click(obj_PreApprovals.AccountNumber);
                    Pages.BasicInteractions().WaitVisible(obj_PreApprovals.AccountNumberTextbox);
                    Pages.BasicInteractions().TypeClear(obj_PreApprovals.AccountNumberTextbox, "100055912");
                    Pages.BasicInteractions().Type(obj_PreApprovals.AccountNumberTextbox, Keys.Enter);
                    Pages.BasicInteractions().WaitTime(2);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Select_StoreOrAgencyName method :" + ex.Message);
                throw;
            }
        }

        public string Create_FPA(String Env, string RequestedAmount)
        {
            String FPAId = null;
            try
            {
                //Navigating to Fund Submit PreApproval Screen
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.SubmiFundPreapproval);
                Pages.BasicInteractions().Click(obj_dashboard.SubmiFundPreapproval);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                //Entering Details for FPA
                FPA_Fill_Form_Details_WorkFlow(Env, RequestedAmount);

                //Adding Attachment
                AddingAttachment();

                Assert.True(Pages.BasicInteractions().IsElementDisplayed(obj_PreApprovals.SubmitButton1));
                Pages.BasicInteractions().Click(obj_PreApprovals.SubmitButton1);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.FPA_SuccessMessage);
                Console.WriteLine(Pages.BasicInteractions().GetText(obj_PreApprovals.FPA_SuccessMessage));
                FPAId = Pages.BasicInteractions().GetText(obj_PreApprovals.FPA_SuccessMessage).Trim().Split(' ')[0];
                return FPAId;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Create_FPA method: " + ex.Message);
                throw;
            }
        }

        public string Clone_FPA(string FPAId)
        {

            try
            {
                Search_FPA(FPAId);

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_PreApprovals.FirstRow_FPAId_Link);
                Pages.BasicInteractions().WaitTillNotVisible(obj_PreApprovals.ImgLoading);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.CloneButton);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().Click(obj_PreApprovals.CloneButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_PreApprovals.ImgLoading);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.FPA_NextButton2);
                Pages.BasicInteractions().Click(obj_PreApprovals.FPA_NextButton2);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitTime(5);
                //Adding Attachment
                AddingAttachment();
                Assert.True(Pages.BasicInteractions().IsElementDisplayed(obj_PreApprovals.SubmitButton1));
                Pages.BasicInteractions().Click(obj_PreApprovals.SubmitButton1);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.FPA_SuccessMessage);
                Console.WriteLine(Pages.BasicInteractions().GetText(obj_PreApprovals.FPA_SuccessMessage));
                FPAId = Pages.BasicInteractions().GetText(obj_PreApprovals.FPA_SuccessMessage).Trim().Split(' ')[0];
                return FPAId;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Clone_FPA method: " + ex.Message);
                throw;
            }
        }

        public void Resubmit_FPA(string FPAId)
        {

            try
            {
                Search_FPA(FPAId);

                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().Click(obj_PreApprovals.FirstRow_FPAId_Link);
                Pages.BasicInteractions().WaitTillNotVisible(obj_PreApprovals.ImgLoading);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.EditButton);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().Click(obj_PreApprovals.EditButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_PreApprovals.ImgLoading);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.FPA_NextButton2);
                Pages.BasicInteractions().Click(obj_PreApprovals.FPA_NextButton2);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().Click(obj_PreApprovals.FPA_NextButton3);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_PreApprovals.SubmitButton1);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.FPA_SuccessMessage);
                Console.WriteLine(Pages.BasicInteractions().GetText(obj_PreApprovals.FPA_SuccessMessage));
               
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Resubmit_FPA method: " + ex.Message);
                throw;
            }
        }

        public void Search_FPA(String FPAId)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.LeftNavFundPreApproval);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().Click(obj_PreApprovals.LeftNavFundPreApproval);
                Pages.BasicInteractions().WaitTillNotVisible(obj_PreApprovals.ImgLoading);
                Pages.BasicInteractions().WaitTime(15);

                //Simple Search 
                Pages.BasicInteractions().Click(obj_PreApprovals.SimpleSearchTextbox);
                Pages.BasicInteractions().Type(obj_PreApprovals.SimpleSearchTextbox, FPAId);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().Click(obj_PreApprovals.SimpleSearchButton);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitTillNotVisible(obj_PreApprovals.ImgLoading);
                Pages.BasicInteractions().WaitTime(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Search_FPA method " + ex.Message);
                throw;
            }
        }

        public void Review_FPA(string FPAId, string Action)
        {
            try
            {
                Search_FPA(FPAId);
                Process_FPA(Action);
                //Console.WriteLine(Pages.BasicInteractions().GetText(obj_PreApprovals.FPA_SuccessMessage));


            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Review_FPA method " + ex.Message);
                throw;
            }
        }

        public void Process_FPA(string Action)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_PreApprovals.FirstRow_FPAId_Link);
                Pages.BasicInteractions().WaitTillNotVisible(obj_PreApprovals.ImgLoading);

                
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
                Pages.BasicInteractions().WaitTime(8);
                Pages.BasicInteractions().Type(obj_claimPerformAction.ClaimReviewCodeText, Keys.Tab);
                Pages.BasicInteractions().Click(obj_claimPerformAction.ClaimReviewCodeTextSelect);
                Pages.BasicInteractions().WaitTime(8);
                Pages.BasicInteractions().Click(obj_claimPerformAction.ClaimReviewCodeDropdown);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_claimPerformAction.ClaimSendResponseButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Process_FPA method " + ex.Message);
                throw;
            }

        }

        public string Get_PreApprovalID(string PreApprovalType )
        {
            try
            {
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                if (PreApprovalType == "BPA")
                {
                    Pages.BasicInteractions().WaitVisible(obj_PreApprovals.LeftNavPreapprovals);
                    Pages.BasicInteractions().Click(obj_PreApprovals.LeftNavPreapprovals);
                }
                else // for FPA
                {
                    Pages.BasicInteractions().WaitVisible(obj_PreApprovals.LeftNavFundPreApproval);
                    Pages.BasicInteractions().Click(obj_PreApprovals.LeftNavFundPreApproval);
                }
                Pages.BasicInteractions().WaitTillNotVisible(obj_PreApprovals.ImgLoading);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.AdvanceSearchLink);
                Pages.BasicInteractions().Click(obj_PreApprovals.AdvanceSearchLink);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.ApprovedCheckbox);
                Pages.BasicInteractions().Click(obj_PreApprovals.ApprovedCheckbox);

                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.AdvanceSearchButton);
                Pages.BasicInteractions().Click(obj_PreApprovals.AdvanceSearchButton);

                Pages.BasicInteractions().WaitTillNotVisible(obj_PreApprovals.LoadingImageBrandingPreApproval);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.TblBPAFirstrow);
                String PreAproval_ID = Pages.BasicInteractions().GetText(obj_PreApprovals.TblBPAFirstrow);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_dashboard.LeftNavDashboard);
                return PreAproval_ID;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Exception in Get_PreApprovalID method with exception :" + Ex.Message);
                //return null;
                throw;
            }
        }
    }
}
