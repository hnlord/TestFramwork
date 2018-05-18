using AutoItX3Lib;
using FrameworkDemo.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;


namespace FrameworkDemo.Pages
{
    internal class TimeandMaterial
    {
        /*
        public TimeandMaterial()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }


        //Click on Adminstration tab
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/ul/li[5]/a")]
        private IWebElement Admin { get; set; }

        //Click on Time and Material Module
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")]
        private IWebElement TandM { get; set; }

        //Click on Create New Button
        [FindsBy(How = How.XPath, Using = "//*[@id='container']/p/a")]
        private IWebElement CreateBtn { get; set; }


        //Click on the dropdown button
        [FindsBy(How = How.XPath, Using = "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]")]
        private IWebElement dropdown { get; set; }


        //Select the value from the dropdown 
        [FindsBy(How = How.XPath, Using = "//*[@id='TypeCode_listbox']/li[2]")]
        private IWebElement dropdownvalue { get; set; }


        //Enter the Code
        [FindsBy(How = How.XPath, Using = "//*[@id='Code']")]
        private IWebElement Code { get; set; }

        //Enter the Description
        [FindsBy(How = How.XPath, Using = "//*[@id='Description']")]
        private IWebElement Description { get; set; }

        //Enter the Price
        [FindsBy(How = How.XPath, Using = "//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")]
        private IWebElement price { get; set; }

        //Click on Save Button
        [FindsBy(How = How.XPath, Using = "//*[@id='SaveButton']")]
        private IWebElement Save { get; set; }

    */
   

        internal void CreatingTM()
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


            //upload file               

            //   IWebElement upload = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='files']"));
            //   upload.SendKeys(@"C:\TestData\1.jpg");

            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[6]/div/div/div/div")).Click();
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            autoIt.Send(@"C:\TestData\1.jpg");
            Thread.Sleep(1000);
            autoIt.Send("{ENTER}");
            Thread.Sleep(1000);


            //Click on Save button
            GlobalDefinitions.ActionBtn(GlobalDefinitions.driver, "XPath", "//*[@id='SaveButton']");


            Thread.Sleep(1000);



            //Verification
            //Click on the last Page
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span")).Click();
            Thread.Sleep(1000);

            /*
            var element = GlobalDefinitions.driver.FindElement(By.XPath("//h1[contains(text(),'Execute Automation Selenium')]"));

            Assert.Multiple(() =>
            {
                Assert.That(element.Text, Is.Null, "Header text not found !!!");
                Assert.That(element.Text, Is.Not.Null, "Header text not found !!!");
            });
            */

            Assert.IsTrue(GlobalDefinitions.driver.PageSource.Contains("101"));


            //Check for the data
            int  rows = GlobalDefinitions.driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table//tr")).Count;
            
         //   Debug.Assert(rows < 0);

            int line = rows - 1;
            string s_xpath = "//*[@id='tmsGrid']/div[3]/table/tbody/tr["+ line.ToString() +"]/td[1]";
            string msg1 = GlobalDefinitions.driver.FindElement(By.XPath(s_xpath)).Text;

            string Actmsg = ExcelLib.ReadData(2, "ActualText");

            Thread.Sleep(2000);

            if (msg1 == Actmsg)
            {
                Thread.Sleep(200);
                // Console.WriteLine("Test passed, Record has been created");
                SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Add TM ");
                Base.test.Log(LogStatus.Pass, "Test Passed, Record has been created successfullsy");
            }

            else

            {
                Thread.Sleep(200);
                //Console.WriteLine("Test Failed, Record not created");
                Base.test.Log(LogStatus.Fail, "Test Failed, Record has not created");
            }

        }

        internal void EditTM()
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
          //  GlobalDefinitions.TextBoxClear(GlobalDefinitions.driver, "CSS", "#Price");
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

        internal void DeleteTM()
        {
            //Click on Admin tab
            GlobalDefinitions.DropListOption(GlobalDefinitions.driver, "ClassName", "dropdown-toggle");

            Thread.Sleep(500);
            //Click on T&M tab
            GlobalDefinitions.DropListOption(GlobalDefinitions.driver, "XPath", "//a[@href='/TimeMaterial']");

            Thread.Sleep(500);

            //1.Verify click on "OK" funcionality

            //get the code value of the first line
            string c_msg = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text;

            //Global.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "BeforeDelete");

            //Click on "Delete" of the first record
            GlobalDefinitions.ActionBtn(GlobalDefinitions.driver, "XPath", "//a[@class='k-button k-button-icontext k-grid-Delete']");
            
            Thread.Sleep(500);

            //Click on "Ok"

            IAlert alert = GlobalDefinitions.driver.SwitchTo().Alert();

            alert.Accept();

            Thread.Sleep(1000);
            

            //verification
            //get code value after execution
            string c_msg1 = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text;

            
            if (c_msg1 == c_msg)
            {
                Console.WriteLine("Delete failed");
                Base.test.Log(LogStatus.Fail, "Test Passed, Record not being deletedd");
                
            }
            else
            {
                Console.WriteLine("Delete done.");
                Base.test.Log(LogStatus.Pass, "Test Passed, Record has been deleted successfully");

                //     Global.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "AfterDelete");
            }



            //2.Verify "Cancel" functionality

            //get the code value of the first line
            c_msg = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text;

            //Click on "Delete" of the first record
            // driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]")).Click();
            //btnDelete.Click();

            GlobalDefinitions.ActionBtn(GlobalDefinitions.driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]");

            Thread.Sleep(1000);

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
