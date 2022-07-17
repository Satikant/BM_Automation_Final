using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.StartUp;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard
{
    public class Common_Dashboard_Landing
    {
        private IWebDriver Driver { get; set; }
        public Common_Dashboard_Landing(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }
        public By LeftNavDashboard { get { return (By.Id("dashboard")); } }
        public By DashboardHeader { get { return (By.XPath("//h1[contains(.,'Dashboard')]")); } }
        public By SubmitBPA { get { return (By.XPath("//button[contains(.,'Submit Brand Pre-Approval')]")); } }
        public By BrandPreApproval { get { return (By.XPath("//span(.,'BRAND PRE-APPROVALS')")); } }
        public By BPALanding { get { return (By.XPath("//h1[contains(.,'Submit a Brand Pre-Approval')]")); } }
        public By SubmitClaim { get { return (By.XPath("//*[contains(text(),'Submit Claim')]")); } }
        public By Submit { get { return (By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Submit'])[1]/span[1]")); } }
        public By ClaimLanding { get { return (By.XPath("//h1[contains(.,'Create a Claim')]")); } }
        public By SubmitDisbursement { get { return (By.XPath("//button[contains(.,'Create Disbursement')]")); } }
        public By DisbursementLanding { get { return (By.XPath("//h4[contains(.,'New Disbursement')]")); } }
        public By ActivityOverviewSection { get { return (By.XPath("//div[contains(@class,'db-panel-header') and contains(.,'Activity Overview')]")); } }
        public By BPADashboardTotal { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[1]")); } }
        public By BPADashboardOpen { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[2]")); } }
        public By BPADashboardProcessed { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[3]")); } }
        public By ClaimsDashboardTotal { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[4]")); } }
        public By ClaimsDashboardOpen { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[5]")); } }
        public By ClaimsDashboardProcessed { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[6]")); } }

        public By ClaimsDashboardTotal_Pandora { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[1]")); } }
        public By ClaimsDashboardOpen_Pandora { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[2]")); } }
        public By ClaimsDashboardProcessed_Pandora { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[3]")); } }
        public By FundSnapshotSection { get { return (By.XPath("//div[contains(@class,'db-panel-header') and contains(.,'Fund Snapshot')]")); } }
        public By FundSnapshotAccrued { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Accrued')]")); } }
        public By FundSnapshotAdjusted { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Adjusted')]")); } }
        public By FundSnapshotTransferred { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Transferred')]")); } }
        public By FundSnapshotOpenClaims { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Open Claims')]")); } }
        public By FundSnapshotApprovedClaims { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Open Claims')]")); } }
        public By FundSnapshotPaidClaims { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Paid Claims')]")); } }
        public By FundSnapshotExpired { get { return (By.XPath("//div[contains(@class,'legend-text') and contains(.,'Expired')]")); } }
        public By RecentActivitySection { get { return (By.XPath("//div[contains(@class,'db-panel-header') and contains(.,'Recent Activity')]")); } }
        public By RecentActivityBPA { get { return (By.XPath("//li[contains(@class,'ng-star-inserted') and contains(.,'Brand Pre-Approvals')]")); } }
        public By RecentActivityClaims { get { return (By.XPath("//li[contains(@class,'ng-star-inserted') and contains(.,'Claims')]")); } }
        public By RecentActivityDisbursement { get { return (By.XPath("//li[contains(@class,'ng-star-inserted') and contains(.,'Disbursements')]")); } }
        public By QuickLinkSection { get { return (By.XPath("(//div[contains(.,'QUICK LINKS')])[7]")); } }
        public By ProgramGuidelinesLink { get { return (By.PartialLinkText("Program Guidelines")); } }
        public By ClaimUserGuideLink { get { return (By.PartialLinkText("Claim User Guide")); } }
        public By imgLoading { get { return By.Id("loading-image"); } }
        public static IList<IWebElement> LeftNavMenuOptions;
        public int LeftNavMenuOptionsCount = 0;

        /// <summary>
        /// Function to capture all the left menu options 
        /// </summary>
        /// <returns>List of </returns>
        public void FuncLeftNavMenu()
        {
            Base b = new Base();
            //b.OpenBrowser()();
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Dashboard_Landing));
            BrowserURLLaunch b1 = new BrowserURLLaunch(Driver);
            LeftNavMenuOptions = Driver.FindElements(By.XPath("//ul[contains(@id,'cfmMenu')]//a//span"));
            Console.WriteLine("Count of Left Menu Options: " + LeftNavMenuOptions.Count);
            foreach (IWebElement element in LeftNavMenuOptions)
            {
                Console.WriteLine("Menu Options: " + element.Text);
            }
        }

        /// <summary>
        /// test case to check Dashboard validation for Corporate & LME
        /// </summary>
        public void Dashboard_Landing_User()
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Dashboard_Landing));
            try
            {
                bi.WaitTime(5);
                bi.WaitVisible(SubmitBPA);
                bi.Click(SubmitBPA);
                bi.WaitVisible(BPALanding);
                if (bi.IsElementDisplayed(BPALanding))
                {
                    Console.WriteLine("BPA link present in Dashboard");
                }
                else
                {
                    Console.WriteLine("BPA link NOT present in Dashboard");
                }

                bi.WaitTime(5);
                bi.Click(LeftNavDashboard);
                bi.WaitVisible(SubmitClaim);
                bi.Click(SubmitClaim);
                bi.WaitVisible(ClaimLanding);
                if (bi.IsElementPresent(ClaimLanding))
                {
                    Console.WriteLine("Claim link present in Dashboard");
                }
                else
                {
                    Console.WriteLine("Claim link NOT present in Dashboard");
                }
                bi.WaitVisible(LeftNavDashboard);
                bi.Click(LeftNavDashboard);

                bi.WaitVisible(SubmitClaim);
                //SubmitDisbursement.Click();
                //Wait.WaitVisible(DisbursementLanding);
                if (bi.IsElementPresent(SubmitDisbursement))
                {
                    Console.WriteLine("Disbursement link present in Dashboard");
                }
                else
                {
                    Console.WriteLine("Disbursement link NOT present in Dashboard");
                }
                bi.Click(LeftNavDashboard);
                //Console.WriteLine("Disbursement link present in Dashboard");

                FuncLeftNavMenu();

                //Activity Overview section validation
                bi.WaitTime(10);
                bi.WaitVisible(ActivityOverviewSection);
                if (bi.GetText(ActivityOverviewSection).Equals("Activity Overview"))
                {
                    Console.WriteLine("Activity Overview section is present");
                    //BPA total check
                    bi.WaitVisible(BPADashboardTotal);
                    //BPADashboardOpen
                    //BPADashboardProcessed
                    if (Convert.ToInt32(bi.GetText(BPADashboardTotal)) == Convert.ToInt32(bi.GetText(BPADashboardOpen)) + Convert.ToInt32(bi.GetText(BPADashboardProcessed)))
                    {
                        Console.WriteLine("Total number(" + Convert.ToInt32(bi.GetText(BPADashboardTotal)) + "=" + (Convert.ToInt32(bi.GetText(BPADashboardOpen)) + "+" +
                           Convert.ToInt32(bi.GetText(BPADashboardProcessed)) + ") of BPA is correct in Dashboard"));
                    }
                    else
                    {
                        Console.WriteLine("Total number(" + Convert.ToInt32(bi.GetText(BPADashboardTotal)) + "=" + (Convert.ToInt32(bi.GetText(BPADashboardOpen)) + "+" +
                           Convert.ToInt32(bi.GetText(BPADashboardProcessed)) + ") of BPA is NOT correct in Dashboard"));
                    }
                    //Claim total check
                    bi.WaitVisible(ClaimsDashboardTotal);
                    if (Convert.ToInt32(bi.GetText(ClaimsDashboardTotal)) == (Convert.ToInt32(bi.GetText(ClaimsDashboardOpen)) + Convert.ToInt32(bi.GetText(ClaimsDashboardProcessed))))
                    {
                        Console.WriteLine("Total number(" + Convert.ToInt32(bi.GetText(ClaimsDashboardTotal)) + "=" + (Convert.ToInt32(bi.GetText(ClaimsDashboardOpen)) + "+" +
                           Convert.ToInt32(bi.GetText(ClaimsDashboardProcessed)) + ") of Claim is correct in Dashboard"));
                    }
                    else
                    {
                        Console.WriteLine("Total number(" + Convert.ToInt32(bi.GetText(ClaimsDashboardTotal)) + "=" + (Convert.ToInt32(bi.GetText(ClaimsDashboardOpen)) + "+" +
                           Convert.ToInt32(bi.GetText(ClaimsDashboardProcessed)) + ") of Claim is NOT correct in Dashboard"));
                    }
                }
                else
                {
                    Console.WriteLine("Activity Overview section is NOT present");
                }


                //Fund Snapshot validation
                bi.WaitTime(15);
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

                //Recent Activity section validation
                bi.WaitTime(10);
                bi.WaitVisible(RecentActivitySection);
                if (bi.IsElementPresent(RecentActivitySection))
                {
                    Console.WriteLine("Recent Acticity section is present");

                    if (bi.IsElementPresent(RecentActivityBPA) && bi.IsElementPresent(RecentActivityClaims) && bi.IsElementPresent(RecentActivityDisbursement))
                    {
                        Console.WriteLine("BPA, Claims & Disbursements tabs are present under Recent Activity section");
                    }
                    else if (bi.IsElementPresent(RecentActivityBPA) && bi.IsElementPresent(RecentActivityClaims))
                    {
                        Console.WriteLine("BPA & Claims tabs are present under Recent Activity section");
                    }
                    else
                    {
                        Console.WriteLine("BPA, Claims & Disbursements tabs are NOT present under Recent Activity section");
                    }
                }
                else
                {
                    Console.WriteLine("Recent Acticity section is NOT present");
                }

                //Quick Links
                bi.WaitTime(10);
                bi.WaitVisible(QuickLinkSection);
                if (bi.IsElementPresent(QuickLinkSection))
                {
                    Console.WriteLine("Quick Link section is present");
                    if (bi.IsElementPresent(ProgramGuidelinesLink) && bi.IsElementPresent(ClaimUserGuideLink))
                    {
                        Console.WriteLine("Program Guidelines & Claim User Guide links are present under Quick Links section");
                    }
                    else
                    {
                        Console.WriteLine("Program Guidelines & Claim User Guide links are NOT present under Quick Links section");
                    }
                }
                else
                {
                    Console.WriteLine("Quick Link section is NOT present");
                }
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Dashboard_Landing_User failed due to: " + ex);
                Console.WriteLine("Dashboard_Landing_User failed due to: " + ex);
                Assert.Fail("Dashboard_Landing_User failed due to: " + ex);
            }
        }
        /// <summary>
        /// test case to check Dashboard validation for Corporate & LME
        /// </summary>
        public void Dashboard_Common(String BUSINESSUNIT)
        {
            BasicInteractions bi = new BasicInteractions(Driver);

            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Dashboard_Landing));
            try
            {   
                bi.WaitTime(5);
                bi.WaitVisible(Submit);
                bi.Click(Submit);
                if (bi.IsElementVisible(SubmitBPA))
                {
                    if(BUSINESSUNIT.Equals("Pandora"))
                    {
                        Assert.Fail("SubmitBrandPreApproval page is displaying in " + BUSINESSUNIT +"Dashboard page");
                    }
                    else
                    {
                        bi.Click(SubmitBPA);
                        bi.WaitVisible(BPALanding);
                        if (bi.IsElementVisible(BPALanding))
                        {
                            Console.WriteLine("BPA link present in Dashboard");
                        }
                        else
                        {
                            Console.WriteLine("BPA link NOT present in Dashboard");
                        }
                    }
                    
                }
                //bi.WaitVisible(SubmitBPA);
                
                bi.WaitTime(10);
                //bi.Click(LeftNavDashboard);
                //bi.WaitVisible(Submit);

                //bi.Click(Submit);
                bi.WaitVisible(SubmitClaim);

                bi.Click(SubmitClaim);
                bi.WaitTime(10);
                bi.WaitTillNotVisible(imgLoading);
                bi.WaitVisible(ClaimLanding);
                if (bi.IsElementPresent(ClaimLanding))
                {
                    Console.WriteLine("Claim link present in Dashboard");
                }
                else
                {
                    Console.WriteLine("Claim link NOT present in Dashboard");
                }
                bi.WaitVisible(LeftNavDashboard);
                bi.Click(LeftNavDashboard);

                bi.WaitVisible(Submit);
                //SubmitDisbursement.Click();
                //Wait.WaitVisible(DisbursementLanding);


                if (bi.IsElementVisible(SubmitDisbursement))
                {
                    if (BUSINESSUNIT.Equals("Pandora"))
                    {
                        Assert.Fail("Create Disbursement button is displaying in " + BUSINESSUNIT + "Dashboard page");
                    }
                    else
                    {
                        Console.WriteLine("Disbursement link present in Dashboard");
                    }

                }
                else
                {
                    Console.WriteLine("Disbursement link NOT present in Dashboard");
                }
                bi.Click(LeftNavDashboard);
                //Console.WriteLine("Disbursement link present in Dashboard");

                FuncLeftNavMenu();

                //Activity Overview section validation
                bi.WaitTime(10);
                bi.WaitVisible(ActivityOverviewSection);
                if (bi.GetText(ActivityOverviewSection).Equals("Activity Overview"))
                {
                    Console.WriteLine("Activity Overview section is present");
                    //BPA total check
                    if (bi.IsElementVisible(BPADashboardTotal))
                    {
                        if (BUSINESSUNIT.Equals("Pandora"))
                        {
                            Assert.False(bi.IsElementPresent(BrandPreApproval));
                            Console.WriteLine("SubmitBrandPreApproval page is displaying in " + BUSINESSUNIT + "Dashboard page");
                        }
                        else
                        {
                            if (Convert.ToInt32(bi.GetText(BPADashboardTotal)) == Convert.ToInt32(bi.GetText(BPADashboardOpen)) + Convert.ToInt32(bi.GetText(BPADashboardProcessed)))
                            {
                                Console.WriteLine("Total number(" + Convert.ToInt32(bi.GetText(BPADashboardTotal)) + "=" + (Convert.ToInt32(bi.GetText(BPADashboardOpen)) + "+" +
                                   Convert.ToInt32(bi.GetText(BPADashboardProcessed)) + ") of BPA is correct in Dashboard"));
                            }
                            else
                            {
                                Console.WriteLine("Total number(" + Convert.ToInt32(bi.GetText(BPADashboardTotal)) + "=" + (Convert.ToInt32(bi.GetText(BPADashboardOpen)) + "+" +
                                   Convert.ToInt32(bi.GetText(BPADashboardProcessed)) + ") of BPA is NOT correct in Dashboard"));
                            }

                        }
                        

                    }
                        
                    //bi.WaitVisible(BPADashboardTotal);
                    //BPADashboardOpen
                    //BPADashboardProcessed
                    
                    //Claim total check
                    bi.WaitVisible(ClaimsDashboardTotal_Pandora);
                    if (Convert.ToInt32(bi.GetText(ClaimsDashboardTotal_Pandora)) == (Convert.ToInt32(bi.GetText(ClaimsDashboardOpen_Pandora)) + Convert.ToInt32(bi.GetText(ClaimsDashboardProcessed_Pandora))))
                    {
                        Console.WriteLine("Total number(" + Convert.ToInt32(bi.GetText(ClaimsDashboardTotal_Pandora)) + "=" + (Convert.ToInt32(bi.GetText(ClaimsDashboardOpen_Pandora)) + "+" +
                           Convert.ToInt32(bi.GetText(ClaimsDashboardProcessed_Pandora)) + ") of Claim is correct in Dashboard"));
                    }
                    else
                    {
                        Console.WriteLine("Total number(" + Convert.ToInt32(bi.GetText(ClaimsDashboardTotal_Pandora)) + "=" + (Convert.ToInt32(bi.GetText(ClaimsDashboardOpen_Pandora)) + "+" +
                           Convert.ToInt32(bi.GetText(ClaimsDashboardProcessed_Pandora)) + ") of Claim is NOT correct in Dashboard"));
                    }
                }
                else
                {
                    Console.WriteLine("Activity Overview section is NOT present");
                }


                //Fund Snapshot validation
                bi.WaitTime(15);
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

                //Recent Activity section validation
                bi.WaitTime(10);
                bi.WaitVisible(RecentActivitySection);
                if (bi.IsElementPresent(RecentActivitySection))
                {
                    Console.WriteLine("Recent Acticity section is present");

                    if (bi.IsElementPresent(RecentActivityBPA) && bi.IsElementPresent(RecentActivityClaims) && bi.IsElementPresent(RecentActivityDisbursement))
                    {
                        Console.WriteLine("BPA, Claims & Disbursements tabs are present under Recent Activity section");
                    }
                    else if (bi.IsElementPresent(RecentActivityBPA) && bi.IsElementPresent(RecentActivityClaims))
                    {
                        Console.WriteLine("BPA & Claims tabs are present under Recent Activity section");
                    }
                    else
                    {
                        Console.WriteLine("BPA, Claims & Disbursements tabs are NOT present under Recent Activity section");
                    }
                }
                else
                {
                    Console.WriteLine("Recent Acticity section is NOT present");
                }

                //Quick Links
                bi.WaitTime(10);
                bi.WaitVisible(QuickLinkSection);
                if (bi.IsElementPresent(QuickLinkSection))
                {
                    Console.WriteLine("Quick Link section is present");
                    if (bi.IsElementPresent(ProgramGuidelinesLink) && bi.IsElementPresent(ClaimUserGuideLink))
                    {
                        Console.WriteLine("Program Guidelines & Claim User Guide links are present under Quick Links section");
                    }
                    else
                    {
                        Console.WriteLine("Program Guidelines & Claim User Guide links are NOT present under Quick Links section");
                    }
                }
                else
                {
                    Console.WriteLine("Quick Link section is NOT present");
                }
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Dashboard_Landing_User failed due to: " + ex);
                Console.WriteLine("Dashboard_Landing_User failed due to: " + ex);
                Assert.Fail("Dashboard_Landing_User failed due to: " + ex);
            }
        }



    }
}
