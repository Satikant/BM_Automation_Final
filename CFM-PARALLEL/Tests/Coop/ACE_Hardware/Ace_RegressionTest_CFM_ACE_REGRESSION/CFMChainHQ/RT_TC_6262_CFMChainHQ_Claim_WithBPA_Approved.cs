//using CFM_PARALLEL.Common;
//using CFM_PARALLEL.Enum;
//using CFM_PARALLEL.PageObject.UI.Ace.BrandingPreapproval;
//using CFM_PARALLEL.PageObject.UI.Ace.Claim;
//using CFM_PARALLEL.StartUp;
//using NUnit.Framework;

//namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.CFMChainHQ
//{
//    [TestFixture]
//    [Parallelizable(ParallelScope.Fixtures)]
//    [Category("CFM_REGRESSION_Approve")]
//    public class RT_TC_6262_CFMChainHQ_Claim
//    {
//        public string bpaID = string.Empty;
//        public string claimID = string.Empty;
//        [Test]
//        public void RT_TC_6262_CFMChainHQ_Claim_WithBPA_Approved()
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
//            preApproval_PerformAction.ACE_PreApproval_PerformAction(bpaID, "Approve");
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;

//            //Base bs3 = new Base();
//            Driver=OpenBrowser();
//            BrowserURLLaunch bl3 = new BrowserURLLaunch(Driver);
//            bl3.BrowserURLACE("LME1");
//            Claim_FullFlow claim_FullFlow = new Claim_FullFlow(Driver);
//            claimID=claim_FullFlow.Ace_Claim_FullFlow("Y", bpaID);
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;

//            //Base bs4 = new Base();
//            Driver=OpenBrowser();
//            BrowserURLLaunch bl4 = new BrowserURLLaunch(Driver);
//            bl4.BrowserURLACE("CORPORATE1");
//            Claim_PerformAction claim_PerformAction = new Claim_PerformAction(Driver);
//            claim_PerformAction.ACE_Claim_PerformAction(claimID, "Approve", "34");
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;
//        }
//    }
//}