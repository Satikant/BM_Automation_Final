using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFM_PARALLEL.PageObject.UI.Ace.Claim
{
    public class Claim_EnterDetails
    {
        private IWebDriver Driver { get; set; }
        public Claim_EnterDetails(IWebDriver Driver)
        {
            this.Driver = Driver;
        }
        public By ClaimReference { get { return (By.Name("data[ClaimReference]")); } }
        public By ActivityTypeDropdown { get { return (By.XPath("//div[contains(@class,'choices__item--selectable choices__placeholder')]")); } }
        public By ActivityTypeText { get { return (By.XPath("//label[contains(text(),'Activity Type')]/parent::div[contains(@class,'formio-component-Activities')]//input[@type='text']")); } }
        public By ActivityTypeTextOption { get { return (By.XPath("(//div[contains(@class,'choices__list')]//div[contains(@class,'choices__item choices__item--choice choices__item--selectable is-highlighted')])[3]")); } }
        public By ClaimStartdate
        {
            get
            {
                return (By.XPath("//div[contains(@class,'formio-component-StartDate')]/div"));
            }
        }
        public By ClaimEndDate
        {
            get
            {
                return (By.XPath("//div[contains(@class,'formio-component-EndDate')]/div"));
            }
        }
        public By ClaimTotalActivityCost { get { return (By.XPath("//input[@name='data[TotalActivityCost]']")); } }
        public By ClaimRequestedAmount { get { return (By.Name("data[RequestedAmount]")); } }
        public By ClaimStartDateSelection(string StartDate)
        {
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + StartDate + "')])"));
        }
        public By ClaimEndDateSelection(string EndDate)
        {
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + EndDate + "')])[2]"));
        }

        public By NextButton { get { return (By.XPath("//button[contains(@class,'formio-button-layout')]")); } }
        public By CCEmail { get { return By.XPath("//*[contains(@name,'data[ccEmail]')]"); } }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db_activitytype"></param>
        public void Ace_Claim_EnterDetails(string db_activitytype,string bpa_choice)
        {
            string EligibleAmount;
           // double RequestedAmount;
            BasicInteractions bi = new BasicInteractions(Driver);
            OBJ_Claims obj_claims = new OBJ_Claims();

            Claim_ChooseProgram claim_ChooseProgram = new Claim_ChooseProgram(Driver);
            try
            {
                Pages.BasicInteractions().WaitVisible(ClaimRequestedAmount);
                Pages.BasicInteractions().Type(ClaimReference, "Claim-Reference Number-1234");             
                   
                    
                if(Pages.BasicInteractions().IsElementPresent(CCEmail))
                {
                    Pages.BasicInteractions().TypeClear(CCEmail, "priti.kumari@brandmuscle.com");
                }

                Pages.BasicInteractions().WaitVisible(ActivityTypeDropdown);
                Pages.BasicInteractions().Click(ActivityTypeDropdown);
                Pages.BasicInteractions().WaitVisible(ActivityTypeText);
                Pages.BasicInteractions().TypeClear(ActivityTypeText, "Sponsorship");
                Pages.BasicInteractions().Type(ActivityTypeText, Keys.Enter);

                Pages.BasicInteractions().WaitVisible(ClaimStartdate);
                Pages.BasicInteractions().Click(ClaimStartdate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));
                //Element not visible
                Pages.BasicInteractions().WaitVisible(ClaimEndDate);
                Pages.BasicInteractions().Click(ClaimEndDate);
                Pages.BasicInteractions().WaitTime(1);
                Pages.BasicInteractions().Click(ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                Pages.BasicInteractions().WaitUntilElementVisible(ClaimTotalActivityCost,240);
                Pages.BasicInteractions().TypeClear(ClaimTotalActivityCost, Parameters.ClaimTotalActivityCost_ACE());
            
                 EligibleAmount = Pages.BasicInteractions().GetAttribute(obj_claims.EligibleAmount_bobcat, "value");
                //Requested Amount is calculting like Eligible Amount;
                //if (Pages.BasicInteractions().IsElementPresent(obj_claims.ReqAmountConverted))
                //{
                //    RequestedAmount = Convert.ToDouble(Pages.BasicInteractions().GetAttribute(obj_claims.ReqAmountConverted, "value"));
                //}
                //else
                //{
                //    RequestedAmount = Convert.ToDouble(EligibleAmount);
                //}
                Pages.BasicInteractions().WaitUntilElementVisible(NextButton, 60);
                Pages.BasicInteractions().TypeClear(ClaimRequestedAmount, Parameters.ClaimRequestedAmount_ACE());
                Pages.BasicInteractions().Click(NextButton);
            }
            catch (Exception ex)
            {              
                Console.WriteLine("Claim_EnterDetails failed due to " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }

        public void Ace_Claim_EnterDetailsOverD(string db_activitytype, string bpa_choice)
        {
            string EligibleAmount;
            double RequestedAmount;
            OBJ_Claims obj_claims = new OBJ_Claims();
        
            Claim_ChooseProgram claim_ChooseProgram = new Claim_ChooseProgram(Driver);
            try
            {
                Pages.BasicInteractions().WaitVisible(ClaimRequestedAmount);
                Pages.BasicInteractions().Type(ClaimReference, "Claim-Reference Number-1234");
                if (bpa_choice.Equals("N"))
                {
                    Pages.BasicInteractions().WaitVisible(ActivityTypeDropdown);
                    Pages.BasicInteractions().Click(ActivityTypeDropdown);
                    Pages.BasicInteractions().WaitVisible(ActivityTypeText);
                    Pages.BasicInteractions().TypeClear(ActivityTypeText,"Direct Mail");
                    Pages.BasicInteractions().Type(ActivityTypeText, Keys.Enter);
                   }

                Pages.BasicInteractions().WaitVisible(ClaimStartdate);
                Pages.BasicInteractions().Click(ClaimStartdate);
                Pages.BasicInteractions().Click(ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));
                //Element not visible
                Pages.BasicInteractions().WaitVisible(ClaimEndDate);
                Pages.BasicInteractions().Click(ClaimEndDate);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                Pages.BasicInteractions().TypeClear(ClaimTotalActivityCost, Parameters.ClaimTotalActivityCost_ACE("YES"));

                EligibleAmount = Pages.BasicInteractions().GetAttribute(obj_claims.EligibleAmount_bobcat, "value");

                //Requested Amount is calculting like Eligible Amount;
                if (Pages.BasicInteractions().IsElementPresent(obj_claims.ReqAmountConverted))
                {
                    RequestedAmount = Convert.ToDouble(Pages.BasicInteractions().GetAttribute(obj_claims.ReqAmountConverted, "value"));
                }
                else
                {
                    RequestedAmount = Convert.ToDouble(EligibleAmount);
                }
                Pages.BasicInteractions().TypeClear(obj_claims.ClaimRequestedAmount, RequestedAmount.ToString());
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().TypeClear(ClaimRequestedAmount, RequestedAmount.ToString());
                Pages.BasicInteractions().Click(NextButton);
                Pages.BasicInteractions().WaitTime(10);               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Claim_EnterDetails failed due to " + ex);
                Assert.Fail("Claim_EnterDetails failed due to " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }
    }
}
