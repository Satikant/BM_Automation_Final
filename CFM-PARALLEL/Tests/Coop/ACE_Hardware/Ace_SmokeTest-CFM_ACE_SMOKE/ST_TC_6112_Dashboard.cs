
using CFM_PARALLEL.Common;
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.UI.Ace.Dashboard;
using CFM_PARALLEL.StartUp;
using NUnit.Framework;
using System;
using System.Threading;

namespace CFM_PARALLEL.Tests.Ace_SmokeTest
{
   [TestFixture]
   [Parallelizable(ParallelScope.Fixtures)]
    public class ST_TC_6112_Dashboard:Base
    {

        [Test, Parallelizable]
        [Category("CFM_ACE_SMOKE")]
        public void ST_TC_6112_User_Dashboard()
        {
             
            try
            {
                //Base bs = new Base();
                
                //OpenBrowser()();
                //log4net.Config.XmlConfigurator.Configure();
                //ILog logger = LogManager.GetLogger(typeof(Dashboard_Landing));

                Console.WriteLine("Login in -------");
                BrowserURLLaunch b = new BrowserURLLaunch(Driver);
                BasicInteractions bi = new BasicInteractions(Driver);
                b.BrowserURL_ACE("CORPORATE1");
                Console.WriteLine("Login with CORPORATE");
                Dashboard_Landing d = new Dashboard_Landing();
                d.Dashboard_Landing_User();
                 
                 
                Thread.Sleep(10000);

                //Base bcc = new Base();
                
                //  OpenBrowser()();
                BrowserURLLaunch bc = new BrowserURLLaunch(Driver);
                bc.BrowserURL_ACE("LME1");
                Console.WriteLine("Login with LME");
                Dashboard_Landing dc = new Dashboard_Landing();
                dc.Dashboard_Landing_User();

                //Dashboard_Landing.Dashboard_Landing_User();
                 
                 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
            finally
            {
                 
            }
        }
    }
}