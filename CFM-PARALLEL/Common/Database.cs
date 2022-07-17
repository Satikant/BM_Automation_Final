using MongoDB.Bson;
using MongoDB.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CFM_PARALLEL.Common
{
    public class Database
    {
        private IWebDriver Driver;

        public Database(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }

        public void VerifyProgramCreationOnMangoDB(string db_programName)
        {
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(Program_FullFlow));
            try
            {
                var client = new MongoClient(ConfigurationManager.ConnectionStrings["MongoDB"].ToString());
                var database = client.GetDatabase(ConfigurationManager.AppSettings["MongoDbKey"].ToString());
                var collection = database.GetCollection<BsonDocument>("Program");
                var filter = Builders<BsonDocument>.Filter.Eq("ProgramName", db_programName);

                var list = collection.Find(filter).ToList();
                Assert.True(list.Count != 0);

                Console.WriteLine("Newly Created Program available in MangoDB");

            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);       Driver.Quit();
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }

        public void VerifyingBPACreationMangoDB(string BPA_ID)
        {
           
            try
            {
                var client = new MongoClient(ConfigurationManager.ConnectionStrings["MongoDB"].ToString());
                var dataBrowserURLLaunch = client.GetDatabase(ConfigurationManager.AppSettings["MongoDbKey"].ToString());
                var collection = dataBrowserURLLaunch.GetCollection<BsonDocument>("BrandingRequest");

                Thread.Sleep(10000);
                var filter = Builders<BsonDocument>.Filter.Eq("BrandingRequestId", Convert.ToInt64(BPA_ID.Substring(4)));
                Thread.Sleep(5000);

                var list = collection.Find(filter).ToList();
                Assert.True(list.Count != 0);
                Console.WriteLine("Newly Created BPA available in MangoDB");
            }
            catch (Exception ex)
            {
                CommonUtilities.Logout(Driver);       Driver.Quit();
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }

    }
}
