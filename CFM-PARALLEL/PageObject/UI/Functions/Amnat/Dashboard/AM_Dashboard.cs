using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using NUnit.Framework;
using System;

namespace CFM_PARALLEL.PageObject.UI.Functions.Amnat.Dashboard
{
    public class AM_Dashboard
    {
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Common oBJ_Common;

        public AM_Dashboard()
        {
            obj_dashboard = new OBJ_Dashboard();
            oBJ_Common = new OBJ_Common();
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
                Console.WriteLine("Asserting for Element Total to be displayed under BRAND PRE-APPROVALS. Expected : True , Actual : " + Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));

                obj_dashboard.SetMS_ActivityOverviewXpath("BRAND PRE-APPROVALS", "Open");
                Console.WriteLine("Asserting for Element Open to be displayed under BRAND PRE-APPROVALS  Expected : True , Actual : " + Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));

                obj_dashboard.SetMS_ActivityOverviewXpath("CLAIMS", "Processed");
                Console.WriteLine("Asserting for Element Processed to be displayed under CLAIMS  Expected : True , Actual : " + Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));

                //Recent Activity Element Validation
                obj_dashboard.SetMS_RecentActivityXpath("Brand Pre-Approvals");
                Console.WriteLine("Asserting for Element Brand Pre Aprroval to be displayed under Recent Activity  Expected : True , Actual : " + Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                                
                obj_dashboard.SetMS_RecentActivityXpath("Claims");
                Console.WriteLine("Asserting for Element Claims to be displayed under Recent Activity  Expected : True , Actual : " + Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Pages.BasicInteractions().Click(obj_dashboard.MS_DashboardElements);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                // validate left navigation links in dashboard
                Pages.BasicInteractions().Click(obj_dashboard.LeftNavProgram);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Console.WriteLine("Asserting Error Widget after clicking PROGRAMS");
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.Dashboard_Landing().ClickParticularValueSection("BRAND PRE-APPROVALS");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Console.WriteLine("Asserting Error Widget after clicking BRAND PRE-APPROVALS");
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.Dashboard_Landing().ClickParticularValueSection("CLAIMS");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Console.WriteLine("Asserting Error Widget after clicking CLAIMS");
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in DashBoard_Validation method: " + ex.Message);
                throw;
            }
        }


        public void FundSnapshot_Validation()
        {
            try
            {
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("View Detailed Report");
                string dashboardAvailableFund = Pages.BasicInteractions().GetText(obj_dashboard.MS_DashboardAvailableFund);
                //dashboardAvailableFund.Split('$')[1].Replace(",", "");

                Pages.BasicInteractions().WaitVisible(obj_dashboard.ViewDetailedReportLink);
                Pages.BasicInteractions().Click(obj_dashboard.ViewDetailedReportLink);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitVisible(obj_dashboard.MS_ViewDetailsAvailableFund);
                string viewDetailAvailableFund = Pages.BasicInteractions().GetText(obj_dashboard.MS_ViewDetailsAvailableFund);
                Console.WriteLine("Asserting for dashboardAvailableFund and viewDetailAvailableFund to be equal.");
                Assert.AreEqual(dashboardAvailableFund, viewDetailAvailableFund);

                Pages.BasicInteractions().Click(obj_dashboard.Moredetailslinktext);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Download Fund Overview");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Download Excel");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Accrued");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Adjusted");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Transferred");                
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Open");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Approved");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Paid");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Expired");

                Pages.Dashboard_Landing().ClickParticularValues("Adjusted");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.Dashboard_Landing().ClickParticularValues("Transferred");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.Dashboard_Landing().ClickParticularValues("Open");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                
                Pages.Dashboard_Landing().ClickParticularValues("Paid");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.Dashboard_Landing().ClickParticularValues("Expired");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.Dashboard_Landing().ClickParticularValues("Approved");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().Click(obj_dashboard.MS_FirstDataRowLink);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Console.WriteLine("Asserting for Approved tab first link.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in FundSnapshot_Validation method: " + ex.Message);
                throw;
            }
        }
    }
}
