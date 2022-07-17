using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Transactions;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace CFM_PARALLEL.PageObject.UI.Functions.Bobcat
{
    public class BC_Dashboard
    {

        public By ImgLoading { get { return By.Id("loading-image"); } }
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private OBJ_Transactions obj_transaction;

        public BC_Dashboard()
        {
            obj_dashboard = new OBJ_Dashboard();
            obj_claims = new OBJ_Claims();
            obj_transaction = new OBJ_Transactions();
        }

        public void ProgramValidation_AdminLevel()
        {
            try
            {
                Pages.Dashboard_Landing().ClickParticularValueSection("PROGRAMS");
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(10);
                Pages.Dashboard_Landing().ValidatePageLabelValues("Program Name");
                Pages.Dashboard_Landing().ValidatePageLabelValues("Description");
                Pages.Dashboard_Landing().ValidatePageLabelValues("Program Currency");
                Pages.Dashboard_Landing().ValidatePageLabelValues("Start Date");
                Pages.Dashboard_Landing().ValidatePageLabelValues("End Date");
                Pages.Dashboard_Landing().ValidatePageLabelValues("Upload Program Guidelines(max 5 attachments)");
            }
            catch (Exception ex)
            {


                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void DashBoard_Validation()
        {
            try
            {
                Pages.BrowserURLLaunch().Validate_Error_Messages();
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Activity Overview");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Co-op Claim Pre-Approvals");
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

                Pages.Dashboard_Landing().ClickParticularValueSection("CO-OP CLAIM PRE-APPROVALS");
                Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.Dashboard_Landing().ValidateParticularButton("Submit Co-op Claim Pre-Approval");

                Pages.Dashboard_Landing().ClickParticularValueSection("CLAIMS");
                Pages.BasicInteractions().WaitTillNotVisible(ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();
                Pages.Dashboard_Landing().ValidateParticularButton("SUBMIT CLAIM");

                Pages.Dashboard_Landing().ClickParticularValueSection("DASHBOARD");
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

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
                Console.WriteLine("Error Message: " + ex.Message);
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
                Assert.AreEqual(dashboardAvailableFund, viewDetailAvailableFund);

                if (!Pages.BasicInteractions().IsElementDisplayed(obj_dashboard.NewFundDetailFundOverview))
                {
                    Pages.BasicInteractions().Click(obj_dashboard.NewFundDetailSlideButton);
                    Pages.BasicInteractions().WaitVisible(obj_dashboard.NewFundDetailFundOverview);

                }

                Pages.BasicInteractions().WaitVisible(obj_dashboard.NewFundDetailStoreDropdown);
                Pages.BasicInteractions().Click(obj_dashboard.NewFundDetailStoreDropdown);
                Pages.BasicInteractions().WaitVisible(obj_dashboard.NewFundDetailStoreTextbox);
                Pages.BasicInteractions().Click(obj_dashboard.NewFundDetailStoreTextbox);
                Pages.BasicInteractions().Type(obj_dashboard.NewFundDetailStoreTextbox, Parameters.Bobcat_StoreName);

                Pages.BasicInteractions().WaitVisible(obj_transaction.DropdownOption_Transaction(Parameters.Bobcat_StoreName));
                Pages.BasicInteractions().Click(obj_transaction.DropdownOption_Transaction(Parameters.Bobcat_StoreName));
                Pages.BasicInteractions().WaitTime(2);

                Pages.BasicInteractions().Click(obj_dashboard.NewFundDetailApplyFilter);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Download Fund Overview");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Available Funds");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("TOTAL CREDITED");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Open Claims");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Approved Claims");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Paid Claims");
                Pages.Dashboard_Landing().ValidateParticularDivValueSection("Transaction Summary");

                Pages.BasicInteractions().Click(obj_dashboard.TranscationSummaryDropdown);
                Pages.BasicInteractions().Click(obj_transaction.DropdownOption_Transaction("Adjusted"));
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_dashboard.TranscationSummaryDropdown);
                Pages.BasicInteractions().Click(obj_transaction.DropdownOption_Transaction("Approved"));
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_dashboard.TranscationSummaryDropdown);
                Pages.BasicInteractions().Click(obj_transaction.DropdownOption_Transaction("Transferred"));
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_dashboard.TranscationSummaryDropdown);
                Pages.BasicInteractions().Click(obj_transaction.DropdownOption_Transaction("Open Claims"));
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_dashboard.TranscationSummaryDropdown);
                Pages.BasicInteractions().Click(obj_transaction.DropdownOption_Transaction("Approved Claims"));
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_dashboard.TranscationSummaryDropdown);
                Pages.BasicInteractions().Click(obj_transaction.DropdownOption_Transaction("Paid Claims"));
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                Pages.BasicInteractions().Click(obj_dashboard.TranscationSummaryDropdown);
                Pages.BasicInteractions().Click(obj_transaction.DropdownOption_Transaction("Expired"));
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                // old fund detail view
                /* Pages.BasicInteractions().Click(obj_dashboard.Moredetailslinktext);
                 Pages.BasicInteractions().WaitTime(5);
                 Pages.Dashboard_Landing().ValidateParticularDivValueSection("Download Fund Overview");
                 Pages.Dashboard_Landing().ValidateParticularDivValueSection("Download Excel");
                 Pages.Dashboard_Landing().ValidateParticularDivValueSection("Approved");
                 Pages.Dashboard_Landing().ValidateParticularDivValueSection("Adjusted");
                 Pages.Dashboard_Landing().ValidateParticularDivValueSection("Transferred");
                 Pages.Dashboard_Landing().ValidateParticularDivValueSection("Open Claims");
                 Pages.Dashboard_Landing().ValidateParticularDivValueSection("Approved Claims");
                 Pages.Dashboard_Landing().ValidateParticularDivValueSection("Paid Claims");
                 Pages.Dashboard_Landing().ValidateParticularDivValueSection("Expired");

                 Pages.Dashboard_Landing().ClickParticularValues("Adjusted");

                 Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                 Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                 Pages.Dashboard_Landing().ClickParticularValues("Transferred");
                 Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                 Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                 Pages.Dashboard_Landing().ClickParticularValues("Open Claims");
                 Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                 Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                 Pages.Dashboard_Landing().ClickParticularValues("Approved Claims");
                 Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                 Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                 Pages.Dashboard_Landing().ClickParticularValues("Paid Claims");
                 Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                 Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();

                 Pages.Dashboard_Landing().ClickParticularValues("Expired");
                 Pages.BasicInteractions().WaitTillNotVisible(imgLoading);
                 Pages.BrowserURLLaunch().Validate_Error_Messages_In_Widget();*/


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in FundSnapshot_Validation method: " + ex.Message);
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

        //Checking the Claims Count Matching on Dashboard
        public void ValidateClaimCountMatchingWithAdditionOfOpenAndProcessedClaims()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_dashboard.LnkTotalClaimsCount);
                Pages.BasicInteractions().WaitTime(5);
                Double TotalClaims = Convert.ToDouble(Pages.BasicInteractions().GetText(obj_dashboard.LnkTotalClaimsCount));
                Double OpenClaims = Convert.ToDouble(Pages.BasicInteractions().GetText(obj_dashboard.LnkOpenClaimsCount));
                Double ProcessedClaims = Convert.ToDouble(Pages.BasicInteractions().GetText(obj_dashboard.LnkProcessedClaimsCount));

                Assert.IsTrue(TotalClaims == (OpenClaims + ProcessedClaims));
                Console.WriteLine("Claims Count showing Correctly on Dashboard");

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
                Pages.BasicInteractions().WaitVisible(obj_dashboard.LnkOpenClaimsCount);
                Pages.BasicInteractions().Click(obj_dashboard.LnkOpenClaimsCount);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitVisible(obj_claims.TblCalimFirstRowClaimID);

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


        public void ValidateProcessedClaimsFilterDashBoard()
        {
            try
            {
                //double TotalClaims = 0;
                Pages.BasicInteractions().WaitVisible(obj_dashboard.LnkProcessedClaimsCount);
                Pages.BasicInteractions().Click(obj_dashboard.LnkProcessedClaimsCount);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitTillNotVisible(obj_claims.ImgLoadingClaim);
                Pages.BasicInteractions().WaitVisible(obj_claims.TblCalimFirstRowClaimID);

                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.PaidCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.PendingPaymentCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.DeniedCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.ApprovedCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.BrandBuilderPaidCheckboxActive));

                
                Console.WriteLine("Processed Claims Filter is working Correctly");

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
                //double TotalClaims = 0;
                Pages.BasicInteractions().WaitVisible(obj_dashboard.LnkOpenBPACount);
                Pages.BasicInteractions().Click(obj_dashboard.LnkOpenBPACount);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);

                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitVisible(obj_claims.TblCalimFirstRowClaimID);

                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.PendingReviewCheckboxActive));
                //Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.ResubmittedCheckboxActive));
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


        public void ValidateProcessedBPAFilterDashBoard()
        {

            try
            {
                //double TotalClaims = 0;
                Pages.BasicInteractions().WaitVisible(obj_dashboard.LnkProcessedBPACount);
                Pages.BasicInteractions().Click(obj_dashboard.LnkProcessedBPACount);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitVisible(obj_claims.TblCalimFirstRowClaimID);

                //Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.PaidCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.ClosedCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.DeniedCheckboxActive));
                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.ApprovedCheckboxActive));
                // Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_claims.BrandBuilderPaidCheckboxActive));

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
                Pages.BasicInteractions().WaitVisible(obj_dashboard.LnkTotalBPACount);
                Pages.BasicInteractions().WaitTime(5);
                Double TotalClaims = Convert.ToDouble(Pages.BasicInteractions().GetText(obj_dashboard.LnkTotalBPACount));
                Double OpenClaims = Convert.ToDouble(Pages.BasicInteractions().GetText(obj_dashboard.LnkOpenBPACount));
                Double ProcessedClaims = Convert.ToDouble(Pages.BasicInteractions().GetText(obj_dashboard.LnkProcessedBPACount));

                Assert.IsTrue(TotalClaims == (OpenClaims + ProcessedClaims));
                Console.WriteLine("Claims Count showing Correctly");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }
    }
}
