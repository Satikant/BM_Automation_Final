using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.PageFactory;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval
{
    public class PreApproval_AdvanceSearch
    {
        public PreApproval_AdvanceSearch()
        {
        }

        public By LeftNavPreapprovals { get { return (By.Id("brandingList")); } }
        // Submit Pre-approvals button
        public By SearchPreapprovals { get { return (By.Id("searchId")); } }
        public By AdvanceSearchLink { get { return (By.PartialLinkText("Advanced Search")); } }
        public By AdvanceSearchBPAIDTextBox { get { return (By.Id("brandingRequestId")); } }
        public By AdvanceSearchButton { get { return (By.XPath("//button[contains(@class,'search-button')]")); } }
        public By PendingReviewCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Pending Review')]")); } }
        public By ApprovedCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Approved')]")); } }
        public By HoldCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Hold')]")); } }
        public By NeedsInformationCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Needs Information')]")); } }
        public By DeniedCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Denied')]")); } }
        public By ClosedCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Closed')]")); } }
        public By ResubmittedCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Resubmitted')]")); } }
        public By BPASearchResult(string BPAID) { return (By.PartialLinkText(BPAID)); }
        public By BPAResponseDropdown { get { return (By.XPath("//p-dropdown[contains(@styleclass,'advSearch')]/div//label")); } }
        public By BPAResponseAction(string action)
        {
            return (By.XPath("//li[contains(@class,'ui-dropdown-item')]/span[contains(.,'" + action + "')]"));
        }
        public By BPAComments { get { return (By.XPath("//textarea[contains(@class,'col-sm-4 col-md-4 ng-pristine ng-valid ng-touched')]")); } }
        public By BPASendResponseButton { get { return (By.Id("sendRespond")); } }
        public By imgLoading { get { return By.Id("loading-image"); } }
        public By LoadingImgEllipsis { get { return By.XPath("//img[contains(@src,'assets/images/Ellipsis.gif')]"); } }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BPAID"></param>
        public void ACE_PreApproval_AdvanceSearch(string BPAID)
        {
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(PreApproval_AdvanceSearch));
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(LeftNavPreapprovals);
                Pages.BasicInteractions().Click(LeftNavPreapprovals);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(LoadingImgEllipsis);
                Pages.BasicInteractions().WaitTime(5);

                //**Simple Search functionality
                Pages.BasicInteractions().Clear(SearchPreapprovals);
                Pages.BasicInteractions().Type(SearchPreapprovals,BPAID);
                Pages.BasicInteractions().WaitTime(5);

                ////**Advanced Search functionality
                //Pages.BasicInteractions().WaitVisible(AdvanceSearchLink);
                //Pages.BasicInteractions().Click(AdvanceSearchLink);
                ////Pages.BasicInteractions().WaitVisible(ApprovedCheckbox);
                ////Pages.BasicInteractions().Click(ApprovedCheckbox);
                ////Pages.BasicInteractions().WaitVisible(PendingReviewCheckbox);
                ////Pages.BasicInteractions().Click(PendingReviewCheckbox);
                ////Pages.BasicInteractions().WaitVisible(HoldCheckbox);
                ////Pages.BasicInteractions().Click(HoldCheckbox);
                ////Pages.BasicInteractions().WaitVisible(NeedsInformationCheckbox);
                ////Pages.BasicInteractions().Click(NeedsInformationCheckbox);
                ////Pages.BasicInteractions().WaitVisible(DeniedCheckbox);
                ////Pages.BasicInteractions().Click(DeniedCheckbox);
                ////Pages.BasicInteractions().WaitVisible(ClosedCheckbox);
                ////Pages.BasicInteractions().Click(ClosedCheckbox);
                ////Pages.BasicInteractions().WaitVisible(ResubmittedCheckbox);
                ////Pages.BasicInteractions().Click(ResubmittedCheckbox);
                //Pages.BasicInteractions().WaitVisible(AdvanceSearchBPAIDTextBox);
                //Pages.BasicInteractions().Clear(AdvanceSearchBPAIDTextBox);
                //Pages.BasicInteractions().Type(AdvanceSearchBPAIDTextBox, BPAID);
                //Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(AdvanceSearchButton);
                Pages.BasicInteractions().Click(AdvanceSearchButton);
                Pages.BasicInteractions().WaitTillNotVisible(LoadingImgEllipsis);

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(BPASearchResult(BPAID));
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                Pages.BasicInteractions().WaitTime(5);
                if (Pages.BasicInteractions().IsElementPresent(BPAResponseDropdown))
                {
                    Console.WriteLine("Advance Search is working fine");
                }
                else
                {
                    Console.WriteLine("Advance search is not working");
                }
                //Wait.WaitVisible(BPAResponseDropdown);
                //BPAResponseDropdown.Click();
                //Wait.WaitTime(5);
                //BPAResponseAction(action).Click();
                //BPAComments.Type(action);
                //BPASendResponseButton.Click();
                //Wait.WaitVisible(SearchPreapprovals);
                //SearchPreapprovals.Clear();
                //SearchPreapprovals.Type(BPAID);
                //BPASearchResult(BPAID).Click();
                //Console.WriteLine(BPAID + " - " + action);
            }
            catch (Exception ex)
            {
                Console.WriteLine("PreApproval_AdvanceSearch " + ex);
                Assert.Fail("PreApproval_AdvanceSearch " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }

        }
    }
}
