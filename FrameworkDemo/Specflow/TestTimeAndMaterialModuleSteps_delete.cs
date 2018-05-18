using FrameworkDemo.Global;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using TechTalk.SpecFlow;

namespace FrameworkDemo.Specflow
{
    [Binding]
    public class TestTimeAndMaterialModuleSteps_delete : Global.Base
    {
        [Given(@"user has logged into the system")]
        public void GivenUserHasLoggedIntoTheSystem()
        {
            Inititalize();
        }
        
        [When(@"user delete a record of ""(.*)""")]
        public void WhenUserDeleteARecordOf(string p0)
        {
            //Click on Admin tab
            GlobalDefinitions.DropListOption(GlobalDefinitions.driver, "ClassName", "dropdown-toggle");

            GlobalDefinitions.wait(500);
            //Click on T&M tab
            GlobalDefinitions.DropListOption(GlobalDefinitions.driver, "XPath", "//a[@href='/TimeMaterial']");

            GlobalDefinitions.wait(500);

            //1.Verify click on "OK" funcionality

            //get the code value of the first line
            string c_msg = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text;

            //Global.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "BeforeDelete");

            //Click on "Delete" of the first record
            GlobalDefinitions.ActionBtn(GlobalDefinitions.driver, "XPath", "//a[@class='k-button k-button-icontext k-grid-Delete']");

            GlobalDefinitions.wait(500);

            //Click on "Ok"

            IAlert alert = GlobalDefinitions.driver.SwitchTo().Alert();

            alert.Accept();

            GlobalDefinitions.wait(500);


            //verification
            //get code value after execution
            string c_msg1 = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text;


            if (c_msg1 == c_msg)
            {
                Console.WriteLine("Delete failed");
                test.Log(LogStatus.Fail, "Test Passed, Record not being deletedd");

            }
            else
            {
                Console.WriteLine("Delete done.");
                test.Log(LogStatus.Pass, "Test Passed, Record has been deleted successfully");

                //     Global.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "AfterDelete");
            }



            //2.Verify "Cancel" functionality

            //get the code value of the first line
            c_msg = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text;

            //Click on "Delete" of the first record
            // driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]")).Click();
            //btnDelete.Click();

            GlobalDefinitions.ActionBtn(GlobalDefinitions.driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]");

            GlobalDefinitions.wait(500); 

            // Click on "cancel"
            IAlert alert1 = GlobalDefinitions.driver.SwitchTo().Alert();
            alert1.Dismiss();

            //verification
            //get code value
            c_msg1 = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text;

            if (c_msg1 == c_msg)
            {
                Console.WriteLine("Cancel is working");
            }
            else
                Console.WriteLine("Cancel failed");
        }
    }
}

