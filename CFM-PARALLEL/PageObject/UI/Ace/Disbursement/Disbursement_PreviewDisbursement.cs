using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace CFMAutomation.PageObject.UI.Ace.Disbursement
{
    public class Disbursement_PreviewDisbursement
    {
        private IWebDriver Driver { get; set; }
        public Disbursement_PreviewDisbursement(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }
        public By ProceedButton { get { return (By.XPath("//button[contains(.,'Proceed')]")); } }

        /// <summary>
        /// 
        /// </summary>
        public void ACE_Disbursement_PreviewDisbursement()
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Disbursement_PreviewDisbursement));
            try
            {
                bi.WaitVisible(ProceedButton);
                bi.Click(ProceedButton);
                bi.WaitTime(10);
            }
            catch(Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("ACE_Disbursement_PreviewDisbursement: "+ex);
                Assert.Fail("ACE_Disbursement_PreviewDisbursement: " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }
        }
    }
}
