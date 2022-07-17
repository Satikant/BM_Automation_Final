using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFM_PARALLEL.PageObject.UI.ObjectRepository.DisplayClaims
{
    class OBJ_DisplayClaims
    {
        public By LeftNavDashboard { get { return (By.XPath("//a[@id='dashboard']")); } }
        public By LeftNavDisplayClaim { get { return (By.XPath("//a[@id='VarianceClaim']")); } }
        public By SubmitDispalyClaimButton { get { return (By.XPath("//span[contains(text(),'Display')]")); } }
        public By StoreDropdown { get { return (By.XPath("//label[text()='Store']/following-sibling::div[@role='combobox']")); } }
        public By StoreTextbox { get { return (By.XPath("//label[text()='Store']/parent::div//input[@type='text']")); } }
        public By ProgramDropdown { get { return (By.XPath("//label[text()='Program Name']/following-sibling::div[@role='combobox']")); } }
        public By ProgramTextbox { get { return (By.XPath("//label[text()='Program Name']/parent::div//input[@type='text']")); } }
        public By ReferenceTextbox { get { return (By.XPath("//input[@name='data[VarianceReference]']")); } }
        public By OrderIdTextbox { get { return (By.XPath("//input[@name='data[OrderId]']")); } }
        public By ConfirmOrderIdTextbox { get { return (By.XPath("//input[@name='data[ConfirmOrderId]']")); } }
        public By StartDate { get { return (By.XPath("//div[contains(@class,'StartDate')]/div")); } }
        public By EndDate { get { return (By.XPath("//div[contains(@class,'EndDate')]/div")); } }
                     
        public By ClaimStartDateSelection(string StartDate)
        {
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + StartDate + "')])"));
        }
        public By ClaimEndDateSelection(string EndDate)
        {
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + EndDate + "')])[2]"));
        }

        public By PurchasedActivityCostTextbox { get { return (By.XPath("//input[@name='data[TotalActivityCost]']")); } }
        public By RequestedAmountTextbox { get { return (By.XPath("//input[@name='data[RequestedAmount]']")); } }
        public By PreviousButton { get { return (By.XPath("//button[text()='Next']")); } }
        public By UploadAttachment { get { return (By.XPath("//label[contains(text(),'Upload')]")); } }
        public By CommentTextbox { get { return (By.XPath("//textarea[@id='txtComments']")); } }
        public By Next1Button { get { return (By.XPath("//button[text()='Next']")); } }
        public By Next2Button { get { return (By.XPath("//button[@name='data[Next]']")); } }
        public By Next3Button { get { return (By.XPath("//span[text()='Next']")); } }
        public By SubmitButton { get { return (By.XPath("//span[text()='Submit']")); } }
        public By DisplayClaimCreationSuccessfulMessage { get { return (By.XPath("//h2[contains(text(),'Successfully')]")); } }
        public By ImgLoading { get { return By.XPath("//div[contains(@id,'loading')]"); } }
        public By DisplayClaimIDLink { get { return (By.XPath("//label[contains(text(),'Showing')]//following::a[contains(text(),'DCL-')][1]")); } }
        public By SearchTextbox { get { return (By.XPath("//input[@id='searchId']")); } }
        public By SearchButton { get { return (By.XPath("//span[text()='Search']")); } }
        public By DisplayClaimStatus { get { return By.XPath("//label[contains(text(),'Showing')]//following::a[contains(text(),'DCL-')][1]//following::span[1]"); } }

        public By DisplayClaimResponseDropdown { get { return By.XPath("//label[contains(text(),'Display')]/following-sibling::div[@role='combobox']"); } }
        public By DisplayClaimResponseTextbox { get { return (By.XPath("//label[contains(text(),'Display')]/parent::div//input[@type='text']")); } }
        public By SendResponseButton { get { return (By.XPath("//button[@type='submit']")); } }
        public By CloneButton { get { return (By.XPath("//button[@id='clone']")); } }
        public By EditDisplayClaimButton { get { return (By.XPath("//button[@id='edit']")); } }
















    }
}
