using CFM_PARALLEL.Common;
using NUnit.Framework;
using OpenQA.Selenium;

using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;

namespace CFMAutomation.PageObject.UI.Ace.Disbursement
{
    public class Disbursement_Fullflow
    {
        private IWebDriver Driver { get; set; }





        public Disbursement_Fullflow(IWebDriver Driver)
        {
            this.Driver = Driver;
          
        }
        public static string DISB_ID;
        public static string db_claim_id;

        /// <summary>
        /// 
        /// </summary>
        public static void Disbursement_DatabaseRead()
        {
           
            try
            {
                string connection_db = ConfigurationManager.ConnectionStrings["BrandMuscleAutomation"].ConnectionString;
                SqlConnection connection_claim_db = new SqlConnection(connection_db);
                string claim_query = "SELECT TOP 1 CLAIM_ID FROM CFMDISBURSEMENT ORDER BY INDEXADDNEW DESC";
                connection_claim_db.Open();
                SqlCommand claim_cmd = new SqlCommand(claim_query, connection_claim_db);
                using (SqlDataReader read = claim_cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        db_claim_id = read["claim_id"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database connection error is: " + ex);
                Assert.Fail("Database connection error is: " + ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public void Ace_Disbursement_Fullflow(string action,string db_claim_id)
        {
            try
            {
                //Disbursement_DatabaseRead();
                Disbursement_SelectClaims disbSC = new Disbursement_SelectClaims(Driver);
                disbSC.ACE_Disbursement_SelectClaims(db_claim_id);
                Disbursement_PreviewDisbursement disbPD = new Disbursement_PreviewDisbursement(Driver);
                disbPD.ACE_Disbursement_PreviewDisbursement();
                Disbursement_RequestApproval disbRA = new Disbursement_RequestApproval(Driver);
                disbRA.Ace_Disbursement_RequestApproval();
                Thread.Sleep(30000);
                //Approve //Deny //Request Data
                Disbursement_ManageDisbursement disbMD = new Disbursement_ManageDisbursement(Driver);
                disbMD.Ace_Disbursement_ManageDisbursement(action);
            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);
                Driver.Quit();              
                Console.WriteLine("Exception:" + ex.Message);
                throw ex;
            }
        }

        

    }
}
