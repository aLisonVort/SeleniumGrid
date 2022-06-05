using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.CodeDom;
using System.Configuration;
using YourLogo.Tests.Configurations;
using YourLogo.Tests.Framework.Browser;
using YourLogo.Tests.TestsInfo;

namespace YourLogo.Tests.UI

{
    /// <summary>Class <c>Reporter</c> to create
    /// and customize Extent Report.</summary>
    
    [SetUpFixture]
     public class ExtentReport
    {
        public static ExtentReports extent;
        private ExtentHtmlReporter htmlReporter;
        public IWebDriver driver;

        private TestConfigModel model;
        protected static Browser browser;

        public Logger logger;
        public ExtentTest test;
        private readonly string path = ConfigurationManager.AppSettings["YourLogo.Report.Path"];
        /// <summary>Creates an extent report.</summary>
        /// 
        [OneTimeSetUp]
        protected void CreateReport()
        {
            if (extent == null)
            {

            extent = new ExtentReports();
            htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent.AttachReporter(htmlReporter);
            }
            SetConfigData();
            browser = new Browser(model.Browser);
            driver = browser.GetWebDriver();
            StandardOneTimeSetup();
            ExtentOneTimeSetUp();
            var a = TestContext.Parameters;
            foreach (var name in a.Names)
            {
                switch (name)
                {
                    case "driver":
                        logger.LogInfo(name + $" is set to:{TestContext.Parameters.Get(name)}");
                        break;
                    default:
                        logger.LogInfo($"No such property: {name}");
                        break;

                }
            }
        }

        
        protected virtual void ExtentOneTimeSetUp() { }

        private void SetLogger()
        {
            logger = new Logger();
            logger.Initialize();
        }
        public void StandardOneTimeSetup()
        {
            // CreateReporter()
            SetLogger();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
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
        public void GetTestName()
        {
             test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test has been finished");
        }
        //public void EndReport()
        //{
        //    extent.Flush();
        //}
        /// <summary>Creates a test.</summary>
        /// <param name="testName">the name of a test to be created</param>
        public void CreateTest(string testName)
        {
            test = extent.CreateTest(testName);
        }
        /// <summary>Sets status to pass.</summary>
        /// <param name="stepDescription">dsescription of a step to set</param>
        public void SetStepStatusPass(string stepDescription)
        {
            test.Log(Status.Pass, stepDescription);
        }
        public void SetStepStatusWarning(string stepDescription)
        {
            test.Log(Status.Warning, stepDescription);
        }
        public void SetTestStatusPass()
        {
            test.Pass("Test Executed Sucessfully");
        }
        public void SetTestStatusFail(string message = null)
        {
            var printMessage = "<p><b style='color:red;'>Test FAILED!</b></p>";
            if (!string.IsNullOrEmpty(message))
            {
                printMessage += $"Message: <br>{message}<br>";
            }
            test.Fail(printMessage);
        }
        public void AddTestFailureScreenshot(string base64ScreenCapture)
        {
            test.AddScreenCaptureFromBase64String(base64ScreenCapture, "Screenshot on Error:");
        }
        public void SetTestStatusSkipped()
        {
            test.Skip("Test skipped!");
        }

        [OneTimeTearDown]
        public void Close()
        {

            extent.Flush();
            StandardOneTimeTearDown(driver);
            ExtentOneTimeTearDown();
        }

        public virtual void ExtentOneTimeTearDown() { }
        public void StandardOneTimeTearDown(IWebDriver driver)
        {
            // test.Close();
            EndTests(driver);
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

    }
}
