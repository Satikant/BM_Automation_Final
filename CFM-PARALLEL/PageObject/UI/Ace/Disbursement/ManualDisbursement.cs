using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Disbursements;
using NUnit.Framework;
using System;

namespace CFM_PARALLEL.PageObject.UI.Ace.Disbursement
{
    public class ManualDisbursement
    {       
        private OBJ_Claims obj_claims;  
        private OBJ_Disbursement obj_Disb;
        private OBJ_Common obj_Common;


        //Constructor
        public ManualDisbursement()
        {       
            obj_claims = new OBJ_Claims();          
            obj_Disb = new OBJ_Disbursement();
            obj_Common = new OBJ_Common();

        }

        public void Navigate_To_Disbursement_Page()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_Disb.LeftNavDisbursement);
                Pages.BasicInteractions().Click(obj_Disb.LeftNavDisbursement);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_Disb.NewDisbursement);
               
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Error Message with an exception in Navigate_To_Disbursement_Page method: " + ex.Message);
                throw;
            }
        }

        public string CreateDisbursementWorkflow()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_Disb.NewDisbursement);
                Pages.BasicInteractions().Click(obj_Disb.NewDisbursement);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_Disb.Filter);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_Disb.FirstRowClaimID_Disbursement);                   
                Pages.BasicInteractions().Click(obj_Disb.SecondRowClaimID_Disbursement);

                Pages.BasicInteractions().WaitVisible(obj_Disb.PreviewDisbursement);
                Pages.BasicInteractions().Click(obj_Disb.PreviewDisbursement);
                Pages.BasicInteractions().WaitVisible(obj_Disb.SubmitButton);
                Pages.BasicInteractions().Click(obj_Disb.SubmitButton);
                Pages.BasicInteractions().WaitVisible(obj_Disb.SuccessMessage);
                Console.WriteLine(Pages.BasicInteractions().GetText(obj_Disb.SuccessMessage));

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_Disb.BackArrow);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_Disb.NewDisbursement);
                Pages.BasicInteractions().Click(obj_Disb.DisbursementTab("In Process"));
                Pages.BasicInteractions().WaitTime(5);
                string Process_DisbID = Pages.BasicInteractions().GetText(obj_Disb.FirstRowDisbID);

                return Process_DisbID;
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Error Message with an exception in CreateDisbursementWorkflow method: " + ex.Message);
                throw;
            }
        }

        public void OpenReviewPageWorkFlow(String DisbId , Boolean isValidateClaimStatus=false)
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_Disb.LeftNavDisbursement);
                Pages.BasicInteractions().Click(obj_Disb.LeftNavDisbursement);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                //Simple Search 
                Pages.BasicInteractions().WaitVisible(obj_claims.SimpleSearchTextbox);
                Pages.BasicInteractions().Click(obj_claims.SimpleSearchTextbox);
                Pages.BasicInteractions().Type(obj_claims.SimpleSearchTextbox, DisbId);
               // Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_Disb.MoreButton);

                Pages.BasicInteractions().Click(obj_Disb.MoreButton);
                Pages.BasicInteractions().WaitVisible(obj_Disb.ReviewButton);

                if(isValidateClaimStatus)
                    ValidateClaimStatus(DisbId);

                Pages.BasicInteractions().Click(obj_Disb.ReviewButton);
                Pages.BasicInteractions().WaitTime(5);
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Error Message with an exception in OpenReviewPageWorkFlow method: " + ex.Message);
                throw;
            }
        }

        public void ReviewProcessWorkFlow(String action, string DisbId)
        {
            string Status;
            try
            {
                if (action.ToUpper().Equals("HOLD"))
                {
                    Pages.BasicInteractions().Click(obj_Disb.ReviewAction("Hold"));
                    Pages.BasicInteractions().WaitTime(2);
                    Pages.BasicInteractions().WaitVisible(obj_Disb.Comments);
                    Pages.BasicInteractions().Click(obj_Disb.Comments);
                    Pages.BasicInteractions().Type(obj_Disb.Comments, "TEST Hold Comment");
                    Pages.BasicInteractions().Click(obj_Disb.ConfirmReviewButton);
                    Pages.BasicInteractions().WaitVisible(obj_Disb.SuccessMessage);
                    Console.WriteLine(Pages.BasicInteractions().GetText(obj_Disb.SuccessMessage));
                    Pages.BasicInteractions().WaitTime(5);
                    Status = Pages.BasicInteractions().GetText(obj_Disb.FirstRowDisbursementStatus);
                    Console.WriteLine("Asserting for Status Hold to be displayed");
                    Assert.AreEqual(Status, "Hold");

                }
                else if (action.ToUpper().Equals("DENY")) { 

                    Pages.BasicInteractions().Click(obj_Disb.ReviewAction("Deny"));
                    Pages.BasicInteractions().WaitTime(2);
                    Pages.BasicInteractions().WaitVisible(obj_Disb.Comments);
                    Pages.BasicInteractions().Click(obj_Disb.Comments);
                    Pages.BasicInteractions().Type(obj_Disb.Comments, "TEST Deny Comment");
                    Pages.BasicInteractions().Click(obj_Disb.ConfirmReviewButton);
                    Pages.BasicInteractions().WaitVisible(obj_Disb.SuccessMessage);
                    Console.WriteLine(Pages.BasicInteractions().GetText(obj_Disb.SuccessMessage));
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_Disb.DisbursementTab("Declined"));
                    Pages.BasicInteractions().WaitTime(5);
                    Status = Pages.BasicInteractions().GetText(obj_Disb.FirstRowDisbursementStatus);
                    Assert.AreEqual(Status, "Denied");

                }
                else if (action.ToUpper().Equals("NEEDS CHANGE"))
                {

                    Pages.BasicInteractions().Click(obj_Disb.ReviewAction("Needs change"));
                    Pages.BasicInteractions().WaitTime(2);
                    Pages.BasicInteractions().WaitVisible(obj_Disb.Comments);
                    Pages.BasicInteractions().Click(obj_Disb.Comments);
                    Pages.BasicInteractions().Type(obj_Disb.Comments, "TEST Needs change Comment");
                    Pages.BasicInteractions().Click(obj_Disb.ConfirmReviewButton);
                    Pages.BasicInteractions().WaitVisible(obj_Disb.SuccessMessage);
                    Console.WriteLine(Pages.BasicInteractions().GetText(obj_Disb.SuccessMessage));
                    Pages.BasicInteractions().WaitTime(5);

                    //Simple Search 
                    Pages.BasicInteractions().WaitVisible(obj_claims.SimpleSearchTextbox);
                    Pages.BasicInteractions().Click(obj_claims.SimpleSearchTextbox);
                    Pages.BasicInteractions().Type(obj_claims.SimpleSearchTextbox, DisbId);
                    Pages.BasicInteractions().WaitTime(2);
                    if (!Pages.BasicInteractions().IsElementDisplayed(obj_claims.DisbIDText(DisbId))){

                        Pages.BasicInteractions().Click(obj_Disb.DisbursementTab("In Process"));
                        Pages.BasicInteractions().WaitTime(5);
                        string Process_DisbID = Pages.BasicInteractions().GetText(obj_Disb.FirstRowDisbID);
                    }                 
                    
                    String status = Pages.BasicInteractions().GetText(obj_Disb.FirstRowDisbursementStatus);
                    Assert.AreEqual(status, "Needs Information");
                }


                else if (action.ToUpper().Equals("APPROVE"))
                {
                    Pages.BasicInteractions().Click(obj_Disb.ReviewAction("Approve"));
                    Pages.BasicInteractions().WaitTime(2);
                    Pages.BasicInteractions().WaitVisible(obj_Disb.Comments);
                    Pages.BasicInteractions().Click(obj_Disb.Comments);
                    Pages.BasicInteractions().Type(obj_Disb.Comments, "TEST Approve Comment");
                    Pages.BasicInteractions().Click(obj_Disb.ConfirmReviewButton);
                    Pages.BasicInteractions().WaitVisible(obj_Disb.SuccessMessage);
                    Console.WriteLine(Pages.BasicInteractions().GetText(obj_Disb.SuccessMessage));
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_Disb.DisbursementTab("Completed"));
                    Pages.BasicInteractions().WaitTime(5);
                    String status = Pages.BasicInteractions().GetText(obj_Disb.FirstRowDisbursementStatus);
                    Assert.AreEqual(status, "Completed");

                    Pages.BasicInteractions().Click(obj_Disb.MoreButton);
                    Pages.BasicInteractions().WaitTime(5);
                    //ValidateClaimStatus();
                    Pages.BasicInteractions().WaitTime(2);
                    Pages.BasicInteractions().Click(obj_Common.ViewAssociatedClaimsLink);
                    Pages.BasicInteractions().WaitTime(5);
                    string ExpectedStatus = Pages.BasicInteractions().GetText(obj_Common.FirstRowClaimIdStatus);
                    Pages.BasicInteractions().Click(obj_Common.FirstRowClaimIdLink);
                    Pages.BasicInteractions().WaitTime(10);
                    string ActualStatus = Pages.BasicInteractions().GetText(obj_claims.ClaimStatusOnClaimReviewPage);
                    Console.WriteLine("Asserting for claim status on claim review page and disbursement detail page ");
                    Assert.AreEqual(ExpectedStatus, ActualStatus);

                }
            }
            catch (Exception ex)
            {              
                Console.WriteLine("Error Message with an exception in ReviewProcessWorkFlow method: " + ex.Message);
                throw;
            }
        }

        public void ValidateClaimStatus(string DisbId)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_Common.ViewAssociatedClaimsLink);
                Pages.BasicInteractions().WaitTime(10);
                string ExpectedStatus = Pages.BasicInteractions().GetText(obj_Common.FirstRowClaimIdStatus);
                Pages.BasicInteractions().Click(obj_Common.FirstRowClaimIdLink);
                Pages.BasicInteractions().WaitTime(10);
                string ActualStatus = Pages.BasicInteractions().GetText(obj_claims.ClaimStatusOnClaimReviewPage);
                Console.WriteLine("Asserting for claim status on claim review page and disbursement detail page ");
                Assert.AreEqual(ExpectedStatus, ActualStatus);
                Pages.BasicInteractions().WaitVisible(obj_Disb.LeftNavDisbursement);
                Pages.BasicInteractions().Click(obj_Disb.LeftNavDisbursement);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();


                //Simple Search 
                Pages.BasicInteractions().WaitVisible(obj_claims.SimpleSearchTextbox);
                Pages.BasicInteractions().Click(obj_claims.SimpleSearchTextbox);
                Pages.BasicInteractions().Type(obj_claims.SimpleSearchTextbox, DisbId);
                // Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_Disb.MoreButton);

                Pages.BasicInteractions().Click(obj_Disb.MoreButton);
                Pages.BasicInteractions().WaitVisible(obj_Disb.ReviewButton);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error Message with an exception in ValidateClaimStatus method: " + ex.Message);
                throw;
            }
        }

        public void SearchDisbId(string DisbId)
        {
            //Simple Search 
            Pages.BasicInteractions().WaitVisible(obj_claims.SimpleSearchTextbox);
            Pages.BasicInteractions().Click(obj_claims.SimpleSearchTextbox);
            Pages.BasicInteractions().Type(obj_claims.SimpleSearchTextbox, DisbId);
            Pages.BasicInteractions().WaitVisible(obj_Disb.MoreButton);
        }

        public void ResubmitDisbursementWorkflow(string DisbId)
        {
            Pages.BasicInteractions().WaitVisible(obj_claims.SimpleSearchTextbox);
            Pages.BasicInteractions().Click(obj_claims.SimpleSearchTextbox);
            Pages.BasicInteractions().Type(obj_claims.SimpleSearchTextbox, DisbId);
            Pages.BasicInteractions().WaitVisible(obj_Disb.MoreButton);
            Pages.BasicInteractions().Click(obj_Disb.MoreButton);
            Pages.BasicInteractions().WaitVisible(obj_Disb.ReviewButton);
            Pages.BasicInteractions().Click(obj_Disb.ReviewButton);
            Pages.BasicInteractions().WaitTime(5);
            Pages.BasicInteractions().WaitVisible(obj_Disb.SecondRowClaimID_Disbursement);
            Pages.BasicInteractions().Click(obj_Disb.SecondRowClaimID_Disbursement);
            Pages.BasicInteractions().WaitVisible(obj_Disb.PreviewDisbursement);
            Pages.BasicInteractions().Click(obj_Disb.PreviewDisbursement);
            Pages.BasicInteractions().WaitVisible(obj_Disb.SubmitButton);
            Pages.BasicInteractions().Click(obj_Disb.SubmitButton);
            Pages.BasicInteractions().WaitVisible(obj_Disb.SuccessMessage);
            Console.WriteLine(Pages.BasicInteractions().GetText(obj_Disb.SuccessMessage));
            Pages.BasicInteractions().WaitTime(5);
            Pages.BasicInteractions().Click(obj_Disb.BackArrow);
            Pages.BasicInteractions().WaitTime(5);
           
        }

    }
}
