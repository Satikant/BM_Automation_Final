using CFM_PARALLEL.Common;
using System;

namespace CFMAutomation.Common
{
    public class Parameters
    {
        public static string Ace_Stage_url = "https://acehardware.v5stage.brandmuscle.net/Login/Login.aspx";
        public static string Ace_QA_url = "https://acehardware.v5qa.brandmuscle.net/Login/Login.aspx";
        public static string Ace_Prod_url = "https://acehardware.brandmuscle.net/Login/Login.aspx";
        public static string Ace_Dev_url = "https://acehardware.v5dev.brandmuscle.net/LandingPages/LandingPageLayout4.aspx";

        public static string Pandora_QA_url = "https://pandora.v5qa.brandmuscle.net/login/login.aspx";
        public static string Pandora_Prod_url = "https://pandora.brandmuscle.net/login/login.aspx";

        public static string Nationwide_Stage_url = "https://nationwide.v5stage.brandmuscle.net/Login/Login.aspx?ReturnUrl=%2fCFMV4%2fCFMV4.aspx#/";
        public static string Nationwide_QA_url = "https://nationwide.v5qa.brandmuscle.net/Login/Login.aspx?ReturnUrl=%2fCFMV4%2fCFMV4.aspx#/";
        //public static string Nationwide_Prod_url = "https://nationwide-storefront.brandmuscle.net/?redirect=false";
        public static string Nationwide_Prod_url = "https://nationwide.brandmuscle.net/Login/Login.aspx?";

        public static string Masco_Stage_url = "https://admintool.v5stage.brandmuscle.net/Login/Login.aspx?logout=true";
        public static string Masco_Prod_url = "https://admintool.brandmuscle.net/Login/Login.aspx?logout=true";

        public static string Farmers_Stage_url = "https://farmers.v5stage.brandmuscle.net/Login/Login.aspx?ReturnUrl=%2fcfm%2fcfm.aspx";
        public static string Farmers_Prod_url = "https://agencymktg.farmersinsurance.com/v/7/2/prc/fi/";

        public static string Amnat_QA_url = "https://americannational.v5qa.brandmuscle.net/Login/Login.aspx?ReturnUrl=%2f";
        public static string Amnat_Prod_url = "https://admintool.brandmuscle.net/Login/Login.aspx?logout=true";

        public static string Geico_Stage_url = "https://geico.stage.brandmuscle.net/app/cfm/v2/#/dashboard";
        public static string Prod_QA_BU_Url = "https://bucfm.brandmuscle.net/CFM/CFM.aspx#";

        public static string Bobcat_Stage_url = "https://bobcat.v5stage.brandmuscle.net/";
        public static string Bobcat_QA_url = "https://bobcat.v5qa.brandmuscle.net/";
        public static string Bobcat_Prod_url = "https://bobcat.brandmuscle.net/";

        public static string Ditchwitch_QA_url = "https://ditchwitch.v5qa.brandmuscle.net/?redirect=false";
        public static string Ditchwitch_Prod_url = "https://ditchwitch.brandmuscle.net/?redirect=false";

        public static string Admin_Stage_url = "https://admintool.v5stage.brandmuscle.net/Login/Login.aspx?logout=true";
        public static string Admin_Prod_url = "https://admintool.brandmuscle.net/Login/Login.aspx?logout=true";
        public static string CampaignManager_Stage_URL = "https://admintool.v5stage.brandmuscle.net/Login/Login.aspx";
        // prod BU
        public static string Prod_BU_ProgramName = "AutomationProgram";
        public static string Prod_BU_StoreName = "28 - CHILD 1";

        //Nationwide fund request Parameters
        public static string NW_ProgramName = "QAAutomation2020";
        public static string NW_StoreName = "00006510";
        public static string NW_RequestedAmount = "200.99";

        //Nationwide fund request PROD Parameters
        public static string NW_Prod_ProgramName = "2021 Nationwide Co-op";
        public static string NW_Prod_AgencyName1 = "060037544";
        public static string NW_Prod_AgencyName2 = "00053355";
        public static string NW_EmulateUser1 = "NW060037544";
        public static string NW_EmulateUser2 = "Virendra.Singh@brandmuscle.com";
        public static string NW_EmulateFirstApprover = "stephanie.vlk@brandmuscle.com";
        public static string NW_EmulateSecondApprover = "NWPOLINSR";
        public static string NW_Business_Unit = "Nationwide – Storefront";

