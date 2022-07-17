using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Text.RegularExpressions;

namespace CFMAutomation.PageObject.UI.Ace.Transactions
{
    public class Transaction_Adjustment
    {
        private IWebDriver Driver { get; set; }

        public Transaction_Adjustment(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }
        public By Dashboard { get { return (By.Id("dashboard")); } }

        public By LeftNavTransaction { get { return (By.Id("allAccruals")); } }
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

        public By AdjustAmount { get { return (By.XPath("//input[contains(@formcontrolname,'Amount')]")); } }
        public By ProgramPeriodDropdownOption { get { return (By.XPath("(//mat-option[contains(@class,'mat-option')]//span)[2]")); } }
        public By AccrualComments { get { return (By.XPath("//textarea[contains(@formcontrolname,'Comment')]")); } }

        public By SubmitButton { get { return (By.XPath("//span[contains(text(),'Confirm Adjustment')]")); } }
        public By BackToTansactions { get { return (By.XPath("//span[contains(text(),'Back to Transactions')]")); } }


        public By ProgramList(string prgname) { return (By.XPath("//ul[contains(@class,'nav nav-tabs')]//li//a[contains(.,'" + prgname + "')]")); }
        public By OtherProgramsLink { get { return (By.PartialLinkText("Other Programs")); } }
        public By FundDetailsLink { get { return (By.PartialLinkText("View Detailed Report")); } }
        //public By AdjustedTab { get { return (By.XPath("//div[contains(@class,'mat-tab-label-content') and contains(.,'Adjust')]")); } }
        public By AdjustedStore { get { return (By.XPath("(//span[contains(@class,'ui-cell-data') and contains(.,'00020')])[1]")); } }
        public By AdjustedAmount { get { return (By.XPath("(//span[contains(@class,'ui-cell-data')]//span[contains(@class,'ng-star-inserted')])[1]")); } }
        public By imgLoading { get { return By.Id("loading-image"); } }
        public By ButtonPreview { get { return (By.XPath("//button[contains(.,'Preview')]")); } }
        public By AvailableFunds { get { return By.XPath("//div[contains(text(),'Available Funds')]/span"); } }
        public By LoadingImageSnapShot { get { return By.XPath("//img[contains(@src,'assets/images/Ellipsis.gif')]"); } }

        public By AccrualTab { get { return (By.XPath("//li[contains(@class,'mat-ripple') and contains(.,'Accrued')]")); } }
        public By AdjustedTab { get { return (By.XPath("//li[contains(@class,'mat-ripple') and contains(.,'Adjusted')]")); } }
        //public By TransferredTab { get { return (By.XPath("//li[contains(@class,'mat-ripple') and contains(.,'Transferred')]")); } }
        public By OpenTab { get { return (By.XPath("(//li[contains(@class,'mat-ripple') and contains(.,'Open')])[2]")); } }
        public By ApprovedTab { get { return (By.XPath("//li[contains(@class,'mat-ripple') and contains(.,'Approved')]")); } }
        public By PaidTab { get { return (By.XPath("//li[contains(@class,'mat-ripple') and contains(.,'Paid')]")); } }
        public By ExpiredTab { get { return (By.XPath("//li[contains(@class,'mat-ripple') and contains(.,'Expired')]")); } }

        public By ViewDetailedReport { get { return By.XPath("//a[contains(.,'View Detailed Report')]"); } }
        public By AccruedTab { get { return By.XPath("//a[contains(.,'Accrued')]"); } }

        public By SubmittedStartdate { get { return (By.XPath("(//p-calendar//.//input)[1]")); } }

