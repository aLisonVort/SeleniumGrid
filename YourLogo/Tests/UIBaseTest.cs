using AventStack.ExtentReports.Model;
using YourLogo.Tests.Configurations;
using YourLogo.Tests.Framework;
using YourLogo.Tests.Framework.Browser;
using YourLogo.Tests.TestsInfo;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLogo.Tests.Utils;
using AventStack.ExtentReports;
using YourLogo.Tests.UI;

namespace YourLogo.Tests.Tests
{
    [SetUpFixture]
    public class UIBaseTest : ExtentReport
    {
        // public IWebDriver driver;

        //  protected Logger logger;
        //protected Reporter report;

        private TestConfigModel model;
        //  private Browser browser;

        [OneTimeSetUp]
        public virtual void OneTimeSetup()
        {
            //report = new Reporter();
            //report.CreateReport();
            SetConfigData();
            browser = new Browser(model.Browser);
            driver = browser.GetWebDriver();
            StandardOneTimeSetup();
            ExtendedOneTimeSetUp();

        }

        [SetUp]

        public virtual void SetUp()
        {
            StandardSetUp();
            ExtendedSetUp();
        }


        [TearDown]
        public void TearDown()
        {
            StandartTearDown();
            ExtendedTearDown();
        }

        //[OneTimeTearDown]

        //public void OneTimeTearDown()
        //{
        //    ExtendedOneTimeTearDown();
        //    StandardOneTimeTearDown(driver);

        //}
        public void StandardSetUp()
        {
            //ExtentReport report = new ExtentReport();
            test = ExtentReport.extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        public virtual void ExtendedSetUp()
        {

        }
        public void StandardOneTimeSetup()
        {
            // CreateReporter()
            SetLogger();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public virtual void ExtendedOneTimeSetUp()
        {
        }

        public void StandartTearDown()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = TestContext.CurrentContext.Result.StackTrace;
                var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";
                switch (status)
                {
                    case TestStatus.Failed:
                        test.Log(Status.Fail, $"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                        test.AddScreenCaptureFromBase64String(browser.GetWebDriver().CaptureScreen(), "Screenshot on Error:");
                        break;
                    case TestStatus.Skipped:
                        test.Skip("Test skipped!");
                        break;
                    default:
                        test.Pass("Test Executed Sucessfully");
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                //  browser.GetWebDriver().Close();
            }
            logger.GetTestName();
            logger.AfterTest();
        }
        public virtual void ExtendedTearDown() { }

        public void StandardOneTimeTearDown(IWebDriver driver)
        {
            // test.Close();
            EndTests(driver);
        }

        public virtual void ExtendedOneTimeTearDown() { }
        public void SetDriverInstance(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void EndTests(IWebDriver driver)
        {
            try
            {
                driver.Quit();
            }
            catch (System.Exception e)
            {
                logger.LogInfo(e.Message);
            }
        }

        //private UIBaseTest CreateReporter()
        //{
        //    report = new Reporter();
        //    report.CreateReport();
        //    return this;
        //}
        private UIBaseTest SetLogger()
        {
            logger = new Logger();
            logger.Initialize();
            return this;
        }
        private void SetConfigData()
        {
            try
            {
                //var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory).Replace(@"\bin\Debug", @"\Configurations\TestConfig.json");
                //path = path.Replace("TestConfig.json\\", "TestConfig.json");
                //string data = File.ReadAllText(path);

                model = new TestConfigModel();
                model.Browser = TestContext.Parameters.Get("driver");
                // model = DataHelper.DeserializeJson<TestConfigModel>(data);
            }
            catch (Exception e)
            {
                logger.LogInfo(e.Message);
                logger.LogInfo("Function: " + nameof(SetConfigData));
            }
        }

    }
}
