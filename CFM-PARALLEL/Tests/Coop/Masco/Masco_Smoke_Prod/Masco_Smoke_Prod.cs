using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using System;


namespace CFM_PARALLEL.Tests.Coop.Masco.Masco_Smoke_Prod
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]

    public class Masco_Smoke_Prod : Base
    {
        [Test, Parallelizable]  // begin of test case
        [Category("CFM_MASCO_SMOKE_PROD")]
        public void ST_TC_MASCO_FundRequest()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("PROD");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                //Pages.MS_Dashboard().SelectSearchUserFrom_BM_AdminDropdown();
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateAccountUser2);
                Pages.MS_FundRequest().Validate_FundRequest();
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_FundRequest method " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable]  // begin of test case
        [Category("CFM_MASCO_SMOKE_PROD")]
        public void ST_TC_MASCO_Claim()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("PROD");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateDealerUser);
                Pages.MS_Claims().Masco_Claim_Fullflow(Parameters.MS_RequestedAmount,Parameters.MS_InvoiceNummber);
                Pages.MS_Claims().Validate_Claims();
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_Claim method " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_MASCO_SMOKE_PROD")]
        public void ST_TC_MASCO_Program()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("PROD");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                //Pages.MS_Dashboard().SelectSearchUserFrom_BM_AdminDropdown();
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateCorporateUser);
                Pages.MS_Programs().Validate_Programs();
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_Program method " + ex.Message);
                throw;
            }

        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_MASCO_SMOKE_PROD")]
        public void ST_TC_MASCO_Transaction()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("PROD");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
               // Pages.MS_Dashboard().SelectSearchUserFrom_BM_AdminDropdown();
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateCorporateUser);
                Pages.MS_Transaction().Validate_Transaction();
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_Transaction method " + ex.Message);
                throw;
            }

        } // end of test case


        [Test, Parallelizable] // begin of test case
        [Category("CFM_MASCO_SMOKE_PROD")]
        public void ST_TC_MASCO_DisplayClaim()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("PROD");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
               // Pages.MS_Dashboard().SelectSearchUserFrom_BM_AdminDropdown();
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateAccountUser2);
                Pages.MS_DisplayClaims().Validate_DisplayClaims_FullFlow( Parameters.MS_StoreName2, Parameters.MS_ProgramName);
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_DisplayClaim method " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_MASCO_SMOKE_PROD")]
        public void ST_TC_MASCO_BrandPreApproval()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("PROD");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
                //Pages.MS_Dashboard().SelectSearchUserFrom_BM_AdminDropdown();
                Pages.CommonFunctions().EmulateUser(Parameters.MS_EmulateDealer2);
                Pages.MS_BrandPreApproval().BPA_FullFlow_Validation();
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_BrandPreApproval method " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_MASCO_SMOKE_PROD")]
        public void ST_TC_MASCO_Fundsnapshot()
        {           
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("PROD");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
               // Pages.MS_Dashboard().SelectSearchUserFrom_BM_AdminDropdown();
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateCorporateUser);
                Pages.MS_Dashboard().FundSnapshot_Validation();
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_Fundsnapshot method " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_MASCO_SMOKE_PROD")]
        public void ST_TC_MASCO_FundPreApproval()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("PROD");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
               // Pages.MS_Dashboard().SelectSearchUserFrom_BM_AdminDropdown();
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateDealerUser);
                Pages.MS_FundPreApproval().FPA_FullFlow_Validation("PROD",Parameters.MS_RequestedAmount);
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_Fundsnapshot method " + ex.Message);
                throw;
            }
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_MASCO_SMOKE_PROD")]
        public void ST_TC_MASCO_Dashboard()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_MASCO("PROD");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Masco_Business_Unit);
               // Pages.MS_Dashboard().SelectSearchUserFrom_BM_AdminDropdown();
                Pages.CommonFunctions().EmulateUser(Parameters.Masco_EmulateCorporateUser);
                Pages.MS_Dashboard().DashBoard_Validation();
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_Dashboard method " + ex.Message);
                throw;
            }
        } // end of test case
    }

}










