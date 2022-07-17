using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace CFM_PARALLEL.PageObject.UI.Ace.Claim
{
    public class Claim_Clone
    {
        private IWebDriver Driver { get; set; }
        public Claim_Clone(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }
        public By Dashboard { get { return (By.Id("dashboard")); } }
        public By imgLoading { get { return By.Id("loading-image"); } }
        public By LeftNavClaim { get { return (By.Id("ManageClaim")); } }
        public By SearchClaim { get { return (By.Id("searchId")); } }
        public By ClaimSearchResult(string ClaimId) { return (By.PartialLinkText(ClaimId)); }
        //public By ClaimSearchResult { get { return (By.XPath("//span[contains(@class,'ui-cell-data')]//a")); } }
        public By CloneButton { get { return (By.Id("clone")); } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ClaimID"></param>
        public void ACE_Claim_Clone(string ClaimID)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Claim_Clone));
            Claim_EnterDetails claim_EnterDetails = new Claim_EnterDetails(Driver);
            OBJ_Claims obj_claims = new OBJ_Claims();
            try
            {
                bi.WaitTime(10);
                bi.WaitVisible(LeftNavClaim);
                bi.Click(LeftNavClaim);
                bi.WaitTillNotVisible(obj_claims.ImgLoadingClaim);
                bi.WaitVisible(SearchClaim);
                bi.Clear(SearchClaim);
                bi.Type(SearchClaim, ClaimID);
                bi.Type(SearchClaim, Keys.Enter);
                bi.WaitTillNotVisible(obj_claims.ImgLoadingClaim);
                bi.Click(ClaimSearchResult(ClaimID));
                //ClaimSearchResult.Click();
                bi.WaitTime(10);
                bi.WaitVisible(CloneButton);
                bi.Click(CloneButton);
                bi.WaitTime(5);
                bi.WaitVisible(claim_EnterDetails.NextButton);
                //Claim_ChooseProgram.NextButton.Click();
                bi.Click(claim_EnterDetails.NextButton);
                bi.WaitTime(5);
                Claim_AttachDocuments ca = new Claim_AttachDocuments(Driver);
                ca.Ace_Claim_AttachDocument();
                bi.WaitTime(5);
                Claim_ReviewSubmit cr = new Claim_ReviewSubmit(Driver);
                cr.Ace_Claim_ReviewSubmit();
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
               
                Console.WriteLine("Claim_Clone: " + ex);
                Assert.Fail("Claim_Clone: " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }

        }

        public void NavigatingBackToDashBoard()
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            bi.WaitVisible(Dashboard);
            bi.Click(Dashboard);
            bi.WaitTillNotVisible(imgLoading);
        }
    }
}
