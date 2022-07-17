using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.PageObject.UI.Ace.Claim;
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
    public class ST_TC_6340_Claim:Base
    {
        public string claimID = string.Empty;

        [Test, Parallelizable]
        public void ST_TC_6340_Claim_Disapproved()
		{
           
            try
            {
                
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURL_ACE("LME1");
                Claim_FullFlow cf = new Claim_FullFlow(Driver);
                claimID = cf.Ace_Claim_FullFlow("N", string.Empty);
                Thread.Sleep(5000);

                //Base bs1 = new Base();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURL_ACE("CORPORATE1");
                Claim_PerformAction cp = new Claim_PerformAction();
                //claimID = cp.SearchAndGetClaimIdofPendingReviewClaim();
                //if(claimID==null)
                //{
                //    Claim_FullFlow cf = new Claim_FullFlow(Driver);
                //    claimID = cf.Ace_Claim_FullFlow("N", string.Empty);
                //                    CommonUtilities.Logout(Driver);       Driver.Quit();;
                //    Thread.Sleep(5000);
                //}
                // Base bc = new Base();
                //bc.OpenBrowser();
                // BrowserURLLaunch bc1 = new BrowserURLLaunch(bc.Driver);
                //bc1.BrowserURLACE("CORPORATE1");
                //Claim_PerformAction cp = new Claim_PerformAction(bc.Driver);
                cp.ACE_Claim_PerformAction(claimID, "Deny");


            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
           
        }
	}
}