        //nationwide display claim parameter
        public static string NW_ReferenceName = "TestReferenceName";
        public static string NW_OrderId = "54321";
        public static string NW_PurchasedActivityCost = "500.55";

        // nationwide claim parameter
        public static string NW_ClaimTotalActivityCost = "50.80";
        public static string NW_ClaimRequestedAmount = "10.88";
        public static string NW_ActivityCategory = "CALENDARS";
        public static string NW_ActivityType = "Calendars";
        public static string NW_ProductType = "Commercial";


        //Nationwide Parameters - Add Payment Profile

        public static string time = DateTime.Now.ToString("dd-MM ss tt");
        public static string time1 = DateTime.Now.ToString("ss tt");

        public static string NW_BusinessName = "Biz Name "+ time;
        public static string NW_Country = "United States of America";
        public static string NW_Address = time1+" Avenue";
        public static string NW_Street = "West Cross";
        public static string NW_City = "Cleveland";
        public static string NW_State = "Ohio";
        public static string NW_Zipcode = "44101";
        public static string NW_RoutingNumber = "011401533";
        public static string NW_AccNumber = "123098123";
        public static string NW_AccType = "Savings";

        //MASCO PROD Parameters
        public static string Masco_Business_Unit = "Masco Cabinetry";
        public static string Masco_EmulateCorporateUser= "Cecelia Warrick";
        public static string Masco_EmulateAccountUser1 = "Kelly Tipton";
        public static string Masco_EmulateAccountUser2 = "nancy.moore@cabinetworksgroup.com";
        public static string Masco_EmulateDealerUser = "DAWN THOMPSON";
        public static string Masco_EmulateDistrictManager = "dick.huber@cabinetworksgroup.com";
        public static string Masco_EmulateDirector = "tony.achatz@cabinetworksgroup.com";
        public static string Masco_EmulateVP = "charley@cabinetworksgroup.com";
        public static string Masco_EmulateFinance = "kara.husband@cabinetworksgroup.com";

        //Masco claim and fund request details
        public static string MS_FR_ProgramName = "2021 Non-Standard DAP";
        public static string MS_FR_StoreName = "300124158";
        public static string MS_DC_StoreName = "300122248 - FBC HOME CONCEPT LLC";
        public static string MS_FR_RequestedAmount = "650.99";
        public static string MS_ProgramName = "2021 Standard DAP";
        public static string MS_StoreName2 = "300111171";
        public static string MS_StoreName = "300116194";
        public static string MS_StoreName3 = "300122720";
        public static string MS_TotalActivityCost = "50.88";
        public static string MS_RequestedAmount = "10.99";
        public static string MS_RequestedNegativeAmount = "-10.99";
        public static string MS_ReferenceName = "Test123";
        public static string MS_OrderId = "54321";

        // Masco Stage details
        public static string MS_stage_StoreName = "300124158";
        public static string MS_EmulateDealer2 = "erica.davis@bldr.com";
        public static string MS_InvoiceNummber = "Test_Invoice_123";
        public static string MS_AgentNAme = "300124158 - BUILDERS FIRSTSOURCE INC-HALFMOON";

