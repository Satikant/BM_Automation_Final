using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.Functions.Pandora;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CFM_PARALLEL.Tests.Coop.Pandora.PN_Regression
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Pandora_Regression : Base
    {

        public String BUSINESSUNIT = "Pandora";

        //private IWebDriver Driver;
        //Dashboard validating
        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_User_Dashboard()
        {
            IWebDriver Driver = null;
            try
            {
                ////Base bs = new Base();
                Driver = OpenBrowser();
                Console.WriteLine("Login in -------");
                BrowserURLLaunch b = new BrowserURLLaunch(Driver);
                b.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                Console.WriteLine("Login with CORPORATE");
                Common_Dashboard_Landing d = new Common_Dashboard_Landing(Driver);
                d.Dashboard_Common(BUSINESSUNIT);
CommonUtilities.Logout(Driver);       Driver.Quit();
                Thread.Sleep(5000);

                ////Base bcc = new Base();
                Driver = OpenBrowser();
                //  OpenBrowser()();
                BrowserURLLaunch bc = new BrowserURLLaunch(Driver);
                bc.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                Console.WriteLine("Login with LME");
                Common_Dashboard_Landing dc = new Common_Dashboard_Landing(Driver);
                dc.Dashboard_Common(BUSINESSUNIT);
                //Dashboard_Landing.Dashboard_Landing_User();
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }


        //Claim Creation
        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_ClaimCreation()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();

                PN_Claim pc = new PN_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                pc.ClaimCreation(Parameters.ClaimTotalActivityCost_Pandora);
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }




        //Claim Clone
        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_ClaimClone()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();
                PN_Claim pc = new PN_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                string ClaimID = pc.ClaimCreation(Parameters.ClaimTotalActivityCost_Pandora);

                pc.ClaimClone(ClaimID);

CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }


        //Claim Hold
        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_ClaimHold()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                PN_Claim pc = new PN_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                string ClaimID = pc.ClaimCreation(Parameters.ClaimTotalActivityCost_Pandora);

