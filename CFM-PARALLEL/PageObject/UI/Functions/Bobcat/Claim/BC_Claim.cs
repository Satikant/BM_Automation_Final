using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace CFM_PARALLEL.PageObject.UI.Functions.Bobcat
{
    class BC_Claim
    {
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private OBJ_Common oBJ_Common;
        //Constructor

        public BC_Claim()
        {
            obj_dashboard = new OBJ_Dashboard();
            obj_claims = new OBJ_Claims();
            oBJ_Common = new OBJ_Common();
        }


        //Claim Creation
        public string ClaimCreation(string bpa_choice = "N", string BPAID = null, string InvoiceNumber = "Claim-Invoice-1234")
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmitClaim);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmitClaim);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);

                SelectStoreAndProgram_Claim(bpa_choice, BPAID);

                //Entering Details
                EnterDetails_Claim(bpa_choice);

                //Adding Attachment
                AddingAttachment_Claim(InvoiceNumber);

                //SubmitClaim
                string ClaimID = SubmitClaim();
                return ClaimID;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }

        //Claim Creation
        public string ClaimCreation(string ClaimTotalActivityCost, string ClaimRequestedAmount, string bpa_choice = "N", string BPAID = null, string InvoiceNumber = "Claim-Invoice-1234")
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmitClaim);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmitClaim);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);


                SelectStoreAndProgram_Claim(bpa_choice, BPAID);

                //Entering Details
                EnterDetails_Claim(ClaimTotalActivityCost, ClaimRequestedAmount, bpa_choice);

                //Adding Attachment
                AddingAttachment_Claim(InvoiceNumber);

                //SubmitClaim
                string ClaimID = SubmitClaim();
                return ClaimID;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }

        public void ClaimCreateAndVerifyAvailableBalanceReduction()
        {
            try
            {
                double BeforeCreation = Convert.ToDouble(GetAvailableFunds(Parameters.Bobcat_ProgramName()).Replace("$", ""));
                ClaimCreation();
                NavigatingToDashBoard();
                double AfterCreation = Convert.ToDouble(GetAvailableFunds(Parameters.Bobcat_ProgramName()).Replace("$", ""));

                Assert.IsTrue(AfterCreation == (BeforeCreation - Convert.ToDouble(Parameters.ClaimRequestedAmount_Bobcat)));
                Console.WriteLine("The Claim Requested Amount is deducted from available Balance Correctly");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //Claim Clone
        public void ClaimClone(String ClaimID, string InvoiceNumber = "Claim-Invoice1234")
        {
            try
            {
                //Search the Claim
                SearchClaim(ClaimID);


                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().Click(obj_claims.ClaimSearchResult(ClaimID));
                //ClaimSearchResult.Click();
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.CloneButton);
                Pages.BasicInteractions().Click(obj_claims.CloneButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.BtnNext2);
                //Claim_ChooseProgram.NextButton.Click();
                Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);


                AddingAttachment_Claim(InvoiceNumber);

                //Submiting CloneClaim
                String ClaimIDAfterClone = SubmitClaim();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }


        //Claim perform Action
        public void ClaimPerformAction(String ClaimID, String Action)
        {
            try
            {
                //Search the Claim
                SearchClaim(ClaimID);

                Pages.BasicInteractions().Click(obj_claims.ClaimSearchResult(ClaimID));
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                if (Pages.BasicInteractions().IsElementPresent(obj_claims.ChbAknowledgeForDuplicateInvoice))
                {
                    Pages.BasicInteractions().Click(obj_claims.ChbAknowledgeForDuplicateInvoice);
                    Pages.BasicInteractions().WaitTime(5);
                }
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimResponseDropdown);
                Pages.BasicInteractions().Click(obj_claims.ClaimResponseDropdown);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.ClaimResponse(Action));
                if (Action.Equals("Approve"))
                {
                    Pages.BasicInteractions().Clear(obj_claims.ClaimApprovedAmount);
                    Pages.BasicInteractions().Type(obj_claims.ClaimApprovedAmount, Parameters.ClaimApprovalAmount_Bobcat);
                }
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimReviewCodeDropdown);
                Pages.BasicInteractions().Click(obj_claims.ClaimReviewCodeDropdown);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Type(obj_claims.ClaimReviewCodeText, Keys.Tab);

                Pages.BasicInteractions().Click(obj_claims.ClaimReviewCodeTextSelect);
                //Pages.BasicInteractions().Type(ClaimComments, "Claim-Perform Action Comments: " + action);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().ClickJavaScript(obj_claims.ClaimSendResponseButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);

                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_claims.SearchClaim);
                Pages.BasicInteractions().Clear(obj_claims.SearchClaim);

                Console.WriteLine(ClaimID + " - " + Action);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }


        //Claim perform Action
        public void ClaimApprovalAmountValidation(String ClaimID, String Action, string Reason)
        {


            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.LeftNavClaim);
                Pages.BasicInteractions().Click(obj_claims.LeftNavClaim);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);

                //**Advance Search functionality
                Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchLink);
                Pages.BasicInteractions().Click(obj_claims.AdvanceSearchLink);
                Pages.BasicInteractions().WaitVisible(obj_claims.PendingReviewCheckbox);
                Pages.BasicInteractions().Click(obj_claims.PendingReviewCheckbox);
                Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchClaimIDTextBox);
                Pages.BasicInteractions().Clear(obj_claims.AdvanceSearchClaimIDTextBox);
                Pages.BasicInteractions().Type(obj_claims.AdvanceSearchClaimIDTextBox, ClaimID);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().Click(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoadingClaim);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.ClaimSearchResult(ClaimID));
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);
                decimal strRequestedAmount = Convert.ToDecimal((Pages.BasicInteractions().GetText(obj_claims.ClaimRequestedAmount_bobcat).Split('$'))[1].ToString());
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimResponseDropdown);
                Pages.BasicInteractions().Click(obj_claims.ClaimResponseDropdown);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.ClaimResponse(Action));
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Clear(obj_claims.ClaimApprovedAmount);
                Pages.BasicInteractions().Type(obj_claims.ClaimApprovedAmount, (strRequestedAmount + 10).ToString());
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimSendResponseButton);
                Pages.BasicInteractions().Click(obj_claims.ClaimSendResponseButton);
                Pages.BasicInteractions().WaitTime(3);
                Assert.AreEqual(Pages.BasicInteractions().GetText(obj_claims.ApprovedAmountErrorMsg).ToString(), "Approved amount cannot be greater than Requested amount");
                Console.WriteLine("Approved amount field not accepting approved amount greater than Requested amount");
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Clear(obj_claims.ClaimApprovedAmount);
                Pages.BasicInteractions().Type(obj_claims.ClaimApprovedAmount, strRequestedAmount.ToString());
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.ClaimReviewCodeDropdown);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Type(obj_claims.ClaimReviewCodeText, Reason);
                Pages.BasicInteractions().Click(obj_claims.ClaimReviewCodeTextSelect);

                Pages.BasicInteractions().WaitTime(5);
                Assert.False(Pages.BasicInteractions().IsElementPresent(obj_claims.ApprovedAmountErrorMsg));

                Console.WriteLine("Approved amount field accepting approved amount when Requested amount and approved amount are same");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ACE_Claim_ApprovedAmountValidation " + ex);
                Assert.Fail("ACE_Claim_ApprovedAmountValidation " + ex);
            }
        }

        public void NavigatingToDashBoard()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.BtnDashBoard);
                Pages.BasicInteractions().Click(obj_claims.BtnDashBoard);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                Pages.BasicInteractions().WaitTime(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //Search Claim By ClaimID
        public void SearchClaim(String ClaimID)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_claims.LeftNavClaim);
                Pages.BasicInteractions().Click(obj_claims.LeftNavClaim);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoadingClaim);
                ////**Simple Search functionality
                //Wait.WaitVisible(SearchClaim);
                //SearchClaim.Clear();
                //SearchClaim.Type(ClaimId);
                //SearchClaim.Type(Keys.Enter);
                Pages.BasicInteractions().WaitTime(5);

                //**Advance Search functionality
                Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchLink);
                Pages.BasicInteractions().Click(obj_claims.AdvanceSearchLink);
                Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchClaimIDTextBox);
                Pages.BasicInteractions().TypeClear(obj_claims.AdvanceSearchClaimIDTextBox, ClaimID);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().Click(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.LoadingImageClaim);
                if (Pages.BasicInteractions().IsElementVisible(obj_claims.TblEmptyMessage))
                {
                    Console.WriteLine(" Claim Not Available");
                }
                else
                {
                    ClaimID = Pages.BasicInteractions().GetText(obj_claims.TblCalimFirstRowClaimID);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }
        //Search and Get Pending Claims
        public String SearchAndGetPendingClaim()
        {
            try
            {
                String ClaimID = null;
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_claims.LeftNavClaim);
                Pages.BasicInteractions().Click(obj_claims.LeftNavClaim);
                //Pages.BasicInteractions().WaitTime(30);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);

                ////**Simple Search functionality
                //Wait.WaitVisible(SearchClaim);
                //SearchClaim.Clear();
                //SearchClaim.Type(ClaimId);
                //SearchClaim.Type(Keys.Enter);
                //Wait.WaitTime(10);

                //**Advance Search functionality
                Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchLink);
                Pages.BasicInteractions().Click(obj_claims.AdvanceSearchLink);
                Pages.BasicInteractions().WaitVisible(obj_claims.ApprovedCheckbox);
                Pages.BasicInteractions().Click(obj_claims.PendingPaymentCheckbox);

                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().Click(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.LoadingImageClaim);
                if (Pages.BasicInteractions().IsElementVisible(obj_claims.TblEmptyMessage))
                {
                    Console.WriteLine("No Pending Claims Available");
                }
                else
                {
                    ClaimID = Pages.BasicInteractions().GetText(obj_claims.TblCalimFirstRowClaimID);
                }
                return ClaimID;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }

        }

        //Claim Validation 
        public void Bobcat_Claim_Fullflow(string InvoiceNumber = "Claim-Invoice-1234")
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
                EnterDetails_Claim1();


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

            Pages.BasicInteractions().Click(Pages.Dashboard_Landing().CompletedStatusTabs);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

            Pages.BasicInteractions().Click(Pages.Dashboard_Landing().PendingStatusTabs);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

            Pages.BasicInteractions().Click(Pages.Dashboard_Landing().DeclinedStatusTabs);
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
        }

        public void FillClaimDetails(string InvoiceNumber = "Claim-Invoice-1234")
        {
            try
            {
                //Select store and Program
                SelectStoreAndProgram_Claim();

                //Entering Details
                EnterDetails_Claim();

                //Adding Attachment
                AddingAttachment_Claim(InvoiceNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void SelectStoreAndProgram_Claim(string bpa_choice = "N", string bpa = null)
        {
            try
            {
                if (Pages.BasicInteractions().IsElementVisible(obj_claims.BPAForClaimYes) | Pages.BasicInteractions().IsElementVisible(obj_claims.BPAForClaimNo))
                {
                    //opting for BPA
                    if (bpa_choice == "Y")
                    {
                        Pages.BasicInteractions().WaitTime(10);
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
                        Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                        Pages.BasicInteractions().WaitVisible(obj_claims.ClaimDropdown);
                        Pages.BasicInteractions().Click(obj_claims.ClaimDropdown);
                        Pages.BasicInteractions().WaitVisible(obj_claims.ClaimText);
                        Pages.BasicInteractions().Type(obj_claims.ClaimText, Parameters.Bobcat_Test_LME());
                        Pages.BasicInteractions().Type(obj_claims.ClaimText, Keys.Enter);

                        Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                        Pages.BasicInteractions().WaitVisible(obj_claims.CoopProgram);
                        Pages.BasicInteractions().Click(obj_claims.CoopProgram);
                        Pages.BasicInteractions().WaitVisible(obj_claims.CoopProgramText);

                        if (Parameters.Bobcat_ProgramName() != null)
                        {
                            Pages.BasicInteractions().TypeClear(obj_claims.CoopProgramText, Parameters.Bobcat_ProgramName());
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
                        Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchStoreName, Parameters.Bobcat_Test_LME());
                        Pages.BasicInteractions().Type(obj_claims.TxbSearchStoreName, Keys.Enter);

                        Pages.BasicInteractions().WaitVisible(obj_claims.DdlProgramName);
                        Pages.BasicInteractions().Click(obj_claims.DdlProgramName);
                        Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchProgramName, Parameters.Bobcat_ProgramName());
                        Pages.BasicInteractions().Type(obj_claims.TxbSearchProgramName, Keys.Enter);
                    }
                    else
                    {
                        Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchStoreName, Parameters.Bobcat_Test_LME());
                        Pages.BasicInteractions().Type(obj_claims.TxbSearchStoreName, Keys.Enter);

                        Pages.BasicInteractions().WaitVisible(obj_claims.DdlProgramName);
                        Pages.BasicInteractions().Click(obj_claims.DdlProgramName);
                        Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchProgramName, Parameters.Bobcat_ProgramName());
                        Pages.BasicInteractions().Type(obj_claims.TxbSearchProgramName, Keys.Enter);
                    }
                    Pages.BasicInteractions().WaitVisible(obj_claims.BtnNext1);
                    Pages.BasicInteractions().Click(obj_claims.BtnNext1);
                    Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }
        public decimal EnterDetails_Claim(string bpa_choice = "N")
        {
            string EligibleAmount;
            decimal RequestedAmount;
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimRequestedAmount);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbClaimDescription, "Claim Ref Number-1234");

                if (bpa_choice == "N")
                {
                    Pages.BasicInteractions().WaitVisible(obj_claims.DdlMediaType);
                    Pages.BasicInteractions().Click(obj_claims.DdlMediaType);

                    Pages.BasicInteractions().WaitVisible(obj_claims.TxbsearchMediaType);
                    Pages.BasicInteractions().TypeClear(obj_claims.TxbsearchMediaType, "Print");
                    Pages.BasicInteractions().Type(obj_claims.TxbsearchMediaType, Keys.Enter);

                    Pages.BasicInteractions().WaitVisible(obj_claims.DdlTactic);
                    Pages.BasicInteractions().Click(obj_claims.DdlTactic);

                    Pages.BasicInteractions().WaitVisible(obj_claims.TxbsearchTactic);
                    Pages.BasicInteractions().TypeClear(obj_claims.TxbsearchTactic, "Direct Mail");
                    Pages.BasicInteractions().Type(obj_claims.TxbsearchTactic, Keys.Enter);
                }

                Pages.BasicInteractions().Click(obj_claims.RbtnDataEquipmentNO);

                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));
                Pages.BasicInteractions().WaitTime(1);

                //Element not visible
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                Pages.BasicInteractions().WaitTime(1);

                Pages.BasicInteractions().TypeClear(obj_claims.ClaimVendorName, "Test");
                //Get Eligible Amount
                Pages.BasicInteractions().TypeClear(obj_claims.ClaimTotalActivityCost, Parameters.ClaimTotalActivityCost_Bobcat);

                EligibleAmount = Pages.BasicInteractions().GetAttribute(obj_claims.EligibleAmount_bobcat, "value");
                Pages.BasicInteractions().WaitTime(3);

                //Requested Amount is calculting like Eligible Amount;
                if (Pages.BasicInteractions().IsElementPresent(obj_claims.ReqAmountConverted))
                {
                    RequestedAmount = Convert.ToDecimal(Pages.BasicInteractions().GetAttribute(obj_claims.ReqAmountConverted, "value"));
                }
                else
                {
                    RequestedAmount = Convert.ToDecimal(EligibleAmount);
                }
                Pages.BasicInteractions().WaitTime(5);
                return RequestedAmount;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void EnterDetails_Claim1(string bpa_choice = "N")
        {
            //string EligibleAmount;           
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimRequestedAmount);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbClaimDescription, "Claim Ref Number-1234");

                if (bpa_choice == "N")
                {
                    Pages.BasicInteractions().WaitVisible(obj_claims.DdlMediaType);
                    Pages.BasicInteractions().Click(obj_claims.DdlMediaType);

                    Pages.BasicInteractions().WaitVisible(obj_claims.TxbsearchMediaType);
                    Pages.BasicInteractions().TypeClear(obj_claims.TxbsearchMediaType, "Print");
                    Pages.BasicInteractions().Type(obj_claims.TxbsearchMediaType, Keys.Enter);

                    Pages.BasicInteractions().WaitVisible(obj_claims.DdlTactic);
                    Pages.BasicInteractions().Click(obj_claims.DdlTactic);

                    Pages.BasicInteractions().WaitVisible(obj_claims.TxbsearchTactic);
                    Pages.BasicInteractions().TypeClear(obj_claims.TxbsearchTactic, "Direct Mail");
                    Pages.BasicInteractions().Type(obj_claims.TxbsearchTactic, Keys.Enter);
                }

                Pages.BasicInteractions().Click(obj_claims.RbtnDataEquipmentNO);

                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));

                //Element not visible
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                Pages.BasicInteractions().WaitTime(2);

                Pages.BasicInteractions().TypeClear(obj_claims.ClaimVendorName, "Test");
                //Get Eligible Amount
                Pages.BasicInteractions().TypeClear(obj_claims.ClaimTotalActivityCost, Parameters.ClaimTotalActivityCost_Bobcat);
                Pages.BasicInteractions().WaitTime(2);

                //EligibleAmount = Pages.BasicInteractions().GetAttribute(obj_claims.EligibleAmount_bobcat, "value");
                Pages.BasicInteractions().TypeClear(obj_claims.ClaimRequestedAmount, Parameters.ClaimRequestedAmount_Bobcat);
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimAcknowledgement);
                Pages.BasicInteractions().Click(obj_claims.ClaimAcknowledgement);
                Pages.BasicInteractions().WaitVisible(obj_claims.BtnNext2);
                Pages.BasicInteractions().Click(obj_claims.BtnNext2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public decimal EnterDetails_Claim(String ClaimTotalActivityCost, string ClaimRequestedamount, string bpa_choice = "N")
        {
            string EligibleAmount = null;
            decimal RequestedAmount;
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimRequestedAmount);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbClaimDescription, "Claim Ref Number-1234");

                if (bpa_choice == "N")
                {
                    Pages.BasicInteractions().WaitVisible(obj_claims.DdlMediaType);
                    Pages.BasicInteractions().Click(obj_claims.DdlMediaType);

                    Pages.BasicInteractions().WaitVisible(obj_claims.TxbsearchMediaType);
                    Pages.BasicInteractions().TypeClear(obj_claims.TxbsearchMediaType, "Print");
                    Pages.BasicInteractions().Type(obj_claims.TxbsearchMediaType, Keys.Enter);

                    Pages.BasicInteractions().WaitVisible(obj_claims.DdlTactic);
                    Pages.BasicInteractions().Click(obj_claims.DdlTactic);

                    Pages.BasicInteractions().WaitVisible(obj_claims.TxbsearchTactic);
                    Pages.BasicInteractions().TypeClear(obj_claims.TxbsearchTactic, "Direct Mail");
                    Pages.BasicInteractions().Type(obj_claims.TxbsearchTactic, Keys.Enter);
                }

                Pages.BasicInteractions().Click(obj_claims.RbtnDataEquipmentNO);

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

                //Get Eligible Amount
                Pages.BasicInteractions().TypeClear(obj_claims.ClaimTotalActivityCost, Parameters.ClaimTotalActivityCost_Bobcat);

                EligibleAmount = Pages.BasicInteractions().GetAttribute(obj_claims.EligibleAmount, "value");

                Pages.BasicInteractions().TypeClear(obj_claims.ClaimRequestedAmount, EligibleAmount);
                Pages.BasicInteractions().WaitTime(10);

                if (Pages.BasicInteractions().IsElementDisplayed(obj_claims.ReqAmountConverted))
                {
                    RequestedAmount = Convert.ToDecimal(Pages.BasicInteractions().GetAttribute(obj_claims.ReqAmountConverted, "value"));
                }
                else
                {
                    RequestedAmount = Convert.ToDecimal(EligibleAmount) - 100;
                }
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.ClaimAcknowledgement);
                Pages.BasicInteractions().Click(obj_claims.BtnNext2);

                return RequestedAmount;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error Message: " + ex.Message);
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
                Pages.BasicInteractions().Type(obj_claims.ClaimComments, "Claim-Comments");
                Pages.BasicInteractions().WaitUntilElementVisible(obj_claims.BtnNext3,120);
                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().Click(obj_claims.BtnNext3);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().IsElementDisplayed(obj_claims.BtnSubmit);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void ClaimDateValidation()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmitClaim);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmitClaim);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);

                //Selecting a Program and stroe for claim
                SelectStoreAndProgram_Claim();

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimRequestedAmount);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbClaimDescription, "Claim Ref Number-1234");

                Pages.BasicInteractions().WaitVisible(obj_claims.DdlMediaType);
                Pages.BasicInteractions().Click(obj_claims.DdlMediaType);

                Pages.BasicInteractions().WaitVisible(obj_claims.TxbsearchMediaType);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbsearchMediaType, "Print");
                Pages.BasicInteractions().Type(obj_claims.TxbsearchMediaType, Keys.Enter);

                Pages.BasicInteractions().WaitVisible(obj_claims.DdlTactic);
                Pages.BasicInteractions().Click(obj_claims.DdlTactic);

                Pages.BasicInteractions().WaitVisible(obj_claims.TxbsearchTactic);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbsearchTactic, "Direct Mail");
                Pages.BasicInteractions().Type(obj_claims.TxbsearchTactic, Keys.Enter);

                Pages.BasicInteractions().Click(obj_claims.RbtnDataEquipmentNO);

                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().WaitTime(5);
                //ClaimStartDateSelection("April 22, 2018").Click();
                Pages.BasicInteractions().Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateValidation_StartDate()));
                Pages.BasicInteractions().WaitTime(5);

                //Element not visible
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().WaitTime(1);
                //ClaimEndDateSelection("April 29, 2018").Click();
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateValidation_EndDate()));
                Pages.BasicInteractions().WaitTime(5);

                Assert.AreEqual(Pages.BasicInteractions().GetText(obj_claims.EndDateErrorMsg).ToString(), "End date cannot be less than Start date");
                Console.WriteLine("Claim Date Validation is throwing error when End Date is less than Start Date");
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                Pages.BasicInteractions().WaitTime(3);
                Assert.False(Pages.BasicInteractions().IsElementPresent(obj_claims.EndDateErrorMsg));
                //{
                Console.WriteLine("Claim Date Validation is working fine when End Date is greater than Start Date");
                //}

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }


        public string SubmitClaim()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(10);
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


                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }

        //Get Available Funds for Program
        public String GetAvailableFunds(string ProgramName)
        {

            try
            {
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(10);
                if (Pages.BasicInteractions().IsElementDisplayed(obj_claims.ProgramList(ProgramName)))
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_claims.ProgramList(ProgramName));

                }
                else
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().WaitVisible(obj_claims.OtherProgramsLink);
                    Pages.BasicInteractions().Click(obj_claims.OtherProgramsLink);
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_claims.ProgramList(ProgramName));
                }
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.LoadingImageSnapShot);
                Pages.BasicInteractions().WaitTime(10);
                string AvailableFund = Pages.BasicInteractions().GetText(obj_claims.AvailableFunds);

                if (AvailableFund.Contains("(") | AvailableFund.Contains(")"))
                {
                    AvailableFund = "-" + AvailableFund.Replace("(", "").Replace(")", "");
                }
                return AvailableFund;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }


        //Claim perform Action
        public void ClaimApprove(String ClaimID, String Action, string Reason, string Amount)
        {
            try
            {
                //Search the Claim
                SearchClaim(ClaimID);

                Pages.BasicInteractions().Click(obj_claims.ClaimSearchResult(ClaimID));
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);

                if (Pages.BasicInteractions().IsElementPresent(obj_claims.ChbAknowledgeForDuplicateInvoice))
                {
                    Pages.BasicInteractions().Click(obj_claims.ChbAknowledgeForDuplicateInvoice);
                    Pages.BasicInteractions().WaitTime(5);
                }
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimResponseDropdown);
                Pages.BasicInteractions().Click(obj_claims.ClaimResponseDropdown);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.ClaimResponse(Action));
                if (Action.Equals("Approve"))
                {
                    Pages.BasicInteractions().Clear(obj_claims.ClaimApprovedAmount);
                    Pages.BasicInteractions().Type(obj_claims.ClaimApprovedAmount, Amount);
                }
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimSendResponseButton);
                Pages.BasicInteractions().Click(obj_claims.ClaimReviewCodeDropdown);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Type(obj_claims.ClaimReviewCodeText, Reason);
                Pages.BasicInteractions().Click(obj_claims.ClaimReviewCodeTextSelect);
                Pages.BasicInteractions().WaitTime(2);


                Pages.BasicInteractions().Click(obj_claims.ClaimSendResponseButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);

                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_claims.SearchClaim);
                Pages.BasicInteractions().Clear(obj_claims.SearchClaim);

                Console.WriteLine(ClaimID + " - " + Action);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }


        }

        public string ClaimResubmitted(string ClaimID)
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.LeftNavClaim);
                Pages.BasicInteractions().Click(obj_claims.LeftNavClaim);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoadingClaim);
                Pages.BasicInteractions().WaitTime(10);

                //**Simple Search functionality
                Pages.BasicInteractions().WaitVisible(obj_claims.SearchClaim);
                Pages.BasicInteractions().Clear(obj_claims.SearchClaim);
                Pages.BasicInteractions().Type(obj_claims.SearchClaim, ClaimID);
                //SearchClaim.Type(Keys.Enter);
                //Wait.WaitTime(10);

                //**Advance Search functionality
                //Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchLink);
                //Pages.BasicInteractions().Click(obj_claims.AdvanceSearchLink);
                ////Pages.BasicInteractions().WaitVisible(obj_claims.NeedsInformationCheckbox);
                ////Pages.BasicInteractions().Click(obj_claims.NeedsInformationCheckbox);
                //Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().Clear(obj_claims.AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().Type(obj_claims.AdvanceSearchClaimIDTextBox, ClaimID);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().Click(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoadingClaim);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.ClaimSearchResult(ClaimID));
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.EditClaimButton);
                Pages.BasicInteractions().Click(obj_claims.EditClaimButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.NextButton);
                Pages.BasicInteractions().WaitTime(5);
                AddingAttachment_Claim("Claim-Invoice-1234");
                Pages.BasicInteractions().WaitTime(5);
                string ReSubmittedClaimID = SubmitClaim();
                return ReSubmittedClaimID;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }


        //Claim Disapprove
        public void ClaimDeny(String ClaimID, String Action, string Reason)
        {
            try
            {
                //Search the Claim
                SearchClaim(ClaimID);

                Pages.BasicInteractions().Click(obj_claims.ClaimSearchResult(ClaimID));
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);

                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimResponseDropdown);
                Pages.BasicInteractions().Click(obj_claims.ClaimResponseDropdown);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.ClaimResponse(Action));
                if (Action.Equals("Approve"))
                {
                    Pages.BasicInteractions().Clear(obj_claims.ClaimApprovedAmount);
                    Pages.BasicInteractions().Type(obj_claims.ClaimApprovedAmount, Parameters.ClaimApprovalAmount_Bobcat);
                }
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimSendResponseButton);
                Pages.BasicInteractions().Click(obj_claims.ClaimReviewCodeDropdown);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Type(obj_claims.ClaimReviewCodeText, Reason);
                Pages.BasicInteractions().Click(obj_claims.ClaimReviewCodeTextSelect);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_claims.ClaimSendResponseButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);

                Pages.BasicInteractions().WaitVisible(obj_claims.SearchClaim);
                Pages.BasicInteractions().Clear(obj_claims.SearchClaim);

                Console.WriteLine(ClaimID + " - " + Action);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //Search Claim By ClaimID And GetStatus
        public string SearchClaimAndGetStatus(String ClaimID)
        {
            string ClaimStatus = string.Empty;
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_claims.LeftNavClaim);
                Pages.BasicInteractions().Click(obj_claims.LeftNavClaim);
                //Pages.BasicInteractions().WaitTime(30);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoadingClaim);
                ////**Simple Search functionality
                Pages.BasicInteractions().WaitVisible(obj_claims.SearchClaim);
                Pages.BasicInteractions().Clear(obj_claims.SearchClaim);
                Pages.BasicInteractions().Type(obj_claims.SearchClaim, ClaimID);
                Pages.BasicInteractions().Type(obj_claims.SearchClaim, Keys.Enter);
                Pages.BasicInteractions().WaitTime(3);

                //**Advance Search functionality
                //Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchLink);
                //Pages.BasicInteractions().Click(obj_claims.AdvanceSearchLink);
                //Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().TypeClear(obj_claims.AdvanceSearchClaimIDTextBox, ClaimID);
                //Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().Click(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.LoadingImageClaim);
                if (Pages.BasicInteractions().IsElementVisible(obj_claims.TblEmptyMessage))
                {
                    Console.WriteLine(" Claim Not Available");
                }
                else
                {
                    ClaimStatus = Pages.BasicInteractions().GetText(obj_claims.TblClaimFirstRowStatus);
                }
                return ClaimStatus;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }


        public void ClaimApprovalPermissionValidationNotAvailableForLME(string ClaimId)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.LeftNavClaim);
                Pages.BasicInteractions().Click(obj_claims.LeftNavClaim);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);

                //**Simple Search functionality
                Pages.BasicInteractions().WaitVisible(obj_claims.SearchClaim);
                Pages.BasicInteractions().Clear(obj_claims.SearchClaim);
                Pages.BasicInteractions().Type(obj_claims.SearchClaim, ClaimId);
                //SearchClaim.Type(Keys.Enter);
                //Wait.WaitTime(10);

                //**Advance Search functionality
                //Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchLink);
                //Pages.BasicInteractions().Click(obj_claims.AdvanceSearchLink);
                ////Pages.BasicInteractions().WaitVisible(obj_claims.PendingReviewCheckbox);
                ////Pages.BasicInteractions().Click(obj_claims.PendingReviewCheckbox);
                //Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().Clear(obj_claims.AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().Type(obj_claims.AdvanceSearchClaimIDTextBox, ClaimId);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().Click(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoadingClaim);
                Pages.BasicInteractions().Click(obj_claims.ClaimSearchResult(ClaimId));
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);

                Assert.False(Pages.BasicInteractions().IsElementPresent(obj_claims.ClaimResponseDropdown));

                Console.WriteLine("Claim: " + BrowserURLLaunch.ROLES + "  doesnt have the option to Approve/Deny/Hold/Needs Information access");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
                throw;
            }
        }


        public void ClaimCreation_Negative()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.LeftNavClaim);
                Pages.BasicInteractions().Click(obj_claims.LeftNavClaim);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                Pages.BasicInteractions().WaitTime(10);
                if (!Pages.BasicInteractions().IsElementPresent(obj_claims.SubmitClaim_Claims))
                {
                    Console.WriteLine("Cannot create Claims, link to create Claims is not present in the application");
                }
                else
                {
                    Pages.BasicInteractions().Click(obj_claims.SubmitClaim_Claims);
                    Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                    Pages.BasicInteractions().WaitTime(5);

                    //**Choose Program stepper
                    Pages.BasicInteractions().WaitVisible(obj_claims.BPAForClaimNo);
                    Pages.BasicInteractions().Click(obj_claims.BPAForClaimNo);
                    Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                    Pages.BasicInteractions().WaitTime(5);
                    if (BrowserURLLaunch.ROLES.Equals("CORPORATE1") || BrowserURLLaunch.ROLES.Equals("CORPORATE2"))
                    {
                        Pages.BasicInteractions().WaitVisible(obj_claims.ClaimDropdown);
                        Pages.BasicInteractions().Click(obj_claims.ClaimDropdown);
                        Pages.BasicInteractions().Type(obj_claims.ClaimText, Parameters.Bobcat_Test_LME());
                        Pages.BasicInteractions().Type(obj_claims.ClaimText, Keys.Enter);

                        Console.WriteLine("CLAIM NEGATIVE: Store selected");
                    }

                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().WaitVisible(obj_claims.DdlProgramName);
                    Pages.BasicInteractions().Click(obj_claims.DdlProgramName);
                    Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchProgramName, Parameters.Bobcat_ProgramName());
                    Pages.BasicInteractions().Type(obj_claims.TxbSearchProgramName, Keys.Enter);
                    Console.WriteLine("CLAIM NEGATIVE: Program selected");

                    Pages.BasicInteractions().WaitVisible(obj_claims.NextButton);
                    Pages.BasicInteractions().Click(obj_claims.NextButton);

                    //**Enter Details stepper
                    Pages.BasicInteractions().WaitVisible(obj_claims.BtnNext2);
                    Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                    Pages.BasicInteractions().Clear(obj_claims.ClaimReference);
                    Pages.BasicInteractions().Type(obj_claims.ClaimReference, "REF-1234");
                    Pages.BasicInteractions().WaitVisible(obj_claims.DdlMediaType);
                    Pages.BasicInteractions().Click(obj_claims.DdlMediaType);

                    Pages.BasicInteractions().WaitVisible(obj_claims.TxbsearchMediaType);
                    Pages.BasicInteractions().TypeClear(obj_claims.TxbsearchMediaType, "Print");
                    Pages.BasicInteractions().Type(obj_claims.TxbsearchMediaType, Keys.Enter);

                    Pages.BasicInteractions().WaitVisible(obj_claims.DdlTactic);
                    Pages.BasicInteractions().WaitVisible(obj_claims.BtnNext2);
                    Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                    Pages.BasicInteractions().WaitTime(5);
                    if (Pages.BasicInteractions().IsElementPresent(obj_claims.ErrorActivityTypeRequired_bobcat))
                    {
                        Pages.BasicInteractions().WaitVisible(obj_claims.DdlTactic);
                        Pages.BasicInteractions().Click(obj_claims.DdlTactic);

                        Pages.BasicInteractions().WaitVisible(obj_claims.TxbsearchTactic);
                        Pages.BasicInteractions().TypeClear(obj_claims.TxbsearchTactic, "Direct Mail");
                        Pages.BasicInteractions().Type(obj_claims.TxbsearchTactic, Keys.Enter);
                        Console.WriteLine("CLAIM NEGATIVE: Activity Selected for Claim");
                    }

                    Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                    if (Pages.BasicInteractions().IsElementPresent(obj_claims.ErrorStartDateRequired))
                    {
                        Pages.BasicInteractions().WaitVisible(obj_claims.ClaimStartdate);
                        Pages.BasicInteractions().Click(obj_claims.ClaimStartdate);

                        Pages.BasicInteractions().Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));
                        Pages.BasicInteractions().WaitTime(5);
                        Console.WriteLine("CLAIM NEGATIVE: Start Date selected for Claim");

                    }

                    Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                    if (Pages.BasicInteractions().IsElementPresent(obj_claims.ErrorEndDateRequired))
                    {
                        //Element not visible
                        Pages.BasicInteractions().WaitVisible(obj_claims.ClaimEndDate);
                        Pages.BasicInteractions().Click(obj_claims.ClaimEndDate);
                        Pages.BasicInteractions().WaitTime(5);
                        //ClaimEndDateSelection("April 29, 2018").Click();
                        Pages.BasicInteractions().Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                        Pages.BasicInteractions().WaitTime(5);
                        Console.WriteLine("CLAIM NEGATIVE: End Date selected for Claim");
                    }

                    Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                    if (Pages.BasicInteractions().IsElementPresent(obj_claims.ErrorTotalActivityCostReq))
                    {
                        Pages.BasicInteractions().Type(obj_claims.ClaimTotalActivityCost, Parameters.ClaimTotalActivityCost_Bobcat);
                        Console.WriteLine("CLAIM NEGATIVE: Total Activity Cost entered for Claim");
                    }

                    Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                    if (Pages.BasicInteractions().IsElementPresent(obj_claims.ErrorClaimFeatureReq))
                    {
                        Pages.BasicInteractions().Click(obj_claims.RbtnDataEquipmentNO);
                        Console.WriteLine("CLAIM NEGATIVE: ClaimFeature Selected");

                    }
                    Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                    if (Pages.BasicInteractions().IsElementPresent(obj_claims.ErrorVendorNameReq))
                    {
                        Pages.BasicInteractions().TypeClear(obj_claims.ClaimVendorName, "Test");
                        Console.WriteLine("CLAIM NEGATIVE: VendorName entered for Claim");

                    }
                    Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                    if (Pages.BasicInteractions().IsElementPresent(obj_claims.ErrorRequestedAmountReq))
                    {
                        Pages.BasicInteractions().Type(obj_claims.ClaimRequestedAmount, Parameters.ClaimRequestedAmount_Bobcat);
                        Console.WriteLine("CLAIM NEGATIVE: Requested Amount entered for Claim");
                    }
                    Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                    if (Pages.BasicInteractions().IsElementPresent(obj_claims.ErrorAknowledgementReq))
                    {
                        Pages.BasicInteractions().Click(obj_claims.ClaimAcknowledgement);
                        Console.WriteLine("CLAIM NEGATIVE: ClaimAknowledgement  Selected");

                    }
                    Pages.BasicInteractions().WaitVisible(obj_claims.BtnNext2);
                    Pages.BasicInteractions().Click(obj_claims.BtnNext2);

                    //**Attach Document
                    Pages.BasicInteractions().WaitVisible(obj_claims.BtnNext3);
                    Pages.BasicInteractions().ClickJavaScript(obj_claims.BtnNext3);
                    if (Pages.BasicInteractions().IsElementPresent(obj_claims.ErrorInvoiceRequired))
                    {
                        Pages.BasicInteractions().WaitVisible(obj_claims.ClaimComments);
                        Pages.BasicInteractions().Type(obj_claims.ClaimInvoice, "Claim-Invoice-1234");
                        Pages.BasicInteractions().WaitTime(5);
                        Console.WriteLine("CLAIM NEGATIVE: Invoice number entered");
                    }

                    Pages.BasicInteractions().Click(obj_claims.BtnNext3);
                    if (Pages.BasicInteractions().IsElementPresent(obj_claims.ErrorAttachmentRequired_bobcat))
                    {
                        Pages.BasicInteractions().WaitVisible(obj_claims.ClaimUpload);
                        Pages.BasicInteractions().Click(obj_claims.ClaimUpload);
                        Pages.BasicInteractions().WaitTime(3);
                        //File Upload
                        CommonUtilities.UploadFileInChrome("CoOpGuidelines_LCP_2018_Q1_R6.pdf");

                        if (Pages.BasicInteractions().IsElementPresent(obj_claims.AttachementRemove))
                        {
                            Console.WriteLine("CLAIM NEGATIVE: Attachment added for " + BrowserURLLaunch.ROLES);
                        }
                        else
                        {
                            Console.WriteLine("CLAIM NEGATIVE: Attachement not attached");
                        }
                    }
                    else
                    {
                        Console.WriteLine("CLAIM NEGATIVE: Attachment Error message not shown");
                    }

                    Pages.BasicInteractions().WaitVisible(obj_claims.ClaimComments);
                    Pages.BasicInteractions().Type(obj_claims.ClaimComments, "Claim-Comments");
                    Pages.BasicInteractions().WaitVisible(obj_claims.BtnNext3);
                    Pages.BasicInteractions().Click(obj_claims.BtnNext3);
                    Pages.BasicInteractions().WaitTime(5);
                    //Review and Submit
                    if (Pages.BasicInteractions().IsElementPresent(obj_claims.SubmitButton))
                    {
                        Console.WriteLine("CLAIM NEGATIVE: Submit Button for submitting a Claim is present");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }
        }

        public void Create_BulkClaim()
        {
            try
            {
                Pages.BasicInteractions().WaitUntilElementVisible(obj_dashboard.BtnSubmit, 120);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmitBulkClaim);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmitBulkClaim);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_claims.UploadBulkClaim, 120);
                CommonUtilities.UploadFile(oBJ_Common.FileUploadInput, "BulkClaim.xlsx");
                Pages.BasicInteractions().WaitUntilElementVisible(obj_claims.ConfirmBulkUploadButton, 120);
                Pages.BasicInteractions().Click(obj_claims.ConfirmBulkUploadButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                Pages.BasicInteractions().WaitVisible(obj_claims.SuccessfulMessage);
                Console.WriteLine(Pages.BasicInteractions().GetText(obj_claims.SuccessfulMessage));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Messagewith an exception in Create_BulkClaim : " + ex.Message);
                throw;
            }
        }
    }
}
