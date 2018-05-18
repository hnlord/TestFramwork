using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FrameworkDemo.Global
{
    internal class Registration
    {
        public Registration()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }


        //Initialize or finding the elements

        //Finding the firstname textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='FirstName']")]
        private IWebElement Firstname { get; set; }

        //Finding the Lastname textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='LastName']")]
        private IWebElement Lastname { get; set; }

        //Finding Username textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='UserName']")]
        private IWebElement Username { get; set; }

        //Finding password field
        [FindsBy(How = How.XPath, Using = "//*[@id='Password']")]
        private IWebElement Password { get; set; }

        //Finding confirm Password field
        [FindsBy(How = How.XPath, Using = "//*[@id='ConfirmPassword']")]
        private IWebElement ConfirmPswd { get; set; }

        //Finding Company Name textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='CompanyName']")]
        private IWebElement CompanyName { get; set; }

        //Finding Create Button
        [FindsBy(How = How.XPath, Using = "//*[@id='container']/form/div/div[7]/div/input")]
        private IWebElement Create { get; set; }


        internal void Regsteps()
        {
            //Start the Add address test
            Base.test = Base.extent.StartTest("User Registration");

            //Populating the Excel sheet
            ExcelLib.PopulateInCollection(Config.Resource.ExcelPath, "Registration");
            GlobalDefinitions.wait(500);

            //Navigate to the Url
            GlobalDefinitions.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Url"));
            GlobalDefinitions.wait(500);

            //Enter Firstname
            Firstname.SendKeys(ExcelLib.ReadData(2, "FirstName"));
            GlobalDefinitions.wait(500);

            //Enter lastname
            Lastname.SendKeys(ExcelLib.ReadData(2, "LastName"));
            GlobalDefinitions.wait(500);

            //Enter the Username
            Username.SendKeys(ExcelLib.ReadData(2, "UserName"));
            GlobalDefinitions.wait(500);

            //Enter the password
            Password.SendKeys(ExcelLib.ReadData(2, "Password"));
            GlobalDefinitions.wait(500);

            //Enter the confirm password
            ConfirmPswd.SendKeys(ExcelLib.ReadData(2, "ConfirmPswd"));
            GlobalDefinitions.wait(500);

            //Enter the Company Name
            CompanyName.SendKeys(ExcelLib.ReadData(2, "CompanyName"));
            GlobalDefinitions.wait(500);

            //Click on Create button
            Create.Click();
            GlobalDefinitions.wait(500);

            //Screenshot
            Global.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "RegistrationPage");

            //Reports
            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Registration successfull");


        }
    }
}
