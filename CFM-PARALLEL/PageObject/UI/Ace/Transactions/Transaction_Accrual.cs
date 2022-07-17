using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;

namespace CFMAutomation.PageObject.UI.Ace.Transactions
{
    public class Transaction_Accrual
    {
        private OBJ_Common oBJ_Common;

        public Transaction_Accrual()
        {
            oBJ_Common = new OBJ_Common();

        }

        public By Dashboard { get { return (By.Id("dashboard")); } }
        public By LeftNavTransaction { get { return (By.Id("allAccruals")); } }
        public By BulkUpload { get { return (By.XPath("//span[contains(text(),'Bulk Upload')]")); } }
        public By UploadAttachment { get { return (By.XPath("//label[contains(text(),'Upload')]")); } }
        public By ConfirmUploadButton { get { return (By.XPath("//span[contains(text(),'Confirm Upload')]")); } }
        public By SuccessMessage { get { return (By.XPath("//div[contains(@class,'text-container')]")); } }
        public By ValidAccrualText { get { return By.XPath("//div[contains(@class,'col-sm-12 col-xs-12 valid-div')]//span"); } }
       
        public By TranAccrual { get { return (By.Id("accrual-btn")); } }
        public By TranAdjustment { get { return (By.Id("adjustment-btn")); } }
        public By TranTransfer { get { return (By.Id("transfer-btn")); } }
        public By ProgramNameDropdown { get { return (By.XPath("//p-dropdown[contains(@formcontrolname,'ProgramName')]")); } }
        public By ProgramNameText { get { return (By.XPath("(//input[contains(@class,'ui-dropdown-filter ui-inputtext')])[1]")); } }
        public By ProgramNameTextOption { get { return (By.XPath("//li[contains(@class,'ui-dropdown-item ui-corner-all')]")); } }

        public By LMEDropdown { get { return (By.XPath("//p-dropdown[contains(@formcontrolname,'LMEId')]")); } }
        public By LMEText { get { return (By.XPath("(//input[contains(@class,'ui-dropdown-filter ui-inputtext')])")); } }
        public By LMETextOption { get { return (By.XPath("//li[contains(@class,'ui-dropdown-item ui-corner-all')]")); } }

        public By PeriodDropdown { get { return (By.XPath("//p-dropdown[contains(@formcontrolname,'Period')]")); } }
        public By PeriodText { get { return (By.XPath("(//input[contains(@class,'ui-dropdown-filter ui-inputtext')])")); } }
        public By PeriodTextOption { get { return (By.XPath("//li[contains(@class,'ui-dropdown-item ui-corner-all')]")); } }

        public By AccrualAmount { get { return (By.XPath("//input[contains(@formcontrolname,'Amount')]")); } }
        public By ProgramPeriodDropdownOption { get { return (By.XPath("(//mat-option[contains(@class,'mat-option')]//span)[2]")); } }
        public By AccrualComments { get { return (By.XPath("//textarea[contains(@formcontrolname,'Comment')]")); } }
        public By SubmitButton { get { return (By.XPath("//span[contains(text(),'Confirm Allocation')]")); } }
        public By BackToTansactions { get { return (By.XPath("//span[contains(text(),'Back to Transactions')]")); } }

        public By ProgramList(string prgname) { return (By.XPath("//ul[contains(@class,'nav nav-tabs')]//li//a[contains(.,'" + prgname + "')]")); }
        public By OtherProgramsLink { get { return (By.PartialLinkText("Other Programs")); } }
        public By FundDetailsLink { get { return (By.PartialLinkText("View Detailed Report")); } }
        public By AccrualTab { get { return (By.XPath("//div[contains(@class,'mat-tab-label-content') and contains(.,'Accrued')]")); } }
        public By AccrualStore { get { return (By.XPath("(//span[contains(@class,'ui-cell-data') and contains(.,'00020')])[1]")); } }
        public By AccruedAmount { get { return (By.XPath("(//span[contains(@class,'ui-cell-data')]//span[contains(@class,'ng-star-inserted')])[1]")); } }
        public By ImgLoading { get { return By.Id("loading-image"); } }
        public By ButtonPreview { get { return (By.XPath("//button[contains(.,'Preview')]")); } }
        public By AvailableFunds { get { return By.XPath("//div[contains(text(),'Available Funds')]/span"); } }
        public By LoadingImageSnapShot { get { return By.XPath("//img[contains(@src,'assets/images/Ellipsis.gif')]"); } }

