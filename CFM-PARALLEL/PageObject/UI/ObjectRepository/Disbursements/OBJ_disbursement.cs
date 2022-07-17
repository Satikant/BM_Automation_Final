using OpenQA.Selenium;


namespace CFM_PARALLEL.PageObject.UI.ObjectRepository.Disbursements
{
    public class OBJ_Disbursement
    {
        public By LeftNavDisbursement { get { return (By.XPath("//a[@id='disbursementList']")); } }
        public By NewDisbursement { get { return (By.XPath("//span[text()='New Disbursement']")); } }
        public By Filter { get { return (By.XPath("//span[text()='Filters']")); } }
        public By FirstRowClaimID_Disbursement { get { return (By.XPath("//tbody[@class='ui-table-tbody']/tr[1]/td[1]//div[contains(@class,'chkbox-box')]")); } }
        public By SecondRowClaimID_Disbursement { get { return (By.XPath("//tbody[@class='ui-table-tbody']/tr[2]/td[1]//div[contains(@class,'chkbox-box')]")); } }
        public By FirstRowDisbursementStatus { get { return (By.XPath("//tbody[@class='ui-table-tbody']/tr[1]/td[4]")); } }
        public By PreviewDisbursement { get { return (By.XPath("//span[contains(text(),'Preview Disbursement')]")); } }
        public By SubmitButton { get { return (By.XPath("//span[contains(text(),'Submit')]")); } }
        public By SuccessMessage { get { return (By.XPath("//div[@class='ui-toast-detail' and contains(text(),'Successfully')]")); } }
        public By BackArrow { get { return (By.XPath("//i[contains(@class,'back-arrow')]")); } }
        public By FirstRowDisbID { get { return (By.XPath("//tbody[@class='ui-table-tbody']/tr[1]/td[1]//span[contains(@class,'medium-Font')]")); } }
        public By MoreButton { get { return (By.XPath("//tbody[@class='ui-table-tbody']/tr[1]/td[5]//a")); } }
        public By ReviewButton { get { return (By.XPath("//span[text()='Review' or text()='Edit']")); } }
        public By Comments { get { return (By.XPath("//textarea[contains(@placeholder,'comment')]")); } }
        public By ConfirmReviewButton { get { return (By.XPath("//button[contains(@class,'primary-button')]")); } }
        //public By ReviewAction { get { return (By.XPath(GetXpath())); } }
        public By ReviewAction(string parameter) {  return (By.XPath("//span[contains(text(),'"+parameter+"')]"));  }
        public By DisbursementTab(string parameter) {  return (By.XPath("//span[contains(text(),'"+parameter+"')]"));  }
        //public By DisbursementTab { get { return (By.XPath(GetXpath())); } }
        public By DisbursementID { get { return (By.XPath("//span[contains(text(),'DISB-')]")); } }


        //public string GetXpath()
        //{
        //    return FinalXPath;
        //}

        //public void SetXpath(string parameter)
        //{
        //    string ReviewActionXpath = "//span[contains(text(),'{0}')]";
        //    FinalXPath = string.Format(ReviewActionXpath, parameter);
        //}
    }
}
