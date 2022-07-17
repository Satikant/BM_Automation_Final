
using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.PageObject.UI.Ace.Claim;
using CFM_PARALLEL.StartUp;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading;

namespace CFM_PARALLEL.Tests.Ace_SmokeTest
{
	[TestFixture]
	[Parallelizable(ParallelScope.Fixtures)]
    [Category("CFM_ACE_SMOKE")]
    //[DeploymentItem(@"DeploymentItems\CoOpGuidelines_LCP_2018_Q1_R6.pdf", @"DeploymentItems")]
    public class ST_TC_6341_Claim:Base
	{
        public string claimID = string.Empty;

        [Test, Parallelizable]
        //[Category("CFM_ACE_SMOKE")]
        public void ST_TC_6341_Claim_Hold()
		{
           
            try
            {                               
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURL_ACE("CORPORATE1");
                Claim_PerformAction cp = new Claim_PerformAction();

                //cp.ACE_Claim_PerformAction(claimID, "Hold");
                cp.ACE_Claim_PerformAction("CL-12618", "Hold");
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
         
        }
	}
}