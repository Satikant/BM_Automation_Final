using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Transactions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval
{
    public class PreApproval_ApprovalPermission
    {
        OBJ_Transactions obj_transaction; 
        public PreApproval_ApprovalPermission()
        {
             obj_transaction = new OBJ_Transactions();
        }

        public By LeftNavPreapprovals { get { return (By.Id("brandingList")); } }
        // Submit Pre-approvals button
        public By SearchPreapprovals { get { return (By.Id("searchId")); } }
        public By AdvanceSearchLink { get { return (By.PartialLinkText("Advanced Search")); } }
        public By AdvanceSearchBPAIDTextBox { get { return (By.Id("brandingRequestId")); } }
        public By AdvanceSearchButton { get { return (By.XPath("//button[contains(@class,'search-button')]")); } }
        public By PendingReviewCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Pending Review')]")); } }
        public By BPASearchResult(string BPAID) { return (By.PartialLinkText(BPAID)); }
        public By BPAResponseDropdown { get { return (By.XPath("//p-dropdown[contains(@styleclass,'advSearch')]/div//label")); } }
        public By imgLoading { get { return By.Id("loading-image"); } }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BPAID"></param>
        public void Ace_PreApproval_ApprovalPermission(string BPAID)
        {
           
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(PreApproval_ApprovalPermission));
            try
            {
                Pages.BasicInteractions().WaitVisible(LeftNavPreapprovals);
                Pages.BasicInteractions().Click(LeftNavPreapprovals);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                Pages.BasicInteractions().WaitTime(10);

                //**Simple Search functionality
                Pages.BasicInteractions().Clear(SearchPreapprovals);
                Pages.BasicInteractions().Type(SearchPreapprovals, BPAID);

                //**Advanced Search functionality
                //Wait.WaitVisible(AdvanceSearchLink);
                //AdvanceSearchLink.Click();
                //Wait.WaitVisible(PendingReviewCheckbox);
                //PendingReviewCheckbox.Click();
                //Wait.WaitVisible(AdvanceSearchBPAIDTextBox);
                //AdvanceSearchBPAIDTextBox.Clear();
                //AdvanceSearchBPAIDTextBox.Type(BPAID);
                //Wait.WaitTime(10);
                Pages.BasicInteractions().WaitVisible(AdvanceSearchButton);
                Pages.BasicInteractions().Click(AdvanceSearchButton);

                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.imgLoadingSnapshot);
                Pages.BasicInteractions().Click(BPASearchResult(BPAID));
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                Pages.BasicInteractions().WaitTime(5);

                Assert.IsFalse(Pages.BasicInteractions().IsElementPresent(BPAResponseDropdown));
                //if (!Pages.BasicInteractions().IsElementPresent(BPAResponseDropdown))
                //{
                    Console.WriteLine("BPA: "+ BrowserURLLaunch.ROLES+" does NOT have the option to Approve/Deny/Hold/Needs Information access");
                //}
                //else
                //{
                //    Console.WriteLine("BPA: " + Pages.BrowserURLLaunch().ROLES + "  have option to Approve/Deny/Hold/Needs Information access");
                //}
                //Wait.WaitVisible(BPAResponseDropdown);
                //BPAResponseDropdown.Click();
                //Wait.WaitTime(5);
                //BPAResponseAction(action).Click();
                ////BPAComments.Type(action);
                //BPASendResponseButton.Click();
                //Wait.WaitVisible(SearchPreapprovals);
                //SearchPreapprovals.Clear();
                //SearchPreapprovals.Type(BPAID);
                //BPASearchResult(BPAID).Click();
                //Console.WriteLine(BPAID + " - " + action);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Ace_PreApproval_ApprovalPermission failed due to " + ex);
                Assert.Fail("Ace_PreApproval_ApprovalPermission failed due to " + ex);
                throw;

            }
        }
    }
}
