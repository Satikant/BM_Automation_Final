using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.DisplayClaims;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFM_PARALLEL.PageObject.UI.Functions.Prod_BU.Claims
{
    public class Claims_DisplayClaim
    {
        private OBJ_DisplayClaims obj_DisplayClaims;
        private OBJ_Common oBJ_Common;
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;


        //Constructor
        public Claims_DisplayClaim()
        {
            obj_DisplayClaims = new OBJ_DisplayClaims();
            oBJ_Common = new OBJ_Common();
            obj_dashboard = new OBJ_Dashboard();
            obj_claims = new OBJ_Claims();

        }

        public string Create_DisplayClaim(String MS_StoreName, string MS_ProgramName)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.LeftNavDisplayClaim);
                Pages.BasicInteractions().Click(obj_DisplayClaims.LeftNavDisplayClaim);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.SubmitDispalyClaimButton);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().Click(obj_DisplayClaims.SubmitDispalyClaimButton);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.StoreDropdown);

                EnterDetails(MS_StoreName, MS_ProgramName);

                AddingAttachment_DisplayClaim();

                string DisplayClaimID = Submit_Displayclaim();
                return DisplayClaimID;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Create_DisplayClaim method: " + ex.Message);
                throw;
            }
        }

        // submit Display Claim
        public string Submit_Displayclaim()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.SubmitButton);
                Pages.BasicInteractions().Click(obj_DisplayClaims.SubmitButton);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitTillNotVisible(obj_DisplayClaims.ImgLoading);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.DisplayClaimCreationSuccessfulMessage);
                Console.WriteLine(Pages.BasicInteractions().GetText(obj_DisplayClaims.DisplayClaimCreationSuccessfulMessage));
                string DisplayClaimID = Pages.BasicInteractions().GetText(obj_DisplayClaims.DisplayClaimCreationSuccessfulMessage).Trim().Split(' ')[0];

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_DisplayClaims.LeftNavDisplayClaim);
                Pages.BasicInteractions().WaitTime(15);

                Console.WriteLine("Display Claim id created = " + DisplayClaimID);
                return DisplayClaimID;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in Submit_Displayclaim:" + ex.Message);
                throw;
            }
        }
        //Fund Request review 
        public void Review_DisplayClaim(string DisplayClaimID, String Action)
        {
            try
            {
                Search_DisplayClaim(DisplayClaimID);
                Process_DisplayClaim(Action);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Review_DisplayClaim method" + ex.Message);
                throw;
            }
        }

        public void Resubmit_DisplayClaim(string DisplayClaimID)
        {
            try
            {
                Search_DisplayClaim(DisplayClaimID);

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_DisplayClaims.DisplayClaimIDLink);
                Pages.BasicInteractions().WaitTillNotVisible(obj_DisplayClaims.ImgLoading);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.EditDisplayClaimButton);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_DisplayClaims.EditDisplayClaimButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_DisplayClaims.ImgLoading);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.Next2Button);
                Pages.BasicInteractions().Click(obj_DisplayClaims.Next2Button);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().Click(obj_DisplayClaims.Next3Button);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().Click(obj_DisplayClaims.SubmitButton);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.DisplayClaimCreationSuccessfulMessage);
                Console.WriteLine(Pages.BasicInteractions().GetText(obj_DisplayClaims.DisplayClaimCreationSuccessfulMessage));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Resubmit_DisplayClaim method: " + ex.Message);
                throw;
            }
        }

        //Search Display Claim
        public void Search_DisplayClaim(String DisplayClaimID)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.LeftNavDisplayClaim);
                Pages.BasicInteractions().Click(obj_DisplayClaims.LeftNavDisplayClaim);
                Pages.BasicInteractions().WaitTillNotVisible(obj_DisplayClaims.ImgLoading);
                Pages.BasicInteractions().WaitTime(10);

                //Simple Search 
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.SearchTextbox);
                Pages.BasicInteractions().Clear(obj_DisplayClaims.SearchTextbox);
                Pages.BasicInteractions().Type(obj_DisplayClaims.SearchTextbox, DisplayClaimID);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_DisplayClaims.SearchButton);
                Pages.BasicInteractions().WaitTime(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Search_DisplayClaim method " + ex.Message);
                throw;
            }
        }


        public void Process_DisplayClaim(string Action)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_DisplayClaims.DisplayClaimIDLink);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.DisplayClaimResponseDropdown);
                Pages.BasicInteractions().Click(obj_DisplayClaims.DisplayClaimResponseDropdown);
                Pages.BasicInteractions().Type(obj_DisplayClaims.DisplayClaimResponseTextbox, Action);
                Pages.BasicInteractions().Type(obj_DisplayClaims.DisplayClaimResponseTextbox, Keys.Enter);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.SendResponseButton);
                Pages.BasicInteractions().Click(obj_DisplayClaims.SendResponseButton);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitTillNotVisible(obj_DisplayClaims.ImgLoading);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.SubmitDispalyClaimButton);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Process_DisplayClaim method " + ex.Message);
                throw;
            }
        }


        public string Clone_DisplayClaim(string DisplayClaimID)
        {
            try
            {
                Search_DisplayClaim(DisplayClaimID);

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_DisplayClaims.DisplayClaimIDLink);
                Pages.BasicInteractions().WaitTillNotVisible(obj_DisplayClaims.ImgLoading);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.CloneButton);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().Click(obj_DisplayClaims.CloneButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_DisplayClaims.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_DisplayClaims.Next2Button);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                //Adding Attachment
                AddingAttachment_DisplayClaim();
                Assert.True(Pages.BasicInteractions().IsElementDisplayed(obj_DisplayClaims.SubmitButton));
                Pages.BasicInteractions().Click(obj_DisplayClaims.SubmitButton);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.DisplayClaimCreationSuccessfulMessage);
                Console.WriteLine(Pages.BasicInteractions().GetText(obj_DisplayClaims.DisplayClaimCreationSuccessfulMessage));
                DisplayClaimID = Pages.BasicInteractions().GetText(obj_DisplayClaims.DisplayClaimCreationSuccessfulMessage).Trim().Split(' ')[0];
                return DisplayClaimID;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Clone_DisplayClaim method: " + ex.Message);
                throw;
            }
        }

        public void EnterDetails(String MS_StoreName, string MS_ProgramName)
        {
            try
            {
                Pages.BasicInteractions().Click(obj_DisplayClaims.StoreDropdown);
                Pages.BasicInteractions().Type(obj_DisplayClaims.StoreTextbox, MS_StoreName);
                Pages.BasicInteractions().Type(obj_DisplayClaims.StoreTextbox, Keys.Enter);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.ProgramDropdown);
                Pages.BasicInteractions().Click(obj_DisplayClaims.ProgramDropdown);
                Pages.BasicInteractions().Type(obj_DisplayClaims.ProgramTextbox, MS_ProgramName);
                Pages.BasicInteractions().Type(obj_DisplayClaims.ProgramTextbox, Keys.Enter);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_DisplayClaims.Next1Button);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().Click(obj_DisplayClaims.ReferenceTextbox);
                Pages.BasicInteractions().Type(obj_DisplayClaims.ReferenceTextbox, Parameters.MS_ReferenceName);
                Pages.BasicInteractions().Click(obj_DisplayClaims.OrderIdTextbox);
                Pages.BasicInteractions().Type(obj_DisplayClaims.OrderIdTextbox, Parameters.MS_OrderId);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().Click(obj_DisplayClaims.StartDate);
                Pages.BasicInteractions().Click(obj_DisplayClaims.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_DisplayClaims.EndDate);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_DisplayClaims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_DisplayClaims.PurchasedActivityCostTextbox);
                Pages.BasicInteractions().Type(obj_DisplayClaims.PurchasedActivityCostTextbox, Parameters.MS_TotalActivityCost);
                Pages.BasicInteractions().Click(obj_DisplayClaims.RequestedAmountTextbox);
                Pages.BasicInteractions().Type(obj_DisplayClaims.RequestedAmountTextbox, Parameters.MS_RequestedAmount);
                Pages.BasicInteractions().Click(obj_DisplayClaims.Next2Button);
                Pages.BasicInteractions().WaitTime(5);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in EnterDetails method: " + ex.Message);
                throw;
            }
        }

        //attachment adding to the display claim
        public void AddingAttachment_DisplayClaim()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(3);
                //File Upload
                CommonUtilities.UploadFile(oBJ_Common.FileUploadInput, "CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.CommentTextbox);
                Pages.BasicInteractions().Type(obj_DisplayClaims.CommentTextbox, "Submitted the Display claim");
                Pages.BasicInteractions().Click(obj_DisplayClaims.Next3Button);
                Pages.BasicInteractions().WaitTime(5);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in AddingAttachment_DisplayClaim: " + ex.Message);
                throw;
            }
        }
               
        public string Prod_BU_CreateClaim(string InvoiceNumber = "Test123")
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

                String ClaimID = Submit_Claim();
                return ClaimID;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Amnat_Claim_Fullflow method: " + ex.Message);
                throw;
            }
        }

        public string Submit_Claim()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(5);
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
                        Pages.BasicInteractions().TypeClear(obj_claims.CoopProgramTextWithBPA, Parameters.Prod_BU_ProgramName);                            
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
                        Pages.BasicInteractions().Type(obj_claims.ClaimText, Parameters.Prod_BU_StoreName);
                        Pages.BasicInteractions().Type(obj_claims.ClaimText, Keys.Enter);
                        Pages.BasicInteractions().WaitTime(2);
                        Pages.BasicInteractions().Click(obj_claims.CoopProgram);
                        Pages.BasicInteractions().WaitVisible(obj_claims.CoopProgramText);                        
                        Pages.BasicInteractions().TypeClear(obj_claims.CoopProgramText, Parameters.Prod_BU_ProgramName);                   
                        Pages.BasicInteractions().Type(obj_claims.CoopProgramText, Keys.Enter);
                    }
                    Pages.BasicInteractions().WaitVisible(obj_claims.NextButton);
                    Pages.BasicInteractions().Click(obj_claims.NextButton);
                    Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                    Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
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
               
                Pages.BasicInteractions().WaitVisible(obj_claims.AM_ActivityType);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_claims.AM_ActivityType);
                Pages.BasicInteractions().WaitVisible(obj_claims.AM_ActivityTypeTextbox);
                Pages.BasicInteractions().TypeClear(obj_claims.AM_ActivityTypeTextbox, "TV");
                Pages.BasicInteractions().Type(obj_claims.AM_ActivityTypeTextbox, Keys.Enter);
                

                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartdate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_claims.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));

                //Element not visible
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_claims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));

                // Eligible Amount
                Pages.BasicInteractions().TypeClear(obj_claims.ClaimTotalActivityCost, Parameters.MS_TotalActivityCost);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().TypeClear(obj_claims.ClaimRequestedAmount, Parameters.MS_RequestedAmount);
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

                Pages.BasicInteractions().WaitVisible(obj_claims.PaymentDate);
                Pages.BasicInteractions().Click(obj_claims.PaymentDate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_claims.PaymentDateSelection());
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimUpload);

                //File Upload
                CommonUtilities.UploadFile(oBJ_Common.FileUploadInput, "CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                Pages.BasicInteractions().WaitVisible(obj_claims.ClaimComments);
                Pages.BasicInteractions().Type(obj_claims.ClaimComments, "Claim-Comments");
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_claims.BtnNext3);
                Pages.BasicInteractions().Click(obj_claims.BtnNext3);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in AddingAttachment_Claim method: " + ex.Message);
                throw;
            }
        }
    }
}
