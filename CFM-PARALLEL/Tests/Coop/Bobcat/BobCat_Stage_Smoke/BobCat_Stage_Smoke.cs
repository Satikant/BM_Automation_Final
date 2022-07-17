using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.Ace.Dashboard;
using CFM_PARALLEL.PageObject.UI.Functions;
using CFM_PARALLEL.PageObject.UI.Functions.Bobcat;
using CFM_PARALLEL.PageObject.UI.Functions.Pandora;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace CFM_PARALLEL.Tests.Coop.Bobcat
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures)]
    public class BobCat_Stage_Smoke : Base
    {
        public string BUSINESSUNIT = "Bobcat";

        [Test, Parallelizable]
        [Category("CFM_BOBCAT_SMOKE_STAGE")]
        public void ST_TC_BC_CoopAdaptorFlow_STAGE()
        {
            String TemplateName = "Business card";
            IWebDriver Driver = null;
            try
            {
                //Base bs1 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                Dashboard_Landing dl = new Dashboard_Landing();
                BC_CoopAdaptor bc = new BC_CoopAdaptor();
                CommonFunctions cf = new CommonFunctions();
                //Calculate Amounts Before going to use Coop Adaptor
                //IDictionary<String, Double> FundsBeforeUsingCoopAdaptor = dl.GetAllTheFunds("2019 Compact Tractor");

                ////Clear Shopping cart
                cf.ClearShoppingCart();
                Thread.Sleep(5000);
                cf.NavigatingBackFromShoppingCart();
                //Search Template
                cf.SearchTemplate(TemplateName);
                //Building Template
                cf.BuildTemplateAndAddToCart_Bobcat(TemplateName);
                //place Order
                cf.PlaceOrder_NewCheckout();
            }
            catch (Exception ex)
            {
                //                 CommonUtilities.Logout(Driver);       Driver.Quit();;
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
        [Category("CFM_BOBCAT_SMOKE_STAGE")]

        public void ST_TC_BC_ClaimCreation_CheckingFunds()
        {
            IWebDriver Driver = null;
            string Invoice = CommonUtilities.RandomInvoice("Invoice");
            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();
                BasicInteractions bi = new BasicInteractions(Driver);

                OBJ_Dashboard obj_dashboard = new OBJ_Dashboard();
                BC_Claim pc = new BC_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");

                BC_Claim bc = new BC_Claim();
                BC_Transactions bt = new BC_Transactions(Driver);
                BC_Dashboard bd = new BC_Dashboard();
                //Get Available Funds Before Creating Claim
                string AvailableFundsBeforeClaimCreation = bt.GetAvailableFunds(Parameters.Bobcat_ProgramName());

                //Creating Claim
                bi.WaitVisible(obj_dashboard.BtnSubmit);
                bi.Click(obj_dashboard.BtnSubmit);
                bi.WaitTime(2);
                bi.WaitVisible(obj_dashboard.BtnSubmitClaim);
                bi.Click(obj_dashboard.BtnSubmitClaim);
                bi.WaitTillNotVisible(obj_dashboard.ImgLoading);


                pc.SelectStoreAndProgram_Claim("N", null);

                //Entering Details
                decimal RequestedAmount = pc.EnterDetails_Claim("N");

                //Adding Attachment
                pc.AddingAttachment_Claim(Invoice);

                //SubmitClaim
                string ClaimID = pc.SubmitClaim();

                //Verifying the Fund Deducted correctly
                //Navigating Back to DashBoard
                bd.NavigatingToDashBoard();

                Thread.Sleep(10000);
                string AvailableFindsAfterClaimCreation = bt.GetAvailableFunds(Parameters.Bobcat_ProgramName());
                Assert.True(Convert.ToDouble(AvailableFindsAfterClaimCreation.Replace("$", "")) == (Convert.ToDouble(AvailableFundsBeforeClaimCreation.Replace("$", "")) - Convert.ToDouble(RequestedAmount)));

                Console.WriteLine("Calim Requested Amount Deducted from Available Funds Correctly");
                CommonUtilities.Logout(Driver); Driver.Quit();

                //bi.WaitTime(30000);


                Thread.Sleep(30000);
                //Base bs1 = new Base();
                Driver = OpenBrowser();
                BC_Claim pc1 = new BC_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Approve ClaimID 
                decimal ClaimApproveAmount = (RequestedAmount - 100);
                pc1.ClaimApprove(ClaimID, "Approve", "173", ClaimApproveAmount.ToString());
                CommonUtilities.Logout(Driver); Driver.Quit();


                //Login with LME again to verify the Funds After Approval
                //Base bs2 = new Base();
                Driver = OpenBrowser();
                BC_Claim pc2 = new BC_Claim();
                BC_Transactions pt2 = new BC_Transactions(Driver);
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Get Funds After Approval
                string AvailableFundsAfterApproval = pt2.GetAvailableFunds(Parameters.Bobcat_ProgramName());
                //verifying After Approval the remaining amount is added to Available Balance
                Assert.True(Convert.ToDouble(AvailableFundsAfterApproval.Replace("$", "")) == (Convert.ToDouble(AvailableFundsBeforeClaimCreation.Replace("$", "")) - Convert.ToDouble(ClaimApproveAmount)));
                Console.WriteLine("Calim Approval Amount Deducted from Available Funds Correctly");
                CommonUtilities.Logout(Driver); Driver.Quit();
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
        [Category("CFM_BOBCAT_SMOKE_STAGE")]
        public void ST_TC_BC_Transaction_Accrual()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs = new Base();
                //Launching Browser
                Driver = OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Transactions bt = new BC_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                bt.Transaction_Accrual("FLAT", Parameters.Bobcat_AccrualPositive_Amount);
                CommonUtilities.Logout(Driver); Driver.Quit();
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
        [Category("CFM_BOBCAT_SMOKE_STAGE")]
        public void ST_TC_BC_Transaction_FundTransfer()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs = new Base();
                //Launching Browser
                Driver = OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Transactions bt = new BC_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                bt.Transaction_FundTransfer("FLAT", Parameters.Bobcat_TransferPositive_Amount);
                CommonUtilities.Logout(Driver); Driver.Quit();
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
        [Category("CFM_BOBCAT_SMOKE_STAGE")]
        public void ST_TC_BC_Transaction_Adjustment()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs = new Base();
                //Launching Browser
                Driver = OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Transactions bt = new BC_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                bt.Transaction_Adjustment("FLAT", Parameters.Bobcat_AccrualPositive_Amount);
                CommonUtilities.Logout(Driver); Driver.Quit();
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
        [Category("CFM_BOBCAT_SMOKE_STAGE")]
        public void ST_TC_BC_BPA_Clone()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();

                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");

                //Creating BPAID
                string BPAID = pc.BPACreation();

                //Cloning the recently created BPA
                pc.BPAClone(BPAID);
                CommonUtilities.Logout(Driver); Driver.Quit();
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

        //BPA HOLD
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_SMOKE_STAGE")]
        public void ST_TC_BC_BPA_HOLD()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();
                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                string BPAID = pc.BPACreation();
                CommonUtilities.Logout(Driver); Driver.Quit();


                //Base bs1 = new Base();
                Driver = OpenBrowser();
                BC_BPA pc1 = new BC_BPA();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Cloning the recently created BPA
                pc1.BPAPerformActionAndVerify(BPAID, "Hold");
                CommonUtilities.Logout(Driver); Driver.Quit();

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
        [Category("CFM_BOBCAT_SMOKE_STAGE")]
        public void ST_TC_BC_BPA_Approved()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();
                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                string BPAID = pc.BPACreation();

                CommonUtilities.Logout(Driver); Driver.Quit();


                //Base bs1 = new Base();
                Driver = OpenBrowser();
                BC_BPA pc1 = new BC_BPA();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Cloning the recently created BPA
                pc1.BPAPerformActionAndVerify(BPAID, "Approve");

                CommonUtilities.Logout(Driver); Driver.Quit();

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
        [Category("CFM_BOBCAT_SMOKE_STAGE")]
        public void ST_TC_BC_BPA_DisApproved()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();
                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                string BPAID = pc.BPACreation();
                CommonUtilities.Logout(Driver); Driver.Quit();


                //Base bs1 = new Base();
                Driver = OpenBrowser();
                BC_BPA pc1 = new BC_BPA();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Cloning the recently created BPA
                pc1.BPAPerformActionAndVerify(BPAID, "Deny");
                CommonUtilities.Logout(Driver); Driver.Quit();

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
        [Category("CFM_BOBCAT_SMOKE_STAGE")]
        public void ST_TC_BC_BPA_NeedChange()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();
                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                string BPAID = pc.BPACreation();
                CommonUtilities.Logout(Driver); Driver.Quit();


                //Base bs1 = new Base();
                Driver = OpenBrowser();
                BC_BPA pc1 = new BC_BPA();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Cloning the recently created BPA
                pc1.BPAPerformActionAndVerify(BPAID, "Needs Change");
                CommonUtilities.Logout(Driver); Driver.Quit();

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
        //Claim Hold
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_SMOKE_STAGE")]
        public void ST_TC_BC_ClaimHold()
        {
            IWebDriver Driver = null;
            string Invoice = CommonUtilities.RandomInvoice("Invoice");

            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Claim pc = new BC_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                string ClaimID = pc.ClaimCreation("N", null, Invoice);
                CommonUtilities.Logout(Driver); Driver.Quit();
                Thread.Sleep(30000);

                //Login with Corporate User
                //Base bs1 = new Base();
                Driver = OpenBrowser();
                PN_Claim pc1 = new PN_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                pc1.ClaimPerformAction(ClaimID, "Hold");
                CommonUtilities.Logout(Driver); Driver.Quit();
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

        //Claim Approve
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_SMOKE_STAGE")]
        public void ST_TC_BC_ClaimApprove_WithDuplicateInvoiceCheck()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Claim pc = new BC_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                string ClaimID = pc.ClaimCreation();
                CommonUtilities.Logout(Driver); Driver.Quit();
                Thread.Sleep(30000);

                //Login with Corporate User
                //Base bs1 = new Base();
                Driver = OpenBrowser();
                PN_Claim pc1 = new PN_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                pc1.ClaimPerformAction(ClaimID, "Approve");
                CommonUtilities.Logout(Driver); Driver.Quit();

                //Again Login with LME for checking the status of Claim
                Thread.Sleep(10000);
                ////Base bs1 = new Base();
                Driver = OpenBrowser();
                BC_Claim pc2 = new BC_Claim();
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                string ClaimStatus = pc2.SearchClaimAndGetStatus(ClaimID);
                Assert.AreEqual(ClaimStatus, "Approved");
                Console.WriteLine("The satatus of the calim after approval is  " + ClaimStatus);
                CommonUtilities.Logout(Driver); Driver.Quit();
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

        //Claim disApprove
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_SMOKE_STAGE")]
        public void ST_TC_BC_ClaimDeny()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Claim pc = new BC_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                string ClaimID = pc.ClaimCreation();
                CommonUtilities.Logout(Driver); Driver.Quit();

                Thread.Sleep(30000);
                //Login with Corporate User
                //Base bs1 = new Base();
                Driver = OpenBrowser();
                PN_Claim pc1 = new PN_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                pc1.ClaimPerformAction(ClaimID, "Deny");
                CommonUtilities.Logout(Driver); Driver.Quit();
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

        //Claim NeedsChange
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_SMOKE_STAGE")]
        public void ST_TC_BC_ClaimNeedsChange()
        {
            IWebDriver Driver = null;
            string Invoice = CommonUtilities.RandomInvoice("Invoice");

            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Claim pc = new BC_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                string ClaimID = pc.ClaimCreation("N", null, Invoice);
                CommonUtilities.Logout(Driver); Driver.Quit();
                Thread.Sleep(30000);
                //Login with Corporate User
                //Base bs1 = new Base();
                Driver = OpenBrowser();
                PN_Claim pc1 = new PN_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                pc1.ClaimPerformAction(ClaimID, "Needs Change");
                CommonUtilities.Logout(Driver); Driver.Quit();
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
        [Category("CFM_BOBCAT_SMOKE_STAGE")]
        public void ST_TC_BC_ClaimResubmitted()
        {
            IWebDriver Driver = null;
            string Invoice = CommonUtilities.RandomInvoice("Invoice");

            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Claim pc = new BC_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                string ClaimID = pc.ClaimCreation("N", null, Invoice);
                CommonUtilities.Logout(Driver); Driver.Quit();
                Thread.Sleep(30000);

                //Login with Corporate User
                //Base bs1 = new Base();
                Driver = OpenBrowser();
                BC_Claim pc1 = new BC_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                pc1.ClaimPerformAction(ClaimID, "Needs Change");
                CommonUtilities.Logout(Driver); Driver.Quit();

                //Base bs3 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl3 = new BrowserURLLaunch(Driver);
                bl3.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                BC_Claim pc2 = new BC_Claim();
                string ResubmittedClaimID = pc2.ClaimResubmitted(ClaimID);
                CommonUtilities.Logout(Driver); Driver.Quit();
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
        [Category("CFM_BOBCAT_SMOKE_STAGE")]
        public void ST_TC_BC_ClaimClone()
        {
            string Invoice = CommonUtilities.RandomInvoice("Invoice");
            IWebDriver Driver = null;

            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();
                BC_Claim pc = new BC_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                string ClaimID = pc.ClaimCreation();
                pc.ClaimClone(ClaimID, Invoice);
                CommonUtilities.Logout(Driver); Driver.Quit();
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


        //Claim With BPA
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_SMOKE_STAGE")]
        public void ST_TC_BC_ClaimWithBPA()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();
                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                string BPAID = pc.BPACreation();
                CommonUtilities.Logout(Driver); Driver.Quit();


                //Base bs1 = new Base();
                Driver = OpenBrowser();
                BC_BPA pc1 = new BC_BPA();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Cloning the recently created BPA
                pc1.BPAPerformActionAndVerify(BPAID, "Approve");
                CommonUtilities.Logout(Driver); Driver.Quit();

                //Base bs2 = new Base();
                Driver = OpenBrowser();
                BC_Claim pc2 = new BC_Claim();
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Claim Creation with BPA
                string ClaimID = pc2.ClaimCreation("Y", BPAID, "Claim-Invoice-1234");

                CommonUtilities.Logout(Driver);
                Driver.Quit();
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
        [Category("CFM_BOBCAT_SMOKE_STAGE")]
        public void ST_TC_BC_User_Dashboard()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs = new Base();
                Driver = OpenBrowser();
                //OpenBrowser()();
                //log4net.Config.XmlConfigurator.Configure();
                //ILog logger = LogManager.GetLogger(typeof(Dashboard_Landing));

                Console.WriteLine("Login in -------");
                BrowserURLLaunch b = new BrowserURLLaunch(Driver);
                BasicInteractions bi = new BasicInteractions(Driver);
                b.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                Console.WriteLine("Login with CORPORATE");
                Dashboard_Landing d = new Dashboard_Landing();
                d.Dashboard_Landing_User();
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                Thread.Sleep(5000);

                //Base bcc = new Base();
                Driver = OpenBrowser();
                //  OpenBrowser()();
                BrowserURLLaunch bc = new BrowserURLLaunch(Driver);
                bc.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                Console.WriteLine("Login with LME");
                Dashboard_Landing dc = new Dashboard_Landing();
                dc.Dashboard_Landing_User();
                //Dashboard_Landing.Dashboard_Landing_User();
                CommonUtilities.Logout(Driver);
                Driver.Quit();
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
