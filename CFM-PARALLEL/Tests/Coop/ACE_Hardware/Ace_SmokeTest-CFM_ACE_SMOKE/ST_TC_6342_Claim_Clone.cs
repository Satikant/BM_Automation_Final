
using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.Interactions_New;
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

    public class ST_TC_6342_Claim : Base
	{
        public string claimID = string.Empty;

        [Test, Parallelizable]
        //[Category("CFM_ACE_SMOKE")]
        public void ST_TC_6342_Claim_Clone()
		{
            
            try
            {
              
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURL_ACE("LME1");
                Claim_PerformAction cp = new Claim_PerformAction();
                Claim_FullFlow cf = new Claim_FullFlow(Driver);
                claimID = cf.Ace_Claim_FullFlow("N", string.Empty);     

                Claim_Clone cc = new Claim_Clone(Driver);
                cc.NavigatingBackToDashBoard();
                cc.ACE_Claim_Clone(claimID);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }

        }
	}
}