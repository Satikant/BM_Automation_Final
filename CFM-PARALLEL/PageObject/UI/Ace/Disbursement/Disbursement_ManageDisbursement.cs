using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace CFMAutomation.PageObject.UI.Ace.Disbursement
{
    public class Disbursement_ManageDisbursement
    {
        private IWebDriver Driver { get; set; }
        public Disbursement_ManageDisbursement(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }

        public By LeftNavManageDisbursement { get { return (By.Id("disbursementList")); } }
        public By TabPending { get { return (By.XPath("//div[contains(@class,'mat-tab-label-content') and contains(.,'Pending')]")); } }
        public By TabInProcess { get { return (By.XPath("//div[contains(@class,'mat-tab-label-content') and contains(.,'In Process')]")); } }
        public By TabCompleted { get { return (By.XPath("//div[contains(@class,'mat-tab-label-content') and contains(.,'Completed')]")); } }
        public By TabDeclined { get { return (By.XPath("//div[contains(@class,'mat-tab-label-content') and contains(.,'Declined')]")); } }
        public By ReviewDropdown { get { return (By.XPath("//mat-select[contains(@formcontrolname,'Review')]//div")); } }
        public By ReviewResponse(string responses) { return (By.XPath("//mat-option[contains(@class,'mat-option')]//span[contains(.,'"+responses+"')]"));  }
        public By ButtonSubmit { get { return (By.XPath("//button[contains(.,'Submit')]")); } }
        public By ButtonEditDisbursement { get {
                return (By.XPath("//button[contains(@class,'disb-button-primary mat-raised-button')]/span[contains(.,'Edit Disbursement')]")); } }
        public By ButtonRunDisbursement { get {
                return (By.XPath("//button[contains(@class,'primary-button')]//span[contains(.,'Run Disbursement')]")); } }
        public By DisbursementSearch { get { return (By.Id("txtSearch")); } }
        public By DisbursementStatusApprove { get { return (By.XPath("//mat-card-content[contains(@class,'detail-content mat-card-content')]/div[9]/div[2]")); } }
        public By DisbursementStatusDecline { get { return (By.XPath("//mat-card-content[contains(@class,'detail-content mat-card-content')]/div[8]/div[2]")); } }
        public By imgLoading { get { return By.Id("loading-image"); } }
        public By NoResult { get { return By.XPath("//*[contains(@class,'mat-card') and contains(text(),'No results')]"); } }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public void Ace_Disbursement_ManageDisbursement(string action)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Disbursement_ManageDisbursement));
            try
            {
                bi.WaitVisible(LeftNavManageDisbursement);
                bi.ClickJavaScript(LeftNavManageDisbursement);
                bi.WaitTillNotVisible(imgLoading);
                bi.WaitTime(5);
                bi.WaitVisible(TabPending);
                bi.Click(TabPending);
                bi.WaitVisible(DisbursementSearch);
                bi.Clear(DisbursementSearch);
                bi.Type(DisbursementSearch,Disbursement_Fullflow.DISB_ID);
                bi.WaitTime(3);
                bi.Type(DisbursementSearch, Keys.Enter);

                //if (bi.IsElementVisible(NoResult))
                //{
                //    bi.WaitVisible(TabInProcess);
                //    bi.Click(TabInProcess);
                //    bi.WaitVisible(DisbursementSearch);
                //    bi.Clear(DisbursementSearch);
                //    bi.Type(DisbursementSearch, Disbursement_Fullflow.DISB_ID);
                //    bi.WaitTime(3);
                //    bi.Type(DisbursementSearch, Keys.Enter);
                //}
                bi.WaitTime(10);
                bi.WaitVisible(ReviewDropdown);
                bi.Click(ReviewDropdown);
                bi.WaitVisible(ButtonSubmit);
                bi.Click(ReviewResponse(action));
                bi.Click(ButtonSubmit);
                bi.WaitTillNotVisible(imgLoading);
                bi.WaitTime(5);
                bi.WaitVisible(DisbursementSearch);
                bi.Clear(DisbursementSearch);
                bi.Type(DisbursementSearch,Disbursement_Fullflow.DISB_ID);

                if (action.Equals("Approve"))
                {
                    bi.WaitVisible(ButtonRunDisbursement);
                    bi.Click(ButtonRunDisbursement);
                    bi.WaitTillNotVisible(imgLoading);

                    bi.WaitTime(5);
                    bi.WaitVisible(TabCompleted);
                    bi.Click(TabCompleted);
                    bi.WaitTime(5);
                    bi.WaitVisible(DisbursementSearch);
                    bi.Clear(DisbursementSearch);
                    bi.Type(DisbursementSearch,Disbursement_Fullflow.DISB_ID);
                    bi.WaitTime(5);
                    bi.WaitVisible(DisbursementStatusApprove);
                    //Console.WriteLine(DisbursementStatus.GetText());
                    if (bi.GetText(DisbursementStatusApprove).Equals("Completed"))
                    {
                        Console.WriteLine("Disbursement in Completed status for " + Disbursement_Fullflow.DISB_ID);
                    }
                    else
                    {
                        Console.WriteLine("Disbursement NOT in Completed status for " + Disbursement_Fullflow.DISB_ID);
                    }
                }
                else if(action.Equals("Need"))
                {
                    if (bi.GetText(DisbursementStatusDecline).Equals("Needs Information"))
                    {
                        Console.WriteLine("Disbursement in Needs Information status for " + Disbursement_Fullflow.DISB_ID);
                    }
                    else
                    {
                        Console.WriteLine("Disbursement NOT in Needs Information status for " + Disbursement_Fullflow.DISB_ID);
                    }
                }
                else if (action.Equals("Deny"))
                {
                    bi.WaitVisible(TabDeclined);
                    bi.Click(TabDeclined);
                    bi.Clear(DisbursementSearch);
                    bi.Type(DisbursementSearch,Disbursement_Fullflow.DISB_ID);
                    bi.WaitTime(10);

                    if (bi.GetText(DisbursementStatusDecline).Equals("Denied"))
                    {
                        Console.WriteLine("Disbursement Deny for " + Disbursement_Fullflow.DISB_ID);
                    }
                    else
                    {
                        Console.WriteLine("Disbursement NOT in Deny status for " + Disbursement_Fullflow.DISB_ID);
                    }
                }

            }
            catch(Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
               
                Console.WriteLine("Ace_Disbursement_ManageDisbursement"+ex);
                Assert.Fail("Ace_Disbursement_ManageDisbursement" + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }
        }
    }
}
