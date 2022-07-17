using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Pre_Approvals;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;

using System;

namespace CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval
{
    public class Preapprovals_EnterDetails
    {
        private OBJ_PreApprovals oBJ_PreApprovals;
        public Preapprovals_EnterDetails(IWebDriver Driver)
        {
            oBJ_PreApprovals = new OBJ_PreApprovals();
        }
        public By LeftNavPreapprovals { get { return (By.Id("brandingList")); } }
        public By Submit { get { return By.XPath("//button[contains(@class,'dropdown-toggle') and contains(@aria-expanded,true)]"); } }
        public By SubmitPreapprovals { get { return (By.XPath("//*[contains(text(),'Submit Brand Pre-Approval')]")); } }
        //Enter Branding Reference Name
        public By BPARefName { get { return (By.XPath("//input[contains(@name,'data[BrandingReference]')]")); } }
        // Select Activity from Activity dropdown
        public By StoreDropdown
        {
            get
            {
                return (By.XPath("//div[contains(@class,'formio-component-LMEId')]//div[contains(@class,'form-control')]"));
            }
        }
        public By StoreDropdownText
        {
            get
            {
                return (By.XPath("//div[contains(@class,'formio-component-LMEId')]//input[contains(@class,'choices__input--cloned')]"));
            }
        }
        public By StoreDropdownTextOption { get { return (By.XPath("(//div[contains(@class,'choices__list')])[1]")); } }

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
        public By ActivityTypeTextOption { get { return (By.XPath("//div[contains(@class,'choices__list')]//div[contains(@class,'choices__item choices__item--choice choices__item--selectable is-highlighted')])[2]")); } }

        //Select Start date  
        public By Startdate { get { return By.XPath("//div[contains(@class,'formio-component-StartDate')]//div"); } }
        //Select End date
        public By Enddate { get { return By.XPath("//div[contains(@class,'formio-component-EndDate')]//div"); } }
        //Click on Submit Button
        public By NextButton { get { return By.XPath("//button[contains(@name,'data[Next]')]"); } }
        public By BPAStartDateSelection(string SrtDate)
        {
            return (By.XPath("//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + SrtDate + "')]"));
        }
        public By BPAEndDateSelection(string EndDate)
        {
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + EndDate + "')])[2]"));
        }
        public By ErrorTechnical { get { return (By.XPath("//h1[contains(.,'technical error occured')]")); } }
        public By Error500Internal { get { return (By.XPath("//hi[contains(.,'Error 500: Internal Server Error')]")); } }
        public By imgLoading { get { return By.Id("loading-image"); } }

