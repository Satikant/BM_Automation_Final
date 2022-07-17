using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval;
using CFMAutomation.Common;
using OpenQA.Selenium;
using System;

namespace CFM_PARALLEL.PageObject.UI.Ace.Claim
{
    public class Claim_ChooseProgram
    {
        private IWebDriver Driver { get; set; }

        public Claim_ChooseProgram(IWebDriver Driver)
        {
            this.Driver = Driver;
        }
        public By LeftNavClaim { get { return (By.Id("ManageClaim")); } }

        public By Submit { get { return By.XPath("//button[contains(@class,'dropdown-toggle') and contains(@aria-expanded,true)]"); } }
        public By SubmitClaim { get { return (By.XPath("//a[contains(@class,'submit-menu') and contains(.,'Submit Claim')]")); } }
        public By SubmitClaim_Claims { get { return By.Id("submitClaim"); } }
        public By ImgLoading { get { return By.Id("loading-image"); } }
        public By SearchClaim { get { return (By.Id("searchId")); } }
        public By BPAForClaimYes { get { return (By.XPath("//label[contains(@class,'control-label') and contains(.,'Yes')]")); } }
        public By BPAForClaimNo { get { return (By.XPath("//label[contains(@class,'control-label') and contains(.,'No')]")); } }

        public By StoreDropdown { get { return (By.XPath("//div[contains(@class,'LME')]/div/div[contains(@class,'form-control')]")); } }
        public By PreApprovalID { get { return By.XPath("//div[contains(@class,'PreApproval')]/div/div[contains(@class,'form-control')]"); } }
        public By StoreText { get { return (By.XPath("(//input[contains(@class,'choices__input choices__input--cloned') and contains(@type,'text')])[2]")); } }
        public By PreApprovalIDText { get { return By.XPath("(//input[contains(@class,'choices__input choices__input--cloned') and contains(@type,'text')])[4]"); } }
        public By ClaimTextSelected { get { return (By.XPath("//div[contains(text(),'26957 - (HQ) Agway Stores')]")); } }
        public By CoOpProgramRadioSelect(string prgname)
        {
            return (By.XPath("//label[contains(.,'" + prgname + "')]"));
        }
        public By CoopProgram { get { return (By.XPath("//div[contains(@class,'SelectedProgram')]/div/div[contains(@class,'form-control')]")); } }
        public By CoopProgramWithBPA { get { return (By.XPath("//div[contains(@class,'BrandingProgram')]/div/div[contains(@class,'form-control')]")); } }
        public By CoopProgramText { get { return (By.XPath("//label[contains(text(),'Co-op Program')]/parent::div[contains(@class,'formio-component-select') and contains(@style,'visible')]//input[@type='text']")); } }
        public By CoopProgramTextWithBPA { get { return (By.XPath("(//input[contains(@class,'choices__input choices__input--cloned') and contains(@type,'text')])[5]")); } }
        public By NextButton { get { return (By.XPath("//button[contains(@class,'primary-button') and contains(.,'Next')]")); } }
        public By ErrorTechnical { get { return (By.XPath("//h1[contains(.,'technical error occured')]")); } }
        public By Error500Internal { get { return (By.XPath("//hi[contains(.,'Error 500: Internal Server Error')]")); } }
        public By Product { get { return By.XPath("//label[contains(text(),'Product')]/parent::div[contains(@class,'formio-component-select') and contains(@style,'visible')]//div[@role='combobox']"); } }
        public By ProductTextbox { get { return By.XPath("//label[contains(text(),'Product')]/parent::div[contains(@class,'formio-component-select') and contains(@style,'visible')]//input[@type='text']"); } }

