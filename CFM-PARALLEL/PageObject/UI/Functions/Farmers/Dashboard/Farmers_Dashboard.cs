using CFM_PARALLEL.PageObject.PageFactory;
using NUnit.Framework;
using System;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;

namespace CFM_PARALLEL.PageObject.UI.Functions.Farmers.Dashboard
{
    public class Farmers_Dashboard
    {
        private OBJ_Dashboard obj_dashboard;

        public Farmers_Dashboard()
        {
            obj_dashboard = new OBJ_Dashboard();
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

                Pages.Dashboard_Landing().ClickParticularValueSection("FUNDING SOURCES");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Console.WriteLine("Asserting Error Widget after clicking PROGRAMS");
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

     
                Pages.Dashboard_Landing().ClickParticularValueSection("PREAPPROVAL REQUESTS");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Console.WriteLine("Asserting Error Widget after clicking BRAND PRE-APPROVALS");
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.Dashboard_Landing().ClickParticularValueSection("FUNDING REQUESTS");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Console.WriteLine("Asserting Error Widget after clicking CLAIMS");
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }
    }
}
