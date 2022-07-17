using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.FundRequest;
using CFMAutomation.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFM_PARALLEL.PageObject.UI.Functions.Nationwide
{
    public class NW_FundRequest
    {

        private IWebDriver Driver;
        private BasicInteractions bi;
        private OBJ_FundRequest obj_FundRequest;

        //Constructor
        public NW_FundRequest(IWebDriver Driver)
        {
            this.Driver = Driver;
            bi = new BasicInteractions(Driver);
            obj_FundRequest = new OBJ_FundRequest();
           
        }
        // fund request Creation
        public string Create_FundRequest(string NW_RequestedAmount, string NW_StoreOrAgencyName, string NW_ProgramName , Boolean isSubmissionRequired, String Env="QA")
        {
            string FundRequestID = null;
            try
            {
                bi.WaitTime(10);
                bi.WaitVisible(obj_FundRequest.LeftNavFundRequest);
                bi.Click(obj_FundRequest.LeftNavFundRequest);
                bi.WaitTime(10);
                bi.WaitVisible(obj_FundRequest.CreateFundRequestButton);
                bi.Click(obj_FundRequest.CreateFundRequestButton);
                bi.WaitVisible(obj_FundRequest.ProgramDropdown);

                //Fill details of fund request
                bi.Click(obj_FundRequest.ProgramDropdown);
                bi.Type(obj_FundRequest.ProgramTextbox, NW_ProgramName);
                bi.Type(obj_FundRequest.ProgramTextbox, Keys.Enter);
                bi.WaitTime(2);

                Select_StoreOrAgencyName(NW_StoreOrAgencyName,Env);

                bi.Click(obj_FundRequest.RequestedAmountTextbox);
                bi.Type(obj_FundRequest.RequestedAmountTextbox, NW_RequestedAmount);
                bi.WaitTime(5);

                AddingAttachment_FundRequest();
                bi.Type(obj_FundRequest.CommentTextbox, "Submitted the fund request");
                bi.Click(obj_FundRequest.ContinueButton);
                bi.WaitTime(5);

              
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
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                Console.WriteLine("Exception in Create_FundRequest method :" + ex.Message);
                throw;
            }
        }

        //Validation of fund request
        public void Validate_FundRequest()
        {
            try
            {
                Create_FundRequest(Parameters.NW_RequestedAmount, Parameters.NW_Prod_AgencyName, Parameters.NW_Prod_ProgramName, false,"PROD");
                bi.IsElementPresent(obj_FundRequest.SubmitButton);
                Console.WriteLine("Submit Button Available");
            }
            
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                Console.WriteLine("Exception in Validate_Fund_Request method :" + ex.Message);
                throw;
            }

        }

        // select store name on QA or Agency Name on Prod
        public void Select_StoreOrAgencyName(string NW_StoreOrAgencyName, string Env)
        {
            try
            {
                bi.WaitTime(5);
                if (Env == "QA")
                    {

                        bi.Click(obj_FundRequest.StoreDropdown);
                        bi.Type(obj_FundRequest.StoreTextbox, NW_StoreOrAgencyName);
                        bi.Type(obj_FundRequest.StoreTextbox, Keys.Enter);
                    }
                    else {
                        bi.Click(obj_FundRequest.AgencyDropdown);
                        bi.Type(obj_FundRequest.AgencyTextbox, NW_StoreOrAgencyName);
                        bi.Type(obj_FundRequest.AgencyTextbox, Keys.Enter);
                    }
                bi.WaitTime(5);



            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                Console.WriteLine("Exception in Select_StoreOrAgencyName method :" + ex.Message);
                throw;
            }

        }


        // submit fund request
        public string SubmitFundRequest()
        {
            try
            {
                bi.WaitTime(5);
                bi.WaitVisible(obj_FundRequest.SubmitButton);
                bi.Click(obj_FundRequest.SubmitButton);
                bi.WaitTime(10);
                bi.WaitTillNotVisible(obj_FundRequest.ImgLoading);
                bi.WaitVisible(obj_FundRequest.FundRequestSuccessfulMessage);
                Console.WriteLine(bi.GetText(obj_FundRequest.FundRequestSuccessfulMessage));
                bi.WaitTime(5);
                String FundRequestID = bi.GetText(obj_FundRequest.FundRequestIDLink);
                return FundRequestID;
        }

            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                Console.WriteLine("Exception in SubmitFundRequest:" + ex.Message);
                throw;
            }
        }
        //attachment adding to the fund request
        public void AddingAttachment_FundRequest()
        {
            try
            {
                bi.Click(obj_FundRequest.FundRequestUpload);
                bi.WaitTime(3);
                //File Upload
                CommonUtilities.UploadFileInChrome("CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                bi.WaitTime(10);
                
            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
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
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                //CommonFunctions.KillProcess();
                Console.WriteLine("Exception in Review_FundRequest method" + ex.Message);
                throw;
            }
         }
        //Search Fund Request
        public void Search_FundRequset(String FundRequestID)
        {
            try
            {
                bi.WaitTime(10);
                bi.WaitVisible(obj_FundRequest.LeftNavFundRequest);
                bi.Click(obj_FundRequest.LeftNavFundRequest);
                bi.WaitTillNotVisible(obj_FundRequest.ImgLoading);
                bi.WaitTime(10);

                //Simple Search 
                bi.WaitVisible(obj_FundRequest.SearchTextbox);
                bi.Clear(obj_FundRequest.SearchTextbox);
                bi.Type(obj_FundRequest.SearchTextbox, FundRequestID);
                bi.WaitTime(2);
                bi.Click(obj_FundRequest.SearchButton);
                bi.WaitTime(5);
            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                Console.WriteLine("Exception in Search_FundRequset method " + ex.Message);
                throw;
            }
        }
        // fund request approve or deny
        public void Process_FundRequset( string Action)
        {
            try
            {
                bi.WaitTime(2);
                bi.Click(obj_FundRequest.FundRequestIDLink);
                bi.WaitTime(3);
                bi.WaitVisible(obj_FundRequest.UpdateStatusDropdown);
                bi.Click(obj_FundRequest.UpdateStatusDropdown);

                // bi.WaitTime(10);
                bi.Type(obj_FundRequest.UpdateStatusTexBox, Action);
                bi.Type(obj_FundRequest.UpdateStatusTexBox, Keys.Enter);
                bi.WaitTime(5);

                if (Action.Equals("Approve"))
                {
                    bi.WaitVisible(obj_FundRequest.TransactionTypeDropdown);
                    bi.Click(obj_FundRequest.TransactionTypeDropdown);
                    bi.Type(obj_FundRequest.TransactionTypeTextBox, "Accrual");
                    bi.Type(obj_FundRequest.TransactionTypeTextBox, Keys.Enter);
                    bi.Type(obj_FundRequest.ApprovalAmountTextBox, "100.55");
                }
                bi.Type(obj_FundRequest.CommentTextbox, "Test Comment");
                bi.Click(obj_FundRequest.SubmitButton);
                bi.WaitTillNotVisible(obj_FundRequest.ImgLoading);
                bi.WaitTime(10);
                bi.WaitVisible(obj_FundRequest.CreateFundRequestButton);
            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
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
                FundRequest_Status = bi.GetText(obj_FundRequest.FundRequestStatus);
                return FundRequest_Status; ;               
            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                Console.WriteLine("Exception in Search_FundRequestStatus method" + ex.Message);
                throw;
            }
        }

        // select business unit from dropdown just after login
        public void SelectNationwideBusinessUnit()
        {
            try
            {
                bi.SelectByValue(obj_FundRequest.NationwideBusinessUnit, "430");
            }

            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                Console.WriteLine("Exception in SelectNationwideBusinessUnit:" + ex.Message);
                throw;
            }
        }

        // emulate to real user
        public void EmulateUser()
        {
            try
            {
                bi.WaitVisible(obj_FundRequest.EmulateUser);
                bi.Click(obj_FundRequest.EmulateUser);
                bi.WaitVisible(obj_FundRequest.EmulateUserTextbox);
                bi.Click(obj_FundRequest.EmulateUserTextbox);
                bi.Type(obj_FundRequest.EmulateUserTextbox, Parameters.EmulateUserName);
                bi.WaitTime(5);
                bi.Type(obj_FundRequest.EmulateUserTextbox, Keys.Enter);
                bi.Click(obj_FundRequest.EmulationButton);
                bi.WaitVisible(obj_FundRequest.V5CFMLink);

                if (bi.IsElementPresent(obj_FundRequest.V5CFMLink))
                {
                    bi.WaitVisible(obj_FundRequest.V5CFMLink);
                    bi.Click(obj_FundRequest.V5CFMLink);
                    bi.WaitVisible(obj_FundRequest.LeftNavDashboard);
                    bi.WaitTime(5);
                }
                else
                {
                    Console.WriteLine("CFM Link is not Available");
                }
            }

            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                Console.WriteLine("Exception in EmulateUser:" + ex.Message);
                throw;
            }
        }


    }

}
