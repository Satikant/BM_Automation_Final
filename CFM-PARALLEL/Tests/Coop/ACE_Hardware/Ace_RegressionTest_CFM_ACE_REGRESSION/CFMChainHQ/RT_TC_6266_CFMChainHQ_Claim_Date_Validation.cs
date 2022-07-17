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
//    public class RT_TC_6266_CFMChainHQ_Claim
//    {
//        [Test]
//        public void RT_TC_6266_CFMChainHQ_Claim_Date_Validation()
//        {
//            //Base bs = new Base();
//            Driver=OpenBrowser();
//            BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
//            bl.BrowserURLACE("LME1");
//            Claim_Validations claim_Validations = new Claim_Validations(Driver);
//            claim_Validations.ClaimDateValidation();
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;
//        }
//    }
//}