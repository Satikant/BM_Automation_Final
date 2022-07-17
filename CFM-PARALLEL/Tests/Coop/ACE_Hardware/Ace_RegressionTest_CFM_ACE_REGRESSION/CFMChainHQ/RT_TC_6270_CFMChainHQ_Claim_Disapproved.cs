//using CFM_PARALLEL.Common;
//using CFM_PARALLEL.Enum;
//using CFM_PARALLEL.PageObject.UI.Ace.Claim;
//using CFM_PARALLEL.StartUp;
//using NUnit.Framework;

//namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.CFMChainHQ
//{
//    [TestFixture]
//    [Parallelizable(ParallelScope.Fixtures)]
//    [Category("CFM_ACE_REGRESSION_DisApprove")]
//    public class RT_TC_6270_CFMChainHQ_Claim
//    {
//        public string claimID = string.Empty;

//        [Test]
//        public void RT_TC_6270_CFMChainHQ_Claim_Disapproved()
//        {

//            //Base bs = new Base();
//            Driver=OpenBrowser();
//            BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
//            bl.BrowserURLACE("LME1");
//            Claim_FullFlow claim_FullFlow = new Claim_FullFlow(Driver);
//            claimID=claim_FullFlow.Ace_Claim_FullFlow("N", string.Empty);
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;

//            //Base bs2 = new Base();
//            Driver=OpenBrowser();
//            BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
//            bl2.BrowserURLACE("CORPORATE1");
//            Claim_PerformAction claim_PerformAction = new Claim_PerformAction(Driver);
//            claim_PerformAction.ACE_Claim_PerformAction(claimID, "Deny", "26");
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;
//        }
//    }
//}