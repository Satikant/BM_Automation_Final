using CFM_PARALLEL.Common;
using CFM_PARALLEL.PageObject.PageFactory;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace CFM_PARALLEL.StartUp
{
    //[TestFixture]
    public class Base
    {

        public string CurrentWindow { get; set; }

        public static string BaseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string screenshotFolder = BaseDir + "\\Screenshots";

        public static IWebDriver Driver = null;

        [SetUp] // will run before each test case
        public void Initialize()
        {
            Console.WriteLine("Inside Initialize method. Initializing the driver ");
            Console.WriteLine("");
            Driver_SetUp(); // Get the driver
            Console.WriteLine("Driver Initialized succesfully");
            Console.WriteLine("");

        }

        [TearDown] // Will run at the end of each test case
        public void CleanUp()
        {
            Console.WriteLine("Inside CleanUp method. Tearing Down the driver ");
            Console.WriteLine("");
            Driver_CleanUp(); // Driver Quit
            Console.WriteLine("Driver CleanUp successful.");
            Console.WriteLine("");
        }

        public IWebDriver Driver_SetUp() {
            if (Driver == null)
                Driver = OpenBrowser();
            return Driver;
        }

        //Close the Driver if its NOT closed yet
        public void Driver_CleanUp()
        {
            if (!Driver.Equals(null))
            {
                Pages.TearDownPages();
                CommonUtilities.Logout(Driver);
                Driver.Quit();
                Driver = null;
            }
        }

        //Initialize Browser Driver depending upon input in WebConfig file and return the same
        public IWebDriver OpenBrowser()
        {
            string browser = ConfigurationManager.AppSettings["BrowserPreferred"].ToString().Trim();
           // string browser = "Firefox";
            switch (browser)
            {
                case "Chrome":
                    Driver = LaunchPersonalizedChrome();
                    break;
                case "Firefox":
                    Driver = LaunchPersonalizedFirefox();
                    break;
                case "InternetExplorer":
                    Driver = LaunchPersonalizedIE();
                    break;
                case "Edge":
                    Driver = LaunchPersonalizedEdge();
                    break;
                case "Safari":
                    Driver = LaunchPersonalizedSafari();
                    break;
                default:
                    Driver = LaunchPersonalizedChrome();
                    break;
            }
            CurrentWindow = Driver.CurrentWindowHandle;
            return Driver;
        }

        #region Personalized Browser Setup

        //Lanches Chrome with personalized options
        public IWebDriver LaunchPersonalizedChrome()
        {
            try
            {
                IWebDriver Driver = null;
                string downloadDirectory = BaseDir + "\\Download";
                string driverPath = BaseDir + "\\Assets";
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);
                chromeOptions.AddArguments("disable-infobars");
                //chromeOptions.AddArguments("--headless", "window-size=1920,1080", "--no-sandbox");
                chromeOptions.AddArguments("--start-maximized");
                chromeOptions.AddArgument("--disable-gpu");                           
                Driver = new ChromeDriver(driverPath, chromeOptions);
                return Driver;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Inside personalizedChrome Catch. Error: " + ex.Message);
                return null;
            }
        }

        //Lanches Firefox with personalized options
        public IWebDriver LaunchPersonalizedFirefox()
        {
            IWebDriver Driver = null;
            var co = new FirefoxOptions();
            //co.AddArgument("--headless");
            co.AddArgument("--window-size=1920,1080");
            //co.AddArgument("--window-size=800,500");
            // co.AddArgument("headless");
            co.AddArgument("--disable-gpu");
            co.AddArgument("--no-sandbox");
            co.AddArguments("--start-maximized");

            //co.AcceptInsecureCertificates = true;
            //co.PageLoadStrategy = PageLoadStrategy.Normal;
            //dir = Path.GetDirectoryName(typeof(Base).Assembly.Location);

            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            service.FirefoxBinaryPath = BaseDir + @"\Assets";
            Console.WriteLine(service.FirefoxBinaryPath);
            Driver = new FirefoxDriver(co);
            Driver.Manage().Window.Maximize();
            return Driver;
        }

        //Lanches Internet Explorer with personalized options
        public IWebDriver LaunchPersonalizedIE()
        {
            IWebDriver Driver = null;
            string driverPath = BaseDir + "\\Assets";
            Driver = new InternetExplorerDriver(driverPath);
            return Driver;
        }

        //Lanches Edge browser with personalized options
        public IWebDriver LaunchPersonalizedEdge()
        {
            IWebDriver Driver = null;
            string driverPath = BaseDir + "\\Assets";
            Driver = new EdgeDriver(driverPath);
            return Driver;
        }

        //Lanches Safari with personalized options
        public IWebDriver LaunchPersonalizedSafari()
        {
            IWebDriver Driver = null;
            return Driver;
        }

        #endregion

        ////gets the Environment name in which test nedds to be executed. Value is fetched from WebConfig file
        //public static string GetEnvName()
        //{
        //    return ReadDataFromWebConfig("ENVIRONMENT");
        //}

        ////Get UserName from WebConfig file
        //public static string GetUsername()
        //{
        //    return ReadDataFromWebConfig("LOGINUSER");
        //}

        ////Get Password From WebConfig file
        //public static string GetPassword()
        //{
        //    return ReadDataFromWebConfig("LOGINPSWD");
        //}

        //Read data from WebConfig file using Key
        static string ReadDataFromWebConfig(string key)
        {
            try
            {
                string value = ConfigurationManager.AppSettings[key].ToString().Trim();
                //Other way of fetching value
                //var appSettings = ConfigurationManager.AppSettings;
                //string value = appSettings[key].Trim();

                return value;
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error while reading app settings from WebConfig file");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw new Exception("KeyNOTPresentInConfigFile");
            }
        }
    }
}