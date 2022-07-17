
using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.UI.Ace.Claim;
using CFM_PARALLEL.StartUp;
using CFMAutomation.PageObject.UI.Ace.Disbursement;
using NUnit.Framework;
using System;

namespace CFMAutomation.Tests.Ace_SmokeTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class ST_TC_6469_Disbursement : Base
    {
        public string claimID = string.Empty;
        [Test, Parallelizable]
        [Category("CFM_ACE_SMOKE")]
        public void ST_TC_6469_Disbursement_Manage()
        {
            
            try
            {
               
                BrowserURLLaunch bccl = new BrowserURLLaunch(Driver);
                bccl.BrowserURL_ACE("CORPORATE1");
                Claim_PerformAction cp = new Claim_PerformAction();
                claimID = cp.SearchAndGetClaimIdofPendingReviewClaim();
                cp.ACE_Claim_PerformAction(claimID, "Approve");
                
                Disbursement_Fullflow df = new Disbursement_Fullflow(Driver);
                df.Ace_Disbursement_Fullflow("Approve", claimID);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
           
        }
    }
}