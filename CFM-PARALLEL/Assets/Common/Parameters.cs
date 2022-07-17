using CFM_PARALLEL.Common;
using System;

namespace CFMAutomation.Common
{
    public class Parameters
    {
        //Nationwide fund request Parameters
        public static string NW_ProgramName = "QAAutomation2020";
        public static string NW_StoreName = "00006510";
        public static string NW_RequestedAmount = "200.99";

        //Nationwide fund request PROD Parameters
        public static string NW_Prod_ProgramName = "2020 Exclusive Co-op";
        public static string NW_Prod_AgencyName = "060037544";



        //nationwide display claim parameter
        public static string NW_ReferenceName = "TestReferenceName";
        public static string NW_OrderId = "54321";
        public static string NW_PurchasedActivityCost = "500.55";
        public static string EmulateUserName = "NW060037544";








        //Nationwide Parameters - Add Payment Profile

        //public static string time = DateTime.Now.ToString("h:mm:ss tt");
        public static string time = DateTime.Now.ToString("dd-MM ss tt");

        public static string time1 = DateTime.Now.ToString("ss tt");

        Random rnd = new Random();

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


        //public int RandomNumber(int min, int max)
        //{
        //    Random random = new Random();
        //    return random.Next(min, max);
        //}


        public static string NW_SelectProgramName()
        {
            if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("PROD"))
            {
                return "NW_ProgramName";
            }
            else if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("QA"))
            {
                return "NW_ProgramName";
              
            }
            else
            {
                return null;
            }

        }

        public static string NW_SelectStoreName()
        {
            if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("PROD"))
            {
                return "NW_StoreName";
            }
            else if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("QA"))
            {
                return "NW_StoreName";

            }
            else
            {
                return null;
            }

        }


        // ACE details

        public static string ProgramName = "AutomationProgram2020";

        public static string Ace_ProgramName(string ProgrammOverDrwawnFlag= "NO" )
        {
            if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("PROD"))
            {
                return "2019 Ace Matching Fund";
            }
            else if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("QA") & ProgrammOverDrwawnFlag == "NO")
            {
                return ProgramName;
                //return "QAAutomationAug";
                //return "QAProgramOverdrawn";
            }
            else if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("QA") & ProgrammOverDrwawnFlag == "YES")
            {
                //return "QAAutomation31";
                //return "QAProgramOverdrawn";
                //return "QAAutomation-OverDrawn";
                return ProgramName;
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
                return "100.00";
            }
            else if ((BrowserURLLaunch.EXECUTIONENVIRONMENT.ToUpper().Equals("Prod".ToUpper()) & ProgrammOverDrwawnFlag == "YES"))
            {
                return "100.00";
            }
            else { return null; }
        }


        //AccrualType for the program is Rolling
        public static string Ace_ProgramName_Rolling = "QAAutomation-Rolling";
        public static string Ace_Roles_Corporate = "CORPORATE1";
        public static string Ace_Roles_LME = "LME1";

        //public static string Ace_Test_LME_00020()() = "14335";
        //public static string Ace_Test_LME_00020() = "14335";
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
        public static string Ace_Test_LME = "M3903";
        public static string Ace_Test_LME_00080 = "M3701";
        public static string Ace_AccrualPositive_Amount = "2000.00";
        public static string Ace_AccrualNegative_Amount = "-20.00";
        public static string Ace_TransferPositive_Amount = "20.00";
        public static string Ace_TransferNegative_Amount = "-20.00";
        public static string ClaimApprovalAmount_ACE = "10.00";

        //**User details
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
                return "United States (US)";
            }
            else if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("QA"))
            {
                return "QAAutomationAug";
                //return "QAProgramOverdrawn";
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
        public static string Pandora_Test_LME_PROD = "USJ0001294 - Borden’s Jewelry Company / Cookeville";

        public static string Pandora_AccrualPositive_Amount = "2000.00";
        public static string Pandora_AccrualNegative_Amount = "-20.00";
        public static string Pandora_TransferPositive_Amount = "20.00";
        public static string Pandora_TransferNegative_Amount = "-20.00";


        //Bobcat Parameters
        public static string Bobcat_ProgramName()
        {
            if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("PROD"))
            {
                return "Compact Tractor";
            }
            else if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("QA"))
            {
                return "OnlineMarketingActivity";
                //return "QAProgramOverdrawn";
            }
            else if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("STAGE"))
            {
                return "Compact Tractor";
                //return "QAProgramOverdrawn";
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
                //return "09999";
                return "01111";

            }
            else if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("STAGE"))
            {
                return "05294";
                //return "QAProgramOverdrawn";
            }
            else if (BrowserURLLaunch.EXECUTIONENVIRONMENT.Equals("QA"))
            {
                return "05294";
                //return "QAProgramOverdrawn";
            }
            else
            {
                return null;
            }
        }

        public static string Bobcat_ProgramName_Rolling = "Ace Brand";
        public static string ClaimTotalActivityCost_Bobcat = "30000";
        public static string ClaimRequestedAmount_Bobcat = "10200";
        public static string ClaimApprovalAmount_Bobcat = "9000";
        public static string ClaimTotalActivityCost_Bobcat_Below10000 = "4000";

        public static string ClaimRequestedAmount_Bobcat_Below10000 = "1000";

        public static string Bobcat_AccrualPositive_Amount = "10000";
        public static string Bobcat_AccrualNegative_Amount = "-20";
        public static string Bobcat_TransferPositive_Amount = "20";
        public static string Bobcat_TransferNegative_Amount = "-20";
        //public static string Bobcat_Test_LME_PROD = "09999";
    }
}
