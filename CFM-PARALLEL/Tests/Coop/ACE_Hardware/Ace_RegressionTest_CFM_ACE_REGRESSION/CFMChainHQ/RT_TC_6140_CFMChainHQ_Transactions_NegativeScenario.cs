//using CFM_PARALLEL.Common;
//using CFM_PARALLEL.Enum;
//using CFM_PARALLEL.StartUp;
//using CFMAutomation.PageObject.UI.Ace.Transactions;
//using NUnit.Framework;

//namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.ACECorporate
//{
//    [TestFixture]
//    [Parallelizable(ParallelScope.Fixtures)]
//    [Category("CFM_ACE_REGRESSION")]
//    public class RT_TC_6140_CFMChainHQ_Transactions
//    {
//        [Test]
//        public void RT_TC_6140_CFMChainHQ_Transactions_NegativeScenario()
//        {
//            //Base bs = new Base();
//            Driver=OpenBrowser();
//            BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
//            bl.BrowserURLACE("LME1");
//            Transaction_Negative transaction_Negative = new Transaction_Negative(Driver);
//            transaction_Negative.Transaction_NegativeScenario_LeftNavValidation();
//                            CommonUtilities.Logout(Driver);       Driver.Quit();;
//        }
//    }
//}