        public By ViewDetailedReport { get { return By.XPath("//a[contains(.,'View Detailed Report')]"); } }
        public By AccruedTab { get { return By.XPath("//a[contains(.,'Accrued')]"); } }

        public By SubmittedStartdate { get { return (By.XPath("(//p-calendar//.//input)[1]")); } }

        public By SubmittedEndDate { get { return (By.XPath("(//p-calendar//.//input)[2]")); } }
        
        public By StartDateSelection(string prgSrtDate)
        {
            return (By.XPath("//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgSrtDate + "')]"));
        }
        public By EndDateSelection(string prgEndDate)
        {
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgEndDate + "')])"));
        }
        public By LMEdropdownDetailedReport { get { return By.XPath("//div[@class='DropId nopadding']/p-dropdown"); } }
        public By LMESearchTxtDetailedReport { get { return By.XPath("//div[@class='DropId nopadding']/p-dropdown/div/div[3]/div/input"); } }
        public By Currentdate { get { return By.XPath("//a[contains(@class,'ui-state-highlight')]"); } }
        public By ApplyFilter { get { return By.XPath("//button[contains(@class,'search-button') and contains(.,'Apply Filter')]"); } }
        public By FirstrowAccruedAmount { get { return By.XPath("//tbody[contains(@class,'ui-datatable')]/tr[1]/td[4]/span[2]/span"); } }

