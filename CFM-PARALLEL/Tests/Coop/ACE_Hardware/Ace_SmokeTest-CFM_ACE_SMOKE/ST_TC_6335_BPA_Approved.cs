
using CFM_PARALLEL.Common;

using CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval;
using CFM_PARALLEL.StartUp;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

using System.Threading;

namespace CFM_PARALLEL.Tests.Ace_SmokeTest
{
	[TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [Category("CFM_ACE_SMOKE")]

    public class ST_TC_6335_BPA :Base
	{
        public string bpaID = string.Empty;
        [Test, Parallelizable]
        [Category("CFM_ACE_SMOKE")]
        public void ST_TC_6335_BPA_Approved()
		{
            
            try
            {
                //Base bs = new Base();
                
                BrowserURLLaunch b = new BrowserURLLaunch(Driver);
                b.BrowserURL_ACE("LME1");
                Preapproval_FullFlow pf = new Preapproval_FullFlow(Driver);
                bpaID = pf.ACE_Preapproval_Fullflow();

                        
                Thread.Sleep(5000);

                //Base bB = new Base();
                
                BrowserURLLaunch b1 = new BrowserURLLaunch(Driver);
                b1.BrowserURL_ACE("CORPORATE1");
                PreApproval_PerformAction pp = new PreApproval_PerformAction();
                pp.ACE_PreApproval_PerformAction(bpaID, "Approve");

                 
                
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