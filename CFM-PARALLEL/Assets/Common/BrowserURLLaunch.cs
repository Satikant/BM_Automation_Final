using CFM_PARALLEL.Interactions_New;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;

namespace CFM_PARALLEL.Common
{
    public class BrowserURLLaunch
    {
        private IWebDriver Driver { get; set; }
        public string CurrentWindow;
        public static string ROLES;
        public static string BUSINESSUNIT="ACE";
        public static string PANDORABUSINESSUNIT = "Pandora";
        public static string EXECUTIONENVIRONMENT;
        public static string Username;
        public static string Password;
        public static string LaunchURL;


        //private BasicInteractions Bi;

        public By imgLoading { get { return By.Id("loading-image"); } }
        //public  By V5Username { get { return (By.Id("MainContent_LoginCentiv_UserName")); } }
        public By V5Username { get { return (By.Id("UserName")); } }
        //public  By V5Password { get { return (By.Id("MainContent_LoginCentiv_Password")); } }
        public By V5Password { get { return (By.Id("Password")); } }
        //public  By V5LoginButton { get { return (By.Id("MainContent_LoginCentiv_btnLogin")); } }
        public By V5LoginButton { get { return (By.Id("LoginButton")); } }
        public By BusinessUnitSelectionDropdown { get { return (By.Id("MainContent_ddlBusinessUnit")); } }
        public By BusinessUnitSelectionDropdownOption(string bu) { return (By.XPath("//option[contains(.,'" + bu + "')]")); }
        // public By V5CFMLink { get { return (By.PartialLinkText("Manage Co")); } }
        //public By V5CFMLink { get { return (By.XPath("//span[text()='Manage Co-op']")); } }
        public By V5CFMLink { get { return (By.XPath("//a[contains(@href,'CFM.aspx')]")); } }
        public By V5CFMenuLink { get { return (By.XPath("//span[text()='MenuLink_Manage Co-op']")); } }
        //public By V5CoopFMenuLink { get { return (By.XPath("//span[text()='Co-op Marketing Funds']")); } }
        public By V5CoopFMenuLink { get { return (By.XPath("//a[contains(@href,'CFM.aspx')]")); } }

        //public By V5CFMLogout { get { return (By.PartialLinkText("Logout")); } }
        public By V5CFMLogout { get { return By.XPath("//a[contains(@href,'/Login/Logout.aspx')]"); } }
        public By LeftNavDashboard { get { return (By.PartialLinkText("dashboard")); } }
        public By ProdAdminLink { get { return (By.XPath("//a[contains(@class,'rmLink')]//span[contains(.,'Manage Co-op')]")); } }
        public By ProdCFMLink { get { return (By.XPath("//a[contains(@class,'rmLink')]//span[contains(.,'MenuLink_CFM')]")); } }
        public By ErrorTechnical { get { return (By.XPath("//h1[contains(.,'technical error occured')]")); } }
        public By Error500Internal { get { return (By.XPath("//hi[contains(.,'Error 500: Internal Server Error')]")); } }
        public By ErrorV5OpenID { get { return (By.XPath("//div[contains(.,'There is an error determining which application you are signing into. Return to the application and try again')]")); } }
        public By ErrorPageNotWoring { get { return (By.XPath("//h1[contains(.,'This page isn’t working')]")); } }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Driver"></param>
        public BrowserURLLaunch(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }

