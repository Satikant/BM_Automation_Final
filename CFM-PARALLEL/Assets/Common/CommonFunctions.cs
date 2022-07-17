using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Claims;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Coop_Funds;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Transactions;
using CFM_PARALLEL.StartUp;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CFM_PARALLEL.Common
{
    class CommonFunctions
    {
        private IWebDriver Driver;
        private Base bs;
        private BrowserURLLaunch bl;
        private OBJ_Dashboard obj_dashboard;
        private OBJ_Claims obj_claims;
        private BasicInteractions bi;
        private OBJ_CoopAdaptor obj_coopadaptor;
        private OBJ_Common obj_common;
        private OBJ_Transactions obj_transaction;
        //Constructor
        public CommonFunctions(IWebDriver Driver)
        {
            this.Driver = Driver;
            bs = new Base();
            bl = new BrowserURLLaunch(Driver);
            obj_dashboard = new OBJ_Dashboard();
            bi = new BasicInteractions(Driver);
            obj_claims = new OBJ_Claims();
            obj_coopadaptor = new OBJ_CoopAdaptor();
            obj_common = new OBJ_Common();
            obj_transaction = new OBJ_Transactions();
        }

        //Navigating to Search Creative page
        public void NavigateSearchCreative()
        {
            try
            {
                bi.WaitVisible(obj_coopadaptor.lnkSearchMaterials);
                bi.Click(obj_coopadaptor.lnkSearchMaterials);
                bi.WaitForPageToLoad(120);
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //Emulate User
        public void EmulateUser(string Username)
        {
            try
            {
                bi.WaitForPageToLoad(120);
                bi.WaitTime(5);
                //Click on EmulateUser link
                bi.ClickJavaScript(obj_common.lnkEmulateUser);
                bi.WaitTime(5);
                //Enable textbox SelectUserToEmulate
                bi.Click(obj_common.txbSelectUserToEmulate);
                bi.WaitTime(5);
                bi.WaitForPageToLoad(60);
                //Type User's name to Emulate
                bi.Type(obj_common.txbSelectUserToEmulate, Username);
                bi.WaitTime(15);
                bi.Type(obj_common.txbSelectUserToEmulate, Keys.Enter);
                //Click on Emulate Now button
                bi.Click(obj_common.btnEmulateNow);
                bi.WaitForPageToLoad(60);
                bi.IsElementPresent(obj_common.lnkExitEmulation);
                Console.WriteLine("User is Emulated");
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

 


        //Clearing Shopping Cart For Old and New Checkouts
        public void ClearShoppingCart()
        {
            try
            {
                bi.WaitTime(10);
                bi.WaitVisible(obj_common.imgShoppingCartIcon, 60);
                bi.WaitUntilElementClickable(obj_common.imgShoppingCartIcon, 60);
                if (Convert.ToInt32(bi.GetText(obj_common.lblOrderLinesAddedTocart)) != 0)
                {
                    //interactions.WaitUntilElementVisible(obj_QA.imgShoppingCartIcon, 60);
                    bi.ScrollToViewElement(obj_common.imgShoppingCartIcon);
                    bi.WaitUntilElementClickable(obj_common.imgShoppingCartIcon, 25);
                    bi.HoverBy(obj_common.imgShoppingCartIcon);
                    bi.WaitTime(2);
                    if (bi.IsElementEnabled(obj_common.btnViewShoppingCart))
                    {
                        bi.Click(obj_common.btnViewShoppingCart);
                        bi.WaitTime(20);
                        ClickOnDeleteAll();
                    }
                    bi.WaitTime(2);
                }
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //navigating back to home screen from New chekcot
        public void NavigatingBackFromShoppingCart()
        {
            try
            {
                if (bi.IsElementPresent(obj_common.lnkContinueShopping))
                {
                    bi.WaitTime(5);
                    bi.Click(obj_common.lnkContinueShopping);
                    bi.WaitForPageToLoad(120);
                    bi.WaitTime(5);
                }
                else
                {
                    Console.WriteLine("Control not in shopping cart page");
                }
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                //CommonFunctions.KillProcess();
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }
        //Delete all the items from shopping cart for Old and New Checkouts
        public void ClickOnDeleteAll()
        {
            try
            {
                bi.WaitTime(5);
                if (bi.IsElementPresent(obj_common.lnkShoppingCartDeleteAll))
                {
                    bi.Click(obj_common.lnkShoppingCartDeleteAll);
                    bi.WaitTime(10);
                    bi.AcceptAlert();
                    bi.WaitTime(3);
                }
                
                else if(bi.IsElementPresent(obj_common.btnRemove))
                {
                    bi.WaitTime(5);
                    IList<IWebElement> RemoveButtons = bi.getElements(obj_common.btnRemove);
                    foreach(IWebElement btnRemove in RemoveButtons)
                    {
                        btnRemove.Click();
                        bi.WaitTime(3);
                        bi.Click(obj_common.btnConfirm);
                        bi.WaitTime(3);
                    }
                }
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //Navigate To Shopping Cart
        public void NavigateToShoppingCart()
        {
            try
            {
                if (bi.IsElementPresent(obj_common.imgShoppingCartIcon))
                {
                    bi.HoverBy(obj_common.imgShoppingCartIcon);
                }
                bi.WaitTime(2);
                if (bi.IsElementEnabled(obj_common.btnViewShoppingCart))
                {
                    bi.Click(obj_common.btnViewShoppingCart);
                    bi.WaitForPageToLoad(120);
                }
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //Place Order New Checkout
        public void PlaceOrder_NewCheckout()
        {
            try
            {
                bi.WaitVisible(obj_coopadaptor.btnCheckout);
                bi.Click(obj_coopadaptor.btnCheckout);
                bi.WaitTime(20);
                //bi.WaitTime(20);
                if (isShippingMethodsAvailable())
                {
                    bi.WaitVisible(obj_coopadaptor.btnCheckout);
                    bi.Click(obj_coopadaptor.btnCheckout);
                }
                else
                {
                    Console.WriteLine("Shipping Methods are Not Available Or Having Different Xpath");
                    if (bi.IsElementEnabled(obj_coopadaptor.btnCheckout))
                    { bi.Click(obj_coopadaptor.btnCheckout); }
                }
                bi.WaitTime(5);
                    bi.WaitVisible(obj_coopadaptor.btnUseFund);
                    bi.WaitTime(2);
                    //Verifing co-op Option is Available during Checkout
                    Assert.True(bi.IsElementVisible(obj_coopadaptor.lblAvailableCoopFund));
                    Console.WriteLine("Coop Balance is showing during checkout");
                    Regex regex = new Regex("[^0-9.]");

                    decimal Percentage = 50;
                    //Get Order Subtotal
                    string Temp1 = bi.GetText(obj_coopadaptor.OrderSubTotal_NewCheckout).Replace("$", "");
                    string Temp2 = regex.Replace(bi.GetText(obj_coopadaptor.EligibleFunds_NewCheckout).Replace("$", ""),"");

                    decimal OrderSubTotal = Convert.ToDecimal(Temp1); 

                    //Get AvailableCo-op Amount
                    //decimal EligibleAmount = bi.ConvertToDecimalFromDollarString(Temp2);
                    decimal EligibleAmount = Convert.ToDecimal(Temp2);

                    Assert.IsTrue(EligibleAmount == (OrderSubTotal * (Percentage / 100)));
                    ////Checking Order SubTotal
                    //Decimal OrderSubTotal=Convert.ToDecimal(regex.Replace(bi.GetText(obj_coopadaptor.OrderSubTotal_NewCheckout),""));

                    ////Getting Eligible Funds
                    
                    //Decimal EligibleAmount=Convert.ToDecimal(regex.Replace(bi.GetText(obj_coopadaptor.EligibleFunds_NewCheckout), ""));

                    //int Percentage = 50;
                    //Assert.IsTrue(EligibleAmount == (OrderSubTotal * (Percentage / 100)));
                    Console.WriteLine("EligibleAmount Showing" + Percentage + "% of the OrderSubTotal");
                    bi.Click(obj_coopadaptor.btnUseFund);
                    bi.WaitTime(2);
                    bi.Type(obj_coopadaptor.txbUseFund, (EligibleAmount-1).ToString());

                    bi.WaitTime(3);
                    if (bi.IsElementVisible(obj_coopadaptor.tabCorporateBilling))
                    {
                        bi.Click(obj_coopadaptor.tabCorporateBilling);
                    }
               
                    Console.WriteLine("Either Shipping Methods are Not available or Payment Not available for Added Item");
                    if(bi.IsElementVisible(obj_coopadaptor.btnPlaceOrder))
                    {
                        Console.WriteLine("Payment Not available for Added Item");
                    }
                

                bi.WaitTime(10);
                bi.ClickJavaScript(obj_coopadaptor.chbtermsandConditions);
                if(bi.IsElementPresent(obj_coopadaptor.BillingInfo1))
                { bi.TypeClear(obj_coopadaptor.BillingInfo1, "Billing Info1"); }

                if (bi.IsElementPresent(obj_coopadaptor.BillingInfo2))
                { bi.TypeClear(obj_coopadaptor.BillingInfo2, "Billing Info1"); }

                if (bi.IsElementPresent(obj_coopadaptor.CBAccountNumber))
                { bi.TypeClear(obj_coopadaptor.CBAccountNumber, "CBAccountNumber"); }

                if (bi.IsElementPresent(obj_coopadaptor.BillingInstructions))
                { bi.TypeClear(obj_coopadaptor.BillingInstructions, "BillingInstructions"); }


                if (bi.IsElementEnabled(obj_coopadaptor.btnPlaceOrder))
                {
                    bi.Click(obj_coopadaptor.btnPlaceOrder);
                    bi.WaitTime(20);
                    bi.WaitVisible(obj_coopadaptor.lblOrderConfirmation);
                }
                else
                {
                    Console.WriteLine("Place Order button not Enabled");
                }
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }


        //Checking Co-op Amount showing or not in Prod with New Checkout
        public void validateCoopAmountvisibility_NewCheckout()
        {
            try
            {
                bi.WaitVisible(obj_coopadaptor.btnCheckout);
                bi.Click(obj_coopadaptor.btnCheckout);
                bi.WaitTime(20);
                if (isShippingMethodsAvailable())
                {
                    bi.WaitVisible(obj_coopadaptor.btnCheckout);
                    bi.Click(obj_coopadaptor.btnCheckout);
                }
                else
                {
                    Console.WriteLine("Shipping Methods are Not Available Or Having Different Xpath");
                    if (bi.IsElementEnabled(obj_coopadaptor.btnCheckout))
                    { bi.Click(obj_coopadaptor.btnCheckout); }
                }
                bi.WaitVisible(obj_coopadaptor.btnUseFund);
                bi.WaitTime(2);

                Assert.True(bi.IsElementVisible(obj_coopadaptor.lblAvailableCoopFund));
                Console.WriteLine("Coop Balance is showing during checkout");
                //Verifing co-op Option is Available during Checkout
                Assert.True(bi.IsElementVisible(obj_coopadaptor.lblAvailableCoopFund));
                Console.WriteLine("Coop Balance is showing during checkout");
                Regex regex = new Regex("[^0-9.]");

                decimal Percentage = 50;
                //Get Order Subtotal
                string Temp1 = bi.GetText(obj_coopadaptor.OrderSubTotal_NewCheckout).Replace("$", "");
                string Temp2 = regex.Replace(bi.GetText(obj_coopadaptor.EligibleFunds_NewCheckout).Replace("$", ""), "");

                decimal OrderSubTotal = Convert.ToDecimal(Temp1);

                //Get AvailableCo-op Amount
                //decimal EligibleAmount = bi.ConvertToDecimalFromDollarString(Temp2);
                decimal EligibleAmount = Convert.ToDecimal(Temp2);

                Assert.IsTrue(EligibleAmount == (OrderSubTotal * (Percentage / 100)));
                Console.WriteLine("EligibleAmount Showing" + Percentage + "% of the OrderSubTotal");
            }
            catch (Exception ex)
            {
               //                 CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        public static string UniqueName(string name)
        {
            string timeStamp = DateTime.Now.ToString();
            timeStamp = timeStamp.Replace("/", "").Replace(" ", "").Replace(":", "");
            return name + timeStamp;
        }

        //Checking Co-op Amount showing with OldCheckout
        public void validateCoopAmountvisibility_OldCheckout()
        {
            try
            {
                bi.WaitUntilElementClickable(obj_common.btnAddToShoppingCartCheckout, 60);
                bi.Click(obj_common.btnAddToShoppingCartCheckout);
                bi.WaitForPageToLoad(60);
                bi.WaitTillNotVisible(obj_common.ImgProcessing);
                if (isShippingMethodsAvailable())
                {
                    bi.Click(obj_common.btnAddToShoppingCartShipInfoSelectPayment);
                }
                else
                {
                    Console.WriteLine("Shipping Methods are Not Available");
                }
                bi.WaitForPageToLoad(120);
                bi.WaitVisible(obj_common.txbNameyourOrder, 45);

                Assert.IsTrue(bi.IsElementPresent(obj_coopadaptor.AmountToApplyCoop));
                Console.WriteLine("Co-op Amount showing while Checkout");
                int Percentage = 100;
                //Get Order Subtotal
                string Temp1 = bi.GetText(obj_coopadaptor.OrderSubTotal).Replace("$", "");
                string Temp2 = bi.GetText(obj_coopadaptor.AvailableCoopBalance).Replace("$", "");
                decimal OrderSubTotal = Convert.ToDecimal(Temp1);

                //Get AvailableCo-op Amount
                decimal AvailableCoopAmount = Convert.ToDecimal(Temp2);

                Assert.IsTrue(AvailableCoopAmount == (OrderSubTotal * (Percentage / 100)));
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //Checking is Shipping Methods are Available or not
        public bool isShippingMethodsAvailable()
        {
            try
            {
                if (bi.IsElementPresent(obj_common.rbtnShippingMethods))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;

                
            }
        }


        //Search Template
        public void SearchTemplate(string TemplateName)
        {
            try
            {
                NavigateSearchCreative();
                bi.WaitTime(5);
                bi.WaitVisible(obj_coopadaptor.txbKeyword);
                bi.TypeClear(obj_coopadaptor.txbKeyword, TemplateName);
                bi.Type(obj_coopadaptor.txbKeyword, Keys.Enter);

                bi.WaitVisible(obj_coopadaptor.btnBuild);
                bi.Click(obj_coopadaptor.btnBuild);
                bi.WaitTillNotVisible(obj_coopadaptor.ImgProcessing);
                bi.WaitTime(10);
                //bi.WaitVisible(obj_coopadaptor.rbtnSelectTheme);
            }
            catch (Exception ex)
            {
               //                 CommonUtilities.Logout(Driver);       Driver.Quit();;
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }


        //Building Template for ACE
        public void BuildTemplateAndAddToCart_ACE(string TemplateName)
        {
            try
            {
                bi.Click(obj_coopadaptor.rbtnSelectTheme);
                //bi.WaitTillNotVisible(obj_coopadaptor.LoadingImgComposer);
                bi.WaitVisible(obj_coopadaptor.imgSelectTheme);
                bi.Click(obj_coopadaptor.imgSelectTheme);
                //bi.WaitTillNotVisible(obj_coopadaptor.LoadingImgComposer);

                bi.Click(obj_coopadaptor.stepSelectLogo);
                bi.WaitVisible(obj_coopadaptor.rbtnLogoStep1);
                bi.Click(obj_coopadaptor.rbtnLogoStep1);
                bi.Click(obj_coopadaptor.stepEditCopy);
                bi.WaitTime(5);
                bi.Click(obj_coopadaptor.StepVerifyLocationInformation);
                bi.WaitTime(5);

                bi.Click(obj_coopadaptor.divStep2);
                bi.WaitVisible(obj_coopadaptor.rbtnLogoStep2);
                bi.Click(obj_coopadaptor.rbtnLogoStep2);
                bi.WaitTime(5);
                bi.Click(obj_coopadaptor.StepSelectLayout);
                bi.WaitVisible(obj_coopadaptor.rbtnLayout);
                bi.Click(obj_coopadaptor.rbtnLayout);
                bi.WaitTime(5);
                bi.Click(obj_coopadaptor.StepSelectImage);
                bi.WaitTime(5);
                bi.Click(obj_coopadaptor.stepEditCopy2);
                bi.WaitTime(5);

                bi.Type(obj_coopadaptor.txbTemplatename, "CoopAdaptorTest");
                bi.Click(obj_coopadaptor.btnFinish);
                bi.WaitTillNotVisible(obj_coopadaptor.ImgProcessing);
                bi.WaitVisible(obj_coopadaptor.rbtnDropship);

                bi.Click(obj_coopadaptor.rbtnDropship);
                bi.Click(obj_coopadaptor.btnContinue_DeliveryOption);
                bi.WaitForPageToLoad(120);
                //bi.WaitVisible(obj_coopadaptor.btnCheckout);
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //Building Template for Bobcat
        public void BuildTemplateAndAddToCart_Bobcat(string TemplateName)
        {
            try
            {
                bi.WaitVisible(obj_coopadaptor.rbtnSelectVehicle);
                bi.Click(obj_coopadaptor.rbtnSelectVehicle);
                //bi.WaitTillNotVisible(obj_coopadaptor.LoadingImgComposer);
                bi.WaitTime(5);

                bi.Click(obj_coopadaptor.StepLocationInformation);
                bi.WaitTime(5);
                bi.TypeClear(obj_coopadaptor.txbPhone,"(789) 012-2345");

                bi.WaitVisible(obj_coopadaptor.divBack);
                bi.Click(obj_coopadaptor.divBack);
                bi.WaitTime(5);

                bi.Type(obj_coopadaptor.txbTemplatename, "CoopAdaptorTest");
                bi.Click(obj_coopadaptor.btnFinish);
                bi.WaitTillNotVisible(obj_coopadaptor.ImgProcessing);
                bi.WaitVisible(obj_coopadaptor.rbtnDropship);

                bi.Click(obj_coopadaptor.rbtnDropship);
                bi.Click(obj_coopadaptor.btnContinue_DeliveryOption);
                bi.WaitForPageToLoad(120);

                if (bi.IsElementPresent(obj_coopadaptor.txbQuantity))
                {
                    bi.TypeClear(obj_coopadaptor.txbQuantity, "10");
                    bi.WaitTime(5);
                }
                else
                {
                    IList<string> Options=bi.GetAllOptions(obj_coopadaptor.ddlQuantity);
                    bi.SelectByText(obj_coopadaptor.ddlQuantity, Options[1]);
                }
                bi.Click(obj_coopadaptor.lnkUpdateQuantities);
                bi.WaitForPageToLoad(120);
                bi.WaitTime(10);
                bi.Click(obj_coopadaptor.btnAddToCart1);
                bi.WaitForPageToLoad(120);
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //Search Item and Add To Cart
        public void SearchTItemAndAddToCart(string TemplateName)
        {
            try
            {
                //Navigating to Search page
                NavigateSearchCreative();

                //Search for the Template
                bi.WaitTime(5);
                bi.WaitVisible(obj_coopadaptor.txbKeyword);
                bi.TypeClear(obj_coopadaptor.txbKeyword, TemplateName);
                bi.Type(obj_coopadaptor.txbKeyword, Keys.Enter);

                //Add to Cart
                bi.WaitVisible(obj_coopadaptor.btnAddToShoppingCart);
                bi.Click(obj_coopadaptor.btnAddToShoppingCart);
                bi.WaitTillNotVisible(obj_coopadaptor.ImgProcessing);
                bi.WaitTime(10);
            }
            catch (Exception ex)
            {
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //Get AvailableFunds
        //Get Available Funds for Program
        public String GetAvailableFunds(string ProgramName)
        {
            // BasicInteractions bi=new BasicInteractions(Driver)

            try
            {
                bi.WaitTillNotVisible(obj_dashboard.imgLoading);
                bi.WaitTillNotVisible(obj_transaction.LoadingImage);
                if (bi.IsElementDisplayed(obj_transaction.ProgramList(ProgramName)))
                {
                    bi.WaitTime(5);
                    bi.Click(obj_transaction.ProgramList(ProgramName));

                }
                else
                {
                    bi.WaitTime(5);
                    bi.WaitVisible(obj_transaction.OtherProgramsLink);
                    bi.Click(obj_transaction.OtherProgramsLink);
                    bi.WaitTime(5);
                    bi.Click(obj_transaction.ProgramList(ProgramName));
                }
                bi.WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                bi.WaitTime(10);
                string AvailableFund = bi.GetText(obj_transaction.AvailableFunds);

                if (AvailableFund.Contains("(") | AvailableFund.Contains(")"))
                {
                    AvailableFund = "-" + AvailableFund.Replace("(", "").Replace(")", "");
                }
                return AvailableFund.Replace("$","");
            }
            catch (Exception ex)
            {

CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }

        public static void KillProcess()
        {
            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");

            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                chromeDriverProcess.Kill();
            }
        }

        

    }
}
