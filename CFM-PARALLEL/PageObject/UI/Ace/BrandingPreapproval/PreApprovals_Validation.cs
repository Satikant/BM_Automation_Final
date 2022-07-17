using CFM_PARALLEL.PageObject.PageFactory;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval
{
    public class PreApprovals_Validation
    {
        public PreApprovals_Validation()
        {
        }
        // Pre-approvals link in CFM Landing Page
        public By LeftNavPreapprovals { get { return (By.Id("brandingList")); } }
        // Submit Pre-approvals button
        //public By SubmitPreapprovals { get { return (By.Id("submitBranding")); } }
        public By SubmitPreapprovals { get { return (By.XPath("//button[contains(@class,'primary-button') and contains(.,'Approval')]")); } }
        // Select Activity from Activity dropdown
        public By StoreDropdown
        {
            get
            {
                return (By.XPath("//div[contains(@class,'choices form-group formio-choices') and contains(@aria-activedescendant,'dataLMEId')]"));
            }
        }
        public By StoreDropdownText { get { return (By.XPath("//input[contains(@class,'choices__input--cloned')]")); } }
        //Select LME from LME dropdown
        public By ActivityDropdown
        {
            get
            {
                return By.XPath("//div[contains(@class,'formio-component-ActivityName')]//div[contains(@class,'form-control')]");
            }
        }
        public By ActivityDropdownText
        {
            get
            {
                return (By.XPath("//div[contains(@class,'formio-component-ActivityName')]//input[contains(@class,'choices__input--cloned')]"));
            }
        }
        //Select Start date  
        public By Startdate { get { return By.XPath("//div[contains(@class,'formio-component-StartDate')]/div"); } }
        //Select End date
        public By Enddate { get { return By.XPath("//div[contains(@class,'formio-component-EndDate')]/div"); } }
        //Click on Submit Button
        public By NextButton
        {
            get
            {
                return By.XPath("//button[contains(@name,'data[Next]')]");
            }
        }
        public By BPAStartDateSelection(string SrtDate)
        {
            return (By.XPath("//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + SrtDate + "')]"));
        }
        public By BPAEndDateSelection(string EndDate)
        {
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + EndDate + "')])[2]"));
        }
        public By EndDateErrorMsg { get { return (By.XPath("(//div[contains(@class,'formio-errors')]//p)[2]")); } }
        public By imgLoading { get { return By.Id("loading-image"); } }

        /// <summary>
        /// Method to validate End Date while creating a BPA
        /// </summary>
        /// <param name="db_activity"></param>
        /// <param name="db_lme"></param>
        public void BPADateValidation(string db_activity, string db_lme)
        {
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Preapprovals_EnterDetails));
            try
            {
                Pages.BasicInteractions().WaitVisible(LeftNavPreapprovals);
                Pages.BasicInteractions().Click(LeftNavPreapprovals);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                //Wait.WaitTime(30);
                Pages.BasicInteractions().WaitVisible(SubmitPreapprovals);
                Pages.BasicInteractions().Click(SubmitPreapprovals);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);

                Pages.BasicInteractions().WaitTime(10);
                //Wait.WaitVisible(StoreDropdown);
                //StoreDropdown.Click();
                //Wait.WaitVisible(StoreDropdownText);
                //StoreDropdownText.Type(db_lme);
                //StoreDropdownText.Type(Keys.Enter);
                Pages.BasicInteractions().WaitVisible(ActivityDropdown);
                Pages.BasicInteractions().Click(ActivityDropdown);
                Pages.BasicInteractions().Type(ActivityDropdownText, db_activity);
                Pages.BasicInteractions().Type(ActivityDropdownText, Keys.Enter);
                Pages.BasicInteractions().WaitVisible(Startdate);
                Pages.BasicInteractions().Click(Startdate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(BPAStartDateSelection(DateSelection.Ace_DateValidation_StartDate()));
                Pages.BasicInteractions().WaitVisible(Enddate);
                Pages.BasicInteractions().Click(Enddate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(BPAEndDateSelection(DateSelection.Ace_DateValidation_EndDate()));
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(NextButton);
                Pages.BasicInteractions().WaitTime(2);
                Assert.AreEqual(Pages.BasicInteractions().GetText(EndDateErrorMsg).ToString(), "End date cannot be less than Start date");
                Console.WriteLine("BPA Date Validation is throwing error when End Date is less than Start Date");
                Pages.BasicInteractions().WaitVisible(Enddate);
                Pages.BasicInteractions().Click(Enddate);
                Pages.BasicInteractions().ClickJavaScript(BPAEndDateSelection(DateSelection.Ace_DateSelection_bpaEndDate()));
                Pages.BasicInteractions().WaitTime(3);
                if (!Pages.BasicInteractions().IsElementPresent(EndDateErrorMsg))
                {
                    Console.WriteLine("BPA Date Validation is working fine when End Date is greater than Start Date");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ace_Preapproval_DateValidation failed due to " + ex);
                Assert.Fail("Ace_Preapproval_DateValidation failed due to " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }

        }
    }
}
