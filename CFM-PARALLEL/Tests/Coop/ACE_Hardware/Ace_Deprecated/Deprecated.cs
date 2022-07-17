
using CFM_PARALLEL.StartUp;
using CFM_PARALLEL.Common;
using CFM_PARALLEL.Enum;
using CFM_PARALLEL.PageObject.UI.Ace.Dashboard;
using NUnit.Framework;
using CFM_PARALLEL.Interactions_New;
using OpenQA.Selenium;
using System;
using CFM_PARALLEL.PageObject.UI.Functions.ACE;


namespace CFM_PARALLEL.Tests.Coop.ACE_Hardware
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class ST_TC_6112_Add_Program_Validation_Admin_Level_Dep : Base
    {
        public string claimID = string.Empty;
        public By imgLoading { get { return By.Id("loading-image"); } }
        public By lnkNewProgram { get { return By.XPath("//span[contains(text(),'New Program')]"); } }
        public string Env = "PROD";


        [Test, Parallelizable]
       
        public void ST_TC_ACE_CoopAdaptorFlow_PROD_Dep()
        {
            IWebDriver Driver = null;
            String TemplateName = "Brands - Co-op Eligible - Horizontal Postcard";
            //Base bs1 = new Base();
            Driver = OpenBrowser();
            BrowserURLLaunch bl1 = new BrowserURLLaunch(Driver);
            bl1.BrowserURL_ACE("LME1", "PROD");
            Dashboard_Landing dl = new Dashboard_Landing();
            ACE_CoopAdaptor ac = new ACE_CoopAdaptor(Driver);
            CommonFunctions cf = new CommonFunctions();

            cf.ClearShoppingCart();
            cf.NavigatingBackFromShoppingCart();
            //Search Template
            cf.SearchTemplate(TemplateName);
            //Building Template
            cf.BuildTemplateAndAddToCart_ACE(TemplateName);
            //Checking co-op Amount visibility

            cf.ValidateCoopAmountvisibility_NewCheckout();

            CommonUtilities.Logout(Driver); Driver.Quit(); ;
        }
    }
}

