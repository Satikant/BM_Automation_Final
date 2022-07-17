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
using System;


namespace CFM_PARALLEL.PageObject.UI.Functions.Masco.Claims
{
    public class MS_Claims
    {
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private OBJ_Common oBJ_Common;
        private Claim_PerformAction obj_claimPerformAction;
        private OBJ_Transactions oBJ_Transactions;

        //Constructor
        public MS_Claims()
        {
            obj_dashboard = new OBJ_Dashboard();
            obj_claims = new OBJ_Claims();
            oBJ_Common = new OBJ_Common();
            obj_claimPerformAction = new Claim_PerformAction();
            oBJ_Transactions = new OBJ_Transactions();
        }

        //Claim Validation 
        public void Masco_Claim_Fullflow(String RequestedAmount, String InvoiceNumber, String preApproval_choice = "N", String PreApprovalId = null)
        {
            try
            {
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmitClaim);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmitClaim);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                SelectStoreAndProgram_Claim(preApproval_choice, PreApprovalId);

                //Entering Details
                if (preApproval_choice == "Y")
                    EnterDetails_Claim_With_PreApproval(RequestedAmount);
                else
                    EnterDetails_Claim(RequestedAmount);


                //Adding Attachment
                AddingAttachment_Claim(InvoiceNumber);

                Assert.True(Pages.BasicInteractions().IsElementDisplayed(obj_claims.BtnSubmit));
                Console.WriteLine("Submit Button Available");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void SelectStoreAndProgram_Claim(String preApproval_choice, String PreApprovalId)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                if (Pages.BasicInteractions().IsElementVisible(obj_claims.BPAForClaimYes) | Pages.BasicInteractions().IsElementVisible(obj_claims.BPAForClaimNo))
                {
                    //opting for BPA
                    if (preApproval_choice == "Y")
                    {
                        Pages.BasicInteractions().WaitUntilElementVisible(obj_claims.BPAForClaimYes,120);
                        Pages.BasicInteractions().Click(obj_claims.BPAForClaimYes);
                        Pages.BasicInteractions().WaitVisible(obj_claims.PreApprovalID);
                        Pages.BasicInteractions().Click(obj_claims.PreApprovalID);
                        Pages.BasicInteractions().TypeClear(obj_claims.PreApprovalIDText, PreApprovalId);
                        Pages.BasicInteractions().Type(obj_claims.PreApprovalIDText, Keys.Enter);
                        Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                        Pages.BasicInteractions().WaitTime(5);

                        if (PreApprovalId.Contains("BPA"))
                            {
                            Pages.BasicInteractions().WaitVisible(obj_claims.CoopProgramWithBPA);
                            Pages.BasicInteractions().Click(obj_claims.CoopProgramWithBPA);
                            Pages.BasicInteractions().WaitVisible(obj_claims.CoopProgramTextWithBPA);
                            if (Parameters.Masco_Claim_ProgramName() != null)
                            {
                                Pages.BasicInteractions().TypeClear(obj_claims.CoopProgramTextWithBPA, Parameters.Masco_Claim_ProgramName());
                            }
                            Pages.BasicInteractions().Type(obj_claims.CoopProgramTextWithBPA, Keys.Enter);
                        }
                         

                    } // end of if
                    //not opting for BPA
                    else if (preApproval_choice == "N")
                    {
                        Pages.BasicInteractions().WaitUntilElementVisible(obj_claims.BPAForClaimNo,120);
                        Pages.BasicInteractions().Click(obj_claims.BPAForClaimNo);
                        Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);

                        Pages.BasicInteractions().WaitVisible(obj_claims.ClaimDropdown);
                        Pages.BasicInteractions().Click(obj_claims.ClaimDropdown);
                        Pages.BasicInteractions().Type(obj_claims.ClaimText, Parameters.MS_StoreName2);
                        Pages.BasicInteractions().Type(obj_claims.ClaimText, Keys.Enter);
                        Pages.BasicInteractions().WaitTime(2);
                        Pages.BasicInteractions().Click(obj_claims.CoopProgram);
                        Pages.BasicInteractions().WaitVisible(obj_claims.CoopProgramText);

                        if (Parameters.Masco_Claim_ProgramName() != null)
                        {
                            Pages.BasicInteractions().TypeClear(obj_claims.CoopProgramText, Parameters.Masco_Claim_ProgramName());
                        }

                        Pages.BasicInteractions().Type(obj_claims.CoopProgramText, Keys.Enter);

                    } // end of else if
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
                        Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchStoreName, Parameters.MS_StoreName);
                        Pages.BasicInteractions().Type(obj_claims.TxbSearchStoreName, Keys.Enter);

