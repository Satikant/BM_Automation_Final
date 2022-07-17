using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Transactions;
using CFMAutomation.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CFM_PARALLEL.PageObject.UI.Functions.Masco.Dashboard
{
    public class MS_Dashboard
    {       
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Common oBJ_Common;
        private OBJ_Transactions obj_Transactions;


        public MS_Dashboard()
        {
            obj_dashboard = new OBJ_Dashboard();
            oBJ_Common = new OBJ_Common();
            obj_Transactions = new OBJ_Transactions();
        }

        public void SelectSearchUserFrom_BM_AdminDropdown()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_dashboard.LeftNavDashboard);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.MS_BM_AdminLink);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_dashboard.MS_BM_AdminLink);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_dashboard.MS_SearchEdituser);
                Pages.BasicInteractions().WaitVisible(oBJ_Common.LnkEmulateUser);
                Pages.BasicInteractions().WaitTime(10);                               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message in SelectSearchUserFrom_BM_AdminDropdown method : " + ex.Message);
                throw;
            }
        }


        public void FundSnapshot_Validation()
        {
            try
            {
               
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.Dashboard_Landing().ClickParticularValueSection("DASHBOARD");
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("View Detailed Report");
                string dashboardAvailableFund = Pages.BasicInteractions().GetText(obj_dashboard.MS_DashboardAvailableFund);
                dashboardAvailableFund.Split('$')[1].Replace(",", "");

                Pages.BasicInteractions().Click(obj_dashboard.ViewDetailedReportLink);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                //Asserting Dashboard dashboardAvailableFund and viewDetailAvailableFund
                string viewDetailAvailableFund = Pages.BasicInteractions().GetText(obj_dashboard.MS_ViewDetailsAvailableFund);
                Console.WriteLine("Asserting for dashboardAvailableFund and viewDetailAvailableFund to be equal.");
                Assert.AreEqual(dashboardAvailableFund,viewDetailAvailableFund);

                if (!Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.NewFundDetailFundOverview))
                {
                    Pages.BasicInteractions().Click(obj_dashboard.NewFundDetailSlideButton);
                    Pages.BasicInteractions().WaitVisible(obj_dashboard.NewFundDetailFundOverview);

                }
                
                Pages.BasicInteractions().WaitVisible(obj_dashboard.NewFundDetailProgramDropdown);
                Pages.BasicInteractions().Click(obj_dashboard.NewFundDetailProgramDropdown);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.NewFundDetailProgramTextbox);
                Pages.BasicInteractions().Click(obj_dashboard.NewFundDetailProgramTextbox);
                Pages.BasicInteractions().Type(obj_dashboard.NewFundDetailProgramTextbox, Parameters.MS_ProgramName);

                Pages.BasicInteractions().WaitVisible(obj_Transactions.DropdownOption_Transaction(Parameters.MS_ProgramName));
                Pages.BasicInteractions().Click(obj_Transactions.DropdownOption_Transaction(Parameters.MS_ProgramName));
                Pages.BasicInteractions().WaitTime(2);


                Pages.BasicInteractions().WaitVisible(obj_dashboard.NewFundDetailStoreDropdown);
                Pages.BasicInteractions().Click(obj_dashboard.NewFundDetailStoreDropdown);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.NewFundDetailStoreTextbox);
                Pages.BasicInteractions().Click(obj_dashboard.NewFundDetailStoreTextbox);
                Pages.BasicInteractions().Type(obj_dashboard.NewFundDetailStoreTextbox, Parameters.MS_AgentNAme);

                Pages.BasicInteractions().WaitVisible(obj_Transactions.DropdownOption_Transaction(Parameters.MS_AgentNAme));
                Pages.BasicInteractions().Click(obj_Transactions.DropdownOption_Transaction(Parameters.MS_AgentNAme));
                Pages.BasicInteractions().WaitTime(2);
                
                Pages.BasicInteractions().Click(obj_dashboard.NewFundDetailApplyFilter);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Download Fund Overview");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Available Funds");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("TOTAL CREDITED");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Frozen");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Open Claims");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Approved Claims");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Paid Claims");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Transaction Summary");

                Pages.BasicInteractions().Click(obj_dashboard.TranscationSummaryDropdown);
                Pages.BasicInteractions().Click(obj_Transactions.DropdownOption_Transaction("Adjusted"));
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_dashboard.TranscationSummaryDropdown);
                Pages.BasicInteractions().Click(obj_Transactions.DropdownOption_Transaction("Accrued"));
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_dashboard.TranscationSummaryDropdown);
                Pages.BasicInteractions().Click(obj_Transactions.DropdownOption_Transaction("Transferred"));
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_dashboard.TranscationSummaryDropdown);
                Pages.BasicInteractions().Click(obj_Transactions.DropdownOption_Transaction("Frozen"));
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_dashboard.TranscationSummaryDropdown);
                Pages.BasicInteractions().Click(obj_Transactions.DropdownOption_Transaction("Open"));
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_dashboard.TranscationSummaryDropdown);
                Pages.BasicInteractions().Click(obj_Transactions.DropdownOption_Transaction("Approved"));
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_dashboard.TranscationSummaryDropdown);
                Pages.BasicInteractions().Click(obj_Transactions.DropdownOption_Transaction("Paid"));
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_dashboard.TranscationSummaryDropdown);
                Pages.BasicInteractions().Click(obj_Transactions.DropdownOption_Transaction("Expired"));
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in FundSnapshot_Validation method: " + ex.Message);
                throw;
            }
        }

        public void DashBoard_Validation()
        {
            try
            {
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                // Validating dashboard headers and submit button
                Console.WriteLine("Asserting for ActivityOverview label to be present : Actual Value : " + Pages.BasicInteractions().IsElementPresent(obj_dashboard.ActivityOverviewSection) + " Expected Value : true");
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_dashboard.ActivityOverviewSection));

                Console.WriteLine("Asserting for FundSnapshotSection label to be present : Actual Value : " + Pages.BasicInteractions().IsElementPresent(obj_dashboard.FundSnapshotSection) + " Expected Value : true");
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_dashboard.FundSnapshotSection));

                Console.WriteLine("Asserting for RecentActivitySection to be present : Actual Value : " + Pages.BasicInteractions().IsElementPresent(obj_dashboard.RecentActivitySection) + " Expected Value : true");
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_dashboard.RecentActivitySection));

                Console.WriteLine("Asserting for Submit Button to be present : Actual Value : " + Pages.BasicInteractions().IsElementPresent(obj_dashboard.Submit) + " Expected Value : true");
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_dashboard.Submit));

                //Activity Overview Element Validation

                obj_dashboard.SetMS_ActivityOverviewXpath("BRAND PRE-APPROVALS", "Total");
                Console.WriteLine("Asserting for Element Total to be displayed under BRAND PRE-APPROVALS. Expected : True , Actual : "+Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));

                obj_dashboard.SetMS_ActivityOverviewXpath("FUND PRE-APPROVALS", "Open");
                Console.WriteLine("Asserting for Element Open to be displayed under FUND PRE-APPROVALS  Expected : True , Actual : " + Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));

                obj_dashboard.SetMS_ActivityOverviewXpath("CLAIMS", "Processed");
                Console.WriteLine("Asserting for Element Processed to be displayed under CLAIMS  Expected : True , Actual : " + Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));

                obj_dashboard.SetMS_ActivityOverviewXpath("DISPLAY CLAIMS", "Total");
                Console.WriteLine("Asserting for Element Total to be displayed under DISPLAY CLAIMS  Expected : True , Actual : " + Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));

                //Recent Activity Element Validation

                obj_dashboard.SetMS_RecentActivityXpath("Brand Pre-Approvals");
                Console.WriteLine("Asserting for Element Brand Pre Aprroval to be displayed under Recent Activity  Expected : True , Actual : " + Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));

                obj_dashboard.SetMS_RecentActivityXpath("Fund Pre-Approvals");
                Console.WriteLine("Asserting for Element Fund Pre Aprroval to be displayed under Recent Activity  Expected : True , Actual : " + Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Pages.BasicInteractions().Click(obj_dashboard.MS_DashboardElements);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                
                obj_dashboard.SetMS_RecentActivityXpath("Claims");
                Console.WriteLine("Asserting for Element Claims to be displayed under Recent Activity  Expected : True , Actual : " + Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Pages.BasicInteractions().Click(obj_dashboard.MS_DashboardElements);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                                             
                obj_dashboard.SetMS_RecentActivityXpath("Display Claims");
                Console.WriteLine("Asserting for Element Display Claims to be displayed under Recent Activity  Expected : True , Actual : " + Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Pages.BasicInteractions().Click(obj_dashboard.MS_DashboardElements);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                // validate left navigation links in dashboard

                Pages.Dashboard_Landing().ClickParticularValueSection("PROGRAMS");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Console.WriteLine("Asserting Error Widget after clicking PROGRAMS");
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();                
               
                Pages.Dashboard_Landing().ClickParticularValueSection("FUND PRE-APPROVALS");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Console.WriteLine("Asserting Error Widget after clicking FUND PRE-APPROVALS");
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.Dashboard_Landing().ClickParticularValueSection("BRAND PRE-APPROVALS");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Console.WriteLine("Asserting Error Widget after clicking BRAND PRE-APPROVALS");
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.Dashboard_Landing().ClickParticularValueSection("CLAIMS");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Console.WriteLine("Asserting Error Widget after clicking CLAIMS");
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.Dashboard_Landing().ClickParticularValueSection("DISPLAY CLAIMS");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Console.WriteLine("Asserting Error Widget after clicking DISPLAY CLAIMS");
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                
                Pages.Dashboard_Landing().ClickParticularValueSection("FUND REQUEST");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Console.WriteLine("Asserting Error Widget after clicking FUND REQUEST");
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public List<double> FundCalculation()
        {
            List<double> amountList = new List<double>();
            try
            {
                Pages.Dashboard_Landing().ClickParticularValueSection("DASHBOARD");
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("View Detailed Report");

                string AvailableFund = Pages.BasicInteractions().GetText(obj_dashboard.MS_DashboardAvailableFund).Split('$')[1].Replace(",", "");
                amountList.Add(Double.Parse(AvailableFund));
                string FrozenFund = Pages.BasicInteractions().GetText(obj_dashboard.FrozenFunds).Split('$')[1].Replace(",", "");
                amountList.Add(Double.Parse(FrozenFund));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }

            return amountList;
        }
    }
}
