using CFM_PARALLEL.StartUp;
using System;
using NUnit.Framework;
using CFMAutomation.Common;
using CFM_PARALLEL.PageObject.PageFactory;

namespace CFM_PARALLEL.Tests.Coop.ACE_Hardware
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures)]

    public class Ace_Production_Smoke : Base
    {
        [Test] // begin of test case
        [Category("CFM_ACE_SMOKE_PROD")]
        public void ST_TC_ACE_Transaction()
        {            
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_ACE("InternalUser", "Prod");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown("ACE");
                Pages.CommonFunctions().EmulateUser(Parameters.Usr_Prod_Admin);      //Emulate User      
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM Link
                Pages.Dashboard_Landing().Validate_Transaction();                
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in Transaction_Validation_Admin_Level:" + ex.Message);
                throw;
            }
           
        } // end of test case

        [Test] // begin of test case
        [Category("CFM_ACE_SMOKE_PROD")]
        public void ST_TC_ACE_Brand_Pre_Approvals()
        {                 
            try
            { 
                Pages.BrowserURLLaunch().BrowserURL_ACE("InternalUser", "Prod");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown("ACE");
                Pages.CommonFunctions().EmulateUser(Parameters.Usr_Prod_Admin);      //Emulate User      
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM Link
                Pages.Preapproval_FullFlow().ACE_Preapproval_Fullflow_Smoke();               
            }

            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in BPA_Validation:" + ex.Message);
                throw;
            }
           

        } // end of test case

        [Test] // begin of test case
        [Category("CFM_ACE_SMOKE_PROD")]

        public void ST_TC_ACE_Claims()
        {           
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_ACE("InternalUser", "Prod");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown("ACE");
                Pages.CommonFunctions().EmulateUser(Parameters.EmulateACE_LMEUser);      //Emulate User      
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM Link
                Pages.Claim_FullFlow().Ace_Claim_FullFlow("N", string.Empty, "NO", "Prod");
                Pages.Dashboard_Landing().Validate_Claims();               
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in Claim_Validation:" + ex.Message);
                throw;
            }    
        }// end of test case

        [Test] // begin of test case
        [Category("CFM_ACE_SMOKE_PROD")]
        public void ST_TC_ACE_Programs()
        {            
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_ACE("InternalUser", "Prod");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown("ACE");
                Pages.CommonFunctions().EmulateUser(Parameters.Usr_Prod_Admin);      //Emulate User      
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM Link
                Pages.Dashboard_Landing().ValidateLabels_CreateNewProgram();                
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in Add_Program_Validation_Admin_Level:" + ex.Message);
                throw;
            }           
        } // end of test case

        [Test] // begin of test case
        [Category("CFM_ACE_SMOKE_PROD")]
        public void ST_TC_ACE_Disbursements()
        {            
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_ACE("InternalUser", "Prod");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown("ACE");
                Pages.CommonFunctions().EmulateUser(Parameters.Usr_Prod_Admin); //Emulate User      
                Pages.BrowserURLLaunch().Click_CFMLink(); //Click CFM Link
                Pages.Dashboard_Landing().Validate_Disbursements();                
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in Disbursement_Validation_Admin_Level:" + ex.Message);
                throw;
            }
        } // end of test case

        [Test] // begin of test case
        [Category("CFM_ACE_SMOKE_PROD")]
        public void ST_TC_ACE_Dashboard()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_ACE("InternalUser", "Prod");
                Pages.BrowserURLLaunch().SelectBusinessUnitFromDropDown("ACE");
                Pages.CommonFunctions().EmulateUser(Parameters.Usr_Prod_Admin);      //Emulate User      
                Pages.BrowserURLLaunch().Click_CFMLink();          //Click CFM Link
                Pages.Dashboard_Landing().Validate_Dashboard();
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in Dashboard_Validation_Admin_Level:" + ex.Message);
                throw;
            }           
        } // end of test case        
    } // end of class
} // end of namespace