using CFM_PARALLEL.PageObject.PageFactory;
using OpenQA.Selenium;
using System;

namespace CFM_PARALLEL.PageObject.UI.Ace.Claim
{
    public class Claim_ReviewSubmit
    {
        private IWebDriver Driver { get; set; }
        public Claim_ReviewSubmit(IWebDriver Driver)
        {
            this.Driver = Driver;
        }
        public By SubmitButton { get { return (By.XPath("//span[contains(text(),'Submit')] ")); } }
        public By GrowlMessage { get { return (By.XPath("//div[contains(@class,'ui-growl ui-widget')]")); } }
        public By PreviousButton { get { return (By.XPath("//button[contains(.,'Previous')]")); } }
        public By ClaimSuccessfulMessage { get { return (By.XPath("//h2[contains(text(),'Successfully')]")); } }
        public By Dashboard { get { return (By.Id("dashboard")); } }
        public By imgLoading { get { return By.Id("loading-image"); } }
        public string GblClaimID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Ace_Claim_ReviewSubmit()
        {
           
            Claim_FullFlow claim_FullFlow = new Claim_FullFlow(Driver);
            try
            {
                Pages.BasicInteractions().WaitUntilElementVisible(SubmitButton,240);
                Pages.BasicInteractions().Click(SubmitButton);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);         
                Pages.BasicInteractions().WaitVisible(ClaimSuccessfulMessage);
                Console.WriteLine(Pages.BasicInteractions().GetText(ClaimSuccessfulMessage));
                string str = Pages.BasicInteractions().GetText(ClaimSuccessfulMessage);
                string[] str1 = str.Split(' ');
                Console.WriteLine(str1[0]);
                claim_FullFlow.CLAIM_ID = str1[0].ToString();
                GblClaimID = str1[0].ToString();
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
            return GblClaimID;
        }
    }
}
