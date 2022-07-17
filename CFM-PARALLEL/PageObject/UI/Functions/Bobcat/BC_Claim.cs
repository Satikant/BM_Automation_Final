using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Transactions;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFM_PARALLEL.PageObject.UI.Functions.Bobcat
{
    class BC_Claim
    {
        private IWebDriver Driver;
        private Base bs;
        private BrowserURLLaunch bl;
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private BasicInteractions bi;
        private CommonFunctions cf;
        //Constructor
        public BC_Claim(IWebDriver Driver)
        {
            this.Driver = Driver;
            bs = new Base();
            bl = new BrowserURLLaunch(Driver);
            obj_dashboard = new OBJ_Dashboard();
            bi = new BasicInteractions(Driver);
            obj_claims = new OBJ_Claims();
            cf= new CommonFunctions(Driver);
        }

     
        //Claim Creation
        public string ClaimCreation(string bpa_choice = "N",string BPAID=null, string InvoiceNumber= "Claim-Invoice-1234")
        {
            try
            {
                bi.WaitVisible(obj_dashboard.btnSubmit);
                bi.Click(obj_dashboard.btnSubmit);
                bi.WaitTime(2);
                bi.WaitVisible(obj_dashboard.btnSubmitClaim);
                bi.Click(obj_dashboard.btnSubmitClaim);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);


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
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }

        //Claim Creation
        public string ClaimCreation(string ClaimTotalActivityCost, string ClaimRequestedAmount, string bpa_choice = "N", string BPAID = null, string InvoiceNumber = "Claim-Invoice-1234")
        {
            try
            {
                bi.WaitVisible(obj_dashboard.btnSubmit);
                bi.Click(obj_dashboard.btnSubmit);
                bi.WaitTime(2);
                bi.WaitVisible(obj_dashboard.btnSubmitClaim);
                bi.Click(obj_dashboard.btnSubmitClaim);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);


                SelectStoreAndProgram_Claim(bpa_choice, BPAID);

                //Entering Details
                EnterDetails_Claim(ClaimTotalActivityCost, ClaimRequestedAmount,bpa_choice);

                //Adding Attachment
                AddingAttachment_Claim(InvoiceNumber);

                //SubmitClaim
                string ClaimID = SubmitClaim();
                return ClaimID;
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();
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
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();

                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //Claim Clone
        public void ClaimClone(String ClaimID,string InvoiceNumber="Claim-Invoice1234")
        {
            try
            {
                //Search the Claim
                SearchClaim(ClaimID);


                bi.WaitTime(3);
                bi.Click(obj_claims.ClaimSearchResult(ClaimID));
                //ClaimSearchResult.Click();
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTime(5);
                bi.WaitVisible(obj_claims.CloneButton);
                bi.Click(obj_claims.CloneButton);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);

                bi.WaitTime(5);
                bi.WaitVisible(obj_claims.btnNext2);
                //Claim_ChooseProgram.NextButton.Click();
                bi.Click(obj_claims.btnNext2);
                bi.WaitTime(5);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);


                //Entering Details
                //EnterDetails_Claim();
                //Attaching Document
                AddingAttachment_Claim(InvoiceNumber);

                //Submiting CloneClaim
                String ClaimIDAfterClone = SubmitClaim();
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
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

                bi.Click(obj_claims.ClaimSearchResult(ClaimID));
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                if (bi.IsElementPresent(obj_claims.chbAknowledgeForDuplicateInvoice))
                {
                    bi.Click(obj_claims.chbAknowledgeForDuplicateInvoice);
                    bi.WaitTime(5);
                }
                bi.WaitVisible(obj_claims.ClaimResponseDropdown);
                bi.Click(obj_claims.ClaimResponseDropdown);
                bi.WaitTime(5);
                bi.Click(obj_claims.ClaimResponse(Action));
                if (Action.Equals("Approve"))
                {
                    bi.Clear(obj_claims.ClaimApprovedAmount);
                    bi.Type(obj_claims.ClaimApprovedAmount, Parameters.ClaimApprovalAmount_Bobcat);
                }
                bi.WaitVisible(obj_claims.ClaimReviewCodeDropdown);
                bi.Click(obj_claims.ClaimReviewCodeDropdown);
                bi.WaitTime(5);
                bi.Type(obj_claims.ClaimReviewCodeText, Keys.Tab);

                bi.Click(obj_claims.ClaimReviewCodeTextSelect);
                //bi.Type(ClaimComments, "Claim-Perform Action Comments: " + action);
                bi.WaitTime(2);
                bi.ClickJavaScript(obj_claims.ClaimSendResponseButton);
                bi.WaitTillNotVisible(obj_claims.imgLoading);

                bi.WaitTime(10);
                bi.WaitVisible(obj_claims.SearchClaim);
                bi.Clear(obj_claims.SearchClaim);

                Console.WriteLine(ClaimID + " - " + Action);
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }


        //Claim perform Action
        public void ClaimApprovalAmountValidation(String ClaimID, String Action, string Reason)
        {
            try
            {
                try
                {
                    bi.WaitTime(5);
                    bi.WaitVisible(obj_claims.LeftNavClaim);
                    bi.Click(obj_claims.LeftNavClaim);
                    bi.WaitTillNotVisible(obj_claims.imgLoading);
                    bi.WaitTime(5);

                    //**Advance Search functionality
                    bi.WaitVisible(obj_claims.AdvanceSearchLink);
                    bi.Click(obj_claims.AdvanceSearchLink);
                    bi.WaitVisible(obj_claims.PendingReviewCheckbox);
                    bi.Click(obj_claims.PendingReviewCheckbox);
                    bi.WaitVisible(obj_claims.AdvanceSearchClaimIDTextBox);
                    bi.Clear(obj_claims.AdvanceSearchClaimIDTextBox);
                    bi.Type(obj_claims.AdvanceSearchClaimIDTextBox, ClaimID);
                    bi.WaitTime(5);
                    bi.WaitVisible(obj_claims.AdvanceSearchButton);
                    bi.Click(obj_claims.AdvanceSearchButton);
                    bi.WaitTillNotVisible(obj_claims.imgLoadingClaim);
                    bi.WaitTime(5);
                    bi.Click(obj_claims.ClaimSearchResult(ClaimID));
                    bi.WaitTillNotVisible(obj_claims.imgLoading);
                    bi.WaitTime(5);
                    decimal strRequestedAmount = Convert.ToDecimal((bi.GetText(obj_claims.ClaimRequestedAmount_bobcat).Split('$'))[1].ToString());
                    bi.WaitVisible(obj_claims.ClaimResponseDropdown);
                    bi.Click(obj_claims.ClaimResponseDropdown);
                    bi.WaitTime(5);
                    bi.Click(obj_claims.ClaimResponse(Action));
                    bi.WaitTime(5);
                    bi.Clear(obj_claims.ClaimApprovedAmount);
                    bi.Type(obj_claims.ClaimApprovedAmount, (strRequestedAmount + 10).ToString());
                    bi.WaitVisible(obj_claims.ClaimSendResponseButton);
                    bi.Click(obj_claims.ClaimSendResponseButton);
                    bi.WaitTime(3);
                    Assert.AreEqual(bi.GetText(obj_claims.ApprovedAmountErrorMsg).ToString(), "Approved amount cannot be greater than Requested amount");
                    Console.WriteLine("Approved amount field not accepting approved amount greater than Requested amount");
                    bi.WaitTime(5);
                    bi.Clear(obj_claims.ClaimApprovedAmount);
                    bi.Type(obj_claims.ClaimApprovedAmount, strRequestedAmount.ToString());
                    bi.WaitTime(5);
                    //bi.WaitVisible(obj_claims.ClaimReviewCodeDropdown);
                    bi.Click(obj_claims.ClaimReviewCodeDropdown);
                    bi.WaitTime(5);
                    bi.Type(obj_claims.ClaimReviewCodeText, Reason);
                    bi.Click(obj_claims.ClaimReviewCodeTextSelect);
                    //bi.WaitVisible(obj_claims.ClaimSendResponseButton);
                    //bi.Click(obj_claims.ClaimSendResponseButton);
                    bi.WaitTime(5);
                    Assert.False(bi.IsElementPresent(obj_claims.ApprovedAmountErrorMsg));
                    //{
                        Console.WriteLine("Approved amount field accepting approved amount when Requested amount and approved amount are same");
                    //}
                }
                catch (Exception ex)
                {
    CommonUtilities.Logout(Driver);       Driver.Quit();
                    //CommonFunctions.KillProcess();
                    Console.WriteLine("ACE_Claim_ApprovedAmountValidation " + ex);
                    Assert.Fail("ACE_Claim_ApprovedAmountValidation " + ex);
                }
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();

                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }


        public void NavigatingToDashBoard()
        {
            try
            {
                bi.WaitTime(5);
                bi.WaitVisible(obj_claims.btnDashBoard);
                bi.Click(obj_claims.btnDashBoard);
                bi.WaitTillNotVisible(obj_claims.imgLoading);
                bi.WaitTime(10);
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //Search Claim By ClaimID
        public void SearchClaim(String ClaimID)
        {
            try
            {
                bi.WaitTime(10);
                bi.WaitVisible(obj_claims.LeftNavClaim);
                bi.Click(obj_claims.LeftNavClaim);
                //bi.WaitTime(30);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTillNotVisible(obj_claims.imgLoadingClaim);
                ////**Simple Search functionality
                //Wait.WaitVisible(SearchClaim);
                //SearchClaim.Clear();
                //SearchClaim.Type(ClaimId);
                //SearchClaim.Type(Keys.Enter);
                bi.WaitTime(5);

                //**Advance Search functionality
                bi.WaitVisible(obj_claims.AdvanceSearchLink);
                bi.Click(obj_claims.AdvanceSearchLink);
                bi.WaitVisible(obj_claims.AdvanceSearchClaimIDTextBox);
                bi.TypeClear(obj_claims.AdvanceSearchClaimIDTextBox, ClaimID);
                bi.WaitTime(5);
                bi.WaitVisible(obj_claims.AdvanceSearchButton);
                bi.Click(obj_claims.AdvanceSearchButton);
                bi.WaitTime(5);
                bi.WaitTillNotVisible(obj_claims.LoadingImageClaim);
                if (bi.IsElementVisible(obj_claims.tblEmptyMessage))
                {
                    Console.WriteLine(" Claim Not Available");
                }
                else
                {
                    ClaimID = bi.GetText(obj_claims.tblCalimFirstRowClaimID);
                }
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
               
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
                bi.WaitTime(10);
                bi.WaitVisible(obj_claims.LeftNavClaim);
                bi.Click(obj_claims.LeftNavClaim);
                //bi.WaitTime(30);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);

                ////**Simple Search functionality
                //Wait.WaitVisible(SearchClaim);
                //SearchClaim.Clear();
                //SearchClaim.Type(ClaimId);
                //SearchClaim.Type(Keys.Enter);
                //Wait.WaitTime(10);

                //**Advance Search functionality
                bi.WaitVisible(obj_claims.AdvanceSearchLink);
                bi.Click(obj_claims.AdvanceSearchLink);
                bi.WaitVisible(obj_claims.ApprovedCheckbox);
                bi.Click(obj_claims.PendingPaymentCheckbox);
                //bi.WaitVisible(AdvanceSearchClaimIDTextBox);
                //bi.Clear(AdvanceSearchClaimIDTextBox);
                //bi.Type(AdvanceSearchClaimIDTextBox, ClaimId);
                bi.WaitTime(10);
                bi.WaitVisible(obj_claims.AdvanceSearchButton);
                bi.Click(obj_claims.AdvanceSearchButton);
                bi.WaitTime(10);
                bi.WaitTillNotVisible(obj_claims.LoadingImageClaim);
                if (bi.IsElementVisible(obj_claims.tblEmptyMessage))
                {
                    Console.WriteLine("No Pending Claims Available");
                }
                else
                {
                    ClaimID = bi.GetText(obj_claims.tblCalimFirstRowClaimID);
                }
                return ClaimID;
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }

        }

        //Claim Validation 
        public void ClaimValidationAtLMELevel(string InvoiceNumber = "Claim-Invoice-1234")
        {
            try
            {

                bi.WaitVisible(obj_dashboard.btnSubmit);
                bi.Click(obj_dashboard.btnSubmit);
                bi.WaitTime(2);
                bi.WaitVisible(obj_dashboard.btnSubmitClaim);
                bi.Click(obj_dashboard.btnSubmitClaim);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTime(2);

                SelectStoreAndProgram_Claim();
                bi.WaitTime(10);

                //Entering Details
                EnterDetails_Claim1();
                //EnterDetails_Claim();

                //Adding Attachment
                //AddingAttachment_Claim(InvoiceNumber);


                //bi.IsElementPresent(obj_claims.btnSubmit);
                Console.WriteLine("Submit Button Available");
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }

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
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void SelectStoreAndProgram_Claim(string bpa_choice = "N", string bpa=null)
        {
            try
            {
                bi.WaitTime(5);
                if (bi.IsElementVisible(obj_claims.BPAForClaimYes) | bi.IsElementVisible(obj_claims.BPAForClaimNo))
                {
                    //opting for BPA
                    if (bpa_choice == "Y")
                    {
                        bi.WaitTime(10);
                        bi.WaitVisible(obj_claims.BPAForClaimYes);
                        bi.Click(obj_claims.BPAForClaimYes);
                        bi.WaitVisible(obj_claims.PreApprovalID);
                        bi.Click(obj_claims.PreApprovalID);
                        //bi.WaitTime(5);
                        bi.TypeClear(obj_claims.PreApprovalIDText, bpa);
                        bi.Type(obj_claims.PreApprovalIDText, Keys.Enter);
                        //bi.Click(ClaimTextSelected);
                        bi.WaitTillNotVisible(obj_claims.imgLoading);
                        bi.WaitVisible(obj_claims.CoopProgramWithBPA);
                        bi.Click(obj_claims.CoopProgramWithBPA);
                        bi.WaitVisible(obj_claims.CoopProgramTextWithBPA);
                        if (Parameters.Bobcat_ProgramName() != null)
                        {
                            bi.TypeClear(obj_claims.CoopProgramTextWithBPA, Parameters.Bobcat_ProgramName());
                            //bi.WaitTime(2);
                        }
                        bi.Type(obj_claims.CoopProgramTextWithBPA, Keys.Enter);
                        //bi.WaitVisible(obj_claims.ClaimTextSelected);
                        //i.Click(obj_claims.ClaimTextSelected);
                        bi.WaitTime(3);
                        //bi.WaitTime(2);
                    }
                    //not opting for BPA
                    else if (bpa_choice == "N")
                    {
                        bi.WaitTime(5);
                        bi.WaitVisible(obj_claims.BPAForClaimNo);
                        bi.Click(obj_claims.BPAForClaimNo);
                        //bi.WaitTime(15);
                        bi.WaitTillNotVisible(obj_claims.imgLoading);

                        //BrowserURLLaunch roles2 = new BrowserURLLaunch(Driver);
                        // if (roles2.ROLES.Equals("CORPORATE1"))
                        // {
                        bi.WaitVisible(obj_claims.ClaimDropdown);
                        bi.Click(obj_claims.ClaimDropdown);
                        //bi.WaitTime(5);
                        bi.WaitVisible(obj_claims.ClaimText);
                        bi.Type(obj_claims.ClaimText, Parameters.Bobcat_Test_LME());
                        //bi.WaitTime(5);
                        bi.Type(obj_claims.ClaimText, Keys.Enter);
                        bi.WaitTime(5);
                        bi.WaitTillNotVisible(obj_claims.imgLoading);
                        //bi.WaitVisible(ClaimTextSelected);
                        //bi.Click(ClaimTextSelected);
                        //    }
                        bi.WaitTillNotVisible(obj_claims.imgLoading);
                        bi.WaitVisible(obj_claims.CoopProgram);
                        bi.Click(obj_claims.CoopProgram);
                        bi.WaitVisible(obj_claims.CoopProgramText);
                        //bi.WaitTime(2);
                        //MPRADEEP0705
                        //PradeepMuthu*6160
                        if (Parameters.Bobcat_ProgramName() != null)
                        {
                            bi.TypeClear(obj_claims.CoopProgramText, Parameters.Bobcat_ProgramName());
                            //bi.WaitTime(2);
                        }
                        bi.Type(obj_claims.CoopProgramText, Keys.Enter);
                        bi.WaitTime(3);
                    }
                    //bi.WaitTime(20);



                    //bi.Click(CoOpProgramRadioSelect(Parameters.Ace_ProgramName(ProgramOverDrawn)));
                    //bi.WaitTime(10);
                    bi.WaitVisible(obj_claims.NextButton);
                    bi.Click(obj_claims.NextButton);
                    bi.WaitTillNotVisible(obj_claims.imgLoading);
                }
                else
                { 
                bi.WaitVisible(obj_claims.ddlStoreName);
                bi.Click(obj_claims.ddlStoreName);
                bi.WaitVisible(obj_claims.txbSearchStoreName);
                if (BrowserURLLaunch.EXECUTIONENVIRONMENT.ToUpper() != "PROD".ToUpper())
                {
                    bi.TypeClear(obj_claims.txbSearchStoreName, Parameters.Bobcat_Test_LME());
                    bi.Type(obj_claims.txbSearchStoreName, Keys.Enter);

                    bi.WaitVisible(obj_claims.ddlProgramName);
                    bi.Click(obj_claims.ddlProgramName);
                    //bi.WaitTime(2);
                    bi.TypeClear(obj_claims.txbSearchProgramName, Parameters.Bobcat_ProgramName());
                    bi.Type(obj_claims.txbSearchProgramName, Keys.Enter);
                }
                else
                {
                    bi.TypeClear(obj_claims.txbSearchStoreName, Parameters.Bobcat_Test_LME());
                    bi.Type(obj_claims.txbSearchStoreName, Keys.Enter);

                    bi.WaitVisible(obj_claims.ddlProgramName);
                    bi.Click(obj_claims.ddlProgramName);
                    //bi.WaitTime(2);
                    bi.TypeClear(obj_claims.txbSearchProgramName, Parameters.Bobcat_ProgramName());
                    bi.Type(obj_claims.txbSearchProgramName, Keys.Enter);
                }
                bi.WaitVisible(obj_claims.btnNext1);
                bi.Click(obj_claims.btnNext1);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                }
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
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
                //String Temp = cf.UniqueName("Claim");
                bi.WaitVisible(obj_claims.ClaimRequestedAmount);
                bi.TypeClear(obj_claims.txbClaimDescription, "Claim Ref Number-1234");
                //bi.WaitVisible(obj_claims.ddlCampaign);
                //bi.Click(obj_claims.ddlCampaign);
                //bi.WaitVisible(obj_claims.txbSearchCampaign);
                //bi.TypeClear(obj_claims.txbSearchCampaign, Keys.Enter);

                if (bpa_choice == "N")
                {
                    bi.WaitVisible(obj_claims.ddlMediaType);
                    bi.Click(obj_claims.ddlMediaType);

                    bi.WaitVisible(obj_claims.txbsearchMediaType);
                    bi.TypeClear(obj_claims.txbsearchMediaType, "Print");
                    bi.Type(obj_claims.txbsearchMediaType, Keys.Enter);

                    bi.WaitVisible(obj_claims.ddlTactic);
                    bi.Click(obj_claims.ddlTactic);

                    bi.WaitVisible(obj_claims.txbsearchTactic);
                    bi.TypeClear(obj_claims.txbsearchTactic, "Direct Mail");
                    bi.Type(obj_claims.txbsearchTactic, Keys.Enter);
                }

                bi.Click(obj_claims.rbtnDataEquipmentNO);

                bi.WaitVisible(obj_claims.ClaimStartdate);
                bi.Click(obj_claims.ClaimStartdate);
                bi.WaitTime(5);
                //ClaimStartDateSelection("April 22, 2018").Click();
                bi.Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));
                bi.WaitTime(5);

                //Element not visible
                bi.WaitVisible(obj_claims.ClaimEndDate);
                bi.Click(obj_claims.ClaimEndDate);
                bi.WaitTime(5);
                //ClaimEndDateSelection("April 29, 2018").Click();
                bi.Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                bi.WaitTime(5);

                bi.TypeClear(obj_claims.ClaimVendorName, "Test");
                //Get Eligible Amount
                bi.TypeClear(obj_claims.ClaimTotalActivityCost, Parameters.ClaimTotalActivityCost_Bobcat);

                EligibleAmount = bi.GetAttribute(obj_claims.EligibleAmount_bobcat, "value");

                bi.WaitTime(3);

                //Requested Amount is calculting like Eligible Amount;
                if (bi.IsElementPresent(obj_claims.ReqAmountConverted))
                {
                    RequestedAmount = Convert.ToDecimal(bi.GetAttribute(obj_claims.ReqAmountConverted, "value"));
                }
                else
                {
                    RequestedAmount = Convert.ToDecimal(EligibleAmount);
                }

                //bi.TypeClear(obj_claims.ClaimRequestedAmount, RequestedAmount.ToString());
                bi.WaitTime(5);
                //bi.WaitTime(5);
                //bi.Click(obj_claims.ClaimAcknowledgement);
                //bi.Click(obj_claims.btnNext2);

                return RequestedAmount;

                //bi.TypeClear(obj_claims.ClaimRequestedAmount, Parameters.ClaimRequestedAmount_Bobcat);
                
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
               
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void EnterDetails_Claim1(string bpa_choice = "N")
        {
            string EligibleAmount;
            decimal RequestedAmount;
            try
            {
                //String Temp = cf.UniqueName("Claim");
                bi.WaitVisible(obj_claims.ClaimRequestedAmount);
                bi.TypeClear(obj_claims.txbClaimDescription, "Claim Ref Number-1234");
                //bi.WaitVisible(obj_claims.ddlCampaign);
                //bi.Click(obj_claims.ddlCampaign);
                //bi.WaitVisible(obj_claims.txbSearchCampaign);
                //bi.TypeClear(obj_claims.txbSearchCampaign, Keys.Enter);

                if (bpa_choice == "N")
                {
                    bi.WaitVisible(obj_claims.ddlMediaType);
                    bi.Click(obj_claims.ddlMediaType);

                    bi.WaitVisible(obj_claims.txbsearchMediaType);
                    bi.TypeClear(obj_claims.txbsearchMediaType, "Print");
                    bi.Type(obj_claims.txbsearchMediaType, Keys.Enter);

                    bi.WaitVisible(obj_claims.ddlTactic);
                    bi.Click(obj_claims.ddlTactic);

                    bi.WaitVisible(obj_claims.txbsearchTactic);
                    bi.TypeClear(obj_claims.txbsearchTactic, "Direct Mail");
                    bi.Type(obj_claims.txbsearchTactic, Keys.Enter);
                }

                bi.Click(obj_claims.rbtnDataEquipmentNO);

                bi.WaitVisible(obj_claims.ClaimStartdate);
                bi.Click(obj_claims.ClaimStartdate);
                bi.WaitTime(5);
                //ClaimStartDateSelection("April 22, 2018").Click();
                bi.Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));
                bi.WaitTime(5);

                //Element not visible
                bi.WaitVisible(obj_claims.ClaimEndDate);
                bi.Click(obj_claims.ClaimEndDate);
                bi.WaitTime(5);
                //ClaimEndDateSelection("April 29, 2018").Click();
                bi.Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                bi.WaitTime(5);

                bi.TypeClear(obj_claims.ClaimVendorName, "Test");
                //Get Eligible Amount
                bi.TypeClear(obj_claims.ClaimTotalActivityCost, Parameters.ClaimTotalActivityCost_Bobcat);

                EligibleAmount = bi.GetAttribute(obj_claims.EligibleAmount_bobcat, "value");

                bi.WaitTime(3);

                /*
                //Requested Amount is calculting like Eligible Amount;
                if (bi.IsElementPresent(obj_claims.ReqAmountConverted))
                {
                    RequestedAmount = Convert.ToDecimal(bi.GetAttribute(obj_claims.ReqAmountConverted, "value"));
                }
                else
                {
                    RequestedAmount = Convert.ToDecimal(EligibleAmount);
                }
                */

                //bi.TypeClear(obj_claims.ClaimRequestedAmount, RequestedAmount.ToString());
                bi.WaitTime(5);
                //bi.WaitTime(5);
                //bi.Click(obj_claims.ClaimAcknowledgement);
                //bi.Click(obj_claims.btnNext2);


                //bi.TypeClear(obj_claims.ClaimRequestedAmount, Parameters.ClaimRequestedAmount_Bobcat);

            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver); Driver.Quit();

                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public decimal EnterDetails_Claim(String ClaimTotalActivityCost,string ClaimRequestedamount,string bpa_choice = "N")
        {
            string EligibleAmount = null;
            decimal RequestedAmount;
            try
            {
                //String Temp = cf.UniqueName("Claim");
                bi.WaitVisible(obj_claims.ClaimRequestedAmount);
                bi.TypeClear(obj_claims.txbClaimDescription, "Claim Ref Number-1234");
                //bi.WaitVisible(obj_claims.ddlCampaign);
                //bi.Click(obj_claims.ddlCampaign);
                //bi.WaitVisible(obj_claims.txbSearchCampaign);
                //bi.TypeClear(obj_claims.txbSearchCampaign, Keys.Enter);

                if (bpa_choice == "N")
                {
                    bi.WaitVisible(obj_claims.ddlMediaType);
                    bi.Click(obj_claims.ddlMediaType);

                    bi.WaitVisible(obj_claims.txbsearchMediaType);
                    bi.TypeClear(obj_claims.txbsearchMediaType, "Print");
                    bi.Type(obj_claims.txbsearchMediaType, Keys.Enter);

                    bi.WaitVisible(obj_claims.ddlTactic);
                    bi.Click(obj_claims.ddlTactic);

                    bi.WaitVisible(obj_claims.txbsearchTactic);
                    bi.TypeClear(obj_claims.txbsearchTactic, "Direct Mail");
                    bi.Type(obj_claims.txbsearchTactic, Keys.Enter);
                }

                bi.Click(obj_claims.rbtnDataEquipmentNO);

                bi.WaitVisible(obj_claims.ClaimStartdate);
                bi.Click(obj_claims.ClaimStartdate);
                bi.WaitTime(5);
                //ClaimStartDateSelection("April 22, 2018").Click();
                bi.Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));
                bi.WaitTime(5);

                //Element not visible
                bi.WaitVisible(obj_claims.ClaimEndDate);
                bi.Click(obj_claims.ClaimEndDate);
                bi.WaitTime(5);
                //ClaimEndDateSelection("April 29, 2018").Click();
                bi.Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                bi.WaitTime(5);

                bi.TypeClear(obj_claims.ClaimVendorName, "Test");

                //Get Eligible Amount
                bi.TypeClear(obj_claims.ClaimTotalActivityCost, Parameters.ClaimTotalActivityCost_Bobcat);

                EligibleAmount = bi.GetAttribute(obj_claims.EligibleAmount, "value");


                bi.TypeClear(obj_claims.ClaimRequestedAmount, EligibleAmount);
                bi.WaitTime(10);

                if (bi.IsElementDisplayed(obj_claims.ReqAmountConverted))
                {
                    RequestedAmount = Convert.ToDecimal(bi.GetAttribute(obj_claims.ReqAmountConverted, "value"));
                }
                else
                {
                    RequestedAmount = Convert.ToDecimal(EligibleAmount) - 100;
                }
                bi.WaitTime(5);
                bi.Click(obj_claims.ClaimAcknowledgement);
                bi.Click(obj_claims.btnNext2);

                return RequestedAmount;
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();

                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }
        public void AddingAttachment_Claim(string InvoiceNumber)
        {
            try
            {
                bi.WaitVisible(obj_claims.ClaimComments);
                bi.TypeClear(obj_claims.ClaimInvoice, InvoiceNumber);
                bi.WaitTime(5);
                bi.WaitVisible(obj_claims.ClaimUpload);
                bi.Click(obj_claims.ClaimUpload);
                bi.WaitTime(3);
                //File Upload
                CommonUtilities.UploadFileInChrome("CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                bi.WaitVisible(obj_claims.ClaimComments);
                bi.Type(obj_claims.ClaimComments, "Claim-Comments");
                bi.WaitVisible(obj_claims.btnNext3);
                bi.Click(obj_claims.btnNext3);
                bi.WaitTime(10);
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void ClaimDateValidation()
        {
            try
            {

                bi.WaitVisible(obj_dashboard.btnSubmit);
                bi.Click(obj_dashboard.btnSubmit);
                bi.WaitTime(2);
                bi.WaitVisible(obj_dashboard.btnSubmitClaim);
                bi.Click(obj_dashboard.btnSubmitClaim);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);

                //Selecting a Program and stroe for claim
                SelectStoreAndProgram_Claim();

                bi.WaitTime(5);
                bi.WaitVisible(obj_claims.ClaimRequestedAmount);
                bi.TypeClear(obj_claims.txbClaimDescription, "Claim Ref Number-1234");
                //bi.WaitVisible(obj_claims.ddlCampaign);
                //bi.Click(obj_claims.ddlCampaign);
                //bi.WaitVisible(obj_claims.txbSearchCampaign);
                //bi.TypeClear(obj_claims.txbSearchCampaign, Keys.Enter);
                bi.WaitVisible(obj_claims.ddlMediaType);
                bi.Click(obj_claims.ddlMediaType);

                bi.WaitVisible(obj_claims.txbsearchMediaType);
                bi.TypeClear(obj_claims.txbsearchMediaType, "Print");
                bi.Type(obj_claims.txbsearchMediaType, Keys.Enter);

                bi.WaitVisible(obj_claims.ddlTactic);
                bi.Click(obj_claims.ddlTactic);

                bi.WaitVisible(obj_claims.txbsearchTactic);
                bi.TypeClear(obj_claims.txbsearchTactic, "Direct Mail");
                bi.Type(obj_claims.txbsearchTactic, Keys.Enter);

                bi.Click(obj_claims.rbtnDataEquipmentNO);

                bi.WaitVisible(obj_claims.ClaimStartdate);
                bi.Click(obj_claims.ClaimStartdate);
                bi.WaitTime(5);
                //ClaimStartDateSelection("April 22, 2018").Click();
                bi.Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateValidation_StartDate()));
                bi.WaitTime(5);

                //Element not visible
                bi.WaitVisible(obj_claims.ClaimEndDate);
                bi.Click(obj_claims.ClaimEndDate);
                bi.WaitTime(1);
                //ClaimEndDateSelection("April 29, 2018").Click();
                bi.Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateValidation_EndDate()));
                bi.WaitTime(5);

                Assert.AreEqual(bi.GetText(obj_claims.EndDateErrorMsg).ToString(), "End date cannot be less than Start date");
                Console.WriteLine("Claim Date Validation is throwing error when End Date is less than Start Date");
                bi.WaitVisible(obj_claims.ClaimEndDate);
                bi.Click(obj_claims.ClaimEndDate);
                bi.WaitTime(1);
                bi.Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                bi.WaitTime(3);
                Assert.False(bi.IsElementPresent(obj_claims.EndDateErrorMsg));
                //{
                    Console.WriteLine("Claim Date Validation is working fine when End Date is greater than Start Date");
                //}

            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();

                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }


        public string SubmitClaim()
        {
            try
            {
                bi.WaitTime(10);
                bi.WaitVisible(obj_claims.btnSubmit);
                if (bi.IsElementPresent(obj_claims.chbAknowledgeForDuplicateInvoice))
                {
                    bi.Click(obj_claims.chbAknowledgeForDuplicateInvoice);
                    bi.WaitTime(5); 
                }
                bi.WaitVisible(obj_claims.btnSubmit);
                bi.Click(obj_claims.btnSubmit);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTime(10);
                bi.WaitVisible(obj_claims.ClaimSuccessfulMessage);
                Console.WriteLine(bi.GetText(obj_claims.ClaimSuccessfulMessage));
                string str = bi.GetText(obj_claims.ClaimSuccessfulMessage);
                string[] str1 = str.Split(' ');
                Console.WriteLine(str1[0]);
                return str1[0];
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }

        //Get Available Funds for Program
        public String GetAvailableFunds(string ProgramName)
        {
            // BasicInteractions bi=new BasicInteractions(Driver)

            try
            {
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTime(10);
                if (bi.IsElementDisplayed(obj_claims.ProgramList(ProgramName)))
                {
                    bi.WaitTime(5);
                    bi.Click(obj_claims.ProgramList(ProgramName));

                }
                else
                {
                    bi.WaitTime(5);
                    bi.WaitVisible(obj_claims.OtherProgramsLink);
                    bi.Click(obj_claims.OtherProgramsLink);
                    bi.WaitTime(5);
                    bi.Click(obj_claims.ProgramList(ProgramName));
                }
                bi.WaitTillNotVisible(obj_claims.LoadingImageSnapShot);
                bi.WaitTime(10);
                string AvailableFund = bi.GetText(obj_claims.AvailableFunds);

                if (AvailableFund.Contains("(") | AvailableFund.Contains(")"))
                {
                    AvailableFund = "-" + AvailableFund.Replace("(", "").Replace(")", "");
                }
                return AvailableFund;
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
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

                bi.Click(obj_claims.ClaimSearchResult(ClaimID));
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);

                if (bi.IsElementPresent(obj_claims.chbAknowledgeForDuplicateInvoice))
                {
                    bi.Click(obj_claims.chbAknowledgeForDuplicateInvoice);
                    bi.WaitTime(5);
                }
                bi.WaitVisible(obj_claims.ClaimResponseDropdown);
                bi.Click(obj_claims.ClaimResponseDropdown);
                bi.WaitTime(5);
                bi.Click(obj_claims.ClaimResponse(Action));
                if (Action.Equals("Approve"))
                {
                    bi.Clear(obj_claims.ClaimApprovedAmount);
                    bi.Type(obj_claims.ClaimApprovedAmount, Amount);
                }
                bi.WaitVisible(obj_claims.ClaimSendResponseButton);
                bi.Click(obj_claims.ClaimReviewCodeDropdown);
                bi.WaitTime(5);
                bi.Type(obj_claims.ClaimReviewCodeText, Reason);
                bi.Click(obj_claims.ClaimReviewCodeTextSelect);
                //bi.Type(ClaimComments, "Claim-Perform Action Comments: " + action);
                bi.WaitTime(2);

               
                bi.Click(obj_claims.ClaimSendResponseButton);
                bi.WaitTillNotVisible(obj_claims.imgLoading);

                bi.WaitTime(10);
                bi.WaitVisible(obj_claims.SearchClaim);
                bi.Clear(obj_claims.SearchClaim);

                Console.WriteLine(ClaimID + " - " + Action);
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();

                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }


        }

        public string ClaimResubmitted(string ClaimID)
        {
            try
            {
                bi.WaitVisible(obj_claims.LeftNavClaim);
                bi.Click(obj_claims.LeftNavClaim);
                bi.WaitTillNotVisible(obj_claims.imgLoading);
                bi.WaitTillNotVisible(obj_claims.imgLoadingClaim);
                bi.WaitTime(10);

                //**Simple Search functionality
                bi.WaitVisible(obj_claims.SearchClaim);
                bi.Clear(obj_claims.SearchClaim);
                bi.Type(obj_claims.SearchClaim, ClaimID);
                //SearchClaim.Type(Keys.Enter);
                //Wait.WaitTime(10);

                //**Advance Search functionality
                //bi.WaitVisible(obj_claims.AdvanceSearchLink);
                //bi.Click(obj_claims.AdvanceSearchLink);
                ////bi.WaitVisible(obj_claims.NeedsInformationCheckbox);
                ////bi.Click(obj_claims.NeedsInformationCheckbox);
                //bi.WaitVisible(obj_claims.AdvanceSearchClaimIDTextBox);
                //bi.Clear(obj_claims.AdvanceSearchClaimIDTextBox);
                //bi.Type(obj_claims.AdvanceSearchClaimIDTextBox, ClaimID);
                bi.WaitTime(5);
                bi.WaitVisible(obj_claims.AdvanceSearchButton);
                bi.Click(obj_claims.AdvanceSearchButton);
                bi.WaitTillNotVisible(obj_claims.imgLoadingClaim);
                bi.WaitTime(5);
                bi.Click(obj_claims.ClaimSearchResult(ClaimID));
                bi.WaitTillNotVisible(obj_claims.imgLoading);
                bi.WaitTime(5);
                bi.WaitVisible(obj_claims.EditClaimButton);
                bi.Click(obj_claims.EditClaimButton);
                bi.WaitTillNotVisible(obj_claims.imgLoading);
                bi.WaitTime(5);
                bi.Click(obj_claims.NextButton);
                bi.WaitTime(5);
                //Claim_AttachDocuments ca = new Claim_AttachDocuments(Driver);
                AddingAttachment_Claim("Claim-Invoice-1234");
                bi.WaitTime(5);
                //Claim_ReviewSubmit cr = new Claim_ReviewSubmit(Driver);
                string ReSubmittedClaimID = SubmitClaim();
                return ReSubmittedClaimID;

            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();
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

                bi.Click(obj_claims.ClaimSearchResult(ClaimID));
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);

                //Denying the Claim without selecting the Duplicate Aknowlegement
                //if (bi.IsElementPresent(obj_claims.chbAknowledgeForDuplicateInvoice))
                //{
                //    bi.Click(obj_claims.chbAknowledgeForDuplicateInvoice);
                //    bi.WaitTime(5);
                //}
                bi.WaitVisible(obj_claims.ClaimResponseDropdown);
                bi.Click(obj_claims.ClaimResponseDropdown);
                bi.WaitTime(5);
                bi.Click(obj_claims.ClaimResponse(Action));
                if (Action.Equals("Approve"))
                {
                    bi.Clear(obj_claims.ClaimApprovedAmount);
                    bi.Type(obj_claims.ClaimApprovedAmount, Parameters.ClaimApprovalAmount_Bobcat);
                }
                bi.WaitVisible(obj_claims.ClaimSendResponseButton);
                bi.Click(obj_claims.ClaimReviewCodeDropdown);
                bi.WaitTime(5);
                bi.Type(obj_claims.ClaimReviewCodeText, Reason);
                bi.Click(obj_claims.ClaimReviewCodeTextSelect);
                //bi.Type(ClaimComments, "Claim-Perform Action Comments: " + action);
                bi.WaitTime(2);
                bi.Click(obj_claims.ClaimSendResponseButton);
                bi.WaitTillNotVisible(obj_claims.imgLoading);

                //bi.WaitTime(30);
                bi.WaitVisible(obj_claims.SearchClaim);
                bi.Clear(obj_claims.SearchClaim);

                Console.WriteLine(ClaimID + " - " + Action);
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();

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
                bi.WaitTime(10);
                bi.WaitVisible(obj_claims.LeftNavClaim);
                bi.Click(obj_claims.LeftNavClaim);
                //bi.WaitTime(30);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTillNotVisible(obj_claims.imgLoadingClaim);
                ////**Simple Search functionality
                bi.WaitVisible(obj_claims.SearchClaim);
                bi.Clear(obj_claims.SearchClaim);
                bi.Type(obj_claims.SearchClaim,ClaimID);
                bi.Type(obj_claims.SearchClaim,Keys.Enter);
                bi.WaitTime(3);

                //**Advance Search functionality
                //bi.WaitVisible(obj_claims.AdvanceSearchLink);
                //bi.Click(obj_claims.AdvanceSearchLink);
                //bi.WaitVisible(obj_claims.AdvanceSearchClaimIDTextBox);
                //bi.TypeClear(obj_claims.AdvanceSearchClaimIDTextBox, ClaimID);
                //bi.WaitTime(5);
                bi.WaitVisible(obj_claims.AdvanceSearchButton);
                bi.Click(obj_claims.AdvanceSearchButton);
                bi.WaitTime(5);
                bi.WaitTillNotVisible(obj_claims.LoadingImageClaim);
                if (bi.IsElementVisible(obj_claims.tblEmptyMessage))
                {
                    Console.WriteLine(" Claim Not Available");
                }
                else
                {
                    ClaimStatus = bi.GetText(obj_claims.tblClaimFirstRowStatus);
                }
                return ClaimStatus;
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }


        public void ClaimApprovalPermissionValidationNotAvailableForLME(string ClaimId)
        {
            try
            {
                bi.WaitTime(5);
                bi.WaitVisible(obj_claims.LeftNavClaim);
                bi.Click(obj_claims.LeftNavClaim);
                bi.WaitTime(5);
                bi.WaitTillNotVisible(obj_claims.imgLoading);

                //**Simple Search functionality
                bi.WaitVisible(obj_claims.SearchClaim);
                bi.Clear(obj_claims.SearchClaim);
                bi.Type(obj_claims.SearchClaim,ClaimId);
                //SearchClaim.Type(Keys.Enter);
                //Wait.WaitTime(10);

                //**Advance Search functionality
                //bi.WaitVisible(obj_claims.AdvanceSearchLink);
                //bi.Click(obj_claims.AdvanceSearchLink);
                ////bi.WaitVisible(obj_claims.PendingReviewCheckbox);
                ////bi.Click(obj_claims.PendingReviewCheckbox);
                //bi.WaitVisible(obj_claims.AdvanceSearchClaimIDTextBox);
                //bi.Clear(obj_claims.AdvanceSearchClaimIDTextBox);
                //bi.Type(obj_claims.AdvanceSearchClaimIDTextBox, ClaimId);
                bi.WaitTime(5);
                bi.WaitVisible(obj_claims.AdvanceSearchButton);
                bi.Click(obj_claims.AdvanceSearchButton);
                bi.WaitTillNotVisible(obj_claims.imgLoadingClaim);
                bi.Click(obj_claims.ClaimSearchResult(ClaimId));
                bi.WaitTime(5);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);

                BrowserURLLaunch browserURLLaunch = new BrowserURLLaunch(Driver);
                Assert.False(bi.IsElementPresent(obj_claims.ClaimResponseDropdown));
                //{
                Console.WriteLine("Claim: " + BrowserURLLaunch.ROLES + "  doesnt have the option to Approve/Deny/Hold/Needs Information access");
                //}
                //else
                //{
                //Console.WriteLine("Claim: " + BrowserURLLaunch.ROLES + "  have option to Approve/Deny/Hold/Needs Information access");
                //}
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();

                Console.WriteLine("Exception: " + ex);
                throw;
                //Assert.Fail("Ace_Claim_ApprovalPermission failed due to " + ex);
            }
        }


        public void ClaimCreation_Negative()
        {
            //BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Claim_Negative));
          
            try
            {
                bi.WaitVisible(obj_claims.LeftNavClaim);
                bi.Click(obj_claims.LeftNavClaim);
                bi.WaitTillNotVisible(obj_claims.imgLoading);
                bi.WaitTime(10);
                //bi.WaitVisible(SubmitClaim);
                if (!bi.IsElementPresent(obj_claims.submitClaim_Claims))
                {
                    Console.WriteLine("Cannot create Claims, link to create Claims is not present in the application");
                }
                else
                {
                    bi.Click(obj_claims.submitClaim_Claims);
                    bi.WaitTillNotVisible(obj_claims.imgLoading);
                    bi.WaitTime(5);

                    //**Choose Program stepper
                    bi.WaitVisible(obj_claims.BPAForClaimNo);
                    bi.Click(obj_claims.BPAForClaimNo);
                    bi.WaitTillNotVisible(obj_claims.imgLoading);
                    bi.WaitTime(5);
                    BrowserURLLaunch browserURLLaunch = new BrowserURLLaunch(Driver);
                    if (BrowserURLLaunch.ROLES.Equals("CORPORATE1") || BrowserURLLaunch.ROLES.Equals("CORPORATE2"))
                    {
                        bi.WaitVisible(obj_claims.ClaimDropdown);
                        bi.Click(obj_claims.ClaimDropdown);
                        //bi.WaitTime(4);
                        bi.Type(obj_claims.ClaimText,Parameters.Bobcat_Test_LME());
                        bi.Type(obj_claims.ClaimText, Keys.Enter);
                        //bi.WaitVisible(obj_claims.ClaimTextSelected);
                        //bi.Click(obj_claims.ClaimTextSelected);
                        Console.WriteLine("CLAIM NEGATIVE: Store selected");
                    }

                    //bi.WaitTime(10);
                    //bi.Click(obj_claims.CoOpProgramRadioSelect(Parameters.Bobcat_ProgramName()));
                    bi.WaitTime(5);
                    bi.WaitVisible(obj_claims.ddlProgramName);
                    bi.Click(obj_claims.ddlProgramName);
                    //bi.WaitTime(2);
                    bi.TypeClear(obj_claims.txbSearchProgramName, Parameters.Bobcat_ProgramName());
                    bi.Type(obj_claims.txbSearchProgramName, Keys.Enter);
                    Console.WriteLine("CLAIM NEGATIVE: Program selected");
                    //Console.WriteLine("CLAIM NEGATIVE: Program selected");

                    bi.WaitVisible(obj_claims.NextButton);
                    bi.Click(obj_claims.NextButton);

                    //**Enter Details stepper
                    bi.WaitVisible(obj_claims.btnNext2);
                    bi.Click(obj_claims.btnNext2);
                    bi.Clear(obj_claims.ClaimReference);
                    bi.Type(obj_claims.ClaimReference, "REF-1234");
                    bi.WaitVisible(obj_claims.ddlMediaType);
                    bi.Click(obj_claims.ddlMediaType);

                    bi.WaitVisible(obj_claims.txbsearchMediaType);
                    bi.TypeClear(obj_claims.txbsearchMediaType, "Print");
                    bi.Type(obj_claims.txbsearchMediaType, Keys.Enter);

                    bi.WaitVisible(obj_claims.ddlTactic);
                    bi.WaitVisible(obj_claims.btnNext2);
                    bi.Click(obj_claims.btnNext2);
                    bi.WaitTime(5);
                    if (bi.IsElementPresent(obj_claims.ErrorActivityTypeRequired_bobcat))
                    {
                        //bi.WaitVisible(obj_claims.ActivityTypeDropdown);
                        bi.WaitVisible(obj_claims.ddlTactic);
                        bi.Click(obj_claims.ddlTactic);

                        bi.WaitVisible(obj_claims.txbsearchTactic);
                        bi.TypeClear(obj_claims.txbsearchTactic, "Direct Mail");
                        bi.Type(obj_claims.txbsearchTactic, Keys.Enter);
                        Console.WriteLine("CLAIM NEGATIVE: Activity Selected for Claim");
                    }

                    bi.Click(obj_claims.btnNext2);
                    if (bi.IsElementPresent(obj_claims.ErrorStartDateRequired))
                    {
                        bi.WaitVisible(obj_claims.ClaimStartdate);
                        bi.Click(obj_claims.ClaimStartdate);
                        //bi.WaitTime(2);
                        //ClaimStartDateSelection("April 22, 2018").Click();
                        bi.Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));
                        bi.WaitTime(5);
                        Console.WriteLine("CLAIM NEGATIVE: Start Date selected for Claim");

                    }

                    bi.Click(obj_claims.btnNext2);
                    if (bi.IsElementPresent(obj_claims.ErrorEndDateRequired))
                    {
                        //Element not visible
                        bi.WaitVisible(obj_claims.ClaimEndDate);
                        bi.Click(obj_claims.ClaimEndDate);
                        bi.WaitTime(5);
                        //ClaimEndDateSelection("April 29, 2018").Click();
                        bi.Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                        bi.WaitTime(5);
                        Console.WriteLine("CLAIM NEGATIVE: End Date selected for Claim");
                    }

                    bi.Click(obj_claims.btnNext2);
                    if (bi.IsElementPresent(obj_claims.ErrorTotalActivityCostReq))
                    {
                        bi.Type(obj_claims.ClaimTotalActivityCost, Parameters.ClaimTotalActivityCost_Bobcat);
                        Console.WriteLine("CLAIM NEGATIVE: Total Activity Cost entered for Claim");
                    }

                    bi.Click(obj_claims.btnNext2);
                    if(bi.IsElementPresent(obj_claims.ErrorClaimFeatureReq))
                    {
                        bi.Click(obj_claims.rbtnDataEquipmentNO);
                        Console.WriteLine("CLAIM NEGATIVE: ClaimFeature Selected");

                    }
                    bi.Click(obj_claims.btnNext2);
                    if (bi.IsElementPresent(obj_claims.ErrorVendorNameReq))
                    {
                        bi.TypeClear(obj_claims.ClaimVendorName, "Test");
                        Console.WriteLine("CLAIM NEGATIVE: VendorName entered for Claim");

                    }
                    bi.Click(obj_claims.btnNext2);
                    if (bi.IsElementPresent(obj_claims.ErrorRequestedAmountReq))
                    {
                        bi.Type(obj_claims.ClaimRequestedAmount, Parameters.ClaimRequestedAmount_Bobcat);
                        Console.WriteLine("CLAIM NEGATIVE: Requested Amount entered for Claim");
                    }
                    bi.Click(obj_claims.btnNext2);
                    if(bi.IsElementPresent(obj_claims.ErrorAknowledgementReq))
                    {
                        bi.Click(obj_claims.ClaimAcknowledgement);
                        Console.WriteLine("CLAIM NEGATIVE: ClaimAknowledgement  Selected");

                    }
                    bi.WaitVisible(obj_claims.btnNext2);
                    bi.Click(obj_claims.btnNext2);

                    //**Attach Document
                    bi.WaitVisible(obj_claims.btnNext3);
                    bi.ClickJavaScript(obj_claims.btnNext3);
                    if (bi.IsElementPresent(obj_claims.ErrorInvoiceRequired))
                    {
                        bi.WaitVisible(obj_claims.ClaimComments);
                        bi.Type(obj_claims.ClaimInvoice, "Claim-Invoice-1234");
                        bi.WaitTime(5);
                        Console.WriteLine("CLAIM NEGATIVE: Invoice number entered");
                    }

                    bi.Click(obj_claims.btnNext3);
                    //bi.WaitTime(1);
                    if (bi.IsElementPresent(obj_claims.ErrorAttachmentRequired_bobcat))
                    {
                        bi.WaitVisible(obj_claims.ClaimUpload);
                        bi.Click(obj_claims.ClaimUpload);
                        bi.WaitTime(3);
                        //File Upload
                        CommonUtilities.UploadFileInChrome("CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                        //bi.WaitVisible(obj_claims.ClaimComments);
                        //bi.Type(obj_claims.ClaimComments, "Claim-Comments");
                        if (bi.IsElementPresent(obj_claims.AttachementRemove))
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

                    bi.WaitVisible(obj_claims.ClaimComments);
                    bi.Type(obj_claims.ClaimComments, "Claim-Comments");
                    bi.WaitVisible(obj_claims.btnNext3);
                    bi.Click(obj_claims.btnNext3);
                    bi.WaitTime(5);
                    //Review and Submit
                    if (bi.IsElementPresent(obj_claims.SubmitButton))
                    {
                        Console.WriteLine("CLAIM NEGATIVE: Submit Button for submitting a Claim is present");
                    }
                }
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();

                Console.WriteLine("Exception: " + ex);
            }
        }

    }
}
