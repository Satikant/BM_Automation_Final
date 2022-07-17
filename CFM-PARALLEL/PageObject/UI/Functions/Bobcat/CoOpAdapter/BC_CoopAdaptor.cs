using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.Coop_Funds;
using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace CFM_PARALLEL.PageObject.UI.Functions.Bobcat
{
    public class BC_CoopAdaptor
    {
        private OBJ_CoopAdaptor obj_coopadaptor;
        //Constructor

        public BC_CoopAdaptor()
        {
            obj_coopadaptor = new OBJ_CoopAdaptor();
        }

        public void Validate_Coop_Adaptor(string TemplateName, string ProjectName)
        {
            try
            {

                Pages.BasicInteractions().Click(obj_coopadaptor.MarketingMaterial);
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.TxbKeyword);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_coopadaptor.TxbKeyword);
                Pages.BasicInteractions().Clear(obj_coopadaptor.TxbKeyword);
                Pages.BasicInteractions().Type(obj_coopadaptor.TxbKeyword, TemplateName);
                Pages.BasicInteractions().Click(obj_coopadaptor.GoButton);
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.TractorBtnBuild);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().Click(obj_coopadaptor.TractorBtnBuild);

                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.SelectLocationForAd);
                Pages.BasicInteractions().Click(obj_coopadaptor.SelectLocationForAd);
                Pages.BasicInteractions().Click(obj_coopadaptor.ContinueButton);
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.RadiobtnSelectVehicle);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().Click(obj_coopadaptor.RadiobtnSelectVehicle);
                Pages.BasicInteractions().Click(obj_coopadaptor.SaveYourWorkButtonForVehicle);
                Pages.BasicInteractions().Clear(obj_coopadaptor.TxbTemplatename);
                Pages.BasicInteractions().Type(obj_coopadaptor.TxbTemplatename, ProjectName);
                Pages.BasicInteractions().Click(obj_coopadaptor.BtnFinish);                
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.Print_Ship_Option);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().Click(obj_coopadaptor.Print_Ship_Option);
                Pages.BasicInteractions().WaitTime(5);
                Pages.BasicInteractions().Click(obj_coopadaptor.BtnContinue_DeliveryOption);
                Pages.BasicInteractions().WaitTime(15);
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.DdlQuantity);

                IList<string> Options = Pages.BasicInteractions().GetAllOptions(obj_coopadaptor.DdlQuantity);
                Pages.BasicInteractions().SelectByText(obj_coopadaptor.DdlQuantity, Options[1]);
                Pages.BasicInteractions().WaitTime(2);
                Pages.BasicInteractions().Click(obj_coopadaptor.BtnAddToCart);
                Pages.BasicInteractions().WaitTime(30);
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.BtnCheckout);
                Pages.BasicInteractions().Click(obj_coopadaptor.BtnCheckout);

                Pages.BasicInteractions().WaitTime(30);
                Pages.BasicInteractions().WaitVisible(obj_coopadaptor.BtnCheckout);
                Pages.BasicInteractions().Click(obj_coopadaptor.BtnCheckout);
                Pages.BasicInteractions().WaitTime(15);                
                Pages.BasicInteractions().Click(obj_coopadaptor.ChbtermsandConditions);
                Pages.BasicInteractions().IsElementPresent(obj_coopadaptor.BtnPlaceOrder);
                Pages.BasicInteractions().WaitTime(15);
                Pages.BasicInteractions().Click(obj_coopadaptor.NavigateBackLink);
                Pages.BasicInteractions().WaitTime(10);
                Pages.BasicInteractions().Click(obj_coopadaptor.NavigateBackLink);
                Pages.BasicInteractions().WaitTime(5);

                Pages.BasicInteractions().WaitUntilElementVisible(obj_coopadaptor.RemoveItemButton,120);
                Pages.BasicInteractions().Click(obj_coopadaptor.RemoveItemButton);

                Pages.BasicInteractions().WaitUntilElementVisible(obj_coopadaptor.ConfirmRemoveItemButton,120);
                Pages.BasicInteractions().Click(obj_coopadaptor.ConfirmRemoveItemButton);
                Pages.BasicInteractions().WaitUntilElementVisible(obj_coopadaptor.ContinueShoppingButton,120);
                Assert.True(Pages.BasicInteractions().IsElementDisplayed(obj_coopadaptor.ContinueShoppingButton));

            }

            catch(Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                throw;
            }
        }
    }
}
