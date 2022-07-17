using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace CFM_PARALLEL.PageObject.UI.Ace.Claim
{
    public class Claim_Resubmitted
    {
        private IWebDriver Driver { get; set; }
        public Claim_Resubmitted(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }
        public By LeftNavClaim { get { return (By.Id("ManageClaim")); } }
        // Submit Pre-approvals button
        public By SearchClaim { get { return (By.Id("searchId")); } }
        public By AdvanceSearchLink { get { return (By.PartialLinkText("Advanced Search")); } }
        public By AdvanceSearchClaimIDTextBox { get { return (By.Id("claimId")); } }
        public By AdvanceSearchButton { get { return (By.XPath("//button[contains(@class,'search-button')]")); } }
        public By NeedsInformationCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Needs Information')]")); } }
        public By ClaimSearchResult(string ClaimId) { return (By.PartialLinkText(ClaimId)); }
        public By EditClaimButton { get { return (By.Id("edit")); } }
        public By imgLoading { get { return By.Id("loading-image"); } }
        public By imgLoadingClaim { get { return By.XPath("//img[@src='assets/images/Ellipsis.gif']"); } }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ClaimId"></param>
        public string Ace_Claim_Resubmitted(string ClaimId)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Claim_Resubmitted));
            Claim_EnterDetails claim_EnterDetails = new Claim_EnterDetails(Driver);
            try
            {
                bi.WaitVisible(LeftNavClaim);
                bi.Click(LeftNavClaim);
                bi.WaitTillNotVisible(imgLoading);
                bi.WaitTime(10);

                //**Simple Search functionality
                bi.WaitVisible(SearchClaim);
                bi.Clear(SearchClaim);
                bi.Type(SearchClaim,ClaimId);
               

                //**Advance Search functionality
                //bi.WaitVisible(AdvanceSearchLink);
                //bi.Click(AdvanceSearchLink);
                ////bi.WaitVisible(NeedsInformationCheckbox);
                ////bi.Click(NeedsInformationCheckbox);
                //bi.WaitVisible(AdvanceSearchClaimIDTextBox);
                //bi.Clear(AdvanceSearchClaimIDTextBox);
                //bi.Type(AdvanceSearchClaimIDTextBox, ClaimId);
                //bi.WaitTime(5);
                bi.WaitVisible(AdvanceSearchButton);
                bi.Click(AdvanceSearchButton);
                bi.WaitTillNotVisible(imgLoadingClaim);
                bi.WaitTime(5);
                bi.Click(ClaimSearchResult(ClaimId));
                bi.WaitTillNotVisible(imgLoading);
                bi.WaitTime(5);
                bi.WaitVisible(EditClaimButton);
                bi.Click(EditClaimButton);
                bi.WaitTillNotVisible(imgLoading);
                bi.WaitTime(5);
                bi.Click(claim_EnterDetails.NextButton);
                bi.WaitTime(5);
                Claim_AttachDocuments ca = new Claim_AttachDocuments(Driver);
                ca.Ace_Claim_AttachDocument();
                bi.WaitTime(5);
                Claim_ReviewSubmit cr = new Claim_ReviewSubmit(Driver);
                string ReSubmittedClaimID=cr.Ace_Claim_ReviewSubmit();
                return ReSubmittedClaimID;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }
    }
}
