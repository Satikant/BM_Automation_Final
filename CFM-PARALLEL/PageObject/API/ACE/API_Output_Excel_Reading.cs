using System;
using Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Collections;
using NUnit.Framework;

namespace CFM_PARALLEL.PageObject.API.Ace

{
    public class Api_OutputExcelReading
    {
        public static Workbook workbook;
        public static Application application;
        public static Worksheet sheet;
        public static Range range;
        public static string str;
        public static int i;
        public static string[] strarray;
        public static int j;
        public static int countfl = 0;
        public static int countnum = 0;

        public static void AceAPImethod(string filenameandpath, string sheetnames, int rownumber, int columnnum)
        {
            try
            {
                application = new Application();
                if (!System.IO.File.Exists("D:\\CFM-RunTimeFiles\\CFM-APIoutput\\ApiOutput.csv"))
                {
                    Console.WriteLine("Your jmx file did not run and Result Excel File doesn't exist.");
                    //return;
                }
                else
                {
                    workbook = application.Workbooks.Open(filenameandpath, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                    Sheets worksheet = workbook.Worksheets;
                    sheet = worksheet.Item[sheetnames];
                    string sheetnamepresent = sheet.Name;
                    range = sheet.UsedRange;
                    int rowcount = range.Rows.Count;
                    int columncount = range.Columns.Count;

                    for (int i = rownumber; i <= rowcount; i++)
                    {
                        string pd = (range.Cells[i, columnnum].Value2);
                        char[] splitchar = { ',' };
                        strarray = pd.Split(splitchar);

                        if (Convert.ToString(strarray[7]).ToUpper() != "TRUE")
                        {
                            countfl++;
                        }
                    }
                    Console.WriteLine(countfl + " API Methods failed " + "\n");
                    for (int i = rownumber; i <= rowcount; i++)
                    {
                        string pd = (range.Cells[i, columnnum].Value2);
                        char[] splitchar = { ',' };
                        strarray = pd.Split(splitchar);

                        if (Convert.ToString(strarray[6]).ToUpper() != "TRUE")
                        {
                            string rplc = Convert.ToString(strarray[5]);
                            rplc = Regex.Replace(rplc, @"[0-9\-\ ]", string.Empty);
                            ArrayList psl = new ArrayList();
                            psl.Add(rplc);
                            foreach (string addvalues in psl)
                            {
                                countnum++;
                                Console.WriteLine(countnum + ") " + addvalues + " --method is Failed and the Response status code is " + Convert.ToString(strarray[3]) + "\n");
                            }
                        }
                    }
                }
                throw new Exception();
            }
            catch (Exception )
            {
                //Console.WriteLine(e);
                //throw e;
            }
            if (countfl >= 1)
            {
                Assert.Fail();
            }
            workbook.Close(true, null, null);
            application.Quit();
        }

    }
}