        #region
        /// <summary>
        /// 
        /// </summary>
        public void URLEnvironment_DataBrowserURLLaunchRead()
        {
            ////log4net.Config.XmlConfigurator.Configure();
            ////ILog logger = LogManager.GetLogger(typeof(BrowserURLLaunch));
            try
            {
                string connection_db = ConfigurationManager.ConnectionStrings["BrandMuscleAutomation"].ConnectionString;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //Console.WriteLine("URLEnvironment_DataBrowserURLLaunchRead " + ex);
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
CommonUtilities.Logout(Driver);       Driver.Quit();
                  //CommonFunctions.KillProcess();

                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public void ErrorMessages()
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(BrowserURLLaunch));
            bi.WaitTime(6);
            if (bi.IsElementPresent(ErrorTechnical))
            {
                Console.WriteLine(ROLES + " ERROR: A technical error occured message is displayed, STOPPING TEST EXECUTION");
                CommonUtilities.Logout(Driver);
                Driver.Quit();

                  //CommonFunctions.KillProcess();

                Assert.Fail(ROLES + " ERROR: A technical error occured message is displayed, STOPPING TEST EXECUTION");
            }
            else if (bi.IsElementPresent(Error500Internal))
            {
                Console.WriteLine(ROLES + " ERROR: Error 500: Internal Server Error occured, STOPPING TEST EXECUTION");
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                  //CommonFunctions.KillProcess();

               Assert.Fail(ROLES + " ERROR: Error 500: Internal Server Error occured, STOPPING TEST EXECUTION");
            }
            else if (bi.IsElementPresent(ErrorPageNotWoring))
            {
                Console.WriteLine(ROLES + " ERROR: This page isn’t working, STOPPING TEST EXECUTION");
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                Assert.Fail(ROLES + " ERROR: This page isn’t working, STOPPING TEST EXECUTION");
            }
            else if (bi.IsElementPresent(ErrorV5OpenID))
            {
                Console.WriteLine(ROLES + " ERROR: V5 OpenID issue, STOPPING TEST EXECUTION");
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                  //CommonFunctions.KillProcess();

                Assert.Fail(ROLES + " ERROR: V5 OpenID issue, STOPPING TEST EXECUTION");
            }
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void BrowserURLACE(string user, String Env="QA")
        {
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(BrowserURLLaunch));
            try
            {
                ROLES = user;
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.URLEnvironment_DataBrowserURLLaunchRead();
                //bl.LoginDetails_DatabaseRead();
                //EXECUTIONENVIRONMENT = ConfigurationManager.AppSettings["Environment"].ToString();
                EXECUTIONENVIRONMENT = Env;
                BasicInteractions bi = new BasicInteractions(Driver);
                if (EXECUTIONENVIRONMENT.ToUpper() == "PROD".ToUpper())
                {
                    bi.Gotourl("https://acehardware.brandmuscle.net/LandingPages/LandingPageLayout4.aspx");


                }
                else if(EXECUTIONENVIRONMENT.ToUpper() == "STAGE".ToUpper() )
                {
                    bi.Gotourl("https://acehardware.v5stage.brandmuscle.net/LandingPages/LandingPageLayout4.aspx");
                }
                else if (EXECUTIONENVIRONMENT.ToUpper() == "DEV".ToUpper())
                {
                    bi.Gotourl("https://acehardware.v5dev.brandmuscle.net/LandingPages/LandingPageLayout4.aspx");
                }
                else
                {
                    bi.Gotourl("https://acehardware.v5qa.brandmuscle.net/Login/Login.aspx");
                }
                //bl.LoginDetails_DatabaseRead(ROLES);
                bi.WaitTime(10);  
                if (user.Equals("CORPORATE1"))
                {
                    bi.WaitVisible(V5Username);
                    //bi.Type(V5Username, "UAT_ADMIN1");
                    bi.Type(V5Username, "UAT_ADMIN");

                    bi.WaitVisible(V5Password);
                    bi.Type(V5Password, "H@RDWAR3");
                    bi.WaitVisible(V5LoginButton);
                    bi.Click(V5LoginButton);
                }
                else if (user.Equals("LME1"))
                {

                    bi.WaitVisible(V5Username);
                    if(Env.Equals("PROD"))
                        bi.Type(V5Username, "uat_coopretailemployee");
                  else
                        bi.Type(V5Username, "UAT_RetailEmployee");
                    bi.WaitVisible(V5Password);
                    bi.Type(V5Password, "H@RDWAR3");
                    //bi.Type(V5Password, "welcome");

                    bi.WaitVisible(V5LoginButton);
                    bi.Click(V5LoginButton);
                }

                bi.WaitForPageToLoad(120);
                if (bi.IsElementPresent(BusinessUnitSelectionDropdown))
                {
                    bi.WaitVisible(BusinessUnitSelectionDropdown);
                    bi.Click(BusinessUnitSelectionDropdown);
                    if (BUSINESSUNIT.Equals("ACE") || BUSINESSUNIT.Equals("Ace"))
                    {
                        bi.Click(BusinessUnitSelectionDropdownOption(BUSINESSUNIT));
                        ErrorMessages();
                    }
                    else
                    {
                        Console.WriteLine(ROLES + " : " + BUSINESSUNIT + " is not present in the business unit dropdown");
                        CommonUtilities.Logout(Driver);
                        Driver.Quit();
                          //CommonFunctions.KillProcess();
                    }

                    bi.WaitVisible(V5CFMLink);
                    bi.Click(V5CFMLink);
                    ErrorMessages();
                    bi.WaitVisible(LeftNavDashboard);
                }
                else
                {
                    bi.WaitVisible(V5CFMLink);
                    bi.Click(V5CFMLink);
                    ErrorMessages();
                    bi.WaitVisible(LeftNavDashboard);
					Thread.Sleep(10000);
                }
            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                //CommonFunctions.KillProcess();
                Console.WriteLine("Error: " + ex.Message);
                throw;
                //Assert.Fail("BrowserURLACE: " + ex);
            }
        }
        #endregion