        //public By ExpirationDate { get { return (By.XPath("//div[contains(@class,'formio-component-ExpirationDate')]/div/span")); } }
        public By SubmittedEndDate { get { return (By.XPath("(//p-calendar//.//input)[2]")); } }
        //public By NextButton { get { return (By.XPath("//button[contains(@class,'btn-wizard-nav-next')]")); } }
        //public By StartDate { get { return (By.XPath("//div[contains(@class,'formio-component-StartDate')]/div/span")); } }
        //public By EndDate { get { return (By.XPath("//div[contains(@class,'formio-component-EndDate')]/div/span")); } }
        public By StartDateSelection(string prgSrtDate)
        {
            return (By.XPath("//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgSrtDate + "')]"));
        }
        public By EndDateSelection(string prgEndDate)
        {
            return (By.XPath("(//div[contains(@class,'dayContainer')]/span[contains(@aria-label,'" + prgEndDate + "')])"));
        }
        public By LMEdropdownDetailedReport { get { return By.XPath("//div[@class='DropId nopadding']/p-dropdown/div"); } }
        public By LMESearchTxtDetailedReport { get { return By.XPath("//div[@class='DropId nopadding']/p-dropdown/div/div[3]/div/input"); } }
        public By currentdate { get { return By.XPath("//a[contains(@class,'ui-state-highlight')]"); } }
        public By ApplyFilter { get { return By.XPath("//button[contains(@class,'search-button') and contains(.,'Apply Filter')]"); } }
        public By FirstrowAdjustedAmount { get { return By.XPath("//tbody[contains(@class,'ui-datatable')]/tr[1]/td[4]/span[2]/span"); } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        public void Transaction_AllocateAdjustment(string accrualType, string amount)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            Transaction_Accrual tc = new Transaction_Accrual();
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Transaction_Adjustment));
            try
            {
                //Get the Availble Funds
                Double AvailableFundBeforeTransfer = tc.GetAvailableFunds((Parameters.Ace_ProgramName()));

                bi.WaitTime(10);
                bi.WaitVisible(LeftNavTransaction);
                bi.Click(LeftNavTransaction);
                bi.WaitVisible(TranAdjustment);
                bi.Click(TranAdjustment);

                bi.WaitTime(20);
                bi.WaitVisible(ProgramNameDropdown);
                bi.Click(ProgramNameDropdown);
                bi.WaitVisible(ProgramNameText);
                bi.Clear(ProgramNameText);
                if (accrualType.Equals("Flat"))
                {
                    bi.Type(ProgramNameText,Parameters.Ace_ProgramName());
                }
                else if (accrualType.Equals("Rolling"))
                {
                    bi.Type(ProgramNameText,Parameters.Ace_ProgramName_Rolling);
                }
                bi.WaitVisible(ProgramNameTextOption);
                bi.Click(ProgramNameTextOption);
                bi.WaitTime(20);

                bi.WaitUntilElementClickable(LMEDropdown,60);
                bi.Click(LMEDropdown);
                bi.WaitVisible(LMEText);
                bi.Clear(LMEText);
                bi.Type(LMEText,(Parameters.Ace_Test_LME_00020()));
                bi.WaitVisible(LMETextOption);
                bi.Click(LMETextOption);
                bi.WaitTime(10);

                bi.WaitVisible(PeriodDropdown);
                bi.Click(PeriodDropdown);
                bi.WaitVisible(PeriodText);
                bi.Clear(PeriodText);
                bi.WaitVisible(PeriodTextOption);
                bi.Click(PeriodTextOption);
                bi.WaitTime(10);

                bi.WaitVisible(AdjustAmount);
                bi.Type(AdjustAmount,amount);

                bi.WaitVisible(AccrualComments);
                bi.Type(AccrualComments,"Adjustment");

                bi.WaitVisible(ButtonPreview);
                bi.Click(ButtonPreview);


                bi.WaitVisible(SubmitButton);
                bi.Click(SubmitButton);
                Console.WriteLine(amount + " ADJUSTMENT for Program: " + Parameters.Ace_ProgramName() + " & Store: " + Parameters.Ace_Test_LME_00020());

                bi.WaitTime(10);
                bi.WaitVisible(BackToTansactions);
                bi.Click(BackToTansactions);

                bi.WaitVisible(Dashboard);
                bi.Click(Dashboard);

                Double AvailableFundAftertransfer = tc.GetAvailableFunds((Parameters.Ace_ProgramName()));

                Assert.True(Convert.ToDouble(AvailableFundAftertransfer) == (Convert.ToDouble(AvailableFundBeforeTransfer) + Convert.ToDouble(amount.Replace("$", ""))));
                Console.WriteLine("Adjustment Amount Added to Available Funds Correctly");
                //bi.WaitTime(10);
                //bi.WaitVisible(FundDetailsLink);
                //bi.Click(FundDetailsLink);
                //bi.WaitVisible(AdjustedTab);
                //bi.Click(AdjustedTab);
                //bi.WaitVisible(AdjustedStore);
                ////var amountCheck = new Regex("^[()]+$");
                //if (bi.GetText(AdjustedAmount).Contains("(") || bi.IsElementDisplayed(AdjustedAmount))
                //{
                //    Console.WriteLine("Entry present under ADJUSTED tab");
                //}
                //else
                //{
                //    Console.WriteLine("Entry NOT present under Adjusted tab");
                //}
            }
            catch(Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("Transaction_AllocateAdjustment: "+ex);
                Assert.Fail("Transaction_AllocateAdjustment: " + ex);
            }
        }


