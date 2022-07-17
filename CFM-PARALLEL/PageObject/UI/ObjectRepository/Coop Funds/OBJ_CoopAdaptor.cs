using OpenQA.Selenium;

namespace CFM_PARALLEL.PageObject.UI.ObjectRepository.Coop_Funds
{
    public class OBJ_CoopAdaptor
    {
        public By MarketingMaterial { get { return By.XPath("//a[contains(@class,'SearchMaterials')]"); } }
        public By TxbKeyword { get { return By.XPath("//input[@id='txtKeywordsTop']"); } }
        public By GoButton { get { return By.XPath("//input[@id='btnKeywordSearchGoTop']"); } }
        public By TractorBtnBuild { get { return By.XPath("//span[contains(text(),'Tractor')]/parent::div/parent::td//button[@id='btnValidate']"); } }
        public By SelectLocationForAd { get { return By.XPath("//table[contains(@class,'locationsTable')]//tbody/tr[2]/td[1]"); } }
        public By ContinueButton { get { return By.XPath("//input[@id='btnContinue']"); } }
        public By RadiobtnSelectVehicle { get { return By.XPath("//input[contains(@id,'radio_Vehicle_Choice_1_0')]"); } }
        public By SaveYourWorkButtonForVehicle { get { return By.XPath("//div[contains(@id,'Vehicle_Choice')]/parent::div/following-sibling::div[@class='actionsContainer']//a[@class='save']"); } }
        public By TxbTemplatename { get { return By.XPath("//input[contains(@id,'TemplateName')]"); } }
        public By BtnFinish { get { return By.Id("btnClientFinish"); } }
        public By Print_Ship_Option { get { return By.XPath("//input[@type='radio' and contains(@value,'DropShip')]"); } }
        public By BtnContinue_DeliveryOption { get { return By.Id("MainContent_btnContinue"); } }
        public By DdlQuantity { get { return By.Id("MainContent_gvItems0_ddlQuantity_0"); } }
        public By BtnAddToCart { get { return By.XPath("//input[contains(@id,'MainContent_btnAddItemToOrder2')]"); } }
        public By BtnCheckout { get { return By.XPath("//button[contains(text(),'Checkout')]"); } }
        public By ARCorporateAddressText { get { return By.XPath("//input[contains(@name,'corporateBillingAddressField1')]"); } }
        public By ChbtermsandConditions { get { return By.Id("termsAndConditions"); } }
        public By BtnPlaceOrder { get { return By.XPath("//button[@class='btn btn-primary' and contains(.,'Place Order')]"); } }
        public By NavigateBackLink { get { return By.XPath("//a[contains(text(),'Back')]"); } }
        public By RemoveItemButton { get { return By.XPath("//button[contains(text(),'Remove')]"); } }
        public By ConfirmRemoveItemButton { get { return By.XPath("//button[contains(text(),'Confirm')]"); } }
        public By ContinueShoppingButton { get { return By.XPath("//button[contains(text(),'Continue Shopping')]"); } }

        public By LnkSearchMaterials { get { return By.XPath("//a[contains(@class,'rmLink') and contains(@href,'SearchCreative.aspx')]"); } }
        public By BtnBuild { get { return By.XPath("//button[contains(@id,'btnValidate')]"); } }
        public By BtnAddToShoppingCart { get { return By.Id("btnAddToShoppingCart"); } }
        public By RbtnSelectTheme { get { return By.XPath("//input[contains(@id,'radio_Choice_1_0')]"); } }
        public By ImgSelectTheme { get { return By.XPath("//img[@class='gallery_image' and @data-lightbox='1']"); } }

        public By StepSelectLogo { get { return By.XPath("//div[@class='stepHeaderText' and contains(text(),'Select Logo')]"); } }
        public By LoadingImgComposer { get { return By.Id("composerLoadingImagePreviewOverlay"); } }

