using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace CFMAutomation.PageObject.UI.Ace.BrandingPreapproval
{
    public class PreApproval_Negative
    {
        private IWebDriver Driver { get; set; }
        public PreApproval_Negative(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        public By ErrorStoreRequired { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Store')]")); } }
        public By ErrorActivityTypeRequired { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Activity Type')]")); } }
        public By ErrorStartDateRequired { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'Start Date')]")); } }
        public By ErrorEndDateRequired { get { return (By.XPath("//div[contains(@class,'formio-errors invalid-feedback') and contains(.,'End Date')]")); } }
        public By ErrorAttachDocument { get { return (By.XPath("//div[contains(@class,'ui-growl-item')]")); } }
        public By AttachementRemove { get { return (By.XPath("//i[contains(@class,'fa fa-times-circle cursor-pointer')]")); } }
        public By LeftNavPreapprovals { get { return By.XPath("//a[contains(@id,'brandingList')]"); } }
        public By imgLoading { get { return By.Id("loading-image"); } }
        public By ErrorInvoiceRequired { get { return By.XPath("//div[@class='ui-toast-detail' and contains(.,'Invoice # cannot be blank')]"); } }
        public By ErrorAttachmentRequired { get { return By.XPath("//div[@class='ui-toast-detail' and contains(.,'Required atleast one support document')]"); } }

        /// <summary>
        /// method to check error messages across all the fields
        /// </summary>
        public void Ace_PreApproval_Negative()
        {
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(PreApproval_Negative));
            Preapprovals_EnterDetails preapprovals_EnterDetails = new Preapprovals_EnterDetails(Driver);
            Preapprovals_AddAttachments preapprovals_AddAttachments = new Preapprovals_AddAttachments(Driver);
            try
            {
                Pages.BasicInteractions().WaitVisible(LeftNavPreapprovals);
                Pages.BasicInteractions().Click(LeftNavPreapprovals);
                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                Pages.BasicInteractions().WaitTime(10);
                //Pages.BasicInteractions().WaitVisible(SubmitPreapprovals);
                if (!Pages.BasicInteractions().IsElementPresent(preapprovals_EnterDetails.SubmitPreapprovals))
                {
                    Console.WriteLine("Cannot create BPA, link to create BPA is not present in the application");
                }
                else
                {
                    Pages.BasicInteractions().Click(preapprovals_EnterDetails.SubmitPreapprovals);
                    Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().WaitVisible(preapprovals_EnterDetails.NextButton);
                    Pages.BasicInteractions().Click(preapprovals_EnterDetails.NextButton);
                    Pages.BasicInteractions().WaitTime(3);
                    BrowserURLLaunch BrowserURLLaunch = new BrowserURLLaunch(Driver);
                    if (BrowserURLLaunch.ROLES.Equals("CORPORATE1") || BrowserURLLaunch.ROLES.Equals("CORPORATE2"))
                    {
                        if (Pages.BasicInteractions().IsElementPresent(ErrorStoreRequired))
                        {
                            Pages.BasicInteractions().WaitTime(5);
                            Pages.BasicInteractions().WaitVisible(preapprovals_EnterDetails.StoreDropdown);
                            Pages.BasicInteractions().Click(preapprovals_EnterDetails.StoreDropdown);
                            //Pages.BasicInteractions().WaitTime(1);
                            Pages.BasicInteractions().WaitVisible(preapprovals_EnterDetails.StoreDropdownText);
                            //preapprovals_EnterDetails.StoreDropdownText.Type(Parameters.Ace_Test_LME_00020());
                            //Pages.BasicInteractions().WaitVisible(preapprovals_EnterDetails.StoreDropdownTextOption);
                            //preapprovals_EnterDetails.StoreDropdownTextOption.Click();
                            Pages.BasicInteractions().Type(preapprovals_EnterDetails.StoreDropdownText, Parameters.Ace_Test_LME1);

                            Pages.BasicInteractions().Type(preapprovals_EnterDetails.StoreDropdownText,Keys.Enter);
                            Console.WriteLine("BPA NEGATIVE: Store selected for " + BrowserURLLaunch.ROLES);
                        }
                    }

                    Pages.BasicInteractions().Click(preapprovals_EnterDetails.NextButton);
                    Pages.BasicInteractions().WaitTime(3);
                    if (Pages.BasicInteractions().IsElementPresent(ErrorActivityTypeRequired))
                    {
                        Pages.BasicInteractions().WaitVisible(preapprovals_EnterDetails.ActivityDropdown);
                        Pages.BasicInteractions().Click(preapprovals_EnterDetails.ActivityDropdown);
                        Pages.BasicInteractions().Type(preapprovals_EnterDetails.ActivityDropdownText,"Direct Mail");
                        //Pages.BasicInteractions().WaitVisible(preapprovals_EnterDetails.ActivityTypeTextOption);
                        //preapprovals_EnterDetails.ActivityTypeTextOption.Click();
                        Pages.BasicInteractions().Type(preapprovals_EnterDetails.ActivityDropdownText,Keys.Enter);
                        Console.WriteLine("BPA NEGATIVE: Activity Type selected for " + BrowserURLLaunch.ROLES);
                    }
                    Pages.BasicInteractions().WaitTime(3);
                    Pages.BasicInteractions().Click(preapprovals_EnterDetails.NextButton);
                    Pages.BasicInteractions().WaitTime(3);
                    if (Pages.BasicInteractions().IsElementPresent(ErrorStartDateRequired))
                    {
                        Pages.BasicInteractions().WaitVisible(preapprovals_EnterDetails.Startdate);
                        Pages.BasicInteractions().Click(preapprovals_EnterDetails.Startdate);
                        //Pages.BasicInteractions().WaitTime(3);
                        Pages.BasicInteractions().Click(preapprovals_EnterDetails.BPAStartDateSelection(DateSelection.Ace_DateSelection_bpaStartDate()));
                        Console.WriteLine("BPA NEGATIVE: Start Date selected for " + BrowserURLLaunch.ROLES);
                    }
                    Pages.BasicInteractions().WaitTime(3);
                    Pages.BasicInteractions().Click(preapprovals_EnterDetails.NextButton);
                    Pages.BasicInteractions().WaitTime(3);
                    if (Pages.BasicInteractions().IsElementPresent(ErrorEndDateRequired))
                    {
                        Pages.BasicInteractions().WaitVisible(preapprovals_EnterDetails.Enddate);
                        Pages.BasicInteractions().Click(preapprovals_EnterDetails.Enddate);
                        Pages.BasicInteractions().WaitTime(5);
                        Pages.BasicInteractions().Click(preapprovals_EnterDetails.BPAEndDateSelection(DateSelection.Ace_DateSelection_bpaEndDate()));
                        Console.WriteLine("BPA NEGATIVE: End Date selected for " + BrowserURLLaunch.ROLES);
                    }
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(preapprovals_EnterDetails.NextButton);
                    Pages.BasicInteractions().WaitTime(3);
                    Pages.BasicInteractions().WaitVisible(preapprovals_AddAttachments.SubmitButton);
                    Pages.BasicInteractions().Click(preapprovals_AddAttachments.SubmitButton);
                    if (Pages.BasicInteractions().IsElementPresent(ErrorAttachmentRequired))
                    {
                        Pages.BasicInteractions().Click(preapprovals_AddAttachments.UploadFile);
                        Pages.BasicInteractions().WaitTime(5);
                        CommonUtilities.UploadFileInChrome("CoOpGuidelines_LCP_2018_Q1_R6.pdf");
                        Pages.BasicInteractions().WaitTime(3);
                        if (Pages.BasicInteractions().IsElementPresent(AttachementRemove))
                        {
                            Console.WriteLine("BPA NEGATIVE: Attachment added for " + BrowserURLLaunch.ROLES);
                        }
                        else
                        {
                            Console.WriteLine("BPA NEGATIVE: Attachement not attached");
                        }
                    }
                    else
                    {
                        Console.WriteLine("BPA NEGATIVE: Attachment Error message not shown");
                    }

                    if (Pages.BasicInteractions().IsElementPresent(preapprovals_AddAttachments.SubmitButton))
                    {
                        Console.WriteLine("BPA NEGATIVE: Submit Button for submitting a BPA is present");
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ace_PreApproval_Negative: " + ex);
                Assert.Fail("Ace_PreApproval_Negative: " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }
        }
    }
}
