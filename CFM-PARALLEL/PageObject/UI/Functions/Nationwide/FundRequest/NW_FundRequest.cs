using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.FundRequest;
using CFMAutomation.Common;
using OpenQA.Selenium;
using System;
using NUnit.Framework;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;

namespace CFM_PARALLEL.PageObject.UI.Functions.Nationwide
{
    public class NW_FundRequest
    {
       
        private OBJ_FundRequest obj_FundRequest;
        private OBJ_Common oBJ_Common;

        //Constructor
        public NW_FundRequest()
        {
            
            obj_FundRequest = new OBJ_FundRequest();
            oBJ_Common = new OBJ_Common();
           
        }
        // fund request Creation
        public string Create_FundRequest(string NW_RequestedAmount, string NW_StoreOrAgencyName, string NW_ProgramName , Boolean isSubmissionRequired, String Env="QA")
        {
            string FundRequestID = null;
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_FundRequest.LeftNavFundRequest);
                Pages.BasicInteractions().Click(obj_FundRequest.LeftNavFundRequest);
                Pages.BasicInteractions().WaitVisible(obj_FundRequest.CreateFundRequestButton);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().Click(obj_FundRequest.CreateFundRequestButton);
                Pages.BasicInteractions().WaitVisible(obj_FundRequest.ProgramDropdown);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                //Fill details of fund request
                Pages.BasicInteractions().Click(obj_FundRequest.ProgramDropdown);
                Pages.BasicInteractions().Type(obj_FundRequest.ProgramTextbox, NW_ProgramName);
                Pages.BasicInteractions().Type(obj_FundRequest.ProgramTextbox, Keys.Enter);
                Pages.BasicInteractions().WaitTime(2);

                Select_StoreOrAgencyName(NW_StoreOrAgencyName,Env);

                Pages.BasicInteractions().Click(obj_FundRequest.RequestedAmountTextbox);
                Pages.BasicInteractions().Type(obj_FundRequest.RequestedAmountTextbox, NW_RequestedAmount);
                Pages.BasicInteractions().WaitTime(5);

                AddingAttachment_FundRequest();
                Pages.BasicInteractions().Type(obj_FundRequest.CommentTextbox, "Submitted the fund request");
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_FundRequest.ContinueButton);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();


                //Submit FundRequset
                if (isSubmissionRequired) // Submit the fund request only if required
                {
                    FundRequestID = SubmitFundRequest();
                    Console.WriteLine("Fund request id created = " + FundRequestID);
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
                Create_FundRequest(Parameters.NW_RequestedAmount, Parameters.NW_Prod_AgencyName1, Parameters.NW_Prod_ProgramName, false,"PROD");
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_FundRequest.SubmitButton));
                Console.WriteLine("Submit Button Available");
            }
            
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Validate_Fund_Request method :" + ex.Message);
                throw;
            }

        }

        // select store name on QA or Agency Name on Prod
        public void Select_StoreOrAgencyName(string NW_StoreOrAgencyName, string Env)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                if (Env == "QA")
                    {

                        Pages.BasicInteractions().Click(obj_FundRequest.StoreDropdown);
                        Pages.BasicInteractions().Type(obj_FundRequest.StoreTextbox, NW_StoreOrAgencyName);
                        Pages.BasicInteractions().Type(obj_FundRequest.StoreTextbox, Keys.Enter);
                    }
                    else {
                        Pages.BasicInteractions().Click(obj_FundRequest.AgencyDropdown);
                        Pages.BasicInteractions().Type(obj_FundRequest.AgencyTextbox, NW_StoreOrAgencyName);
                        Pages.BasicInteractions().Type(obj_FundRequest.AgencyTextbox, Keys.Enter);
                    }
                Pages.BasicInteractions().WaitTime(5);



            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Select_StoreOrAgencyName method :" + ex.Message);
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
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitTillNotVisible(obj_FundRequest.ImgLoading);
                Pages.BasicInteractions().WaitVisible(obj_FundRequest.FundRequestSuccessfulMessage);
                Console.WriteLine(Pages.BasicInteractions().GetText(obj_FundRequest.FundRequestSuccessfulMessage));
                Pages.BasicInteractions().WaitTime(5);
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
                Pages.BasicInteractions().WaitVisible(obj_FundRequest.FundRequestUpload);
                Pages.BasicInteractions().WaitTime(3);
                //File Upload
                CommonUtilities.UploadFile(oBJ_Common.FileUploadInput,"CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                Pages.BasicInteractions().WaitTime(10);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in AddingAttachment_FundRequest: " + ex.Message);
                throw;
            }
        }

        //Fund Request review 
        public void Review_FundRequest(String FundRequestID, String Action)
        {
            try
            {
                Search_FundRequset(FundRequestID);
                Process_FundRequset(Action);
             }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Review_FundRequest method" + ex.Message);
                throw;
            }
         }
        //Search Fund Request
        public void Search_FundRequset(String FundRequestID)
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
        // fund request approve or deny
        public void Process_FundRequset( string Action)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_FundRequest.FundRequestIDLink);
                Pages.BasicInteractions().WaitTime(3);
                Pages.BasicInteractions().WaitVisible(obj_FundRequest.UpdateStatusDropdown);
                Pages.BasicInteractions().Click(obj_FundRequest.UpdateStatusDropdown);

                Pages.BasicInteractions().Type(obj_FundRequest.UpdateStatusTexBox, Action);
                Pages.BasicInteractions().Type(obj_FundRequest.UpdateStatusTexBox, Keys.Enter);
                Pages.BasicInteractions().WaitTime(5);

                if (Action.Equals("Approve"))
                {
                    Pages.BasicInteractions().WaitVisible(obj_FundRequest.TransactionTypeDropdown);
                    Pages.BasicInteractions().Click(obj_FundRequest.TransactionTypeDropdown);
                    Pages.BasicInteractions().Type(obj_FundRequest.TransactionTypeTextBox, "Accrual");
                    Pages.BasicInteractions().Type(obj_FundRequest.TransactionTypeTextBox, Keys.Enter);
                    Pages.BasicInteractions().Type(obj_FundRequest.ApprovalAmountTextBox, "100.55");
                }
                Pages.BasicInteractions().Type(obj_FundRequest.CommentTextbox, "Test Comment");
                Pages.BasicInteractions().Click(obj_FundRequest.SubmitButton);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
               // Pages.BasicInteractions().WaitTillNotVisible(obj_FundRequest.ImgLoading);
                Pages.BasicInteractions().WaitVisible(obj_FundRequest.CreateFundRequestButton);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Process_FundRequset method " + ex.Message);
                throw;
            }

        }
        //Search FundRequestID Status
        public string Search_FundRequestStatus(String FundRequestID)
        {
            string FundRequest_Status = string.Empty;
            try
            {
                Search_FundRequset(FundRequestID);
                FundRequest_Status = Pages.BasicInteractions().GetText(obj_FundRequest.FundRequestStatus);
                return FundRequest_Status; ;               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Search_FundRequestStatus method" + ex.Message);
                throw;
            }
        }

       

    }

}
