using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.StartUp;
using CFMAutomation.PageObject.UI.Ace.Program;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.ACECorporate
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    //[Category("CFM_ACE_REGRESSION")]

    public class RT_TC_6040_ACECorporate_Program:Base
    {
        [Test,Parallelizable]
        [Category("CFM_ACE_REGRESSION")]
        public void RT_TC_LME_Program_NegativeScenario()
        {
            IWebDriver Driver = null;
            try
            {

                ////Base bs = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.BrowserURL_ACE("LME1");

                Program_NegativeScenario program_NegativeScenario = new Program_NegativeScenario();
                program_NegativeScenario.Program_NegativeScenario_LeftNavValidation();
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                //                CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }
    }
}