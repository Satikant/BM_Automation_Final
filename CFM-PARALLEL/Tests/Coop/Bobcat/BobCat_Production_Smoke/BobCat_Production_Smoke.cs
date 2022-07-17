using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.StartUp;
using NUnit.Framework;
using System;


namespace CFM_PARALLEL.Tests.Coop.Bobcat
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures)]
    public class BobCat_Production_Smoke : Base
    {
        [Test, Parallelizable]
        [Category("CFM_BOBCAT_SMOKE_PROD")]
        public void ST_TC_BOBCAT_CoopAdaptorFlow()
        {
            try
            {                              
                Pages.BrowserURLLaunch().BrowserURL_BOBCAT("CORPORATE1", "Bobcat", "PROD");                
                Pages.BC_CoopAdaptor().Validate_Coop_Adaptor("Business card", "Test");
                //IDictionary<String, Double> FundsBeforeUsingCoopAdaptor = dl.GetAllTheFunds("2019 Compact Tractor");   //Calculate Amounts Before going to use Coop Adaptor
                //Pages.CommonFunctions().ClearShoppingCart();     //Clear Shopping cart
                //Pages.CommonFunctions().NavigatingBackFromShoppingCart();
                //Pages.CommonFunctions().SearchTemplate(TemplateName);   //Search Template
                //Pages.CommonFunctions().BuildTemplateAndAddToCart_Bobcat(TemplateName);   //Building Template
                //Pages.CommonFunctions().validateCoopAmountvisibility_NewCheckout();    //Verifing CoopAMount Visibility                
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Error Message with an exception in BOBCAT_CoopAdaptorFlow: " + ex.Message);
                throw;
            }
            
        } //end of test case

        [Test, Parallelizable]
        [Category("CFM_BOBCAT_SMOKE_PROD")]
        public void ST_TC_BOBCAT_Claim()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_BOBCAT("CORPORATE1", "Bobcat", "PROD");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.BC_Claim().Bobcat_Claim_Fullflow();
                Pages.BC_Claim().Validate_Claims();               
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Error Message with an exception in BOBCAT_Claim: " + ex.Message);
                throw;
            }
           
        } //end of test case

        [Test, Parallelizable]
        [Category("CFM_BOBCAT_SMOKE_PROD")]
        public void ST_TC_BOBCAT_Dashboard()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_BOBCAT("CORPORATE1", "Bobcat", "PROD");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.BC_Dashboard().DashBoard_Validation();              
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Error Message with an exception in BOBCAT_Dashboard: " + ex.Message);
                throw;
            }
           
        } //end of test case

        [Test, Parallelizable]
        [Category("CFM_BOBCAT_SMOKE_PROD")]
        public void ST_TC_BOBCAT_FundSnapShot()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_BOBCAT("CORPORATE1", "Bobcat", "PROD");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.BC_Dashboard().FundSnapshot_Validation();                
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Error Message with an exception in BOBCAT_FundSnapShot: " + ex.Message);
                throw;
            }
            
        } //end of test case

        [Test, Parallelizable]
        [Category("CFM_BOBCAT_SMOKE_PROD")]
        public void ST_TC_BOBCAT_BrandPreApproval()
        {
            try
            {
                Pages.BrowserURLLaunch().BrowserURL_BOBCAT("CORPORATE1", "Bobcat", "PROD");
                Pages.BrowserURLLaunch().Click_CFMLink();
                Pages.BC_BPA().BPA_FullFlow_Validation();               
            }
            catch (Exception ex)
            {
                Pages.BasicInteractions().TakeScreenshots(TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Error Message with an exception in BOBCAT_BrandPreApproval: " + ex.Message);
                throw;
            }            
        } //end of test case
    } //end of class
} // end of namespace
