using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.PageObject.UI.Ace.Dashboard;
using CFM_PARALLEL.StartUp;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CFMAutomation.Tests.Ace_SmokeTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [Category("CFM_ACE_REGRESSION")]
    public class RT_TC_6112_Dashboard_Regression:Base
    {
        [Test]
        public void RT_TC_Dashboard_RegressionTest()
        {
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Dashboard_Landing));
            IWebDriver Driver = null;

            try
            {
                //Base base1 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURL_ACE("CORPORATE1");
                Console.WriteLine("Login with CORPORATE");
                Dashboard_Landing dashboard_Landingcorp = new Dashboard_Landing();
                dashboard_Landingcorp.Dashboard_Landing_User();
CommonUtilities.Logout(Driver);       Driver.Quit();

                Console.WriteLine();


                Driver = OpenBrowser();
                BrowserURLLaunch bl2 = new BrowserURLLaunch(Driver);
                bl2.BrowserURL_ACE("LME1");
                Console.WriteLine("Login with LME");
                Dashboard_Landing dashboard_Landinglme = new Dashboard_Landing();
                dashboard_Landinglme.Dashboard_Landing_User();
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