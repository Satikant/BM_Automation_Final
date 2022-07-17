using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval;
using CFM_PARALLEL.PageObject.UI.Ace.Claim;
using CFM_PARALLEL.PageObject.UI.Ace.Dashboard;
using CFM_PARALLEL.PageObject.UI.Functions.ACE;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using CFMAutomation.PageObject.UI.Ace.Transactions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace CFM_PARALLEL.Tests.Ace_SmokeTest
{
	[TestFixture]
	[Parallelizable(ParallelScope.Self)]
   
    public class ST_TC_6339_Claim :Base
    {
        public string bpaID = string.Empty;
        public string claimID = string.Empty;
        public string amount = "20";
        public By Dashboard { get { return (By.Id("dashboard")); } }

        [Test, Parallelizable]
        [Category("CFM_ACE_SMOKE")]
        public void ST_TC_6339_Claim_WithBPA_Approved()
        {
             
            try
            {
                ////Base bs = new Base();
                //Driver=OpenBrowser();
                //BrowserURLLaunch b = new BrowserURLLaunch(Driver);
                //b.BrowserURLACE("LME1");
                //Preapproval_FullFlow pf = new Preapproval_FullFlow(Driver);
                //bpaID = pf.ACE_Preapproval_Fullflow();
                //                         ;
                //Thread.Sleep(5000);

                //Base bB = new Base();
                //bB.OpenBrowser();
                //BrowserURLLaunch b1 = new BrowserURLLaunch(bB.Driver);
                //b1.BrowserURLACE("CORPORATE1");
                //PreApproval_PerformAction pp = new PreApproval_PerformAction(bB.Driver);
                //pp.ACE_PreApproval_PerformAction(bpaID, "Approve");
                //bB.                         ;

                //Base bcc = new Base();
                 
                BrowserURLLaunch bll = new BrowserURLLaunch(Driver);
                //bll.BrowserURLACE("LME1");
                Claim_FullFlow cf = new Claim_FullFlow(Driver);
                Transaction_Accrual ta = new Transaction_Accrual();
                PreApproval_PerformAction pp = new PreApproval_PerformAction();
                bll.BrowserURL_ACE("LME1");
                bpaID = pp.GetBPAIDByStoreName("M3903");
                BasicInteractions bi = new BasicInteractions(Driver);
                bi.WaitVisible(Dashboard);
                bi.Click(Dashboard);
                bi.WaitTime(10);

                //Get Available Funds Before Creating Claim
                Double AvailableFundsBeforeClaimCreation = ta.GetAvailableFunds(Parameters.Ace_ProgramName());
                claimID = cf.Ace_Claim_FullFlow("Y", bpaID);

                //get Available Funds After Creating Claim

                bi.WaitVisible(Dashboard);
                bi.Click(Dashboard);

                Double AvailableFindsAfterClaimCreation = ta.GetAvailableFunds(Parameters.Ace_ProgramName());
                Assert.True(Convert.ToDouble(AvailableFindsAfterClaimCreation) == (Convert.ToDouble(AvailableFundsBeforeClaimCreation) - Convert.ToDouble(amount.Replace("$", ""))));
                Console.WriteLine("Calim Amount Deducted from Available Funds Correctly");

 
                 

                //Base bcc1 = new Base();
                 
                BrowserURLLaunch bccl = new BrowserURLLaunch(Driver);
                bccl.BrowserURL_ACE("CORPORATE1");
                Claim_PerformAction cp = new Claim_PerformAction();
                cp.ACE_Claim_PerformAction(claimID, "Approve");

         
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
            finally
            {
                 
            }
        }


        [Test,NonParallelizable]
        [Category("CFM_ACE_SMOKE")]
        public void ST_TC_5991_BrandMuscleAdmin_Transactions_AccrualPositive()
        {
             

            try
            {
                
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURL_ACE("CORPORATE1");
                Transaction_Accrual transaction_Accrual = new Transaction_Accrual();
                transaction_Accrual.Transaction_AllocateAccruals("Flat", Parameters.Ace_AccrualPositive_Amount);

         
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
            finally
            {
                 
            }
        }

        [Test,NonParallelizable]
        [Category("CFM_ACE_SMOKE")]
       
        public void ST_TC_5995_BrandMuscleAdmin_Transactions_TransferPositive()
        {
             

            try
            {
                //Base bs1 = new Base();
                 
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURL_ACE("CORPORATE1");
                Transaction_Transfer transaction_Transfer = new Transaction_Transfer(Driver);
                transaction_Transfer.Transaction_FundTransfer(Parameters.Ace_TransferPositive_Amount);

                         
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
            finally
            {
                 
            }

        }

        [Test, Parallelizable]
        [Category("CFM_ACE_SMOKE")]
        public void ST_TC_5997_BrandMuscleAdmin_Transactions_AdjustmentPositive()
        {
             
            try
            {
                 
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURL_ACE("CORPORATE1");
                Transaction_Adjustment transaction_Adjustment = new Transaction_Adjustment(Driver);
                transaction_Adjustment.Transaction_AllocateAdjustment("Flat", Parameters.Ace_AccrualPositive_Amount);
                         
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
            finally
            {
                 
            }
        }


        [Test, Parallelizable]
        [Category("CFM_ACE_SMOKE")]
        public void ST_TC_ACE_CoopAdaptorFlow_QA()
        {
            String TemplateName = "Brands - Co-op Eligible - Horizontal Postcard";
             
            try
            {
                //Base bs1 = new Base();
                 
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURL_ACE("LME1");
                Dashboard_Landing dl = new Dashboard_Landing();
                ACE_CoopAdaptor ac = new ACE_CoopAdaptor(Driver);
                CommonFunctions cf = new CommonFunctions();
                //Calculate Amounts Before going to use Coop Adaptor
                IDictionary<String, Double> FundsBeforeUsingCoopAdaptor = dl.GetAllTheFunds("TestProgram3December");
                //Clear Shopping Cart
                cf.ClearShoppingCart();
                cf.NavigatingBackFromShoppingCart();
                //Search Template
                cf.SearchTemplate(TemplateName);
                //Building Template
                cf.BuildTemplateAndAddToCart_ACE(TemplateName);
                //place Order
                cf.PlaceOrder_NewCheckout();

         
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
            finally
            {
                 
            }
        }

        
           
            [Test, Parallelizable]
            [Category("CFM_ACE_SMOKE")]
            public void ST_TC_ACE_ClaimProgramOverdrawn_Approved()
            {
                 
            try
            {
                string claimID = string.Empty;
                //Base bs3 = new Base();
                 
                BrowserURLLaunch bl3 = new BrowserURLLaunch(Driver);
                bl3.BrowserURL_ACE("LME1");
                Claim_PerformAction claim_PerformAction = new Claim_PerformAction();
                CommonFunctions cf = new CommonFunctions();
                double AmountBeforeApproval = Convert.ToDouble(cf.GetAvailableFunds(Parameters.Ace_ProgramName("YES")));
              
                Claim_FullFlow claim_FullFlow = new Claim_FullFlow(Driver);
                claimID = claim_FullFlow.Ace_Claim_FullFlow("N", string.Empty, ProgramOverDrawn: "YES");

                         

                //Base bs2 = new Base();
                 
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURL_ACE("CORPORATE1");
                Claim_PerformAction claim_PerformAction2 = new Claim_PerformAction();

                claim_PerformAction2.ACE_Claim_PerformActionOD(claimID, "Approve", "34", AmountBeforeApproval, expectation: "IncreaseInValue");
                Dashboard_Landing dl = new Dashboard_Landing();
                dl.NavigatingToDashBoard();
                CommonFunctions cf1 = new CommonFunctions();

                double AmountAfterApproval = Convert.ToDouble(cf1.GetAvailableFunds(Parameters.Ace_ProgramName("YES")));

                Assert.AreEqual(AmountAfterApproval, (AmountBeforeApproval - Convert.ToDouble(Parameters.ClaimRequestedAmount_ACE("YES"))));

                         
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
            finally
            {
                 
            }
        }
    }
}