
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

	public class ST_TC_6336_BPA:Base
	{
		static string file = Path.GetFullPath("DeploymentItems") + "\\CoOpGuidelines_LCP_2018_Q1_R6.pdf";
        public string bpaID = string.Empty;

        [Test, Parallelizable]
        [Category("CFM_ACE_SMOKE")]
		public void ST_TC_6336_BPA_Disapproved()
		{
            
            try
            {
                //Base bs = new Base();
                
                BrowserURLLaunch b = new BrowserURLLaunch(Driver);
                b.BrowserURL_ACE("LME1");
                Preapproval_FullFlow pf = new Preapproval_FullFlow(Driver);
                bpaID = pf.ACE_Preapproval_Fullflow();

         
                Thread.Sleep(5000);

                //Base bcc = new Base();
                
                //	BrowserURLLaunch bc = new BrowserURLLaunch();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURL_ACE("CORPORATE1");
                PreApproval_PerformAction pp = new PreApproval_PerformAction();
                pp.ACE_PreApproval_PerformAction(bpaID, "Deny");

         
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
            finally
            {
                 
            }
        }
	}
}