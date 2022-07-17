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

namespace CFM_PARALLEL.PageObject.UI.Functions.Pandora
{
    public class PN_Dashboard
    {
        private IWebDriver Driver;
        private Base bs;
        private BrowserURLLaunch bl;
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private BasicInteractions bi;
        private Dashboard_Landing db;
        private OBJ_Transactions obj_transaction;
        public PN_Dashboard(IWebDriver Driver)
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
                bi.WaitTime(20);

                bi.WaitUntilElementVisible(obj_dashboard.Programlabel, 5);
                bi.WaitUntilElementVisible(obj_dashboard.active, 5);
                bi.WaitUntilElementVisible(obj_dashboard.open, 5);
                bi.WaitUntilElementVisible(obj_dashboard.inactive, 5);
                bi.WaitUntilElementVisible(obj_dashboard.closed, 5);
                //bi.Click(obj_dashboard.lnkNewProgram);
                ////db.validatePageHeaderValues("New Program");
                //bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                //bi.WaitTime(10);
                //db.validatePageLabelValues("Program Name");
                //db.validatePageLabelValues("Description");
                //db.validatePageLabelValues("Program Currency");
                //db.validatePageLabelValues("Start Date");
                //db.validatePageLabelValues("End Date");
                //db.validatePageLabelValues("Upload Program Guidelines(max 5 attachments)");
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
                db.validatePageHeaderValues("Dashboard");
                bi.WaitTime(10);
                db.validateParticularButton("SEARCH");
                //bi.Click(obj_dashboard.LeftNavPreapprovals);
                //db.validateParticularButton("SUBMIT BRAND PRE-APPROVAL");
                bi.Click(obj_dashboard.LeftNavClaim);
                bi.WaitTime(10);
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

