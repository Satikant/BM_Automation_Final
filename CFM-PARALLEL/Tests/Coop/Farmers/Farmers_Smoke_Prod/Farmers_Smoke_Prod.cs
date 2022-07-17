using CFM_PARALLEL.StartUp;
using System;
using CFM_PARALLEL.PageObject.PageFactory;
using NUnit.Framework;
using CFMAutomation.Common;

namespace CFM_PARALLEL.Tests.Coop.Farmers.Farmers_Smoke_Prod
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Farmers_Smoke_Prod : Base
    {        
        [Test, Parallelizable]  // begin of test case
        [Category("CFM_FARMERS_SMOKE_PROD")]
        public void ST_TC_FARMERS_Dashboard()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_Farmers("PROD");
                Pages.CommonFunctions().Farmers_EmulateUser(Parameters.Farmers_EmulateUser1);
                Pages.Farmers_Dashboard().DashBoard_Validation();

            }
            catch (Exception ex)
            {
                 Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                 Console.WriteLine("Exception in MASCO_FundRequest method " + ex.Message);
                 throw;
            }
        } // end of test case
    }
}
