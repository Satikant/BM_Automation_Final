//using BrandmuscleAutomation.StartUp;
//using CFMAutomation.Common;
//using CFMAutomation.PageObject.UI.Ace.BrandingPreapproval;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.IO;

//namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.RegionalManager
//{
//    [TestClass]
//    [DeploymentItem(@"DeploymentItems\CoOpGuidelines_LCP_2018_Q1_R6.pdf", @"DeploymentItems")]
//    public class RT_TC_6106_RegionalManager_BPA : Base
//    {
//        static string file = Path.GetFullPath("DeploymentItems") + "\\CoOpGuidelines_LCP_2018_Q1_R6.pdf";

//        [TestMethod]
//        //[TestCategory("CFM_ACE_REGRESSION")]
//        public void RT_TC_6106_RegionalManager_BPA_Date_Validation()
//        {
//            BrowserURLLaunch.BrowserURLACE("Chrome", "LME1");
//            PreApprovals_Validation.Ace_Preapproval_DateValidation("Direct Mail","Ace Hardware");
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;
//        }
//    }
//}