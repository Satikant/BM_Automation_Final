using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace CFMAutomation.PageObject.UI.Ace.Transactions
{

    public class Transaction_Negative
    {
        private IWebDriver Driver { get; set; }
        public Transaction_Negative(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }
        public By Dashboard { get { return (By.Id("dashboard")); } }
        public By LeftNavTransaction { get { return (By.Id("allAccruals")); } }
        public By LeftNavDashboard { get { return (By.PartialLinkText("dashboard")); } }
        public By FundSnapshotSection { get { return (By.XPath("//div[contains(@class,'db-panel-header') and contains(.,'Fund Snapshot')]")); } }
        public By FundSnapshotAccrued { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Accrued')]")); } }
        public By FundSnapshotAdjusted { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Adjusted')]")); } }
        public By FundSnapshotTransferred { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Transferred')]")); } }
        public By FundSnapshotOpenClaims { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Open Claims')]")); } }
        public By FundSnapshotApprovedClaims { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Open Claims')]")); } }
        public By FundSnapshotPaidClaims { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Paid Claims')]")); } }
        public By FundSnapshotExpired { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Expired')]")); } }
        public By ProgramList(string prgname) { return (By.XPath("//ul[contains(@class,'nav nav-tabs')]//li//a[contains(.,'" + prgname + "')]")); }
        public By OtherProgramsLink { get { return (By.PartialLinkText("Other Programs")); } }
        public By FundDetailsLink { get { return (By.PartialLinkText("View Detailed Report")); } }
        public By AccrualTab { get { return (By.XPath("//li[contains(@class,'mat-ripple') and contains(.,'Accrued')]")); } }
        public By AdjustedTab { get { return (By.XPath("//li[contains(@class,'mat-ripple') and contains(.,'Adjusted')]")); } }
        public By TransferredTab { get { return (By.XPath("//li[contains(@class,'mat-ripple') and contains(.,'Transferred')]")); } }
        public By OpenTab { get { return (By.XPath("(//li[contains(@class,'mat-ripple') and contains(.,'Open')])[2]")); } }
        public By OpenTabAce { get { return (By.XPath("(//li[contains(@class,'mat-ripple') and contains(.,'Open')])[1]")); } }

        public By ApprovedTab { get { return (By.XPath("//li[contains(@class,'mat-ripple') and contains(.,'Approved')]")); } }
        public By PaidTab { get { return (By.XPath("//li[contains(@class,'mat-ripple') and contains(.,'Paid')]")); } }
        public By ExpiredTab { get { return (By.XPath("//li[contains(@class,'mat-ripple') and contains(.,'Expired')]")); } }
        public By imgLoading { get { return By.Id("loading-image"); } }
        public By imgLoadingSnapshot { get { return By.XPath("//img[@src='assets/images/Ellipsis.gif']"); } }

        /// <summary>
        /// 
        /// </summary>
        public void Transaction_NegativeScenario_FundSnapshot()
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Transaction_Negative));
            try
            {

                //Fund Snapshot validation
                bi.WaitTillNotVisible(imgLoading);
                bi.WaitTillNotVisible(imgLoadingSnapshot);
                bi.WaitTime(5);
                
                //bi.WaitVisible(FundSnapshotAccrued);
                if (bi.IsElementPresent(FundSnapshotSection))
                {
                    Console.WriteLine("Fund Snapshot Section is present");
                    if (bi.IsElementPresent(FundSnapshotAccrued) && bi.IsElementPresent(FundSnapshotAdjusted) && bi.IsElementPresent(FundSnapshotTransferred) && bi.IsElementPresent(FundSnapshotOpenClaims) &&
                    bi.IsElementPresent(FundSnapshotApprovedClaims) && bi.IsElementPresent(FundSnapshotPaidClaims) && bi.IsElementPresent(FundSnapshotExpired))
                    {
                        Console.WriteLine("Accrued, Adjusted, Transferred, Open Claims, Approved Claims, Paid Claims, Expired labels are present");
                    }
                    else
                    {
                        Console.WriteLine("Accrued, Adjusted, Transferred, Open Claims, Approved Claims, Paid Claims, Expired labels are NOT present");

                    }
                }
                else
                {
                    Console.WriteLine("Fund Snapshot Section is NOT present");
                }

                if (bi.IsElementDisplayed(ProgramList(Parameters.Ace_ProgramName())))
                {
                    bi.Click(ProgramList(Parameters.Ace_ProgramName()));
                    Console.WriteLine("Program displayed among first four");
                }
                else
                {
                    bi.WaitVisible(OtherProgramsLink);
                    bi.Click(OtherProgramsLink);
                    bi.WaitTime(2);
                    bi.Click(ProgramList(Parameters.Ace_ProgramName()));
                    Console.WriteLine("Program displayed under dropdown");
                }
                bi.WaitTillNotVisible(imgLoadingSnapshot);
                bi.WaitTime(5);
                bi.WaitVisible(FundDetailsLink);
                bi.Click(FundDetailsLink);
                bi.WaitTillNotVisible(imgLoadingSnapshot);
                bi.WaitVisible(AccrualTab);
                bi.ClickJavaScript(AccrualTab);
                bi.WaitTime(1);
                bi.ClickJavaScript(AdjustedTab);
                bi.WaitTime(1);
                bi.ClickJavaScript(TransferredTab);
                bi.WaitTime(1);
                bi.ClickJavaScript(OpenTabAce);
                bi.WaitTime(1);
                bi.ClickJavaScript(ApprovedTab);
                bi.WaitTime(1);
                bi.ClickJavaScript(PaidTab);
                bi.WaitTime(1);
                bi.ClickJavaScript(ExpiredTab);
                bi.WaitTime(1);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Transaction_NegativeScenario_FundSnapshot " + ex);
                Assert.Fail("Transaction_NegativeScenario_FundSnapshot " + ex);
            }
        }

        public void Transaction_NegativeScenario_LeftNavValidation()
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Transaction_Negative));
            try
            {
                if (bi.IsElementPresent(LeftNavTransaction))
                {
                    Console.WriteLine("Transaction on left navigation pane is present");
                }
                else
                {
                    Console.WriteLine("Transaction on left navigation pane is not present");
                    Console.WriteLine("User cannot perform Accrual, Adjustment & Transfer");
                }

            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit(); 
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("Transaction_NegativeScenario_LeftNavValidation " + ex);
                Assert.Fail("Transaction_NegativeScenario_LeftNavValidation " + ex);
            }
        }
    }
}