        //#region
        ///// <summary>
        ///// To launch pandora application
        ///// </summary>
        ///// <param name="name"></param>
        //public void BrowserURLPANDORA(string user)
        //{
        //    try
        //    {
        //        ROLES = user;
        //        BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
        //        bl.URLEnvironment_DataBrowserURLLaunchRead();
        //        //bl.LoginDetails_DatabaseRead();
        //        BasicInteractions Bi = new BasicInteractions(Driver);

        //        bi.Gotourl("https://pandora.v5qa.brandmuscle.net/");
        //        //bl.LoginDetails_DatabaseRead(ROLES);

        //        if (user.Equals("CORPORATE1"))
        //        {
        //            bi.WaitVisible(V5Username);
        //            bi.Type(V5Username, "UAT_ADMIN");
        //            bi.WaitVisible(V5Password);
        //            bi.Type(V5Password, "mJP38dX3");
        //            bi.WaitVisible(V5LoginButton);
        //            bi.Click(V5LoginButton);
        //        }
        //        else if (user.Equals("LME1"))
        //        {

        //            bi.WaitVisible(V5Username);
        //            bi.Type(V5Username, "pandora_employee1");
        //            bi.WaitVisible(V5Password);
        //            bi.Type(V5Password, "welcome");
        //            bi.WaitVisible(V5LoginButton);
        //            bi.Click(V5LoginButton);
        //        }


        //        if (bi.IsElementPresent(BusinessUnitSelectionDropdown))
        //        {
        //            bi.WaitVisible(BusinessUnitSelectionDropdown);
        //            bi.Click(BusinessUnitSelectionDropdown);
        //            //  bi.Type(BusinessUnitSelectionDropdown,"P");
        //            if (PANDORABUSINESSUNIT.Equals("Pandora") || PANDORABUSINESSUNIT.Equals("PANDORA"))
        //            {
        //                bi.Click(BusinessUnitSelectionDropdownOption("Pandora"));
        //                ErrorMessages();
        //            }
        //            else
        //            {
        //                Console.WriteLine(ROLES + " : " + PANDORABUSINESSUNIT + " is not present in the business unit dropdown");
        //CommonUtilities.Logout(Driver);       Driver.Quit();
        //            }

