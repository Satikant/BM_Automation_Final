using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace CFMAutomation.PageObject.UI.Ace.Disbursement
{
    public class Disbursement_Negative
    {
        private IWebDriver Driver { get; set; }
        public Disbursement_Negative(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }
        public By LeftNavCreateDisbursement { get { return (By.Id("disbursementEdit")); } }
        public By LeftNavManageDisbursement { get { return (By.Id("disbursementList")); } }
        public By TabPending { get { return (By.XPath("//div[contains(@class,'mat-tab-label-content') and contains(.,'Pending')]")); } }
        public By TabInProcess { get { return (By.XPath("//div[contains(@class,'mat-tab-label-content') and contains(.,'In Process')]")); } }
        public By TabCompleted { get { return (By.XPath("//div[contains(@class,'mat-tab-label-content') and contains(.,'Completed')]")); } }
        public By TabDeclined { get { return (By.XPath("//div[contains(@class,'mat-tab-label-content') and contains(.,'Declined')]")); } }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Role"></param>
        public void Disbursement_Negative_LeftNavValidation(string Role)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Disbursement_Negative));
            try
            {
                if (bi.IsElementPresent(LeftNavCreateDisbursement))
                {
                    Console.WriteLine(Role + " can Create Disbursement");
                }
                else
                {
                    Console.WriteLine(Role+" does NOT have permission to Create Disbursement");
                    Console.WriteLine(Role+" cannot View, Edit, Clone or Perform action on Disbursement");
                }

                if (bi.IsElementPresent(LeftNavManageDisbursement))
                {
                    Console.WriteLine(Role + " can View/Manage Disbursement");
                }
                else
                {
                    Console.WriteLine(Role + " does NOT have permission to Manage Disbursement");
                }
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine(Role+" Disbursement_Negative_LeftNavValidation " + ex);
                Assert.Fail(Role+" Disbursement_Negative_LeftNavValidation " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }
        }

        public void Disbursement_Negative_ViewDisbursement(string Role)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Disbursement_Negative));
            try
            {
                if (bi.IsElementPresent(LeftNavManageDisbursement))
                {
                    Console.WriteLine(Role + " can View/Manage Disbursement");
                    bi.Click(LeftNavManageDisbursement);
                    bi.WaitVisible(TabPending);
                    Console.WriteLine(Role + " has access to disbursements created by them");
                }
                else
                {
                    Console.WriteLine(Role + " does NOT have permission to Manage Disbursement");
                }
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine(Role + " Disbursement_Negative_ViewDisbursement " + ex);

                Assert.Fail(Role + " Disbursement_Negative_ViewDisbursement " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }
        }
    }
}
