﻿//using CFM_PARALLEL.Common;
//using CFM_PARALLEL.Enum;
//using CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval;
//using CFM_PARALLEL.StartUp;
//using NUnit.Framework;

//namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.CFMChainHQ
//{
//    [TestFixture]
//    [Parallelizable(ParallelScope.Fixtures)]
//    [Category("CFM_ACE_REGRESSION_DisApprove")]

//    public class RT_TC_6117_CFMChainHQ_BPA
//    {
//        public string bpaID = string.Empty;

//        [Test]
//        public void RT_TC_6117_CFMChainHQ_BPA_Disapproved()
//        {
//            //Base bs = new Base();
//            Driver=OpenBrowser();
//            BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
//            bl.BrowserURLACE("LME1");
//            Preapproval_FullFlow preapproval_FullFlow = new Preapproval_FullFlow(Driver);
//            bpaID=preapproval_FullFlow.ACE_Preapproval_Fullflow();
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;

//            //Base bs2 = new Base();
//            Driver=OpenBrowser();
//            BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
//            bl2.BrowserURLACE("CORPORATE1");
//            PreApproval_PerformAction preApproval_PerformAction = new PreApproval_PerformAction(Driver);
//            preApproval_PerformAction.ACE_PreApproval_PerformAction(bpaID, "Deny");
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;
//        }
//    }
//}