using Excel;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace FrameworkDemo.Global
{
    class GlobalDefinitions
    {
        //Initialise the Driver
        public static IWebDriver driver { set; get; }

        //Implicit Wait
        #region WaitforElement 

        public static void wait(int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);

        }

        #endregion

        //Text Box set value
        public static void TextBox(IWebDriver driver, string Locator, string LocatorValue, string TextValue)
        {
            if (Locator == "Id")
                driver.FindElement(By.Id(LocatorValue)).SendKeys(TextValue);
            else if (Locator == "XPath")
                driver.FindElement(By.XPath(LocatorValue)).SendKeys(TextValue);
            else if (Locator == "CSS")
                driver.FindElement(By.CssSelector(LocatorValue)).SendKeys(TextValue);
            else if (Locator == "ClassName")
                driver.FindElement(By.ClassName(LocatorValue)).SendKeys(TextValue);

        }

        //numerictextbox Text Box set value
        public static void NumerictextboxSetvalue(IWebDriver driver, string Locator, string LocatorValue, string TextValue)
        {
            if (Locator == "Id")
                driver.FindElement(By.Id(LocatorValue)).SendKeys(TextValue);
            else if (Locator == "XPath")
                driver.FindElement(By.XPath(LocatorValue)).SendKeys(TextValue);
            else if (Locator == "CSS")
                driver.FindElement(By.CssSelector(LocatorValue)).SendKeys(TextValue);
            else if (Locator == "ClassName")
                driver.FindElement(By.ClassName(LocatorValue)).SendKeys(TextValue);

        }


        //Text Box get value
        public static string TextBoxGetValue(IWebDriver driver, string Locator, string LocatorValue)
        {
            if (Locator == "Id")
                return driver.FindElement(By.Id(LocatorValue)).Text;
            else if (Locator == "XPath")
                return driver.FindElement(By.XPath(LocatorValue)).Text;
            else if (Locator == "CSS")
                return driver.FindElement(By.CssSelector(LocatorValue)).Text;
            else if (Locator == "ClassName")
                return driver.FindElement(By.ClassName(LocatorValue)).Text;
            else
                return "";

        }

        //Text Box Clear
        public static void TextBoxClear(IWebDriver driver, string Locator, string LocatorValue)
        {
            if (Locator == "Id")
                driver.FindElement(By.Id(LocatorValue)).Clear();
            else if (Locator == "XPath")
                driver.FindElement(By.XPath(LocatorValue)).Clear();
            else if (Locator == "CSS")
                driver.FindElement(By.CssSelector(LocatorValue)).Clear();
            else if (Locator == "ClassName")
                driver.FindElement(By.ClassName(LocatorValue)).Clear();

        }

        //ActionButton
        public static void ActionBtn(IWebDriver driver, string Locator, string LocatorValue)
        {
            if (Locator == "Id")
                driver.FindElement(By.Id(LocatorValue)).Click();
            else if (Locator == "XPath")
                driver.FindElement(By.XPath(LocatorValue)).Click();
            else if (Locator == "CSS")
                driver.FindElement(By.CssSelector(LocatorValue)).Click();
            else if (Locator == "ClassName")
                driver.FindElement(By.ClassName(LocatorValue)).Click();
            
        }

        //DropList
        public static void DropList(IWebDriver driver, string Locator, string LocatorValue)
        {
            if (Locator == "Id")
                driver.FindElement(By.Id(LocatorValue)).Click();
            else if (Locator == "XPath")
                driver.FindElement(By.XPath(LocatorValue)).Click();
            else if (Locator == "CSS")
                driver.FindElement(By.CssSelector(LocatorValue)).Click();
            else if (Locator == "ClassName")
                driver.FindElement(By.ClassName(LocatorValue)).Click();
        }

        //DropListOption
        public static void DropListOption(IWebDriver driver, string Locator, string LocatorValue)
        {
            if (Locator == "Id")
                driver.FindElement(By.Id(LocatorValue)).Click();
            else if (Locator == "XPath")
                driver.FindElement(By.XPath(LocatorValue)).Click();
            else if (Locator == "CSS")
                driver.FindElement(By.CssSelector(LocatorValue)).Click();
            else if (Locator == "ClassName")
                driver.FindElement(By.ClassName(LocatorValue)).Click();
        }
    }

    #region screenshots
    public class SaveScreenShotClass
    {
        public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
        {
            //var folderLocation = (Global.Base.ScreenshotPath);
            var folderLocation = (Config.Resource.ScreenshotPath);

            if (!System.IO.Directory.Exists(folderLocation))
            {
                System.IO.Directory.CreateDirectory(folderLocation);
            }

            var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            var fileName = new StringBuilder(folderLocation);

            fileName.Append(ScreenShotFileName);
            fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
            //fileName.Append(DateTime.Now.ToString("dd-mm-yyyym_ss"));
            fileName.Append(".jpeg");
            screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Jpeg);
            return fileName.ToString();
        }
    }
    #endregion

    #region Excel 
    public class ExcelLib
    {
        static List<Datacollection> dataCol = new List<Datacollection>();

        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }
        }


        public static void ClearData()
        {
            dataCol.Clear();
        }


        private static DataTable ExcelToDataTable(string fileName, string SheetName)
        {
            // Open file and return as Stream
            using (System.IO.FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                {
                    excelReader.IsFirstRowAsColumnNames = true;

                    //Return as dataset
                    DataSet result = excelReader.AsDataSet();
                    //Get all the tables
                    DataTableCollection table = result.Tables;

                    // store it in data table
                    DataTable resultTable = table[SheetName];

                    //excelReader.Dispose();
                    //excelReader.Close();
                    // return
                    return resultTable;
                }
            }
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations

                rowNumber = rowNumber - 1;
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;


                return data.ToString();
            }

            catch (Exception e)
            {
                //Added by Kumar
                Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine + e.Message.ToString());
                return null;
            }
        }

        public static void PopulateInCollection(string fileName, string SheetName)
        {
            ExcelLib.ClearData();
            DataTable table = ExcelToDataTable(fileName, SheetName);

            //Iterate through the rows and columns of the Table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };


                    //Add all the details for each row
                    dataCol.Add(dtTable);

                }
            }

        }
    }

    #endregion

}
