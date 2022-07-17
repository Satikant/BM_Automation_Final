
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
    //[DeploymentItem(@"DeploymentItems\CoOpGuidelines_LCP_2018_Q1_R6.pdf", @"DeploymentItems")]
    public class ST_TC_6338_BPA:Base
	{
		static string file = Path.GetFullPath("DeploymentItems") + "\\CoOpGuidelines_LCP_2018_Q1_R6.pdf";
        public string bpaID = string.Empty;


        [Test, Parallelizable]
        [Category("CFM_ACE_SMOKE")]
        public void ST_TC_6338_BPA_Clone()
		{
            

            try
            {
               
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURL_ACE("LME1");
                Preapproval_FullFlow pf = new Preapproval_FullFlow(Driver);
                bpaID = pf.ACE_Preapproval_Fullflow();
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                //Thread.Sleep(5000);

                //         //Base bcc = new Base();
                //         Driver=OpenBrowser();       
                //         BrowserURLLaunch bll = new BrowserURLLaunch(Driver);
                //bll.BrowserURLACE("LME1");
                Preapproval_Clone pc = new Preapproval_Clone(Driver);
                pc.ACE_Preapproval_Clone(bpaID);

               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
           
        }
	}
}