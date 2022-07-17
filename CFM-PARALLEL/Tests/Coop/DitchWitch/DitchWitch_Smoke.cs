using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.PageObject.UI.Ace.Dashboard;
using CFM_PARALLEL.StartUp;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CFM_PARALLEL.Tests.Coop.DitchWitch
{

    [TestFixture, Parallelizable(ParallelScope.Fixtures)]
    public class DitchWitch_Smoke : Base
    {
        public string BUSINESSUNIT = "Ditch Witch";
        public string UserName = "1410AC";

        [Test, Parallelizable]
        [Category("CFM_DW_SMOKE_PROD")]
        public void ST_TC_DW_CoopAdaptorFlow_PROD()
        {
            IWebDriver Driver = null;
            String TemplateName = "Orange Show Bag";

            try
            {
                
                Driver = OpenBrowser();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("LME1", BUSINESSUNIT, "PROD");
                Dashboard_Landing dl = new Dashboard_Landing();
                CommonFunctions cf = new CommonFunctions();

                //Emulate User
                cf.EmulateUser(UserName);
                //Clear Shopping Cart
                cf.ClearShoppingCart();
                //Search Template
                cf.SearchTItemAndAddToCart(TemplateName);
                //Navigating to Shopping cart
                cf.NavigateToShoppingCart();
                cf.ValidateCoopAmountvisibility_OldCheckout();
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }

        }

        [Test, Parallelizable]
        [Category("CFM_DW_SMOKE_QA")]
        public void ST_TC_DW_CoopAdaptorFlow_QA()
        {
            IWebDriver Driver = null;
            String TemplateName = "Orange Show Bag";
            try
            {
                ////Base bs1 = new Base();
                Driver = OpenBrowser();
                BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
                bl1.BrowserURLCLIENT("LME1", BUSINESSUNIT);
                Dashboard_Landing dl = new Dashboard_Landing();
                //DW_CoopAdaptor dc = new DW_CoopAdaptor(Driver);
                CommonFunctions cf = new CommonFunctions();

                //Emulate User
                cf.EmulateUser(UserName);
                Thread.Sleep(10000);
                //Clear Shopping Cart
                cf.ClearShoppingCart();
                //Search Template
                cf.SearchTItemAndAddToCart(TemplateName);
                //Navigating to Shopping cart
                cf.NavigateToShoppingCart();
                cf.ValidateCoopAmountvisibility_OldCheckout();
CommonUtilities.Logout(Driver);       Driver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
            finally
            {
                Driver_CleanUp();
            }
        }
    }
}
