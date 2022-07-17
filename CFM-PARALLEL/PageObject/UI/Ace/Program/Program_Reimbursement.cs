using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace CFMAutomation.PageObject.UI.Ace.Program
{
    public class Program_Reimbursement
    {
        private IWebDriver Driver { get; set; }
        public Program_Reimbursement(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }
        public By Reimbursement_Fixed { get { return (By.XPath("//div[contains(@class,'formio-component-ReimbursementType')]//span[contains(.,'Fixed')]")); } }
        public By Reimbursement_Variable { get { return (By.XPath("//div[contains(@class,'formio-component-ReimbursementType')]//span[contains(.,'Variable')]")); } }
        public By CappingYes { get { return (By.XPath("//div[contains(@class,'formio-component-AllowCapping')]//span[contains(.,'Yes')]")); } }
        public By CappingNo { get { return (By.XPath("//div[contains(@class,'formio-component-AllowCapping')]//span[contains(.,'No')]")); } }
        public By ReimburseFixedPercent { get { return (By.XPath("//input[contains(@name,'data[Activities][0][FixedReimbursement]')]")); } }
        public By NextButton { get { return (By.XPath("//button[contains(@class,'btn-wizard-nav-next')]")); } }
        public By ActivitySelection(string activityoption)
        {
            return (By.XPath("//label[contains(@class,'control-label form-check-label')]//span[contains(.,'"+activityoption+"')]"));
        }
        public void ActivityOption(string activityoption)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            bi.Click(ActivitySelection(activityoption));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db_reimbursementType"></param>
        /// <param name="db_reimbursementRate"></param>
        /// <param name="db_capping"></param>
        /// <param name="db_cappingpercent"></param>
        /// <param name="db_activityOptions"></param>
        public void ACE_Program_Reimbursement(string db_reimbursementType,string db_reimbursementRate,string db_capping,string db_cappingpercent,string db_activityOptions)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Program_Reimbursement));
            try
            {
                bi.WaitVisible(NextButton);
                if (db_reimbursementType.Equals("Fixed"))
                {
                    bi.WaitVisible(Reimbursement_Fixed);
                    bi.ClickJavaScript(Reimbursement_Fixed);
                    bi.WaitVisible(ReimburseFixedPercent);
                    bi.Clear(ReimburseFixedPercent);
                    bi.Type(ReimburseFixedPercent,db_reimbursementRate);
                }
                else if (db_reimbursementType.Equals("Variable"))
                {
                    bi.WaitVisible(Reimbursement_Variable);
                    bi.ClickJavaScript(Reimbursement_Variable);
                }

                if (db_capping.Equals("Y"))
                {
                    bi.WaitVisible(CappingYes);
                    bi.ClickJavaScript(CappingYes);
                }
                else if (db_capping.Equals("N"))
                {
                    bi.WaitVisible(CappingNo);
                    bi.ClickJavaScript(CappingNo);
                }

                ActivityOption("Direct Mail");
                bi.ClickJavaScript(NextButton);
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("ACE_Program_Reimbursement " + ex);
                Assert.Fail("ACE_Program_Reimbursement " + ex);
            }
        }
    }
}