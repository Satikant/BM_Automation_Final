using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Pre_Approvals;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval
{
    public class PreApproval_PerformAction
    {
        public PreApproval_PerformAction()
        {
        }

        public By LeftNavPreapprovals { get { return (By.Id("brandingList")); } }
        // Submit Pre-approvals button
        public By SearchPreapprovals { get { return (By.XPath("//input[@id='searchId']")); } }
        public By SearchPreapprovals1 { get { return (By.Id("searchId")); } }
        public By AdvanceSearchLink { get { return (By.PartialLinkText("Advanced Search")); } }
        public By AdvanceSearchBPAIDTextBox { get { return (By.Id("brandingRequestId")); } }
        public By AdvanceSearchButton { get { return (By.XPath("//button[contains(@class,'search-button')]")); } }
        public By PendingReviewCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Pending Review')]")); } }
        public By BPASearchResult(string BPAID) { return (By.PartialLinkText(BPAID)); }
        public By BPAResponseDropdown { get { return (By.XPath("//p-dropdown[contains(@styleclass,'advSearch')]/div//label")); } }
        public By BPAResponseAction(string action)
        {
            return (By.XPath("//li[contains(@class,'ui-dropdown-item')]/span[contains(.,'" + action + "')]"));
        }
        public By BPAComments { get { return (By.XPath("//textarea[contains(@class,'col-sm-4 col-md-4 ng-pristine ng-valid ng-touched')]")); } }
        public By BPASendResponseButton { get { return (By.Id("sendRespond")); } }
        public By imgLoading { get { return By.Id("loading-image"); } }
        public By ddlStoreName { get { return By.XPath("//label[contains(.,'Select Store')]"); } }
        public By Storetext { get { return By.XPath("//input[contains(@class,'ui-dropdown-filter')]"); } }
        //public By Firstrow { get { return By.XPath("//tbody[contains(@class,'datatable')]/tr[1]/td[2]/span[2]/a"); } }
        public By Firstrow { get { return By.XPath("//tbody[contains(@class,'table')]//tr[1]/td[2]//a"); } }

        public By ApprovedStatus { get { return By.XPath("//div[contains(@class,'checkbox')]/following-sibling::label[text()='Approved']"); } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BPAID"></param>
        /// <param name="action"></param>
        public void ACE_PreApproval_PerformAction(string BPAID, string action)
        {
            OBJ_PreApprovals obj_bpa = new OBJ_PreApprovals();

            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(PreApproval_PerformAction));
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(LeftNavPreapprovals);
                Pages.BasicInteractions().Click(LeftNavPreapprovals);
                //Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                // Pages.BasicInteractions().WaitTime(20);

                //**Simple Search functionality
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().Clear(SearchPreapprovals);
                Pages.BasicInteractions().Type(SearchPreapprovals, BPAID);
                Pages.BasicInteractions().WaitTime(10);

                ////**Advanced Search functionality
                //Pages.BasicInteractions().WaitVisible(AdvanceSearchLink);
                //Pages.BasicInteractions().Click(AdvanceSearchLink);
                ////Pages.BasicInteractions().WaitVisible(PendingReviewCheckbox);
                ////Pages.BasicInteractions().Click(PendingReviewCheckbox);
                //Pages.BasicInteractions().WaitVisible(AdvanceSearchBPAIDTextBox);
                //Pages.BasicInteractions().Clear(AdvanceSearchBPAIDTextBox);
                //Pages.BasicInteractions().Type(AdvanceSearchBPAIDTextBox,BPAID);
                //Pages.BasicInteractions().WaitTime(2);

                Pages.BasicInteractions().WaitVisible(AdvanceSearchButton);
                Pages.BasicInteractions().Click(AdvanceSearchButton);

                Pages.BasicInteractions().WaitTime(10);

                Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.LoadingImageBrandingPreApproval);
                Pages.BasicInteractions().Click(BPASearchResult(BPAID));
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                

                //Pages.BasicInteractions().WaitTime(20);
                //Wait.WaitVisible(BPAResponseDropdown);
                Pages.BasicInteractions().Click(BPAResponseDropdown);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(BPAResponseAction(action));
                Pages.BasicInteractions().WaitTime(10);

                //BPAComments.Type(action);
                Pages.BasicInteractions().Click(BPASendResponseButton);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);

                //Pages.BasicInteractions().WaitTime(10);
                //Pages.BasicInteractions().WaitClickable(LeftNavPreapprovals);
                //Pages.BasicInteractions().WaitVisible(LeftNavPreapprovals);
                //Pages.BasicInteractions().Click(LeftNavPreapprovals);
                //Pages.BasicInteractions().WaitTime(20);
                //Pages.BasicInteractions().WaitVisible(SearchPreapprovals);
                //Pages.BasicInteractions().Clear(SearchPreapprovals);
                //Pages.BasicInteractions().Type(SearchPreapprovals, BPAID);
                //Pages.BasicInteractions().Click(BPASearchResult(BPAID));
                Console.WriteLine(BPAID + " - " + action);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ACE_PreApproval_PerformAction "+ex);
                Assert.Fail("ACE_PreApproval_PerformAction " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }

        }

        public string GetBPAIDByStoreName(String StoreName)
        {
            OBJ_PreApprovals obj_bpa = new OBJ_PreApprovals();
            try
            {
                Pages.BasicInteractions().WaitTime(15);
                Pages.BasicInteractions().WaitVisible(LeftNavPreapprovals);
                Pages.BasicInteractions().Click(LeftNavPreapprovals);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                // Pages.BasicInteractions().WaitTime(20);

                //**Simple Search functionality
                //Pages.BasicInteractions().Clear(SearchPreapprovals);
                //Pages.BasicInteractions().Type(SearchPreapprovals, BPAID);
                //Pages.BasicInteractions().WaitTime(5);

                //**Advanced Search functionality
                Pages.BasicInteractions().WaitVisible(AdvanceSearchLink);
                Pages.BasicInteractions().Click(AdvanceSearchLink);
                Pages.BasicInteractions().WaitVisible(ddlStoreName);
                Pages.BasicInteractions().Click(ddlStoreName);
                Pages.BasicInteractions().TypeClear(Storetext, StoreName);
                Pages.BasicInteractions().Type(Storetext, Keys.ArrowDown);
                Pages.BasicInteractions().Type(Storetext, Keys.Enter);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(ApprovedStatus);
                Pages.BasicInteractions().Click(ApprovedStatus);

                Pages.BasicInteractions().WaitVisible(AdvanceSearchButton);
                Pages.BasicInteractions().Click(AdvanceSearchButton);
                Thread.Sleep(10000);


                Pages.BasicInteractions().WaitTillNotVisible(obj_bpa.LoadingImageBrandingPreApproval);
                Pages.BasicInteractions().WaitVisible(Firstrow);
                String BPAID = Pages.BasicInteractions().GetText(Firstrow);
                return BPAID;
            }
            catch(Exception Ex)
            {
                Console.WriteLine("Exception:" + Ex.Message);
                //return null;
                throw;
            }
        }
    }
}
