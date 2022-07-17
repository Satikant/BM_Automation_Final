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

namespace CFM_PARALLEL.PageObject.UI.Functions.Masco.BrandPreApproval
{
    public class MS_BrandPreApproval
    {
        private OBJ_Dashboard obj_dashboard;
        private OBJ_PreApprovals obj_PreApprovals;
        private Claim_PerformAction obj_claimPerformAction;
        private OBJ_Common oBJ_Common;
        private OBJ_Claims obj_claims;

        //Constructor
        public MS_BrandPreApproval()
        {
            obj_dashboard = new OBJ_Dashboard();
            obj_PreApprovals = new OBJ_PreApprovals();
            obj_claimPerformAction = new Claim_PerformAction();
            oBJ_Common = new OBJ_Common();
            obj_claims = new OBJ_Claims();
        }

        public void BPA_FullFlow_Validation()
        {
            try
            {
                //Navigating to Brand Submit PreApproval Screen
                Pages.BasicInteractions().WaitUntilElementVisible(obj_dashboard.LeftNavDashboard,120);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.SubmitBrandPreapproval);
                Pages.BasicInteractions().Click(obj_dashboard.SubmitBrandPreapproval);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                //Entering Details for BPA
                BPAEnterDetails();

                //Adding Attachment
                BPAAddingAttachment();

                //Checking Submit Button Visiblity
                Assert.True(Pages.BasicInteractions().IsElementDisplayed(obj_PreApprovals.SubmitButton2));
                Console.WriteLine("User Able to Pass Brand Pre Approval Values till Submit Button: PASSED");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in BPA_FullFlow_Validation method: " + ex.Message);
                throw;
            }
        }

        public void BPAEnterDetails()
        {
            try
            {
                //Entering Details for BPA
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.BPARefName);
                Pages.BasicInteractions().Clear(obj_PreApprovals.BPARefName);
                Pages.BasicInteractions().Type(obj_PreApprovals.BPARefName, "BPA-Reference Number-1234");
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.StoreDropdown);
                Pages.BasicInteractions().WaitTime(2);
                //Pages.BasicInteractions().Click(obj_PreApprovals.StoreDropdown);
                //Pages.BasicInteractions().WaitVisible(obj_PreApprovals.StoreTextbox);
                //Pages.BasicInteractions().TypeClear(obj_PreApprovals.StoreTextbox, Parameters.MS_StoreName);                
                //Pages.BasicInteractions().Type(obj_PreApprovals.StoreTextbox, Keys.Enter);
                //Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().Click(obj_PreApprovals.BrandName);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.BrandNameTextbox);
                Pages.BasicInteractions().TypeClear(obj_PreApprovals.BrandNameTextbox, "KraftMaid");
                Pages.BasicInteractions().Type(obj_PreApprovals.BrandNameTextbox, Keys.Enter);
                Pages.BasicInteractions().WaitTime(3);