        public string BPA_CHOICE;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bpa"></param>
        /// <param name="bpa_choice"></param>
        /// <param name="db_lme"></param>
        public void Ace_Claim_ChooseProgram(string bpa, string bpa_choice, string db_lme, string Env, string ProgramOverDrawn = "NO")
        {
            BasicInteractions bi = new BasicInteractions(Driver);

            Preapproval_FullFlow preapproval_FullFlow = new Preapproval_FullFlow(Driver);
            try
            {
                Pages.BasicInteractions().WaitUntilElementVisible(Submit,240);
                
                if (!Pages.BasicInteractions().IsElementPresent(Submit))
                {
                    Console.WriteLine("Cannot create Claims, link to create Claims is not present in the application");
                }
                else
                {
                    Pages.BasicInteractions().Click(Submit);
                    Pages.BasicInteractions().WaitVisible(SubmitClaim);
                    Pages.BasicInteractions().Click(SubmitClaim);
                    Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);

                    if (Pages.BasicInteractions().IsElementPresent(ErrorTechnical))
                    {
                        Console.WriteLine("BPA ERROR: A technical error occured message is displayed");
                    }
                    else if (Pages.BasicInteractions().IsElementPresent(Error500Internal))
                    {
                        Console.WriteLine("BPA ERROR: Error 500: Internal Server Error occured");
                    }
                    else
                    {
                        BPA_CHOICE = bpa_choice;

                        //opting for BPA
                        if (bpa_choice == "Y")
                        {
                            Pages.BasicInteractions().WaitUntilElementVisible(BPAForClaimYes,240);
                            Pages.BasicInteractions().Click(BPAForClaimYes);
                            Pages.BasicInteractions().WaitVisible(PreApprovalID);
                            Pages.BasicInteractions().Click(PreApprovalID);
                            Pages.BasicInteractions().TypeClear(PreApprovalIDText, bpa);
                            Pages.BasicInteractions().Type(PreApprovalIDText,Keys.Enter);
                            Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
                            Pages.BasicInteractions().WaitVisible(CoopProgramWithBPA);
                            Pages.BasicInteractions().Click(CoopProgramWithBPA);
                            Pages.BasicInteractions().WaitVisible(CoopProgramTextWithBPA);
                            if (Parameters.Ace_ProgramName(ProgramOverDrawn) != null)
                            {
                                Pages.BasicInteractions().TypeClear(CoopProgramTextWithBPA, Parameters.Ace_ProgramName(ProgramOverDrawn));
                            }
                            Pages.BasicInteractions().Type(CoopProgramTextWithBPA, Keys.Enter);
                            Pages.BasicInteractions().WaitTime(3);
                        }
                        //not opting for BPA
                        else if (bpa_choice == "N")
                        {
                            Pages.BasicInteractions().WaitUntilElementVisible(BPAForClaimNo,240);
                            Pages.BasicInteractions().Click(BPAForClaimNo);
                            Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);

                            Pages.BasicInteractions().WaitVisible(StoreDropdown);
                            Pages.BasicInteractions().Click(StoreDropdown);
                            Pages.BasicInteractions().WaitVisible(StoreText);
                            Pages.BasicInteractions().WaitTime(1);
                            Pages.BasicInteractions().Type(StoreText, Parameters.Ace_Test_LME2);
                            Pages.BasicInteractions().Type(StoreText, Keys.Enter);
                           Pages.BasicInteractions().WaitTime(3);

                            //Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
                            Pages.BasicInteractions().WaitVisible(Product);
                            Pages.BasicInteractions().Click(Product);
                            Pages.BasicInteractions().WaitVisible(ProductTextbox);
                            Pages.BasicInteractions().WaitTime(1);
                            Pages.BasicInteractions().Type(ProductTextbox, Parameters.Ace_Product);
                            Pages.BasicInteractions().Type(ProductTextbox, Keys.Enter);

                            Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
                            Pages.BasicInteractions().WaitUntilElementVisible(CoopProgram,240);
                            Pages.BasicInteractions().Click(CoopProgram);
                            Pages.BasicInteractions().WaitVisible(CoopProgramText);
                            Pages.BasicInteractions().WaitTime(1);
                            Pages.BasicInteractions().Type(CoopProgramText, Parameters.ACE_ProgramName);
                            Pages.BasicInteractions().Type(CoopProgramText, Keys.Enter);
                        }
                        Pages.BasicInteractions().WaitUntilElementVisible(NextButton,240);
                        Pages.BasicInteractions().Click(NextButton);
                        Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Claim_ChooseProgram: " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }
    }
}
