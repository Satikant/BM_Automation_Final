using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFM_PARALLEL.PageObject.UI.Functions.Pandora
{
    public class PN_Claim
    {
        private IWebDriver Driver;
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private BasicInteractions bi;
        //Constructor
        public PN_Claim(IWebDriver Driver)
        {
            this.Driver = Driver;
            
            obj_dashboard = new OBJ_Dashboard();
            bi = new BasicInteractions(Driver);
            obj_claims = new OBJ_Claims();
        }

        //Claim Creation
        public string ClaimCreation(string TotalActivityCost)
        {
            try
            {
                bi.WaitVisible(obj_dashboard.btnSubmit);
                bi.Click(obj_dashboard.btnSubmit);
                bi.WaitTime(2);
                bi.WaitVisible(obj_dashboard.btnSubmitClaim);
                bi.Click(obj_dashboard.btnSubmitClaim);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                //Fill details of Claim
                FillClaimDetails(TotalActivityCost);

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


        //Claim Clone
        public void ClaimClone(String ClaimID)
        {
            try
            {
                //Search the Claim
                SearchClaim(ClaimID);


                bi.WaitTime(10);
                bi.Click(obj_claims.ClaimSearchResult(ClaimID));
                //ClaimSearchResult.Click();
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTime(5);
                bi.WaitVisible(obj_claims.CloneButton);
                bi.Click(obj_claims.CloneButton);
                bi.WaitTime(15);
                //Claim_ChooseProgram.NextButton.Click();
                bi.Click(obj_claims.btnNext2);
                bi.WaitTime(10);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);


                //Entering Details
                //EnterDetails_Claim(Parameters.ClaimTotalActivityCost_Pandora, Parameters.ClaimRequestedAmount_Pandora);
                //Attaching Document
                AddingAttachment_Claim();

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
                bi.WaitTime(20);
                bi.WaitVisible(obj_claims.ClaimResponseDropdown);
                bi.Click(obj_claims.ClaimResponseDropdown);
                bi.WaitTime(10);
                bi.Click(obj_claims.ClaimResponse(Action));
                decimal strRequestedAmount = Convert.ToDecimal((bi.GetText(obj_claims.ClaimRequestedAmount_bobcat).Split('$')[1]).ToString());

                if (Action.Equals("Approve"))
                    {
                        bi.Clear(obj_claims.ClaimApprovedAmount);
                        bi.Type(obj_claims.ClaimApprovedAmount, strRequestedAmount.ToString());
                    }
                    bi.WaitVisible(obj_claims.ClaimSendResponseButton);
                    bi.Click(obj_claims.ClaimReviewCodeDropdown);
                    bi.WaitTime(5);
                bi.Type(obj_claims.ClaimReviewCodeText, Keys.Tab);

                bi.Click(obj_claims.ClaimReviewCodeTextSelect);
                //bi.Type(ClaimComments, "Claim-Perform Action Comments: " + action);
                bi.WaitTime(2);
                    bi.Click(obj_claims.ClaimSendResponseButton);
                    bi.WaitTillNotVisible(obj_claims.imgLoading);

                //bi.WaitTime(30);
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
        public void NavigatingToDashBoard()
        {
            try
            {
                bi.WaitTime(5);
                bi.WaitVisible(obj_claims.btnDashBoard);
                bi.Click(obj_claims.btnDashBoard);
                bi.WaitTillNotVisible(obj_claims.imgLoading);
            }
            catch (Exception ex)
            {
                  //CommonFunctions.KillProcess();
CommonUtilities.Logout(Driver);       Driver.Quit();
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
                bi.WaitTillNotVisible(obj_claims.LoadingImageClaim);
                ////**Simple Search functionality
                bi.WaitVisible(obj_claims.SearchClaim);
                bi.Clear(obj_claims.SearchClaim);
                bi.Type(obj_claims.SearchClaim,ClaimID);
                //bi.Type(obj_claims.SearchClaim,Keys.Enter);
                //bi.WaitTime(5);

                //**Advance Search functionality
                //bi.WaitVisible(obj_claims.AdvanceSearchLink);
                //bi.Click(obj_claims.AdvanceSearchLink);
                //bi.WaitVisible(obj_claims.AdvanceSearchClaimIDTextBox);
                //bi.TypeClear(obj_claims.AdvanceSearchClaimIDTextBox, ClaimID);
                //bi.WaitTime(5);
                bi.WaitVisible(obj_claims.AdvanceSearchButton);
                bi.Click(obj_claims.AdvanceSearchButton);
                bi.WaitTime(20);
                bi.WaitTillNotVisible(obj_claims.LoadingImageClaim);
                if (bi.IsElementVisible(obj_claims.tblEmptyMessage))
                {
                    Console.WriteLine(" Claim Not Available");
                }
                else
                {
                    Console.WriteLine("Claim Available");
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

        //Search Claim By ClaimID And GetStatus
        public string SearchClaimAndGetStatus(String ClaimID)
        {
            string ClaimStatus = string.Empty;
            try
            {
                bi.WaitTime(5);
                bi.WaitVisible(obj_claims.LeftNavClaim);
                bi.Click(obj_claims.LeftNavClaim);
                //bi.WaitTime(30);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTillNotVisible(obj_claims.imgLoadingClaim);
                ////**Simple Search functionality
                bi.WaitVisible(obj_claims.SearchClaim);
                bi.Clear(obj_claims.SearchClaim);
                bi.Type(obj_claims.SearchClaim, ClaimID);
                //bi.Type(obj_claims.SearchClaim, Keys.Enter);
                //bi.WaitTime(5);

                //**Advance Search functionality
                //bi.WaitVisible(obj_claims.AdvanceSearchLink);
                //bi.Click(obj_claims.AdvanceSearchLink);
                //bi.WaitVisible(obj_claims.AdvanceSearchClaimIDTextBox);
                //bi.TypeClear(obj_claims.AdvanceSearchClaimIDTextBox, ClaimID);
                //bi.WaitTime(5);
                bi.WaitVisible(obj_claims.AdvanceSearchButton);
                bi.Click(obj_claims.AdvanceSearchButton);
                bi.WaitTime(20);
                bi.WaitTillNotVisible(obj_claims.LoadingImageClaim);
                if (bi.IsElementVisible(obj_claims.tblEmptyMessage))
                {
                    Console.WriteLine(" Claim Not Available");
                }
                else
                {
                    bi.WaitTime(5);
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
                bi.WaitVisible(obj_claims.SearchClaim);
                bi.Clear(obj_claims.SearchClaim);
                bi.Type(obj_claims.SearchClaim, ClaimID);
                //bi.Type(obj_claims.SearchClaim, Keys.Enter);
                //bi.WaitTime(5);

                //**Advance Search functionality
                //bi.WaitVisible(obj_claims.AdvanceSearchLink);
                //bi.Click(obj_claims.AdvanceSearchLink);
                //bi.WaitVisible(obj_claims.ApprovedCheckbox);
                //bi.Click(obj_claims.PendingPaymentCheckbox);
                ////bi.WaitVisible(AdvanceSearchClaimIDTextBox);
                ////bi.Clear(AdvanceSearchClaimIDTextBox);
                ////bi.Type(AdvanceSearchClaimIDTextBox, ClaimId);
                //bi.WaitTime(10);
                bi.WaitVisible(obj_claims.AdvanceSearchButton);
                bi.Click(obj_claims.AdvanceSearchButton);
                bi.WaitTime(5);
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
        public void ClaimValidationAtLMELevel()
        {
            try
            {
            
            bi.WaitVisible(obj_dashboard.btnSubmit);
            bi.Click(obj_dashboard.btnSubmit);
            bi.WaitTime(2);
            bi.WaitVisible(obj_dashboard.btnSubmitClaim);
            bi.Click(obj_dashboard.btnSubmitClaim);
            bi.WaitTillNotVisible(obj_dashboard.imgLoading);

            FillClaimDetails(Parameters.ClaimTotalActivityCost_Pandora);


            bi.IsElementPresent(obj_claims.btnSubmit);
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

        public void FillClaimDetails(string TotalActivityCost)
        {
            try
            {
                //Select store and Program

                SelectStoreAndProgram_Claim();

                //Entering Details
                double ReqAmount=EnterDetails_Claim(TotalActivityCost);

                //Adding Attachment
                AddingAttachment_Claim();
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
               
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void SelectStoreAndProgram_Claim()
        {
            try
            {
                bi.WaitVisible(obj_claims.ddlStoreName);
                bi.Click(obj_claims.ddlStoreName);
                bi.WaitVisible(obj_claims.txbSearchStoreName);
                if (BrowserURLLaunch.EXECUTIONENVIRONMENT.ToUpper() == "PROD".ToUpper())
                {
                    bi.TypeClear(obj_claims.txbSearchStoreName, Parameters.Pandora_Test_LME_PROD);
                    bi.Type(obj_claims.txbSearchStoreName, Keys.Enter);

                    bi.WaitVisible(obj_claims.ddlProgramName);
                    bi.Click(obj_claims.ddlProgramName);
                    //bi.WaitTime(2);
                    bi.TypeClear(obj_claims.txbSearchProgramName, Parameters.Pandora_ProgramName());
                    bi.Type(obj_claims.txbSearchProgramName, Keys.Enter);
                }
                else
                {
                    bi.TypeClear(obj_claims.txbSearchStoreName, Parameters.Pandora_Test_LME);
                    bi.Type(obj_claims.txbSearchStoreName, Keys.Enter);

                    bi.WaitVisible(obj_claims.ddlProgramName);
                    bi.Click(obj_claims.ddlProgramName);
                    //bi.WaitTime(2);
                    bi.TypeClear(obj_claims.txbSearchProgramName, Parameters.Pandora_ProgramName());
                    bi.Type(obj_claims.txbSearchProgramName, Keys.Enter);
                }
                bi.WaitVisible(obj_claims.btnNext1);
                bi.Click(obj_claims.btnNext1);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
               
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
                bi.WaitTime(5);
                bi.WaitVisible(obj_claims.ClaimRequestedAmount_Pandora);
                bi.TypeClear(obj_claims.txbClaimDescription, "Claim Ref No 1234");
                bi.WaitVisible(obj_claims.ddlCampaign);
                bi.WaitTime(5);
                bi.Click(obj_claims.ddlCampaign);
                bi.WaitVisible(obj_claims.txbSearchCampaign);
                bi.WaitTime(5);
                bi.TypeClear(obj_claims.txbSearchCampaign, Keys.Enter);

                bi.WaitVisible(obj_claims.ddlTactic);
                bi.Click(obj_claims.ddlTactic);

                bi.WaitVisible(obj_claims.txbsearchTactic);
                bi.TypeClear(obj_claims.txbsearchTactic, "Direct Mail");
                bi.Type(obj_claims.txbsearchTactic, Keys.Enter);

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
                bi.Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                bi.WaitTime(5);


                bi.TypeClear(obj_claims.ClaimTotalActivityCost_Pandora, TotalActivityCost);
                bi.WaitTime(5);

                //Get Eligible Amount
               
                EligibleAmount = bi.GetAttribute(obj_claims.EligibleAmount, "value");
               

                bi.TypeClear(obj_claims.ClaimRequestedAmount_Pandora, EligibleAmount);
                bi.WaitTime(10);
                //Requested Amount is calculting like Eligible Amount;

                if (bi.IsElementDisplayed(obj_claims.ReqAmountConverted))
                {
                    RequestedAmount = Convert.ToDouble(bi.GetAttribute(obj_claims.ReqAmountConverted, "value"));
                }
                else
                {
                    RequestedAmount = Convert.ToDouble(EligibleAmount);
                }
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

        public void AddingAttachment_Claim()
        {
            try
            {
                bi.WaitVisible(obj_claims.ClaimComments);
                bi.Type(obj_claims.ClaimInvoice, "Claim-13445");
                bi.WaitTime(5);
                bi.WaitVisible(obj_claims.ClaimUpload);
                bi.Click(obj_claims.ClaimUpload);
                bi.WaitTime(3);
                //File Upload
                CommonUtilities.UploadFileInChrome("CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                //CommonUtilities.UploadFile("CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                bi.WaitTime(10);
                bi.WaitVisible(obj_claims.ClaimComments);
                bi.Type(obj_claims.ClaimComments, "Claim-Comments");
                bi.WaitVisible(obj_claims.btnNext3);
                bi.Click(obj_claims.btnNext3);
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
                bi.WaitTime(5);
                bi.WaitVisible(obj_claims.btnSubmit);
                bi.Click(obj_claims.btnSubmit);
                bi.WaitTime(10);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);

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

        //Claim Creation Negative
        public void ClaimCreation_Negative()
        {
            //BasicInteractions bi = new BasicInteractions(Driver);
            ////log4net.Config.XmlConfigurator.Configure();
            ////ILog logger = LogManager.GetLogger(typeof(Claim_Negative));
            //Claim_ChooseProgram claim_ChooseProgram = new Claim_ChooseProgram(Driver);
            //Claim_EnterDetails claim_EnterDetails = new Claim_EnterDetails(Driver);
            //Claim_AttachDocuments claim_AttachDocuments = new Claim_AttachDocuments(Driver);
            //Claim_ReviewSubmit claim_ReviewSubmit = new Claim_ReviewSubmit(Driver);
            try
            {
                bi.WaitVisible(obj_dashboard.btnSubmit);
                bi.Click(obj_dashboard.btnSubmit);
                bi.WaitTime(2);
                //bi.WaitVisible(obj_dashboard.btnSubmitClaim);
                // bi.Click(obj_dashboard.btnSubmitClaim);
                //bi.WaitTillNotVisible(obj_dashboard.imgLoading);


                //bi.WaitVisible(obj_claims.LeftNavClaim);
                //bi.Click(obj_claims.LeftNavClaim);
                //bi.WaitTillNotVisible(obj_claims.imgLoading);
                //bi.WaitTime(10);
                //bi.WaitVisible(SubmitClaim);
                if (!bi.IsElementPresent(obj_dashboard.btnSubmitClaim))
                {
                    Console.WriteLine("Cannot create Claims, link to create Claims is not present in the application");
                }
                else
                {
                    bi.WaitVisible(obj_dashboard.btnSubmitClaim);
                    bi.Click(obj_dashboard.btnSubmitClaim);
                    bi.WaitTillNotVisible(obj_dashboard.imgLoading);

                    //**Choose Program stepper
                    //bi.WaitVisible(obj_claims.BPAForClaimNo);
                    //bi.Click(obj_claims.BPAForClaimNo);
                    //bi.WaitTime(15);
                    BrowserURLLaunch browserURLLaunch = new BrowserURLLaunch(Driver);
                    if (BrowserURLLaunch.ROLES.Equals("CORPORATE1") || BrowserURLLaunch.ROLES.Equals("CORPORATE2"))
                    {
                        bi.WaitVisible(obj_claims.ddlStoreName);
                        bi.Click(obj_claims.ddlStoreName);
                        bi.WaitVisible(obj_claims.txbSearchStoreName);

                        bi.TypeClear(obj_claims.txbSearchStoreName, Parameters.Pandora_Test_LME);
                        bi.Type(obj_claims.txbSearchStoreName, Keys.Enter);

                        //bi.WaitVisible(obj_claims.ddlProgramName);
                        //bi.Click(obj_claims.ddlProgramName);
                        ////bi.WaitTime(2);
                        //bi.TypeClear(obj_claims.txbSearchProgramName, Parameters.Pandora_ProgramName());
                        //bi.Type(obj_claims.txbSearchProgramName, Keys.Enter);
                        Console.WriteLine("CLAIM NEGATIVE: Store selected");
                    }

                    bi.WaitTime(5);
                    bi.WaitVisible(obj_claims.ddlProgramName);
                    bi.Click(obj_claims.ddlProgramName);
                    //bi.WaitTime(2);
                    bi.TypeClear(obj_claims.txbSearchProgramName, Parameters.Pandora_ProgramName());
                    bi.Type(obj_claims.txbSearchProgramName, Keys.Enter);
                    Console.WriteLine("CLAIM NEGATIVE: Program selected");

                    bi.WaitVisible(obj_claims.NextButton);
                    bi.Click(obj_claims.NextButton);
                    bi.WaitTillNotVisible(obj_claims.imgLoading);
                    bi.WaitTime(2);
                    //**Enter Details stepper
                    bi.WaitVisible(obj_claims.btnNext2);
                    bi.Click(obj_claims.btnNext2);
                    bi.Clear(obj_claims.ClaimReference);
                    bi.Type(obj_claims.ClaimReference, "REF-1234");
                    bi.WaitVisible(obj_claims.btnNext2);
                    bi.Click(obj_claims.btnNext2);
                    if (bi.IsElementPresent(obj_claims.ErrorActivityTypeRequired))
                    {
                        bi.WaitVisible(obj_claims.ddlTactic);
                        bi.Click(obj_claims.ddlTactic);

                        bi.WaitVisible(obj_claims.txbsearchTactic);
                        bi.TypeClear(obj_claims.txbsearchTactic, "Direct Mail");
                        bi.Type(obj_claims.txbsearchTactic, Keys.Enter);
                        Console.WriteLine("CLAIM NEGATIVE: Tactic Selected for Claim");
                    }

                    bi.Click(obj_claims.btnNext2);
                    if (bi.IsElementPresent(obj_claims.ErrorStartDateRequired))
                    {
                        bi.WaitVisible(obj_claims.ClaimStartdate);
                        bi.Click(obj_claims.ClaimStartdate);
                        bi.Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));
                        Console.WriteLine("CLAIM NEGATIVE: Start Date selected for Claim");
                    }

                    bi.Click(obj_claims.btnNext2);
                    if (bi.IsElementPresent(obj_claims.ErrorEndDateRequired))
                    {
                        bi.WaitVisible(obj_claims.ClaimEndDate);
                        bi.Click(obj_claims.ClaimEndDate);
                        bi.WaitTime(5);
                        bi.Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                        Console.WriteLine("CLAIM NEGATIVE: End Date selected for Claim");
                    }

                    bi.Click(obj_claims.btnNext2);
                    if (bi.IsElementPresent(obj_claims.ErrorTotalActivityCostReq))
                    {
                        bi.Type(obj_claims.ClaimTotalActivityCost_Pandora, "300");
                        Console.WriteLine("CLAIM NEGATIVE: Total Activity Cost entered for Claim");
                    }

                    bi.WaitTime(5);
                    bi.Click(obj_claims.btnNext2);
                    if (bi.IsElementPresent(obj_claims.ErrorRequestedAmountReq))
                    {
                        bi.Type(obj_claims.ClaimRequestedAmount_Pandora, "20");
                        Console.WriteLine("CLAIM NEGATIVE: Requested Amount entered for Claim");
                    }
                    bi.Click(obj_claims.btnNext2);
                    if (bi.IsElementPresent(obj_claims.ErrorCampaignReq))
                    {
                        bi.WaitVisible(obj_claims.ddlCampaign);
                        bi.Click(obj_claims.ddlCampaign);
                        bi.WaitVisible(obj_claims.txbSearchCampaign);
                        bi.TypeClear(obj_claims.txbSearchCampaign, Keys.Enter);
                    }
                    bi.WaitTime(5);
                    bi.ClickJavaScript(obj_claims.btnNext2);
                    bi.WaitTime(5);
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
                    if (bi.IsElementPresent(obj_claims.ErrorAttachmentRequired))
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

                Console.WriteLine("Ace_Claim_Negative: " + ex);
                Assert.Fail("Ace_Claim_Negative: " + ex);
            }
        }

        public string ClaimResubmitted(string ClaimID)
        {
            try
            {
                bi.WaitVisible(obj_claims.LeftNavClaim);
                bi.Click(obj_claims.LeftNavClaim);
                bi.WaitTillNotVisible(obj_claims.imgLoading);
                bi.WaitTime(10);

                //**Simple Search functionality
                bi.WaitVisible(obj_claims.SearchClaim);
                bi.Clear(obj_claims.SearchClaim);
                bi.Type(obj_claims.SearchClaim, ClaimID);
                //bi.Type(obj_claims.SearchClaim, Keys.Enter);
                //bi.WaitTime(5);

                //**Advance Search functionality
                //bi.WaitVisible(obj_claims.AdvanceSearchLink);
                //bi.Click(obj_claims.AdvanceSearchLink);
                ////bi.WaitVisible(obj_claims.NeedsInformationCheckbox);
                ////bi.Click(obj_claims.NeedsInformationCheckbox);
                //bi.WaitVisible(obj_claims.AdvanceSearchClaimIDTextBox);
                //bi.Clear(obj_claims.AdvanceSearchClaimIDTextBox);
                //bi.Type(obj_claims.AdvanceSearchClaimIDTextBox, ClaimID);
                //bi.WaitTime(5);

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
                AddingAttachment_Claim();
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

                //selecting Program and Store
                SelectStoreAndProgram_Claim();


                bi.WaitVisible(obj_claims.ClaimRequestedAmount_Pandora);
                bi.TypeClear(obj_claims.txbClaimDescription, "Claim Ref No 1234");
                bi.WaitVisible(obj_claims.ddlCampaign);
                bi.Click(obj_claims.ddlCampaign);
                bi.WaitVisible(obj_claims.txbSearchCampaign);
                bi.TypeClear(obj_claims.txbSearchCampaign, Keys.Enter);

                bi.WaitVisible(obj_claims.ddlTactic);
                bi.Click(obj_claims.ddlTactic);

                bi.WaitVisible(obj_claims.txbsearchTactic);
                bi.TypeClear(obj_claims.txbsearchTactic, "Direct Mail");
                bi.Type(obj_claims.txbsearchTactic, Keys.Enter);

                //ActivityTypeText.Type(Keys.Enter);
                bi.WaitVisible(obj_claims.ClaimStartdate);
                bi.Click(obj_claims.ClaimStartdate);
                //ClaimStartDateSelection("April 22, 2018").Click();
                bi.Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateValidation_StartDate()));
                //Element not visible
                bi.WaitVisible(obj_claims.ClaimEndDate);
                bi.Click(obj_claims.ClaimEndDate);
                bi.WaitTime(10);
                //ClaimEndDateSelection("April 29, 2018").Click();
                bi.Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateValidation_EndDate()));
                bi.WaitTime(3);
                Assert.AreEqual(bi.GetText(obj_claims.EndDateErrorMsg).ToString(), "End date cannot be less than Start date");
                Console.WriteLine("Claim Date Validation is throwing error when End Date is less than Start Date");
                bi.WaitVisible(obj_claims.ClaimEndDate);
                bi.Click(obj_claims.ClaimEndDate);
                bi.Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                bi.WaitTime(3);
                if (!bi.IsElementPresent(obj_claims.EndDateErrorMsg))
                {
                    Console.WriteLine("Claim Date Validation is working fine when End Date is greater than Start Date");
                }
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("Ace_Claim_DateValidation " + ex);
                Assert.Fail("Ace_Claim_DateValidation " + ex);
            }
        }

        public void ClaimApprovalPermissionValidation(string ClaimId)
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
                bi.Type(obj_claims.SearchClaim, ClaimId);
                //bi.Type(obj_claims.SearchClaim, Keys.Enter);
                //bi.WaitTime(5);

                //**Advance Search functionality
                //bi.WaitVisible(obj_claims.AdvanceSearchLink);
                //bi.Click(obj_claims.AdvanceSearchLink);
                ////bi.WaitVisible(obj_claims.PendingReviewCheckbox);
                ////bi.Click(obj_claims.PendingReviewCheckbox);
                //bi.WaitVisible(obj_claims.AdvanceSearchClaimIDTextBox);
                //bi.Clear(obj_claims.AdvanceSearchClaimIDTextBox);
                //bi.Type(obj_claims.AdvanceSearchClaimIDTextBox, ClaimId);
                //bi.WaitTime(5);
                bi.WaitVisible(obj_claims.AdvanceSearchButton);
                bi.Click(obj_claims.AdvanceSearchButton);
                bi.WaitTime(5);
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
                
                Console.WriteLine("Ace_Claim_ApprovalPermission failed due to " + ex);
                Assert.Fail("Ace_Claim_ApprovalPermission failed due to " + ex);
            }
        }

        //Claim Approval Amount Validation
        public void ClaimApprovalAmountValidation(string ClaimId, string action, string reason)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Claim_PerformAction));
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
                //bi.WaitVisible(obj_claims.PendingReviewCheckbox);
                //bi.Click(obj_claims.PendingReviewCheckbox);
                bi.WaitVisible(obj_claims.AdvanceSearchClaimIDTextBox);
                bi.Clear(obj_claims.AdvanceSearchClaimIDTextBox);
                bi.Type(obj_claims.AdvanceSearchClaimIDTextBox, ClaimId);
                bi.WaitTime(5);
                bi.WaitVisible(obj_claims.AdvanceSearchButton);
                bi.Click(obj_claims.AdvanceSearchButton);
                bi.WaitTillNotVisible(obj_claims.imgLoadingClaim);
                bi.WaitTime(5);
                bi.Click(obj_claims.ClaimSearchResult(ClaimId));
                bi.WaitTime(20);
                decimal strRequestedAmount = Convert.ToDecimal((bi.GetText(obj_claims.ClaimRequestedAmount_bobcat).Split('$')[1]).ToString());
                bi.WaitVisible(obj_claims.ClaimResponseDropdown);
                bi.Click(obj_claims.ClaimResponseDropdown);
                bi.WaitTime(5);
                bi.Click(obj_claims.ClaimResponse(action));
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
                //bi.WaitVisible(obj_claims.ClaimSendResponseButton);
                //bi.Click(obj_claims.ClaimSendResponseButton);

                bi.WaitVisible(obj_claims.ClaimSendResponseButton);
                bi.Click(obj_claims.ClaimReviewCodeDropdown);
                bi.WaitTime(5);
                bi.Type(obj_claims.ClaimReviewCodeText, "84");
                bi.Click(obj_claims.ClaimReviewCodeTextSelect);
                Assert.IsFalse(bi.IsElementPresent(obj_claims.ApprovedAmountErrorMsg));
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

        
        //Claim Approve
        public void ClaimApprove(String ClaimID, String Action, string Reason,string ApprovalAmount)
        {
            try
            {
                //Search the Claim
                SearchClaim(ClaimID);
                bi.WaitTime(5);
                bi.Click(obj_claims.ClaimSearchResult(ClaimID));
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTime(5);
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
                    bi.Type(obj_claims.ClaimApprovedAmount, ApprovalAmount);
                }
                bi.WaitVisible(obj_claims.ClaimSendResponseButton);
                bi.Click(obj_claims.ClaimReviewCodeDropdown);
                bi.WaitTime(5);
                bi.Type(obj_claims.ClaimReviewCodeText, Reason);
                bi.WaitTime(5);
                bi.Click(obj_claims.ClaimReviewCodeTextSelect);
                //bi.Type(ClaimComments, "Claim-Perform Action Comments: " + action);
                bi.WaitTime(2);
                bi.Click(obj_claims.ClaimSendResponseButton);
                bi.WaitTillNotVisible(obj_claims.imgLoading);

                bi.WaitTime(20);
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


    }
}
