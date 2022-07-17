using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace CFM_PARALLEL.PageObject.UI.Ace.Claim
{
    public class Claim_ApprovalPermission
    {
        private IWebDriver Driver { get; set; }
        public Claim_ApprovalPermission(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }
        public By LeftNavClaim { get { return (By.Id("ManageClaim")); } }
        public By AdvanceSearchLink { get { return (By.PartialLinkText("Advanced Search")); } }
        public By AdvanceSearchClaimIDTextBox { get { return (By.Id("claimId")); } }
        public By AdvanceSearchButton { get { return (By.XPath("//button[contains(@class,'search-button')]")); } }
        public By PendingReviewCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Pending Review')]")); } }
        public By ClaimSearchResult(string ClaimId) { return (By.PartialLinkText(ClaimId)); }
        public By ClaimResponseDropdown { get { return (By.XPath("//p-dropdown[contains(@formcontrolname,'ReviewerAction')]/div//label")); } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ClaimId"></param>
        /// <param name="action"></param>
        /// <param name="reason"></param>
        public void Ace_Claim_ApprovalPermission(string ClaimId, string action, string reason)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            OBJ_Claims obj_claims = new OBJ_Claims();
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Claim_ApprovalPermission));
            try
            {
                bi.WaitTime(15);
                bi.WaitVisible(LeftNavClaim);
                bi.Click(LeftNavClaim);
                bi.WaitTime(15);

                //**Simple Search functionality
                bi.WaitVisible(obj_claims.SearchClaim);
                bi.Clear(obj_claims.SearchClaim);
                bi.Type(obj_claims.SearchClaim,ClaimId);
                //bi.Type(obj_claims.SearchClaim,Keys.Enter);
                //bi.WaitTime(10);

                //**Advance Search functionality
                //bi.WaitVisible(AdvanceSearchLink);
                //bi.Click(AdvanceSearchLink);
                ////bi.WaitVisible(PendingReviewCheckbox);
                ////bi.Click(PendingReviewCheckbox);
                //bi.WaitVisible(AdvanceSearchClaimIDTextBox);
                //bi.Clear(AdvanceSearchClaimIDTextBox);
                //bi.Type(AdvanceSearchClaimIDTextBox, ClaimId);
                //bi.WaitTime(10);
                bi.WaitVisible(AdvanceSearchButton);
                bi.Click(AdvanceSearchButton);
                bi.WaitTillNotVisible(obj_claims.ImgLoadingClaim);
                bi.WaitTime(2);
                bi.Click(ClaimSearchResult(ClaimId));
                bi.WaitTillNotVisible(obj_claims.ImgLoading);

                BrowserURLLaunch browserURLLaunch = new BrowserURLLaunch(Driver);
                if (!bi.IsElementPresent(ClaimResponseDropdown))
                {
                    Console.WriteLine("Claim: " + BrowserURLLaunch.ROLES + "  doesnt have the option to Approve/Deny/Hold/Needs Information access");
                }
                else
                {
                    Console.WriteLine("Claim: " + BrowserURLLaunch.ROLES + "  have option to Approve/Deny/Hold/Needs Information access");
                }
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
               
                Console.WriteLine("Ace_Claim_ApprovalPermission failed due to " + ex);
                Assert.Fail("Ace_Claim_ApprovalPermission failed due to " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }

        }
    }
}
