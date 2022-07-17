using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.DisplayClaims;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace CFM_PARALLEL.PageObject.UI.Functions.Masco
{
    public class MS_DisplayClaims
    {
        private OBJ_DisplayClaims obj_DisplayClaims;
        private OBJ_Common oBJ_Common;

        //Constructor
        public MS_DisplayClaims()
        {
            obj_DisplayClaims = new OBJ_DisplayClaims();
            oBJ_Common = new OBJ_Common();
        }

        // Validate display claim creation
        public void Validate_DisplayClaims_FullFlow( string MS_StoreName, string MS_ProgramName)
        {
            try
            {
                Pages.BasicInteractions().WaitUntilElementVisible(obj_DisplayClaims.LeftNavDisplayClaim,120);
                Pages.BasicInteractions().Click(obj_DisplayClaims.LeftNavDisplayClaim);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_DisplayClaims.SubmitDispalyClaimButton,120);
                Pages.BasicInteractions().Click(obj_DisplayClaims.SubmitDispalyClaimButton);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.StoreDropdown);

                //Fill details of Display Claim
                EnterDetails(MS_StoreName, MS_ProgramName);

                AddingAttachment_DisplayClaim();               

                Assert.True(Pages.BasicInteractions().IsElementDisplayed(obj_DisplayClaims.SubmitButton));
                Console.WriteLine("Display Claim is Verified without clicking Submit button");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Validate_DisplayClaims_FullFlow method :" + ex.Message);
                throw;
            }
        }

        //attachment adding to the display claim
        public void AddingAttachment_DisplayClaim()
        {
            try
            {
                Pages.BasicInteractions().WaitUntilElementVisible(obj_DisplayClaims.CommentTextbox,120);
                //File Upload
                CommonUtilities.UploadFile(oBJ_Common.FileUploadInput,"CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.CommentTextbox);
                Pages.BasicInteractions().Type(obj_DisplayClaims.CommentTextbox, "Submitted the Display claim");
                Pages.BasicInteractions().Click(obj_DisplayClaims.Next3Button);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.SubmitButton);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in AddingAttachment_DisplayClaim: " + ex.Message);
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
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.Next1Button);
                Pages.BasicInteractions().Click(obj_DisplayClaims.Next1Button);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.ReferenceTextbox);
                Pages.BasicInteractions().Click(obj_DisplayClaims.ReferenceTextbox);
                Pages.BasicInteractions().Type(obj_DisplayClaims.ReferenceTextbox, Parameters.MS_ReferenceName);
                Pages.BasicInteractions().Click(obj_DisplayClaims.OrderIdTextbox);
                Pages.BasicInteractions().Type(obj_DisplayClaims.OrderIdTextbox, Parameters.MS_OrderId);
                Pages.BasicInteractions().Click(obj_DisplayClaims.ConfirmOrderIdTextbox);
                Pages.BasicInteractions().Type(obj_DisplayClaims.ConfirmOrderIdTextbox, Parameters.MS_OrderId);

                Pages.BasicInteractions().Click(obj_DisplayClaims.StartDate);
                Pages.BasicInteractions().Click(obj_DisplayClaims.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_DisplayClaims.EndDate);
                Pages.BasicInteractions().Click(obj_DisplayClaims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(obj_DisplayClaims.PurchasedActivityCostTextbox);
                Pages.BasicInteractions().Type(obj_DisplayClaims.PurchasedActivityCostTextbox, Parameters.MS_TotalActivityCost);
                Pages.BasicInteractions().Click(obj_DisplayClaims.RequestedAmountTextbox);
                Pages.BasicInteractions().Type(obj_DisplayClaims.RequestedAmountTextbox, Parameters.MS_RequestedAmount);
                Pages.BasicInteractions().Click(obj_DisplayClaims.Next2Button);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in EnterDetails method: " + ex.Message);
                throw;
            }
        }

        public string Create_DisplayClaim( String MS_StoreName, string MS_ProgramName)
        {
            try
            {
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
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.SubmitButton);

                Pages.BasicInteractions().Click(obj_DisplayClaims.SubmitButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_DisplayClaims.ImgLoading);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.DisplayClaimCreationSuccessfulMessage);
                Console.WriteLine(Pages.BasicInteractions().GetText(obj_DisplayClaims.DisplayClaimCreationSuccessfulMessage));

                string DisplayClaimID = Pages.BasicInteractions().GetText(obj_DisplayClaims.DisplayClaimCreationSuccessfulMessage);
                string[] str1 = DisplayClaimID.Split(' ');
                Console.WriteLine(str1[0]);
                return str1[0];

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

                Pages.BasicInteractions().WaitTime(2);
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
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.LeftNavDisplayClaim);
                Pages.BasicInteractions().Click(obj_DisplayClaims.LeftNavDisplayClaim);
                Pages.BasicInteractions().WaitTillNotVisible(obj_DisplayClaims.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                //Simple Search 
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.SearchTextbox);
                Pages.BasicInteractions().Clear(obj_DisplayClaims.SearchTextbox);
                Pages.BasicInteractions().Type(obj_DisplayClaims.SearchTextbox, DisplayClaimID);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_DisplayClaims.SearchButton);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.DisplayClaimIDLink);

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
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.DisplayClaimIDLink);
                Pages.BasicInteractions().Click(obj_DisplayClaims.DisplayClaimIDLink);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.DisplayClaimResponseDropdown);
                Pages.BasicInteractions().Click(obj_DisplayClaims.DisplayClaimResponseDropdown);
                Pages.BasicInteractions().Type(obj_DisplayClaims.DisplayClaimResponseTextbox, Action);
                Pages.BasicInteractions().Type(obj_DisplayClaims.DisplayClaimResponseTextbox, Keys.Enter);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.SendResponseButton);

                Pages.BasicInteractions().Click(obj_DisplayClaims.SendResponseButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_DisplayClaims.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
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

                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.DisplayClaimIDLink);
                Pages.BasicInteractions().Click(obj_DisplayClaims.DisplayClaimIDLink);
                Pages.BasicInteractions().WaitTillNotVisible(obj_DisplayClaims.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.CloneButton);
                Pages.BasicInteractions().Click(obj_DisplayClaims.CloneButton);
                Pages.BasicInteractions().WaitTillNotVisible(obj_DisplayClaims.ImgLoading);
                Pages.BasicInteractions().WaitVisible(obj_DisplayClaims.Next2Button);
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
    }
}
