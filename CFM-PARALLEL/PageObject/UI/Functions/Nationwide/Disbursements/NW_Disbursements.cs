using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Disbursements;
using System;


namespace CFM_PARALLEL.PageObject.UI.Functions.Nationwide.Disbursements
{
    public class NW_Disbursements
    {           
       
        private OBJ_Claims obj_claims;        
        private OBJ_Disbursement obj_Disb;
       

        //Constructor
        public NW_Disbursements()
        {
            obj_claims = new OBJ_Claims();
            obj_Disb = new OBJ_Disbursement();

        }

        public void Manage_DisbursementsWorkFlow(String disbursement_id)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_Disb.LeftNavDisbursement);
                Pages.BasicInteractions().Click(obj_Disb.LeftNavDisbursement);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_Disb.NewDisbursement);

                Pages.BasicInteractions().Click(obj_claims.SimpleSearchTextbox);
                Pages.BasicInteractions().Type(obj_claims.SimpleSearchTextbox, disbursement_id);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error Message with an exception in Manage_DisbursementsWorkFlow method: " + ex.Message);
                throw;
            }
        }

        public void ProcessDisbursements(String disbursement_id , String action)
        {
            try
            {
                Manage_DisbursementsWorkFlow(disbursement_id);
                Pages .ManualDisbursement().OpenReviewPageWorkFlow(disbursement_id); // passing true param to validate Claim Status after creating 
                Pages.ManualDisbursement().ReviewProcessWorkFlow(action, disbursement_id); // Approve for Disbursment
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error Message with an exception in ProcessDisbursements method: " + ex.Message);
                throw;
            }
        }


        public string CreateNationWideDisbursementWorkflow(String claimID1, String claimID2)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_claims.SimpleSearchTextbox);
                Pages.BasicInteractions().Type(obj_claims.SimpleSearchTextbox, claimID1);
                Pages.BasicInteractions().Click(obj_Disb.FirstRowClaimID_Disbursement);

                Pages.BasicInteractions().Clear(obj_claims.SimpleSearchTextbox);
                Pages.BasicInteractions().Type(obj_claims.SimpleSearchTextbox, claimID2);
                Pages.BasicInteractions().Click(obj_Disb.FirstRowClaimID_Disbursement);



                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_Disb.PreviewDisbursement);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_Disb.SubmitButton);
                Pages.BasicInteractions().Click(obj_Disb.SubmitButton);
                Pages.BasicInteractions().WaitVisible(obj_Disb.SuccessMessage);
                Console.WriteLine(Pages.BasicInteractions().GetText(obj_Disb.SuccessMessage));
                Pages.BasicInteractions().WaitTime(10);
                String disbursementID = Pages.BasicInteractions().GetText(obj_Disb.DisbursementID);
                Pages.BasicInteractions().WaitTime(5);
                // Pages.BasicInteractions().Click(obj_Common.HomeButton);
                Pages.BasicInteractions().Gotourl("https://nationwide.v5stage.brandmuscle.net/LandingPages/LandingPageLayout4.aspx");
                Pages.BasicInteractions().WaitTime(5);
                return disbursementID;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error Message with an exception in CreateNationWideDisbursementWorkflow method: " + ex.Message);
                throw;
            }
        }

    }
}