        public By RbtnLogoStep1 { get { return By.Id("radio_AT_SelectLogo_PC_HZ_1_0"); } }
        public By StepEditCopy { get { return By.XPath("//div[@class='stepHeaderText' and contains(text(),'Edit Copy')]"); } }
        public By StepEditCopy2 { get { return By.XPath("(//div[@class='stepHeaderText' and contains(text(),'Edit Copy')])[2]"); } }

        public By StepVerifyLocationInformation { get { return By.XPath("//div[@class='stepHeaderText' and contains(text(),'Verify Location Information')]"); } }

        public By DivStep2 { get { return By.XPath("//div[@class='workflowHeader']"); } }
        public By RbtnLogoStep2 { get { return By.Id("radio_AT_SelectLogo_PC_HZ_2_0"); } }
        public By StepSelectLayout { get { return By.XPath("//div[@class='stepHeaderText' and contains(text(),'Select Layout')]"); } }
        public By RbtnLayout { get { return By.Id("radio_AT_Include_Coupon2_1"); } }

        public By StepSelectImage { get { return By.XPath("//div[@class='stepHeaderText' and contains(text(),'Select Image')]"); } }
        
        public By ImgProcessing { get { return By.Id("imgProcessingImage"); } }

        public By RbtnDropship { get { return By.XPath("//input[contains(@value,'DeliveryOption=DropShip')]"); } }
        public By ShippingModeSelector { get { return By.XPath("//app-shipping-mode-selector"); } }

        public By BtnUseFund { get { return By.XPath("//button[contains(text(),'Use Fund')]"); } }
        public By TxbUseFund { get { return By.XPath("//input[contains(@class,'form-control') and @prefix='$']"); } }

        public By TabCorporateBilling { get { return By.XPath("//span[contains(text(),'Corporate Billing')]"); } }
        public By LblOrderConfirmation { get { return By.XPath("//div[contains(text(),'Order Confirmation')]"); } }
        public By LblAvailableCoopFund { get { return By.XPath("//app-coop-fund/div/div[2]"); } }

        public By AmountToApplyCoop { get { return By.Id("MainContent_PaymentSelection1_rptrFundingAccounts_txtAmountToApply_0"); } }
        public By TotalCoopBalance { get { return By.XPath("//span[contains(@id,'MainContent_PaymentSelection1_rptrFundingAccounts_lblTotalBalnceCoop_0')]"); } }
        public By AvailableCoopBalance { get { return By.XPath("//span[contains(@id,'MainContent_PaymentSelection1_rptrFundingAccounts_lblAvailableAmount_0')]"); } }
        public By OrderSubTotal { get { return By.XPath("//td[@class='CostTotalValue']/span[@class='OrderCostSubTotal']"); } }

        public By OrderSubTotal_NewCheckout { get { return By.XPath("//div[contains(@class,'sub-total')]/div[2]/div"); } }
        public By EligibleFunds_NewCheckout { get { return By.XPath("//app-coop-fund/div/div[2]"); } }

        //Objects for BOBCAT Template
        public By StepLocationInformation { get { return By.XPath("//div[@class='stepHeaderText' and contains(text(),'Location Information')]"); } }
        public By DivBack { get { return By.XPath("//div[@class='workflowHeader' and contains(.,'Back')]"); } }
        public By TxbPhone { get { return By.Id("Sales_Phone_1"); } }
        //Product selection Page
        public By TxbQuantity { get { return By.Id("MainContent_gvItems0_txtQuantity_0"); } }
        public By LnkUpdateQuantities { get { return By.Id("MainContent_lbUpdateQuantities"); } }


        public By BillingInfo1 { get { return By.XPath("(//*[@id='corporate-billing-address-field-1'])[1]"); } }
        public By BillingInfo2 { get { return By.XPath("(//*[@id='corporate-billing-address-field-1'])[2]"); } }
        public By CBAccountNumber { get { return By.XPath("(//*[@id='corporate-billing-address-field-1'])[3]"); } }
        public By BillingInstructions { get { return By.XPath("(//*[@id='corporate-billing-address-field-1'])[4]"); } }

    }
}
