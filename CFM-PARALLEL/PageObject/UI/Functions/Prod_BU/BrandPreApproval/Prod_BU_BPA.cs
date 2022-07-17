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
namespace CFM_PARALLEL.PageObject.UI.Functions.Prod_BU.BrandPreApproval
{
    public class Prod_BU_BPA
    {
      
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private OBJ_PreApprovals obj_bpa;
        private OBJ_Common oBJ_Common;

        //Constructor
        public Prod_BU_BPA()
        {
            
            obj_dashboard = new OBJ_Dashboard();
            obj_claims = new OBJ_Claims();
            obj_bpa = new OBJ_PreApprovals();
            oBJ_Common = new OBJ_Common();
        }

        public string Create_BPA()
        {
            try
            {
                //Navigating to Brand Submit PreApproval Screen
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.LeftNavDashboard);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.SubmitBrandPreapproval);
                Pages.BasicInteractions().Click(obj_dashboard.SubmitBrandPreapproval);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                //Entering Details for BPA
                BPAEnterDetails();

                //Adding Attachment
                BPAAddingAttachment();

                Console.WriteLine("Asserting for Submit Button displaying on 3rd page of BPA");
                Assert.True(Pages.BasicInteractions().IsElementDisplayed(obj_bpa.SubmitButton2));
                Pages.BasicInteractions().Click(obj_bpa.SubmitButton2);
                Pages.BasicInteractions().WaitVisible(obj_bpa.FPA_SuccessMessage);
                Console.WriteLine(Pages.BasicInteractions().GetText(obj_bpa.FPA_SuccessMessage));
                string BPAId = Pages.BasicInteractions().GetText(obj_bpa.FPA_SuccessMessage).Trim().Split(' ')[0];
                return BPAId;
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
               
                Pages.BasicInteractions().WaitVisible(obj_bpa.BPARefName);
                Pages.BasicInteractions().Clear(obj_bpa.BPARefName);
                Pages.BasicInteractions().Type(obj_bpa.BPARefName, "BPA-Reference Number-1234");

                //Pages.BasicInteractions().WaitVisible(obj_bpa.StoreDropdown);
                //Pages.BasicInteractions().Click(obj_bpa.StoreDropdown);
                //Pages.BasicInteractions().WaitVisible(obj_bpa.StoreTextbox);
                //Pages.BasicInteractions().TypeClear(obj_bpa.StoreTextbox, "28 - CHILD 1");
                //Pages.BasicInteractions().Type(obj_bpa.StoreTextbox, Keys.Enter);

                Pages.BasicInteractions().WaitVisible(obj_bpa.BPA_ActivityType);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_bpa.BPA_ActivityType);
                Pages.BasicInteractions().WaitVisible(obj_bpa.BPA_ActivityTypeTextbox);
                Pages.BasicInteractions().TypeClear(obj_bpa.BPA_ActivityTypeTextbox, "Direct Mail");
                Pages.BasicInteractions().Type(obj_bpa.BPA_ActivityTypeTextbox, Keys.Enter);

