//using CFM_PARALLEL.Common;
//using CFM_PARALLEL.Enum;
//using CFM_PARALLEL.PageObject.UI.Ace.Claim;
//using CFM_PARALLEL.StartUp;
//using NUnit.Framework;

//namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.CFMChainHQ
//{
//    [TestFixture]
//    [Parallelizable(ParallelScope.Fixtures)]
//    [Category("CFM_ACE_REGRESSION")]
//    public class RT_TC_6269_CFMChainHQ_Claim
//    {
//        [Test]
//        public void RT_TC_6269_CFMChainHQ_Claim_ApprovalPermissionNegSce()
//        {
//            //Base bs = new Base();
//            Driver=OpenBrowser();
//            BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
//            bl.BrowserURLACE("LME1");
//            Claim_FullFlow claim_FullFlow = new Claim_FullFlow(Driver);
//            claim_FullFlow.Ace_Claim_FullFlow("N", string.Empty);
//            Claim_ApprovalPermission claim_ApprovalPermission = new Claim_ApprovalPermission(Driver);
//            claim_ApprovalPermission.Ace_Claim_ApprovalPermission(claim_FullFlow.CLAIM_ID,"Approve","34");
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;
//        }
//    }
//}