        public By LeftNavClaim { get { return (By.Id("ManageClaim")); } }
        // Submit Pre-approvals button
        public By SearchClaim { get { return (By.Id("searchId")); } }
        public By AdvanceSearchLink { get { return (By.PartialLinkText("Advanced Search")); } }
        public By AdvanceSearchClaimIDTextBox { get { return (By.Id("claimId")); } }
        public By AdvanceSearchButton { get { return (By.XPath("//button[contains(@class,'search-button')]")); } }
        public By PendingReviewCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Pending Review')]")); } }
        public By ApprovedCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Approved')]")); } }
        public By ClaimSearchResult(string ClaimId) { return (By.PartialLinkText(ClaimId)); }
        public By ClaimResponseDropdown { get { return (By.XPath("//p-dropdown[contains(@formcontrolname,'ReviewerAction')]//div//label")); } }
        public By ClaimResponse(string action) { return (By.XPath("//li[contains(@class,'ui-dropdown-item')]/span[contains(.,'" + action + "')]")); }
        public By ClaimApprovedAmount { get { return (By.Id("approvedAmount")); } }
        public By ClaimReviewCodeDropdown { get { return (By.XPath("//p-multiselect[contains(@formcontrolname,'ReviewCode')]")); } }
        public By ClaimReviewCodeText { get { return (By.XPath("//div[contains(@class,'ui-multiselect-filter-container')]//input")); } }
        public By ClaimReviewCodeTextSelect { get { return (By.XPath("(//div[contains(@class,'ui-chkbox-box ui-widget ui-corner-all ui-state-default')])[2]")); } }
        public By ClaimComments { get { return (By.XPath("//textarea[contains(@formcontrolname,'ReviewComment')]")); } }
        public By ClaimSendResponseButton { get { return (By.Id("sendRespond")); } }
        public By ClaimActionMessage { get { return (By.XPath("//label[contains(@contains(@class,'Approve')]")); } }
        public By tblBPAFirstrow { get { return By.XPath("//tbody[contains(@class,'ui-datatable-data')]/tr[1]/td[2]/span[2]/a"); } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db_activity"></param>
        /// <param name="db_lme"></param>
        /// <param name="db_startdate"></param>
        /// <param name="db_enddate"></param>
        public void Ace_Preapproval_EnterDetails(string db_activity, string db_lme, string db_startdate, string db_enddate)
        {
            try
            {
                Pages.BasicInteractions().WaitUntilElementVisible(LeftNavPreapprovals,240);
                Pages.BasicInteractions().WaitVisible(Submit);
                Pages.BasicInteractions().Click(Submit);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                if (!Pages.BasicInteractions().IsElementPresent(SubmitPreapprovals))
                {
                    Console.WriteLine("Cannot create BPA, link to create BPA is not present in the application");
                }

                if (Pages.BasicInteractions().IsElementPresent(ErrorTechnical))
                {
                    Console.WriteLine("BPA ERROR: A technical error occured message is displayed");
                }
                else if (Pages.BasicInteractions().IsElementPresent(Pages.BrowserURLLaunch().ErrorTechnicalWidget))
                {
                    Console.WriteLine("BPA ERROR: Error 500: Internal Server Error occured");
                }

                Pages.BasicInteractions().Click(SubmitPreapprovals);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                if (Pages.BasicInteractions().IsElementPresent(ErrorTechnical))
                {
                    Console.WriteLine("BPA ERROR: A technical error occured message is displayed");
                }
                else if (Pages.BasicInteractions().IsElementPresent(Pages.BrowserURLLaunch().ErrorTechnicalWidget))
                {
                    Console.WriteLine("BPA ERROR: Error 500: Internal Server Error occured");
                }
                else
                {
                    Pages.BasicInteractions().WaitVisible(BPARefName);
                    Pages.BasicInteractions().Clear(BPARefName);
                    Pages.BasicInteractions().Type(BPARefName, "BPA-Reference Number-1234");
                    Pages.BasicInteractions().WaitVisible(StoreDropdown);
                    Pages.BasicInteractions().Click(StoreDropdown);
                    Pages.BasicInteractions().WaitVisible(StoreDropdownText);
                    Pages.BasicInteractions().TypeClear(StoreDropdownText, Parameters.Ace_Test_LME1);
                    Pages.BasicInteractions().WaitTime(2);
                    Pages.BasicInteractions().Type(StoreDropdownText, Keys.Enter);

                    Pages.BasicInteractions().WaitVisible(oBJ_PreApprovals.BPA_ActivityType);
                    Pages.BasicInteractions().Click(oBJ_PreApprovals.BPA_ActivityType);
                    Pages.BasicInteractions().Type(oBJ_PreApprovals.BPA_ActivityTypeTextbox, "Direct Mail");
                    Pages.BasicInteractions().WaitTime(2);
                    Pages.BasicInteractions().Type(oBJ_PreApprovals.BPA_ActivityTypeTextbox, Keys.Enter);

                    Pages.BasicInteractions().WaitUntilElementVisible(Startdate,240);
                    Pages.BasicInteractions().Click(Startdate);
                    Pages.BasicInteractions().WaitTime(1);
                    Pages.BasicInteractions().Click(BPAStartDateSelection(DateSelection.Ace_DateSelection_bpaStartDate()));
                    Pages.BasicInteractions().WaitUntilElementVisible(Enddate,240);
                    Pages.BasicInteractions().Click(Enddate);
                    Pages.BasicInteractions().WaitTime(1);
                    Pages.BasicInteractions().Click(BPAEndDateSelection(DateSelection.Ace_DateSelection_bpaEndDate()));
                    Pages.BasicInteractions().WaitUntilElementVisible(NextButton,240);
                    Pages.BasicInteractions().ClickJavaScript(NextButton);
                    // Pages.BasicInteractions().WaitTillNotVisible(imgLoading,240);
                    Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                    Pages.BasicInteractions().WaitTime(5);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ace_Preapproval_EnterDetails: " + ex);
                Assert.Fail("Ace_Preapproval_EnterDetails: " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }

        //Search for Pending BPA's Claims
        public string SearchAndGetPendingReviewBPAID()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(LeftNavPreapprovals);
                Pages.BasicInteractions().Click(LeftNavPreapprovals);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);

                ////**Simple Search functionality
                //Wait.WaitVisible(SearchClaim);
                //SearchClaim.Clear();
                //SearchClaim.Type(ClaimId);
                //SearchClaim.Type(Keys.Enter);
                //Wait.WaitTime(10);

                //**Advance Search functionality
                Pages.BasicInteractions().WaitVisible(AdvanceSearchLink);
                Pages.BasicInteractions().Click(AdvanceSearchLink);
                Pages.BasicInteractions().WaitVisible(PendingReviewCheckbox);
                Pages.BasicInteractions().Click(PendingReviewCheckbox);
               
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(AdvanceSearchButton);
                Pages.BasicInteractions().Click(AdvanceSearchButton);
                Pages.BasicInteractions().WaitTime(10);
                String BPAID = Pages.BasicInteractions().GetText(tblBPAFirstrow);
                return BPAID;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }
    }
}
