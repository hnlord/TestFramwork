using FrameworkDemo.Global;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace FrameworkDemo.Specflow
{
    [Binding]
    public class TestTimeAndMaterialModuleSteps_Edit :Global.Base

    {
        [Given(@"user have logged into the system successfully")]
        public void GivenUserHaveLoggedIntoTheSystemSuccessfully()
        {
            Inititalize();
        }
        
        [When(@"user edit a record of ""(.*)""")]
        public void WhenUserEditARecordOf(string p0)
        {
            ExcelLib.PopulateInCollection(Config.Resource.ExcelPath, "TandM");
            Thread.Sleep(1000);
            //Click on Admin tab
            GlobalDefinitions.DropListOption(GlobalDefinitions.driver, "ClassName", "dropdown-toggle");

            Thread.Sleep(500);
            //Click on T&M tab
            GlobalDefinitions.DropListOption(GlobalDefinitions.driver, "XPath", "//a[@href='/TimeMaterial']");

            Thread.Sleep(500);

            //Click on "Go to the first page" button
            //  GlobalDefinitions.ActionBtn(GlobalDefinitions.driver, "XPath", "//span[@class='k-icon k-i-seek-w']");
            //  SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "FirstPage");

            //Click on "Edit" of the first record 
            GlobalDefinitions.ActionBtn(GlobalDefinitions.driver, "XPath", "//a[@class='k-button k-button-icontext k-grid-Edit']");
            //   SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "EditPage");
            GlobalDefinitions.wait(1000);
            //Edit data in "Code" textbox
            string s_codev = ExcelLib.ReadData(2, "Code"); ;
            //  driver.FindElement(By.Id("Code")).Clear();
            // s_code.Clear();
            GlobalDefinitions.TextBoxClear(GlobalDefinitions.driver, "Id", "Code");
            GlobalDefinitions.TextBox(GlobalDefinitions.driver, "Id", "Code", s_codev);


            //Enter Description
            string s_description = ExcelLib.ReadData(2, "Description");
            GlobalDefinitions.TextBoxClear(GlobalDefinitions.driver, "Id", "Description");
            GlobalDefinitions.TextBox(GlobalDefinitions.driver, "Id", "Description", s_description);


            //Enter price
            string s_plricev = ExcelLib.ReadData(2, "Price");
          //  GlobalDefinitions.TextBoxClear(GlobalDefinitions.driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]");


            Thread.Sleep(1000);
            // GlobalDefinitions.TextBox(GlobalDefinitions.driver, "CSS", "#Price", s_plricev);
            GlobalDefinitions.TextBox(GlobalDefinitions.driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]", s_plricev);


            //Click on "Save" button

            // GlobalDefinitions.ActionBtn(GlobalDefinitions.driver, "XPath", "//*[@id='SaveButton']");
            GlobalDefinitions.ActionBtn(GlobalDefinitions.driver, "Id", "SaveButton");
            Thread.Sleep(1000);

            //validation
            //get code value
            string msg1 = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text;

            //get description value
            //string msg2 = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[3]")).Text;
            string Actmsg = ExcelLib.ReadData(2, "ActualText");
            if (msg1 == Actmsg)
            {
                Thread.Sleep(200);
                // Console.WriteLine("Test passed, Record has been created");
                Base.test.Log(LogStatus.Pass, "Test Passed, Record has been modified successfully");
                SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "EditSuccessful");
            }
            else
            {
                Thread.Sleep(200);
                //Console.WriteLine("Test Failed, Record not modified");
                Base.test.Log(LogStatus.Fail, "Test Failed, Record not being modified");
                SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "EditFail");
            }

        }

        [Then(@"system can close the browser")]
        public void ThenSystemCanCloseTheBrowser()
        {
            TearDown();
        }
    }
}