                Pages.BasicInteractions().Click(obj_PreApprovals.AccountNumber);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.AccountNumberTextbox);
                Pages.BasicInteractions().TypeClear(obj_PreApprovals.AccountNumberTextbox, "13412");
                Pages.BasicInteractions().Type(obj_PreApprovals.AccountNumberTextbox, Keys.Enter);
                Pages.BasicInteractions().WaitTime(3);

                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.BPA_MediaType);
                Pages.BasicInteractions().Click(obj_PreApprovals.BPA_MediaType);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.BPA_MediaTypeTextbox);
                Pages.BasicInteractions().TypeClear(obj_PreApprovals.BPA_MediaTypeTextbox, "Advertising");
                Pages.BasicInteractions().Type(obj_PreApprovals.BPA_MediaTypeTextbox, Keys.Enter);

                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.BPA_ActivityType);
                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().Click(obj_PreApprovals.BPA_ActivityType);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.BPA_ActivityTypeTextbox);
                Pages.BasicInteractions().TypeClear(obj_PreApprovals.BPA_ActivityTypeTextbox, "Templates");
                Pages.BasicInteractions().Type(obj_PreApprovals.BPA_ActivityTypeTextbox, Keys.Enter);
                                             
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.Startdate);
                Pages.BasicInteractions().Click(obj_PreApprovals.Startdate);
                Pages.BasicInteractions().Click(obj_PreApprovals.BPAStartDateSelection(DateSelection.Ace_DateSelection_bpaStartDate()));
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.Enddate);
                Pages.BasicInteractions().Click(obj_PreApprovals.Enddate);
                Pages.BasicInteractions().Click(obj_PreApprovals.BPAEndDateSelection(DateSelection.Ace_DateSelection_bpaEndDate()));
                Pages.BasicInteractions().Click(obj_PreApprovals.NextButton);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in BPAEnterDetails method: " + ex.Message);
                throw;
            }
        }

        public void BPAAddingAttachment()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.Comment);               
                //File Upload                
                CommonUtilities.UploadFile(oBJ_Common.FileUploadInput, "CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.Comment);
                Pages.BasicInteractions().Type(obj_PreApprovals.Comment, "BPA-Comments");
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.FPA_NextButton3);
                Pages.BasicInteractions().Click(obj_PreApprovals.FPA_NextButton3);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.SubmitButton2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in BPAAddingAttachment method: " + ex.Message);
                throw;
            }
        }

        public string Create_BPA()
        {
            try
            {
                //Navigating to Brand Submit PreApproval Screen
                Pages.BasicInteractions().WaitUntilElementVisible(obj_dashboard.BtnSubmit,120);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.SubmitBrandPreapproval);
                Pages.BasicInteractions().Click(obj_dashboard.SubmitBrandPreapproval);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                //Entering Details for BPA
                BPAEnterDetails();

                //Adding Attachment
                BPAAddingAttachment();

                //Checking Submit Button Visiblity
                Assert.True(Pages.BasicInteractions().IsElementDisplayed(obj_PreApprovals.SubmitButton2));
                Console.WriteLine("Submit Button is displaying on 3rd page of BPA");
                Pages.BasicInteractions().Click(obj_PreApprovals.SubmitButton2);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.FPA_SuccessMessage);
                Console.WriteLine(Pages.BasicInteractions().GetText(obj_PreApprovals.FPA_SuccessMessage));
                string BPAId = Pages.BasicInteractions().GetText(obj_PreApprovals.FPA_SuccessMessage).Trim().Split(' ')[0];
                return BPAId;                               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Create_BPA method: " + ex.Message);
                throw;
            }
        }

        public void Search_BPA(String BPAId)
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.LeftNavPreapprovals);
                Pages.BasicInteractions().Click(obj_PreApprovals.LeftNavPreapprovals);
                Pages.BasicInteractions().WaitTillNotVisible(obj_PreApprovals.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                //Simple Search 
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.SimpleSearchTextbox);
                Pages.BasicInteractions().Click(obj_PreApprovals.SimpleSearchTextbox);
                Pages.BasicInteractions().Type(obj_PreApprovals.SimpleSearchTextbox, BPAId);
                Pages.BasicInteractions().Click(obj_PreApprovals.SimpleSearchButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_PreApprovals.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Search_BPA method " + ex.Message);
                throw;
            }
        }

        public string Clone_BPA(string BPAId)
        {
            try
            {
                Search_BPA(BPAId);
                Pages.BasicInteractions().WaitVisible(oBJ_Common.MoreDetailsLink);
                Pages.BasicInteractions().Click(oBJ_Common.MoreDetailsLink);

                Pages.BasicInteractions().WaitVisible(obj_claims.ViewReviewButton);
                Pages.BasicInteractions().Click(obj_claims.ViewReviewButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_PreApprovals.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                                                            
                Pages.BasicInteractions().WaitUntilElementVisible(obj_PreApprovals.CloneButton,120);
                Pages.BasicInteractions().Click(obj_PreApprovals.CloneButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_PreApprovals.ImgLoading);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_PreApprovals.NextButton,120);
                Pages.BasicInteractions().Click(obj_PreApprovals.NextButton);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                //Adding Attachment
                BPAAddingAttachment();

                Assert.True(Pages.BasicInteractions().IsElementDisplayed(obj_PreApprovals.SubmitButton2));
                Pages.BasicInteractions().Click(obj_PreApprovals.SubmitButton2);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.FPA_SuccessMessage);
                Console.WriteLine(Pages.BasicInteractions().GetText(obj_PreApprovals.FPA_SuccessMessage));
                BPAId = Pages.BasicInteractions().GetText(obj_PreApprovals.FPA_SuccessMessage).Trim().Split(' ')[0];
                return BPAId;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Clone_FPA method: " + ex.Message);
                throw;
            }
        }


        public void Resubmit_BPA(string BPAId)
        {
            try
            {
                Search_BPA(BPAId);
                Pages.BasicInteractions().WaitVisible(oBJ_Common.MoreDetailsLink);
                Pages.BasicInteractions().Click(oBJ_Common.MoreDetailsLink);
                Pages.BasicInteractions().WaitVisible(obj_claims.ViewReviewButton);
                Pages.BasicInteractions().Click(obj_claims.ViewReviewButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_PreApprovals.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.EditButton);
                Pages.BasicInteractions().WaitTime(2);

                Pages.BasicInteractions().Click(obj_PreApprovals.EditButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_PreApprovals.ImgLoading);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.FPA_NextButton2);
                Pages.BasicInteractions().Click(obj_PreApprovals.FPA_NextButton2);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().Click(obj_PreApprovals.FPA_NextButton3);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().Click(obj_PreApprovals.SubmitButton2);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.FPA_SuccessMessage);
                Console.WriteLine(Pages.BasicInteractions().GetText(obj_PreApprovals.FPA_SuccessMessage));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Resubmit_BPA method: " + ex.Message);
                throw;
            }
        }

        public void Review_BPA(string BPAId, string Action)
        {
            try
            {
                Search_BPA(BPAId);
                Process_BPA(Action);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Review_FPA method: " + ex.Message);
                throw;
            }
        }

        public void Process_BPA(string Action)
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(oBJ_Common.MoreDetailsLink);
                Pages.BasicInteractions().Click(oBJ_Common.MoreDetailsLink);
                Pages.BasicInteractions().WaitVisible(obj_claims.ViewReviewButton);
                Pages.BasicInteractions().Click(obj_claims.ViewReviewButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_PreApprovals.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

               
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.BPAResponseDropdown);
                Pages.BasicInteractions().Click(obj_PreApprovals.BPAResponseDropdown);
                Pages.BasicInteractions().Click(obj_PreApprovals.BPAResponseAction(Action));               
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.BPASendResponseButton);
                Pages.BasicInteractions().Click(obj_PreApprovals.BPAReviewCodesDropdown);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Type(obj_claimPerformAction.ClaimReviewCodeText, Keys.Tab);
                Pages.BasicInteractions().Click(obj_claimPerformAction.ClaimReviewCodeTextSelect);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_claimPerformAction.ClaimSendResponseButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_PreApprovals.ImgLoading);
                Pages.BasicInteractions().WaitVisible(obj_PreApprovals.BPASuccessMessage);
                Console.WriteLine(obj_PreApprovals.BPASuccessMessage);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Process_BPA method " + ex.Message);
                throw;
            }
        }
    }
}
