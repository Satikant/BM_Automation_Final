using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace CFMAutomation.PageObject.UI.Ace.Program
{
    public class Program_Preview
    {
        private IWebDriver Driver { get; set; }
        public Program_Preview(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }

        public By SubmitButton { get { return (By.XPath("//button[contains(@class,'btn-wizard-nav-submit')]")); } }
        public By LeftNavDashboard { get { return (By.Id("dashboard")); } }
        public By SubmitClaim { get { return (By.XPath("//button[contains(.,'Submit Claim')]")); } }

        /// <summary>
        /// 
        /// </summary>
        public void ACE_Program_Preview()
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Program_Preview));
            try
            {
                bi.WaitTime(3);
                bi.WaitVisible(SubmitButton);
                bi.Click(SubmitButton);
                bi.WaitTime(60);

                bi.WaitVisible(LeftNavDashboard);
                bi.Click(LeftNavDashboard);
                Console.WriteLine("Program "+Program_ProgramDetails.Prg_Name+" created successfully");
                
            }
            catch(Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("ACE_Program_Preview : "+ex);
                Assert.Fail("ACE_Program_Preview : " + ex);
            }
        }
    }
}
