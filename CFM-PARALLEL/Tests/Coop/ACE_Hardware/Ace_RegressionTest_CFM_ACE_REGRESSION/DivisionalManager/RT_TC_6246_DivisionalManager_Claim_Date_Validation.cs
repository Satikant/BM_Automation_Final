//using BrandmuscleAutomation.StartUp;
//using CFMAutomation.Common;
//using CFMAutomation.PageObject.UI.Ace.Claim;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.IO;

//namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.DivisionalManager
//{
//    [TestClass]
//    [DeploymentItem(@"DeploymentItems\CoOpGuidelines_LCP_2018_Q1_R6.pdf", @"DeploymentItems")]
//    public class RT_TC_6246_DivisionalManager_Claim : Base
//    {
//        static string file = Path.GetFullPath("DeploymentItems") + "\\CoOpGuidelines_LCP_2018_Q1_R6.pdf";

//        [TestMethod]
//        //[TestCategory("CFM_ACE_REGRESSION")]
//        public void RT_TC_6246_DivisionalManager_Claim_Date_Validation()
//        {
//            BrowserURLLaunch.BrowserURLACE("Chrome", "LME1");
//            Claim_Validation.Ace_Claim_DateValidation();
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;
//        }
//    }
//}