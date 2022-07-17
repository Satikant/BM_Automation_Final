using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Disbursements;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Program_Management;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Transactions;
using CFM_PARALLEL.StartUp;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace CFM_PARALLEL.PageObject.UI.Ace.Dashboard
{
    public class Dashboard_Landing
    {
        private OBJ_Common oBJ_Common;
        private OBJ_Claims obj_Claims;
        private OBJ_Dashboard oBJ_Dashboard;
        private OBJ_Transactions obj_transaction ;
        private OBJ_Disbursement obj_Disbursement;
        private OBJ_Program oBJ_Program;

        public Dashboard_Landing()
        {
             oBJ_Common = new OBJ_Common();
             obj_Claims = new OBJ_Claims();
             oBJ_Dashboard = new OBJ_Dashboard();
             obj_transaction = new OBJ_Transactions();
             oBJ_Program = new OBJ_Program();
            obj_Disbursement = new OBJ_Disbursement();
        }

        public By LeftNavDashboard { get { return (By.XPath("//a[@id='dashboard']/parent::li")); } }

        public By DashboardHeader { get { return (By.XPath("//h1[contains(.,'Dashboard')]")); } }
        public By DashboardSubmit { get { return (By.XPath("//span[contains(text(),'Submit')]")); } }
        public By DashboardSubmitdropdown { get { return (By.XPath("//ul[@class='dropdown-menu pull-right']")); } }
        public By DbSubmitBPA { get { return (By.XPath("//a[contains(text(),'Submit Brand Pre-Approval')]")); } }
        public By DbSubmitClaim { get { return (By.XPath("//a[contains(text(),'Submit Claim')]")); } }
        public By DbCreateDisbursement { get { return (By.XPath("//a[contains(text(),'Create Disbursement')]")); } }
        public By SubmitBPA { get { return (By.XPath("//button[contains(.,'Submit Brand Pre-Approval')]")); } }
        public By SubmitClaim { get { return (By.XPath("//button[contains(.,'Submit Claim')]")); } }
        public By BrandPreApproval { get { return (By.XPath("//span(.,'BRAND PRE-APPROVALS')")); } }
        public By BPALanding { get { return (By.XPath("//h1[contains(text(),'Submit a Brand Pre-Approval')]")); } }
        public By ClaimLanding { get { return (By.XPath("//h1[contains(.,'Create a Claim')]")); } }
        public By SubmitDisbursement { get { return (By.XPath("//div//a[contains(.,'Create Disbursement')]")); } }
        public By SubmitDisbursement1 { get { return (By.XPath("//button[contains(.,'Create Disbursement')]")); } }
        public By DisbursementLanding { get { return (By.XPath("//h4[contains(.,'New Disbursement')]")); } }
        public By ActivityOverviewSection { get { return (By.XPath("//div[contains(@class,'db-panel-header') and contains(.,'Activity Overview')]")); } }
        public By BPADashboardTotal { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[1]")); } }
        public By BPADashboardOpen { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[2]")); } }
        public By BPADashboardProcessed { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[3]")); } }
        public By ClaimsDashboardTotal { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[4]")); } }
        public By ClaimsDashboardOpen { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[5]")); } }
        public By ClaimsDashboardProcessed { get { return (By.XPath("(//div[contains(@class,'overview-second-row')]//a)[6]")); } }
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
        public By Submit { get { return By.XPath("//button[contains(@class,'dropdown-toggle') and contains(@aria-expanded,true)]"); } }
        public By LeftNavPreapprovals { get { return (By.XPath("//a[@id='brandingList']/parent::li")); } }
        public By LeftNavClaim { get { return (By.XPath("//a[@id='ManageClaim']/parent::li")); } }
        public By LeftNavDisbursement { get { return (By.XPath("//a[@id='disbursementList']/parent::li")); } }
        public By LeftNavProgram { get { return (By.XPath("//a[@id='prgProgramSnapshot']/parent::li")); } }
        public By Leftsidesections(String sectionName) {   return (By.XPath("//ul[@id='cfmMenu']//span[contains(text(),'"+sectionName+"')]/ancestor::li"));  }
        public By Divall { get { return (By.XPath("//div | //a | //span")); } }
        public By Fundsnapshotvalues { get { return (By.XPath("//a[@data-toggle='tab']")); } }
        public By Pageh1tags { get { return (By.XPath("//div//h1")); } }
        public By LnkNewProgram { get { return By.XPath("//span[contains(text(),'New Program')]"); } }
       public By Pageheadsectionvalues { get { return (By.XPath("//ul[contains(@class,'nav-tabs')]//li")); } }
        public By Pagelabelvalues { get { return (By.XPath("//div//label")); } }
        public By Pagebuttons { get { return (By.XPath("//div//button[@type='button'] | //div//button")); } }
        public By PendingStatusTabs { get { return (By.XPath("//li[@id='Pending']")); } }
        public By InProcessStatusTabs { get { return (By.XPath("//li[@id='InProcess']")); } }
        public By CompletedStatusTabs { get { return (By.XPath("//li[@id='Completed']")); } }
        public By DeclinedStatusTabs { get { return (By.XPath("//li[@id='Declined']")); } }
        public By ImgLoading { get { return By.Id("loading-image"); } }
        public By LeftNavMenuOption { get { return By.XPath("//ul[contains(@id,'cfmMenu')]//a//span"); } }


        public static IList<IWebElement> LeftNavMenuOptions;
        public int LeftNavMenuOptionsCount = 0;

        

        //Validate & Click Sections of - Left Hand Side Section
        //public void ClickParticularValueSection(string name)
        //{
        //    try
        //    {
        //        Pages.BasicInteractions().WaitForPageToLoad(5);
        //        Pages.BasicInteractions().WaitTime(10);
        //        int count = 1;
        //        IList<IWebElement> listofpagesections = Pages.BasicInteractions().getElements(leftsidesections);
        //        int c = listofpagesections.Count;
        //        for (int i = 0; i < listofpagesections.Count; i++)
        //        {
        //            string panel = ((listofpagesections)[i]).Text;
        //            if (panel.ToUpper() == name.ToUpper())
        //            {
        //                ((listofpagesections)[i]).Click();
        //                Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
        //                Console.WriteLine(name + "  --> Values Clicked");
        //                break;
        //            }
        //            count++;
        //            }
        //        if (count > c)
        //        {
        //            throw new Exception(" Loop Exceeded -" + name + " Values Not Present ");
        //        }

        //        Console.WriteLine(name + "  Validated Page Values - Flow Passed");
        //    }

        //    catch (Exception error)
        //    {
        //        Console.WriteLine(name + " - Not able to Click Section Values - Flow Failed - Due to - : " + error);
        //        throw error;
        //    }
        //}

        //Validate & Click Sections of - Left Hand Side Section
        public void ClickParticularValueSection(string SectionName)
        {
            try
            {
                Pages.BasicInteractions().Click(Leftsidesections(SectionName));
            }

            catch (Exception)
            {
                Console.WriteLine("Excetption in method ClickParticularValueSection for the section "+ SectionName);
                throw ;
            }
        }

        //Validate & Click Sections of - Left Hand Side Section
        public void ValidateParticularDivValueSection(string name)
        {
            try
            {
                Pages.BasicInteractions().WaitTime(3);
                int count = 1;
                IList<IWebElement> listofpagesections = Pages.BasicInteractions().GetElements(Divall);
                int c = listofpagesections.Count;
                for (int i = 0; i < listofpagesections.Count; i++)
                {
                    string panel = ((listofpagesections)[i]).Text;
                    string panel1 = panel.Trim();
                    if (panel1.ToUpper().Contains(name.ToUpper()))
                    {
                        Console.WriteLine(name + "--> Values Present");
                        break;
                    }
                    count++;
                }
                if (count > c)
                {
                    throw new Exception("Loop Exceeded -" + name + " Values Not Present");
                }

                Console.WriteLine(name + "Validated Page Values - Flow Passed");
            }

            catch (Exception error)
            {
                Console.WriteLine(name + " - Not able to Click Section Values - Flow Failed - Due to - : " + error);
                throw error;
            }
        }

        public void ClickParticularValues(string name)
        {
            
            try
            {
                Pages.BasicInteractions().WaitForPageToLoad(120);
                Pages.BasicInteractions().WaitTime(3);
                int count = 1;
                IList<IWebElement> listofpagesections = Pages.BasicInteractions().GetElements(Fundsnapshotvalues);
                int c = listofpagesections.Count;
                for (int i = 0; i < listofpagesections.Count; i++)
                {
                    string panel = ((listofpagesections)[i]).Text;
                    if (panel.ToUpper() == name.ToUpper())
                    {
                        ((listofpagesections)[i]).Click();
                        Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
                        Console.WriteLine(name + "--> Values Clicked");
                        break;
                    }
                    count++;
                }
                if (count > c)
                {
                    throw new Exception("Loop Exceeded -" + name + " Values Not Present");
                }

                Console.WriteLine(name + "Validated Page Values - Flow Passed");
            }

            catch (Exception error)
            {
                Console.WriteLine(name + " - Not able to Click Section Values - Flow Failed - Due to - : " + error);
                throw error;
            }
        }


        //Validate Sections of - Left Hand Side Section
        public void ClickParticularButton(string name)
        {
            
            try
            {
                Pages.BasicInteractions().WaitForPageToLoad();
                Pages.BasicInteractions().WaitTime(3);
                int count = 1;
                IList<IWebElement> listofpagesections = Pages.BasicInteractions().GetElements(Pagebuttons);
                int c = listofpagesections.Count;
                for (int i = 0; i < listofpagesections.Count; i++)
                {
                    string panel = ((listofpagesections)[i]).Text;
                    if (panel.ToUpper() == name.ToUpper())
                    {
                        ((listofpagesections)[i]).Click();
                        Console.WriteLine(name + "--> Values Clicked");
                        break;
                    }
                    count++;
                }
                if (count > c)
                {
                    throw new Exception("Loop Exceeded -" + name + " Button Not Present");
                }

                Console.WriteLine(name + " - Validated Page Values - Flow Passed");
            }

            catch (Exception error)
            {
                Console.WriteLine(name + " - Not able to Click Button - Flow Failed - Due to - : " + error);
                throw error;
            }
        }

        //Validate ParticularButton
        public void ValidateParticularButton(string name)
        {            
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
                Pages.BasicInteractions().WaitTime(3);
                int count = 1;
                IList<IWebElement> listofpagesections = Pages.BasicInteractions().GetElements(Pagebuttons);
                int c = listofpagesections.Count;
                for (int i = 0; i < listofpagesections.Count; i++)
                {
                    string panel = ((listofpagesections)[i]).Text;
                    if (panel.ToUpper().Contains(name.ToUpper()))
                    {
                        Console.WriteLine(name + "--> Button is Present");
                        break;
                    }
                    count++;
                }
                if (count > c)
                {
                    throw new Exception("Loop Exceeded -" + name + " Button Not Present");
                }

                Console.WriteLine(name + " - Validated Page Button Values - Flow Passed");
            }

            catch (Exception error)
            {
                Console.WriteLine(name + " - Not able to Validate Button - Flow Failed - Due to - : " + error);
                throw error;
            }
        }

        //Validate Page Section Values
        public void ValidatePageHeadSectionValues(string name)
        {            
            try
            {
                Pages.BasicInteractions().WaitForPageToLoad();
                Pages.BasicInteractions().WaitTime(3);
                int count = 1;
                IList<IWebElement> listofpagesections = Pages.BasicInteractions().GetElements(Pageheadsectionvalues);
                int c = listofpagesections.Count;
                for (int i = 0; i < listofpagesections.Count; i++)
                {
                    string panel = ((listofpagesections)[i]).GetAttribute("id");
                    if (panel.ToUpper().Contains(name.ToUpper()))
                    {
                        Console.WriteLine(name + " --> Values Present");
                        break;
                    }
                    count++;
                }
                if (count > c)
                {
                    throw new Exception("Loop Exceeded -" + name + " Values Not Present");
                }

                Console.WriteLine(name + " - Validated Page Values - Flow Passed");
            }

            catch (Exception error)
            {
                Console.WriteLine(name + " - Not able to Validate GIven Values - Flow Failed - Due to - : " + error);
                throw error;
            }
        }

        //Validate Page Label Values
        public void ValidatePageLabelValues(string name)
        {
            
            try
            {
                Pages.BasicInteractions().WaitForPageToLoad();
                Pages.BasicInteractions().WaitTime(3);
                int count = 1;
                IList<IWebElement> listofpagesections = Pages.BasicInteractions().GetElements(Pagelabelvalues);
                int countElements = listofpagesections.Count;
                for (int i = 0; i < countElements; i++)
                {
                    string panel = ((listofpagesections)[i]).Text;
                    if (panel.ToUpper() == name.ToUpper())
                    {
                        Console.WriteLine(name + " --> Value Present");
                        break;
                    }
                    count++;
                }
                if (count > countElements)
                {
                    throw new Exception("Loop Exceeded -" + name + " Value Not Present");
                }

                Console.WriteLine(name + " - Validated Page Value - Flow Passed");
            }

            catch (Exception error)
            {
                Console.WriteLine(name + " - Not able to Validate Given Value - Flow Failed - Due to - : " + error);
                throw error;
            }
        }

        //Validate Page Div Values
        public void ValidatePageDivValues(string name)
        {
            
            try
            {
                Pages.BasicInteractions().WaitForPageToLoad();
                Pages.BasicInteractions().WaitTime(3);
                int count = 1;
                IList<IWebElement> listofpagesections = Pages.BasicInteractions().GetElements(Pagelabelvalues);
                int countElements = listofpagesections.Count;
                for (int i = 0; i < countElements; i++)
                {
                    string panel = ((listofpagesections)[i]).Text;
                    if (panel.ToUpper() == name.ToUpper())
                    {
                        Console.WriteLine(name + " --> Value Present");
                        break;
                    }
                    count++;
                }
                if (count > countElements)
                {
                    throw new Exception("Loop Exceeded -" + name + " Value Not Present");
                }

                Console.WriteLine(name + " - Validated Page Value - Flow Passed");
            }

            catch (Exception error)
            {
                Console.WriteLine(name + " - Not able to Validate Given Value - Flow Failed - Due to - : " + error);
                throw error;
            }
        }

        //Validate Page Head Tag Values
        public void ValidatePageHeaderValues(string name)
        {
            
            try
            {
                Pages.BasicInteractions().WaitForPageToLoad();
                Pages.BasicInteractions().WaitTime(3);
                int count = 1;
                IList<IWebElement> listofpagesections = Pages.BasicInteractions().GetElements(Pageh1tags);
                int c = listofpagesections.Count;
                for (int i = 0; i < listofpagesections.Count; i++)
                {
                    string panel = ((listofpagesections)[i]).Text;
                    if (panel.ToUpper() == name.ToUpper())
                    {
                        Console.WriteLine(name + " --> Values Present");
                        break;
                    }
                    count++;
                }
                if (count > c)
                {
                    throw new Exception("Loop Exceeded -" + name + " Header Values Not Present");
                }

                Console.WriteLine(name + " - Validated Page Header Values - Flow Passed");
            }

            catch (Exception error)
            {
                Console.WriteLine(name + " - Not able to Validate Given Header Values - Flow Failed - Due to - : " + error);
                throw error;
            }
        }


        /// <summary>
        /// Function to capture all the left menu options 
        /// </summary>
        /// <returns>List of </returns>
        public void ValidateBrandPreApprovalSection()
        {
            try
            {                
                ClickParticularButton("SUBMIT BRAND PRE-APPROVAL");
                Pages.BasicInteractions().WaitTime(10);
                ValidatePageLabelValues("Brand Reference");
                ValidatePageLabelValues("Store");
                ValidatePageLabelValues("Activity Type");
                ValidatePageLabelValues("Start Date");
                ValidatePageLabelValues("End Date");
                ValidateParticularButton("NEXT");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void ValidateCreateDisbursementSection()
        {
            try
            {                
                ClickParticularButton("CREATE DISBURSEMENT");
                Pages.BasicInteractions().WaitTime(5);
                ValidatePageLabelValues("New Disbursement");
                ValidatePageLabelValues("Cancel");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }
                          
        /// Function to capture all the left menu options 
        /// </summary>
        /// <returns>List of </returns>
        public void FuncLeftNavMenu()
        {
            Base b = new Base();
            //b.OpenBrowser()();
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Dashboard_Landing));
            LeftNavMenuOptions = Pages.BasicInteractions().GetElements(LeftNavMenuOption); // changed implementation
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
            
            
            try
            {
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().Click(LeftNavPreapprovals);
                Pages.BasicInteractions().WaitVisible(SubmitBPA);
                Pages.BasicInteractions().Click(SubmitBPA);
                Pages.BasicInteractions().WaitVisible(BPALanding);
                if (Pages.BasicInteractions().IsElementDisplayed(BPALanding))
                {
                    Console.WriteLine("BPA link present in Dashboard");
                }
                else
                {
                    Console.WriteLine("BPA link NOT present in Dashboard");
                }

                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(LeftNavClaim);
                Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
                Pages.BasicInteractions().WaitVisible(SubmitClaim);
                Pages.BasicInteractions().Click(SubmitClaim);
                Pages.BasicInteractions().WaitVisible(ClaimLanding);
                if (Pages.BasicInteractions().IsElementPresent(ClaimLanding))
                {
                    Console.WriteLine("Claim link present in Dashboard");
                }
                else
                {
                    Console.WriteLine("Claim link NOT present in Dashboard");
                }
                Pages.BasicInteractions().WaitTime(3);
                //Pages.BasicInteractions().WaitTillNotVisible(imgLoading);

                Pages.BasicInteractions().WaitVisible(LeftNavDashboard);
                Pages.BasicInteractions().WaitTime(3);

                Pages.BasicInteractions().Click(LeftNavDashboard);
                Pages.BasicInteractions().WaitTime(3);

                Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
                Pages.BasicInteractions().WaitTime(3);

                Pages.BasicInteractions().WaitVisible(Submit);
                Pages.BasicInteractions().Click(Submit);
                Pages.BasicInteractions().WaitTime(3);

                
                if (Pages.BasicInteractions().IsElementPresent(SubmitDisbursement))
                {
                    Console.WriteLine("Disbursement link present in Dashboard");
                }
                else
                {
                    Console.WriteLine("Disbursement link NOT present in Dashboard");
                }
                Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
                Pages.BasicInteractions().WaitTime(3);

                Pages.BasicInteractions().Click(LeftNavDashboard);
                //Console.WriteLine("Disbursement link present in Dashboard");
                Pages.BasicInteractions().WaitTime(3);

                Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
                Pages.BasicInteractions().WaitTime(3);

                FuncLeftNavMenu();

                //Activity Overview section validation
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(ActivityOverviewSection);
                if (Pages.BasicInteractions().GetText(ActivityOverviewSection).Equals("Activity Overview"))
                {
                    Console.WriteLine("Activity Overview section is present");
                    //BPA total check
                    Pages.BasicInteractions().WaitVisible(BPADashboardTotal);
                    //BPADashboardOpen
                    //BPADashboardProcessed
                    if (Convert.ToInt32(Pages.BasicInteractions().GetText(BPADashboardTotal)) == Convert.ToInt32(Pages.BasicInteractions().GetText(BPADashboardOpen)) + Convert.ToInt32(Pages.BasicInteractions().GetText(BPADashboardProcessed)))
                    {
                        Console.WriteLine("Total number(" + Convert.ToInt32(Pages.BasicInteractions().GetText(BPADashboardTotal)) + "=" + (Convert.ToInt32(Pages.BasicInteractions().GetText(BPADashboardOpen)) + "+" +
                           Convert.ToInt32(Pages.BasicInteractions().GetText(BPADashboardProcessed)) + ") of BPA is correct in Dashboard"));
                    }
                    else
                    {
                        Console.WriteLine("Total number(" + Convert.ToInt32(Pages.BasicInteractions().GetText(BPADashboardTotal)) + "=" + (Convert.ToInt32(Pages.BasicInteractions().GetText(BPADashboardOpen)) + "+" +
                           Convert.ToInt32(Pages.BasicInteractions().GetText(BPADashboardProcessed)) + ") of BPA is NOT correct in Dashboard"));
                    }
                    //Claim total check
                    Pages.BasicInteractions().WaitVisible(ClaimsDashboardTotal);
                    if (Convert.ToInt32(Pages.BasicInteractions().GetText(ClaimsDashboardTotal)) == (Convert.ToInt32(Pages.BasicInteractions().GetText(ClaimsDashboardOpen)) + Convert.ToInt32(Pages.BasicInteractions().GetText(ClaimsDashboardProcessed))))
                    {
                        Console.WriteLine("Total number(" + Convert.ToInt32(Pages.BasicInteractions().GetText(ClaimsDashboardTotal)) + "=" + (Convert.ToInt32(Pages.BasicInteractions().GetText(ClaimsDashboardOpen)) + "+" +
                           Convert.ToInt32(Pages.BasicInteractions().GetText(ClaimsDashboardProcessed)) + ") of Claim is correct in Dashboard"));
                    }
                    else
                    {
                        Console.WriteLine("Total number(" + Convert.ToInt32(Pages.BasicInteractions().GetText(ClaimsDashboardTotal)) + "=" + (Convert.ToInt32(Pages.BasicInteractions().GetText(ClaimsDashboardOpen)) + "+" +
                           Convert.ToInt32(Pages.BasicInteractions().GetText(ClaimsDashboardProcessed)) + ") of Claim is NOT correct in Dashboard"));
                    }
                }
                else
                {
                    Console.WriteLine("Activity Overview section is NOT present");
                }


                //Fund Snapshot validation
                Pages.BasicInteractions().WaitTime(15);
                //Pages.BasicInteractions().WaitVisible(FundSnapshotAccrued);
                if (Pages.BasicInteractions().IsElementPresent(FundSnapshotSection))
                {
                    Console.WriteLine("Fund Snapshot Section is present");
                    if (Pages.BasicInteractions().IsElementPresent(FundSnapshotAccrued) && Pages.BasicInteractions().IsElementPresent(FundSnapshotAdjusted) && Pages.BasicInteractions().IsElementPresent(FundSnapshotTransferred) && Pages.BasicInteractions().IsElementPresent(FundSnapshotOpenClaims) &&
                    Pages.BasicInteractions().IsElementPresent(FundSnapshotApprovedClaims) && Pages.BasicInteractions().IsElementPresent(FundSnapshotPaidClaims) && Pages.BasicInteractions().IsElementPresent(FundSnapshotExpired))
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
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(RecentActivitySection);
                if (Pages.BasicInteractions().IsElementPresent(RecentActivitySection))
                {
                    Console.WriteLine("Recent Acticity section is present");

                    if (Pages.BasicInteractions().IsElementPresent(RecentActivityBPA) && Pages.BasicInteractions().IsElementPresent(RecentActivityClaims) && Pages.BasicInteractions().IsElementPresent(RecentActivityDisbursement))
                    {
                        Console.WriteLine("BPA, Claims & Disbursements tabs are present under Recent Activity section");
                    }
                    else if (Pages.BasicInteractions().IsElementPresent(RecentActivityBPA) && Pages.BasicInteractions().IsElementPresent(RecentActivityClaims))
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
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(QuickLinkSection);
                if (Pages.BasicInteractions().IsElementPresent(QuickLinkSection))
                {
                    Console.WriteLine("Quick Link section is present");
                    if (Pages.BasicInteractions().IsElementPresent(ProgramGuidelinesLink) && Pages.BasicInteractions().IsElementPresent(ClaimUserGuideLink))
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
                Console.WriteLine("Dashboard_Landing_User failed due to: " + ex);
                Assert.Fail("Dashboard_Landing_User failed due to: " + ex);
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }
        }

        //Get Available, Open, Paid Etc.,

        public IDictionary<string, Double> GetAllTheFunds(String ProgramName)
        {
            IDictionary<string, double> Funds = new Dictionary<string, double>();
            

            try
            {
                Pages.BasicInteractions().WaitTillNotVisible(oBJ_Dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.LoadingImage);

                Pages.BasicInteractions().WaitTime(5);
                if (Pages.BasicInteractions().IsElementDisplayed(obj_transaction.ProgramList(ProgramName)))
                {

                    Pages.BasicInteractions().Click(obj_transaction.ProgramList(ProgramName));
                    //Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                    Pages.BasicInteractions().WaitTime(5);
                }
                else
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().WaitVisible(obj_transaction.OtherProgramsLink);
                    Pages.BasicInteractions().Click(obj_transaction.OtherProgramsLink);
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_transaction.ProgramList(ProgramName));
                }
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                Pages.BasicInteractions().WaitTime(5);
                string AvailableFund = Pages.BasicInteractions().GetText(obj_transaction.AvailableFunds).Replace("$", "");

                if (AvailableFund.Contains("(") | AvailableFund.Contains(")"))
                {
                    AvailableFund = "-" + AvailableFund.Replace("(", "").Replace(")", "");
                }
                Funds.Add("AvailableFunds", Convert.ToDouble(AvailableFund));

                //Clicking on View Detailed Report
                Pages.BasicInteractions().WaitVisible(oBJ_Dashboard.LnkViewDetailedReport);
                Pages.BasicInteractions().Click(oBJ_Dashboard.LnkViewDetailedReport);
                Pages.BasicInteractions().WaitTillNotVisible(oBJ_Dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(oBJ_Dashboard.BtnMoreDetails);
                Pages.BasicInteractions().Click(oBJ_Dashboard.BtnMoreDetails);

                //Get All the funds and add to Dictionary
                string TotalCredited = Pages.BasicInteractions().GetText(oBJ_Dashboard.TotalCredited).Replace("$", "");

                if (TotalCredited.Contains("(") | TotalCredited.Contains(")"))
                {
                    TotalCredited = "-" + TotalCredited.Replace("(", "").Replace(")", "");
                }
                Funds.Add("TotalCredited", Convert.ToDouble(TotalCredited));


                //Open Claims
                string OpenClaims = Pages.BasicInteractions().GetText(oBJ_Dashboard.OpenCliams).Replace("$", "");

                if (OpenClaims.Contains("(") | OpenClaims.Contains(")"))
                {
                    OpenClaims = "-" + OpenClaims.Replace("(", "").Replace(")", "");
                }
                Funds.Add("OpenClaims", Convert.ToDouble(OpenClaims));

                //Approved Claims
                string ApprovedClaims = Pages.BasicInteractions().GetText(oBJ_Dashboard.ApprovedClaims).Replace("$", "");

                if (ApprovedClaims.Contains("(") | ApprovedClaims.Contains(")"))
                {
                    ApprovedClaims = "-" + ApprovedClaims.Replace("(", "").Replace(")", "");
                }
                Funds.Add("ApprovedClaims", Convert.ToDouble(ApprovedClaims));

                //Paid Claims
                string PaidCliams = Pages.BasicInteractions().GetText(oBJ_Dashboard.PaidClaims).Replace("$", "");

                if (PaidCliams.Contains("(") | PaidCliams.Contains(")"))
                {
                    PaidCliams = "-" + PaidCliams.Replace("(", "").Replace(")", "");
                }
                Funds.Add("PaidCliams", Convert.ToDouble(PaidCliams));

                return Funds;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }


        //Navigate to dashBoard
        public void NavigatingToDashBoard()
        {           

            try
            {
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_Claims.BtnDashBoard);
                Pages.BasicInteractions().Click(obj_Claims.BtnDashBoard);
                Pages.BasicInteractions().WaitTillNotVisible(obj_Claims.ImgLoading);
                Pages.BasicInteractions().WaitTime(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //Checking the Claims Count Matching on Dashboard
        public void ValidateClaimCountMatchingWithAdditionOfOpenAndProcessedClaims()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(oBJ_Dashboard.LnkTotalClaimsCount);
                Pages.BasicInteractions().WaitTime(5);
                Double TotalClaims = Convert.ToDouble(Pages.BasicInteractions().GetText(oBJ_Dashboard.LnkTotalClaimsCount));
                Double OpenClaims = Convert.ToDouble(Pages.BasicInteractions().GetText(oBJ_Dashboard.LnkOpenClaimsCount));
                Double ProcessedClaims = Convert.ToDouble(Pages.BasicInteractions().GetText(oBJ_Dashboard.LnkProcessedClaimsCount));

                Assert.IsTrue(TotalClaims == (OpenClaims + ProcessedClaims));
                Console.WriteLine("Claims Count showing Correctly");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }



        public void ValidateOpenClaimsFilterDashBoard()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(oBJ_Dashboard.LnkOpenClaimsCount);
                Pages.BasicInteractions().Click(oBJ_Dashboard.LnkOpenClaimsCount);
                Pages.BasicInteractions().WaitTillNotVisible(oBJ_Dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_Claims.TblCalimFirstRowClaimID);
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_Claims.PendingReviewCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_Claims.ResubmittedCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_Claims.NeedsInformationCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_Claims.HoldCheckboxActive));
                Console.WriteLine("Open Claims Filter is working Correctly");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }


        public void ValidateProcessedClaimsFilterDashBoard()
        {           
            try
            {               
                Pages.BasicInteractions().WaitVisible(oBJ_Dashboard.LnkProcessedClaimsCount);
                Pages.BasicInteractions().Click(oBJ_Dashboard.LnkProcessedClaimsCount);
                Pages.BasicInteractions().WaitTillNotVisible(oBJ_Dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_Claims.TblCalimFirstRowClaimID);

                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_Claims.PaidCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_Claims.ClosedCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_Claims.DeniedCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_Claims.ApprovedCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_Claims.BrandBuilderPaidCheckboxActive));
                Console.WriteLine("Processed Claims Filter is working Correctly");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }



        //Checking the Claims Count Matching on Dashboard
        public void ValidateBPACountMatchingWithAdditionOfOpenAndProcessedClaims()
        {            
            try
            {
                Pages.BasicInteractions().WaitVisible(oBJ_Dashboard.LnkTotalBPACount);
                Pages.BasicInteractions().WaitTime(5);
                Double TotalClaims = Convert.ToDouble(Pages.BasicInteractions().GetText(oBJ_Dashboard.LnkTotalBPACount));
                Double OpenClaims = Convert.ToDouble(Pages.BasicInteractions().GetText(oBJ_Dashboard.LnkOpenBPACount));
                Double ProcessedClaims = Convert.ToDouble(Pages.BasicInteractions().GetText(oBJ_Dashboard.LnkProcessedBPACount));
                Assert.IsTrue(TotalClaims == (OpenClaims + ProcessedClaims));
                Console.WriteLine("Claims Count showing Correctly");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }



        public void ValidateOpenBPAFilterDashBoard()
        {           

            try
            {
                Pages.BasicInteractions().WaitVisible(oBJ_Dashboard.LnkOpenBPACount);
                Pages.BasicInteractions().Click(oBJ_Dashboard.LnkOpenBPACount);
                Pages.BasicInteractions().WaitTillNotVisible(oBJ_Dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitVisible(obj_Claims.TblCalimFirstRowClaimID);

                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_Claims.PendingReviewCheckboxActive));
                //Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.ResubmittedCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_Claims.NeedsInformationCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_Claims.HoldCheckboxActive));
                //Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.ResubmittedCheckbox));
                //Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.NeedsInformationCheckbox));
                Console.WriteLine("Open Claims Filter is working Correctly");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void ValidateProcessedBPAFilterDashBoard()
        {            
            try
            {
                //double TotalClaims = 0;
                Pages.BasicInteractions().WaitVisible(oBJ_Dashboard.LnkProcessedBPACount);
                Pages.BasicInteractions().Click(oBJ_Dashboard.LnkProcessedBPACount);
                Pages.BasicInteractions().WaitTillNotVisible(oBJ_Dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitVisible(obj_Claims.TblCalimFirstRowClaimID);

                //Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.PaidCheckboxActive));
                //Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.ClosedCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_Claims.DeniedCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_Claims.ApprovedCheckboxActive));
                // Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.BrandBuilderPaidCheckboxActive));
                Console.WriteLine("Processed Claims Filter is working Correctly");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void ValidateLabels_CreateNewProgram()
        {
            try
            {
                Pages.BasicInteractions().WaitUntilElementVisible(LeftNavProgram,120);
                Pages.BasicInteractions().Click(LeftNavProgram);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitVisible(LnkNewProgram);
                Pages.BasicInteractions().Click(LnkNewProgram);
                Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                ValidatePageLabelValues("Program Name");
                ValidatePageLabelValues("Description");
                ValidatePageLabelValues("Program Currency");
                ValidatePageLabelValues("Start Date");
                ValidatePageLabelValues("End Date");
                ValidatePageLabelValues("Upload Program Guidelines(max 5 attachments)");

                Pages.BasicInteractions().Click(LeftNavProgram);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Program.Programlabel, 20);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Program.active, 20);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Program.open, 20);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Program.inactive, 20);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Program.closed, 20);

                Pages.BasicInteractions().Click(oBJ_Program.open);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().Click(oBJ_Program.inactive);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().Click(oBJ_Program.closed);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in ValidateLabels_CreateNewProgram method:" + ex.Message);
                throw;
            }           
            
        }
        public void Validate_Transaction()
        {
            Pages.BasicInteractions().WaitUntilElementVisible(obj_transaction.LeftNavTransaction,120);
            Pages.BasicInteractions().Click(obj_transaction.LeftNavTransaction);
            Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
            Pages.BasicInteractions().WaitUntilElementVisible(obj_transaction.TranAccrual, 120);
            //Validate Accrual
            Pages.BasicInteractions().Click(obj_transaction.TranAccrual);
            Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            ValidatePageLabelValues("Program");
            ValidatePageLabelValues("Store");
            ValidatePageLabelValues("Period");
            ValidatePageLabelValues("Amount");
            ValidatePageLabelValues("Comments (Optional)");

            Pages.BasicInteractions().Click(obj_transaction.LeftNavTransaction);
            Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
            Pages.BasicInteractions().WaitUntilElementVisible(obj_transaction.TranAdjustment, 120);
            //Validate Adjustment
            Pages.BasicInteractions().Click(obj_transaction.TranAdjustment);
            Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            ValidatePageLabelValues("Program");
            ValidatePageLabelValues("Store");
            ValidatePageLabelValues("Period");
            ValidatePageLabelValues("Amount");
            ValidatePageLabelValues("Comments (Optional)");

            Pages.BasicInteractions().Click(obj_transaction.LeftNavTransaction);
            Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
            Pages.BasicInteractions().WaitUntilElementVisible(obj_transaction.TranTransfer, 120);

            //Validate Transaction
            Pages.BasicInteractions().Click(obj_transaction.TranTransfer);
            Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            ValidatePageLabelValues("Program");
            ValidatePageLabelValues("Store");
            ValidatePageLabelValues("Comments (Optional)");
            Console.WriteLine("Asserting for TransferAmount label to be present : Actual Value : " + Pages.BasicInteractions().IsElementPresent(obj_transaction.TransferAmountLabel) + "Expected Value : true");
            Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_transaction.TransferAmountLabel));
        }

        public void Validate_Dashboard()
        {
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

            ValidatePageHeaderValues("Dashboard");
            ValidateParticularButton("SEARCH");

            Console.WriteLine("Asserting for ActivityOverview label to be present : Actual Value : " + Pages.BasicInteractions().IsElementPresent(oBJ_Dashboard.ActivityOverviewSection) + "Expected Value : true");
            Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(oBJ_Dashboard.ActivityOverviewSection));

            Console.WriteLine("Asserting for FundSnapshotSection label to be present : Actual Value : " + Pages.BasicInteractions().IsElementPresent(oBJ_Dashboard.FundSnapshotSection) + "Expected Value : true");
            Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(oBJ_Dashboard.FundSnapshotSection));

            Console.WriteLine("Asserting for RecentActivitySection to be present : Actual Value : " + Pages.BasicInteractions().IsElementPresent(oBJ_Dashboard.RecentActivitySection) + "Expected Value : true");
            Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(oBJ_Dashboard.RecentActivitySection));

            Console.WriteLine("Asserting for Submit Button to be present : Actual Value : " + Pages.BasicInteractions().IsElementPresent(oBJ_Dashboard.Submit) + "Expected Value : true");
            Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(oBJ_Dashboard.Submit));

            Pages.BasicInteractions().Click(LeftNavPreapprovals);
            Pages.BasicInteractions().WaitVisible((oBJ_Dashboard.SubmitBrandPreApproval_Button));
            Console.WriteLine("Asserting for SubmitBrandPreApproval_Button to be present : Actual Value : " + Pages.BasicInteractions().IsElementPresent(oBJ_Dashboard.SubmitBrandPreApproval_Button) + "Expected Value : true");
            Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(oBJ_Dashboard.SubmitBrandPreApproval_Button));
            Console.WriteLine("Submit Brand Pre-Approval button is available on BPA Manage page");
            Pages.BasicInteractions().WaitUntilElementVisible(LeftNavClaim, 240);
            Pages.BasicInteractions().Click(LeftNavClaim);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

            Pages.BasicInteractions().WaitVisible((oBJ_Dashboard.SubmitClaim_Button));
            Console.WriteLine("Asserting for SubmitClaim Button to be present : Actual Value : " + Pages.BasicInteractions().IsElementPresent(oBJ_Dashboard.SubmitClaim_Button) + "Expected Value : true");
            Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(oBJ_Dashboard.SubmitClaim_Button));
            Console.WriteLine("Submit Claim button is available on Claim Manage page");
            Console.WriteLine("Dashboard_Validation_ Executed - PASSED");               
        }
        
        public void Validate_Disbursements()
        {
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            Pages.BasicInteractions().WaitVisible(obj_Disbursement.LeftNavDisbursement);
            Pages.BasicInteractions().Click(obj_Disbursement.LeftNavDisbursement);
            Pages.BasicInteractions().WaitUntilElementVisible(InProcessStatusTabs,240);
            ValidatePageHeadSectionValues("Pending");
            ValidatePageHeadSectionValues("InProcess");
            ValidatePageHeadSectionValues("Completed");
            ValidatePageHeadSectionValues("Declined");
            Pages.BasicInteractions().Click(InProcessStatusTabs);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            Pages.BasicInteractions().Click(DeclinedStatusTabs);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            Pages.BasicInteractions().Click(PendingStatusTabs);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            Pages.BasicInteractions().Click(CompletedStatusTabs);

            Pages.BasicInteractions().WaitVisible(oBJ_Common.MoreDetailsLink);
            Pages.BasicInteractions().Click(oBJ_Common.MoreDetailsLink);
            Pages.BasicInteractions().WaitVisible(oBJ_Common.CommentsLink);
            Pages.BasicInteractions().Click(oBJ_Common.CommentsLink);
            Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Common.CommentHistoryLabel,120);
            Assert.AreEqual(true, Pages.BasicInteractions().IsElementDisplayed(oBJ_Common.CommentHistoryLabel));
            Pages.BasicInteractions().Click(oBJ_Common.CloseButton);
            Pages.BasicInteractions().WaitVisible(oBJ_Common.ViewAssociatedClaimsLink);
            Pages.BasicInteractions().Click(oBJ_Common.ViewAssociatedClaimsLink);
            Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Common.FirstRowClaimIdStatus,120);
            string ExpectedStatus = Pages.BasicInteractions().GetText(oBJ_Common.FirstRowClaimIdStatus);
            Pages.BasicInteractions().Click(oBJ_Common.FirstRowClaimIdLink);
            Pages.BasicInteractions().WaitUntilElementVisible(obj_Claims.ClaimStatusOnClaimReviewPage,120);

            string ActualStatus = Pages.BasicInteractions().GetText(obj_Claims.ClaimStatusOnClaimReviewPage);
            Console.WriteLine("Asserting for claim status on Disb Detail page and claim review page to be same");
            Assert.AreEqual(ExpectedStatus, ActualStatus);

        }

        public void Validate_Claims()
        {  
            ClickParticularValueSection("CLAIMS");
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            ValidatePageHeadSectionValues("Pending");
            ValidatePageHeadSectionValues("InProcess");
            ValidatePageHeadSectionValues("Completed");
            ValidatePageHeadSectionValues("Declined");

            Pages.BasicInteractions().Click(InProcessStatusTabs);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

            Pages.BasicInteractions().Click(DeclinedStatusTabs);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

            Pages.BasicInteractions().Click(PendingStatusTabs);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

            Pages.BasicInteractions().Click(CompletedStatusTabs);
            Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Common.MoreDetailsLink,120);
            Pages.BasicInteractions().Click(oBJ_Common.MoreDetailsLink);
            Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Common.AuditTrailLink, 120);
            Pages.BasicInteractions().Click(oBJ_Common.AuditTrailLink);
            Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Common.AuditHistoryLabel, 120);
            Assert.AreEqual(true, Pages.BasicInteractions().IsElementDisplayed(oBJ_Common.AuditHistoryLabel));
            Pages.BasicInteractions().Click(oBJ_Common.CloseButton);
            Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Common.ClaimDetailsPageStatus, 120);          
            string ExpectedStatus = Pages.BasicInteractions().GetText(oBJ_Common.ClaimDetailsPageStatus);
            Pages.BasicInteractions().Click(oBJ_Common.ViewButton);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            string ActualStatus = Pages.BasicInteractions().GetText(obj_Claims.ClaimStatusOnClaimReviewPage);
            Assert.AreEqual(ExpectedStatus, ActualStatus);
            Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

        }

    }

}