        //verifying Accrual Entry under Detailed Report
        public void VerifyingAdjustmentEntryUnderDetailedReport(string accrualType = "Flat")
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Transaction_Accrual));
            try
            {
                string ProgramName = null;
                if (accrualType.Equals("Flat"))
                {
                    ProgramName = Parameters.Ace_ProgramName();
                    //bi.Type(ProgramNameText, Parameters.Ace_ProgramName());
                }
                else
                {
                    ProgramName = Parameters.Ace_ProgramName_Rolling;
                    //bi.Type(ProgramNameText, Parameters.Ace_ProgramName_Rolling);
                }

                bi.WaitTillNotVisible(imgLoading);
                bi.WaitTillNotVisible(LoadingImageSnapShot);
                bi.WaitTime(5);
                if (bi.IsElementDisplayed(ProgramList(ProgramName)))
                {
                    //bi.WaitTime(5);
                    bi.Click(ProgramList(ProgramName));

                }
                else
                {
                    //bi.WaitTime(5);
                    bi.WaitVisible(OtherProgramsLink);
                    bi.Click(OtherProgramsLink);
                    bi.WaitTime(5);
                    bi.Click(ProgramList(ProgramName));
                }
                bi.WaitTillNotVisible(LoadingImageSnapShot);
                bi.WaitTime(5);
                bi.WaitVisible(ViewDetailedReport);
                bi.ClickJavaScript(ViewDetailedReport);
                bi.WaitTillNotVisible(imgLoading);

                bi.WaitVisible(AdjustedTab);
                bi.Click(AdjustedTab);
                bi.WaitTillNotVisible(LoadingImageSnapShot);
                bi.WaitTime(5);
                if (!bi.GetElement(LMEdropdownDetailedReport).GetAttribute("class").Contains("disable"))
                {
                    bi.Click(LMEdropdownDetailedReport);
                    bi.WaitTime(2);
                    bi.TypeClear(LMESearchTxtDetailedReport, Parameters.Ace_Test_LME1);
                    bi.Type(LMESearchTxtDetailedReport, Keys.Down);
                    bi.Type(LMESearchTxtDetailedReport, Keys.Enter);
                }
                bi.WaitVisible(SubmittedStartdate);
                bi.Click(SubmittedStartdate);
                bi.WaitTime(2);
                DateSelection dsTran = new DateSelection();
                bi.ClickJavaScript(currentdate);

                bi.WaitTime(5);
                bi.WaitVisible(SubmittedEndDate);
                bi.Click(SubmittedEndDate);
                bi.WaitTime(2);
                DateSelection dsExp = new DateSelection();
                bi.ClickJavaScript(currentdate);
                bi.WaitTime(3);

                bi.Click(ApplyFilter);
                bi.WaitTime(10);
                Regex regex = new Regex("[^0-9.]");
                //Assert.True(bi.GetText(FirstrowAdjustedAmount).Contains("("));
                //Console.WriteLine("Application showing The Specified amount is deducted from the Source LME");
                Assert.AreEqual(Convert.ToDouble(regex.Replace(bi.GetText(FirstrowAdjustedAmount), "")), Convert.ToDouble(regex.Replace(Parameters.Ace_AccrualPositive_Amount, "")));
                //Checking the First row Amount
                Console.WriteLine("Accrual Amount Entry showing under Fund Snapshot");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
            }
        }

    }
}