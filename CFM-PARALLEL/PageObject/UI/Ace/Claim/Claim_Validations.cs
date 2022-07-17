using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFM_PARALLEL.PageObject.UI.Ace.Claim
{
    public class Claim_Validations
    {
        private IWebDriver Driver { get; set; }
        public Claim_Validations(IWebDriver Driver)
        {
            this.Driver = Driver;
           
        }

        public By LeftNavClaim { get { return (By.Id("ManageClaim")); } }
        // Submit Pre-approvals button
        public By SearchClaim { get { return (By.Id("searchId")); } }
        public By AdvanceSearchLink { get { return (By.PartialLinkText("Advanced Search")); } }
        public By AdvanceSearchClaimIDTextBox { get { return (By.Id("claimId")); } }
        public By AdvanceSearchButton { get { return (By.XPath("//button[contains(@class,'search-button')]")); } }
        public By PendingReviewCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Pending Review')]")); } }
        public By ClaimSearchResult(string ClaimId) { return (By.PartialLinkText(ClaimId)); }
        public By ClaimResponseDropdown { get { return (By.XPath("//p-dropdown[contains(@formcontrolname,'ReviewerAction')]/div//label")); } }
        public By ClaimResponse(string action) { return (By.XPath("//li[contains(@class,'ui-dropdown-item')]/span[contains(.,'" + action + "')]")); }
        public By ClaimApprovedAmount { get { return (By.Id("approvedAmount")); } }
        public By ClaimReviewCodeDropdown { get { return (By.XPath("//p-multiselect[contains(@formcontrolname,'ReviewCode')]/div//label")); } }
        public By ClaimReviewCodeText { get { return (By.XPath("//div[contains(@class,'ui-multiselect-filter-container')]/input")); } }
        public By ClaimReviewCodeTextSelect { get { return (By.XPath("//li[contains(@class,'ui-multiselect-item ui-corner-all ng-star-inserted')]//div[contains(@class,'ui-chkbox ui-widget')]")); } }
        public By ClaimComments { get { return (By.XPath("//textarea[contains(@formcontrolname,'ReviewComment')]")); } }
        public By ClaimSendResponseButton { get { return (By.Id("sendRespond")); } }
        public By ClaimActionMessage { get { return (By.XPath("//label[contains(@contains(@class,'Approve')]")); } }
        public By ApprovedAmountErrorMsg { get { return (By.XPath("//span[contains(@class,'alert alert-danger')]")); } }
        public By ClaimRequestedAmount { get { return (By.XPath("(//span[contains(@class,'regular-font con-floatRight')])[4]")); } }


        //**identifiers for Date validation | Claim - Enter Details
        public By ClaimTotalActivityCost { get { return (By.Name("data[TotalActivityCost]")); } }
        public By ClaimReference { get { return (By.Name("data[ClaimReference]")); } }
        public By ActivityTypeDropdown { get { return (By.XPath("//div[contains(@class,'choices__item--selectable choices__placeholder')]")); } }
        public By ActivityTypeText { get { return (By.XPath("//input[contains(@class,'choices__input choices__input--cloned') and contains(@aria-activedescendant,'dataActivities')]")); } }
        public By ActivityTypeTextOption { get { return (By.XPath("(//div[contains(@class,'choices__list')]//div[contains(@class,'choices__item choices__item--choice choices__item--selectable is-highlighted')])[3]")); } }
        public By ClaimStartdate { get { return (By.XPath("//div[contains(@class,'formio-component-StartDate')]/div")); } }
        public By ClaimEndDate { get { return (By.XPath("//div[contains(@class,'formio-component-EndDate')]/div")); } }
        public By ClaimStartDateSelection(string StartDate)
        {
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + StartDate + "')])"));
        }
        public By ClaimEndDateSelection(string EndDate)
        {
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + EndDate + "')])[2]"));
        }
        public By EndDateErrorMsg { get { return (By.XPath("//div[contains(@class,'formio-errors')]//p")); } }

        /// <summary>
        /// Method to validate Approved amount while approving claim in Pending Review status
        /// </summary>
        /// <param name="ClaimId"></param>
        /// <param name="action"></param>
        /// <param name="reason"></param>
        public void ClaimApprovalAmountValidation(string ClaimId, string action, string reason)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            OBJ_Claims obj_claims = new OBJ_Claims();
            
            try
            {
                bi.WaitTime(15);
                bi.WaitVisible(LeftNavClaim);
                bi.Click(LeftNavClaim);
                bi.WaitTime(15);

                //**Simple Search functionality
                bi.WaitVisible(obj_claims.SearchClaim);
                bi.Clear(obj_claims.SearchClaim);
                bi.Type(obj_claims.SearchClaim, ClaimId);
                //bi.Type(obj_claims.SearchClaim,Keys.Enter);
                //bi.WaitTime(10);

                //**Advance Search functionality
                //bi.WaitVisible(AdvanceSearchLink);
                //bi.Click(AdvanceSearchLink);
                ////bi.WaitVisible(PendingReviewCheckbox);
                ////bi.Click(PendingReviewCheckbox);
                //bi.WaitVisible(AdvanceSearchClaimIDTextBox);
                //bi.Clear(AdvanceSearchClaimIDTextBox);
                //bi.Type(AdvanceSearchClaimIDTextBox, ClaimId);
                //bi.WaitTime(10);
                bi.WaitVisible(AdvanceSearchButton);
                bi.Click(AdvanceSearchButton);
                bi.WaitTillNotVisible(obj_claims.ImgLoadingClaim);

                bi.Click(ClaimSearchResult(ClaimId));
                bi.WaitTime(20);
                decimal strRequestedAmount = Convert.ToDecimal(bi.GetText(ClaimRequestedAmount).ToString().Substring(1));
                bi.WaitVisible(ClaimResponseDropdown);
                bi.Click(ClaimResponseDropdown);
                bi.WaitTime(5);
                bi.Click(ClaimResponse(action));
                bi.WaitTime(5);
                bi.Clear(ClaimApprovedAmount);
                bi.Type(ClaimApprovedAmount, (strRequestedAmount + 10).ToString());
                bi.WaitVisible(ClaimSendResponseButton);
                bi.Click(ClaimSendResponseButton);
                bi.WaitTime(3);
                Assert.AreEqual(bi.GetText(ApprovedAmountErrorMsg).ToString(), "Approved amount cannot be greater than Requested amount");
                Console.WriteLine("Approved amount field not accepting approved amount greater than Requested amount");
                bi.WaitTime(5);
                bi.Clear(ClaimApprovedAmount);
                bi.Type(ClaimApprovedAmount, strRequestedAmount.ToString());
                bi.WaitVisible(ClaimSendResponseButton);
                bi.Click(ClaimSendResponseButton);
                if (!bi.IsElementPresent(ApprovedAmountErrorMsg))
                {
                    Console.WriteLine("Approved amount field accepting approved amount when Requested amount and approved amount are same");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("ACE_Claim_ApprovedAmountValidation " + ex);
                Assert.Fail("ACE_Claim_ApprovedAmountValidation " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }
        }

        /// <summary>
        /// Method to validate End Date while creating a claim
        /// </summary>
        public void ClaimDateValidation()
        {
            BasicInteractions bi = new BasicInteractions(Driver);
           
            try
            {
                Claim_ChooseProgram cc = new Claim_ChooseProgram(Driver);
                cc.Ace_Claim_ChooseProgram("BPA-325", "N","QA", "00020");
                bi.WaitVisible(ClaimReference);
                bi.Type(ClaimReference, "RED1234");
                bi.WaitVisible(ActivityTypeDropdown);
                bi.Click(ActivityTypeDropdown);
                bi.WaitVisible(ActivityTypeText);
                bi.TypeClear(ActivityTypeText, "Direct Mail");
                bi.Type(ActivityTypeText,Keys.Enter);
                
                bi.WaitVisible(ClaimStartdate);
                bi.Click(ClaimStartdate);
                //ClaimStartDateSelection("April 22, 2018").Click();
                bi.Click(ClaimStartDateSelection(DateSelection.Ace_DateValidation_StartDate()));
                //Element not visible
                bi.WaitVisible(ClaimEndDate);
                bi.Click(ClaimEndDate);
                bi.WaitTime(2);
                //ClaimEndDateSelection("April 29, 2018").Click();
                bi.Click(ClaimEndDateSelection(DateSelection.Ace_DateValidation_EndDate()));
                bi.WaitTime(3);
                Assert.AreEqual(bi.GetText(EndDateErrorMsg).ToString(), "End date cannot be less than Start date");
                Console.WriteLine("Claim Date Validation is throwing error when End Date is less than Start Date");
                bi.WaitVisible(ClaimEndDate);
                bi.Click(ClaimEndDate);
                bi.Click(ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                bi.WaitTime(3);
                if (!bi.IsElementPresent(EndDateErrorMsg))
                {
                    Console.WriteLine("Claim Date Validation is working fine when End Date is greater than Start Date");
                }
            }
            catch (Exception ex)
            {
                             
                Console.WriteLine("Ace_Claim_DateValidation " + ex);
                Assert.Fail("Ace_Claim_DateValidation " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }
        }
    }
}
