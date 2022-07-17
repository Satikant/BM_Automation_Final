//using CFM_PARALLEL.Common;
//using CFM_PARALLEL.Enum;
//using CFM_PARALLEL.PageObject.UI.Ace.Claim;
//using CFM_PARALLEL.StartUp;
//using CFMAutomation.PageObject.UI.Ace.Disbursement;
//using NUnit.Framework;

//namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.BrandMuscleAdmin
//{
//    [TestFixture]
//    [Parallelizable(ParallelScope.Fixtures)]
//    [Category("CFM_ACE_REGRESSION")]
//    public class RT_TC_6475_ACECorporate_Disbursement
//    {
//        public string claimID = string.Empty;

//        [Test]
//        public void RT_TC_6475_ACECorporate_Disbursement_NeedsChange()
//        {
//            //Base bs1 = new Base();
//            Driver=OpenBrowser();
//            BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
//            bl1.BrowserURLACE("LME1");
//            Claim_FullFlow claim_FullFlow = new Claim_FullFlow(Driver);
//            claimID = claim_FullFlow.Ace_Claim_FullFlow("N", string.Empty);
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;

//            //Base bs2 = new Base();
//            Driver=OpenBrowser();
//            BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
//            bl2.BrowserURLACE("CORPORATE1");
//            Claim_PerformAction claim_PerformAction = new Claim_PerformAction(Driver);
//            claim_PerformAction.ACE_Claim_PerformAction(claimID, "Approve", "34");
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;

//            //Base bs3 = new Base();
//            Driver=OpenBrowser();
//            BrowserURLLaunch bl3 = new BrowserURLLaunch(Driver);
//            bl3.BrowserURLACE("CORPORATE1");
//            Disbursement_Fullflow disbursement_Fullflow = new Disbursement_Fullflow(Driver);
//            disbursement_Fullflow.Ace_Disbursement_Fullflow("Need", claimID);
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;
//        }
//    }
//}