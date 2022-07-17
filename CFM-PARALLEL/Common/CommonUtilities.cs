
using CFM_PARALLEL.Interactions_New;
using CFM_PARALLEL.PageObject.PageFactory;
using CFM_PARALLEL.PageObject.UI.ObjectRepository.CommonObjects;
using CFM_PARALLEL.StartUp;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFM_PARALLEL.Common
{
   public static class CommonUtilities
    {
        /// <summary>
        /// Method to capture screenshot
        /// </summary>
        /// <param name="PartialPath">Name to be appended for screenshot</param>
        //public static void Screenshot(string directory, string PartialPath)
        //{
        //    //Console.WriteLine("Inside Screenshot method!");
        //    ITakesScreenshot ScreenshotDriverCollapse = Driver as ITakesScreenshot;
        //    Screenshot ScreenshotCollapse = ScreenshotDriverCollapse.GetScreenshot();
        //    String ScreenshotPathCollapse = @"D:\ForAutomation\Screenshot\CFM" + PartialPath + "_" + DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt") + ".png";
        //    ScreenshotCollapse.SaveAsFile(ScreenshotPathCollapse, ScreenshotImageFormat.Png);
        //}

        /// <summary>
        /// Method to update status of the executed method to the dataBrowserURLLaunch
        /// </summary>
        /// <param name="MethodName"></param>
        /// <param name="MethodExecutionStatus"></param>
        public static void MethodExecutionStatusToDataBrowserURLLaunch(string Project, string MethodName, string MethodExecutionStatus)
        {
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = log4net.LogManager.GetLogger(typeof(CommonUtilities));
            try
            {
                SqlConnection Connection;
                SqlCommand Command;

                string connstring = "server=bmi-azdb001.dataBrowserURLLaunch.windows.net;dataBrowserURLLaunch=brandmuscleautomation;user=brandmuscle;password=N0tS3arstower";
                Connection = new SqlConnection(connstring);
                Connection.Open();
                //string Query = "update indexrecord set Flag = @MethodExecutionStatus where method = @MethodName and project = @Project";
                Command = new SqlCommand("update indexrecord set Flag = '" + MethodExecutionStatus + "' where Method='" + MethodName + "'and Project='" + Project + "'", Connection);
                //Command.Parameters.AddWithValue(@);
                Command.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("DataBrowserURLLaunch connection in MethodExecutionStatusToDataBrowserURLLaunch() failed due to: " + e);
            }
        }

        /// <summary>
        /// Method return the data fetched from BrandmuscleAutomation dataBrowserURLLaunch
        /// </summary>
        /// <param name="query">query to be executed in the BrandmuscleAutomation dataBrowserURLLaunch</param>
        /// <returns>the results fetched from the BrandmuscleAutomation dataBrowserURLLaunch after executing the query</returns>
        public static SqlDataReader MethodDataBrowserURLLaunchConnectionSQLQuery(string query)
        {
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(CommonUtilities));
            SqlConnection Connection = null;
            SqlCommand Command;
            SqlDataReader read = null;
            try
            {
                string connstring = "server=bmi-azdb001.dataBrowserURLLaunch.windows.net;dataBrowserURLLaunch=brandmuscleautomation;user=brandmuscle;password=N0tS3arstower";
                Connection = new SqlConnection(connstring);
                Connection.Open();
                Command = new SqlCommand(query, Connection);
                read = Command.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine("DataBrowserURLLaunch connection in MethodDataBrowserURLLaunchConnectionSQLQuery() failed due to: " + e);
            }
            return read;
#pragma warning disable CS0162 // Unreachable code detected
            Connection.Close();
#pragma warning restore CS0162 // Unreachable code detected
        }

        /// <summary>
        /// Method return the data fetched from ChannelBuilderQADev dataBrowserURLLaunch
        /// </summary>
        /// <param name="query">query to be executed in the ChannelBuilderQADev dataBrowserURLLaunch</param>
        /// <returns>the results fetched from the ChannelBuilderQADev dataBrowserURLLaunch after executing the query</returns>
        public static SqlDataReader MethodQADevDataBrowserURLLaunchConnectionSQLQuery(string query)
        {
            //log4net.Config.XmlConfigurator.Configure();
            //ILog logger = LogManager.GetLogger(typeof(CommonUtilities));
            SqlConnection Connection = null;
            SqlCommand Command;
            SqlDataReader read = null;
            try
            {
                string connstring = "server=bmi-azdb002.dataBrowserURLLaunch.windows.net;dataBrowserURLLaunch=ChannelBuilderQaDev;user=ChannelBuilder;password=mSUePJraar$";
                Connection = new SqlConnection(connstring);
                Connection.Open();
                Command = new SqlCommand(query, Connection);
                read = Command.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine("DataBrowserURLLaunch connection in MethodQADevDataBrowserURLLaunchConnectionSQLQuery() failed due to: " + e);
            }
            return read;
#pragma warning disable CS0162 // Unreachable code detected
            Connection.Close();
#pragma warning restore CS0162 // Unreachable code detected
        }

        //Upload file using AutoItExe
        public static void UploadFileInChrome(string fileName)
        {
            try
            {
                Thread.Sleep(10000);
                string filePath = CommonUtilities.Returndynamicpath() + @"\DeploymentItems\" + fileName;
               // string filePath = Path.GetFullPath(@"DeploymentItems") + "\\" + fileName;
                string otherParametersVar = '"' + filePath + '"';
                Process process = new System.Diagnostics.Process();
                string path = Path.GetFullPath(@"Assets") + "\\UploadFileInChrome.exe";
                process.StartInfo.FileName = path;
                process.StartInfo.Arguments = @otherParametersVar;
                process.Start();
                Thread.Sleep(10000);
                //Wait.WaitTime(10);
                //Kill the process if it is still active
                if (!process.HasExited)
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UploadFileInChrome: " + ex);
            }
        }

        

        public static void UploadFile(By WebElementLocator, string fileName)
        {

            try
            {
                string filePath = CommonUtilities.Returndynamicpath() + @"\DeploymentItems\" + fileName;
                Pages.BasicInteractions().Type(WebElementLocator, filePath);


            }
            catch (Exception ex)
            {
                Console.WriteLine("UploadFileInChrome: " + ex);
            }
        }

        //Upload file in Chrome using AutoIt
        public static void UploadFileInChromeUsingAutoIT(string fileName)
        {
            OpenQA.Selenium.IWebDriver Driver = null;
            BasicInteractions bi = new BasicInteractions(Driver);

            string filePath = CommonUtilities.Returndynamicpath() + @"\DeploymentItems\" + fileName;
            // string filePath = Path.GetFullPath(@"DeploymentItems") + "\\" + fileName;
            filePath = '"' + filePath + '"';
            Console.WriteLine("path is" + filePath);
            //AutoItX3 autoIt = new AutoItX3();
            //below code is for chrome;

           // AutoItX.WinActivate("Open");//this will activate the window
            //Thread.Sleep(1000);
            //AutoItX.Send(@filePath);
           // Thread.Sleep(1000);
           // AutoItX.Send("{ENTER}");
           // bi.WaitTime(12);

         
            
            //AutoItX3 autoIt = new AutoItX3();
            //// autoIt.WinActivate("Open");
            //autoIt.ControlFocus("Open", "", "");
            //autoIt.ControlSetText("Open", "", "Edit1", @filePath);
            //autoIt.ControlClick("Open", "", "Button1");
        }
        public static string Returndynamicpath()
        {
            var dir = Path.GetDirectoryName(typeof(Base).Assembly.Location);
            Environment.CurrentDirectory = dir;
            string path = dir;
            Console.WriteLine(path);
            return path;
        }
        public static int GetFreeTcpPort()
        {
            Thread.Sleep(100);
            var tcpListener = new TcpListener(IPAddress.Loopback, 0);
            tcpListener.Start();
            int port = ((IPEndPoint)tcpListener.LocalEndpoint).Port;
            tcpListener.Stop();
            return port;
        }

        public static string RandomInvoice(string str)
        {
            Random r = new Random();
            string Invoice = r.Next(100000).ToString();
            return str+Invoice;
        }

        public static void Logout(IWebDriver Driver)
        {
            BasicInteractions bi = new BasicInteractions(Driver);
            OBJ_Common obj_common = new OBJ_Common();
            if (bi.IsElementVisible(obj_common.V5CFMLogout))
            {
                bi.ClickJavaScript(obj_common.V5CFMLogout);
                bi.WaitForPageToLoad(120);
                bi.WaitTime(10);
            }
        }
    }
}
