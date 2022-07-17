using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Data.SqlClient;
using NUnit.Framework;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;
using CFM_PARALLEL.Common;

namespace CFMAutomation.PageObject.UI.Ace.Program
{
    public class Program_FullFlow
    {
        private IWebDriver Driver { get; set; }
        public Program_FullFlow(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        public static string db_programName, db_prgDesc, db_strDate, db_endDate, db_currency,
            db_fundistributionhierarchy,db_claimflow, db_overdraft,db_requireBPA,db_ecomEligible,
            db_accrualType, db_accrualPeriod, db_claimDate,db_expDate, 
            db_reimbursementType, db_reimbursementRate, db_capping, db_cappingpercent,db_activityOptions,
            db_accrualAmt;
        public static int EntryCount;


        /// <summary>
        /// 
        /// </summary>
        public static void Program_MongoDatabaseRead(string db_programName)
        {
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Program_FullFlow));
            try
            {
                var client = new MongoClient(ConfigurationManager.ConnectionStrings["MongoDB"].ToString());
                var database = client.GetDatabase(ConfigurationManager.AppSettings["MongoDbKey"].ToString());
                var collection = database.GetCollection<BsonDocument>("Program");
                ////var filter = Builders<BsonDocument>.Filter.Eq(.ProgramName, db_programName);
                ////var ProgramCreated = from Program in collection.AsQueryable().
                ////                     where Program["ProgramName"] == db_programName
                ////                     select Program;

                ////var ProgramCreated = collection.AsQueryable().ToList().Where Program["ProgramName"] == db_programName
                ////                     select Program;

                //var x = collection.AsQueryable().ToList();
                //var ProgramCreated = x.Where(z => z["ProgramName"] == (db_programName)).Select(y => y["ProgramName"].ToString());


                ////var ProgramCreated = collection.Find(Program["ProgramName"] == db_programName).ToList();
                ////select Program;

                //if (ProgramCreated.Any())
                //{
                //    Console.WriteLine(ProgramCreated + " program was created successfully, present in Mongo DB");
                //    Console.WriteLine(db_programName + " program was created successfully, present in Mongo DB");
                //}
                //else
                //{
                //    Console.WriteLine("Program was NOT created successfully, Not present in Mongo DB");

                //}

                var filter = Builders<BsonDocument>.Filter.Eq("ProgramName", db_programName);

                var list = collection.Find(filter).ToList();
                Assert.True(list.Count != 0);
           
                Console.WriteLine("Newly Created Program available in MangoDB");
          
            }
            catch (Exception ex)
            {
                Console.WriteLine("Program_MongoDatabaseRead failed due to: " + ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Program_DatabaseDataRead()
        {
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Program_FullFlow));
            try
            {
                string connection_db = ConfigurationManager.ConnectionStrings["BrandMuscleAutomation"].ConnectionString;
                SqlConnection connection_claim_db = new SqlConnection(connection_db);
                string claim_query = "select * from cfmaddnewprogramdata where AccrualType='"+db_accrualType+ "' order by indexaddnew desc";
                connection_claim_db.Open();
                SqlCommand claim_cmd = new SqlCommand(claim_query, connection_claim_db);
                using (SqlDataReader read = claim_cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        db_programName = read["PrgName"].ToString();
                        db_prgDesc = read["PrgDesc"].ToString();
                        db_strDate = read["StartDate"].ToString();
                        db_endDate = read["EndDate"].ToString();
                        db_currency = read["Currency"].ToString();
                        db_fundistributionhierarchy = read["FundDistributionHierarchy"].ToString();
                        db_claimflow = read["ClaimFlow"].ToString();
                        db_overdraft = read["Overdraft"].ToString();
                        db_requireBPA = read["RequireBPA"].ToString();
                        db_ecomEligible = read["EcomEligible"].ToString();
                        db_accrualType = read["AccrualType"].ToString();
                        db_accrualPeriod = read["AccrualPeriod"].ToString();
                        db_claimDate = read["ClaimDate"].ToString();
                        db_expDate = read["ExpiryDate"].ToString();
                        db_reimbursementType = read["ReimbursementType"].ToString();
                        db_reimbursementRate = read["ReimbursementRate"].ToString();
                        db_capping = read["CappingOption"].ToString();
                        db_cappingpercent = read["CappingPercent"].ToString();
                        db_activityOptions = read["ActivityOptions"].ToString();
                        db_accrualAmt = read["AccrualAmount"].ToString();
                        Console.WriteLine(db_programName + " | " + db_prgDesc + " | " + db_strDate + " | " + db_endDate + " | " + db_currency + " | " +
            db_fundistributionhierarchy + " | " + db_claimflow + " | " + db_overdraft + " | " + db_requireBPA + " | " + db_ecomEligible + " | " +
            db_accrualType + " | " + db_accrualPeriod + " | " + db_claimDate + " | " + db_expDate + " | " +
            db_reimbursementType + " | " + db_reimbursementRate + " | " + db_capping + " | " + db_cappingpercent + " | " + db_activityOptions + " | " +
            db_accrualAmt);
                    }
                }
                connection_claim_db.Close();
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
        public static void Program_DatabaseEntryCount()
        {
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Program_FullFlow));
            try
            {
                string connection_db = ConfigurationManager.ConnectionStrings["BrandMuscleAutomation"].ConnectionString;
                SqlConnection connection_claim_db = new SqlConnection(connection_db);
                string claim_query = "select count(*) COUNT from cfmaddnewprogramdata;";
                connection_claim_db.Open();
                SqlCommand claim_cmd = new SqlCommand(claim_query, connection_claim_db);
                using (SqlDataReader read = claim_cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        EntryCount = Convert.ToInt32(read["COUNT"].ToString());
                        Console.WriteLine("EntryCount: "+EntryCount);
                    }
                }
                connection_claim_db.Close();
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
        /// <param name="AccrualType"></param>
        public void ACE_Program_FullFlow(string AccrualType)
        {
            db_accrualType = AccrualType;
            string ProgramName = CommonFunctions.UniqueName("AutomationTest");
            Program_DatabaseDataRead();

            Program_ProgramDetails prg_ProgramDetails = new Program_ProgramDetails(Driver);
            prg_ProgramDetails.ACE_Program_ProgramDetails(ProgramName, db_prgDesc, db_currency);

            Program_ProgramsFlow prg_ProgramsFlow = new Program_ProgramsFlow(Driver);
            prg_ProgramsFlow.ACE_Program_Programs_Flow(db_overdraft, db_requireBPA, db_ecomEligible);

            Program_AccrualDetails prg_AccrualDetails = new Program_AccrualDetails(Driver);
            prg_AccrualDetails.ACE_Program_AccrualDetails(db_accrualType, db_accrualPeriod);

            Program_Reimbursement prg_Reimbursement = new Program_Reimbursement(Driver);
            prg_Reimbursement.ACE_Program_Reimbursement(db_reimbursementType, db_reimbursementRate, db_capping, db_cappingpercent, db_activityOptions);

            Program_Preview prg_Preview = new Program_Preview(Driver);
            prg_Preview.ACE_Program_Preview();
            
            Program_MongoDatabaseRead(ProgramName);
        }
    }
}
