using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.Ace.Dashboard;
using CFM_PARALLEL.PageObject.UI.Functions;
using CFM_PARALLEL.PageObject.UI.Functions.Bobcat;
using CFM_PARALLEL.PageObject.UI.Functions.Pandora;
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

namespace CFM_PARALLEL.Tests.Coop.Bobcat
{

    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class BobCat_Regression :Base
    {
        public string BUSINESSUNIT = "Bobcat";

        [Test, Parallelizable]
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_CoopAdaptorFlow_STAGE()
        {
            IWebDriver Driver = null;
            String TemplateName = "Business card";
            try
            {
                ////Base bs1 = new Base();
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
                cf.NavigatingBackFromShoppingCart();
                //Search Template
                cf.SearchTemplate(TemplateName);
                //Building Template
                cf.BuildTemplateAndAddToCart_Bobcat(TemplateName);
                //place Order
                cf.PlaceOrder_NewCheckout();

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
        //Claim Creation
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ClaimCreation()
        {
            string Invoice = CommonUtilities.RandomInvoice("Invoice");
            IWebDriver Driver = null;


            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();

                BC_Claim pc = new BC_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                pc.ClaimCreation("N", null, Invoice);
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ClaimCreation_CheckingFunds()
        {
            string Invoice = CommonUtilities.RandomInvoice("Invoice");
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();

                BC_Claim pc = new BC_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");

                BC_Claim bc = new BC_Claim();
                BC_Transactions bt = new BC_Transactions(Driver);
                BC_Dashboard bd = new BC_Dashboard();
                //Get Available Funds Before Creating Claim
                string AvailableFundsBeforeClaimCreation = bt.GetAvailableFunds(Parameters.Bobcat_ProgramName());

                //Creating Claim
                string ClaimID = bc.ClaimCreation("N", null, Invoice);

                //Verifying the Fund Deducted correctly
                //Navigating Back to DashBoard
                bd.NavigatingToDashBoard();

                Thread.Sleep(10000);
                string AvailableFindsAfterClaimCreation = bt.GetAvailableFunds(Parameters.Bobcat_ProgramName());
                Assert.True(Convert.ToDouble(AvailableFindsAfterClaimCreation.Replace("$", "")) == (Convert.ToDouble(AvailableFundsBeforeClaimCreation.Replace("$", "")) - Convert.ToDouble(Parameters.ClaimRequestedAmount_Bobcat.Replace("$", ""))));

                Console.WriteLine("Calim Requested Amount Deducted from Available Funds Correctly");
CommonUtilities.Logout(Driver);       Driver.Quit();

                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BC_Claim pc1 = new BC_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Approve ClaimID 
                pc1.ClaimApprove(ClaimID, "Approve", "173", Parameters.ClaimApprovalAmount_Bobcat);

CommonUtilities.Logout(Driver);       Driver.Quit();


                //Login with LME again to verify the Funds After Approval
                ////Base bs2 = new Base();
                Driver=OpenBrowser();
                BC_Claim pc2 = new BC_Claim();
                BC_Transactions pt2 = new BC_Transactions(Driver);
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Get Funds After Approval
                string AvailableFundsAfterApproval = pt2.GetAvailableFunds(Parameters.Bobcat_ProgramName());
                //verifying After Approval the remaining amount is added to Available Balance
                Assert.True(Convert.ToDouble(AvailableFundsAfterApproval.Replace("$", "")) == (Convert.ToDouble(AvailableFundsBeforeClaimCreation.Replace("$", "")) - Convert.ToDouble(Parameters.ClaimApprovalAmount_Bobcat.Replace("$", ""))));
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

        [Test, Parallelizable]
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ClaimCreation_Negative()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                BC_Claim pd = new BC_Claim();
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


        [Test, Parallelizable]
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_Claim_VerifyingApprovalAmountLessthanRequestedAmount()
        {
            string Invoice = CommonUtilities.RandomInvoice("Invoice");
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                BC_Claim pd = new BC_Claim();
                string claimID = pd.ClaimCreation("N", null, Invoice);
CommonUtilities.Logout(Driver);       Driver.Quit();

                ////Base bs2 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                BC_Claim claim_Validation = new BC_Claim();
                claim_Validation.ClaimApprovalAmountValidation(claimID, "Approve", "173");
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ClaimDateValidation()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs2 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                BC_Claim claim_Validation = new BC_Claim();
                claim_Validation.ClaimDateValidation();
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ClaimAutoApprovalBelow10000()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();

                BC_Claim pc = new BC_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                string ClaimID = pc.ClaimCreation(Parameters.ClaimTotalActivityCost_Bobcat_Below10000, Parameters.ClaimRequestedAmount_Bobcat_Below10000, "N", null, "Claim-Invoice-1234");
                Thread.Sleep(30000);
                //Verifying the ClaimStatus
                string Status = pc.SearchClaimAndGetStatus(ClaimID);
                Assert.IsTrue(Status.ToUpper().Contains("Approve".ToUpper()));
                Console.WriteLine("Claims below $10000 are Auto Approved");
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_Transaction_Accrual_Positive()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                //Launching Browser
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Transactions bt = new BC_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                bt.Transaction_Accrual("FLAT", Parameters.Bobcat_AccrualPositive_Amount);
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_Transaction_Accrual_Negative()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                //Launching Browser
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Transactions bt = new BC_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                bt.Transaction_Accrual("FLAT", Parameters.Bobcat_AccrualNegative_Amount);
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_Transaction_FundTransfer_Positive()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                //Launching Browser
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Transactions bt = new BC_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                bt.Transaction_FundTransfer("FLAT", Parameters.Bobcat_TransferPositive_Amount);
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_Transaction_Adjustment_Positive()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                //Launching Browser
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Transactions bt = new BC_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                bt.Transaction_Adjustment("FLAT", Parameters.Bobcat_AccrualPositive_Amount);
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_Transaction_Adjustment_Negative()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                //Launching Browser
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Transactions bt = new BC_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                bt.Transaction_Adjustment("FLAT", Parameters.Bobcat_AccrualNegative_Amount);
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_BPA_Clone()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();

                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");

                //Creating BPAID
                string BPAID = pc.BPACreation();

                //Cloning the recently created BPA
                pc.BPAClone(BPAID);

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

        //BPA HOLD
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_BPA_HOLD()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();
                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                string BPAID = pc.BPACreation();
CommonUtilities.Logout(Driver);       Driver.Quit();


                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BC_BPA pc1 = new BC_BPA();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Cloning the recently created BPA
                pc1.BPAPerformActionAndVerify(BPAID, "Hold");
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

        //BPA HOLD
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_BPA_AdvanceSearch()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();
                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                string BPAID = pc.BPACreation();
CommonUtilities.Logout(Driver);       Driver.Quit();


                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BC_BPA pc1 = new BC_BPA();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Cloning the recently created BPA
                pc1.BPA_AdvanceSearch(BPAID);
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_BPA_Approved()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();
                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                string BPAID = pc.BPACreation();
CommonUtilities.Logout(Driver);       Driver.Quit();


                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BC_BPA pc1 = new BC_BPA();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Cloning the recently created BPA
                pc1.BPAPerformActionAndVerify(BPAID, "Approve");
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_BPA_Creation_Negative()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();
                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                pc.BPACreation_Negative();
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_BPA_Creation_VerifyingOnMangoDB()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();
                BC_BPA pc = new BC_BPA();
                Database db = new Database(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                string BPAID = pc.BPACreation();

                //Verifying BPA Creation on mangodb
                db.VerifyingBPACreationMangoDB(BPAID);
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_BPA_DisApproved()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();
                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                string BPAID = pc.BPACreation();
CommonUtilities.Logout(Driver);       Driver.Quit();


                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BC_BPA pc1 = new BC_BPA();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Cloning the recently created BPA
                pc1.BPAPerformActionAndVerify(BPAID, "Deny");
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_BPA_NeedChange()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();
                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                string BPAID = pc.BPACreation();
CommonUtilities.Logout(Driver);       Driver.Quit();


                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BC_BPA pc1 = new BC_BPA();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Cloning the recently created BPA
                pc1.BPAPerformActionAndVerify(BPAID, "Needs Change");
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_BPA_Resubmitted()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();
                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                string BPAID = pc.BPACreation();
CommonUtilities.Logout(Driver);       Driver.Quit();


                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BC_BPA pc1 = new BC_BPA();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Cloning the recently created BPA
                pc1.BPAPerformActionAndVerify(BPAID, "Needs Change");
CommonUtilities.Logout(Driver);       Driver.Quit();

                ////Base bs2 = new Base();
                Driver=OpenBrowser();
                BC_BPA pc2 = new BC_BPA();
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Cloning the recently created BPA
                pc2.BPA_Resubmitted(BPAID);
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_BPA_DateValidation()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();
                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                pc.BPADateValidation();
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ClaimHold()
        {
            IWebDriver Driver = null;

            try
            {
                string Invoice = CommonUtilities.RandomInvoice("Invoice");

                ////Base bs = new Base();
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Claim pc = new BC_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                string ClaimID = pc.ClaimCreation("N", null, Invoice);
CommonUtilities.Logout(Driver);       Driver.Quit();

                //Login with Corporate User
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BC_Claim pc1 = new BC_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
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

        //Claim Approve
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ClaimApprove_WithDuplicateInvoiceCheck()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Claim pc = new BC_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                string ClaimID = pc.ClaimCreation();
CommonUtilities.Logout(Driver);       Driver.Quit();

                //Login with Corporate User
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BC_Claim pc1 = new BC_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                pc1.ClaimPerformAction(ClaimID, "Approve");
CommonUtilities.Logout(Driver);       Driver.Quit();

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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_DashBoard_ClaimCountMatchingWithAdditionOfOpenAndProcessedClaims()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                BC_Dashboard pd = new BC_Dashboard();
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_BPACountMatchingWithAdditionOfOpenAndProcessedClaims()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                BC_Dashboard pd = new BC_Dashboard();
                pd.ValidateBPACountMatchingWithAdditionOfOpenAndProcessedClaims();
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_OpenClaimsFilterVerificationDashBoard()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                BC_Dashboard pd = new BC_Dashboard();

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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ProcessedClaimsFilterVerificationDashBoard()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                BC_Dashboard pd = new BC_Dashboard();

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


        [Test, Parallelizable]
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_OpenBPAFilterVerificationDashBoard()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                BC_Dashboard pd = new BC_Dashboard();

                pd.ValidateOpenBPAFilterDashBoard();
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ProcessedBPAFilterVerificationDashBoard()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");

                BC_Dashboard pd = new BC_Dashboard();
                pd.ValidateProcessedBPAFilterDashBoard();
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
        //Claim disApprove
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ClaimDeny()
        {
            IWebDriver Driver = null;

            try
            {
                string Invoice = CommonUtilities.RandomInvoice("Invoice");

                ////Base bs = new Base();
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Claim pc = new BC_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                string ClaimID = pc.ClaimCreation("N", null, Invoice);
CommonUtilities.Logout(Driver);       Driver.Quit();

                Thread.Sleep(20000);
                //Login with Corporate User
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BC_Claim pc1 = new BC_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
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

        //Claim NeedsChange
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ClaimNeedsChange()
        {
            IWebDriver Driver = null;

            try
            {
                string Invoice = CommonUtilities.RandomInvoice("Invoice");

                ////Base bs = new Base();
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Claim pc = new BC_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                string ClaimID = pc.ClaimCreation("N", null, Invoice);
CommonUtilities.Logout(Driver);       Driver.Quit();

                //Login with Corporate User
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BC_Claim pc1 = new BC_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
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

        [Test, Parallelizable]
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ClaimResubmitted()
        {
            IWebDriver Driver = null;


            try
            {
                string Invoice = CommonUtilities.RandomInvoice("Invoice");
                ////Base bs = new Base();
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Claim pc = new BC_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                string ClaimID = pc.ClaimCreation("N", null, Invoice);
CommonUtilities.Logout(Driver);       Driver.Quit();

                //Login with Corporate User
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BC_Claim pc1 = new BC_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                pc1.ClaimPerformAction(ClaimID, "Needs Change");
CommonUtilities.Logout(Driver);       Driver.Quit();

                ////Base bs3 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bl3 = new BrowserURLLaunch(Driver);
                bl3.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                BC_Claim pc2 = new BC_Claim();
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

        //Claim Clone
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ClaimClone()
        {
            IWebDriver Driver = null;

            try
            {
                string Invoice = CommonUtilities.RandomInvoice("Invoice");

                ////Base bs = new Base();
                Driver=OpenBrowser();
                BC_Claim pc = new BC_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                string ClaimID = pc.ClaimCreation("N", null, Invoice);
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


        //Claim With BPA
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ClaimWithBPA_Creation()
        {
            IWebDriver Driver = null;

            try
            {
                string Invoice = CommonUtilities.RandomInvoice("Invoice");

                ////Base bs = new Base();
                Driver=OpenBrowser();
                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                string BPAID = pc.BPACreation();
CommonUtilities.Logout(Driver);       Driver.Quit();


                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BC_BPA pc1 = new BC_BPA();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Cloning the recently created BPA
                pc1.BPAPerformActionAndVerify(BPAID, "Approve");
CommonUtilities.Logout(Driver);       Driver.Quit();

                ////Base bs2 = new Base();
                Driver=OpenBrowser();
                BC_Claim pc2 = new BC_Claim();
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Claim Creation with BPA
                string ClaimID = pc2.ClaimCreation("Y", BPAID, Invoice);
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

        //Claim With BPA Approve
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ClaimWithBPA_Approve_WithDuplicateInvoiceCheck()
        {
            IWebDriver Driver = null;

            try
            {
                string Invoice = CommonUtilities.RandomInvoice("Invoice");

                ////Base bs = new Base();
                Driver=OpenBrowser();
                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                string BPAID = pc.BPACreation();
CommonUtilities.Logout(Driver);       Driver.Quit();


                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BC_BPA pc1 = new BC_BPA();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Cloning the recently created BPA
                pc1.BPAPerformActionAndVerify(BPAID, "Approve");
CommonUtilities.Logout(Driver);       Driver.Quit();

                ////Base bs2 = new Base();
                Driver=OpenBrowser();
                BC_Claim pc2 = new BC_Claim();
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Claim Creation with BPA
                string ClaimID = pc2.ClaimCreation("Y", BPAID, Invoice);
CommonUtilities.Logout(Driver);       Driver.Quit();

                //Login with Corporate User
                ////Base bs3 = new Base();
                Driver=OpenBrowser();
                BC_Claim pc3 = new BC_Claim();
                BrowserURLLaunch bl3 = new BrowserURLLaunch(Driver);
                bl3.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                pc3.ClaimPerformAction(ClaimID, "Approve");
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

        //Claim With BPA Deny
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ClaimWithBPA_Deny()
        {
            IWebDriver Driver = null;

            try
            {
                string Invoice = CommonUtilities.RandomInvoice("Invoice");

                ////Base bs = new Base();
                Driver=OpenBrowser();
                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                string BPAID = pc.BPACreation();
CommonUtilities.Logout(Driver);       Driver.Quit();


                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BC_BPA pc1 = new BC_BPA();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Cloning the recently created BPA
                pc1.BPAPerformActionAndVerify(BPAID, "Approve");
CommonUtilities.Logout(Driver);       Driver.Quit();

                ////Base bs2 = new Base();
                Driver=OpenBrowser();
                BC_Claim pc2 = new BC_Claim();
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Claim Creation with BPA
                string ClaimID = pc2.ClaimCreation("Y", BPAID, Invoice);
CommonUtilities.Logout(Driver);       Driver.Quit();

                //Login with Corporate User
                ////Base bs3 = new Base();
                Driver=OpenBrowser();
                BC_Claim pc3 = new BC_Claim();
                BrowserURLLaunch bl3 = new BrowserURLLaunch(Driver);
                bl3.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                pc3.ClaimPerformAction(ClaimID, "Deny");
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

        //Claim With BPA Hold
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ClaimWithBPA_Hold()
        {
            IWebDriver Driver = null;

            try
            {
                string Invoice = CommonUtilities.RandomInvoice("Invoice");

                ////Base bs = new Base();
                Driver=OpenBrowser();
                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                string BPAID = pc.BPACreation();
CommonUtilities.Logout(Driver);       Driver.Quit();


                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BC_BPA pc1 = new BC_BPA();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Cloning the recently created BPA
                pc1.BPAPerformActionAndVerify(BPAID, "Approve");
CommonUtilities.Logout(Driver);       Driver.Quit();

                ////Base bs2 = new Base();
                Driver=OpenBrowser();
                BC_Claim pc2 = new BC_Claim();
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Claim Creation with BPA
                string ClaimID = pc2.ClaimCreation("Y", BPAID, Invoice);
CommonUtilities.Logout(Driver);       Driver.Quit();

                //Login with Corporate User
                ////Base bs3 = new Base();
                Driver=OpenBrowser();
                BC_Claim pc3 = new BC_Claim();
                BrowserURLLaunch bl3 = new BrowserURLLaunch(Driver);
                bl3.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                pc3.ClaimPerformAction(ClaimID, "Hold");
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

        //Claim With BPA NeedsChange
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ClaimWithBPA_NeedsChange()
        {
            IWebDriver Driver = null;

            try
            {
                string Invoice = CommonUtilities.RandomInvoice("Invoice");

                ////Base bs = new Base();
                Driver=OpenBrowser();
                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                string BPAID = pc.BPACreation();
CommonUtilities.Logout(Driver);       Driver.Quit();


                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BC_BPA pc1 = new BC_BPA();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Cloning the recently created BPA
                pc1.BPAPerformActionAndVerify(BPAID, "Approve");
CommonUtilities.Logout(Driver);       Driver.Quit();

                ////Base bs2 = new Base();
                Driver=OpenBrowser();
                BC_Claim pc2 = new BC_Claim();
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Claim Creation with BPA
                string ClaimID = pc2.ClaimCreation("Y", BPAID, Invoice);
CommonUtilities.Logout(Driver);       Driver.Quit();

                //Login with Corporate User
                ////Base bs3 = new Base();
                Driver=OpenBrowser();
                BC_Claim pc3 = new BC_Claim();
                BrowserURLLaunch bl3 = new BrowserURLLaunch(Driver);
                bl3.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                pc3.ClaimPerformAction(ClaimID, "Needs Change");
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

        //Claim With BPA Resubmitted
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ClaimWithBPA_Resubmitted()
        {
            IWebDriver Driver = null;

            try
            {
                string Invoice = CommonUtilities.RandomInvoice("Invoice");

                ////Base bs = new Base();
                Driver=OpenBrowser();
                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                string BPAID = pc.BPACreation();
CommonUtilities.Logout(Driver);       Driver.Quit();


                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BC_BPA pc1 = new BC_BPA();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Cloning the recently created BPA
                pc1.BPAPerformActionAndVerify(BPAID, "Approve");
CommonUtilities.Logout(Driver);       Driver.Quit();

                ////Base bs2 = new Base();
                Driver=OpenBrowser();
                BC_Claim pc2 = new BC_Claim();
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Claim Creation with BPA
                string ClaimID = pc2.ClaimCreation("Y", BPAID, Invoice);
CommonUtilities.Logout(Driver);       Driver.Quit();

                //Login with Corporate User
                ////Base bs3 = new Base();
                Driver=OpenBrowser();
                BC_Claim pc3 = new BC_Claim();
                BrowserURLLaunch bl3 = new BrowserURLLaunch(Driver);
                bl3.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                pc3.ClaimPerformAction(ClaimID, "Needs Change");
CommonUtilities.Logout(Driver);       Driver.Quit();

                ////Base bs4 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bl4 = new BrowserURLLaunch(Driver);
                bl4.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                BC_Claim pc4 = new BC_Claim();
                string ResubmittedClaimID = pc4.ClaimResubmitted(ClaimID);
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ClaimWithBPA_Clone()
        {
            IWebDriver Driver = null;

            try
            {
                string Invoice = CommonUtilities.RandomInvoice("Invoice");

                ////Base bs = new Base();
                Driver=OpenBrowser();
                BC_BPA pc = new BC_BPA();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Creating BPAID
                string BPAID = pc.BPACreation();
CommonUtilities.Logout(Driver);       Driver.Quit();


                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BC_BPA pc1 = new BC_BPA();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                //Cloning the recently created BPA
                pc1.BPAPerformActionAndVerify(BPAID, "Approve");
CommonUtilities.Logout(Driver);       Driver.Quit();

                ////Base bs2 = new Base();
                Driver=OpenBrowser();
                BC_Claim pc2 = new BC_Claim();
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                //Claim Creation with BPA
                string ClaimID = pc2.ClaimCreation("Y", BPAID, Invoice);
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                pc2.ClaimClone(ClaimID);

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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_User_Dashboard()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                Driver=OpenBrowser();
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
CommonUtilities.Logout(Driver);       Driver.Quit();
                Thread.Sleep(5000);

                //Base bcc = new Base();
                Driver=OpenBrowser();
                //  OpenBrowser()();
                BrowserURLLaunch bc = new BrowserURLLaunch(Driver);
                bc.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                Console.WriteLine("Login with LME");
                Dashboard_Landing dc = new Dashboard_Landing();
                dc.Dashboard_Landing_User();
                //Dashboard_Landing.Dashboard_Landing_User();
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

        //Claim disApprove Without Aknowledging the Duplicate
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_ClaimDeny_WithOutDuplicateAknowlegement()
        {
            IWebDriver Driver = null;

            try
            {

                ////Base bs = new Base();
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Claim pc = new BC_Claim();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                string ClaimID = pc.ClaimCreation();
CommonUtilities.Logout(Driver);       Driver.Quit();
                Thread.Sleep(20000);
                //Login with Corporate User
                ////Base bs1 = new Base();
                Driver=OpenBrowser();
                BC_Claim pc1 = new BC_Claim();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_Transaction_VerifyAccrualEntryInFundSnapShot()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                //Launching Browser
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Transactions pt = new BC_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                pt.Transaction_Accrual("FLAT", Parameters.Bobcat_AccrualPositive_Amount);
                BC_Claim pd = new BC_Claim();
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_Transaction_VerifyFundTransferEntryInFundSnapShot()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                //Launching Browser
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Transactions pt = new BC_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                pt.Transaction_FundTransfer("FLAT", Parameters.Bobcat_TransferPositive_Amount);
                BC_Claim pd = new BC_Claim();
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_Transaction_VerifyAdjustmentEntryInFundSnapShot()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs = new Base();
                //Launching Browser
                Driver=OpenBrowser();

                //Login with LME for Creating a Claim
                BC_Transactions pt = new BC_Transactions(Driver);
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURLCLIENT("CORPORATE1", BUSINESSUNIT, "STAGE");
                pt.Transaction_Adjustment("FLAT", Parameters.Bobcat_AccrualPositive_Amount);
                BC_Claim pd = new BC_Claim();
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
        [Category("CFM_BOBCAT_REGRESSION")]
        public void RT_TC_BC_LME_ValidateNoClaimApprovalPermission()
        {
            IWebDriver Driver = null;

            try
            {
                ////Base bs2 = new Base();
                Driver=OpenBrowser();
                BrowserURLLaunch bc1 = new BrowserURLLaunch(Driver);
                bc1.BrowserURLCLIENT("LME1", BUSINESSUNIT, "STAGE");
                BC_Claim pc = new BC_Claim();
                string claimID = pc.ClaimCreation("N", null, "Claim-1234");

                //Checking LME user has Approval Permission
                pc.ClaimApprovalPermissionValidationNotAvailableForLME(claimID);
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
