using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using NUnit.Framework;
using System;

namespace CFM_PARALLEL.PageObject.UI.Functions.Geico
{
    public class Geico_Dashboard
    {
        private OBJ_Dashboard obj_dashboard;
        //Constructor
        public Geico_Dashboard()
        {
            obj_dashboard = new OBJ_Dashboard();            
        }

        public string Get_TotalSpent_Dashboard()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_dashboard.RequiredProgram_Dashboard);
                Pages.BasicInteractions().Click(obj_dashboard.RequiredProgram_Dashboard);
                Pages.BasicInteractions().WaitTime(5);
                string Dashboard_TotalSpent = Pages.BasicInteractions().GetText(obj_dashboard.TotalSpentAmount);
                return Dashboard_TotalSpent;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Get_TotalSpent_Dashboard method:" + ex.Message);
                throw;
            }
        }

        public void DashBoard_Validation()
        {
            try
            {
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(10);
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

                Pages.BasicInteractions().WaitTime(20);
                obj_dashboard.SetMS_ActivityOverviewXpath("CLAIMS", "Total");
                Console.WriteLine("Asserting for Element Total to be displayed under CLAIMS Expected : True , Actual : " + Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));

                obj_dashboard.SetMS_ActivityOverviewXpath("CLAIMS", "Open");
                Console.WriteLine("Asserting for Element Open to be displayed under CLAIMS  Expected : True , Actual : " + Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));

                obj_dashboard.SetMS_ActivityOverviewXpath("CLAIMS", "Processed");
                Console.WriteLine("Asserting for Element Processed to be displayed under CLAIMS  Expected : True , Actual : " + Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));

              
                //Recent Activity Element Validation

                obj_dashboard.SetMS_RecentActivityXpath("Claims");
                Console.WriteLine("Asserting for Element Claims to be displayed under Recent Activity  Expected : True , Actual : " + Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));
                Assert.IsTrue(Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.MS_DashboardElements));                              

               
                // validate left navigation links in dashboard

                Pages.Dashboard_Landing().ClickParticularValueSection("PROGRAMS");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Console.WriteLine("Asserting Error Widget after clicking PROGRAMS");
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
               
                Pages.Dashboard_Landing().ClickParticularValueSection("CLAIMS");
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
