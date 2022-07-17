using OpenQA.Selenium;
namespace CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects
{
    class OBJ_Common
    {
        //Emulating User
        public By LnkEmulateUser { get { return By.XPath("//div[@class='collapsedEmulationControl' and text()='Emulate User']"); } }
        public By BtnEmulateNow { get { return By.Id("emulationButton"); } }
        public By TxbEmulateUserSearch { get { return By.XPath("//div[@id='s2id_PageHeader1_EmulationController_emulationMultiFilter_multiselect']"); } }
        public By TxtName { get { return By.XPath("//div[@id='s2id_PageHeader1_EmulationController_emulationMultiFilter_multiselect']/ul/li[1]/div"); } }
        public By TxbSelectUserToEmulate { get { return By.XPath("//div[@id='multiselectfilter']/div/ul/li/input"); } }
        public By LnkExitEmulation { get { return By.XPath("//a[contains(@id,'lnkExitEmulation')]"); } }
        public By TxtSearchResults { get { return By.XPath("//li[@class='select2-no-results' and text()='Your search returned no results.']"); } }
        public By TblSearchResultsEmulateUsr { get { return By.XPath("//ul[@class='select2-results']"); } }

        //Add to item Cart //Item added to cart successfully.//
        public By TxtSearchMaterialTemplatesQunatity { get { return By.XPath("//input[contains(@class,'tenPercentWidth txtOrderQty')]"); } }
        public By TxtSearchMaterialTemplatesPriceQunatity { get { return By.XPath("//span[@id='lblTotalItemPrice']"); } }
        public By LnkSearchMaterialTemplatesQunatityUpdateTotal { get { return By.XPath("//a[@id='lnkUpdateTotal']"); } }
        public By BtnSearchMaterialAddToShoppingCart { get { return By.XPath("//input[@id='btnAddToShoppingCart']"); } }

        public By LblOrderLinesAddedTocart { get { return By.XPath("//td[@id='ShoppingCartOrderLines']"); } }
        public By ImgShoppingCartIcon { get { return By.XPath("//img[contains(@src,'images/icons/cartNonHover.png')]"); } }
        public By BtnViewShoppingCart { get { return By.Id("ViewShoppingCart"); } }

        public By LnkShoppingCartDeleteAll { get { return By.Id("MainContent_bmiCart_rptrOrderLines_lbRemoveAll"); } }
        public By BtnRemove { get { return By.XPath("//button[contains(.,'Remove')]"); } }
        public By BtnConfirm { get { return By.XPath("//button[contains(.,'Confirm')]"); } }
        public By LnkContinueShopping { get { return By.XPath("//a[contains(@class,'nav-link header-link')]"); } }
        public By ImgShoppingCartIconCastrol { get { return By.XPath("//img[@src='/Skinning/castrol/Locales/en/images/icons/cartNonHover.png']"); } }
       
        public By BtnAddToShoppingCartShipInfoSelectPayment { get { return By.Id("MainContent_btnSelectPayment1"); } }
        public By BtnAddToShoppingCartCheckout { get { return By.Id("MainContent_btnCheckoutCart"); } }
        public By TxbNameyourOrder { get { return By.Id("MainContent_txtOrderName"); } }
        public By ImgProcessing { get { return By.Id("imgProcessingImage"); } }
        public By RbtnShippingMethods { get { return By.XPath("//input[@type='radio']"); } }
        public By RbtnShippingMethods_newCheckout { get { return By.XPath("//input[@type='radio']"); } }
        public By V5CFMLogout { get { return By.XPath("//a[contains(@href,'/Login/Logout.aspx')]"); } }
        public By MoreDetailsLink { get { return By.XPath("//tbody//tr[1]//td[@class='cursor-pointer']//a"); } }
        public By CommentsLink { get { return By.XPath("//a[contains(text(),'Comments')]"); } }
        public By AuditTrailLink { get { return By.XPath("//a[contains(text(),'Audit')]"); } }
        public By ViewAssociatedClaimsLink { get { return By.XPath("//a[contains(text(),'associated claims')]"); } }
        public By CommentHistoryLabel { get { return By.XPath("//div[contains(text(),'Comment History')]"); } }
        public By AuditHistoryLabel { get { return By.XPath("//div[contains(text(),'Audit History')]"); } }
        public By CloseButton { get { return By.XPath("//i[contains(text(),'close')]"); } }
        public By FirstRowClaimIdLink { get { return By.XPath("//tbody//tr[1]//td[1]//a[@class='primary-link']"); } }
        public By FirstRowClaimIdStatus { get { return By.XPath("//tbody//tr[1]//td[6]"); } }
        public By ClaimDetailsPageStatus { get { return By.XPath("//div[contains(text(),'Status')]/following-sibling::div"); } }
        public By ViewButton { get { return By.XPath("//span[text()='View']/ancestor::button"); } }
        public By CorruptUser { get { return By.XPath("//ul[contains(@class,'results')]//li[4]//div[@class='userEmulationRow']"); } }
        public By HomeButton { get { return By.XPath("//a[contains(@class,'HomeMenu')]"); } }
        public By FileUploadInput { get { return (By.XPath("//input[@formcontrolname='FileControl']")); } }
        public By EmulateHeaderRow { get { return (By.XPath("//li[contains(@class,'select2-result-unselectable')]")); } }
        public By HintText { get { return (By.XPath("//ul[contains(@class,'select2-results')]")); } }

        //FARMERS
        public By AdminOption { get { return (By.XPath("//span[contains(text(),'Admin') and contains(@class,'rmExpandDown')]")); } }
        public By CrossButton { get { return (By.XPath("//button[contains(@class,'wm-visual-design-button')]/div")); } }
        public By EmulatingAgent { get { return (By.XPath("//a[contains(@class,'EmulateAgent')]")); } }
        public By RadioButton { get { return (By.XPath("//input[contains(@type,'radio') and contains(@id,'EmulationType_1')]")); } }
        public By EmulationTextBox { get { return (By.XPath("//input[contains(@name,'EmulationSearchText')]")); } }
        public By FindButton { get { return (By.XPath("//a[contains(@id,'Find')]")); } }
        public By UserOption { get { return (By.XPath("//option[contains(@selected,'selected')]/parent::select[contains(@class,'EmuListBox')]")); } }
        public By EmulateButton { get { return (By.XPath("//input[contains(@name,'btnEmulate')]")); } }
        public By AgentRadioBtn { get { return (By.XPath("//input[contains(@type,'radio') and contains(@id,'EmulationType_1')]")); } }
        public By EmulationSearchText { get { return (By.XPath("//input[contains(@name,'EmulationSearchText')]")); } }
        public By Farmers_EmulateUser { get { return (By.XPath("//div[contains(@class,'collapsedEmulationControl') and contains(text(),'Emulate Agent')]")); } }
    }
}
