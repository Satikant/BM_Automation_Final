using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CFM_PARALLEL.PageObject.UI.Functions.Nationwide.Dashboard
{
    public class NW_Dashboard
    {

        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private OBJ_Transactions obj_transaction;

        public NW_Dashboard()
        {
            obj_dashboard = new OBJ_Dashboard();
            obj_claims = new OBJ_Claims();
            obj_transaction = new OBJ_Transactions();
        }

        public void DashBoard_Validation()
        {
            try
            {
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Activity Overview");
                Pages.BrowserURLLaunch().Validate_Error_Messages();
                
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Total");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Open");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Processed");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Fund Snapshot");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Recent Activity");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("View Detailed Report");

                Pages.Dashboard_Landing().ClickParticularValueSection("PROGRAMS");
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.Dashboard_Landing().ClickParticularValueSection("TRANSACTION");
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();                

                Pages.Dashboard_Landing().ClickParticularValueSection("CLAIMS");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.Dashboard_Landing().ValidateParticularButton("SUBMIT CLAIM");

                Pages.Dashboard_Landing().ClickParticularValueSection("DASHBOARD");
                Pages.BasicInteractions().WaitUntilElementVisible(obj_dashboard.ActivityOverviewSection,120);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_dashboard.FundSnapshotSection, 120);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_dashboard.RecentActivitySection, 120);

                Console.WriteLine("Asserting for ActivityOverview label to be present : Actual Value : " + Pages.BasicInteractions().IsElementPresent(obj_dashboard.ActivityOverviewSection) + " Expected Value : true");
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_dashboard.ActivityOverviewSection));

                Console.WriteLine("Asserting for FundSnapshotSection label to be present : Actual Value : " + Pages.BasicInteractions().IsElementPresent(obj_dashboard.FundSnapshotSection) + " Expected Value : true");
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_dashboard.FundSnapshotSection));

                Console.WriteLine("Asserting for RecentActivitySection to be present : Actual Value : " + Pages.BasicInteractions().IsElementPresent(obj_dashboard.RecentActivitySection) + " Expected Value : true");
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_dashboard.RecentActivitySection));

                Console.WriteLine("Asserting for Submit Button to be present : Actual Value : " + Pages.BasicInteractions().IsElementPresent(obj_dashboard.Submit) + " Expected Value : true");
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_dashboard.Submit));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in DashBoard_Validation method: " + ex.Message);
                throw;
            }
        }
    }
}
