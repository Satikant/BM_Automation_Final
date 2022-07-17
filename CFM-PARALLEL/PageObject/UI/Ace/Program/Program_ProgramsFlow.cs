using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace CFMAutomation.PageObject.UI.Ace.Program
{
    public class Program_ProgramsFlow
    {
        private IWebDriver Driver { get; set; }
        public Program_ProgramsFlow(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }
        public By ClaimFlow { get { return (By.XPath("//span[contains(.,'Activity Type')]")); } }
        //public By OverdraftYes { get { return (By.XPath("//div[contains(@class,'formio-component-AllowOverdraft')]//span[contains(.,'Yes')]")); } }
        //public By OverdraftNo { get { return (By.XPath("//div[contains(@class,'formio-component-AllowOverdraft')]//span[contains(.,'No')]")); } }
        public By FundOrganizationHierarchy { get { return (By.XPath("//label[contains(@class,'control-label form-check-label')]//span[contains(.,'Organization Hierarchy')]")); } }
        public By FundMatchingHierarchy { get { return (By.XPath("//label[contains(@class,'control-label form-check-label')]//span[contains(.,'Matching Fund Hierarchy')]")); } }
        public By FundGroupHierarchy { get { return (By.XPath("//label[contains(@class,'control-label form-check-label')]//span[contains(.,'Group Hierarchy')]")); } }
        public By OverdraftYes { get { return (By.XPath("//div[contains(@class,'formio-component-AllowClaimOverdrawn')]//span[contains(.,'Yes')]")); } }
        public By OverdraftNo { get { return (By.XPath("//div[contains(@class,'formio-component-AllowClaimOverdrawn')]//span[contains(.,'No')]")); } }
        public By BrandingApprovalsYes { get { return (By.XPath("//div[contains(@class,'formio-component-BrandingRequired')]//span[contains(.,'Yes')]")); } }
        public By BrandingApprovalsNo { get { return (By.XPath("//div[contains(@class,'formio-component-BrandingRequired')]//span[contains(.,'No')]")); } }
        public By EComYes { get { return (By.XPath("//div[contains(@class,'formio-component-AllowECom')]//span[contains(.,'Yes')]")); } }
        public By EComNo { get { return (By.XPath("//div[contains(@class,'formio-component-AllowECom')]//span[contains(.,'No')]")); } }

        public By NextButton { get { return (By.XPath("//button[contains(@class,'btn-wizard-nav-next')]")); } }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="db_overdraft"></param>
        /// <param name="db_requireBPA"></param>
        /// <param name="db_ecomEligible"></param>
        public void ACE_Program_Programs_Flow(string db_overdraft,string db_requireBPA,string db_ecomEligible)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Program_ProgramsFlow));
            try
            {
                bi.WaitVisible(ClaimFlow);
                bi.ClickJavaScript(ClaimFlow);
                bi.WaitTime(2);
                bi.WaitVisible(FundMatchingHierarchy);
                bi.ClickJavaScript(FundMatchingHierarchy);
                bi.WaitVisible(ClaimFlow);
                bi.ClickJavaScript(ClaimFlow);
                if (db_overdraft.Equals("Y"))
                {
                    bi.WaitVisible(OverdraftYes);
                    bi.ClickJavaScript(OverdraftYes);
                }
                else
                {
                    bi.WaitVisible(OverdraftNo);
                    bi.ClickJavaScript(OverdraftNo);
                }

                if (db_requireBPA.Equals("Y"))
                {
                    bi.WaitVisible(BrandingApprovalsYes);
                    bi.ClickJavaScript(BrandingApprovalsYes);
                }
                else
                {
                    bi.WaitVisible(BrandingApprovalsNo);
                    bi.ClickJavaScript(BrandingApprovalsNo);
                }

                if (db_ecomEligible.Equals("Y"))
                {
                    bi.WaitVisible(EComYes);
                    bi.ClickJavaScript(EComYes);
                }
                else
                {
                    bi.WaitVisible(EComNo);
                    bi.ClickJavaScript(EComNo);
                }

                bi.WaitVisible(NextButton);
                bi.ClickJavaScript(NextButton);
                bi.WaitTime(5);
            }
            catch(Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("ACE_Program_Programs_Flow "+ex);
                Assert.Fail("ACE_Program_Programs_Flow " + ex);
            }
        }
    }
}