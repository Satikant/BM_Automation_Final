
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Program_Management;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Transactions;
using NUnit.Framework;
using System;


namespace CFM_PARALLEL.PageObject.UI.Functions.Pandora
{
    public class PN_Dashboard
    {

        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private OBJ_Transactions obj_transaction;
        private OBJ_Program oBJ_Program;

        public PN_Dashboard()
        {
            obj_dashboard = new OBJ_Dashboard();
            obj_claims = new OBJ_Claims();
            oBJ_Program = new OBJ_Program();
            obj_transaction = new OBJ_Transactions();
        }

        public void ProgramValidation_AdminLevel()
        {
            try
            {                
                Pages.BasicInteractions().WaitVisible(obj_dashboard.LeftNavProgram);
                Pages.Dashboard_Landing().ClickParticularValueSection("PROGRAMS");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Program.Programlabel, 5);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Program.active, 5);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Program.open, 5);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Program.inactive, 5);
                Pages.BasicInteractions().WaitUntilElementVisible(oBJ_Program.closed, 5);

                //Pages.BasicInteractions().Click(obj_dashboard.lnkNewProgram);
                ////Pages.Dashboard_Landing().validatePageHeaderValues("New Program");
                //Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.imgLoading);
                //Pages.BasicInteractions().WaitTime(10);
                //Pages.Dashboard_Landing().validatePageLabelValues("Program Name");
                //Pages.Dashboard_Landing().validatePageLabelValues("Description");
                //Pages.Dashboard_Landing().validatePageLabelValues("Program Currency");
                //Pages.Dashboard_Landing().validatePageLabelValues("Start Date");
                //Pages.Dashboard_Landing().validatePageLabelValues("End Date");
                //Pages.Dashboard_Landing().validatePageLabelValues("Upload Program Guidelines(max 5 attachments)");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message in ProgramValidation_AdminLevel: " + ex.Message);
                throw;
            }
        }

        public void DashBoardValidation_AdminLevel()
        {
            try
            {
                Pages.Dashboard_Landing().ClickParticularValueSection("DASHBOARD");
                Pages.Dashboard_Landing().ValidatePageHeaderValues("Dashboard");
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.Dashboard_Landing().ValidateParticularButton("SEARCH");

                Console.WriteLine("Asserting for ActivityOverview label to be present : Actual Value : " + Pages.BasicInteractions().IsElementPresent(obj_dashboard.ActivityOverviewSection) + "Expected Value : true");
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_dashboard.ActivityOverviewSection));

                Console.WriteLine("Asserting for FundSnapshotSection label to be present : Actual Value : " + Pages.BasicInteractions().IsElementPresent(obj_dashboard.FundSnapshotSection) + "Expected Value : true");
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_dashboard.FundSnapshotSection));

                Console.WriteLine("Asserting for RecentActivitySection to be present : Actual Value : " + Pages.BasicInteractions().IsElementPresent(obj_dashboard.RecentActivitySection) + "Expected Value : true");
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_dashboard.RecentActivitySection));

                Console.WriteLine("Asserting for Submit Button to be present : Actual Value : " + Pages.BasicInteractions().IsElementPresent(obj_dashboard.Submit) + "Expected Value : true");
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_dashboard.Submit));

                Pages.BasicInteractions().WaitVisible(obj_dashboard.LeftNavClaim);
                Pages.BasicInteractions().Click(obj_dashboard.LeftNavClaim);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.Dashboard_Landing().ValidateParticularButton("SUBMIT CLAIM");
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
                Pages.BasicInteractions().WaitVisible(obj_dashboard.LnkTotalClaimsCount_Pandora);
                Pages.BasicInteractions().WaitTime(5);
                Double TotalClaims = Convert.ToDouble(Pages.BasicInteractions().GetText(obj_dashboard.LnkTotalClaimsCount_Pandora));
                Double OpenClaims = Convert.ToDouble(Pages.BasicInteractions().GetText(obj_dashboard.LnkOpenClaimsCount_Pandora));
                Double ProcessedClaims = Convert.ToDouble(Pages.BasicInteractions().GetText(obj_dashboard.LnkProcessedClaimsCount_Pandora));

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
                //double TotalClaims = 0;
                Pages.BasicInteractions().WaitVisible(obj_dashboard.LnkOpenClaimsCount_Pandora);
                Pages.BasicInteractions().Click(obj_dashboard.LnkOpenClaimsCount_Pandora);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitVisible(obj_claims.TblCalimFirstRowClaimID);

                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.PendingReviewCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.ResubmittedCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.NeedsInformationCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.HoldCheckboxActive));
               
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
                //double TotalClaims = 0;
                Pages.BasicInteractions().WaitVisible(obj_dashboard.LnkProcessedClaimsCount_Pandora);
                Pages.BasicInteractions().Click(obj_dashboard.LnkProcessedClaimsCount_Pandora);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitVisible(obj_claims.TblCalimFirstRowClaimID);

                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.PaidCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.PendingPaymentCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.DeniedCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.ApprovedCheckboxActive));
               
                Console.WriteLine("Processed Claims Filter is working Correctly");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void NavigatingToDashBoard()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_transaction.Dashboard);
                Pages.BasicInteractions().Click(obj_transaction.Dashboard);
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.imgLoading);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }
        public void ValidateOpenClaimsFilter_Fundsnapshot()
        {
            try
            {
                //double TotalClaims = 0;
                Pages.BasicInteractions().WaitVisible(obj_dashboard.OpenClaims_Fundsnapshot);
                Pages.BasicInteractions().WaitTime(5);


                Pages.BasicInteractions().Click(obj_dashboard.OpenClaims_Fundsnapshot);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(10);


                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.PendingReviewCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.ResubmittedCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.NeedsInformationCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.HoldCheckboxActive));
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

        public void ValidateProcessedClaimsFilter_Fundsnapshot()
        {
            try
            {
                //double TotalClaims = 0;
                Pages.BasicInteractions().WaitVisible(obj_dashboard.ProcessedClaims_Fundsnapshot);
                Pages.BasicInteractions().WaitTime(5);


                Pages.BasicInteractions().Click(obj_dashboard.ProcessedClaims_Fundsnapshot);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(10);


                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.PaidCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.PendingPaymentCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.DeniedCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.ApprovedCheckboxActive));

                
                Console.WriteLine("Processed Claims Filter is working Correctly");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }
        public void SelectProgramName_Fundsnapshot(string ProgramName)
        {
            try
            {
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.imgLoadingSnapshot);
                if (Pages.BasicInteractions().IsElementDisplayed(obj_transaction.ProgramList(ProgramName)))
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_transaction.ProgramList(ProgramName));

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

            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }


        }
    }
}