CommonUtilities.Logout(Driver);       Driver.Quit();
                Thread.Sleep(30000);

                //Login with Corporate User
                ////Base bs1 = new Base();
                Driver = OpenBrowser();
                PN_Claim pc1 = new PN_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pc1.ClaimPerformAction(ClaimID, "Hold");
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }


        //Claim Approval
        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_ClaimApprove()
        {
            IWebDriver Driver = null;
            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                PN_Claim pc = new PN_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                string ClaimID = pc.ClaimCreation(Parameters.ClaimTotalActivityCost_Pandora);
CommonUtilities.Logout(Driver);       Driver.Quit();

                Thread.Sleep(30000);
                //////Base bs1 = new Base();
                Driver=OpenBrowser();
                PN_Claim pc1 = new PN_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pc1.ClaimPerformAction(ClaimID, "Approve");
CommonUtilities.Logout(Driver);       Driver.Quit();

                //Again Login with LME for checking the status of Claim
                Thread.Sleep(10000);
                //Base bs1 = new Base();
                Driver = OpenBrowser();
                PN_Claim pc2 = new PN_Claim();
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                //Search Claim By ClaimID And GetStatus
                string ClaimStatus = pc2.SearchClaimAndGetStatus(ClaimID);
                Assert.AreEqual(ClaimStatus, "Approved");
                Console.WriteLine("The satatus of the calim after approval is  " + ClaimStatus);
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }


        //Claim need Change
        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_ClaimNeedChnage()
        {
            IWebDriver Driver = null;
            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                PN_Claim pc = new PN_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                string ClaimID = pc.ClaimCreation(Parameters.ClaimTotalActivityCost_Pandora);
CommonUtilities.Logout(Driver);       Driver.Quit();

                Thread.Sleep(30000);
                //Login with Corporate User

                //////Base bs1 = new Base();
                Driver=OpenBrowser();
                PN_Claim pc1 = new PN_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pc1.ClaimPerformAction(ClaimID, "Needs Change");
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }


        //Claim Approved
        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_ClaimDisApproved()
        {
            IWebDriver Driver = null;
            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                PN_Claim pc = new PN_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                string ClaimID = pc.ClaimCreation(Parameters.ClaimTotalActivityCost_Pandora);

CommonUtilities.Logout(Driver);       Driver.Quit();
                Thread.Sleep(30000);


                ////Base bs1 = new Base();
                //Login with Corporate User
                Driver=OpenBrowser();
                PN_Claim pc1 = new PN_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pc1.ClaimPerformAction(ClaimID, "Deny");
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }

        }


        [Test, NonParallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_Transaction_Accrual_Positive()
        {
            IWebDriver Driver = null;
            try
            {
                ////Base bs = new Base();
                //Launching Browser
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                PN_Transactions pt = new PN_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pt.Transaction_Accrual("FLAT", Parameters.Pandora_AccrualPositive_Amount);
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally { Driver_CleanUp(); }
        }


        [Test, NonParallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_Transaction_FundTransfer_Positive()
        {
            IWebDriver Driver = null;
            try
            {
                ////Base bs = new Base();
                //Launching Browser
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                PN_Transactions pt = new PN_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pt.Transaction_FundTransfer("FLAT", Parameters.Pandora_TransferPositive_Amount);
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }


        [Test, NonParallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_Transaction_Adjustment_Positive()
        {
            IWebDriver Driver = null;
            try
            {
                ////Base bs = new Base();
                //Launching Browser
                Driver = OpenBrowser();

                //Login with LME for Creating a Claim
                PN_Transactions pt = new PN_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pt.Transaction_Adjustment("FLAT", Parameters.Pandora_AccrualPositive_Amount);
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }


        [Test, NonParallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_Transaction_Accrual_Negative()
        {
            IWebDriver Driver = null;
            try
            {
                ////Base bs = new Base();
                //Launching Browser
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                PN_Transactions pt = new PN_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pt.Transaction_Accrual("FLAT", Parameters.Pandora_AccrualNegative_Amount);
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }




        [Test, NonParallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_Transaction_Adjustment_Negative()
        {
            IWebDriver Driver = null;
            try
            {
                ////Base bs = new Base();
                //Launching Browser
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                PN_Transactions pt = new PN_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pt.Transaction_Adjustment("FLAT", Parameters.Pandora_AccrualNegative_Amount);
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }



        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_ClaimAutoApprovalBelow5000()
        {
            IWebDriver Driver = null;
            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();

                PN_Claim pc = new PN_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                string ClaimID = pc.ClaimCreation(Parameters.ClaimTotalActivityCost_Pandora_Below5000);
                Thread.Sleep(20000);
                //Verifying the ClaimStatus
                string Status = pc.SearchClaimAndGetStatus(ClaimID);
                Assert.IsTrue(Status.ToUpper().Contains("Approve".ToUpper()));
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }

        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_FlatProgramCreationAndVerifyingOnMangoDB()
        {
            IWebDriver Driver = null;
            try
            {
                //////Base bs1 = new Base();
                Driver=OpenBrowser();
                PN_Claim pc1 = new PN_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                PN_ProgramManagement pm = new PN_ProgramManagement(Driver);
                pm.ProgramCreationAndVerifyingonMangoDB("Flat");
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }


        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_RollingProgramCreationAndVerifyingOnMangoDB()
        {
            IWebDriver Driver = null;

            try
            {
                //////Base bs1 = new Base();
                Driver=OpenBrowser();
                PN_Claim pc1 = new PN_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                PN_ProgramManagement pm = new PN_ProgramManagement(Driver);
                pm.ProgramCreationAndVerifyingonMangoDB("Rolling");
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }

        //Claim need Change
        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_ClaimResumitted()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                PN_Claim pc = new PN_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                string ClaimID = pc.ClaimCreation(Parameters.ClaimTotalActivityCost_Pandora);

CommonUtilities.Logout(Driver);       Driver.Quit();
                Thread.Sleep(30000);
                //Login with Corporate User
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                PN_Claim pc1 = new PN_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);


                pc1.ClaimPerformAction(ClaimID, "Needs Change");
CommonUtilities.Logout(Driver);       Driver.Quit();

                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bl3 = new BrowserURLLaunch(Driver);
                bl3.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                PN_Claim pc2 = new PN_Claim();
                string ResubmittedClaimID = pc2.ClaimResubmitted(ClaimID);
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }

        [Test, NonParallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_Transaction_Accrual_FlatProgram()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                //Launching Browser
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                PN_Transactions pt = new PN_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pt.Transaction_Accrual("FLAT", Parameters.Pandora_AccrualPositive_Amount);
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }

        [Test, NonParallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_Transaction_Accrual_RollingProgram()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                //Launching Browser
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                PN_Transactions pt = new PN_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pt.Transaction_Accrual("Rolling", Parameters.Pandora_AccrualPositive_Amount);
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }

        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_ProgramCreationValidatingAlltheFields()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                PN_ProgramManagement pm = new PN_ProgramManagement(Driver);

                //Checking all the field validation for Program Form
                pm.ProgramCreationValidatingAlltheFields();
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }


        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_ClaimDateValidation()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                PN_Claim pc = new PN_Claim();

                //Claim Date Validation
                pc.ClaimDateValidation();
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }

        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_ClaimApprovalPermissionsValidation()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                PN_Claim pc = new PN_Claim();
                string claimID = pc.ClaimCreation(Parameters.ClaimTotalActivityCost_Pandora);

                //Checking LME user has Approval Permission
                pc.ClaimApprovalPermissionValidation(claimID);
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }

        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_VerifyProgramDisplayingOnDashBoardforLMEUsers()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                PN_ProgramManagement pm = new PN_ProgramManagement(Driver);
                //Validate ProgramDisplay for LME users
                pm.validateProgramDisplayingforLMEUsersOnDashBoard(Parameters.Ace_ProgramName());

CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }


        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_VerifyFundsnapshotSectionForLMEUsers()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                PN_Transactions pt = new PN_Transactions(Driver);
                //Validate ProgramDisplay for LME users
                pt.ValidateFundRelatedEntriesonDashBoard();

CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }


        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_VerifyProgramDisplayingOnDashBoardforCORPORATEUsers()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                PN_ProgramManagement pm = new PN_ProgramManagement(Driver);
                //Validate ProgramDisplay for LME users
                pm.validateProgramDisplayingforLMEUsersOnDashBoard(Parameters.Ace_ProgramName());

CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }


        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_VerifyFundsnapshotSectionForCORPORATEUsers()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                PN_Transactions pt = new PN_Transactions(Driver);
                //Validate ProgramDisplay for LME users
                pt.ValidateFundRelatedEntriesonDashBoard();

CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }

        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_ValidatingProgramCreationNonAvailabilityForLMEUsers()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                PN_ProgramManagement pt = new PN_ProgramManagement(Driver);
                //Validate ProgramDisplay for LME users
                pt.VerifyProgramCreationPermissionNonAvailabilityForLMEUser();

CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }


        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_ValidatingTransactionsNonAvailabilityForLMEUsers()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                PN_Transactions pt = new PN_Transactions(Driver);
                //Validate Transaction permission Non availability for LME users
                pt.ValidateTransactionPermissionNonAvailabilityForLMEUsers();

CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }



        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_Claim_VerifyingApprovedAmountNotGreaterThanRequestedAmount()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                PN_Claim pc = new PN_Claim();
                CommonFunctions cf = new CommonFunctions();

                string claimID = pc.ClaimCreation(Parameters.ClaimTotalActivityCost_Pandora);
CommonUtilities.Logout(Driver);       Driver.Quit();
                //string claimID = "";
                Thread.Sleep(30000);

                ////Base bs1 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bc2 = new BrowserURLLaunch(Driver);
                bc2.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                PN_Claim pc2 = new PN_Claim();
                pc2.ClaimApprovalAmountValidation(claimID, "Approve", "34");
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }


        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_DashBoard_ClaimCountMatchingWithAdditionOfOpenAndProcessedClaims()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                PN_Dashboard pd = new PN_Dashboard();
                pd.ValidateClaimCountMatchingWithAdditionOfOpenAndProcessedClaims();
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }

        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_OpenClaimsFilterVerificationDashBoard()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                PN_Dashboard pd = new PN_Dashboard();

                pd.ValidateOpenClaimsFilterDashBoard();
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }

        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_ProcessedClaimsFilterVerificationDashBoard()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                PN_Dashboard pd = new PN_Dashboard();

                pd.ValidateProcessedClaimsFilterDashBoard();
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }

        [Test, NonParallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_Transaction_VerifyAccrualEntryInFundSnapShot()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                //Launching Browser
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                PN_Transactions pt = new PN_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pt.Transaction_Accrual("FLAT", Parameters.Pandora_AccrualPositive_Amount);
                PN_Claim pd = new PN_Claim();
                pd.NavigatingToDashBoard();
                pt.VerifyingAccrualEntryUnderDetailedReport();
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }


        [Test, NonParallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_Transaction_VerifyFundTransferEntryInFundSnapShot()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                //Launching Browser
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                PN_Transactions pt = new PN_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pt.Transaction_FundTransfer("FLAT", Parameters.Pandora_TransferPositive_Amount);
                PN_Claim pd = new PN_Claim();
                pd.NavigatingToDashBoard();
                pt.VerifyingTransferEntryUnderDetailedReport();
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }

        }


        [Test, NonParallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_Transaction_VerifyAdjustmentEntryInFundSnapShot()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                //Launching Browser
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                PN_Transactions pt = new PN_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                pt.Transaction_Adjustment("FLAT", Parameters.Pandora_AccrualPositive_Amount);
                PN_Claim pd = new PN_Claim();
                pd.NavigatingToDashBoard();
                pt.VerifyingAdjustmentEntryUnderDetailedReport();
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }

        [Test, Parallelizable]
        [Category("CFM_PANDORA_REGRESSION")]
        public void RT_TC_PN_ClaimCreation_Negative()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);
                PN_Claim pd = new PN_Claim();
                pd.ClaimCreation_Negative();
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }

        //Validating the Available Fund Reduction after Calim Creation
        [Test, NonParallelizable]
        [Category("CFM_PANDORA_REGRESSION")]

        public void ST_TC_PN_ClaimCreation_CheckingFunds()
        {
            IWebDriver Driver = null;
            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();
                PN_Transactions pt = new PN_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                PN_Dashboard pd = new PN_Dashboard();
                OBJ_Dashboard obj_dashboard = new OBJ_Dashboard();
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                PN_Claim pc = new PN_Claim();
                BasicInteractions bi = new BasicInteractions(Driver);
                //Get Available Funds Before Creating Claim
                string AvailableFundsBeforeClaimCreation = pt.GetAvailableFunds(Parameters.Pandora_ProgramName());

                //Creating Claim
                //string ClaimID = pc.ClaimCreation(Parameters.ClaimTotalActivityCost_Pandora, Parameters.ClaimRequestedAmount_Pandora);
                bi.WaitVisible(obj_dashboard.BtnSubmit);
                bi.Click(obj_dashboard.BtnSubmit);
                bi.WaitTime(2);
                bi.WaitVisible(obj_dashboard.BtnSubmitClaim);
                bi.Click(obj_dashboard.BtnSubmitClaim);
                bi.WaitTillNotVisible(obj_dashboard.ImgLoading);

                //Select store and Program

                pc.SelectStoreAndProgram_Claim();

                //Entering Details
                double ReqAmountConverted = pc.EnterDetails_Claim(Parameters.ClaimTotalActivityCost_Pandora);

                //Adding Attachment
                pc.AddingAttachment_Claim();
                //Verifying the Fund Deducted correctly

                //SubmitClaim
                string ClaimID = pc.SubmitClaim();
                Thread.Sleep(10000);

                //Navigating Back to DashBoard
                pd.NavigatingToDashBoard();
                string AvailableFindsAfterClaimCreation = pt.GetAvailableFunds(Parameters.Pandora_ProgramName());
                Assert.True(Convert.ToDouble(AvailableFindsAfterClaimCreation.Replace("$", "")) == (Convert.ToDouble(AvailableFundsBeforeClaimCreation.Replace("$", "")) - ReqAmountConverted));

                Console.WriteLine("Calim Requested Amount Deducted from Available Funds Correctly");
CommonUtilities.Logout(Driver);       Driver.Quit();
                Thread.Sleep(30000);
                //Base bs1 = new Base();
                Driver = OpenBrowser();
                PN_Claim pc1 = new PN_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT);

                double ClaimApprovedAmount = ReqAmountConverted - Convert.ToDouble(100);
                //Approve ClaimID 
                pc1.ClaimApprove(ClaimID, "Approve", "84", ClaimApprovedAmount.ToString());

CommonUtilities.Logout(Driver);       Driver.Quit();


                //Login with LME again to verify the Funds After Approval
                //Base bs2 = new Base();
                Driver = OpenBrowser();
                PN_Claim pc2 = new PN_Claim();
                PN_Transactions pt2 = new PN_Transactions(Driver);
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                //Get Funds After Approval
                string AvailableFundsAfterApproval = pt2.GetAvailableFunds(Parameters.Pandora_ProgramName());
                //verifying After Approval the remaining amount is added to Available Balance
                Assert.True(Convert.ToDouble(AvailableFundsAfterApproval.Replace("$", "")) == (Convert.ToDouble(AvailableFundsBeforeClaimCreation.Replace("$", "")) - ClaimApprovedAmount));
                Console.WriteLine("Calim Approval Amount Deducted from Available Funds Correctly");
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }

        }
    }
}