                Pages.BasicInteractions().WaitVisible(obj_bpa.Startdate);
                Pages.BasicInteractions().Click(obj_bpa.Startdate);
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
                Pages.BasicInteractions().WaitVisible(obj_bpa.Comment);
                //File Upload                
                CommonUtilities.UploadFile(oBJ_Common.FileUploadInput,"CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                Pages.BasicInteractions().WaitVisible(obj_bpa.Comment);
                Pages.BasicInteractions().Type(obj_bpa.Comment, "Test-Comments");
                Pages.BasicInteractions().WaitVisible(obj_bpa.FPA_NextButton3);
                Pages.BasicInteractions().Click(obj_bpa.FPA_NextButton3);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in BPAAddingAttachment method: " + ex.Message);
                throw;
            }
        }

        public string Create_FPA(string Functionality= "BPA")
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_dashboard.LeftNavDashboard);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.SubmiFundPreapproval);
                Pages.BasicInteractions().Click(obj_dashboard.SubmiFundPreapproval);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                //Entering Details for BPA
                FPA_Fill_Form_Details_WorkFlow();

                //Adding Attachment
                BPAAddingAttachment();

                Console.WriteLine("Asserting for Submit Button displaying on 3rd page of BPA");
                if (Functionality == "BPA")
                {
                    Pages.BasicInteractions().WaitVisible(obj_bpa.SubmitButton2);
                    Assert.True(Pages.BasicInteractions().IsElementDisplayed(obj_bpa.SubmitButton2));
                    Pages.BasicInteractions().Click(obj_bpa.SubmitButton2);
                }
                else
                {
                    Pages.BasicInteractions().WaitVisible(obj_bpa.SubmitButton1);
                    Assert.True(Pages.BasicInteractions().IsElementDisplayed(obj_bpa.SubmitButton1));
                    Pages.BasicInteractions().Click(obj_bpa.SubmitButton1);
                }
                Pages.BasicInteractions().WaitUntilElementVisible(obj_bpa.FPA_SuccessMessage,120);
                Console.WriteLine(Pages.BasicInteractions().GetText(obj_bpa.FPA_SuccessMessage));
                string BPAId = Pages.BasicInteractions().GetText(obj_bpa.FPA_SuccessMessage).Trim().Split(' ')[0];
                return BPAId;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in BPA_FullFlow_Validation method: " + ex.Message);
                throw;
            }
        }

        public void FPA_Fill_Form_Details_WorkFlow()
        {
            try
            {
                //Entering Details for FPA
                Pages.BasicInteractions().WaitVisible(obj_bpa.FPA_Store);
                Pages.BasicInteractions().Click(obj_bpa.FPA_Store);
                Pages.BasicInteractions().WaitVisible(obj_bpa.FPA_StoreTextbox);
                
                Pages.BasicInteractions().TypeClear(obj_bpa.FPA_StoreTextbox, "28 - CHILD 1");
                Pages.BasicInteractions().Type(obj_bpa.FPA_StoreTextbox, Keys.Enter);
                Pages.BasicInteractions().WaitTime(2);          

                Pages.BasicInteractions().WaitVisible(obj_bpa.FPA_Program);
                Pages.BasicInteractions().Click(obj_bpa.FPA_Program);
                Pages.BasicInteractions().WaitVisible(obj_bpa.FPA_ProgramTextbox);
                Pages.BasicInteractions().TypeClear(obj_bpa.FPA_ProgramTextbox, "AutomationProgram");
                Pages.BasicInteractions().Type(obj_bpa.FPA_ProgramTextbox, Keys.Enter);
                Pages.BasicInteractions().WaitTime(2);

                Pages.BasicInteractions().WaitVisible(obj_bpa.FPA_NextButton1);
                Pages.BasicInteractions().Click(obj_bpa.FPA_NextButton1);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().WaitUntilElementVisible(obj_bpa.PreApprovalReferenceTextbox,120);
                Pages.BasicInteractions().Click(obj_bpa.PreApprovalReferenceTextbox);
                Pages.BasicInteractions().TypeClear(obj_bpa.PreApprovalReferenceTextbox, "Test123");
                Pages.BasicInteractions().WaitTime(2);
               
                Pages.BasicInteractions().WaitVisible(obj_bpa.BPA_ActivityType);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_bpa.BPA_ActivityType);
                Pages.BasicInteractions().WaitVisible(obj_bpa.BPA_ActivityTypeTextbox);
                Pages.BasicInteractions().TypeClear(obj_bpa.BPA_ActivityTypeTextbox, "TV");
                Pages.BasicInteractions().Type(obj_bpa.BPA_ActivityTypeTextbox, Keys.Enter);

                Pages.BasicInteractions().WaitVisible(obj_bpa.FPA_StartDate);
                Pages.BasicInteractions().Click(obj_bpa.FPA_StartDate);
                Pages.BasicInteractions().Click(obj_bpa.BPAStartDateSelection(DateSelection.Ace_DateSelection_bpaStartDate()));
                Pages.BasicInteractions().WaitVisible(obj_bpa.FPA_EndDate);
                Pages.BasicInteractions().Click(obj_bpa.FPA_EndDate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_bpa.BPAEndDateSelection(DateSelection.Ace_DateSelection_bpaEndDate()));

                // Eligible Amount
                Pages.BasicInteractions().TypeClear(obj_bpa.FPA_TotalActivityCost, Parameters.MS_TotalActivityCost);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().TypeClear(obj_bpa.FPA_RequestedAmount, Parameters.MS_RequestedAmount);
                Pages.BasicInteractions().WaitVisible(obj_bpa.FPA_NextButton2);

                Pages.BasicInteractions().Click(obj_bpa.FPA_NextButton2);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in FPAEnterDetails method: " + ex.Message);
                throw;
            }
        }
    }
}
