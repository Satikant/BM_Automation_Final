using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace CFMAutomation.PageObject.UI.Ace.Disbursement
{
    public class Disbursement_SelectClaims
    {
        private IWebDriver Driver { get; set; }
        public Disbursement_SelectClaims(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }
        public By LeftNavCreateDisbursement { get { return (By.Id("disbursementEdit")); } }
        public By SubmitDisbursement { get { return (By.XPath("//button[contains(@class,'primary-button') and contains(.,'Disbursement')]")); } }
        public By ClaimSearch { get { return (By.Id("txtSearch")); } }
        public By ClaimCheckBox { get { return (By.XPath("//p-dtcheckbox[contains(@class,'ng-star-inserted')]/div/div[2]")); } }
        public By ButtonPreview { get { return (By.XPath("//button[contains(.,'Preview')]")); } }
        public By imgLoading { get { return By.Id("loading-image"); } }
        public By LeftNavDashboard { get { return (By.PartialLinkText("dashboard")); } }
        public By Submit { get { return By.XPath("//button[contains(@class,'dropdown-toggle') and contains(@aria-expanded,true)]"); } }
        public By CreateDisbursement { get { return (By.XPath("//a[contains(@class,'submit-menu-item') and contains(.,'Create Disbursement ')]")); } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CLAIM_ID"></param>
        public void ACE_Disbursement_SelectClaims(string CLAIM_ID)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Disbursement_SelectClaims));
            try
            {
                bi.WaitTime(5);
                bi.Click(LeftNavDashboard);
                bi.WaitTillNotVisible(imgLoading);
                bi.WaitTime(5);
                if (!bi.IsElementPresent(Submit))
                {
                    Console.WriteLine("Cannot create disbursements, link to create disbursements is not present in the application");
                }
                else
                {
                    //SearchClaim.Clear();
                    bi.Click(Submit);
                    bi.WaitVisible(CreateDisbursement);

                    bi.Click(CreateDisbursement);
                    //bi.WaitVisible(ClaimSearch);
                    bi.WaitTillNotVisible(imgLoading);
                    //bi.Click(SubmitDisbursement);
                   // bi.WaitTime(15);
                    bi.WaitVisible(ClaimSearch);
                    bi.Clear(ClaimSearch);
                    bi.Type(ClaimSearch, CLAIM_ID);
                    bi.WaitVisible(ClaimCheckBox);
                    bi.Click(ClaimCheckBox);
                    bi.WaitVisible(ButtonPreview);
                    bi.Click(ButtonPreview);
                }
            }
            catch(Exception ex)
            {
              
                Console.WriteLine("ACE_Disbursement_SelectClaims: "+ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }
        }
    }
}
