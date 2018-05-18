using FrameworkDemo.Global;
using OpenQA.Selenium;
using System.Threading;

namespace FrameworkDemo.Pages
{
    internal class Login
    {
        //Create a Constructor
        public Login()
        {
         //   PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

     /*   //Define the UserName textBox
        [FindsBy(How = How.Id, Using = "UserName")]
        private IWebElement Username { set; get; }

        //Define the Password textBox
        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement Password { set; get; }

        //Define the Login Button
        [FindsBy(How = How.XPath, Using = "//*[@id='loginForm']/form/div[3]/input[1]")]
        private IWebElement LoginBtn { set; get; }
*/
        internal void LoginSteps()
        {

            //Start the Time and Material test
            Base.test = Base.extent.StartTest("Login System");

            //Populate in collection
            ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "LoginPage");

            //Navigate to Url
            GlobalDefinitions.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Url"));
            GlobalDefinitions.wait(500);
            
            //Maxmize the window
            GlobalDefinitions.driver.Manage().Window.Maximize();


            //Enter Username 
           // Username.SendKeys(ExcelLib.ReadData(2, "UserName"));
            GlobalDefinitions.TextBox(GlobalDefinitions.driver, "Id", "UserName", Global.ExcelLib.ReadData(2, "UserName"));

            //Enter Password 
            //Password.SendKeys(ExcelLib.ReadData(2, "Password"));
            GlobalDefinitions.TextBox(GlobalDefinitions.driver, "Id", "Password", Global.ExcelLib.ReadData(2, "Password"));
            //Click on login Button
            //LoginBtn.Click();
            GlobalDefinitions.ActionBtn(GlobalDefinitions.driver, "XPath", "//input[@type='submit']");

            Thread.Sleep(500);
            //Verification
            string message = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='addnewjob']")).Text;
            string ActualMessage = ExcelLib.ReadData(2, "ActualMsg");

            //Explicit Wait
            Thread.Sleep(500);

            //Verification           
            if (message == ActualMessage)
            {
                // Console.WriteLine("Login Successful");
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Login Successfully");
             //   Global.SaveScreenShotClass.SaveScreenshot(Global.GlobalDefinitions.driver, "HomePage");
            }
            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Login Unsuccessfully");
                //Console.WriteLine("Login Unsuccessful");
            }

        }
    }
}
