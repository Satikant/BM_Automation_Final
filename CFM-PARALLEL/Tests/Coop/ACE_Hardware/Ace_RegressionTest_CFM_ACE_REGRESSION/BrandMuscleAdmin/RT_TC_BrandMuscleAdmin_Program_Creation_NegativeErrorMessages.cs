using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.StartUp;
using CFMAutomation.PageObject.UI.Ace.Program;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFMAutomation.Tests.Ace_RegressionTest_CFM_ACE_REGRESSION.BrandMuscleAdmin
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    //[Category("CFM_ACE_REGRESSION")]
    [Category("CFM_ACE_REGRESSION")]
    public class ST_TC_Program_Negative:Base
    {
        [Test]
        public void RT_TC_BrandMuscleAdmin_Program_Creation_NegativeErrorMessages()
        {
            IWebDriver Driver = null;

            try
            {
                //Base bs1 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURL_ACE("CORPORATE1");
                Program_NegativeScenario program_NegativeScenario = new Program_NegativeScenario();
                program_NegativeScenario.Program_NegativeScenario_ErrorMsgsValidation();
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