using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace CFMAutomation.PageObject.UI.Ace.Program
{
    public class Program_ProgramDetails
    {
        private IWebDriver Driver { get; set; }
        public Program_ProgramDetails(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }
        public By leftNavProgram { get { return By.Id("prgProgramSnapshot"); } }
        //public By LeftNavAddProgram { get { return (By.Id("prgEdit")); } }
        public By btnNewprogram { get { return By.XPath("//button[contains(@class,'primary-button') and contains(.,'New Program')]"); } }
        //Program Name 
        public By ProgramName { get { return (By.XPath("//input[@name='data[ProgramName]']")); } }
        public By ProgramDesc { get { return (By.XPath("//textarea[@name='data[Description]']")); } }
        //public By ProgramCurrencyDropdown { get { return (By.XPath("//div[@class='choices form-group formio-choices']")); } }
        public By ProgramCurrencyDropdown { get { return (By.XPath("//div[@data-value='Choose Currency']")); } }

        //public By ProgramCurrencyText { get { return (By.XPath("//input[@class='choices__input choices__input--cloned']")); } }
        public By ProgramCurrencyText { get { return (By.XPath("//div[contains(@class,'ProgramCurrency')]/div/div[2]/input")); } }

        public By ProgramCurrencyTextOption { get { return (By.XPath("(//div[contains(@class,'choices__list')]//div[contains(@class,'choices__item choices__item--choice choices__item--selectable is-highlighted')])")); } }
        public By StartDate { get { return (By.XPath("//div[contains(@class,'formio-component-StartDate')]/div/span")); } }
        public By EndDate { get { return (By.XPath("//div[contains(@class,'formio-component-EndDate')]/div/span")); } }
        //public By BrowseLink { get { return (By.XPath("//div[contains(@class,'fileSelector')]")); } }
        public By BrowseLink { get { return (By.PartialLinkText("browse")); } }
        public By NextButton { get { return(By.XPath("//button[contains(@class,'btn-wizard-nav-next')]")); } }
        public By StartDateSelection(string prgSrtDate)
        {
            return (By.XPath("//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'"+prgSrtDate+"')]"));
        }
        public By EndDateSelection(string prgEndDate)
        {
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgEndDate + "')])"));
        }
        public By imgLoading { get { return By.Id("loading-image"); } }

        public static string Prg_Name;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="db_PrgName"></param>
        /// <param name="db_PrgDesc"></param>
        /// <param name="db_Currency"></param>
        public void ACE_Program_ProgramDetails(string db_PrgName,string db_PrgDesc,string db_Currency) 
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            CommonFunctions cf = new CommonFunctions();
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Program_ProgramDetails));
            try
            {
                bi.WaitTime(5);
                bi.WaitVisible(leftNavProgram);
                bi.Click(leftNavProgram);
                bi.WaitTillNotVisible(imgLoading);
                bi.WaitTime(5);
                //Clicking on New Program
                bi.WaitVisible(btnNewprogram);
                bi.Click(btnNewprogram);

                //Waiting upto programname field is visible
                bi.WaitVisible(ProgramName);
                bi.Type(ProgramName,db_PrgName);
                //Prg_Name = db_PrgName;
                bi.WaitVisible(ProgramDesc);
                bi.Type(ProgramDesc,db_PrgDesc);
                bi.WaitVisible(ProgramCurrencyDropdown);
                
                if(db_Currency=="USD")
                {
                    db_Currency = "$";
                }
                bi.Click(ProgramCurrencyDropdown);
                bi.WaitVisible(ProgramCurrencyText);
                bi.TypeClear(ProgramCurrencyText, db_Currency);
                bi.Type(ProgramCurrencyText, Keys.Enter);
                //bi.WaitVisible(ProgramCurrencyTextOption);
                //bi.Click(ProgramCurrencyTextOption);
                //ProgramCurrencyText.Type(Keys.Enter);

                bi.WaitVisible(StartDate);
                bi.Click(StartDate);
                bi.WaitTime(5);
                DateSelection dssrt = new DateSelection();
                bi.Click(StartDateSelection(dssrt.Ace_DateSelection_prgStartDate()));

                bi.WaitVisible(EndDate);
                bi.Click(EndDate);
                bi.WaitTime(5);
                DateSelection dsend = new DateSelection();
                bi.Click(EndDateSelection(dsend.Ace_DateSelection_prgEndDate()));

                //bi.WaitVisible(BrowseLink);
                //BrowseLink.Click();
                //System.Windows.Forms.SendKeys.SendWait("^a");
                //bi.WaitTime(3);
                ////File path from deployment items
                //System.Windows.Forms.SendKeys.SendWait("D:\\AutomationFileAttachment\\CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                //bi.WaitTime(3);
                //System.Windows.Forms.SendKeys.SendWait(@"{Enter}");
                bi.WaitTime(5);
                bi.ClickJavaScript(NextButton);
            }
            catch(Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
              
                Console.WriteLine("ACE_Program_ProgramDetails " + ex);
                Assert.Fail("ACE_Program_ProgramDetails " + ex);
            }

        }
    }
}
