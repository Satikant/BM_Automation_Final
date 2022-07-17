//using BrandmuscleAutomation.StartUp;
//using CFMAutomation.Common;
//using CFMAutomation.PageObject.UI.Ace.BrandingPreapproval;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.IO;

//namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.CFMIndependent
//{
//    [TestClass]
//    [DeploymentItem(@"DeploymentItems\CoOpGuidelines_LCP_2018_Q1_R6.pdf", @"DeploymentItems")]
//    public class RT_TC_7570_CFMIndependent_BPA : Base
//    {
//        static string file = Path.GetFullPath("DeploymentItems") + "\\CoOpGuidelines_LCP_2018_Q1_R6.pdf";
//        [DeploymentItem(@"DeploymentItems\CoOpGuidelines_LCP_2018_Q1_R6.pdf", @"DeploymentItems")]

//        [TestMethod]
//        //[TestCategory("CFM_ACE_REGRESSION")]
//        public void RT_TC_7570_CFMIndependent_BPA_Hold()
//        {
//            BrowserURLLaunch.BrowserURLACE("Chrome", "LME1");
//            Preapproval_FullFlow.ACE_Preapproval_Fullflow();
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;

//            BrowserURLLaunch.BrowserURLACE("Chrome", "CORPORATE1");
//            PreApproval_PerformAction.ACE_PreApproval_PerformAction(Preapproval_FullFlow.BPA_ID, "Hold");
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;
//        }
//    }
//}