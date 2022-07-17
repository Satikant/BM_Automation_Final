
using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval;
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
    public class ST_TC_6472_BPA : Base
	{
		static string file = Path.GetFullPath("DeploymentItems") + "\\CoOpGuidelines_LCP_2018_Q1_R6.pdf";
        public string bpaID = string.Empty;

        [Test, Parallelizable]
        //[Category("CFM_ACE_SMOKE")]
        public void ST_TC_6472_BPA_Hold()
		{
           
            try
            {                              
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURL_ACE("LME1");
                Preapproval_FullFlow pf = new Preapproval_FullFlow(Driver);
                bpaID = pf.ACE_Preapproval_Fullflow();


                
                BrowserURLLaunch BC = new BrowserURLLaunch(Driver);
                BC.BrowserURL_ACE("CORPORATE1");
                PreApproval_PerformAction PP = new PreApproval_PerformAction();
                PP.ACE_PreApproval_PerformAction(bpaID, "Hold");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
           
        }
	}
}