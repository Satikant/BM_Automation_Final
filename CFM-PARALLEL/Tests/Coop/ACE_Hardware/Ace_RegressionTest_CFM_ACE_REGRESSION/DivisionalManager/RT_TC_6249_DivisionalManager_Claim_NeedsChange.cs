﻿//using BrandmuscleAutomation.StartUp;
//using CFMAutomation.Common;
//using CFMAutomation.PageObject.UI.Ace.Claim;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.IO;

//namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.DivisionalManager
//{
//    [TestClass]
//    [DeploymentItem(@"DeploymentItems\CoOpGuidelines_LCP_2018_Q1_R6.pdf", @"DeploymentItems")]
//    public class RT_TC_6249_DivisionalManager_Claim : Base
//    {
//        static string file = Path.GetFullPath("DeploymentItems") + "\\CoOpGuidelines_LCP_2018_Q1_R6.pdf";

//        [TestMethod]
//        //[TestCategory("CFM_ACE_REGRESSION")]
//        public void RT_TC_6249_DivisionalManager_Claim_NeedsChange()
//        {
//            BrowserURLLaunch.BrowserURLACE("Chrome", "LME1");
//            Claim_FullFlow.Ace_Claim_FullFlow("N");
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;

//            BrowserURLLaunch.BrowserURLACE("Chrome", "CORPORATE1");
//            Claim_PerformAction.ACE_Claim_PerformAction(Claim_FullFlow.CLAIM_ID, "Needs Change", "10");
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;
//        }
//    }
//}