        //            bi.WaitVisible(V5CFMenuLink);
        //            bi.Click(V5CFMenuLink);
        //            ErrorMessages();
        //            bi.WaitVisible(LeftNavDashboard);
        //        }
        //        else
        //        {
        //            bi.WaitVisible(V5CFMenuLink);
        //            bi.Click(V5CFMenuLink);
        //            ErrorMessages();
        //            bi.WaitVisible(LeftNavDashboard);
        //            Thread.Sleep(10000);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //                        CommonUtilities.Logout(Driver);       Driver.Quit();;
        //        Console.WriteLine("BrowserURLPANDORA: " + ex);
        //        Assert.Fail("BrowserURLPANDORA: " + ex);
        //    }
        //}
        //#endregion

        #region
        /// <summary>
        /// To launch pandora application
        /// </summary>
        /// <param name="name"></param>
        public void BrowserURLCLIENT(string user,String Client, String Env="QA")
        {
            try
            {
                ROLES = user;
                BrowserURLLaunch bl = new BrowserURLLaunch(Driver);
                bl.URLEnvironment_DataBrowserURLLaunchRead();
                //bl.LoginDetails_DatabaseRead();
                //EXECUTIONENVIRONMENT = ConfigurationManager.AppSettings["Environment"].ToString();
                EXECUTIONENVIRONMENT = Env;
                //bl.LoginDetails_DatabaseRead();
                BasicInteractions bi = new BasicInteractions(Driver);
                bi.WaitTime(5);

                if (Client.ToUpper().Trim().Equals("PANDORA"))
                {
                    if (Env.ToUpper() == "PROD".ToUpper())
                    {
                        bi.Gotourl("https://pandora.brandmuscle.net/login/login.aspx");
                        switch (user.ToUpper().Trim())
                        {
                            case "CORPORATE1":
                                bi.WaitVisible(V5Username);
                                //bi.Type(V5Username, "UAT_ADMIN");
                                bi.Type(V5Username, "adoneau@pandora.net");
                                bi.WaitVisible(V5Password);
                                bi.Type(V5Password, "welcome");
                                //bi.Type(V5Password, "welcome");
                                bi.WaitVisible(V5LoginButton);
                                bi.Click(V5LoginButton);
                                break;

                            case "LME1":
                                bi.WaitVisible(V5Username);
                                bi.Type(V5Username, "adoneau@pandora.net");
                                //bi.Type(V5Username, "Uat_employee");
                                bi.WaitVisible(V5Password);
                                //bi.Type(V5Password, "P@ND0RA");
                                bi.Type(V5Password, "welcome");

                                bi.WaitVisible(V5LoginButton);
                                bi.Click(V5LoginButton);
                                break;

                        }
                    }
                    else
                    {
                        bi.Gotourl("https://pandora.v5qa.brandmuscle.net/login/login.aspx");
                        switch (user.ToUpper().Trim())
                        {
                            case "CORPORATE1":
                                bi.WaitVisible(V5Username);
                                //bi.Type(V5Username, "UAT_ADMIN");
                                bi.Type(V5Username, "UAT_ADMIN");
                                bi.WaitVisible(V5Password);
                                bi.Type(V5Password, "P@ND0RA");
                                //bi.Type(V5Password, "welcome");
                                bi.WaitVisible(V5LoginButton);
                                bi.Click(V5LoginButton);
                                break;

                            case "LME1":
                                bi.WaitVisible(V5Username);
                                bi.Type(V5Username, "adoneau@pandora.net");
                                //bi.Type(V5Username, "Uat_employee");
                                bi.WaitVisible(V5Password);
                                //bi.Type(V5Password, "P@ND0RA");
                                bi.Type(V5Password, "welcome");

                                bi.WaitVisible(V5LoginButton);
                                bi.Click(V5LoginButton);
                                break;

                        }
                    }

                }
                else if (Client.ToUpper().Trim().Equals("NATIONWIDE"))
                {
                    if (Env.ToUpper() == "PROD".ToUpper())
                    {
                        bi.Gotourl("https://nationwide-storefront.brandmuscle.net/?redirect=false");
                        switch (user.ToUpper().Trim())
                        {
                            case "LME1":
                                bi.WaitVisible(V5Username);
                                bi.Type(V5Username, "priti.Kumari@brandmuscle.com");
                                bi.WaitVisible(V5Password);
                                bi.Type(V5Password, "Ownlocal512");
                                bi.WaitVisible(V5LoginButton);
                                bi.Click(V5LoginButton);
                                bi.WaitForPageToLoad(120);
                                bi.WaitTime(10);
                                break;
                        }
                    }
                    else
                    {
                        bi.Gotourl("https://nationwide.v5qa.brandmuscle.net/CFM/CFM.aspx");
                        switch (user.ToUpper().Trim())
                        {
                            case "CORPORATE1":
                                bi.WaitVisible(V5Username);
                                bi.Type(V5Username, "NW_Admin");
                                bi.WaitVisible(V5Password);
                                bi.Type(V5Password, "welcome");
                                break;

                            case "LME1":
                                bi.WaitVisible(V5Username);
                                bi.Type(V5Username, "NW_User1");
                                bi.WaitVisible(V5Password);
                                bi.Type(V5Password, "welcome");
                                break;

                            case "LME2":
                                bi.WaitVisible(V5Username);
                                bi.Type(V5Username, "NW_User2");
                                bi.WaitVisible(V5Password);
                                bi.Type(V5Password, "welcome");
                                break;

                            case "REVIEWER1":
                                bi.WaitVisible(V5Username);
                                bi.Type(V5Username, "NW_User2");
                                bi.WaitVisible(V5Password);
                                bi.Type(V5Password, "welcome");
                                break;

                            case "REVIEWER2":
                                bi.WaitVisible(V5Username);
                                bi.Type(V5Username, "NW_User2");
                                bi.WaitVisible(V5Password);
                                bi.Type(V5Password, "welcome");
                                break;

                        }

                        bi.WaitVisible(V5LoginButton);
                        try
                        {
                            bi.Click(V5LoginButton);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Error: " + ex.Message);
                        }
                        finally
                        {
                            bi.WaitForPageToLoad(100);
                            bi.Refresh();
                        }

                        bi.WaitForPageToLoad(100);
                        bi.WaitTime(20);

                    }
                }

                else if (Client.ToUpper().Trim().Equals("DITCH WITCH"))
                {
                    if (Env.ToUpper() == "PROD".ToUpper())
                    {
                        bi.Gotourl("https://ditchwitch.brandmuscle.net/?redirect=false");
                        bi.WaitVisible(V5Username);
                        bi.Type(V5Username, "qaatestemulate1");
                        bi.WaitVisible(V5Password);
                        bi.Type(V5Password, "welcome");
                        bi.WaitVisible(V5LoginButton);
                        bi.Click(V5LoginButton);
                        bi.WaitForPageToLoad(120);
                        bi.WaitTime(10);
                    }
                    else
                    {
                        bi.Gotourl("https://ditchwitch.v5qa.brandmuscle.net/?redirect=false");
                        bi.WaitVisible(V5Username);
                        bi.Type(V5Username, "qaatestemulate1");
                        bi.WaitVisible(V5Password);
                        bi.Type(V5Password, "welcome");
                        bi.WaitVisible(V5LoginButton);
                        bi.Click(V5LoginButton);
                        bi.WaitForPageToLoad(120);
                        bi.WaitTime(10);
                    }

                }
                else if (Client.ToUpper().Trim().Equals("BOBCAT"))
                {
                    if (Env.ToUpper() == "PROD".ToUpper())
                    {
                        bi.Gotourl("https://bobcat.brandmuscle.net/");
                        switch (user.ToUpper().Trim())
                        {
                            case "CORPORATE1":
                                bi.WaitVisible(V5Username);
                                bi.Type(V5Username, "BobcatCorporateAdmin");
                                bi.WaitVisible(V5Password);
                                bi.Type(V5Password, "welcome");
                                bi.WaitVisible(V5LoginButton);
                                bi.Click(V5LoginButton);
                                break;

                            case "LME1":
                                bi.WaitVisible(V5Username);
                                bi.Type(V5Username, "BobcatCoopContact");
                                bi.WaitVisible(V5Password);
                                bi.Type(V5Password, "welcome");
                                bi.WaitVisible(V5LoginButton);
                                bi.Click(V5LoginButton);
                                break;
                        }
                    }
                    else if (Env.ToUpper() == "STAGE".ToUpper())
                    {
                        bi.Gotourl("https://bobcat.v5stage.brandmuscle.net/");
                        switch (user.ToUpper().Trim())
                        {
                            case "CORPORATE1":
                                bi.WaitVisible(V5Username);
                                bi.Type(V5Username, "Uat_CorporateAdmin");
                                bi.WaitVisible(V5Password);
                                bi.Type(V5Password, "welcome");
                                bi.WaitVisible(V5LoginButton);
                                bi.Click(V5LoginButton);
                                break;

                            case "LME1":
                                bi.WaitVisible(V5Username);
                                bi.Type(V5Username, "Uat_CoopContact");
                                bi.WaitVisible(V5Password);
                                bi.Type(V5Password, "welcome");
                                bi.WaitVisible(V5LoginButton);
                                bi.Click(V5LoginButton);
                                break;
                        }
                    }
                    else
                    {
                        bi.Gotourl("https://bobcat.v5qa.brandmuscle.net/");
                        switch (user.ToUpper().Trim())
                        {
                            case "CORPORATE1":
                                bi.WaitVisible(V5Username);
                                bi.Type(V5Username, "Uat_CorporateAdmin");
                                bi.WaitVisible(V5Password);
                                bi.Type(V5Password, "welcome");
                                bi.WaitVisible(V5LoginButton);
                                bi.Click(V5LoginButton);
                                break;

                            case "LME1":
                                bi.WaitVisible(V5Username);
                                bi.Type(V5Username, "Uat_CoopContact");
                                bi.WaitVisible(V5Password);
                                bi.Type(V5Password, "welcome");
                                bi.WaitVisible(V5LoginButton);
                                bi.Click(V5LoginButton);
                                break;
                        }
                    }
                    bi.WaitForPageToLoad(120);


                }
                      
               /* if (bi.IsElementPresent(BusinessUnitSelectionDropdown))
                {
                //bi.WaitVisible(BusinessUnitSelectionDropdown);
                //bi.Click(BusinessUnitSelectionDropdown);
                bi.SelectByText(BusinessUnitSelectionDropdown, Client.Trim());
                bi.WaitForPageToLoad(120);
                }
                else
                {
                    Console.WriteLine("Business Unit Dropdown Not Available");
                }*/

                if (bi.IsElementPresent(V5CFMLink))
                {
                    bi.WaitVisible(V5CFMLink);
                    bi.Click(V5CFMLink);
                    bi.WaitTillNotVisible(imgLoading,240);
                    ErrorMessages();
                    bi.WaitVisible(LeftNavDashboard);

                }
                else
                {
                    Console.WriteLine("CFM Link is not Available");
                }
            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                //CommonFunctions.KillProcess();
                Console.WriteLine("Error: " + ex.Message);
                throw;
                //Assert.Fail("BrowserURLPANDORA: " + ex);
            }
        }
        #endregion

        //public void Logout()
        //{
        //    BasicInteractions bi = new BasicInteractions(Driver);
        //    if (bi.IsElementVisible(V5CFMLogout))
        //    {
        //        bi.Click(V5CFMLogout);
        //        bi.WaitForPageToLoad(120);
        //        bi.WaitTime(10);
        //    }
        //}

    }
}