                        Pages.BasicInteractions().WaitVisible(obj_claims.DdlProgramName);
                        Pages.BasicInteractions().Click(obj_claims.DdlProgramName);
                        Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchProgramName, Parameters.Masco_Claim_ProgramName());
                        Pages.BasicInteractions().Type(obj_claims.TxbSearchProgramName, Keys.Enter);
                    }
                    else
                    {
                        Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchStoreName, Parameters.MS_FR_StoreName);
                        Pages.BasicInteractions().Type(obj_claims.TxbSearchStoreName, Keys.Enter);

                        Pages.BasicInteractions().WaitVisible(obj_claims.DdlProgramName);
                        Pages.BasicInteractions().Click(obj_claims.DdlProgramName);
                        Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchProgramName, Parameters.MS_FR_ProgramName);
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

        public void EnterDetails_Claim(string RequestedAmount)
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimRequestedAmount);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbClaimDescription, "Claim Ref Number-1234");

                Pages.BasicInteractions().WaitVisible(obj_claims.DdlMediaType);
                Pages.BasicInteractions().Click(obj_claims.DdlMediaType);
                Pages.BasicInteractions().WaitVisible(obj_claims.TxbsearchMediaType);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbsearchMediaType, "Advertising");
                Pages.BasicInteractions().Type(obj_claims.TxbsearchMediaType, Keys.Enter);
                Pages.BasicInteractions().WaitTime(2);

                Pages.BasicInteractions().WaitVisible(obj_claims.ActivityType);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_claims.ActivityType);
                Pages.BasicInteractions().WaitVisible(obj_claims.ActivityTypeTextbox);
                Pages.BasicInteractions().TypeClear(obj_claims.ActivityTypeTextbox, "Templates");
                Pages.BasicInteractions().Type(obj_claims.ActivityTypeTextbox, Keys.Enter);
                Pages.BasicInteractions().WaitTime(2);

                Pages.BasicInteractions().WaitVisible(obj_claims.ApprovedBrands);
                Pages.BasicInteractions().Click(obj_claims.ApprovedBrands);
                Pages.BasicInteractions().WaitVisible(obj_claims.ApprovedBrandsTextbox);
                Pages.BasicInteractions().TypeClear(obj_claims.ApprovedBrandsTextbox, "KraftMaid");
                Pages.BasicInteractions().Type(obj_claims.ApprovedBrandsTextbox, Keys.Enter);
                Pages.BasicInteractions().WaitTime(2);

                Pages.BasicInteractions().WaitVisible(obj_claims.AccountNumber);
                Pages.BasicInteractions().Click(obj_claims.AccountNumber);
                Pages.BasicInteractions().WaitVisible(obj_claims.AccountNumberTextbox);
                Pages.BasicInteractions().TypeClear(obj_claims.AccountNumberTextbox, "3147");
                Pages.BasicInteractions().Type(obj_claims.AccountNumberTextbox, Keys.Enter);
                Pages.BasicInteractions().WaitTime(2);

                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));

                //Element not visible
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));

                Pages.BasicInteractions().TypeClear(obj_claims.ClaimVendorName, "Test");

                // Eligible Amount
                Pages.BasicInteractions().TypeClear(obj_claims.ClaimTotalActivityCost, Parameters.MS_TotalActivityCost);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().TypeClear(obj_claims.ClaimRequestedAmount, RequestedAmount);
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

        public void EnterDetails_Claim_With_PreApproval(string RequestedAmount)
        {

            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimRequestedAmount);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbClaimDescription, "Claim Ref Number-1234");


                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));
                Pages.BasicInteractions().WaitTime(5);

                //Element not visible
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().TypeClear(obj_claims.ClaimVendorName, "Test");

                // Eligible Amount
                Pages.BasicInteractions().TypeClear(obj_claims.ClaimTotalActivityCost, Parameters.MS_TotalActivityCost);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().TypeClear(obj_claims.ClaimRequestedAmount, RequestedAmount);
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
                CommonUtilities.UploadFile(oBJ_Common.FileUploadInput, "CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                Pages.BasicInteractions().WaitUntilElementVisible(obj_claims.FileUploadedSuccessfully, 120);
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimComments);
                Pages.BasicInteractions().WaitVisible(obj_claims.BtnNext3);
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

                Pages.BasicInteractions().Click(obj_claims.CompletedStatusTabs);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_claims.PendingStatusTabs);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_claims.DeclinedStatusTabs);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Common.MoreDetailsLink, 120);
                Pages.BasicInteractions().Click(oBJ_Common.MoreDetailsLink);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Common.AuditTrailLink, 120);
                Pages.BasicInteractions().Click(oBJ_Common.AuditTrailLink);
                Pages.BasicInteractions().WaitVisible(oBJ_Common.AuditHistoryLabel);
                Assert.AreEqual(true, Pages.BasicInteractions().IsElementDisplayed(oBJ_Common.AuditHistoryLabel));
                Pages.BasicInteractions().Click(oBJ_Common.CloseButton);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Common.ClaimDetailsPageStatus, 120);
                string ExpectedStatus = Pages.BasicInteractions().GetText(oBJ_Common.ClaimDetailsPageStatus);
                Pages.BasicInteractions().Click(oBJ_Common.ViewButton);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                string ActualStatus = Pages.BasicInteractions().GetText(obj_claims.ClaimStatusOnClaimReviewPage);
                Assert.AreEqual(ExpectedStatus, ActualStatus);
                Console.WriteLine("Claim manage page is verified");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Validate_Claims method: " + ex.Message);
                throw;
            }

        }

        public string Create_Claim(String RequestedAmount, String InvoiceNumber, string preApproval_choice = "N", string PreApprovalID = null)
        {
            try
            {
                Masco_Claim_Fullflow(RequestedAmount, InvoiceNumber, preApproval_choice, PreApprovalID);
                string ClaimID = Submit_Claim();
                return ClaimID;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Create_Claim method: " + ex.Message);
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
                Pages.BasicInteractions().Click(obj_claims.SimpleSearchButton);
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

        public string Submit_Claim()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.BtnSubmit);
                if (Pages.BasicInteractions().IsElementPresent(obj_claims.ChbAknowledgeForDuplicateInvoice))
                {
                    Pages.BasicInteractions().Click(obj_claims.ChbAknowledgeForDuplicateInvoice);
                    Pages.BasicInteractions().WaitTime(5);
                }
                Pages.BasicInteractions().WaitVisible(obj_claims.BtnSubmit);
                Pages.BasicInteractions().Click(obj_claims.BtnSubmit);
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

        public void validate_Claim_ViewDetailed_Report(String ClaimType, String ExpectedRequestAmount, String ExpectedClaimID)
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(oBJ_Transactions.LeftNavDashboard);
                Pages.BasicInteractions().Click(oBJ_Transactions.LeftNavDashboard);
                Pages.BasicInteractions().WaitVisible(oBJ_Transactions.ViewDetailedReport);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(oBJ_Transactions.ViewDetailedReport);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                if (ClaimType == "Open")
                {
                    Pages.BasicInteractions().WaitVisible(oBJ_Transactions.OpenTab);
                    Pages.BasicInteractions().Click(oBJ_Transactions.OpenTab);
                }
                else
                {
                    Pages.BasicInteractions().WaitVisible(oBJ_Transactions.ApprovedTab);
                    Pages.BasicInteractions().Click(oBJ_Transactions.ApprovedTab);
                }

                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitVisible(oBJ_Transactions.FirstrowAmountOpenAndAppprovedClaimTab);
                String actualAmount = Pages.BasicInteractions().GetText(oBJ_Transactions.FirstrowAmountOpenAndAppprovedClaimTab).Split('$')[1];
                Console.WriteLine("Asserting Expected and Actual Requested Amount in validate_Claim_ViewDetailed_Report method");
                Assert.AreEqual(Double.Parse(ExpectedRequestAmount), actualAmount);

                Pages.BasicInteractions().Click(oBJ_Transactions.FirstrowAmountOpenAndAppprovedClaimTab);
                Console.WriteLine("Asserting Expected and Actual ClaimID  in validate_Claim_ViewDetailed_Report method");

                String actualClaimID = Pages.BasicInteractions().GetText(obj_claims.ClaimIDHeader);
                Assert.AreEqual(ExpectedClaimID, actualClaimID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in validate_Claim_ViewDetailed_Report method:" + ex.Message);
                throw;
            }
        }
    }
}
