using NUnit.Framework;
using OpenQA.Selenium;
using System;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Pre_Approvals;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;

namespace CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval
{
    public class Preapprovals_AddAttachments
    {
        private IWebDriver Driver { get; set; }
        private OBJ_PreApprovals oBJ_PreApprovals;
        private OBJ_Common obj_Common;

        public Preapprovals_AddAttachments(IWebDriver Driver)
        {
            this.Driver = Driver;
            oBJ_PreApprovals = new OBJ_PreApprovals();
            obj_Common = new OBJ_Common();

        }

        public By UploadFile { get { return (By.XPath("//label[contains(text(),'Upload')]")); } }
        
        public By Comment { get { return By.XPath("//textarea[contains(@class,'textarea-comment')]"); } }
        public By SubmitButton { get { return By.XPath("//button[contains(text(),'Submit')]"); } }
        public By ViewPreapprovalStatus { get { return By.XPath("//div[contains(@class,'col-sm-12')]/li[2]"); } }
        public By BPAID { get { return By.XPath("//div[contains(@class,'ng-star-inserted')]/h1"); } }
        public By BPAStatus { get { return By.XPath("//div[contains(@class,'col-sm-12')]/label[2]"); } }
        public By imgLoading { get { return By.Id("loading-image"); } }

        static string file = System.IO.Path.GetFullPath("DeploymentItems") + "\\CoOpGuidelines_LCP_2018_Q1_R6.pdf";
        public string GblBPAID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db_comments"></param>
        public string ACE_Preapproval_AddAttachment(string db_comments)
        {
            Preapproval_FullFlow preapproval_FullFlow = new Preapproval_FullFlow(Driver);
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(UploadFile);
                Pages.BasicInteractions().WaitTime(5);

                //File Upload
                Common.CommonUtilities.UploadFileInChrome("CoOpGuidelines_LCP_2018_Q1_R6.pdf");               
                Pages.BasicInteractions().WaitVisible(Comment);
                Pages.BasicInteractions().Type(Comment, "BPA-Comments");
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(SubmitButton);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(ViewPreapprovalStatus);
                Pages.BasicInteractions().ClickJavaScript(ViewPreapprovalStatus);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                Pages.BasicInteractions().WaitTime(5);

                Console.WriteLine(Pages.BasicInteractions().GetText(BPAID));
                preapproval_FullFlow.BPA_ID = Pages.BasicInteractions().GetText(BPAID);
                GblBPAID = Pages.BasicInteractions().GetText(BPAID);
                Pages.BasicInteractions().WaitVisible(BPAStatus);
                Console.WriteLine(Pages.BasicInteractions().GetText(BPAStatus));
                if (Pages.BasicInteractions().GetText(BPAStatus) == "Approved")
                {
                    Console.WriteLine("BPA " + Pages.BasicInteractions().GetText(BPAID) + " created successfully");
                }
                else
                {
                    Console.WriteLine("BPA " + Pages.BasicInteractions().GetText(BPAID) + " is in " + Pages.BasicInteractions().GetText(BPAStatus) + " status");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ACE_Preapproval_AddAttachment: "+ex);
                Console.WriteLine("ACE_Preapproval_AddAttachment: " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }

            return GblBPAID;

        }

        public string ACE_Preapproval_AddAttachment_Smoke(string db_comments)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitUntilElementVisible(Comment,240);
                //File Upload
                CommonUtilities.UploadFile(obj_Common.FileUploadInput, "CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                Pages.BasicInteractions().WaitVisible(Comment);
                Pages.BasicInteractions().Type(Comment, "BPA-Comments-Creation");
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_PreApprovals.FPA_NextButton3,240);
                Pages.BasicInteractions().Click(oBJ_PreApprovals.FPA_NextButton3);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_PreApprovals.SubmitButton2,240);
                Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(oBJ_PreApprovals.SubmitButton2));
                Console.WriteLine("User Able to Pass Brand Pre Approval Values till Submit Button: PASSED");
            }
            catch (Exception ex)
            {
                Console.WriteLine("User Not Able to Pass Brand Pre Approval Values till Submit Button: FAILED - " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
            return GblBPAID;
        }
    }
}
