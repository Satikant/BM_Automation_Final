//using BrandmuscleAutomation.StartUp;
//using CFMAutomation.Common;
//using CFMAutomation.PageObject.UI.Ace.BrandingPreapproval;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.IO;

//namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.DivisionalManager
//{
//    [TestClass]
//    [DeploymentItem(@"DeploymentItems\CoOpGuidelines_LCP_2018_Q1_R6.pdf", @"DeploymentItems")]

//    public class RT_TC_6096_DivisionalManager_BPA : Base
//    {
//        static string file = Path.GetFullPath("DeploymentItems") + "\\CoOpGuidelines_LCP_2018_Q1_R6.pdf";

//        [TestMethod]
//        //[TestCategory("CFM_ACE_REGRESSION")]
//        public void RT_TC_6096_DivisionalManager_BPA_DatabaseValidation()
//        {
//            BrowserURLLaunch.BrowserURLACE("Chrome", "CORPORATE1");
//            Preapproval_FullFlow.ACE_Preapproval_Fullflow();
//            Preapproval_FullFlow.BrandingPreapproval_MongoDatabaseRead();
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;
//        }
//    }
//}