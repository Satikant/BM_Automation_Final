//using CFM_PARALLEL.Common;
//using CFM_PARALLEL.Enum;
//using CFM_PARALLEL.PageObject.UI.Ace.Claim;
//using CFM_PARALLEL.StartUp;
//using NUnit.Framework;

//namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.ACECorporate
//{
//    [TestFixture]
//    [Parallelizable(ParallelScope.Fixtures)]
//    [Category("CFM_ACE_REGRESSION")]
//    public class RT_TC_6187_ACECorporate_Claim
//    {
//        public string claimID = string.Empty;
//        [Test]
//        public void RT_TC_6187_ACECorporate_Claim_Amount_Validation()
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
//            Claim_Validations claim_Validation = new Claim_Validations(Driver);
//            claim_Validation.ClaimApprovalAmountValidation(claimID, "Approve", "34");
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;
//        }
//    }
//}