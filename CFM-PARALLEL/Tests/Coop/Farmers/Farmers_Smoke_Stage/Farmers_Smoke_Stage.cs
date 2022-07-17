using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.StartUp;
using CFMAutomation.Common;
using NUnit.Framework;
using System;

namespace CFM_PARALLEL.Tests.Coop.Farmers.Farmers_Smoke_Stage
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Farmers_Smoke_Stage : Base
    {
        public string BusinessUnit = "Farmers";
        [Test, Parallelizable]  // begin of test case
        [Category("CFM_FARMERS_SMOKE_STAGE")]
        public void ST_TC_FARMERS_Claim()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_Farmers("STAGE");
                Pages.BrowserURLLaunch().BusinessUnitFromDropDown(BusinessUnit);
                Pages.CommonFunctions().Farmers_EmulateUser(Parameters.Farmers_EmulateUser2);
                string ClaimId = Pages.Farmers_Claim().Create_Claim(Parameters.Farmers_RequestedAmount);
                Pages.CommonFunctions().ExitEmulation();
                Pages.CommonFunctions().Farmers_EmulateUser(Parameters.Farmers_Approver);
                Pages.Farmers_Claim().Review_Claim(ClaimId,"Approve");

            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Exception in FARMERS_Claim method " + ex.Message);
                throw;
            }
        }

    }
}
