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

//    public class RT_TC_6120_CFMChainHQ_BPA
//    {
//        public string bpaID = string.Empty;

//        [Test]
//        public void RT_TC_6120_CFMChainHQ_BPA_DatabaseValidation()
//        {
//            //Base bs = new Base();
//            Driver=OpenBrowser();
//            BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
//            bl.BrowserURLACE("CORPORATE1");
//            Preapproval_FullFlow preapproval_FullFlow = new Preapproval_FullFlow(Driver);
//            bpaID=preapproval_FullFlow.ACE_Preapproval_Fullflow();
//            preapproval_FullFlow.BrandingPreapproval_MongoDataBrowserURLLaunchRead();
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;
//        }
//    }
//}