        /// <summary>
        /// Method for performing Accrual Allocation
        /// </summary>
        /// <param name="accrualType">Flat or Rolling</param>
        /// <param name="amount">accrual amount</param>
        public void Transaction_AllocateAccruals(string accrualType,string amount)
        {           
            try
            {
                string ProgramName = null;
                if (accrualType.Equals("Flat"))
                {
                    ProgramName = Parameters.Ace_ProgramName();
                    //Pages.BasicInteractions().Type(ProgramNameText, Parameters.Ace_ProgramName());
                }
                else if (accrualType.Equals("Rolling"))
                {
                    ProgramName = Parameters.Ace_ProgramName_Rolling;
                    //Pages.BasicInteractions().Type(ProgramNameText, Parameters.Ace_ProgramName_Rolling);
                }

                //Get the Availble Funds
                Double AvailableFundBeforeAccrual=GetAvailableFunds(ProgramName);

                Pages.BasicInteractions().WaitTime(5);
                //Pages.BasicInteractions().WaitVisible(LeftNavTransaction);
                Pages.BasicInteractions().Click(LeftNavTransaction,true);
               // Pages.BasicInteractions().WaitVisible(TranAccrual);
                Pages.BasicInteractions().Click(TranAccrual,true);

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(ProgramNameDropdown);
                Pages.BasicInteractions().Click(ProgramNameDropdown);
                Pages.BasicInteractions().WaitVisible(ProgramNameText);
                Pages.BasicInteractions().Clear(ProgramNameText);
                
                Pages.BasicInteractions().Type(ProgramNameText, ProgramName);
                
                
                Pages.BasicInteractions().WaitVisible(ProgramNameTextOption);
                Pages.BasicInteractions().Click(ProgramNameTextOption);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitUntilElementClickable(LMEDropdown,60);
                Pages.BasicInteractions().Click(LMEDropdown);
                Pages.BasicInteractions().WaitVisible(LMEText);
                Pages.BasicInteractions().Clear(LMEText);
                Pages.BasicInteractions().Type(LMEText,Parameters.Ace_Test_LME_00020());
                Pages.BasicInteractions().WaitVisible(LMETextOption);
                Pages.BasicInteractions().Click(LMETextOption);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitVisible(PeriodDropdown);
                Pages.BasicInteractions().Click(PeriodDropdown);
                Pages.BasicInteractions().WaitVisible(PeriodText);
                Pages.BasicInteractions().Clear(PeriodText);
                Pages.BasicInteractions().WaitVisible(PeriodTextOption);
                Pages.BasicInteractions().Click(PeriodTextOption);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitVisible(AccrualAmount);
                Pages.BasicInteractions().Type(AccrualAmount,amount);

                Pages.BasicInteractions().WaitVisible(AccrualComments);
                Pages.BasicInteractions().Type(AccrualComments,"Accrual");

                Pages.BasicInteractions().WaitVisible(ButtonPreview);
                Pages.BasicInteractions().Click(ButtonPreview);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitVisible(SubmitButton);
                Pages.BasicInteractions().Click(SubmitButton);
                Pages.BasicInteractions().WaitTime(5);
                Console.WriteLine("$"+amount+" ACCRUED for Program: " + ProgramName+ " & Store: " + Parameters.Ace_Test_LME_00020());
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(BackToTansactions);
                Pages.BasicInteractions().Click(BackToTansactions);

                Pages.BasicInteractions().WaitVisible(Dashboard);
                Pages.BasicInteractions().Click(Dashboard);
                Pages.BasicInteractions().WaitTime(10);
                Double AvailableFundAfterAccrual=GetAvailableFunds(ProgramName);

                Assert.True( Convert.ToDouble(AvailableFundAfterAccrual)==(Convert.ToDouble(AvailableFundBeforeAccrual) + Convert.ToDouble(amount)));
                Console.WriteLine("Accrual Amount Added to Available Funds Correctly");

                //Pages.BasicInteractions().WaitVisible(Dashboard);
                //Pages.BasicInteractions().Click(Dashboard);
                //Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                //Pages.BasicInteractions().WaitTime(10);
                //if (Pages.BasicInteractions().IsElementDisplayed(ProgramList(Parameters.Ace_ProgramName())))
                //{
                //    Pages.BasicInteractions().WaitTime(5);
                //    Pages.BasicInteractions().Click(ProgramList(Parameters.Ace_ProgramName()));
                //}
                //else
                //{
                //    Pages.BasicInteractions().WaitTime(5);
                //    Pages.BasicInteractions().WaitVisible(OtherProgramsLink);
                //    Pages.BasicInteractions().Click(OtherProgramsLink);
                //    Pages.BasicInteractions().WaitTime(5);
                //    Pages.BasicInteractions().Click(ProgramList(Parameters.Ace_ProgramName()));
                //}

                //Pages.BasicInteractions().WaitTime(10);
                //Pages.BasicInteractions().WaitVisible(FundDetailsLink);
                //Pages.BasicInteractions().Click(FundDetailsLink);
                //Pages.BasicInteractions().WaitVisible(AccrualTab);
                //Pages.BasicInteractions().Click(AccrualTab);
                //Pages.BasicInteractions().WaitVisible(AccrualStore);
                ////var amountCheck = new Regex("^[()]+$");
                //if (Pages.BasicInteractions().IsElementDisplayed(AccruedAmount) || Pages.BasicInteractions().GetText(AccruedAmount).Contains("("))
                //{
                //    Console.WriteLine("Entry present under ACCURED tab");
                //}
                //else
                //{
                //    Console.WriteLine("Entry NOT present under ACCRUED tab");
                //}
            }
            catch(Exception ex)
            {               
                Console.WriteLine("Exception IN Workflow Transaction_AllocateAccruals " + ex);
            }
        }


        //verifying Accrual Entry under Detailed Report
        public void VerifyingAccrualEntryUnderDetailedReport(string accrualType)
        {         
            try
            {
                string ProgramName = null;
                if (accrualType.Equals("Flat"))
                {
                    ProgramName = Parameters.Ace_ProgramName();
                }
                else 
                {
                    ProgramName = Parameters.Ace_ProgramName_Rolling;
                }

                Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(LoadingImageSnapShot);
                Pages.BasicInteractions().WaitTime(5);
                if (Pages.BasicInteractions().IsElementDisplayed(ProgramList(ProgramName)))
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(ProgramList(ProgramName));

                }
                else
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().WaitVisible(OtherProgramsLink);
                    Pages.BasicInteractions().Click(OtherProgramsLink);
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(ProgramList(ProgramName));
                }
                Pages.BasicInteractions().WaitTillNotVisible(LoadingImageSnapShot);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(ViewDetailedReport);
                Pages.BasicInteractions().ClickJavaScript(ViewDetailedReport);
                Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);

