//using BrandmuscleAutomation.StartUp;
//using CFMAutomation.Common;
//using CFMAutomation.PageObject.UI.Ace.BrandingPreapproval;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Web;

//namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.DistrictManager
//{
//    [TestClass]
//    [DeploymentItem(@"DeploymentItems\CoOpGuidelines_LCP_2018_Q1_R6.pdf", @"DeploymentItems")]
//    public class RT_TC_6081_DistrictManager_BPA : Base
//    {
//        static string file = Path.GetFullPath("DeploymentItems") + "\\CoOpGuidelines_LCP_2018_Q1_R6.pdf";

//        [TestMethod]
//        //[TestCategory("CFM_ACE_REGRESSION")]
//        public void RT_TC_6081_DistrictManager_BPA_ApprovalPermissionNegSce()
//        {
//            BrowserURLLaunch.BrowserURLACE("Chrome", "LME1");
//            Preapproval_FullFlow.ACE_Preapproval_Fullflow();
//            PreApproval_ApprovalPermission.Ace_PreApproval_ApprovalPermission(Preapproval_FullFlow.BPA_ID);
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;
//        }
//    }
//}