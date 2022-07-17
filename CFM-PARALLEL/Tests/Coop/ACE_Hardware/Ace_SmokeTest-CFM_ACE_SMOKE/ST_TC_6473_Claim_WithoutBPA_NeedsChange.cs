
using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.PageObject.UI.Ace.Claim;
using CFM_PARALLEL.StartUp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading;

namespace CFM_PARALLEL.Tests.Ace_SmokeTest
{
	[TestFixture]
	[Parallelizable(ParallelScope.Fixtures)]
    //[DeploymentItem(@"DeploymentItems\CoOpGuidelines_LCP_2018_Q1_R6.pdf", @"DeploymentItems")]
    public class ST_TC_6473_Claim : Base
	{
        public string claimID = string.Empty;

        [Test, Parallelizable]
        [Category("CFM_ACE_SMOKE")]

        public void ST_TC_6473_Claim_NeedsChange()
		{
           
            try
            {
               
                BrowserURLLaunch BL = new BrowserURLLaunch(Driver);
                BL.BrowserURL_ACE("LME1");
                Claim_FullFlow CF = new Claim_FullFlow(Driver);
                claimID = CF.Ace_Claim_FullFlow("N", string.Empty);

                Thread.Sleep(30000);

               
                BrowserURLLaunch BC = new BrowserURLLaunch(Driver);
                BC.BrowserURL_ACE("CORPORATE1");
                Claim_PerformAction PP = new Claim_PerformAction();
                PP.ACE_Claim_PerformAction(claimID, "Needs Change");
                }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
           
        }
	}
}