                Pages.BasicInteractions().WaitVisible(AccruedTab);
                if (Pages.BasicInteractions().IsElementEnabled(LMEdropdownDetailedReport))
                {
                    Pages.BasicInteractions().Click(LMEdropdownDetailedReport);
                    Pages.BasicInteractions().WaitTime(2);
                    Pages.BasicInteractions().TypeClear(LMESearchTxtDetailedReport, Parameters.Ace_Test_LME1);
                    Pages.BasicInteractions().Type(LMESearchTxtDetailedReport, Keys.Down);
                    Pages.BasicInteractions().Type(LMESearchTxtDetailedReport, Keys.Enter);
                }
                Pages.BasicInteractions().WaitVisible(SubmittedStartdate);
                Pages.BasicInteractions().Click(SubmittedStartdate);
                Pages.BasicInteractions().WaitTime(2);
                DateSelection dsTran = new DateSelection();
                Pages.BasicInteractions().ClickJavaScript(Currentdate);

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(SubmittedEndDate);
                Pages.BasicInteractions().Click(SubmittedEndDate);
                Pages.BasicInteractions().WaitTime(2);
                DateSelection dsExp = new DateSelection();
                Pages.BasicInteractions().ClickJavaScript(Currentdate);
                Pages.BasicInteractions().WaitTime(3);

                Pages.BasicInteractions().Click(ApplyFilter);
                Pages.BasicInteractions().WaitTime(10);
                Regex regex = new Regex("[^0-9.]");
                //Checking the First row Amount
                Assert.AreEqual(regex.Replace(Pages.BasicInteractions().GetText(FirstrowAccruedAmount),""), Parameters.Ace_AccrualPositive_Amount);
                Console.WriteLine("Accrual Amount Entry showing under Fund Snapshot");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception IN Workflow VerifyingAccrualEntryUnderDetailedReport " + ex);

            }
        }      
               
        public double GetAvailableFunds(string ProgramName)
        {
             double FinalAvailableFund = 0;
            try
            {
                Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(LoadingImageSnapShot);
                Pages.BasicInteractions().WaitTime(5);
                if (Pages.BasicInteractions().IsElementDisplayed(ProgramList(ProgramName)))
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(ProgramList(ProgramName));

                }
                else
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().WaitVisible(OtherProgramsLink);
                    Pages.BasicInteractions().Click(OtherProgramsLink);
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(ProgramList(ProgramName));
                }
                Pages.BasicInteractions().WaitTillNotVisible(LoadingImageSnapShot);
                Pages.BasicInteractions().WaitTime(5);
                string AvailableFund = Pages.BasicInteractions().GetText(AvailableFunds);

                if (AvailableFund.Contains("(") | AvailableFund.Contains(")"))
                {
                    AvailableFund = "-" + AvailableFund.Replace("(", "").Replace(")", "");
                }
                Regex regex = new Regex("[^0-9.]");
                FinalAvailableFund = Convert.ToDouble(regex.Replace(AvailableFund, ""));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception IN Workflow GetAvailableFunds " + ex);
                throw;
            }
            return FinalAvailableFund;

        }

        public void Create_BulkAccrual()
        {            
            try
            {
                Pages.BasicInteractions().WaitVisible(Dashboard);
                Pages.BasicInteractions().WaitUntilElementVisible(LeftNavTransaction,120);
                Pages.BasicInteractions().Click(LeftNavTransaction);
                Pages.BasicInteractions().WaitUntilElementVisible(TranAccrual,120);
                Pages.BasicInteractions().Click(TranAccrual);
                Pages.BasicInteractions().WaitUntilElementVisible(BulkUpload,120);               
                Pages.BasicInteractions().Click(BulkUpload);
                Pages.BasicInteractions().WaitVisible(UploadAttachment);
                CommonUtilities.UploadFile(oBJ_Common.FileUploadInput,"BulkAccrual.csv");
                Pages.BasicInteractions().WaitVisible(ConfirmUploadButton);
                Console.WriteLine("Accruing amount for 6 stores " + Pages.BasicInteractions().GetText(ValidAccrualText));
                Assert.AreEqual("6 valid accruals", Pages.BasicInteractions().GetText(ValidAccrualText), "Expected and Actual are same");              
                Pages.BasicInteractions().Click(ConfirmUploadButton);
                Pages.BasicInteractions().WaitVisible(SuccessMessage);
                Console.WriteLine(Pages.BasicInteractions().GetText(SuccessMessage));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception IN Workflow Create_BulkAccrual " + ex);
                throw;
            }          
        }
    }
}
