//using CFM_PARALLEL.Common;
//using CFM_PARALLEL.Enum;
//using CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval;
//using CFM_PARALLEL.StartUp;
//using NUnit.Framework;

//namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.CFMChainHQ
//{
//    [TestFixture]
//    [Parallelizable(ParallelScope.Fixtures)]
//    [Category("CFM_ACE_REGRESSION")]
//    public class RT_TC_6121_CFMChainHQ_BPA
//    {
//        [Test]
//        public void RT_TC_6121_CFMChainHQ_BPA_Date_Validation()
//        {
//            //Base bs = new Base();
//            Driver=OpenBrowser();
//            BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
//            bl.BrowserURLACE("LME1");
//            PreApprovals_Validation preApprovals_Validation = new PreApprovals_Validation(Driver);
//            preApprovals_Validation.BPADateValidation("Direct Mail", "Ace Hardware");
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;
//        }
//    }
//}