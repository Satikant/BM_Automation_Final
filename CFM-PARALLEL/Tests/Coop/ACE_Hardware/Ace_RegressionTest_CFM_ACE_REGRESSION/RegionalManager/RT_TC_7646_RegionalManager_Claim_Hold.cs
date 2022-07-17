//using CFM_PARALLEL.Common;
//using CFM_PARALLEL.StartUp;
//using NUnit.Framework;

//namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.RegionalManager
//{
//    [TestFixture]
//    [Parallelizable(ParallelScope.Fixtures)]
//    [Category("CFM_ACE_REGRESSION")]

//    public class RT_TC_7646_RegionalManager_Claim
//    {
//        [Test]
//        //[TestCategory("CFM_ACE_REGRESSION")]
//        public void RT_TC_7646_RegionalManager_Claim_Hold()
//        {
//            //Base bs = new Base();
//            Driverclass();
//            BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
//            bl.BrowserURLACE("LME1");

//            Claim_FullFlow 
//                .Ace_Claim_FullFlow("N");
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;

//            BrowserURLLaunch.BrowserURLACE("Chrome", "CORPORATE1");
//            Claim_PerformAction.ACE_Claim_PerformAction(Claim_FullFlow.CLAIM_ID, "Hold", "36");
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;
//        }
//    }
//}