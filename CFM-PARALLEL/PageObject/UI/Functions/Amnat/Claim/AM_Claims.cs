using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.Ace.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace CFM_PARALLEL.PageObject.UI.Functions.Amnat.Claim
{
    public class AM_Claims
    {

        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private OBJ_Common oBJ_Common;



        //Constructor
        public AM_Claims()
        {
            obj_dashboard = new OBJ_Dashboard();
            obj_claims = new OBJ_Claims();
            oBJ_Common = new OBJ_Common();
        }

        //Claim Validation 
        public void Amnat_Claim_Fullflow(string InvoiceNumber = "Claim-Invoice-1234")
        {
            try
            {
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmitClaim);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmitClaim);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                SelectStoreAndProgram_Claim();

                //Entering Details
                EnterDetails_Claim();

                //Adding Attachment
                AddingAttachment_Claim(InvoiceNumber);

                Assert.True(Pages.BasicInteractions().IsElementDisplayed(obj_claims.BtnSubmit));
                Console.WriteLine("Submit Button Available");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Amnat_Claim_Fullflow method: " + ex.Message);
                throw;
            }
        }

        public void SelectStoreAndProgram_Claim(string bpa_choice = "N", string bpa = null)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                if (Pages.BasicInteractions().IsElementVisible(obj_claims.BPAForClaimYes) | Pages.BasicInteractions().IsElementVisible(obj_claims.BPAForClaimNo))
                {
                    //opting for BPA
                    if (bpa_choice == "Y")
                    {
                        Pages.BasicInteractions().WaitVisible(obj_claims.BPAForClaimYes);
                        Pages.BasicInteractions().Click(obj_claims.BPAForClaimYes);
                        Pages.BasicInteractions().WaitVisible(obj_claims.PreApprovalID);
                        Pages.BasicInteractions().Click(obj_claims.PreApprovalID);
                        Pages.BasicInteractions().TypeClear(obj_claims.PreApprovalIDText, bpa);
                        Pages.BasicInteractions().Type(obj_claims.PreApprovalIDText, Keys.Enter);
                        Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                        Pages.BasicInteractions().WaitVisible(obj_claims.CoopProgramWithBPA);
                        Pages.BasicInteractions().Click(obj_claims.CoopProgramWithBPA);
                        Pages.BasicInteractions().WaitVisible(obj_claims.CoopProgramTextWithBPA);
                        if (Parameters.Bobcat_ProgramName() != null)
                        {
                            Pages.BasicInteractions().TypeClear(obj_claims.CoopProgramTextWithBPA, Parameters.Bobcat_ProgramName());
                        }
                        Pages.BasicInteractions().Type(obj_claims.CoopProgramTextWithBPA, Keys.Enter);

                        Pages.BasicInteractions().WaitTime(3);

                    }
                    //not opting for BPA
                    else if (bpa_choice == "N")
                    {
                        Pages.BasicInteractions().WaitVisible(obj_claims.BPAForClaimNo);
                        Pages.BasicInteractions().Click(obj_claims.BPAForClaimNo);
                        Pages.BasicInteractions().WaitTime(5);
                        Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);

                        Pages.BasicInteractions().WaitVisible(obj_claims.ClaimDropdown);
                        Pages.BasicInteractions().Click(obj_claims.ClaimDropdown);
                        Pages.BasicInteractions().Type(obj_claims.ClaimText, Parameters.AM_Prod_StoreName);
                        Pages.BasicInteractions().Type(obj_claims.ClaimText, Keys.Enter);
                        Pages.BasicInteractions().WaitTime(2);
                        Pages.BasicInteractions().Click(obj_claims.CoopProgram);
                        Pages.BasicInteractions().WaitVisible(obj_claims.CoopProgramText);

                        if (Parameters.Amnat_ProgramName() != null)
                        {
                            Pages.BasicInteractions().TypeClear(obj_claims.CoopProgramText, Parameters.Amnat_ProgramName());
                        }

                        Pages.BasicInteractions().Type(obj_claims.CoopProgramText, Keys.Enter);
                    }
                    Pages.BasicInteractions().WaitVisible(obj_claims.NextButton);
                    Pages.BasicInteractions().Click(obj_claims.NextButton);
                    Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                    Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                }
                else
                {
                    Pages.BasicInteractions().WaitVisible(obj_claims.DdlStoreName);
                    Pages.BasicInteractions().Click(obj_claims.DdlStoreName);
                    Pages.BasicInteractions().WaitVisible(obj_claims.TxbSearchStoreName);
                    if (BrowserURLLaunch.EXECUTIONENVIRONMENT.ToUpper() != "PROD".ToUpper())
                    {
                        Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchStoreName, Parameters.AM_Prod_StoreName);
                        Pages.BasicInteractions().Type(obj_claims.TxbSearchStoreName, Keys.Enter);

                        Pages.BasicInteractions().WaitVisible(obj_claims.DdlProgramName);
                        Pages.BasicInteractions().Click(obj_claims.DdlProgramName);
                        Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchProgramName, Parameters.AM_Prod_ProgramName);
                        Pages.BasicInteractions().Type(obj_claims.TxbSearchProgramName, Keys.Enter);
                    }
                    else
                    {
                        Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchStoreName, Parameters.AM_Prod_StoreName);
                        Pages.BasicInteractions().Type(obj_claims.TxbSearchStoreName, Keys.Enter);

                        Pages.BasicInteractions().WaitVisible(obj_claims.DdlProgramName);
                        Pages.BasicInteractions().Click(obj_claims.DdlProgramName);
                        Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchProgramName, Parameters.AM_Prod_ProgramName);
                        Pages.BasicInteractions().Type(obj_claims.TxbSearchProgramName, Keys.Enter);
                    }
                    Pages.BasicInteractions().WaitVisible(obj_claims.BtnNext1);
                    Pages.BasicInteractions().Click(obj_claims.BtnNext1);
                    Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                }
            }
            catch (Exception ex)
            {                
                Console.WriteLine("Error Message with an exception in SelectStoreAndProgram_Claim method: " + ex.Message);
                throw;
            }
        }

        public void EnterDetails_Claim(string bpa_choice = "N")
        {

            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimRequestedAmount);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbClaimDescription, "Claim Ref Number-1234");

                if (bpa_choice == "N")
                {
                   
                    Pages.BasicInteractions().WaitVisible(obj_claims.AM_ActivityType);
                    Pages.BasicInteractions().WaitTime(2);
                    Pages.BasicInteractions().Click(obj_claims.AM_ActivityType);
                    Pages.BasicInteractions().WaitVisible(obj_claims.AM_ActivityTypeTextbox);
                    Pages.BasicInteractions().TypeClear(obj_claims.AM_ActivityTypeTextbox, "Billboard");
                    Pages.BasicInteractions().Type(obj_claims.AM_ActivityTypeTextbox, Keys.Enter);
                    Pages.BasicInteractions().WaitTime(2);
                }

                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));

                //Element not visible
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                Pages.BasicInteractions().WaitTime(2);
                                
                // Eligible Amount
                Pages.BasicInteractions().TypeClear(obj_claims.ClaimTotalActivityCost, Parameters.AM_TotalActivityCost);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().TypeClear(obj_claims.ClaimRequestedAmount, Parameters.AM_RequestedAmount);
                Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }
            catch (Exception ex)
            {                
                Console.WriteLine("Error Message with an exception in EnterDetails_Claim method: " + ex.Message);
                throw;
            }
        }

        public void AddingAttachment_Claim(string InvoiceNumber)
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimComments);
                Pages.BasicInteractions().TypeClear(obj_claims.ClaimInvoice, InvoiceNumber);
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimUpload);
               
                //File Upload
                CommonUtilities.UploadFile(oBJ_Common.FileUploadInput,"CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                Pages.BasicInteractions().WaitUntilElementVisible(obj_claims.FileUploadedSuccessfully, 120);
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimComments);
                Pages.BasicInteractions().Type(obj_claims.ClaimComments, "Claim-Comments");
                Pages.BasicInteractions().WaitUntilElementVisible(obj_claims.BtnNext3, 120);
                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().Click(obj_claims.BtnNext3);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }
            catch (Exception ex)
            {               
                Console.WriteLine("Error Message with an exception in AddingAttachment_Claim method: " + ex.Message);
                throw;
            }
        }

        public void Validate_Claims()
        {
            try
            {
                Pages.Dashboard_Landing().ClickParticularValueSection("CLAIMS");
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.Dashboard_Landing().ValidatePageHeadSectionValues("Pending");
                Pages.Dashboard_Landing().ValidatePageHeadSectionValues("InProcess");
                Pages.Dashboard_Landing().ValidatePageHeadSectionValues("Completed");
                Pages.Dashboard_Landing().ValidatePageHeadSectionValues("Declined");

                Pages.BasicInteractions().Click(obj_claims.InProcessStatusTabs);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_claims.DeclinedStatusTabs);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_claims.PendingStatusTabs);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_claims.CompletedStatusTabs);
                /*Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Common.MoreDetailsLink, 120);
                Pages.BasicInteractions().Click(oBJ_Common.MoreDetailsLink);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Common.AuditTrailLink, 120);
                Pages.BasicInteractions().Click(oBJ_Common.AuditTrailLink);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Common.AuditHistoryLabel, 120);
                Assert.AreEqual(true, Pages.BasicInteractions().IsElementDisplayed(oBJ_Common.AuditHistoryLabel));
                Pages.BasicInteractions().Click(oBJ_Common.CloseButton);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Common.ClaimDetailsPageStatus, 120);
                string ExpectedStatus = Pages.BasicInteractions().GetText(oBJ_Common.ClaimDetailsPageStatus);
                Pages.BasicInteractions().Click(oBJ_Common.ViewButton);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                string ActualStatus = Pages.BasicInteractions().GetText(obj_claims.ClaimStatusOnClaimReviewPage);
                Assert.AreEqual(ExpectedStatus, ActualStatus);
                Console.WriteLine("Claim manage page is verified");*/
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Validate_Claims method: " + ex.Message);
                throw;
            }
        }
    }
}


