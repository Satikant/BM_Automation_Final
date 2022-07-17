//using CFM_PARALLEL.Common;
//using CFM_PARALLEL.Enum;
//using CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval;
//using CFM_PARALLEL.StartUp;
//using NUnit.Framework;

//namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.ACECorporate
//{
//    [TestFixture]
//    [Parallelizable(ParallelScope.Fixtures)]
//    [Category("CFM_REGRESSION_ACE_COPR")]

//    public class RT_TC_6049_ACECorporate_BPA
//    {
//        [Test]
//        public void RT_TC_6049_ACECorporate_BPA_DatabaseValidation()
//        {
//            //Base bs = new Base();
//            Driver=OpenBrowser();
//            BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
//            bl.BrowserURLACE("LME1");

//            Preapproval_FullFlow preapproval_FullFlow = new Preapproval_FullFlow(Driver);
//            preapproval_FullFlow.ACE_Preapproval_Fullflow();
//            preapproval_FullFlow.BrandingPreapproval_MongoDataBrowserURLLaunchRead();
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;
//        }
//    }
//}