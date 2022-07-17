using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Coop_Funds;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Dashboard;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Transactions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CFM_PARALLEL.Common
{
    class CommonFunctions
    {
        private OBJ_Dashboard obj_dashboard;
        private OBJ_CoopAdaptor obj_coopadaptor;
        private OBJ_Common obj_common;
        private OBJ_Transactions obj_transaction;

        public CommonFunctions()
        {
            obj_dashboard = new OBJ_Dashboard();
            obj_coopadaptor = new OBJ_CoopAdaptor();
            obj_common = new OBJ_Common();
            obj_transaction = new OBJ_Transactions();
        }

        //Navigating to Search Creative page
        public void NavigateSearchCreative()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.LnkSearchMaterials);
                Pages.BasicInteractions().Click(obj_coopadaptor.LnkSearchMaterials);
                Pages.BasicInteractions().WaitForPageToLoad(120);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //Emulate User
        public void EmulateUser(string Username , Boolean isCorruptUser = false)
        {
            try
            {
                Pages.BasicInteractions().WaitForPageToLoad(120);
                Pages.BasicInteractions().WaitTime(5);
                //Click on EmulateUser link
                Pages.BasicInteractions().ClickJavaScript(obj_common.LnkEmulateUser);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_common.TxbSelectUserToEmulate, 120);
                Pages.BasicInteractions().WaitTime(2);
                //Enable textbox SelectUserToEmulate
                Pages.BasicInteractions().Click(obj_common.TxbSelectUserToEmulate);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_common.HintText, 120);
                //Type User's name to Emulate
                Pages.BasicInteractions().Type(obj_common.TxbSelectUserToEmulate, Username);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_common.EmulateHeaderRow, 120); 
                if (isCorruptUser)
                    Pages.BasicInteractions().Click(obj_common.CorruptUser);
                else
                    Pages.BasicInteractions().Type(obj_common.TxbSelectUserToEmulate, Keys.Enter);
                //Click on Emulate Now button
                Pages.BasicInteractions().Click(obj_common.BtnEmulateNow);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_common.LnkExitEmulation,120);
                Pages.BasicInteractions().IsElementPresent(obj_common.LnkExitEmulation);
                Console.WriteLine("User is Emulated");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in EmulateUser method: " + ex.Message);
                throw;
            }
        }       

        //Exit Emulation
        public void ExitEmulation()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_common.LnkExitEmulation);                
                Pages.BasicInteractions().ClickJavaScript(obj_common.LnkExitEmulation);
                Pages.BasicInteractions().WaitTime(10);
                if (Pages.BasicInteractions().IsElementDisplayed(obj_common.Farmers_EmulateUser))
                Pages.BasicInteractions().WaitVisible(obj_common.Farmers_EmulateUser);
                else
                Pages.BasicInteractions().WaitVisible(obj_common.LnkEmulateUser);             
               
                Console.WriteLine("User is exit and ready to Emulate other user");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in ExitEmulation method: " + ex.Message);
                throw;
            }
        }

        public void Farmers_EmulateUser(string EmulateUser, Boolean isCorruptUser = false)
        {
            try
            {
                Pages.BasicInteractions().WaitForPageToLoad(120);
               // Pages.BasicInteractions().WaitVisible(obj_common.AdminOption);
                Pages.BasicInteractions().WaitVisible(obj_common.Farmers_EmulateUser);
                Pages.BasicInteractions().Click(obj_common.Farmers_EmulateUser);
                /*Pages.BasicInteractions().WaitVisible(obj_common.EmulatingAgent);
                Pages.BasicInteractions().Click(obj_common.EmulatingAgent);
                Pages.BasicInteractions().WaitVisible(obj_common.AgentRadioBtn);
                Pages.BasicInteractions().Click(obj_common.AgentRadioBtn);
                Pages.BasicInteractions().WaitVisible(obj_common.EmulationSearchText);
                Pages.BasicInteractions().Click(obj_common.EmulationSearchText);
                Pages.BasicInteractions().Type(obj_common.EmulationSearchText, EmulateUser);
                Pages.BasicInteractions().Click(obj_common.FindButton);
                Pages.BasicInteractions().WaitVisible(obj_common.UserOption);
                Pages.BasicInteractions().Click(obj_common.UserOption);
                Pages.BasicInteractions().Click(obj_common.EmulateButton);               
                Pages.BasicInteractions().WaitUntilElementVisible(obj_common.LnkExitEmulation, 120);
                Pages.BasicInteractions().IsElementPresent(obj_common.LnkExitEmulation);
                Console.WriteLine("User is Emulated");*/
                Pages.BasicInteractions().WaitUntilElementVisible(obj_common.TxbSelectUserToEmulate, 120);
                Pages.BasicInteractions().WaitTime(2);
                //Enable textbox SelectUserToEmulate
                Pages.BasicInteractions().Click(obj_common.TxbSelectUserToEmulate);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_common.HintText, 120);
                //Type User's name to Emulate
                Pages.BasicInteractions().Type(obj_common.TxbSelectUserToEmulate, EmulateUser);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_common.EmulateHeaderRow, 120);
                if (isCorruptUser)
                    Pages.BasicInteractions().Click(obj_common.CorruptUser);
                else
                    Pages.BasicInteractions().Type(obj_common.TxbSelectUserToEmulate, Keys.Enter);
                //Click on Emulate Now button
                Pages.BasicInteractions().Click(obj_common.BtnEmulateNow);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_common.LnkExitEmulation, 120);
                Pages.BasicInteractions().IsElementPresent(obj_common.LnkExitEmulation);
                Console.WriteLine("User is Emulated");

                Pages.BasicInteractions().Gotourl("https://farmers.v5stage.brandmuscle.net/cfm/cfm.aspx");
                Pages.BasicInteractions().WaitUntilElementVisible(obj_dashboard.LeftNavDashboard,240);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message with an exception in Farmers_EmulateUser method: " + ex.Message);
                throw;
            }
        }


        //Clearing Shopping Cart For Old and New Checkouts
        public void ClearShoppingCart()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().WaitVisible(obj_common.ImgShoppingCartIcon, 60);
                Pages.BasicInteractions().WaitUntilElementClickable(obj_common.ImgShoppingCartIcon, 60);
                if (Convert.ToInt32(Pages.BasicInteractions().GetText(obj_common.LblOrderLinesAddedTocart)) != 0)
                {
                    //interactions.WaitUntilElementVisible(obj_QA.imgShoppingCartIcon, 60);
                    Pages.BasicInteractions().ScrollToViewElement(obj_common.ImgShoppingCartIcon);
                    Pages.BasicInteractions().WaitUntilElementClickable(obj_common.ImgShoppingCartIcon, 25);
                    Pages.BasicInteractions().HoverBy(obj_common.ImgShoppingCartIcon);
                    Pages.BasicInteractions().WaitTime(2);
                    if (Pages.BasicInteractions().IsElementEnabled(obj_common.BtnViewShoppingCart))
                    {
                        Pages.BasicInteractions().Click(obj_common.BtnViewShoppingCart);
                        Pages.BasicInteractions().WaitTime(20);
                        ClickOnDeleteAll();
                    }
                    Pages.BasicInteractions().WaitTime(2);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //navigating back to home screen from New chekcot
        public void NavigatingBackFromShoppingCart()
        {
            try
            {
                if (Pages.BasicInteractions().IsElementPresent(obj_common.LnkContinueShopping))
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_common.LnkContinueShopping);
                    Pages.BasicInteractions().WaitForPageToLoad(120);
                    Pages.BasicInteractions().WaitTime(5);
                }
                else
                {
                    Console.WriteLine("Control not in shopping cart page");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }
        //Delete all the items from shopping cart for Old and New Checkouts
        public void ClickOnDeleteAll()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(5);
                if (Pages.BasicInteractions().IsElementPresent(obj_common.LnkShoppingCartDeleteAll))
                {
                    Pages.BasicInteractions().Click(obj_common.LnkShoppingCartDeleteAll);
                    Pages.BasicInteractions().WaitTime(10);
                    Pages.BasicInteractions().AcceptAlert();
                    Pages.BasicInteractions().WaitTime(3);
                }
                
                else if(Pages.BasicInteractions().IsElementPresent(obj_common.BtnRemove))
                {
                    Pages.BasicInteractions().WaitTime(5);
                    IList<IWebElement> RemoveButtons = Pages.BasicInteractions().GetElements(obj_common.BtnRemove);
                    foreach(IWebElement btnRemove in RemoveButtons)
                    {
                        btnRemove.Click();
                        Pages.BasicInteractions().WaitTime(3);
                        Pages.BasicInteractions().Click(obj_common.BtnConfirm);
                        Pages.BasicInteractions().WaitTime(3);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //Navigate To Shopping Cart
        public void NavigateToShoppingCart()
        {
            try
            {
                if (Pages.BasicInteractions().IsElementPresent(obj_common.ImgShoppingCartIcon))
                {
                    Pages.BasicInteractions().HoverBy(obj_common.ImgShoppingCartIcon);
                }
                Pages.BasicInteractions().WaitTime(2);
                if (Pages.BasicInteractions().IsElementEnabled(obj_common.BtnViewShoppingCart))
                {
                    Pages.BasicInteractions().Click(obj_common.BtnViewShoppingCart);
                    Pages.BasicInteractions().WaitForPageToLoad(120);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //Place Order New Checkout
        public void PlaceOrder_NewCheckout()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.BtnCheckout);
                Pages.BasicInteractions().Click(obj_coopadaptor.BtnCheckout);
                Pages.BasicInteractions().WaitTime(20);
                //Pages.BasicInteractions().WaitTime(20);
                if (IsShippingMethodsAvailable())
                {
                    Pages.BasicInteractions().WaitVisible(obj_coopadaptor.BtnCheckout);
                    Pages.BasicInteractions().Click(obj_coopadaptor.BtnCheckout);
                }
                else
                {
                    Console.WriteLine("Shipping Methods are Not Available Or Having Different Xpath");
                    if (Pages.BasicInteractions().IsElementEnabled(obj_coopadaptor.BtnCheckout))
                    { Pages.BasicInteractions().Click(obj_coopadaptor.BtnCheckout); }
                }
                Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().WaitVisible(obj_coopadaptor.BtnUseFund);
                    Pages.BasicInteractions().WaitTime(2);
                    //Verifing co-op Option is Available during Checkout
                    Assert.True(Pages.BasicInteractions().IsElementVisible(obj_coopadaptor.LblAvailableCoopFund));
                    Console.WriteLine("Coop Balance is showing during checkout");
                    Regex regex = new Regex("[^0-9.]");

                    decimal Percentage = 50;
                    //Get Order Subtotal
                    string Temp1 = Pages.BasicInteractions().GetText(obj_coopadaptor.OrderSubTotal_NewCheckout).Replace("$", "");
                    string Temp2 = regex.Replace(Pages.BasicInteractions().GetText(obj_coopadaptor.EligibleFunds_NewCheckout).Replace("$", ""),"");

                    decimal OrderSubTotal = Convert.ToDecimal(Temp1); 

                    //Get AvailableCo-op Amount
                    //decimal EligibleAmount = Pages.BasicInteractions().ConvertToDecimalFromDollarString(Temp2);
                    decimal EligibleAmount = Convert.ToDecimal(Temp2);

                    Assert.IsTrue(EligibleAmount == (OrderSubTotal * (Percentage / 100)));
                    ////Checking Order SubTotal
                    //Decimal OrderSubTotal=Convert.ToDecimal(regex.Replace(Pages.BasicInteractions().GetText(obj_coopadaptor.OrderSubTotal_NewCheckout),""));

                    ////Getting Eligible Funds
                    
                    //Decimal EligibleAmount=Convert.ToDecimal(regex.Replace(Pages.BasicInteractions().GetText(obj_coopadaptor.EligibleFunds_NewCheckout), ""));

                    //int Percentage = 50;
                    //Assert.IsTrue(EligibleAmount == (OrderSubTotal * (Percentage / 100)));
                    Console.WriteLine("EligibleAmount Showing" + Percentage + "% of the OrderSubTotal");
                    Pages.BasicInteractions().Click(obj_coopadaptor.BtnUseFund);
                    Pages.BasicInteractions().WaitTime(2);
                    Pages.BasicInteractions().Type(obj_coopadaptor.TxbUseFund, (EligibleAmount-1).ToString());

                    Pages.BasicInteractions().WaitTime(3);
                    if (Pages.BasicInteractions().IsElementVisible(obj_coopadaptor.TabCorporateBilling))
                    {
                        Pages.BasicInteractions().Click(obj_coopadaptor.TabCorporateBilling);
                    }
               
                    Console.WriteLine("Either Shipping Methods are Not available or Payment Not available for Added Item");
                    if(Pages.BasicInteractions().IsElementVisible(obj_coopadaptor.BtnPlaceOrder))
                    {
                        Console.WriteLine("Payment Not available for Added Item");
                    }
                

                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().ClickJavaScript(obj_coopadaptor.ChbtermsandConditions);
                if(Pages.BasicInteractions().IsElementPresent(obj_coopadaptor.BillingInfo1))
                { Pages.BasicInteractions().TypeClear(obj_coopadaptor.BillingInfo1, "Billing Info1"); }

                if (Pages.BasicInteractions().IsElementPresent(obj_coopadaptor.BillingInfo2))
                { Pages.BasicInteractions().TypeClear(obj_coopadaptor.BillingInfo2, "Billing Info1"); }

                if (Pages.BasicInteractions().IsElementPresent(obj_coopadaptor.CBAccountNumber))
                { Pages.BasicInteractions().TypeClear(obj_coopadaptor.CBAccountNumber, "CBAccountNumber"); }

                if (Pages.BasicInteractions().IsElementPresent(obj_coopadaptor.BillingInstructions))
                { Pages.BasicInteractions().TypeClear(obj_coopadaptor.BillingInstructions, "BillingInstructions"); }


                if (Pages.BasicInteractions().IsElementEnabled(obj_coopadaptor.BtnPlaceOrder))
                {
                    Pages.BasicInteractions().Click(obj_coopadaptor.BtnPlaceOrder);
                    Pages.BasicInteractions().WaitTime(20);
                    Pages.BasicInteractions().WaitVisible(obj_coopadaptor.LblOrderConfirmation);
                }
                else
                {
                    Console.WriteLine("Place Order button not Enabled");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }


        //Checking Co-op Amount showing or not in Prod with New Checkout
        public void ValidateCoopAmountvisibility_NewCheckout()
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.BtnCheckout);
                Pages.BasicInteractions().Click(obj_coopadaptor.BtnCheckout);
                Pages.BasicInteractions().WaitTime(20);
                if (IsShippingMethodsAvailable())
                {
                    Pages.BasicInteractions().WaitVisible(obj_coopadaptor.BtnCheckout);
                    Pages.BasicInteractions().Click(obj_coopadaptor.BtnCheckout);
                }
                else
                {
                    Console.WriteLine("Shipping Methods are Not Available Or Having Different Xpath");
                    if (Pages.BasicInteractions().IsElementEnabled(obj_coopadaptor.BtnCheckout))
                    { Pages.BasicInteractions().Click(obj_coopadaptor.BtnCheckout); }
                }
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.BtnUseFund);
                Pages.BasicInteractions().WaitTime(2);

                Assert.True(Pages.BasicInteractions().IsElementVisible(obj_coopadaptor.LblAvailableCoopFund));
                Console.WriteLine("Coop Balance is showing during checkout");
                //Verifing co-op Option is Available during Checkout
                Assert.True(Pages.BasicInteractions().IsElementVisible(obj_coopadaptor.LblAvailableCoopFund));
                Console.WriteLine("Coop Balance is showing during checkout");
                Regex regex = new Regex("[^0-9.]");

                decimal Percentage = 50;
                //Get Order Subtotal
                string Temp1 = Pages.BasicInteractions().GetText(obj_coopadaptor.OrderSubTotal_NewCheckout).Replace("$", "");
                string Temp2 = regex.Replace(Pages.BasicInteractions().GetText(obj_coopadaptor.EligibleFunds_NewCheckout).Replace("$", ""), "");

                decimal OrderSubTotal = Convert.ToDecimal(Temp1);

                //Get AvailableCo-op Amount
                //decimal EligibleAmount = Pages.BasicInteractions().ConvertToDecimalFromDollarString(Temp2);
                decimal EligibleAmount = Convert.ToDecimal(Temp2);

                Assert.IsTrue(EligibleAmount == (OrderSubTotal * (Percentage / 100)));
                Console.WriteLine("EligibleAmount Showing" + Percentage + "% of the OrderSubTotal");
            }
            catch (Exception ex)
            {
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
        public void ValidateCoopAmountvisibility_OldCheckout()
        {
            try
            {
                Pages.BasicInteractions().WaitUntilElementClickable(obj_common.BtnAddToShoppingCartCheckout, 60);
                Pages.BasicInteractions().Click(obj_common.BtnAddToShoppingCartCheckout);
                Pages.BasicInteractions().WaitForPageToLoad(60);
                Pages.BasicInteractions().WaitTillNotVisible(obj_common.ImgProcessing);
                if (IsShippingMethodsAvailable())
                {
                    Pages.BasicInteractions().Click(obj_common.BtnAddToShoppingCartShipInfoSelectPayment);
                }
                else
                {
                    Console.WriteLine("Shipping Methods are Not Available");
                }
                Pages.BasicInteractions().WaitForPageToLoad(120);
                Pages.BasicInteractions().WaitVisible(obj_common.TxbNameyourOrder, 45);

                Assert.IsTrue(Pages.BasicInteractions().IsElementPresent(obj_coopadaptor.AmountToApplyCoop));
                Console.WriteLine("Co-op Amount showing while Checkout");
                int Percentage = 100;
                //Get Order Subtotal
                string Temp1 = Pages.BasicInteractions().GetText(obj_coopadaptor.OrderSubTotal).Replace("$", "");
                string Temp2 = Pages.BasicInteractions().GetText(obj_coopadaptor.AvailableCoopBalance).Replace("$", "");
                decimal OrderSubTotal = Convert.ToDecimal(Temp1);

                //Get AvailableCo-op Amount
                decimal AvailableCoopAmount = Convert.ToDecimal(Temp2);

                Assert.IsTrue(AvailableCoopAmount == (OrderSubTotal * (Percentage / 100)));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //Checking is Shipping Methods are Available or not
        public bool IsShippingMethodsAvailable()
        {
            try
            {
                if (Pages.BasicInteractions().IsElementPresent(obj_common.RbtnShippingMethods))
                    return true;
                else
                    return false;
            }
            catch (Exception )
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
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.TxbKeyword);
                Pages.BasicInteractions().TypeClear(obj_coopadaptor.TxbKeyword, TemplateName);
                Pages.BasicInteractions().Type(obj_coopadaptor.TxbKeyword, Keys.Enter);

                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.BtnBuild);
                Pages.BasicInteractions().Click(obj_coopadaptor.BtnBuild);
                Pages.BasicInteractions().WaitTillNotVisible(obj_coopadaptor.ImgProcessing);
                Pages.BasicInteractions().WaitTime(10);
                //Pages.BasicInteractions().WaitVisible(obj_coopadaptor.rbtnSelectTheme);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }


        //Building Template for ACE
        public void BuildTemplateAndAddToCart_ACE(string TemplateName)
        {
            try
            {
                Pages.BasicInteractions().Click(obj_coopadaptor.RbtnSelectTheme);
                //Pages.BasicInteractions().WaitTillNotVisible(obj_coopadaptor.LoadingImgComposer);
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.ImgSelectTheme);
                Pages.BasicInteractions().Click(obj_coopadaptor.ImgSelectTheme);
                //Pages.BasicInteractions().WaitTillNotVisible(obj_coopadaptor.LoadingImgComposer);

                Pages.BasicInteractions().Click(obj_coopadaptor.StepSelectLogo);
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.RbtnLogoStep1);
                Pages.BasicInteractions().Click(obj_coopadaptor.RbtnLogoStep1);
                Pages.BasicInteractions().Click(obj_coopadaptor.StepEditCopy);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_coopadaptor.StepVerifyLocationInformation);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().Click(obj_coopadaptor.DivStep2);
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.RbtnLogoStep2);
                Pages.BasicInteractions().Click(obj_coopadaptor.RbtnLogoStep2);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_coopadaptor.StepSelectLayout);
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.RbtnLayout);
                Pages.BasicInteractions().Click(obj_coopadaptor.RbtnLayout);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_coopadaptor.StepSelectImage);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_coopadaptor.StepEditCopy2);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().Type(obj_coopadaptor.TxbTemplatename, "CoopAdaptorTest");
                Pages.BasicInteractions().Click(obj_coopadaptor.BtnFinish);
                Pages.BasicInteractions().WaitTillNotVisible(obj_coopadaptor.ImgProcessing);
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.RbtnDropship);

                Pages.BasicInteractions().Click(obj_coopadaptor.RbtnDropship);
                Pages.BasicInteractions().Click(obj_coopadaptor.BtnContinue_DeliveryOption);
                Pages.BasicInteractions().WaitForPageToLoad(120);
                //Pages.BasicInteractions().WaitVisible(obj_coopadaptor.btnCheckout);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        //Building Template for Bobcat
        public void BuildTemplateAndAddToCart_Bobcat(string TemplateName)
        {
            try
            {
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.RadiobtnSelectVehicle);
                Pages.BasicInteractions().Click(obj_coopadaptor.RadiobtnSelectVehicle);
                //Pages.BasicInteractions().WaitTillNotVisible(obj_coopadaptor.LoadingImgComposer);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().Click(obj_coopadaptor.StepLocationInformation);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().TypeClear(obj_coopadaptor.TxbPhone,"(789) 012-2345");

                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.DivBack);
                Pages.BasicInteractions().Click(obj_coopadaptor.DivBack);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().Type(obj_coopadaptor.TxbTemplatename, "CoopAdaptorTest");
                Pages.BasicInteractions().Click(obj_coopadaptor.BtnFinish);
                Pages.BasicInteractions().WaitTillNotVisible(obj_coopadaptor.ImgProcessing);
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.RbtnDropship);

                Pages.BasicInteractions().Click(obj_coopadaptor.RbtnDropship);
                Pages.BasicInteractions().Click(obj_coopadaptor.BtnContinue_DeliveryOption);
                Pages.BasicInteractions().WaitForPageToLoad(120);

                if (Pages.BasicInteractions().IsElementPresent(obj_coopadaptor.TxbQuantity))
                {
                    Pages.BasicInteractions().TypeClear(obj_coopadaptor.TxbQuantity, "10");
                    Pages.BasicInteractions().WaitTime(5);
                }
                else
                {
                    IList<string> Options=Pages.BasicInteractions().GetAllOptions(obj_coopadaptor.DdlQuantity);
                    Pages.BasicInteractions().SelectByText(obj_coopadaptor.DdlQuantity, Options[1]);
                }
                Pages.BasicInteractions().Click(obj_coopadaptor.LnkUpdateQuantities);
                Pages.BasicInteractions().WaitForPageToLoad(120);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().Click(obj_coopadaptor.BtnAddToCart);
                Pages.BasicInteractions().WaitForPageToLoad(120);
            }
            catch (Exception ex)
            {
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
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.TxbKeyword);
                Pages.BasicInteractions().TypeClear(obj_coopadaptor.TxbKeyword, TemplateName);
                Pages.BasicInteractions().Type(obj_coopadaptor.TxbKeyword, Keys.Enter);

                //Add to Cart
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.BtnAddToShoppingCart);
                Pages.BasicInteractions().Click(obj_coopadaptor.BtnAddToShoppingCart);
                Pages.BasicInteractions().WaitTillNotVisible(obj_coopadaptor.ImgProcessing);
                Pages.BasicInteractions().WaitTime(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }

        
        //Get Available Funds for Program
        public String GetAvailableFunds(string ProgramName)
        {
            try
            {
                Pages.BasicInteractions().Click(obj_dashboard.LeftNavDashboard);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.LoadingImage);
                if (Pages.BasicInteractions().IsElementDisplayed(obj_transaction.ProgramList(ProgramName)))
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_transaction.ProgramList(ProgramName));
                }
                else
                {
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().WaitVisible(obj_transaction.OtherProgramsLink);
                    Pages.BasicInteractions().Click(obj_transaction.OtherProgramsLink);
                    Pages.BasicInteractions().WaitTime(5);
                    Pages.BasicInteractions().Click(obj_transaction.ProgramList(ProgramName));
                }
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.LoadingImageSnapShot);
                Pages.BasicInteractions().WaitVisible(obj_transaction.AvailableFunds);
                Pages.BasicInteractions().WaitTime(5);
                string AvailableFund = Pages.BasicInteractions().GetText(obj_transaction.AvailableFunds);

                if (AvailableFund.Contains("(") | AvailableFund.Contains(")"))
                {
                    AvailableFund = "-" + AvailableFund.Replace("(", "").Replace(")", "");
                }
                return AvailableFund.Replace("$","");
            }
            catch (Exception ex)
            {
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

        public String DashboardAvailableFunds(string ProgramName)
        {
            string AmountBeforeApproval = null;
            try
            {
                Pages.BasicInteractions().Click(obj_dashboard.LeftNavDashboard);
                Pages.BasicInteractions().WaitTillNotVisible(obj_dashboard.ImgLoading);
                Pages.BasicInteractions().WaitTillNotVisible(obj_transaction.LoadingImage);
                if (Pages.BasicInteractions().IsElementDisplayed(obj_transaction.ProgramList(ProgramName)))
                {
                    Pages.BasicInteractions().WaitTime(5);
                     AmountBeforeApproval = Pages.BasicInteractions().GetText(obj_dashboard.MS_DashboardAvailableFund).Split('$')[1].Replace(",", "");                    
                }

                return AmountBeforeApproval;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }

    }
}
