using CFM_PARALLEL.PageObject.PageFactory;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval
{
    public class Preapproval_Clone
    {
        private IWebDriver Driver { get; set; }
        public Preapproval_Clone(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }
        public By LeftNavPreapprovals { get { return (By.Id("brandingList")); } }
        // Submit Pre-approvals button
        public By SearchPreapprovals { get { return (By.Id("searchId")); } }
        public By BPASearchResult(string BPAID) { return (By.PartialLinkText(BPAID)); }
        public By CloneButton { get { return (By.Id("clone")); } }
        //public By LeftNavPreapprovals { get { return (By.Id("brandingList")); } }
        // Submit Pre-approvals button
        //public By SearchPreapprovals { get { return (By.Id("searchId")); } }
        public By AdvanceSearchLink { get { return (By.PartialLinkText("Advanced Search")); } }
        public By AdvanceSearchBPAIDTextBox { get { return (By.Id("brandingRequestId")); } }
        public By AdvanceSearchButton { get { return (By.XPath("//button[contains(@class,'search-button')]")); } }
        public By PendingReviewCheckbox { get { return (By.XPath("//label[contains(@class,'ui-chkbox-label') and contains(.,'Pending Review')]")); } }
        //public By BPASearchResult(string BPAID) { return (By.PartialLinkText(BPAID)); }
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
        public void ACE_Preapproval_Clone(string BPAID)
        {
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Preapproval_Clone));
            Preapprovals_EnterDetails preapprovals_EnterDetails = new Preapprovals_EnterDetails(Driver);
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(LeftNavPreapprovals);
                Pages.BasicInteractions().Click(LeftNavPreapprovals);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                Console.WriteLine("Cloning " + BPAID);
                Pages.BasicInteractions().WaitTime(5);
                //**Simple Search functionality
                Pages.BasicInteractions().Clear(SearchPreapprovals);
                Pages.BasicInteractions().Type(SearchPreapprovals, BPAID);
                Pages.BasicInteractions().WaitTime(10);

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
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitTillNotVisible(LoadingImgEllipsis);

                
                Pages.BasicInteractions().Click(BPASearchResult(BPAID));
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);

                
                Pages.BasicInteractions().WaitVisible(CloneButton);
                Pages.BasicInteractions().Click(CloneButton);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);

                
                Pages.BasicInteractions().Click(preapprovals_EnterDetails.NextButton);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);

                Pages.BasicInteractions().WaitTime(5);
                Preapprovals_AddAttachments pa = new Preapprovals_AddAttachments(Driver);
                pa.ACE_Preapproval_AddAttachment("BPA CLONE!");
                Console.WriteLine("Cloned successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("BPA Clone: " + ex);
                Assert.Fail("BPA Clone: " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }

        }
    }
}
