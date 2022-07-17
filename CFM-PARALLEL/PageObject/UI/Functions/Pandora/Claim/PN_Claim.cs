using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFM_PARALLEL.PageObject.UI.Functions.Pandora
{
    public class PN_Claim
    {
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private OBJ_Common oBJ_Common;
        private OBJ_Claims oBJ_Claims;
        

        //Constructor
        public PN_Claim()
        {
            obj_dashboard = new OBJ_Dashboard();
            obj_claims = new OBJ_Claims();
            oBJ_Common = new OBJ_Common();
            oBJ_Claims = new OBJ_Claims();
        }

        //Claim Creation
        public string ClaimCreation(string TotalActivityCost)
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmitClaim);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmitClaim);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                //Fill details of Claim
                FillClaimDetails(TotalActivityCost);

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


        //Claim Clone
        public void ClaimClone(String ClaimID)
        {
            try
            {
                //Search the Claim
                SearchClaim(ClaimID);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().Click(obj_claims.ClaimSearchResult(ClaimID));
                //ClaimSearchResult.Click();
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.CloneButton);
                Pages.BasicInteractions().Click(obj_claims.CloneButton);
                Pages.BasicInteractions().WaitTime(15);
                //Claim_ChooseProgram.NextButton.Click();
                Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);


                //Entering Details
                //EnterDetails_Claim(Parameters.ClaimTotalActivityCost_Pandora, Parameters.ClaimRequestedAmount_Pandora);
                //Attaching Document
                AddingAttachment_Claim();

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
                Pages.BasicInteractions().WaitTime(20);
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimResponseDropdown);
                Pages.BasicInteractions().Click(obj_claims.ClaimResponseDropdown);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().Click(obj_claims.ClaimResponse(Action));
                decimal strRequestedAmount = Convert.ToDecimal((Pages.BasicInteractions().GetText(obj_claims.ClaimRequestedAmount_bobcat).Split('$')[1]).ToString());

                if (Action.Equals("Approve"))
                {
                    Pages.BasicInteractions().Clear(obj_claims.ClaimApprovedAmount);
                    Pages.BasicInteractions().Type(obj_claims.ClaimApprovedAmount, strRequestedAmount.ToString());
                }
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimSendResponseButton);
                Pages.BasicInteractions().Click(obj_claims.ClaimReviewCodeDropdown);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Type(obj_claims.ClaimReviewCodeText, Keys.Tab);

                Pages.BasicInteractions().Click(obj_claims.ClaimReviewCodeTextSelect);
                //Pages.BasicInteractions().Type(ClaimComments, "Claim-Perform Action Comments: " + action);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_claims.ClaimSendResponseButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);

                //Pages.BasicInteractions().WaitTime(30);
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
        public void NavigatingToDashBoard()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.BtnDashBoard);
                Pages.BasicInteractions().Click(obj_claims.BtnDashBoard);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
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
                //Pages.BasicInteractions().WaitTime(30);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.LoadingImageClaim);
                ////**Simple Search functionality
                Pages.BasicInteractions().WaitVisible(obj_claims.SearchClaim);
                Pages.BasicInteractions().Clear(obj_claims.SearchClaim);
                Pages.BasicInteractions().Type(obj_claims.SearchClaim, ClaimID);
                //Pages.BasicInteractions().Type(obj_claims.SearchClaim,Keys.Enter);
                //Pages.BasicInteractions().WaitTime(5);

                //**Advance Search functionality
                //Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchLink);
                //Pages.BasicInteractions().Click(obj_claims.AdvanceSearchLink);
                //Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().TypeClear(obj_claims.AdvanceSearchClaimIDTextBox, ClaimID);
                //Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().Click(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().WaitTime(20);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.LoadingImageClaim);
                if (Pages.BasicInteractions().IsElementVisible(obj_claims.TblEmptyMessage))
                {
                    Console.WriteLine(" Claim Not Available");
                }
                else
                {
                    Console.WriteLine("Claim Available");
                    ClaimID = Pages.BasicInteractions().GetText(obj_claims.TblCalimFirstRowClaimID);
                }
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
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.LeftNavClaim);
                Pages.BasicInteractions().Click(obj_claims.LeftNavClaim);
                //Pages.BasicInteractions().WaitTime(30);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoadingClaim);
                ////**Simple Search functionality
                Pages.BasicInteractions().WaitVisible(obj_claims.SearchClaim);
                Pages.BasicInteractions().Clear(obj_claims.SearchClaim);
                Pages.BasicInteractions().Type(obj_claims.SearchClaim, ClaimID);
                //Pages.BasicInteractions().Type(obj_claims.SearchClaim, Keys.Enter);
                //Pages.BasicInteractions().WaitTime(5);

                //**Advance Search functionality
                //Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchLink);
                //Pages.BasicInteractions().Click(obj_claims.AdvanceSearchLink);
                //Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().TypeClear(obj_claims.AdvanceSearchClaimIDTextBox, ClaimID);
                //Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().Click(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().WaitTime(20);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.LoadingImageClaim);
                if (Pages.BasicInteractions().IsElementVisible(obj_claims.TblEmptyMessage))
                {
                    Console.WriteLine(" Claim Not Available");
                }
                else
                {
                    Pages.BasicInteractions().WaitTime(5);
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
                Pages.BasicInteractions().WaitVisible(obj_claims.SearchClaim);
                Pages.BasicInteractions().Clear(obj_claims.SearchClaim);
                Pages.BasicInteractions().Type(obj_claims.SearchClaim, ClaimID);
                //Pages.BasicInteractions().Type(obj_claims.SearchClaim, Keys.Enter);
                //Pages.BasicInteractions().WaitTime(5);

                //**Advance Search functionality
                //Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchLink);
                //Pages.BasicInteractions().Click(obj_claims.AdvanceSearchLink);
                //Pages.BasicInteractions().WaitVisible(obj_claims.ApprovedCheckbox);
                //Pages.BasicInteractions().Click(obj_claims.PendingPaymentCheckbox);
                ////Pages.BasicInteractions().WaitVisible(AdvanceSearchClaimIDTextBox);
                ////Pages.BasicInteractions().Clear(AdvanceSearchClaimIDTextBox);
                ////Pages.BasicInteractions().Type(AdvanceSearchClaimIDTextBox, ClaimId);
                //Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().Click(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().WaitTime(5);
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
        public void Claim_FullFlow_Validation()
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
                FillClaimDetails(Parameters.ClaimTotalActivityCost_Pandora);
                Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_claims.BtnSubmit));
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
            try
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
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(oBJ_Common.MoreDetailsLink);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Common.AuditTrailLink,120);
                Pages.BasicInteractions().Click(oBJ_Common.AuditTrailLink);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Common.AuditHistoryLabel, 120);
                Assert.AreEqual(true, Pages.BasicInteractions().IsElementDisplayed(oBJ_Common.AuditHistoryLabel));
                Pages.BasicInteractions().Click(oBJ_Common.CloseButton);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Common.ClaimDetailsPageStatus, 120);
                string ExpectedStatus = Pages.BasicInteractions().GetText(oBJ_Common.ClaimDetailsPageStatus);
                Pages.BasicInteractions().Click(oBJ_Common.ViewButton);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                string ActualStatus = Pages.BasicInteractions().GetText(oBJ_Claims.ClaimStatusOnClaimReviewPage);
                Assert.AreEqual(ExpectedStatus, ActualStatus);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void FillClaimDetails(string TotalActivityCost)
        {
            try
            {
                //Select store and Program
                SelectStoreAndProgram_Claim();

                //Entering Details
                double ReqAmount = EnterDetails_Claim(TotalActivityCost);

                //Adding Attachment
                AddingAttachment_Claim();
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
                Pages.BasicInteractions().WaitVisible(obj_claims.DdlStoreName);
                Pages.BasicInteractions().Click(obj_claims.DdlStoreName);
                Pages.BasicInteractions().WaitVisible(obj_claims.TxbSearchStoreName);
                if (BrowserURLLaunch.EXECUTIONENVIRONMENT.ToUpper() == "PROD".ToUpper())
                {
                    Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchStoreName, Parameters.Pandora_Test_LME_PROD);
                    Pages.BasicInteractions().Type(obj_claims.TxbSearchStoreName, Keys.Enter);

                    Pages.BasicInteractions().WaitVisible(obj_claims.DdlProgramName);
                    Pages.BasicInteractions().Click(obj_claims.DdlProgramName);
                    Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchProgramName, Parameters.Pandora_ProgramName());
                    Pages.BasicInteractions().Type(obj_claims.TxbSearchProgramName, Keys.Enter);
                }
                else
                {
                    Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchStoreName, Parameters.Pandora_Test_LME);
                    Pages.BasicInteractions().Type(obj_claims.TxbSearchStoreName, Keys.Enter);

                    Pages.BasicInteractions().WaitVisible(obj_claims.DdlProgramName);
                    Pages.BasicInteractions().Click(obj_claims.DdlProgramName);
                    Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchProgramName, Parameters.Pandora_ProgramName());
                    Pages.BasicInteractions().Type(obj_claims.TxbSearchProgramName, Keys.Enter);
                }
                Pages.BasicInteractions().WaitVisible(obj_claims.BtnNext1);
                Pages.BasicInteractions().Click(obj_claims.BtnNext1);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }
        public double EnterDetails_Claim(string TotalActivityCost)
        {
            double RequestedAmount;
            string EligibleAmount = null;
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimRequestedAmount_Pandora);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbClaimDescription, "Claim Ref No 1234");
                Pages.BasicInteractions().WaitVisible(obj_claims.DdlCampaign);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_claims.DdlCampaign);
                Pages.BasicInteractions().WaitVisible(obj_claims.TxbSearchCampaign);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchCampaign, Keys.Enter);

                Pages.BasicInteractions().WaitVisible(obj_claims.DdlTactic);
                Pages.BasicInteractions().Click(obj_claims.DdlTactic);

                Pages.BasicInteractions().WaitVisible(obj_claims.TxbsearchTactic);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbsearchTactic, "Direct Mail");
                Pages.BasicInteractions().Type(obj_claims.TxbsearchTactic, Keys.Enter);

                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));
                Pages.BasicInteractions().WaitTime(2);

                //Element not visible
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                Pages.BasicInteractions().WaitTime(2);


                Pages.BasicInteractions().TypeClear(obj_claims.ClaimTotalActivityCost_Pandora, TotalActivityCost);
                Pages.BasicInteractions().WaitTime(2);

                //Get Eligible Amount

                EligibleAmount = Pages.BasicInteractions().GetAttribute(obj_claims.EligibleAmount, "value");
                Pages.BasicInteractions().TypeClear(obj_claims.ClaimRequestedAmount_Pandora, EligibleAmount);
                Pages.BasicInteractions().WaitTime(3);
                //Requested Amount is calculting like Eligible Amount;

                if (Pages.BasicInteractions().IsElementDisplayed(obj_claims.ReqAmountConverted))
                {
                    RequestedAmount = Convert.ToDouble(Pages.BasicInteractions().GetAttribute(obj_claims.ReqAmountConverted, "value"));
                }
                else
                {
                    RequestedAmount = Convert.ToDouble(EligibleAmount);
                }
                Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                return RequestedAmount;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void AddingAttachment_Claim()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimComments);
                Pages.BasicInteractions().Type(obj_claims.ClaimInvoice, "Claim-12345");
                Pages.BasicInteractions().WaitVisible(obj_claims.PaymentDate);
                Pages.BasicInteractions().Click(obj_claims.PaymentDate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_claims.PaymentDateSelection());
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimUpload);

               //File Upload
                CommonUtilities.UploadFile(oBJ_Common.FileUploadInput, "CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                Pages.BasicInteractions().WaitUntilElementVisible(obj_claims.FileUploadedSuccessfully, 120);
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimComments);
                Pages.BasicInteractions().Type(obj_claims.ClaimComments, "Claim-Comments");
                Pages.BasicInteractions().WaitUntilElementVisible(obj_claims.BtnNext3,60);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.BtnNext3);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
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
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.BtnSubmit);
                Pages.BasicInteractions().Click(obj_claims.BtnSubmit);
                Pages.BasicInteractions().WaitTime(10);
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
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }

        //Claim Creation Negative
        public void ClaimCreation_Negative()
        {
            
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().Click(obj_dashboard.BtnSubmit);
                Pages.BasicInteractions().WaitTime(2);
                
                if (!Pages.BasicInteractions().IsElementPresent(obj_dashboard.BtnSubmitClaim))
                {
                    Console.WriteLine("Cannot create Claims, link to create Claims is not present in the application");
                }
                else
                {
                    Pages.BasicInteractions().WaitVisible(obj_dashboard.BtnSubmitClaim);
                    Pages.BasicInteractions().Click(obj_dashboard.BtnSubmitClaim);
                    Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);

                   
                    if (BrowserURLLaunch.ROLES.Equals("CORPORATE1") || BrowserURLLaunch.ROLES.Equals("CORPORATE2"))
                    {
                        Pages.BasicInteractions().WaitVisible(obj_claims.DdlStoreName);
                        Pages.BasicInteractions().Click(obj_claims.DdlStoreName);
                        Pages.BasicInteractions().WaitVisible(obj_claims.TxbSearchStoreName);

                        Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchStoreName, Parameters.Pandora_Test_LME);
                        Pages.BasicInteractions().Type(obj_claims.TxbSearchStoreName, Keys.Enter);

                       
                        Console.WriteLine("CLAIM NEGATIVE: Store selected");
                    }

                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().WaitVisible(obj_claims.DdlProgramName);
                    Pages.BasicInteractions().Click(obj_claims.DdlProgramName);
                    //Pages.BasicInteractions().WaitTime(2);
                    Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchProgramName, Parameters.Pandora_ProgramName());
                    Pages.BasicInteractions().Type(obj_claims.TxbSearchProgramName, Keys.Enter);
                    Console.WriteLine("CLAIM NEGATIVE: Program selected");

                    Pages.BasicInteractions().WaitVisible(obj_claims.NextButton);
                    Pages.BasicInteractions().Click(obj_claims.NextButton);
                    Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                    Pages.BasicInteractions().WaitTime(2);
                    //**Enter Details stepper
                    Pages.BasicInteractions().WaitVisible(obj_claims.BtnNext2);
                    Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                    Pages.BasicInteractions().Clear(obj_claims.ClaimReference);
                    Pages.BasicInteractions().Type(obj_claims.ClaimReference, "REF-1234");
                    Pages.BasicInteractions().WaitVisible(obj_claims.BtnNext2);
                    Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                    if (Pages.BasicInteractions().IsElementPresent(obj_claims.ErrorActivityTypeRequired))
                    {
                        Pages.BasicInteractions().WaitVisible(obj_claims.DdlTactic);
                        Pages.BasicInteractions().Click(obj_claims.DdlTactic);

                        Pages.BasicInteractions().WaitVisible(obj_claims.TxbsearchTactic);
                        Pages.BasicInteractions().TypeClear(obj_claims.TxbsearchTactic, "Direct Mail");
                        Pages.BasicInteractions().Type(obj_claims.TxbsearchTactic, Keys.Enter);
                        Console.WriteLine("CLAIM NEGATIVE: Tactic Selected for Claim");
                    }

                    Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                    if (Pages.BasicInteractions().IsElementPresent(obj_claims.ErrorStartDateRequired))
                    {
                        Pages.BasicInteractions().WaitVisible(obj_claims.ClaimStartdate);
                        Pages.BasicInteractions().Click(obj_claims.ClaimStartdate);
                        Pages.BasicInteractions().Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));
                        Console.WriteLine("CLAIM NEGATIVE: Start Date selected for Claim");
                    }

                    Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                    if (Pages.BasicInteractions().IsElementPresent(obj_claims.ErrorEndDateRequired))
                    {
                        Pages.BasicInteractions().WaitVisible(obj_claims.ClaimEndDate);
                        Pages.BasicInteractions().Click(obj_claims.ClaimEndDate);
                        Pages.BasicInteractions().WaitTime(5);
                        Pages.BasicInteractions().Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                        Console.WriteLine("CLAIM NEGATIVE: End Date selected for Claim");
                    }

                    Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                    if (Pages.BasicInteractions().IsElementPresent(obj_claims.ErrorTotalActivityCostReq))
                    {
                        Pages.BasicInteractions().Type(obj_claims.ClaimTotalActivityCost_Pandora, "300");
                        Console.WriteLine("CLAIM NEGATIVE: Total Activity Cost entered for Claim");
                    }

                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                    if (Pages.BasicInteractions().IsElementPresent(obj_claims.ErrorRequestedAmountReq))
                    {
                        Pages.BasicInteractions().Type(obj_claims.ClaimRequestedAmount_Pandora, "20");
                        Console.WriteLine("CLAIM NEGATIVE: Requested Amount entered for Claim");
                    }
                    Pages.BasicInteractions().Click(obj_claims.BtnNext2);
                    if (Pages.BasicInteractions().IsElementPresent(obj_claims.ErrorCampaignReq))
                    {
                        Pages.BasicInteractions().WaitVisible(obj_claims.DdlCampaign);
                        Pages.BasicInteractions().Click(obj_claims.DdlCampaign);
                        Pages.BasicInteractions().WaitVisible(obj_claims.TxbSearchCampaign);
                        Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchCampaign, Keys.Enter);
                    }
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().ClickJavaScript(obj_claims.BtnNext2);
                    Pages.BasicInteractions().WaitTime(5);
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
                    if (Pages.BasicInteractions().IsElementPresent(obj_claims.ErrorAttachmentRequired))
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
                Console.WriteLine("Ace_Claim_Negative: " + ex);
                Assert.Fail("Ace_Claim_Negative: " + ex);
            }
        }

        public string ClaimResubmitted(string ClaimID)
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_claims.LeftNavClaim);
                Pages.BasicInteractions().Click(obj_claims.LeftNavClaim);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                Pages.BasicInteractions().WaitTime(10);

                //**Simple Search functionality
                Pages.BasicInteractions().WaitVisible(obj_claims.SearchClaim);
                Pages.BasicInteractions().Clear(obj_claims.SearchClaim);
                Pages.BasicInteractions().Type(obj_claims.SearchClaim, ClaimID);
                //Pages.BasicInteractions().Type(obj_claims.SearchClaim, Keys.Enter);
                //Pages.BasicInteractions().WaitTime(5);

                //**Advance Search functionality
                //Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchLink);
                //Pages.BasicInteractions().Click(obj_claims.AdvanceSearchLink);
                ////Pages.BasicInteractions().WaitVisible(obj_claims.NeedsInformationCheckbox);
                ////Pages.BasicInteractions().Click(obj_claims.NeedsInformationCheckbox);
                //Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().Clear(obj_claims.AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().Type(obj_claims.AdvanceSearchClaimIDTextBox, ClaimID);
                //Pages.BasicInteractions().WaitTime(5);

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
                //Claim_AttachDocuments ca = new Claim_AttachDocuments(Driver);
                AddingAttachment_Claim();
                Pages.BasicInteractions().WaitTime(5);
                //Claim_ReviewSubmit cr = new Claim_ReviewSubmit(Driver);
                string ReSubmittedClaimID = SubmitClaim();
                return ReSubmittedClaimID;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
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

                //selecting Program and Store
                SelectStoreAndProgram_Claim();


                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimRequestedAmount_Pandora);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbClaimDescription, "Claim Ref No 1234");
                Pages.BasicInteractions().WaitVisible(obj_claims.DdlCampaign);
                Pages.BasicInteractions().Click(obj_claims.DdlCampaign);
                Pages.BasicInteractions().WaitVisible(obj_claims.TxbSearchCampaign);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbSearchCampaign, Keys.Enter);

                Pages.BasicInteractions().WaitVisible(obj_claims.DdlTactic);
                Pages.BasicInteractions().Click(obj_claims.DdlTactic);

                Pages.BasicInteractions().WaitVisible(obj_claims.TxbsearchTactic);
                Pages.BasicInteractions().TypeClear(obj_claims.TxbsearchTactic, "Direct Mail");
                Pages.BasicInteractions().Type(obj_claims.TxbsearchTactic, Keys.Enter);

                //ActivityTypeText.Type(Keys.Enter);
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartdate);
                //ClaimStartDateSelection("April 22, 2018").Click();
                Pages.BasicInteractions().Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateValidation_StartDate()));
                //Element not visible
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().WaitTime(10);
                //ClaimEndDateSelection("April 29, 2018").Click();
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateValidation_EndDate()));
                Pages.BasicInteractions().WaitTime(3);
                Assert.AreEqual(Pages.BasicInteractions().GetText(obj_claims.EndDateErrorMsg).ToString(), "End date cannot be less than Start date");
                Console.WriteLine("Claim Date Validation is throwing error when End Date is less than Start Date");
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                Pages.BasicInteractions().WaitTime(3);
                if (!Pages.BasicInteractions().IsElementPresent(obj_claims.EndDateErrorMsg))
                {
                    Console.WriteLine("Claim Date Validation is working fine when End Date is greater than Start Date");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ace_Claim_DateValidation " + ex);
                Assert.Fail("Ace_Claim_DateValidation " + ex);
            }
        }

        public void ClaimApprovalPermissionValidation(string ClaimId)
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
                //Pages.BasicInteractions().Type(obj_claims.SearchClaim, Keys.Enter);
                //Pages.BasicInteractions().WaitTime(5);

                //**Advance Search functionality
                //Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchLink);
                //Pages.BasicInteractions().Click(obj_claims.AdvanceSearchLink);
                ////Pages.BasicInteractions().WaitVisible(obj_claims.PendingReviewCheckbox);
                ////Pages.BasicInteractions().Click(obj_claims.PendingReviewCheckbox);
                //Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().Clear(obj_claims.AdvanceSearchClaimIDTextBox);
                //Pages.BasicInteractions().Type(obj_claims.AdvanceSearchClaimIDTextBox, ClaimId);
                //Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().Click(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.ClaimSearchResult(ClaimId));
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);

                Assert.False(Pages.BasicInteractions().IsElementPresent(obj_claims.ClaimResponseDropdown));
                //{
                Console.WriteLine("Claim: " + BrowserURLLaunch.ROLES + "  doesnt have the option to Approve/Deny/Hold/Needs Information access");
                //}
                //else
                //{
                //Console.WriteLine("Claim: " + Pages.BrowserURLLaunch().ROLES + "  have option to Approve/Deny/Hold/Needs Information access");
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ace_Claim_ApprovalPermission failed due to " + ex);
                Assert.Fail("Ace_Claim_ApprovalPermission failed due to " + ex);
            }
        }

        //Claim Approval Amount Validation
        public void ClaimApprovalAmountValidation(string ClaimId, string action, string reason)
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
                //Pages.BasicInteractions().WaitVisible(obj_claims.PendingReviewCheckbox);
                //Pages.BasicInteractions().Click(obj_claims.PendingReviewCheckbox);
                Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchClaimIDTextBox);
                Pages.BasicInteractions().Clear(obj_claims.AdvanceSearchClaimIDTextBox);
                Pages.BasicInteractions().Type(obj_claims.AdvanceSearchClaimIDTextBox, ClaimId);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().Click(obj_claims.AdvanceSearchButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoadingClaim);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.ClaimSearchResult(ClaimId));
                Pages.BasicInteractions().WaitTime(20);
                decimal strRequestedAmount = Convert.ToDecimal((Pages.BasicInteractions().GetText(obj_claims.ClaimRequestedAmount_bobcat).Split('$')[1]).ToString());
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimResponseDropdown);
                Pages.BasicInteractions().Click(obj_claims.ClaimResponseDropdown);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.ClaimResponse(action));
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
                //Pages.BasicInteractions().WaitVisible(obj_claims.ClaimSendResponseButton);
                //Pages.BasicInteractions().Click(obj_claims.ClaimSendResponseButton);

                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimSendResponseButton);
                Pages.BasicInteractions().Click(obj_claims.ClaimReviewCodeDropdown);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Type(obj_claims.ClaimReviewCodeText, "84");
                Pages.BasicInteractions().Click(obj_claims.ClaimReviewCodeTextSelect);
                Assert.IsFalse(Pages.BasicInteractions().IsElementPresent(obj_claims.ApprovedAmountErrorMsg));
                //{
                Console.WriteLine("Approved amount field accepting approved amount when Requested amount and approved amount are same");
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine("ACE_Claim_ApprovedAmountValidation " + ex);
                Assert.Fail("ACE_Claim_ApprovedAmountValidation " + ex);
            }
        }


        //Claim Approve
        public void ClaimApprove(String ClaimID, String Action, string Reason, string ApprovalAmount)
        {
            try
            {
                //Search the Claim
                SearchClaim(ClaimID);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.ClaimSearchResult(ClaimID));
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);
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
                    Pages.BasicInteractions().Type(obj_claims.ClaimApprovedAmount, ApprovalAmount);
                }
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimSendResponseButton);
                Pages.BasicInteractions().Click(obj_claims.ClaimReviewCodeDropdown);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Type(obj_claims.ClaimReviewCodeText, Reason);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.ClaimReviewCodeTextSelect);
                //Pages.BasicInteractions().Type(ClaimComments, "Claim-Perform Action Comments: " + action);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_claims.ClaimSendResponseButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);

                Pages.BasicInteractions().WaitTime(20);
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


    }
}