        //Checking the Claims Count Matching on Dashboard
        public void ValidateClaimCountMatchingWithAdditionOfOpenAndProcessedClaims()
        {
            try
            {
                bi.WaitVisible(obj_dashboard.lnkTotalClaimsCount_Pandora);
                bi.WaitTime(5);
                Double TotalClaims = Convert.ToDouble(bi.GetText(obj_dashboard.lnkTotalClaimsCount_Pandora));
                Double OpenClaims = Convert.ToDouble(bi.GetText(obj_dashboard.lnkOpenClaimsCount_Pandora));
                Double ProcessedClaims = Convert.ToDouble(bi.GetText(obj_dashboard.lnkProcessedClaimsCount_Pandora));

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


        //public void ValidateTotalClaimsCountMatchingWithDashBoardTotalClaims()
        //{
        //    try
        //    {
        //        double TotalClaims = 0;
        //        bi.WaitVisible(obj_dashboard.lnkTotalClaimsCount);


        //        //Getting the Total Claims Count From DashBoard
        //        Double TotalClaims_DashBoard = Convert.ToDouble(bi.GetText(obj_dashboard.lnkTotalClaimsCount));

        //        bi.Click(obj_dashboard.lnkTotalClaimsCount);
        //        bi.WaitTillNotVisible(obj_dashboard.imgLoading);
        //        bi.WaitTime(5);

        //        bi.WaitVisible(obj_claims.tblCalimFirstRowClaimID);
        //        while (bi.IsElementEnabled(obj_claims.PaginationRight))
        //        {
        //            bi.WaitTillNotVisible(obj_claims.imgLoadingClaim);
        //            double rows = bi.getElements(obj_claims.tblRowsCurrentPage).Count;
        //            TotalClaims = TotalClaims + rows;
        //            bi.ClickJavaScript(obj_claims.PaginationRight);
        //        }

        //        Assert.AreEqual(TotalClaims, TotalClaims_DashBoard);
        //        Console.WriteLine("Application Showing Total Claims Count Correctly on DashBoard");
        //    }
        //    catch (Exception ex)
        //    {
        //                        CommonUtilities.Logout(Driver);       Driver.Quit();;
        //          //CommonFunctions.KillProcess();

        //        Console.WriteLine("Error Message: " + ex.Message);
        //        throw;
        //    }
        //}

        public void ValidateOpenClaimsFilterDashBoard()
        {
            try
            {
                //double TotalClaims = 0;
                bi.WaitVisible(obj_dashboard.lnkOpenClaimsCount_Pandora);
                bi.Click(obj_dashboard.lnkOpenClaimsCount_Pandora);
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
                bi.WaitVisible(obj_dashboard.lnkProcessedClaimsCount_Pandora);
                bi.Click(obj_dashboard.lnkProcessedClaimsCount_Pandora);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTime(5);

                bi.WaitVisible(obj_claims.tblCalimFirstRowClaimID);

                Assert.IsTrue(bi.IsElementPresent(obj_claims.PaidCheckboxActive));
                Assert.IsTrue(bi.IsElementPresent(obj_claims.PendingPaymentCheckboxActive));
                Assert.IsTrue(bi.IsElementPresent(obj_claims.DeniedCheckboxActive));
                Assert.IsTrue(bi.IsElementPresent(obj_claims.ApprovedCheckboxActive));
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
        public void ValidateOpenClaimsFilter_Fundsnapshot()
        {
            try
            {
                //double TotalClaims = 0;
                bi.WaitVisible(obj_dashboard.OpenClaims_Fundsnapshot);
                bi.WaitTime(5);


                bi.Click(obj_dashboard.OpenClaims_Fundsnapshot);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTime(10);


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
                Driver.Quit();
                //CommonFunctions.KillProcess();

                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public void ValidateProcessedClaimsFilter_Fundsnapshot()
        {
            try
            {
                //double TotalClaims = 0;
                bi.WaitVisible(obj_dashboard.ProcessedClaims_Fundsnapshot);
                bi.WaitTime(5);


                bi.Click(obj_dashboard.ProcessedClaims_Fundsnapshot);
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTime(10);


                Assert.IsTrue(bi.IsElementPresent(obj_claims.PaidCheckboxActive));
                Assert.IsTrue(bi.IsElementPresent(obj_claims.PendingPaymentCheckboxActive));
                Assert.IsTrue(bi.IsElementPresent(obj_claims.DeniedCheckboxActive));
                Assert.IsTrue(bi.IsElementPresent(obj_claims.ApprovedCheckboxActive));

                // Assert.IsTrue(bi.IsElementPresent(obj_claims.PaidCheckbox));
                // Assert.IsTrue(bi.IsElementPresent(obj_claims.PendingPaymentCheckbox));
                // Assert.IsTrue(bi.IsElementPresent(obj_claims.DeniedCheckbox));
                // Assert.IsTrue(bi.IsElementPresent(obj_claims.ApprovedCheckbox));
                Console.WriteLine("Processed Claims Filter is working Correctly");
            }
            catch (Exception ex)
            {
                Driver.Quit();
                //CommonFunctions.KillProcess();

                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }
        public void SelectProgramName_Fundsnapshot(string ProgramName)
        {
            try
            {
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTillNotVisible(obj_transaction.imgLoadingSnapshot);
                if (bi.IsElementDisplayed(obj_transaction.ProgramList(ProgramName)))
                {
                    bi.WaitTime(5);
                    bi.Click(obj_transaction.ProgramList(ProgramName));

                }
                else
                {
                    bi.WaitTime(5);
                    bi.WaitVisible(obj_transaction.OtherProgramsLink);
                    bi.Click(obj_transaction.OtherProgramsLink);
                    bi.WaitTime(5);
                    bi.Click(obj_transaction.ProgramList(ProgramName));
                }
                bi.WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                bi.WaitTime(5);

            }

            catch (Exception ex)
            {
                Driver.Quit();
                //CommonFunctions.KillProcess();
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }


        }
    }
}
