//using CFM_PARALLEL.Common;
//using CFM_PARALLEL.Enum;
//using CFM_PARALLEL.StartUp;
//using CFMAutomation.PageObject.UI.Ace.Program;
//using NUnit.Framework;

//namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.ACECorporate
//{
//    [TestFixture]
//    [Parallelizable(ParallelScope.Fixtures)]
//    [Category("CFM_ACE_REGRESSION")]

//    public class RT_TC_6137_CFMChainHQ_Program
//    {
//        [Test]
//        public void RT_TC_6137_CFMChainHQ_Program_NegativeScenario()
//        {
//            //Base bs = new Base();
//            Driver=OpenBrowser();
//            BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
//            bl.BrowserURLACE("LME1");
//            Program_NegativeScenario program_NegativeScenario = new Program_NegativeScenario(Driver);
//            program_NegativeScenario.Program_NegativeScenario_LeftNavValidation();
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;
//        }
//    }
//}