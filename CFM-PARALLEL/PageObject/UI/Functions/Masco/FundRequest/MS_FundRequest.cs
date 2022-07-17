using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.FundRequest;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace CFM_PARALLEL.PageObject.UI.Functions.Masco
{
    public class MS_FundRequest
    {
        private OBJ_FundRequest obj_FundRequest;
        private OBJ_Common oBJ_Common;

        //Constructor
        public MS_FundRequest()
        {
            obj_FundRequest = new OBJ_FundRequest();
            oBJ_Common = new OBJ_Common();
        }

        // fund request Creation
        public string Create_FundRequest(string MS_RequestedAmount, string MS_StoreName, string MS_ProgramName, Boolean isSubmissionRequired, String Env = "QA")
        {
            string FundRequestID = null;
            try
            {
                Pages.BasicInteractions().WaitUntilElementVisible(obj_FundRequest.LeftNavFundRequest,120);
                Pages.BasicInteractions().Click(obj_FundRequest.LeftNavFundRequest);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitVisible(obj_FundRequest.CreateFundRequestButton);
                Pages.BasicInteractions().Click(obj_FundRequest.CreateFundRequestButton);
                Pages.BasicInteractions().WaitVisible(obj_FundRequest.ProgramDropdown);

                //Fill details of fund request
                Pages.BasicInteractions().Click(obj_FundRequest.ProgramDropdown);
                Pages.BasicInteractions().Type(obj_FundRequest.ProgramTextbox, MS_ProgramName);
                Pages.BasicInteractions().Type(obj_FundRequest.ProgramTextbox, Keys.Enter);
                Pages.BasicInteractions().WaitTime(5);

                //Pages.BasicInteractions().WaitVisible(obj_FundRequest.StoreDropdown);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_FundRequest.StoreDropdown, 120);
                Pages.BasicInteractions().Click(obj_FundRequest.StoreDropdown);
                Pages.BasicInteractions().Type(obj_FundRequest.StoreTextbox, MS_StoreName);
                Pages.BasicInteractions().Type(obj_FundRequest.StoreTextbox, Keys.Enter);
                Pages.BasicInteractions().WaitVisible(obj_FundRequest.RequestedAmountTextbox,120);

                Pages.BasicInteractions().Click(obj_FundRequest.RequestedAmountTextbox);
                Pages.BasicInteractions().Type(obj_FundRequest.RequestedAmountTextbox, MS_RequestedAmount);

                AddingAttachment_FundRequest();

                Pages.BasicInteractions().Type(obj_FundRequest.CommentTextbox, "Submitted the fund request");
                Pages.BasicInteractions().Click(obj_FundRequest.ContinueButton);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                               
                //Submit FundRequset
                if (isSubmissionRequired) // Submit the fund request only if required
                {
                    FundRequestID = SubmitFundRequest();
                    Console.WriteLine("Fund request id created = " + FundRequestID);
                    string FundRequest_Status = Search_FundRequestStatus(FundRequestID); // Search_FundRequestStatus
                    Assert.AreEqual(FundRequest_Status, "Pending Review"); //Assertion used to validate the fund request status
                    Console.WriteLine("The status of the fund request after submission is  " + FundRequest_Status);
                }                
                return FundRequestID;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Create_FundRequest method :" + ex.Message);
                throw;
            }
        }

        //Validation of fund request
        public void Validate_FundRequest()
        {
            try
            {
                Create_FundRequest(Parameters.MS_RequestedAmount, Parameters.MS_FR_StoreName, Parameters.MS_FR_ProgramName, false, "PROD");
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_FundRequest.SubmitButton));
                Console.WriteLine("Submit Button Available");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in Validate_Fund_Request method :" + ex.Message);
                throw;
            }

        }

        // submit fund request
        public string SubmitFundRequest()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_FundRequest.SubmitButton);
                Pages.BasicInteractions().Click(obj_FundRequest.SubmitButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_FundRequest.ImgLoading);
                Pages.BasicInteractions().WaitVisible(obj_FundRequest.FundRequestSuccessfulMessage);
                Console.WriteLine(Pages.BasicInteractions().GetText(obj_FundRequest.FundRequestSuccessfulMessage));
                Pages.BasicInteractions().WaitTime(10);
                String FundRequestID = Pages.BasicInteractions().GetText(obj_FundRequest.FundRequestIDLink);
                return FundRequestID;

            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in SubmitFundRequest:" + ex.Message);
                throw;
            }
        }

        //attachment adding to the fund request
        public void AddingAttachment_FundRequest()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(3);                
                //File Upload
                CommonUtilities.UploadFile(oBJ_Common.FileUploadInput,"CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                Pages.BasicInteractions().WaitVisible(obj_FundRequest.ContinueButton);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in AddingAttachment_FundRequest: " + ex.Message);
                throw;
            }
        }

        //Search FundRequestID Status
        public string Search_FundRequestStatus(String FundRequestID)
        {
            string FundRequest_Status = string.Empty;
            try
            {
                Search_FundRequest(FundRequestID);
                FundRequest_Status = Pages.BasicInteractions().GetText(obj_FundRequest.FundRequestStatus);
                return FundRequest_Status; ;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Search_FundRequestStatus method" + ex.Message);
                throw;
            }
        }

        //Search Fund Request
        public void Search_FundRequest(String FundRequestID)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_FundRequest.LeftNavFundRequest);
                Pages.BasicInteractions().Click(obj_FundRequest.LeftNavFundRequest);
                Pages.BasicInteractions().WaitTillNotVisible(obj_FundRequest.ImgLoading);
                Pages.BasicInteractions().WaitTime(10);

                //Simple Search 
                Pages.BasicInteractions().WaitVisible(obj_FundRequest.SearchTextbox);
                Pages.BasicInteractions().Clear(obj_FundRequest.SearchTextbox);
                Pages.BasicInteractions().Type(obj_FundRequest.SearchTextbox, FundRequestID);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_FundRequest.SearchButton);
                Pages.BasicInteractions().WaitTime(5);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Search_FundRequset method " + ex.Message);
                throw;
            }
        }

        //Fund Request review 
        public void Review_FundRequest(String FundRequestID, String Action, String Amount)
        {
            try
            {
                Search_FundRequest(FundRequestID);
                Process_FundRequest(Action,Amount);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Review_FundRequest method" + ex.Message);
                throw;
            }
        }

        // fund request approve or deny
        public void Process_FundRequest(string Action,string Amount)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_FundRequest.FundRequestIDLink);
                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().WaitVisible(obj_FundRequest.UpdateStatusDropdown);
                Pages.BasicInteractions().Click(obj_FundRequest.UpdateStatusDropdown);

                // Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().Type(obj_FundRequest.UpdateStatusTexBox, Action);
                Pages.BasicInteractions().Type(obj_FundRequest.UpdateStatusTexBox, Keys.Enter);
                Pages.BasicInteractions().WaitTime(5);

                if (Action.Equals("Approve"))
                {
                   /* Pages.BasicInteractions().WaitVisible(obj_FundRequest.TransactionTypeDropdown);
                    Pages.BasicInteractions().Click(obj_FundRequest.TransactionTypeDropdown);
                    Pages.BasicInteractions().Type(obj_FundRequest.TransactionTypeTextBox, "Accrual");
                    Pages.BasicInteractions().Type(obj_FundRequest.TransactionTypeTextBox, Keys.Enter);
                    Pages.BasicInteractions().WaitTime(2);*/
                    Pages.BasicInteractions().Type(obj_FundRequest.ApprovalAmountTextBox, Amount);
                }
                

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Process_FundRequset method " + ex.Message);
                throw;
            }
        }

        public void Process_FundRequest_WorkFlow (string User , string FundRequestID, string Action, string Amount, int ReviewerLevel)
        {
            try
            {

                Pages.CommonFunctions().ExitEmulation();
                Pages.CommonFunctions().EmulateUser(User);
                Review_FundRequest(FundRequestID, Action, Amount);
                Validate_ReviewHistory_FundRequest(ReviewerLevel);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Process_FundRequest_WorkFlow method" + ex.Message);
                throw;
            }
        }

      
        public void Update_FundRequest()
        {
            try
            {
                Pages.BasicInteractions().Type(obj_FundRequest.CommentTextbox, "Test Comment");
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_FundRequest.SubmitButton);
                Pages.BasicInteractions().WaitVisible(obj_FundRequest.LeftNavFundRequest);
                Pages.BasicInteractions().WaitTime(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Update_FundRequest method" + ex.Message);
                throw;
            }
        }

        public void Validate_ReviewHistory_FundRequest(int ReviewerLevel)
        {
            try
            {
                if (ReviewerLevel >= 2)
                {
                    obj_FundRequest.SetXpath(1);
                    Console.WriteLine("Asserting for review history 1 to be displayed");
                    Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_FundRequest.ReviewHistoryLevel));
                }

                if (ReviewerLevel >= 3)
                {
                    obj_FundRequest.SetXpath(2);
                    Console.WriteLine("Asserting for review history 2 to be displayed");
                    Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_FundRequest.ReviewHistoryLevel));
                }

                if (ReviewerLevel >= 4)
                {
                    obj_FundRequest.SetXpath(3);
                    Console.WriteLine("Asserting for review history 3 to be displayed");
                    Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_FundRequest.ReviewHistoryLevel));
                }

                if (ReviewerLevel >= 5)
                {
                    obj_FundRequest.SetXpath(4);
                    Console.WriteLine("Asserting for review history 4 to be displayed ");
                    Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_FundRequest.ReviewHistoryLevel));
                }

                Update_FundRequest();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Validate_ReviewHistory_FundRequest method" + ex.Message);
                throw;
            }
        }
    }
}
