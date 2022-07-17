using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.DisplayClaims;
using CFMAutomation.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFM_PARALLEL.PageObject.UI.Functions.Nationwide
{
    public class NW_DisplayClaims
    {
        private IWebDriver Driver;
        private BasicInteractions bi;
        private OBJ_DisplayClaims obj_DisplayClaims;

        //Constructor
        public NW_DisplayClaims(IWebDriver Driver)
        {
            this.Driver = Driver;
            bi = new BasicInteractions(Driver);
            obj_DisplayClaims = new OBJ_DisplayClaims();
        }
        // display creation
        public string Create_DisplayClaim(string NW_RequestedAmount, string NW_StoreName, string NW_ProgramName)
        {
            try
            {
                bi.WaitTime(10);
                bi.WaitVisible(obj_DisplayClaims.LeftNavDisplayClaim);
                bi.Click(obj_DisplayClaims.LeftNavDisplayClaim);
                bi.WaitTime(10);
                bi.WaitVisible(obj_DisplayClaims.SubmitDispalyClaimButton);
                bi.Click(obj_DisplayClaims.SubmitDispalyClaimButton);
                bi.WaitVisible(obj_DisplayClaims.StoreDropdown);

                //Fill details of Display Claim
                bi.Click(obj_DisplayClaims.StoreDropdown);
                bi.Type(obj_DisplayClaims.StoreTextbox, NW_StoreName);
                bi.Type(obj_DisplayClaims.StoreTextbox, Keys.Enter);
                bi.WaitVisible(obj_DisplayClaims.ProgramDropdown);
                bi.Click(obj_DisplayClaims.ProgramDropdown);
                bi.Type(obj_DisplayClaims.ProgramTextbox, NW_ProgramName);
                bi.Type(obj_DisplayClaims.ProgramTextbox, Keys.Enter);
                bi.WaitTime(5);
                bi.Click(obj_DisplayClaims.Next1Button);
                bi.WaitTime(5);

                bi.Click(obj_DisplayClaims.ReferenceTextbox);
                bi.Type(obj_DisplayClaims.ReferenceTextbox, Parameters.NW_ReferenceName);
                bi.Click(obj_DisplayClaims.OrderIdTextbox);
                bi.Type(obj_DisplayClaims.OrderIdTextbox, Parameters.NW_OrderId);
                bi.Click(obj_DisplayClaims.StartDate);
                bi.Click(obj_DisplayClaims.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));
                bi.WaitTime(5);
                bi.Click(obj_DisplayClaims.EndDate);
                bi.WaitTime(5);
                bi.Click(obj_DisplayClaims.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                bi.WaitTime(5);
                bi.Click(obj_DisplayClaims.PurchasedActivityCostTextbox);
                bi.Type(obj_DisplayClaims.PurchasedActivityCostTextbox, Parameters.NW_PurchasedActivityCost);
                bi.Click(obj_DisplayClaims.RequestedAmountTextbox);
                bi.Type(obj_DisplayClaims.RequestedAmountTextbox, Parameters.NW_RequestedAmount);
                bi.Click(obj_DisplayClaims.Next2Button);
                bi.WaitTime(5);

                AddingAttachment_DisplayClaim();

                bi.Type(obj_DisplayClaims.CommentTextbox, "Submitted the Display claim");
                bi.Click(obj_DisplayClaims.Next3Button);
                bi.WaitTime(5);
                

                //Submit Display Claim
                string DisplayClaimID = SubmitDisplayclaim();
                Console.WriteLine("Display Claim id created = " + DisplayClaimID);
                return DisplayClaimID;
            }
            catch(Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                Console.WriteLine("Exception in Create_DisplayClaim method :" + ex.Message);
                throw;

            }
        }

        // submit Display Claim
        public string SubmitDisplayclaim()
        {
            try
            {
                bi.WaitTime(5);
                bi.WaitVisible(obj_DisplayClaims.SubmitButton);

                bi.Click(obj_DisplayClaims.SubmitButton);
                bi.WaitTime(10);
                bi.WaitTillNotVisible(obj_DisplayClaims.ImgLoading);
                bi.WaitVisible(obj_DisplayClaims.DisplayClaimCreationSuccessfulMessage);
                Console.WriteLine(bi.GetText(obj_DisplayClaims.DisplayClaimCreationSuccessfulMessage));
                bi.WaitTime(10);
                bi.Click(obj_DisplayClaims.LeftNavDisplayClaim);
                bi.WaitTime(15);

                String DisplayClaimID = bi.GetText(obj_DisplayClaims.DisplayClaimIDLink);
                return DisplayClaimID;
            }

            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                Console.WriteLine("Exception in SubmitDisplayclaim:" + ex.Message);
                throw;
            }
        }

        //attachment adding to the display claim
        public void AddingAttachment_DisplayClaim()
        {
            try
            {
                bi.Click(obj_DisplayClaims.UploadAttachment);
                bi.WaitTime(3);
                //File Upload
                CommonUtilities.UploadFileInChrome("CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                bi.WaitTime(10);

            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                Console.WriteLine("Exception in AddingAttachment_DisplayClaim: " + ex.Message);
                throw;
            }
        }

        //Search Display Claim
        public void Search_DisplayClaim(String DisplayClaimID)
        {
            try
            {
                bi.WaitTime(10);
                bi.WaitVisible(obj_DisplayClaims.LeftNavDisplayClaim);
                bi.Click(obj_DisplayClaims.LeftNavDisplayClaim);
                bi.WaitTillNotVisible(obj_DisplayClaims.ImgLoading);
                bi.WaitTime(10);

                //Simple Search 
                bi.WaitVisible(obj_DisplayClaims.SearchTextbox);
                bi.Clear(obj_DisplayClaims.SearchTextbox);
                bi.Type(obj_DisplayClaims.SearchTextbox, DisplayClaimID);
                bi.WaitTime(2);
                bi.Click(obj_DisplayClaims.SearchButton);
                bi.WaitTime(10);
            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                Console.WriteLine("Exception in Search_DisplayClaim method " + ex.Message);
                throw;
            }
        }



        //Search DisplayClaimID Status
        public string Search_DisplayClaimStatus(String DisplayClaimID)
        {
            string DisplayClaim_Status = string.Empty;
            try
            {
                Search_DisplayClaim(DisplayClaimID);
                DisplayClaim_Status = bi.GetText(obj_DisplayClaims.DisplayClaimStatus);
                bi.WaitTime(5);

                return DisplayClaim_Status;

            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                Console.WriteLine("Exception in Search_DisplayClaimStatus method" + ex.Message);
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
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                //CommonFunctions.KillProcess();
                Console.WriteLine("Exception in Review_FundRequest method" + ex.Message);
                throw;
            }
       }

        // Display Claim hold, needs change and deny
        public void Process_DisplayClaim(string Action)
        {
            try
            {
                bi.WaitTime(5);
                bi.Click(obj_DisplayClaims.DisplayClaimIDLink);
                bi.WaitTime(10);
                bi.WaitVisible(obj_DisplayClaims.DisplayClaimResponseDropdown);
                bi.Click(obj_DisplayClaims.DisplayClaimResponseDropdown);
                bi.Type(obj_DisplayClaims.DisplayClaimResponseTextbox, Action);
                bi.Type(obj_DisplayClaims.DisplayClaimResponseTextbox, Keys.Enter);
                bi.WaitTime(2);
                bi.WaitVisible(obj_DisplayClaims.SendResponseButton);

                bi.Click(obj_DisplayClaims.SendResponseButton);
                bi.WaitTime(5);
                bi.WaitTillNotVisible(obj_DisplayClaims.ImgLoading);
                bi.WaitTime(10);
                bi.WaitVisible(obj_DisplayClaims.SubmitDispalyClaimButton);
                



            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                Console.WriteLine("Exception in Process_FundRequset method " + ex.Message);
                throw;
            }

        }
        




    }
}