        public static string Masco_Claim_ProgramName()
        {
            if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("PROD"))
            {
                return MS_ProgramName;
            }
            else if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("STAGE"))
            {
                return MS_ProgramName;
            }
            else
            {
                return null;
            }
        }

        //AMNAT PROD Parameters
        public static string Amnat_Prod_Business_Unit = "American National";
        public static string Amnat_Prod_EmulateUser2 = "ML000717";
        //public static string Amnat_Prod_EmulateUser = "ML473901";
        public static string Amnat_Prod_EmulateUser = "ML529408";
        public static string AM_Prod_ProgramName = "Marketing Credits 2021";
        public static string AM_Prod_StoreName = "ML529408";
        public static string AM_TotalActivityCost = "50.88";
        public static string AM_RequestedAmount = "20.99";
        public static string AM_ReferenceName = "Test123";

        public static string Amnat_ProgramName()
        {
            if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("PROD"))
            {
                return AM_Prod_ProgramName;
            }

            else if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("STAGE"))
            {
                return AM_Prod_ProgramName;
            }
            else
            {
                return null;
            }
        }

        // Geico Details
        public static string SOB_Name = "90147";
        public static string Geico_ProgramName = "2020 GFR Co-op Program";
        public static string Geico_ActivityCost = "100";
        public static string Geico_RequestedAmount = "50.88";

        //Farmers Details
        public static string Farmers_EmulateUser1= "192577";
        public static string Farmers_EmulateUser2= "040302";
        public static string Farmers_Approver= "Deepthi.gavarna@brandmuscle.com";
        public static string Farmers_RequestedAmount = "50";
        public static string Farmers_ActivityCost = "100";
        public static string Farmers_InvoiceNumber = "12345";
        public static string Farmers_ProgramName = "CostshareQAProgram";


        // ACE details

        public static string ProgramName_QA = "AutomationProgram2020";
        public static string ACE_ProgramName = "2021 Ace Brand";
        //public static string ACE_ProgramName = "Ace New Store Fund";

        public static string Ace_ProgramName(string ProgrammOverDrwawnFlag= "NO" )
        {
            if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("PROD"))
            {
                return "2019 Ace Matching Fund";
            }
            else if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("STAGE") & ProgrammOverDrwawnFlag == "NO")
            {
                return "2020 Ace Brand";                
            }
            else if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("QA") & ProgrammOverDrwawnFlag == "YES")
            {               
                return "2020 Ace Brand";
            }
            else
            {
                return null;
            }
        }


        public static string ClaimTotalActivityCost_ACE(string ProgrammOverDrwawnFlag = "NO")
        {
            if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("QA") & ProgrammOverDrwawnFlag == "YES")
            {
                return "9000.00";
            }
            else if((BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("QA") & ProgrammOverDrwawnFlag == "NO"))
            {
                return "200.00";
            }
            else if ((BrowserURLLaunch.EXECUTIONENVIRONMENT.ToUpper().Equals("Prod".ToUpper()) & ProgrammOverDrwawnFlag == "NO"))
            {
                return "200.00";
            }
            else if ((BrowserURLLaunch.EXECUTIONENVIRONMENT.ToUpper().Equals("Prod".ToUpper()) & ProgrammOverDrwawnFlag == "YES"))
            {
                return "200.00";
            }
            else { return null; }
        }

        public static string ClaimRequestedAmount_ACE(string ProgrammOverDrwawnFlag = "NO")
        {
            if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("QA") & ProgrammOverDrwawnFlag == "YES")
            {
                return "4000.00";
            }
            else if ((BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("QA") & ProgrammOverDrwawnFlag == "NO"))
            {
                return "100.00";
            }
            else if ((BrowserURLLaunch.EXECUTIONENVIRONMENT.ToUpper().Equals("Prod".ToUpper()) & ProgrammOverDrwawnFlag == "NO"))
            {
                return "1.00";
            }
            else if ((BrowserURLLaunch.EXECUTIONENVIRONMENT.ToUpper().Equals("Prod".ToUpper()) & ProgrammOverDrwawnFlag == "YES"))
            {
                return "1.00";
            }
            else { return null; }
        }


        //AccrualType for the program is Rolling
        public static string Ace_ProgramName_Rolling = "QAAutomation-Rolling";
        public static string Ace_Roles_Corporate = "CORPORATE1";
        public static string Ace_Roles_LME = "LME1";

        public static string Ace_Test_LME1 = "M3903";
        public static string Ace_Test_LME2 = "14876";
        public static string Ace_Product = "Ace Local Lift";
        public static string Ace_Test_LME_00080 = "M3701";
        public static string Ace_AccrualPositive_Amount = "2000.00";
        public static string Ace_AccrualNegative_Amount = "-20.00";
        public static string Ace_TransferPositive_Amount = "20.00";
        public static string Ace_TransferNegative_Amount = "-20.00";
        public static string ClaimApprovalAmount_ACE = "10.00";

        public static string Ace_Test_LME_00020()
        {
            if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("PROD"))
            {
                return "14335";
            }
            else if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("QA"))
            {
                return "M3903";
            }
            else
            {
                return "00080";
            }
        }


        //**User details
        //ACE EMULATE USER
        public static string Usr_Prod_Admin = "Virendra Singh";
        public static string EmulateACE_CorporateUser = "Aabrah@acehardware.com";
        public static string EmulateACE_AdminUser = "priti.kumari@brandmuscle.com";
        public static string EmulateACE_LMEUser = "BWats1@aceservices.com";

        //UAT_ADMIN
        public string Usr_UAT_Admin = "UAT_ADMIN";
        public string Pwd_UAT_Admin = "H@RDWAR3";
        //UAT_CoopCorporate
        public string Usr_UAT_CoopCorporate = "UAT_CoopCorporate";
        public string Pwd_UAT_CoopCorporate = "welcome";
        //UAT_CoopRetailEmployee
        public string Usr_UAT_CoopRetailEmployee = "UAT_CoopRetailEmployee";
        public string Pwd_UAT_CoopRetailEmployee = "H@RDWAR3";        
        //UAT_CoopCorporate
        public string Usr_UAT_CoopStoreOwner = "UAT_CoopStoreOwner";
        public string Pwd_UAT_CoopStoreOwner = "welcome";
        //UAT_CoopCorporate
        public string Usr_UAT_RetailEmployee = "UAT_RetailEmployee";
        public string Pwd_UAT_RetailEmployee = "H@RDWAR3";

        //Pandora Parameters
        public static string Pandora_ProgramName()
        {
            if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("PROD"))
            {
                return "United States 2021";
            }
            else if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("QA"))
            {
                return "QAAutomationAug";
            }
            else
            {
                return null;
            }
        }

        public static string ClaimTotalActivityCost_Pandora = "50000.00";
        public static string ClaimRequestedAmount_Pandora = "30000.00";
        public static string ClaimApprovalAmount_Pandora="10000.00";
        public static string ClaimTotalActivityCost_Pandora_Below5000 = "4000.00";
        public static string ClaimRequestedAmount_Pandora_Below5000 = "1000.00";

        public static string Pandora_ProgramName_Rolling = "QAAutomation-Rolling";
        public static string Pandora_Test_LME = "Braun and Sons";
        public static string Pandora_Test_LME_PROD = "USF0036639 - PANDORA @ Sambil Curacao";

        public static string Pandora_AccrualPositive_Amount = "2000.00";
        public static string Pandora_AccrualNegative_Amount = "-20.00";
        public static string Pandora_TransferPositive_Amount = "20.00";
        public static string Pandora_TransferNegative_Amount = "-20.00";


        //Bobcat Parameters
        public static string Bobcat_ProgramName()
        {
            if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("PROD"))
            {
                return "2021 FL-CST Other";
            }
            else if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("QA"))
            {
                return "OnlineMarketingActivity";
            }
            else if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("STAGE"))
            {
                return "Compact Tractor";
            }
            else
            {
                return null;
            }
        }
        public static string Bobcat_Test_LME()
        {
            if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("PROD"))
            {
                return "01111";
            }
            else if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("STAGE"))
            {
                return "05294";
            }
            else if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("QA"))
            {
                return "05294";
            }
            else
            {
                return null;
            }
        }

        public static string Bobcat_ProgramName_Rolling = "Ace Brand";
        public static string ClaimTotalActivityCost_Bobcat = "30";
        public static string ClaimRequestedAmount_Bobcat = "0.5";
        public static string ClaimApprovalAmount_Bobcat = "90";
        public static string ClaimTotalActivityCost_Bobcat_Below10000 = "4000";
        public static string ClaimRequestedAmount_Bobcat_Below10000 = "1000";
        public static string Bobcat_AccrualPositive_Amount = "10000";
        public static string Bobcat_AccrualNegative_Amount = "-20";
        public static string Bobcat_TransferPositive_Amount = "20";
        public static string Bobcat_TransferNegative_Amount = "-20";
        public static string Bobcat_StoreName = "00303 - 2M Mower and Tool, Miami, FL";
    }
}
