using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using System;


namespace CFM_PARALLEL.Tests.Coop.Amnat.Amnat_Smoke_Prod
{
    [TestFixture]                                  
    [Parallelizable(ParallelScope.Fixtures)]
    public class Amnat_Smoke_Prod : Base
    {
        [Test, Parallelizable]  // begin of test case
        [Category("CFM_AMNAT_SMOKE_PROD")]
        public void ST_TC_AMNAT_Claim()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_AMNAT("PROD");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Amnat_Prod_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.Amnat_Prod_EmulateUser);
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM Link
                Pages.AM_Claims().Amnat_Claim_Fullflow();
                Pages.AM_Claims().Validate_Claims();                
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in AMNAT_Claim method " + ex.Message);
                throw;
            }
            
        } // end of test case

        [Test, Parallelizable]  // begin of test case
        [Category("CFM_AMNAT_SMOKE_PROD")]
        public void ST_TC_AMNAT_Programs()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_AMNAT("PROD");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Amnat_Prod_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.Amnat_Prod_EmulateUser);
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM Link
                Pages.AM_Programs().Validate_Programs();
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in AMNAT_Programs method " + ex.Message);
                throw;
            }
           
        } // end of test case


        [Test, Parallelizable]  // begin of test case
        [Category("CFM_AMNAT_SMOKE_PROD")]
        public void ST_TC_AMNAT_BrandingPreApproval()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_AMNAT("PROD");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Amnat_Prod_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.Amnat_Prod_EmulateUser);
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM Link
                Pages.AM_BrandPreApproval().BPA_FullFlow_Validation();
               
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in AMNAT_BrandingPreApproval method " + ex.Message);
                throw;
            }
           
        } // end of test case


        [Test, Parallelizable] // begin of test case
        [Category("CFM_AMNAT_SMOKE_PROD")]
        public void ST_TC_AMNAT_Dashboard()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_AMNAT("PROD");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Amnat_Prod_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.Amnat_Prod_EmulateUser);
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM Link
                Pages.AM_Dashboard().DashBoard_Validation();              
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in AMNAT_Dashboard method " + ex.Message);
                throw;
            }
            
        } // end of test case


        [Test, Parallelizable] // begin of test case
        [Category("CFM_AMNAT_SMOKE_PROD")]
        public void ST_TC_AMNAT_Fundsnapshot()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_AMNAT("PROD");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.Amnat_Prod_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.Amnat_Prod_EmulateUser2);
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM Link
                Pages.AM_Dashboard().FundSnapshot_Validation();                
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in MASCO_Fundsnapshot method " + ex.Message);
                throw;
            }
           
        } // end of test case
    }
}
