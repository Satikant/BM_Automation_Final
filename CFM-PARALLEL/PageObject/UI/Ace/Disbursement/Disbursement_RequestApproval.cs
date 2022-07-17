using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace CFMAutomation.PageObject.UI.Ace.Disbursement
{
    public class Disbursement_RequestApproval
    {
        private IWebDriver Driver { get; set; }
        public Disbursement_RequestApproval(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }
        public By DisbID { get {
                return (By.XPath("//mat-horizontal-stepper[contains(@class,'mat-stepper-horizontal')]/div[2]/div[3]/div/div/div[1]/div[1]/div[1]/div[1]/div[3]/div")); } }
        public By SubmitButton { get { return (By.XPath("//button[contains(.,'Submit')]")); } }
        public By imgLoading { get { return By.Id("loading-image"); } }

        /// <summary>
        /// 
        /// </summary>
        public void Ace_Disbursement_RequestApproval()
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Disbursement_RequestApproval));
            try
            {
                //Console.WriteLine("DISB ID: " + DisbID.GetText());
                Console.WriteLine("DISB ID: " + bi.GetText(DisbID));
                Disbursement_Fullflow.DISB_ID = bi.GetText(DisbID);
                bi.WaitVisible(SubmitButton);
                bi.Click(SubmitButton);
                bi.WaitTillNotVisible(imgLoading);
            }
            catch(Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("Ace_Disbursement_RequestApproval " + ex);
                Assert.Fail("Ace_Disbursement_RequestApproval " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }
        }
    }
}
