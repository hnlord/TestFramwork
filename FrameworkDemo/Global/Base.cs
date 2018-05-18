using FrameworkDemo.Config;
using FrameworkDemo.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;

namespace FrameworkDemo.Global
{

    public class Base
    {
        #region To access Path from resource file
        public static int Browser = Int32.Parse(Resource.Browser);
        public static string ExcelPath = Resource.ExcelPath;
        public static string ScreenshotPath = Resource.ScreenshotPath;
        public static string ReportPath = Resource.ReportPath;
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        
        #endregion


        #region Setup
        [SetUp]
        public void Inititalize()
        {
            
            #region initialise Report

            //Initialise Report
            extent = new ExtentReports(Base.ReportPath, false, DisplayOrder.NewestFirst);
            //Load report cofig file
            extent.LoadConfig(Resource.ReportXMLPath);

            #endregion
            // advisasble to read this documentation before proceeding http://extentreports.relevantcodes.com/net/
            switch (Browser)
            {
                case 1:
                    GlobalDefinitions.driver = new FirefoxDriver();
                    break;
                case 2:
                    GlobalDefinitions.driver = new ChromeDriver();
                    break;

            }

           

            //Creating object for Login class to access Loginstep method
            if (Resource.IsLogin == "true")
            {
                Login loginobj = new Login();
                loginobj.LoginSteps();
            }

            else
            {
                Registration regobj = new Registration();
                regobj.Regsteps();
            }

        }
        #endregion

        #region TearDown
        [TearDown]
        public void TearDown()
        {
            test.Log(LogStatus.Info, "TD");
            // Screenshot
            String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Report");

            //end test. (Reports)
            extent.EndTest(test);

            // calling Flush writes everything to the log file (Reports)
            extent.Flush();

            // Close the driver :           
          //  GlobalDefinitions.driver.Close();
            GlobalDefinitions.driver.Quit();
        }
        #endregion
    }
}

