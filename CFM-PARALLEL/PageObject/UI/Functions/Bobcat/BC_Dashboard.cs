using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.Ace.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Transactions;
using CFM_PARALLEL.StartUp;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFM_PARALLEL.PageObject.UI.Functions.Bobcat
{
    public class BC_Dashboard
    {

        public By imgLoading { get { return By.Id("loading-image"); } }
        private IWebDriver Driver;
        private Base bs;
        private BrowserURLLaunch bl;
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private BasicInteractions bi;
        private Dashboard_Landing db;
        private OBJ_Transactions obj_transaction;
        public BC_Dashboard(IWebDriver Driver)
        {
            this.Driver = Driver;
            bs = new Base();
            bl = new BrowserURLLaunch(Driver);
            obj_dashboard = new OBJ_Dashboard();
            bi = new BasicInteractions(Driver);
            obj_claims = new OBJ_Claims();
            db = new Dashboard_Landing(Driver);
            obj_transaction = new OBJ_Transactions();
        }

        public void ProgramValidation_AdminLevel()
        {
            try
            {
                db.clickParticularValueSection("PROGRAMS");
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                //bi.Click(obj_dashboard.lnkNewProgram);
                //db.validatePageHeaderValues("New Program");
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTime(10);
                db.validatePageLabelValues("Program Name");
                db.validatePageLabelValues("Description");
                db.validatePageLabelValues("Program Currency");
                db.validatePageLabelValues("Start Date");
                db.validatePageLabelValues("End Date");
                db.validatePageLabelValues("Upload Program Guidelines(max 5 attachments)");
            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void DashBoardValidation_AdminLevel()
        {
            try
            {
                db.clickParticularValueSection("DASHBOARD");
                db.clickParticularValueSection1("Activity Overview");
                db.clickParticularValueSection1("Co-op Claim Pre-Approvals");
                db.clickParticularValueSection1("Total");
                db.clickParticularValueSection1("Open");
                db.clickParticularValueSection1("Processed");
                db.clickParticularValueSection1("Fund Snapshot");
                db.clickParticularValueSection1("Recent Activity");
                db.clickParticularValueSection1("View Detailed Report");


                db.clickParticularValueSection("PROGRAMS");
                db.clickParticularValueSection("TRANSACTION");
                db.clickParticularValueSection("CO-OP CLAIM PRE-APPROVALS");
                db.clickParticularValueSection("CLAIMS");



                db.clickParticularValueSection1("Dashboard");
                db.validateParticularButton("SEARCH");
                bi.Click(obj_dashboard.LeftNavPreapprovals);
                //db.validateParticularButton("SUBMIT BRAND PRE-APPROVAL");
                db.validateParticularButton("Submit Co-op Claim Pre-Approval");
                bi.Click(obj_dashboard.LeftNavClaim);
                bi.WaitTillNotVisible(imgLoading);
                db.validateParticularButton("SUBMIT CLAIM");
            }
            catch (Exception ex)
            {
            CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void FundSnapshotValidation_AdminLevel()
        {
            try
            {
                db.clickParticularValueSection("DASHBOARD");
                db.clickParticularValueSection1("Activity Overview");
                //db.clickParticularValueSection1("Co-op Claim Pre-Approvals");
                //db.clickParticularValueSection1("Total");
                //db.clickParticularValueSection1("Open");
                //db.clickParticularValueSection1("Processed");
                //db.clickParticularValueSection1("Fund Snapshot");
                //db.clickParticularValueSection1("Recent Activity");
                db.clickParticularValueSection1("View Detailed Report");

                bi.Click(obj_dashboard.viewDetailedReportLink);
                bi.WaitTime(18);
                bi.WaitTillNotVisible(imgLoading);
                bi.Click(obj_dashboard.moredetailslinktext);
                bi.WaitTime(3);
                db.clickParticularValueSection1("Download Fund Overview");
                db.clickParticularValueSection1("Download Excel");

                db.clickParticularValueSection1("Approved");
                db.clickParticularValueSection1("Adjusted");
                db.clickParticularValueSection1("Transferred");
                db.clickParticularValueSection1("Open Claims");
                db.clickParticularValueSection1("Approved Claims");
                db.clickParticularValueSection1("Paid Claims");
                db.clickParticularValueSection1("Expired");

                //db.clickParticularValues("Approved");
                //bi.WaitTillNotVisible(imgLoading);
                db.clickParticularValues("Adjusted");
                bi.WaitTillNotVisible(imgLoading);
                db.clickParticularValues("Transferred");
                bi.WaitTillNotVisible(imgLoading);
                db.clickParticularValues("Open Claims");
                bi.WaitTillNotVisible(imgLoading);
                db.clickParticularValues("Approved Claims");
                bi.WaitTillNotVisible(imgLoading);
                db.clickParticularValues("Paid Claims");
                bi.WaitTillNotVisible(imgLoading);
                db.clickParticularValues("Expired");
                bi.WaitTillNotVisible(imgLoading);

            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver); Driver.Quit();
                //CommonFunctions.KillProcess();

                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void NavigatingToDashBoard()
        {
            try
            {
                bi.WaitVisible(obj_transaction.Dashboard);
                bi.Click(obj_transaction.Dashboard);
                bi.WaitTillNotVisible(obj_transaction.imgLoading);
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();

                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //Checking the Claims Count Matching on Dashboard
        public void ValidateClaimCountMatchingWithAdditionOfOpenAndProcessedClaims()
        {
            try
            {
                bi.WaitVisible(obj_dashboard.lnkTotalClaimsCount);
                bi.WaitTime(5);
                Double TotalClaims = Convert.ToDouble(bi.GetText(obj_dashboard.lnkTotalClaimsCount));
                Double OpenClaims = Convert.ToDouble(bi.GetText(obj_dashboard.lnkOpenClaimsCount));
                Double ProcessedClaims = Convert.ToDouble(bi.GetText(obj_dashboard.lnkProcessedClaimsCount));

                Assert.IsTrue(TotalClaims == (OpenClaims + ProcessedClaims));
                Console.WriteLine("Claims Count showing Correctly on Dashboard");

            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();

                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void ValidateOpenClaimsFilterDashBoard()
        {
            try
            {
                //double TotalClaims = 0;
                bi.WaitVisible(obj_dashboard.lnkOpenClaimsCount);
                bi.Click(obj_dashboard.lnkOpenClaimsCount);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTime(5);

                bi.WaitVisible(obj_claims.tblCalimFirstRowClaimID);

                Assert.IsTrue(bi.IsElementPresent(obj_claims.PendingReviewCheckboxActive));
                Assert.IsTrue(bi.IsElementPresent(obj_claims.ResubmittedCheckboxActive));
                Assert.IsTrue(bi.IsElementPresent(obj_claims.NeedsInformationCheckboxActive));
                Assert.IsTrue(bi.IsElementPresent(obj_claims.HoldCheckboxActive));
                //Assert.IsTrue(bi.IsElementPresent(obj_claims.ResubmittedCheckbox));
                //Assert.IsTrue(bi.IsElementPresent(obj_claims.NeedsInformationCheckbox));
                Console.WriteLine("Open Claims Filter is working Correctly");

            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();

                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }


        public void ValidateProcessedClaimsFilterDashBoard()
        {
            try
            {
                //double TotalClaims = 0;
                bi.WaitVisible(obj_dashboard.lnkProcessedClaimsCount);
                bi.Click(obj_dashboard.lnkProcessedClaimsCount);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTime(5);
                bi.WaitTillNotVisible(obj_claims.imgLoadingClaim);
                bi.WaitVisible(obj_claims.tblCalimFirstRowClaimID);

                Assert.IsTrue(bi.IsElementPresent(obj_claims.PaidCheckboxActive));
                Assert.IsTrue(bi.IsElementPresent(obj_claims.PendingPaymentCheckboxActive));
                Assert.IsTrue(bi.IsElementPresent(obj_claims.DeniedCheckboxActive));
                Assert.IsTrue(bi.IsElementPresent(obj_claims.ApprovedCheckboxActive));
                Assert.IsTrue(bi.IsElementPresent(obj_claims.BrandBuilderPaidCheckboxActive));

                //Assert.IsTrue(bi.IsElementPresent(obj_claims.PaidCheckbox));
                //Assert.IsTrue(bi.IsElementPresent(obj_claims.PendingPaymentCheckbox));
                //Assert.IsTrue(bi.IsElementPresent(obj_claims.DeniedCheckbox));
                //Assert.IsTrue(bi.IsElementPresent(obj_claims.ApprovedCheckbox));
                Console.WriteLine("Processed Claims Filter is working Correctly");

            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();

                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }


        public void ValidateOpenBPAFilterDashBoard()
        {
            //BasicInteractions bi = new BasicInteractions(Driver);
            //OBJ_Claims obj_claims = new OBJ_Claims();
            //OBJ_Dashboard obj_dashboard = new OBJ_Dashboard();

            try
            {
                //double TotalClaims = 0;
                bi.WaitVisible(obj_dashboard.lnkOpenBPACount);
                bi.Click(obj_dashboard.lnkOpenBPACount);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                
                bi.WaitTime(5);

                bi.WaitVisible(obj_claims.tblCalimFirstRowClaimID);

                Assert.IsTrue(bi.IsElementPresent(obj_claims.PendingReviewCheckboxActive));
                //Assert.IsTrue(bi.IsElementPresent(obj_claims.ResubmittedCheckboxActive));
                Assert.IsTrue(bi.IsElementPresent(obj_claims.NeedsInformationCheckboxActive));
                Assert.IsTrue(bi.IsElementPresent(obj_claims.HoldCheckboxActive));
                //Assert.IsTrue(bi.IsElementPresent(obj_claims.ResubmittedCheckbox));
                //Assert.IsTrue(bi.IsElementPresent(obj_claims.NeedsInformationCheckbox));
                Console.WriteLine("Open Claims Filter is working Correctly");

            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();

                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }


        public void ValidateProcessedBPAFilterDashBoard()
        {
            //BasicInteractions bi = new BasicInteractions(Driver);
            //OBJ_Claims obj_claims = new OBJ_Claims();
            //OBJ_Dashboard obj_dashboard = new OBJ_Dashboard();
            try
            {
                //double TotalClaims = 0;
                bi.WaitVisible(obj_dashboard.lnkProcessedBPACount);
                bi.Click(obj_dashboard.lnkProcessedBPACount);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTime(5);

                bi.WaitVisible(obj_claims.tblCalimFirstRowClaimID);

                //Assert.IsTrue(bi.IsElementPresent(obj_claims.PaidCheckboxActive));
                Assert.IsTrue(bi.IsElementPresent(obj_claims.ClosedCheckboxActive));
                Assert.IsTrue(bi.IsElementPresent(obj_claims.DeniedCheckboxActive));
                Assert.IsTrue(bi.IsElementPresent(obj_claims.ApprovedCheckboxActive));
                // Assert.IsTrue(bi.IsElementPresent(obj_claims.BrandBuilderPaidCheckboxActive));

                Console.WriteLine("Processed Claims Filter is working Correctly");

            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();

                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //Checking the Claims Count Matching on Dashboard
        public void ValidateBPACountMatchingWithAdditionOfOpenAndProcessedClaims()
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            OBJ_Claims obj_claims = new OBJ_Claims();
            OBJ_Dashboard obj_dashboard = new OBJ_Dashboard();
            try
            {
                bi.WaitVisible(obj_dashboard.lnkTotalBPACount);
                bi.WaitTime(5);
                Double TotalClaims = Convert.ToDouble(bi.GetText(obj_dashboard.lnkTotalBPACount));
                Double OpenClaims = Convert.ToDouble(bi.GetText(obj_dashboard.lnkOpenBPACount));
                Double ProcessedClaims = Convert.ToDouble(bi.GetText(obj_dashboard.lnkProcessedBPACount));

                Assert.IsTrue(TotalClaims == (OpenClaims + ProcessedClaims));
                Console.WriteLine("Claims Count showing Correctly");

            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();

                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }
    }
}
