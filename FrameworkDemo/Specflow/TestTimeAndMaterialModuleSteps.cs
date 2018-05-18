using FrameworkDemo.Global;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace FrameworkDemo.Specflow
{
    [Binding]
    public class TestTimeAndMaterialModuleSteps : Global.Base
    {
        [Given(@"I have logged into the system successfully")]
        public void GivenIHaveLoggedIntoTheSystemSuccessfully()
        {
            Inititalize();
        }
        
        [When(@"I add a Time and Material")]
        public void WhenIAddATimeAndMaterial()
        {
            ExcelLib.PopulateInCollection(Config.Resource.ExcelPath, "TandM");
            Thread.Sleep(1000);
            //Click on Admin tab
            GlobalDefinitions.DropListOption(GlobalDefinitions.driver, "ClassName", "dropdown-toggle");

            Thread.Sleep(500);
            //Click on T&M tab
            GlobalDefinitions.DropListOption(GlobalDefinitions.driver, "XPath", "//a[@href='/TimeMaterial']");

            Thread.Sleep(500);

            //Click on Create New Button
            GlobalDefinitions.ActionBtn(GlobalDefinitions.driver, "XPath", "//a[@href='/TimeMaterial/Create']");
            Thread.Sleep(500);

            //Click on Dropdown
            GlobalDefinitions.DropList(GlobalDefinitions.driver, "XPath", "//span[@class='k-input']");

            Thread.Sleep(1000);

            //Select the value from dropdown
            //Select "Time" option

            string m_Xpath = "//ul[@class='k-list k-reset']/li[1]";
            string t_Xpath = "//ul[@class='k-list k-reset']/li[2]";

            GlobalDefinitions.DropListOption(GlobalDefinitions.driver, "XPath", t_Xpath);


            //Enter Code
            string s_codev = ExcelLib.ReadData(2, "Code");
            GlobalDefinitions.TextBox(GlobalDefinitions.driver, "Id", "Code", s_codev);


            //Enter Description
            string s_description = ExcelLib.ReadData(2, "Description");
            GlobalDefinitions.TextBox(GlobalDefinitions.driver, "Id", "Description", s_description);


            //Enter price
            string s_plricev = ExcelLib.ReadData(2, "Price");
            GlobalDefinitions.TextBox(GlobalDefinitions.driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]", s_plricev);
            Thread.Sleep(1000);

            //Click on Save button
            GlobalDefinitions.ActionBtn(GlobalDefinitions.driver, "XPath", "//*[@id='SaveButton']");


            Thread.Sleep(1000);



            //Verification
            //Click on the last Page
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span")).Click();



            //Check for the data
            string msg1 = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text;
            string Actmsg = ExcelLib.ReadData(2, "ActualText");

            Thread.Sleep(2000);

            if (msg1 == Actmsg)
            {
                Thread.Sleep(200);
                // Console.WriteLine("Test passed, Record has been created");
                Base.test.Log(LogStatus.Pass, "Test Passed, Record has been created successfully");
            }

            else

            {
                Thread.Sleep(200);
                //Console.WriteLine("Test Failed, Record not created");
                Base.test.Log(LogStatus.Fail, "Test Failed, Record has not created");
            }
        }
        
        [Then(@"close the browser")]
        public void ThenCloseTheBrowser()
        {

            TearDown();


        }
    }
}
