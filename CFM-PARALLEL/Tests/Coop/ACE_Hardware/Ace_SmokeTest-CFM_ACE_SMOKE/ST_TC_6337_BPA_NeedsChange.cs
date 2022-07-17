
using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval;
using CFM_PARALLEL.StartUp;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading;

namespace CFM_PARALLEL.Tests.Ace_SmokeTest
{
	[TestFixture]
	[Parallelizable(ParallelScope.Fixtures)]
    [Category("CFM_ACE_SMOKE")]
    //[DeploymentItem(@"DeploymentItems\CoOpGuidelines_LCP_2018_Q1_R6.pdf", @"DeploymentItems")]
    public class ST_TC_6337_BPA:Base
	{
        //static string file = Path.GetFullPath("DeploymentItems") + "\\CoOpGuidelines_LCP_2018_Q1_R6.pdf";
        //[DeploymentItem(@"DeploymentItems\CoOpGuidelines_LCP_2018_Q1_R6.pdf", @"DeploymentItems")]
        public string bpaID = string.Empty;


        [Test, Parallelizable]
        public void ST_TC_6337_BPA_NeedsChange()
		{
            try
            {
                //Base bs = new Base();
               
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURL_ACE("LME1");
                Preapproval_FullFlow pf = new Preapproval_FullFlow(Driver);
                bpaID = pf.ACE_Preapproval_Fullflow();


                Thread.Sleep(5000);

                //BrowserURLLaunch bc = new BrowserURLLaunch();

                //Base bs1 = new Base();
                
                BrowserURLLaunch bsu = new BrowserURLLaunch(Driver);
                bsu.BrowserURL_ACE("CORPORATE1");
                PreApproval_PerformAction pp = new PreApproval_PerformAction();
                pp.ACE_PreApproval_PerformAction(bpaID, "Needs Change");


            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
          
        }
	}
}