﻿//using BrandmuscleAutomation.StartUp;
//using CFMAutomation.Common;
//using CFMAutomation.PageObject.UI.Ace.BrandingPreapproval;
//using CFMAutomation.PageObject.UI.Ace.Claim;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.IO;

//namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.DivisionalManager
//{
//    [TestClass]
//    [DeploymentItem(@"DeploymentItems\CoOpGuidelines_LCP_2018_Q1_R6.pdf", @"DeploymentItems")]
//    public class RT_TC_6098_DivisionalManager_BPA : Base
//    {
//        static string file = Path.GetFullPath("DeploymentItems") + "\\CoOpGuidelines_LCP_2018_Q1_R6.pdf";

//        [TestMethod]
//        //[TestCategory("CFM_ACE_REGRESSION")]
//        public void RT_TC_6098_DivisionalManager_BPA_AdvanceSearch()
//        {
//            BrowserURLLaunch.BrowserURLACE("Chrome", "LME1");
//            Preapproval_FullFlow.ACE_Preapproval_Fullflow();
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;

//            BrowserURLLaunch.BrowserURLACE("Chrome", "LME1");
//            PreApproval_AdvanceSearch.ACE_PreApproval_AdvanceSearch(Preapproval_FullFlow.BPA_ID);
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;

//        }
//    }
//}