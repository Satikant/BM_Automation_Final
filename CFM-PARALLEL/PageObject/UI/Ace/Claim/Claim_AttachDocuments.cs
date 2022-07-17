using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFM_PARALLEL.PageObject.UI.Ace.Claim
{
    public class Claim_AttachDocuments
    {
        private IWebDriver Driver { get; set; }
        private OBJ_Common oBJ_Common;
        private OBJ_Claims obj_claims;

        public Claim_AttachDocuments(IWebDriver Driver)
        {
            this.Driver = Driver;
            oBJ_Common = new OBJ_Common();
            obj_claims = new OBJ_Claims();
        }
        public By ClaimInvoice { get { return (By.XPath("//input[contains(@formcontrolname,'Invoice')]")); } }        
        public By ClaimUpload { get { return (By.XPath("//label[contains(text(),'Upload')]")); } }
        public By CCEmail { get { return By.XPath("//*[contains(@name,'data[ccEmail]')]"); } }
        public By ClaimComments { get { return (By.Id("txtComments")); } }
        public By NextButton { get { return (By.XPath("//div[contains(@class,'marginTop20 marginBottom10')]/button[2]")); } }

        /// <summary>
        /// 
        /// </summary>
        public void Ace_Claim_AttachDocument()
        {
           // BasicInteractions bi = new BasicInteractions(Driver);            
            try
            {
                Pages.BasicInteractions().WaitVisible(ClaimInvoice);
                Pages.BasicInteractions().TypeClear(ClaimInvoice, "Claim-Invoice-1234");
                Pages.BasicInteractions().WaitUntilElementVisible(ClaimUpload,240);
                //File Upload
                CommonUtilities.UploadFile(oBJ_Common.FileUploadInput, "CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                Pages.BasicInteractions().WaitUntilElementVisible(obj_claims.FileUploadedSuccessfully, 120);
                Pages.BasicInteractions().WaitVisible(ClaimComments);
                Pages.BasicInteractions().Type(ClaimComments, "Claim-Comments");
                Pages.BasicInteractions().WaitUntilElementClickable(NextButton, 120);
                Pages.BasicInteractions().Click(NextButton);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }
            catch (Exception ex)
            {                
                Console.WriteLine("Ace_Claim_AttachDocument"+ex);
                Assert.Fail("Ace_Claim_AttachDocument" + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }
    }
}
