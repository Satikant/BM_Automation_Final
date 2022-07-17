using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.Ace.Claim;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace CFMAutomation.PageObject.UI.Ace.Claim
{
    public class Claim_Negative
    {
        private IWebDriver Driver { get; set; }
        public Claim_Negative(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }
        public By ErrorActivityTypeRequired { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Activity Type is required')]")); } }
        public By ErrorStartDateRequired { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Start Date is required')]")); } }
        public By ErrorEndDateRequired { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'End Date is required')]")); } }
        public By ErrorTotalActivityCostReq { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Total Activity Cost is required')]")); } }
        public By ErrorRequestedAmountReq { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Requested Amount is required')]")); } }
        public By ErrorAttachDocument { get { return (By.XPath("//div[contains(@class,'ui-growl-item')]")); } }
        public By AttachementRemove { get { return (By.XPath("//i[contains(@class,'fa fa-times-circle cursor-pointer')]")); } }
        public By LeftNavClaim { get { return (By.Id("ManageClaim")); } }
        public By imgLoading { get { return By.Id("loading-image"); } }

        public void Ace_Claim_Negative()
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Claim_Negative));
            Claim_ChooseProgram claim_ChooseProgram = new Claim_ChooseProgram(Driver);
            Claim_EnterDetails claim_EnterDetails = new Claim_EnterDetails(Driver);
            Claim_AttachDocuments claim_AttachDocuments = new Claim_AttachDocuments(Driver);
            Claim_ReviewSubmit claim_ReviewSubmit = new Claim_ReviewSubmit(Driver);
            OBJ_Claims obj_claims = new OBJ_Claims();
            try
            {
                bi.WaitVisible(LeftNavClaim);
                bi.Click(LeftNavClaim);
                bi.WaitTillNotVisible(imgLoading);
                bi.WaitTime(10);
                //bi.WaitVisible(SubmitClaim);
                if (!bi.IsElementPresent(claim_ChooseProgram.SubmitClaim_Claims))
                {
                    Console.WriteLine("Cannot create Claims, link to create Claims is not present in the application");
                }
                else
                {
                    bi.Click(claim_ChooseProgram.SubmitClaim_Claims);
                    bi.WaitTillNotVisible(imgLoading);
                    bi.WaitTime(5);

                    //**Choose Program stepper
                    bi.WaitVisible(claim_ChooseProgram.BPAForClaimNo);
                    bi.Click(claim_ChooseProgram.BPAForClaimNo);
                    bi.WaitTillNotVisible(imgLoading);
                    bi.WaitTime(5);
                    BrowserURLLaunch browserURLLaunch = new BrowserURLLaunch(Driver);
                    if (BrowserURLLaunch.ROLES.Equals("CORPORATE1") || BrowserURLLaunch.ROLES.Equals("CORPORATE2"))
                    {
                        bi.WaitVisible(claim_ChooseProgram.StoreDropdown);
                        bi.Click(claim_ChooseProgram.StoreDropdown);
                        //bi.WaitTime(5);
                        bi.WaitVisible(claim_ChooseProgram.StoreText);
                        bi.Type(claim_ChooseProgram.StoreText, Parameters.Ace_Test_LME1);
                        //bi.WaitTime(5);
                        bi.Type(claim_ChooseProgram.StoreText, Keys.Enter);
                        bi.WaitTime(5);
                        bi.WaitTillNotVisible(imgLoading);
                        Console.WriteLine("CLAIM NEGATIVE: Store selected");
                    }

                    bi.WaitTillNotVisible(imgLoading);
                    bi.WaitVisible(claim_ChooseProgram.CoopProgram);
                    bi.Click(claim_ChooseProgram.CoopProgram);
                    bi.WaitVisible(claim_ChooseProgram.CoopProgramText);
                    //bi.WaitTime(2);
                    if (Parameters.Ace_ProgramName() != null)
                    {
                        bi.TypeClear(claim_ChooseProgram.CoopProgramText, Parameters.Ace_ProgramName());
                        //bi.WaitTime(2);
                    }
                    bi.Type(claim_ChooseProgram.CoopProgramText, Keys.Enter);
                    bi.WaitTime(3);
                    Console.WriteLine("CLAIM NEGATIVE: Program selected");

                    bi.WaitVisible(claim_ChooseProgram.NextButton);
                    bi.Click(claim_ChooseProgram.NextButton);

                    //**Enter Details stepper
                    bi.WaitVisible(claim_EnterDetails.NextButton);
                    bi.Click(claim_EnterDetails.NextButton);
                    bi.Clear(claim_EnterDetails.ClaimReference);
                    bi.Type(claim_EnterDetails.ClaimReference,"REF-1234");
                    bi.WaitVisible(claim_EnterDetails.NextButton);
                    bi.Click(claim_EnterDetails.NextButton);
                    if (bi.IsElementPresent(ErrorActivityTypeRequired))
                    {
                        bi.WaitVisible(claim_EnterDetails.ActivityTypeDropdown);
                        bi.Click(claim_EnterDetails.ActivityTypeDropdown);
                        bi.WaitVisible(claim_EnterDetails.ActivityTypeText);
                        bi.Type(claim_EnterDetails.ActivityTypeText,"Direct Mail");
                        //bi.WaitVisible(claim_EnterDetails.ActivityTypeTextOption);
                        //claim_EnterDetails.ActivityTypeTextOption.Click();
                        bi.Type(claim_EnterDetails.ActivityTypeText,Keys.Enter);
                        Console.WriteLine("CLAIM NEGATIVE: Activity Selected for Claim");
                    }

                    bi.Click(claim_EnterDetails.NextButton);
                    if (bi.IsElementPresent(ErrorStartDateRequired))
                    {
                        bi.WaitVisible(claim_EnterDetails.ClaimStartdate);
                        bi.Click(claim_EnterDetails.ClaimStartdate);
                        bi.Click(claim_EnterDetails.ClaimStartDateSelection(DateSelection.Ace_DateSelection_claimStartDate()));
                        Console.WriteLine("CLAIM NEGATIVE: Start Date selected for Claim");
                    }

                    bi.Click(claim_EnterDetails.NextButton);
                    if (bi.IsElementPresent(ErrorEndDateRequired))
                    {
                        bi.WaitVisible(claim_EnterDetails.ClaimEndDate);
                        bi.Click(claim_EnterDetails.ClaimEndDate);
                        bi.WaitTime(5);
                        bi.Click(claim_EnterDetails.ClaimEndDateSelection(DateSelection.Ace_DateSelection_claimEndDate()));
                        Console.WriteLine("CLAIM NEGATIVE: End Date selected for Claim");
                    }

                    bi.Click(claim_EnterDetails.NextButton);
                    if (bi.IsElementPresent(ErrorTotalActivityCostReq))
                    {
                        bi.Type(claim_EnterDetails.ClaimTotalActivityCost,"300");
                        Console.WriteLine("CLAIM NEGATIVE: Total Activity Cost entered for Claim");
                    }

                    bi.Click(claim_EnterDetails.NextButton);
                    if (bi.IsElementPresent(ErrorRequestedAmountReq))
                    {
                        bi.Type(claim_EnterDetails.ClaimRequestedAmount,"20");
                        Console.WriteLine("CLAIM NEGATIVE: Requested Amount entered for Claim");
                    }
                    bi.Click(claim_EnterDetails.NextButton);

                    //**Attach Document
                    bi.WaitVisible(claim_AttachDocuments.NextButton);
                    bi.Click(claim_AttachDocuments.NextButton);
                    //if (bi.IsElementPresent(obj_claims.ErrorInvoiceRequired))
                    //{
                        bi.WaitVisible(claim_AttachDocuments.ClaimComments);
                        bi.Clear(claim_AttachDocuments.ClaimInvoice);
                        bi.Type(claim_AttachDocuments.ClaimInvoice,"INV-1234");
                        Console.WriteLine("CLAIM NEGATIVE: Invoice number entered");
                    //}

                    bi.Click(claim_AttachDocuments.NextButton);
                    //bi.Click(obj_claims.btnNext3);
                    //bi.WaitTime(1);
                    if (bi.IsElementPresent(obj_claims.ErrorAttachmentRequired_bobcat))
                    {
                        bi.WaitVisible(obj_claims.ClaimUpload);
                        bi.Click(obj_claims.ClaimUpload);
                        bi.WaitTime(3);
                        //File Upload
                        CommonUtilities.UploadFileInChrome("CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                        //bi.WaitVisible(obj_claims.ClaimComments);
                        //bi.Type(obj_claims.ClaimComments, "Claim-Comments");
                        if (bi.IsElementPresent(obj_claims.AttachementRemove))
                        {
                            Console.WriteLine("CLAIM NEGATIVE: Attachment added for " + BrowserURLLaunch.ROLES);
                        }
                        else
                        {
                            Console.WriteLine("CLAIM NEGATIVE: Attachement not attached");
                        }
                    }
                    else
                    {
                        Console.WriteLine("CLAIM NEGATIVE: Attachment Error message not shown");
                    }

                    bi.WaitVisible(obj_claims.ClaimComments);
                    bi.Type(obj_claims.ClaimComments, "Claim-Comments");
                    bi.WaitVisible(obj_claims.BtnNext3);
                    bi.Click(obj_claims.BtnNext3);
                    bi.WaitTime(5);
                    //Review and Submit
                    if (bi.IsElementPresent(obj_claims.SubmitButton))
                    {
                        Console.WriteLine("CLAIM NEGATIVE: Submit Button for submitting a Claim is present");
                    }
                }
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("Ace_Claim_Negative: " + ex);
                Assert.Fail("Ace_Claim_Negative: " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }
        }
    }
}
