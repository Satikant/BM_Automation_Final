using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.StartUp;
using NUnit.Framework;
using System;


namespace CFM_PARALLEL.Tests.Coop.Pandora
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Pandora_Production_Smoke : Base
    {
        public String BusinessUnit = "Pandora";

        [Test, Parallelizable]
        [Category("CFM_PANDORA_SMOKE_PROD")]
        public void ST_TC_PANDORA_Claim()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURLCLIENT("LME1", BusinessUnit, "PROD");
                Pages.PN_Claim().Claim_FullFlow_Validation();
                Pages.PN_Claim().Validate_Claims();
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Error Message with an exception in ST_TC_PROD_PANDORA_Claim: " + ex.Message);
                throw;
            }        
        } //end of test case

        [Test, Parallelizable]
        [Category("CFM_PANDORA_SMOKE_PROD")]
        public void ST_TC_PANDORA_Program()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURLCLIENT("CORPORATE1", BusinessUnit, "PROD");
                Pages.PN_Dashboard().ProgramValidation_AdminLevel();               
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Error Message with an exception in ST_TC_PROD_PANDORA_Program: " + ex.Message);
                throw;
            }            
        } //end of test case

        [Test, Parallelizable]
        [Category("CFM_PANDORA_SMOKE_PROD")]
        public void ST_TC_PANDORA_Dashboard()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURLCLIENT("CORPORATE1", BusinessUnit, "PROD");
                Pages.PN_Dashboard().DashBoardValidation_AdminLevel();               
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Error Message with an exception in ST_TC_PROD_PANDORA_Dashboard: " + ex.Message);
                throw;
            }            
        } //end of test case
    }
}
