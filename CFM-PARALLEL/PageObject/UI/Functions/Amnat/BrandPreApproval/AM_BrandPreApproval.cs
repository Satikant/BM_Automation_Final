using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Pre_Approvals;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace CFM_PARALLEL.PageObject.UI.Functions.Amnat.BrandPreApproval
{
    public class AM_BrandPreApproval
    {
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private OBJ_PreApprovals obj_bpa;
        private OBJ_Common oBJ_Common;

        //Constructor
        public AM_BrandPreApproval()
        {
            obj_dashboard = new OBJ_Dashboard();
            obj_claims = new OBJ_Claims();
            obj_bpa = new OBJ_PreApprovals();
            oBJ_Common = new OBJ_Common();
        }

        public void BPA_FullFlow_Validation()
        {
            try
            {
                //Navigating to Brand Submit PreApproval Screen                
                Pages.BasicInteractions().WaitUntilElementVisible(obj_dashboard.BtnSubmit,240);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_dashboard.SubmitBrandPreapproval,120);
                Pages.BasicInteractions().Click(obj_dashboard.SubmitBrandPreapproval);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                //Entering Details for BPA
                BPAEnterDetails();

                //Adding Attachment
                BPAAddingAttachment();
   
                //Checking Submit Button Visibility
                Console.WriteLine("Asserting for submit button visibility");
                Assert.True(Pages.BasicInteractions().IsElementDisplayed(obj_bpa.SubmitButton2));
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
                Pages.BasicInteractions().WaitVisible(obj_bpa.AM_BPAlabel);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_bpa.AM_SubmissionBPAOption,120);
                Pages.BasicInteractions().Click(obj_bpa.AM_SubmissionBPAOption);
                Pages.BasicInteractions().WaitVisible(obj_bpa.BPARefName);
                Pages.BasicInteractions().Clear(obj_bpa.BPARefName);
                Pages.BasicInteractions().Type(obj_bpa.BPARefName, "BPA-Reference Number-1234");
               
                Pages.BasicInteractions().WaitUntilElementVisible(obj_bpa.BPA_ActivityType,120);
                Pages.BasicInteractions().Click(obj_bpa.BPA_ActivityType);
                Pages.BasicInteractions().WaitVisible(obj_bpa.BPA_ActivityTypeTextbox);
                Pages.BasicInteractions().TypeClear(obj_bpa.BPA_ActivityTypeTextbox, "Radio");
                Pages.BasicInteractions().Type(obj_bpa.BPA_ActivityTypeTextbox, Keys.Enter);

                Pages.BasicInteractions().WaitVisible(obj_bpa.Startdate);
                Pages.BasicInteractions().Click(obj_bpa.Startdate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_bpa.BPAStartDateSelection(DateSelection.Ace_DateSelection_bpaStartDate()));
                Pages.BasicInteractions().WaitVisible(obj_bpa.Enddate);
                Pages.BasicInteractions().Click(obj_bpa.Enddate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_bpa.BPAEndDateSelection(DateSelection.Ace_DateSelection_bpaEndDate()));
                Pages.BasicInteractions().Click(obj_bpa.NextButton);
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
                Pages.BasicInteractions().WaitUntilElementVisible(obj_bpa.FPA_NextButton3,120);          
                //File Upload                
                CommonUtilities.UploadFile(oBJ_Common.FileUploadInput,"CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                Pages.BasicInteractions().WaitVisible(obj_bpa.Comment);
                Pages.BasicInteractions().Type(obj_bpa.Comment, "BPA-Comments");              
                Pages.BasicInteractions().WaitUntilElementClickable(obj_bpa.FPA_NextButton3,120);
                Pages.BasicInteractions().Click(obj_bpa.FPA_NextButton3);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_bpa.SubmitButton2,120);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitTime(5);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in BPAAddingAttachment method: " + ex.Message);
                throw;
            }
        }
    }
}
