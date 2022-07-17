using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.CampaignManager;
using CFMAutomation.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace CFM_PARALLEL.Common
{
    public class BrowserURLLaunch
    {
        private IWebDriver Driver { get; set; }
        public string CurrentWindow;
        public static string ROLES;
        public static string BUSINESSUNIT = "ACE";
        public static string PANDORABUSINESSUNIT = "Pandora";
        public static string EXECUTIONENVIRONMENT;
        public static string Username;
        public static string Password;
        public static string LaunchURL;

        public By ImgLoading { get { return By.Id("loading-image"); } }
        public By V5Username { get { return (By.XPath("//input[contains(@id,'UserName')]")); } }
        public By V5Username_Geico { get { return (By.XPath("//input[contains(@id,'username')]")); } }
        public By V5Password { get { return (By.XPath("//input[@id='Password']")); } }
        public By V5Password_Geico { get { return (By.XPath("//input[@id='password']")); } }
        public By V5LoginButton { get { return (By.XPath("//input[@id='LoginButton']")); } }
        public By V5LoginButton_Geico { get { return (By.XPath("//input[@name='login']")); } }
        public By V5InternalUserPassword { get { return (By.XPath("//input[contains(@id,'Password')]")); } }
        public By V5InternalUserLoginButton { get { return (By.XPath("//input[contains(@id,'btnLogin')]")); } }
        public By BusinessUnitSelectionDropdown { get { return (By.Id("MainContent_ddlBusinessUnit")); } }
        public By BusinessUnitSelectionDropdownOption(string bu) { return (By.XPath("//option[contains(.,'" + bu + "')]")); }
        public By V5CFMLink { get { return (By.XPath("//a[contains(@href,'CFM.aspx')]")); } }
        public By NewOfferingPopUpCloseButton { get { return (By.XPath("//button[contains(@class,'visual-design-button')]")); } }
        public By NewOfferingPopUpWindow { get { return (By.XPath("//div[contains(@id,'walkme-visual-design')]")); } }
        public By Bobcat_PopupWindow { get { return (By.XPath("//button[@class='wm-visual-design-button']")); } }
        public By Bobcat_TourWindow { get { return (By.XPath("//button[text()='VIEW LATER']")); } }
        public By V5CFMenuLink { get { return (By.XPath("//span[text()='MenuLink_Manage Co-op']")); } }
        public By V5CoopFMenuLink { get { return (By.XPath("//a[contains(@href,'CFM.aspx')]")); } }

        public By V5CFMLogout { get { return By.XPath("//a[contains(@href,'/Login/Logout.aspx')]"); } }
        public By LeftNavDashboard { get { return (By.XPath("//a[@id='dashboard']")); } }
        public By BtnSubmit { get { return By.XPath("//button[contains(@class,'dropdown-toggle') and contains(@aria-expanded,true)]"); } }
        public By ProdAdminLink { get { return (By.XPath("//a[contains(@class,'rmLink')]//span[contains(.,'Manage Co-op')]")); } }
        public By ProdCFMLink { get { return (By.XPath("//a[contains(@class,'rmLink')]//span[contains(.,'MenuLink_CFM')]")); } }
        public By ErrorTechnical { get { return (By.XPath("//h1[contains(.,'technical error occured')]")); } }
        public By ErrorTechnicalWidget { get { return (By.XPath("//div[contains(@class,'ui-toast-top-right')]//p-toastitem[contains(@class,'toastAnimation')]//div[@class='ui-toast-summary' and contains(text(),'unexpected')]")); } }
        public By Error500InternalServerError { get { return (By.XPath("//h2[contains(.,'500 - Internal server error.')]")); } }
        public By ErrorV5OpenID { get { return (By.XPath("//div[contains(.,'There is an error determining which application you are signing into. Return to the application and try again')]")); } }
        public By ErrorPageNotWoring { get { return (By.XPath("//h1[contains(.,'This page isn’t working')]")); } }

        //FARMERS
        public By VendorAccess { get { return (By.XPath("//a[contains(text(),'Vendor Access')]")); } }
        public By UserName { get { return (By.XPath("//input[contains(@id,'txtUsername')]")); } }
        public By PassWord { get { return (By.XPath("//input[contains(@id,'txtPassword')]")); } }
        public By Login { get { return (By.XPath("//a[contains(@id,'Login') and @class='dnnPrimaryAction']")); } }
        public By AdminOption { get { return (By.XPath("//span[contains(text(),'Admin') and contains(@class,'rmExpandDown')]")); } }
        public By CrossButton { get { return (By.XPath("//button[contains(@class,'wm-visual-design-button')]/div")); } }
        public By LnkEmulateUser { get { return By.XPath("//div[@class='collapsedEmulationControl' and text()='Emulate User']"); } }
        public By Farmers_EmulateUser { get { return (By.XPath("//div[contains(@class,'collapsedEmulationControl') and contains(text(),'Emulate Agent')]")); } }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="Driver"></param>
        public BrowserURLLaunch(IWebDriver Driver)
        {

        }

        #region
        /// <summary>
        /// 
        /// </summary>
        public void URLEnvironment_DataBrowserURLLaunchRead()
        {
            try
            {
                string connection_db = ConfigurationManager.ConnectionStrings["BrandMuscleAutomation"].ConnectionString;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ROLES"></param>
        public void LoginDetails_DatabaseRead(string ROLES)
        {
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(BrowserURLLaunch));
            try
            {
                string connection_db = ConfigurationManager.ConnectionStrings["BrandMuscleAutomation"].ConnectionString;
                SqlConnection connection_login_db = new SqlConnection(connection_db);
                string claim_query = "SELECT USERNAME,PASSWORD FROM CFMLOGINDETAILS with (nolock) WHERE PRODUCT='" + BUSINESSUNIT + "' AND ROLES='" + ROLES + "'" + "AND ENVIRONMENT='" + EXECUTIONENVIRONMENT + "'";
                connection_login_db.Open();
                SqlCommand claim_cmd = new SqlCommand(claim_query, connection_login_db);
                using (SqlDataReader read = claim_cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        Username = read["USERNAME"].ToString();
                        Password = read["PASSWORD"].ToString();
                    }
                }
                connection_login_db.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public void Validate_Error_Messages()
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            Pages.BasicInteractions().WaitTime(3);
            if (Pages.BasicInteractions().IsElementPresent(ErrorTechnical))
            {
                Console.WriteLine(ROLES + " ERROR: A technical error occured message is displayed, STOPPING TEST EXECUTION");
                //CommonFunctions.KillProcess();

                Assert.Fail(ROLES + " ERROR: A technical error occured message is displayed, STOPPING TEST EXECUTION");
            }
            else if (Pages.BasicInteractions().IsElementPresent(Error500InternalServerError))
            {
                Console.WriteLine(ROLES + " ERROR: Error 500: Internal Server Error occured, STOPPING TEST EXECUTION");
                //CommonFunctions.KillProcess();

                Assert.Fail(ROLES + " ERROR: Error 500: Internal Server Error occured, STOPPING TEST EXECUTION");
            }
            else if (Pages.BasicInteractions().IsElementPresent(ErrorPageNotWoring))
            {
                Console.WriteLine(ROLES + " ERROR: This page isn’t working, STOPPING TEST EXECUTION");
                Assert.Fail(ROLES + " ERROR: This page isn’t working, STOPPING TEST EXECUTION");
            }
            else if (Pages.BasicInteractions().IsElementPresent(ErrorV5OpenID))
            {
                Console.WriteLine(ROLES + " ERROR: V5 OpenID issue, STOPPING TEST EXECUTION");
                //CommonFunctions.KillProcess();

                Assert.Fail(ROLES + " ERROR: V5 OpenID issue, STOPPING TEST EXECUTION");
            }
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public void Validate_Error_Messages_In_Widget()
        {
            int count = 0;
            Boolean found = false;
            while (count++ < 10 && found == false)
            { // Waiting for widget to appear in 10 seconds with a time interval of 1 seconds
                Pages.BasicInteractions().WaitTime(1);
                found = Pages.BasicInteractions().IsElementPresent(ErrorTechnicalWidget);
            }

            if (found)
            {
                String ErrorMessage = Pages.BasicInteractions().GetText(ErrorTechnicalWidget);
                Console.WriteLine(ROLES + " ERROR displayed with message in Validate_Error_Messages_In_Widget method: " + ErrorMessage);
                Assert.Fail("ERROR displayed with message in Validate_Error_Messages_In_Widget method");
            }
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void BrowserURL_ACE(string user, String Env = "QA")
        {
            try
            {
                ROLES = user;
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.URLEnvironment_DataBrowserURLLaunchRead();
                EXECUTIONENVIRONMENT = Env;
                BasicInteractions bi = new BasicInteractions(Driver);
                if (EXECUTIONENVIRONMENT.ToUpper() == "PROD".ToUpper())

                    Pages.BasicInteractions().Gotourl(Parameters.Admin_Prod_url);

                else if (EXECUTIONENVIRONMENT.ToUpper() == "STAGE".ToUpper())

                    Pages.BasicInteractions().Gotourl(Parameters.Admin_Stage_url);

                else if (EXECUTIONENVIRONMENT.ToUpper() == "DEV".ToUpper())

                    Pages.BasicInteractions().Gotourl(Parameters.Ace_Dev_url);

                else
                {
                    Pages.BasicInteractions().Gotourl(Parameters.Ace_QA_url);
                }
                Pages.BasicInteractions().WaitVisible(V5Username);
                if (user.Equals("CORPORATE1"))
                {
                    Pages.BasicInteractions().WaitVisible(V5Username);
                    Pages.BasicInteractions().Type(V5Username, "UAT_ADMIN");

                    Pages.BasicInteractions().WaitVisible(V5Password);
                    Pages.BasicInteractions().Type(V5Password, "H@RDWAR3");
                    Pages.BasicInteractions().WaitVisible(V5LoginButton);
                    Pages.BasicInteractions().Click(V5LoginButton);

                }
                else if (user.Equals("LME1"))
                {

                    Pages.BasicInteractions().WaitVisible(V5Username);
                    Pages.BasicInteractions().Type(V5Username, "UAT_RetailEmployee");
                    Pages.BasicInteractions().WaitVisible(V5Password);
                    Pages.BasicInteractions().Type(V5Password, "H@RDWAR3");

                    Pages.BasicInteractions().WaitVisible(V5LoginButton);
                    Pages.BasicInteractions().Click(V5LoginButton);
                }
                else if (user.Equals("InternalUser"))
                {
                    Pages.BasicInteractions().WaitVisible(V5Username);
                    Pages.BasicInteractions().Type(V5Username, "priti.Kumari@brandmuscle.com");
                    Pages.BasicInteractions().WaitVisible(V5InternalUserPassword);
                    Pages.BasicInteractions().Type(V5InternalUserPassword, "Ownlocal512");
                    Pages.BasicInteractions().WaitVisible(V5InternalUserLoginButton);
                    Pages.BasicInteractions().Click(V5InternalUserLoginButton);
                }

                Pages.BasicInteractions().WaitForPageToLoad(240);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error with an exception in BrowserURL_ACE method: " + ex.Message);
                throw;
            }
        }
        #endregion

        public void SelectBusinessUnitFromDropDown(String businessUnit)
        {
            BasicInteractions bi = new BasicInteractions(Driver);

            if (Pages.BasicInteractions().IsElementPresent(BusinessUnitSelectionDropdown))
            {
                Pages.BasicInteractions().WaitVisible(BusinessUnitSelectionDropdown);
                Pages.BasicInteractions().Click(BusinessUnitSelectionDropdown);
                Pages.BasicInteractions().Click(BusinessUnitSelectionDropdownOption(businessUnit));
                //Pages.BasicInteractions().WaitTime(20);
                Pages.BasicInteractions().WaitUntilElementVisible(V5CFMLink, 240);

            }
            else
            {
                if (Pages.BasicInteractions().IsElementDisplayed(NewOfferingPopUpCloseButton))
                {
                    Pages.BasicInteractions().ClickJavaScript(NewOfferingPopUpCloseButton);
                }
                Pages.BasicInteractions().WaitVisible(V5CFMLink);
                Pages.BasicInteractions().Click(V5CFMLink);
                Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitVisible(LeftNavDashboard);
            }
        }

        public void Click_CFMLink()
        {
            try
            {
                Close_PopUp();
                Pages.BasicInteractions().WaitVisible(V5CFMLink);
                Pages.BasicInteractions().Click(V5CFMLink);
                Validate_Error_Messages_In_Widget();
                Pages.BasicInteractions().WaitVisible(BtnSubmit);
                Pages.BasicInteractions().WaitVisible(LeftNavDashboard);
                Validate_Error_Messages_In_Widget();

                if (Pages.BasicInteractions().IsElementDisplayed(Bobcat_TourWindow))
                {
                    Pages.BasicInteractions().Click(Bobcat_TourWindow);
                    Pages.BasicInteractions().WaitVisible(LeftNavDashboard);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(" ERROR in Click_CFMLink method: " + ex.ToString());
                throw;

            }
        }

        public void Close_PopUp()
        {
            try
            {
                Pages.BasicInteractions().WaitTime(10);
                if (Pages.BasicInteractions().IsElementDisplayed(NewOfferingPopUpWindow) || Pages.BasicInteractions().IsElementDisplayed(Bobcat_PopupWindow))
                {
                    Pages.BasicInteractions().Refresh();
                    Pages.BasicInteractions().WaitForPageToLoad(120);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(" ERROR in Close_PopUp method: " + ex.ToString());
                throw;

            }
        }

        #region
        /// <summary>
        /// To launch pandora application
        /// </summary>
        /// <param name="name"></param>
        public void BrowserURLCLIENT(string user, String Client, String Env = "QA")
        {
            try
            {
                ROLES = user;
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.URLEnvironment_DataBrowserURLLaunchRead();
                EXECUTIONENVIRONMENT = Env;
                BasicInteractions bi = new BasicInteractions(Driver);
                Pages.BasicInteractions().WaitTime(5);

                if (Client.ToUpper().Trim().Equals("PANDORA"))
                {
                    if (Env.ToUpper() == "PROD".ToUpper())
                    {
                        Pages.BasicInteractions().Gotourl(Parameters.Pandora_Prod_url);
                        switch (user.ToUpper().Trim())
                        {
                            case "CORPORATE1":
                                Pages.BasicInteractions().WaitVisible(V5Username);
                                Pages.BasicInteractions().Type(V5Username, "adoneau@pandora.net");
                                Pages.BasicInteractions().WaitVisible(V5Password);
                                Pages.BasicInteractions().Type(V5Password, "welcome");
                                Pages.BasicInteractions().WaitVisible(V5LoginButton);
                                Pages.BasicInteractions().Click(V5LoginButton);
                                Pages.BasicInteractions().WaitForPageToLoad(240);
                                break;

                            case "LME1":
                                Pages.BasicInteractions().WaitVisible(V5Username);
                                Pages.BasicInteractions().Type(V5Username, "adoneau@pandora.net");
                                Pages.BasicInteractions().WaitVisible(V5Password);
                                Pages.BasicInteractions().Type(V5Password, "welcome");

                                Pages.BasicInteractions().WaitVisible(V5LoginButton);
                                Pages.BasicInteractions().Click(V5LoginButton);
                                Pages.BasicInteractions().WaitForPageToLoad(120);

                                break;

                        }
                    }
                    else
                    {
                        Pages.BasicInteractions().Gotourl(Parameters.Pandora_QA_url);
                        switch (user.ToUpper().Trim())
                        {
                            case "CORPORATE1":
                                Pages.BasicInteractions().WaitVisible(V5Username);
                                Pages.BasicInteractions().Type(V5Username, "UAT_ADMIN");
                                Pages.BasicInteractions().WaitVisible(V5Password);
                                Pages.BasicInteractions().Type(V5Password, "P@ND0RA");
                                Pages.BasicInteractions().WaitVisible(V5LoginButton);
                                Pages.BasicInteractions().Click(V5LoginButton);
                                Pages.BasicInteractions().WaitForPageToLoad(120);

                                break;

                            case "LME1":
                                Pages.BasicInteractions().WaitVisible(V5Username);
                                Pages.BasicInteractions().Type(V5Username, "adoneau@pandora.net");
                                Pages.BasicInteractions().WaitVisible(V5Password);
                                Pages.BasicInteractions().Type(V5Password, "welcome");

                                Pages.BasicInteractions().WaitVisible(V5LoginButton);
                                Pages.BasicInteractions().Click(V5LoginButton);
                                Pages.BasicInteractions().WaitForPageToLoad(120);

                                break;

                        }
                    }

                }
                else if (Client.ToUpper().Trim().Equals("DITCH WITCH"))
                {
                    if (Env.ToUpper() == "PROD".ToUpper())
                    {
                        Pages.BasicInteractions().Gotourl(Parameters.Ditchwitch_Prod_url);
                        Pages.BasicInteractions().WaitVisible(V5Username);
                        Pages.BasicInteractions().Type(V5Username, "qaatestemulate1");
                        Pages.BasicInteractions().WaitVisible(V5Password);
                        Pages.BasicInteractions().Type(V5Password, "welcome");
                        Pages.BasicInteractions().WaitVisible(V5LoginButton);
                        Pages.BasicInteractions().Click(V5LoginButton);
                        Pages.BasicInteractions().WaitForPageToLoad(120);
                        Pages.BasicInteractions().WaitTime(10);
                    }
                    else
                    {
                        Pages.BasicInteractions().Gotourl(Parameters.Ditchwitch_QA_url);
                        Pages.BasicInteractions().WaitVisible(V5Username);
                        Pages.BasicInteractions().Type(V5Username, "qaatestemulate1");
                        Pages.BasicInteractions().WaitVisible(V5Password);
                        Pages.BasicInteractions().Type(V5Password, "welcome");
                        Pages.BasicInteractions().WaitVisible(V5LoginButton);
                        Pages.BasicInteractions().Click(V5LoginButton);
                        Pages.BasicInteractions().WaitForPageToLoad(120);
                        Pages.BasicInteractions().WaitTime(10);
                    }

                }
                else if (Client.ToUpper().Trim().Equals("BOBCAT"))
                {
                    if (Env.ToUpper() == "PROD".ToUpper())
                    {
                        Pages.BasicInteractions().Gotourl(Parameters.Bobcat_Prod_url);
                        switch (user.ToUpper().Trim())
                        {
                            case "CORPORATE1":
                                Pages.BasicInteractions().WaitVisible(V5Username);
                                Pages.BasicInteractions().Type(V5Username, "BobcatCorporateAdmin");
                                Pages.BasicInteractions().WaitVisible(V5Password);
                                Pages.BasicInteractions().Type(V5Password, "welcome");
                                Pages.BasicInteractions().WaitVisible(V5LoginButton);
                                Pages.BasicInteractions().Click(V5LoginButton);
                                Pages.BasicInteractions().WaitForPageToLoad(120);

                                break;

                            case "LME1":
                                Pages.BasicInteractions().WaitVisible(V5Username);
                                Pages.BasicInteractions().Type(V5Username, "BobcatCoopContact");
                                Pages.BasicInteractions().WaitVisible(V5Password);
                                Pages.BasicInteractions().Type(V5Password, "welcome");
                                Pages.BasicInteractions().WaitVisible(V5LoginButton);
                                Pages.BasicInteractions().Click(V5LoginButton);
                                Pages.BasicInteractions().WaitForPageToLoad(120);

                                break;
                        }
                    }
                    else if (Env.ToUpper() == "STAGE".ToUpper())
                    {
                        Pages.BasicInteractions().Gotourl(Parameters.Bobcat_Stage_url);
                        switch (user.ToUpper().Trim())
                        {
                            case "CORPORATE1":
                                Pages.BasicInteractions().WaitVisible(V5Username);
                                Pages.BasicInteractions().Type(V5Username, "Uat_CorporateAdmin");
                                Pages.BasicInteractions().WaitVisible(V5Password);
                                Pages.BasicInteractions().Type(V5Password, "welcome");
                                Pages.BasicInteractions().WaitVisible(V5LoginButton);
                                Pages.BasicInteractions().Click(V5LoginButton);
                                Pages.BasicInteractions().WaitForPageToLoad(120);

                                break;

                            case "LME1":
                                Pages.BasicInteractions().WaitVisible(V5Username);
                                Pages.BasicInteractions().Type(V5Username, "Uat_CoopContact");
                                Pages.BasicInteractions().WaitVisible(V5Password);
                                Pages.BasicInteractions().Type(V5Password, "welcome");
                                Pages.BasicInteractions().WaitVisible(V5LoginButton);
                                Pages.BasicInteractions().Click(V5LoginButton);
                                Pages.BasicInteractions().WaitForPageToLoad(120);

                                break;
                        }
                    }
                    else
                    {
                        Pages.BasicInteractions().Gotourl(Parameters.Bobcat_QA_url);
                        switch (user.ToUpper().Trim())
                        {
                            case "CORPORATE1":
                                Pages.BasicInteractions().WaitVisible(V5Username);
                                Pages.BasicInteractions().Type(V5Username, "Uat_CorporateAdmin");
                                Pages.BasicInteractions().WaitVisible(V5Password);
                                Pages.BasicInteractions().Type(V5Password, "welcome");
                                Pages.BasicInteractions().WaitVisible(V5LoginButton);
                                Pages.BasicInteractions().Click(V5LoginButton);
                                Pages.BasicInteractions().WaitForPageToLoad(120);

                                break;

                            case "LME1":
                                Pages.BasicInteractions().WaitVisible(V5Username);
                                Pages.BasicInteractions().Type(V5Username, "Uat_CoopContact");
                                Pages.BasicInteractions().WaitVisible(V5Password);
                                Pages.BasicInteractions().Type(V5Password, "welcome");
                                Pages.BasicInteractions().WaitVisible(V5LoginButton);
                                Pages.BasicInteractions().Click(V5LoginButton);
                                Pages.BasicInteractions().WaitForPageToLoad(120);

                                break;
                        }
                    }
                }

                Close_PopUp();
                Pages.BasicInteractions().WaitVisible(V5CFMLink);

                if (Pages.BasicInteractions().IsElementPresent(V5CFMLink))
                {
                    Pages.BasicInteractions().Click(V5CFMLink);
                    Pages.BasicInteractions().WaitTillNotVisible(ImgLoading, 240);
                    Validate_Error_Messages_In_Widget();
                    Pages.BasicInteractions().WaitVisible(BtnSubmit);

                }
                else
                {
                    Console.WriteLine("CFM Link is not Available");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }
        #endregion

        #region
        public void BrowserURL_NATIONWIDE(string user, String Env = "QA")
        {
            try
            {
                ROLES = user;
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.URLEnvironment_DataBrowserURLLaunchRead();
                EXECUTIONENVIRONMENT = Env;
               
                BasicInteractions bi = new BasicInteractions(Driver);
                Pages.BasicInteractions().WaitTime(5);

                if (Env.ToUpper() == "PROD".ToUpper())
                {
                    Pages.BasicInteractions().Gotourl(Parameters.Nationwide_Prod_url);
                    switch (user.ToUpper().Trim())
                    {
                        case "LME1":
                            Pages.BasicInteractions().WaitVisible(V5Username);
                            Pages.BasicInteractions().Type(V5Username, "priti.Kumari@brandmuscle.com");
                            Pages.BasicInteractions().WaitVisible(V5Password);
                            Pages.BasicInteractions().Type(V5Password, "Ownlocal512");
                            Pages.BasicInteractions().WaitVisible(V5LoginButton);
                            Pages.BasicInteractions().Click(V5LoginButton);
                            Pages.BasicInteractions().WaitForPageToLoad(240);
                            break;
                    }
                }

                else if (Env.ToUpper() == "STAGE".ToUpper())
                {
                    Pages.BasicInteractions().Gotourl(Parameters.Nationwide_Stage_url);
                    switch (user.ToUpper().Trim())
                    {
                        case "LME1":
                            Pages.BasicInteractions().WaitVisible(V5Username);
                            Pages.BasicInteractions().Type(V5Username, "priti.kumari@brandmuscle.com");
                            Pages.BasicInteractions().WaitVisible(V5Password);
                            Pages.BasicInteractions().Type(V5Password, "Ownlocal512");
                            Pages.BasicInteractions().WaitVisible(V5LoginButton);
                            Pages.BasicInteractions().Click(V5LoginButton);
                            Pages.BasicInteractions().WaitForPageToLoad(240);
                            break;
                    }
                }

                else
                {
                    Pages.BasicInteractions().Gotourl(Parameters.Nationwide_QA_url);
                    switch (user.ToUpper().Trim())
                    {
                        case "CORPORATE1":
                            Pages.BasicInteractions().WaitVisible(V5Username);
                            Pages.BasicInteractions().Type(V5Username, "NW_Admin");
                            Pages.BasicInteractions().WaitVisible(V5Password);
                            Pages.BasicInteractions().Type(V5Password, "welcome");
                            break;

                        case "LME1":
                            Pages.BasicInteractions().WaitVisible(V5Username);
                            Pages.BasicInteractions().Type(V5Username, "NW_User1");
                            Pages.BasicInteractions().WaitVisible(V5Password);
                            Pages.BasicInteractions().Type(V5Password, "welcome");
                            break;

                        case "LME2":
                            Pages.BasicInteractions().WaitVisible(V5Username);
                            Pages.BasicInteractions().Type(V5Username, "NW_User2");
                            Pages.BasicInteractions().WaitVisible(V5Password);
                            Pages.BasicInteractions().Type(V5Password, "welcome");
                            break;

                        case "REVIEWER1":
                            Pages.BasicInteractions().WaitVisible(V5Username);
                            Pages.BasicInteractions().Type(V5Username, "NW_User2");
                            Pages.BasicInteractions().WaitVisible(V5Password);
                            Pages.BasicInteractions().Type(V5Password, "welcome");
                            break;

                        case "REVIEWER2":
                            Pages.BasicInteractions().WaitVisible(V5Username);
                            Pages.BasicInteractions().Type(V5Username, "NW_User2");
                            Pages.BasicInteractions().WaitVisible(V5Password);
                            Pages.BasicInteractions().Type(V5Password, "welcome");
                            break;

                    }

                    Pages.BasicInteractions().WaitVisible(V5LoginButton);
                    try
                    {
                        Pages.BasicInteractions().Click(V5LoginButton);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("Error: " + ex.Message);
                    }
                    finally
                    {
                        Pages.BasicInteractions().WaitForPageToLoad(100);
                        Pages.BasicInteractions().Refresh();
                    }

                    Pages.BasicInteractions().WaitForPageToLoad(100);
                    Pages.BasicInteractions().WaitTime(20);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }
        #endregion

        #region
        public void BrowserURL_BOBCAT(string user, String Client, String Env = "QA")
        {
            try
            {
                ROLES = user;
               
                EXECUTIONENVIRONMENT = Env;
                if (Env.ToUpper() == "PROD".ToUpper())
                {
                    Pages.BasicInteractions().Gotourl(Parameters.Bobcat_Prod_url);
                    switch (user.ToUpper().Trim())
                    {
                        case "CORPORATE1":
                            Pages.BasicInteractions().WaitVisible(V5Username);
                            Pages.BasicInteractions().Type(V5Username, "BobcatCorporateAdmin");
                            Pages.BasicInteractions().WaitVisible(V5Password);
                            Pages.BasicInteractions().Type(V5Password, "welcome");
                            Pages.BasicInteractions().WaitVisible(V5LoginButton);
                            Pages.BasicInteractions().Click(V5LoginButton);
                            break;

                        case "LME1":
                            Pages.BasicInteractions().WaitVisible(V5Username);
                            Pages.BasicInteractions().Type(V5Username, "BobcatCoopContact");
                            Pages.BasicInteractions().WaitVisible(V5Password);
                            Pages.BasicInteractions().Type(V5Password, "welcome");
                            Pages.BasicInteractions().WaitVisible(V5LoginButton);
                            Pages.BasicInteractions().Click(V5LoginButton);
                            break;
                    }
                } // end of if
                else if (Env.ToUpper() == "STAGE".ToUpper())
                {
                    Pages.BasicInteractions().Gotourl(Parameters.Bobcat_Stage_url);
                    switch (user.ToUpper().Trim())
                    {
                        case "CORPORATE1":
                            Pages.BasicInteractions().WaitVisible(V5Username);
                            Pages.BasicInteractions().Type(V5Username, "BobcatCorporate");
                            Pages.BasicInteractions().WaitVisible(V5Password);
                            Pages.BasicInteractions().Type(V5Password, "welcome");
                            Pages.BasicInteractions().WaitVisible(V5LoginButton);
                            Pages.BasicInteractions().Click(V5LoginButton);
                            break;

                        case "LME1":
                            Pages.BasicInteractions().WaitVisible(V5Username);
                            Pages.BasicInteractions().Type(V5Username, "BobcatCoopcontact");
                            Pages.BasicInteractions().WaitVisible(V5Password);
                            Pages.BasicInteractions().Type(V5Password, "welcome");
                            Pages.BasicInteractions().WaitVisible(V5LoginButton);
                            Pages.BasicInteractions().Click(V5LoginButton);
                            break;
                    }
                } // end of else if
                else
                {
                    Pages.BasicInteractions().Gotourl(Parameters.Bobcat_QA_url);
                    switch (user.ToUpper().Trim())
                    {
                        case "CORPORATE1":
                            Pages.BasicInteractions().WaitVisible(V5Username);
                            Pages.BasicInteractions().Type(V5Username, "Uat_CorporateAdmin");
                            Pages.BasicInteractions().WaitVisible(V5Password);
                            Pages.BasicInteractions().Type(V5Password, "welcome");
                            Pages.BasicInteractions().WaitVisible(V5LoginButton);
                            Pages.BasicInteractions().Click(V5LoginButton);
                            break;

                        case "LME1":
                            Pages.BasicInteractions().WaitVisible(V5Username);
                            Pages.BasicInteractions().Type(V5Username, "Uat_CoopContact");
                            Pages.BasicInteractions().WaitVisible(V5Password);
                            Pages.BasicInteractions().Type(V5Password, "welcome");
                            Pages.BasicInteractions().WaitVisible(V5LoginButton);
                            Pages.BasicInteractions().Click(V5LoginButton);
                            break;
                    }
                } // end of else
                Pages.BasicInteractions().WaitForPageToLoad(240);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }
        #endregion

        public void BrowserURL_MASCO(String Env)
        {
            try
            {
            
                EXECUTIONENVIRONMENT = Env;
         

                if (Env.ToUpper() == "PROD".ToUpper())
                    Pages.BasicInteractions().Gotourl(Parameters.Masco_Prod_url);
                else
                    Pages.BasicInteractions().Gotourl(Parameters.Masco_Stage_url);

                Pages.BasicInteractions().WaitVisible(V5Username);
                Pages.BasicInteractions().Type(V5Username, "priti.Kumari@brandmuscle.com");
                Pages.BasicInteractions().WaitVisible(V5InternalUserPassword);
                Pages.BasicInteractions().Type(V5InternalUserPassword, "Ownlocal512");
                Pages.BasicInteractions().WaitVisible(V5InternalUserLoginButton);
                Pages.BasicInteractions().Click(V5InternalUserLoginButton);
                Pages.BasicInteractions().WaitForPageToLoad(240);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }

        public void BrowserURL_Farmers(String Env)
        {
            try
            {
             
                EXECUTIONENVIRONMENT = Env;
               

                if (Env.ToUpper() == "PROD".ToUpper())
                {
                    Pages.BasicInteractions().Gotourl(Parameters.Farmers_Prod_url);

                    Pages.BasicInteractions().WaitVisible(VendorAccess);
                    Pages.BasicInteractions().Click(VendorAccess);
                    Pages.BasicInteractions().WaitVisible(UserName);
                    Pages.BasicInteractions().Type(UserName, "FI:uswlaf17");
                    Pages.BasicInteractions().WaitVisible(PassWord);
                    Pages.BasicInteractions().Type(PassWord, "1szhWs4xLD6ENKiAi2ftIA==");
                    Pages.BasicInteractions().WaitVisible(Login);
                    Pages.BasicInteractions().Click(Login);
                    Pages.BasicInteractions().WaitForPageToLoad(240);
                    Pages.BasicInteractions().WaitTime(8);
                    if (Pages.BasicInteractions().IsElementDisplayed(CrossButton))
                    {
                        Pages.BasicInteractions().Click(CrossButton);
                    }
                    Pages.BasicInteractions().WaitVisible(AdminOption);
                }
                else
                {
                    Pages.BasicInteractions().Gotourl(Parameters.Farmers_Stage_url);
                    Pages.BasicInteractions().WaitVisible(V5Username);
                    Pages.BasicInteractions().Type(V5Username, "priti.Kumari@brandmuscle.com");
                    Pages.BasicInteractions().WaitVisible(V5InternalUserPassword);
                    Pages.BasicInteractions().Type(V5InternalUserPassword, "Ownlocal512");
                    Pages.BasicInteractions().WaitVisible(V5InternalUserLoginButton);
                    Pages.BasicInteractions().Click(V5InternalUserLoginButton);
                    Pages.BasicInteractions().WaitForPageToLoad(240);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }
        public void BrowserURL_CampManager(String Env)
        {
            Homepage products = new Homepage();
            try
            {
                EXECUTIONENVIRONMENT = Env;
                if (Env.ToUpper() == "STAGE".ToUpper())
                {
                    Pages.BasicInteractions().Gotourl(Parameters.CampaignManager_Stage_URL);
                    Pages.BasicInteractions().WaitVisible(products.Username);
                    Pages.BasicInteractions().Type(products.Username, "satikant.pradhan@brandmuscle.com");
                    Pages.BasicInteractions().WaitVisible(products.PWD);
                    Pages.BasicInteractions().Type(products.PWD, "Ownlocal512");
                    Pages.BasicInteractions().WaitVisible(products.LoginBtn);
                    Pages.BasicInteractions().Click(products.LoginBtn);
                    Pages.BasicInteractions().WaitForPageToLoad(240);
                }
                /*
                else
                {
                    Pages.BasicInteractions().Gotourl(Parameters.Farmers_Prod_url);
                    Pages.BasicInteractions().WaitVisible(VendorAccess);
                    Pages.BasicInteractions().Click(VendorAccess);
                    Pages.BasicInteractions().WaitVisible(UserName);
                    Pages.BasicInteractions().Type(UserName, "FI:uswlaf17");
                    Pages.BasicInteractions().WaitVisible(PassWord);
                    Pages.BasicInteractions().Type(PassWord, "1szhWs4xLD6ENKiAi2ftIA==");
                    Pages.BasicInteractions().WaitVisible(Login);
                    Pages.BasicInteractions().Click(Login);
                    Pages.BasicInteractions().WaitForPageToLoad(240);
                    Pages.BasicInteractions().WaitTime(8);
                    if (Pages.BasicInteractions().IsElementDisplayed(CrossButton))
                    {
                        Pages.BasicInteractions().Click(CrossButton);
                    }
                    Pages.BasicInteractions().WaitVisible(AdminOption);

                } */
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }
        public void CampMgrBUselection(String businessUnit)
        {
            Pages.BasicInteractions().IsElementPresent(BusinessUnitSelectionDropdown);
            Pages.BasicInteractions().WaitVisible(BusinessUnitSelectionDropdown);
            Pages.BasicInteractions().Click(BusinessUnitSelectionDropdown);
            Pages.BasicInteractions().Click(BusinessUnitSelectionDropdownOption(businessUnit));
            Pages.BasicInteractions().WaitTime(5);

        }
        public void BusinessUnitFromDropDown(String businessUnit)
        {
            Pages.BasicInteractions().IsElementPresent(BusinessUnitSelectionDropdown);
            Pages.BasicInteractions().WaitVisible(BusinessUnitSelectionDropdown);
            Pages.BasicInteractions().Click(BusinessUnitSelectionDropdown);
            Pages.BasicInteractions().Click(BusinessUnitSelectionDropdownOption(businessUnit));
            Pages.BasicInteractions().WaitUntilElementVisible(Farmers_EmulateUser,240);
            Pages.BasicInteractions().WaitTime(5);

        }


        public void BrowserURL_AMNAT(String Env = "STAGE")
        {
            try
            {
                
                EXECUTIONENVIRONMENT = Env;
                BasicInteractions bi = new BasicInteractions(Driver);
                if (EXECUTIONENVIRONMENT.ToUpper() == "PROD".ToUpper())

                    Pages.BasicInteractions().Gotourl(Parameters.Amnat_Prod_url);
                else
                    Pages.BasicInteractions().Gotourl(Parameters.Amnat_QA_url);

                Pages.BasicInteractions().WaitVisible(V5Username);
                Pages.BasicInteractions().Type(V5Username, "priti.Kumari@brandmuscle.com");
                Pages.BasicInteractions().WaitVisible(V5InternalUserPassword);
                Pages.BasicInteractions().Type(V5InternalUserPassword, "Ownlocal512");
                Pages.BasicInteractions().WaitVisible(V5InternalUserLoginButton);
                Pages.BasicInteractions().Click(V5InternalUserLoginButton);
                Pages.BasicInteractions().WaitForPageToLoad(240);
                Pages.BasicInteractions().WaitVisible(BusinessUnitSelectionDropdown);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }

        public void BrowserURL_Prod_QA_BU(string user)
        {
            try
            {
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.URLEnvironment_DataBrowserURLLaunchRead();
                BasicInteractions bi = new BasicInteractions(Driver);
                Pages.BasicInteractions().Gotourl(Parameters.Prod_QA_BU_Url);
                Pages.BasicInteractions().WaitTime(10);

                switch (user.ToUpper().Trim())
                {
                    case "CORPORATE1":
                        Pages.BasicInteractions().WaitVisible(V5Username);
                        Pages.BasicInteractions().Type(V5Username, "corporate.user@brandmuscle.com");
                        Pages.BasicInteractions().WaitVisible(V5InternalUserPassword);
                        Pages.BasicInteractions().Type(V5InternalUserPassword, "welcome");
                        Pages.BasicInteractions().WaitVisible(V5InternalUserLoginButton);
                        Pages.BasicInteractions().Click(V5InternalUserLoginButton);
                        // Pages.BasicInteractions().WaitForPageToLoad(60);
                        // Pages.BasicInteractions().Gotourl(Parameters.Prod_QA_BU_Url);
                        Pages.BasicInteractions().WaitForPageToLoad(240);
                        Pages.BasicInteractions().WaitUntilElementVisible(V5CFMLink, 240);
                        break;

                    case "CHILD":
                        Pages.BasicInteractions().WaitVisible(V5Username);
                        Pages.BasicInteractions().Type(V5Username, "CHILD1.user@brandmuscle.com");
                        Pages.BasicInteractions().WaitVisible(V5InternalUserPassword);
                        Pages.BasicInteractions().Type(V5InternalUserPassword, "welcome");
                        Pages.BasicInteractions().WaitVisible(V5InternalUserLoginButton);
                        Pages.BasicInteractions().Click(V5InternalUserLoginButton);
                        // Pages.BasicInteractions().WaitForPageToLoad(60);
                        //Pages.BasicInteractions().Gotourl(Parameters.Prod_QA_BU_Url);
                        Pages.BasicInteractions().WaitForPageToLoad(240);
                        Pages.BasicInteractions().WaitUntilElementVisible(V5CFMLink, 240);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }

        public void BrowserURL_Geico(string user)
        {
            try
            {
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.URLEnvironment_DataBrowserURLLaunchRead();
                BasicInteractions bi = new BasicInteractions(Driver);
                Pages.BasicInteractions().Gotourl(Parameters.Geico_Stage_url);
                switch (user.ToUpper().Trim())
                {
                    case "GFR":
                        Pages.BasicInteractions().WaitVisible(V5Username_Geico);
                        Pages.BasicInteractions().Type(V5Username_Geico, "U95746");
                        Pages.BasicInteractions().WaitVisible(V5Password_Geico);
                        Pages.BasicInteractions().Type(V5Password_Geico, "welcome");
                        Pages.BasicInteractions().WaitVisible(V5LoginButton_Geico);
                        Pages.BasicInteractions().Click(V5LoginButton_Geico);
                        Pages.BasicInteractions().WaitForPageToLoad(240);
                        break;

                    case "LEAD":
                        Pages.BasicInteractions().WaitVisible(V5Username_Geico);
                        Pages.BasicInteractions().Type(V5Username_Geico, "U51PER");
                        Pages.BasicInteractions().WaitVisible(V5Password_Geico);
                        Pages.BasicInteractions().Type(V5Password_Geico, "welcome");
                        Pages.BasicInteractions().WaitVisible(V5LoginButton_Geico);
                        Pages.BasicInteractions().Click(V5LoginButton_Geico);
                        Pages.BasicInteractions().WaitForPageToLoad(240);
                        break;

                    case "SUPERVISOR":
                        Pages.BasicInteractions().WaitVisible(V5Username_Geico);
                        Pages.BasicInteractions().Type(V5Username_Geico, "U51PCA");
                        Pages.BasicInteractions().WaitVisible(V5Password_Geico);
                        Pages.BasicInteractions().Type(V5Password_Geico, "welcome");
                        Pages.BasicInteractions().WaitVisible(V5LoginButton_Geico);
                        Pages.BasicInteractions().Click(V5LoginButton_Geico);
                        Pages.BasicInteractions().WaitForPageToLoad(240);
                        break;

                    case "MANAGEMENT":
                        Pages.BasicInteractions().WaitVisible(V5Username_Geico);
                        Pages.BasicInteractions().Type(V5Username_Geico, "U51PKJ");
                        Pages.BasicInteractions().WaitVisible(V5Password_Geico);
                        Pages.BasicInteractions().Type(V5Password_Geico, "welcome");
                        Pages.BasicInteractions().WaitVisible(V5LoginButton_Geico);
                        Pages.BasicInteractions().Click(V5LoginButton_Geico);
                        Pages.BasicInteractions().WaitForPageToLoad(240);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;

            }
        }
    }
}
