using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFM_PARALLEL.PageObject.UI.ObjectRepository.FundRequest
{
    class OBJ_FundRequest
    {

        private String FinalXPath;
        public By LeftNavFundRequest { get { return (By.XPath("//a[@id='fundrequestList']")); } }
        public By CreateFundRequestButton { get { return (By.XPath("//button[@id='submitFundRequest']")); } }
        public By RequestedAmountTextbox { get { return (By.XPath("//input[@name='data[RequestedAmount]']")); } }
        public By CommentTextbox { get { return (By.XPath("//textarea[@name='data[Comment]']")); } }
        public By ContinueButton { get { return (By.XPath("//button[text()='Continue']")); } }
        public By SubmitButton { get { return (By.XPath("//button[text()='Submit']")); } }
        public By BackButton { get { return (By.XPath("//button[text()='Back']")); } }
        public By ViewDetailedReportLink { get { return (By.XPath("//a[text()='View Detailed Report ']")); } }
        public By StoreDropdown { get { return (By.XPath("//label[text()='Store']/following-sibling::div[@role='combobox']")); } }
        public By StoreTextbox { get { return (By.XPath("//label[text()='Store']/parent::div//input[@type='text']")); } }
        public By AgencyDropdown { get { return (By.XPath("//label[text()='Agency']/following-sibling::div[@role='combobox']")); } }
        public By AgencyTextbox { get { return (By.XPath("//label[text()='Agency']/parent::div//input[@type='text']")); } }
        public By ProgramDropdown { get { return (By.XPath("//label[text()='Program']/following-sibling::div[@role='combobox']")); } }
        public By ProgramTextbox{ get { return (By.XPath("//label[text()='Program']/parent::div//input[@type='text']")); } }
        public By ImgLoading { get { return By.XPath("//div[contains(@id,'loading')]"); } }
        public By FundRequestSuccessfulMessage { get { return (By.XPath("//div[contains(text(),'Successfully')]")); } }
        //public By FundRequestUpload { get { return (By.XPath("//input[@type='file']")); } }
        public By FundRequestUpload { get { return (By.XPath("//div[@class='fileSelector']//a[@class='browse']")); } }
        public By FundRequestIDLink { get { return (By.XPath("//label[contains(text(),'Showing')]//following::a[contains(text(),'FR-')][1]")); } }
        public By SearchTextbox { get { return (By.XPath("//input[@id='searchId']")); } }
        public By SearchButton { get { return (By.XPath("//span[text()='Search']")); } }
        public By UpdateStatusDropdown { get { return (By.XPath("//label[text()='Update Status']/parent::div//div[@role='combobox']")); } }
        public By UpdateStatusTexBox { get { return (By.XPath("//label[text()='Update Status']/parent::div//input[@type='text']")); } }
        public By TransactionTypeDropdown { get { return (By.XPath("//label[text()='Transaction Type']/parent::div//div[@role='combobox']")); } }
        public By TransactionTypeTextBox { get { return (By.XPath("//label[text()='Transaction Type']/parent::div//input[@type='text']")); } }
        public By ApprovalAmountTextBox { get { return (By.XPath("//label[text()='Approval Amount']/parent::div//input[@name='data[ApprovedAmount]']")); } }
        public By FundRequestStatus { get { return By.XPath("//label[contains(text(),'Showing')]//following::a[contains(text(),'FR-')][1]//following::span[1]"); } }
        public By LeftNavDashboard { get { return (By.XPath("//a[@id='dashboard']")); } }
        public By ViewFundDetailLink { get { return (By.XPath("//a[contains(text(),'Detailed')]")); } }

        public By NationwideBusinessUnit { get { return (By.XPath("//select[@id='MainContent_ddlBusinessUnit']")); } }
        public By EmulateUser { get { return (By.XPath("//div[contains(text(),'Emulate')]")); } }
        public By EmulateUserTextbox { get { return (By.XPath("//ul[contains(@class,'emulationTextBox')]//input")); } }
        public By EmulationButton { get { return (By.XPath("//input[@id='emulationButton']")); } }
        public By V5CFMLink { get { return (By.XPath("//a[contains(@href,'CFM.aspx')]")); } }
        public By ReviewHistoryLevel { get { return (By.XPath(GetXpath())); } }


        public string GetXpath()
        {
            return FinalXPath;
        }

        public void SetXpath(int parameter)
        {
            string ReviewActionXpath = "//label[contains(text(),'Review History')]/following-sibling::table/tbody//tr[{0}]//div[contains(@class,'review-table')]";
            FinalXPath = string.Format(ReviewActionXpath, parameter);
        }

    }
}
