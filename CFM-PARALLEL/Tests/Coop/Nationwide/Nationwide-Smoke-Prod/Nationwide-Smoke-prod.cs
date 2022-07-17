using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using System;


namespace CFM_PARALLEL.Tests.Coop.Nationwide.Nationwide_Smoke_Prod
{

    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Smoke_Nationwide_Prod : Base
    {       

        [Test, Parallelizable]  // begin of test case
        [Category("CFM_NATIONWIDE_SMOKE_PROD")]
        public void ST_TC_NATIONWIDE_PaymentProfiles()
        {           
            try
            {                
                Pages.BrowserURLLaunch().BrowserURL_NATIONWIDE("LME1", "PROD");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.NW_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.NW_EmulateUser1);
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM Link
                Pages.NW_Payments().Validate_PaymentProfiles();         
            }

            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in NATIONWIDE_PaymentProfiles method " + ex.Message);
                throw;
            }
           

        } // end of test case


        [Test, Parallelizable]  // begin of test case
        [Category("CFM_NATIONWIDE_SMOKE_PROD")]
        public void ST_TC_NATIONWIDE_Claim()
        {            
            try
            {               
                Pages.BrowserURLLaunch().BrowserURL_NATIONWIDE("LME1", "PROD");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.NW_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.NW_EmulateUser2,true);
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM Link
                Pages.NW_Claims().NW_Claim_FullFlow(Parameters.NW_Prod_AgencyName1);
                Pages.NW_Claims().Validate_Claims(); // claim validation              
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in NATIONWIDE_Claim method " + ex.Message);
                throw;
            }
           
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_NATIONWIDE_SMOKE_PROD")]
        public void ST_TC_NATIONWIDE_Payments()
        {            
            try
            {               
                Pages.BrowserURLLaunch().BrowserURL_NATIONWIDE("LME1", "PROD");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.NW_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.NW_EmulateUser1);
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM Link
                Pages.NW_Payments().Validate_Payments();
                
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in NATIONWIDE_Payment method " + ex.Message);
                throw;
            }
            
        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_NATIONWIDE_SMOKE_PROD")]
        public void ST_TC_NATIONWIDE_Dashboard()
        {          
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_NATIONWIDE("LME1", "PROD");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.NW_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.NW_EmulateUser2,true);
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM Link
                Pages.NW_Dashboard().DashBoard_Validation();               
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in NATIONWIDE_Dashboard method " + ex.Message);
                throw;
            }
            

        } // end of test case

        [Test, Parallelizable] // begin of test case
        [Category("CFM_NATIONWIDE_SMOKE_PROD")]
        public void ST_TC_NATIONWIDE_Program()
        {           
            try
            {               
                Pages.BrowserURLLaunch().BrowserURL_NATIONWIDE("LME1", "PROD");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown(Parameters.NW_Business_Unit);
                Pages.CommonFunctions().EmulateUser(Parameters.NW_EmulateUser1);
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM Link
                Pages.NW_Programs().Validate_Programs();
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in NATIONWIDE_Program method " + ex.Message);
                throw;
            }           
        } // end of test case
    }
}

