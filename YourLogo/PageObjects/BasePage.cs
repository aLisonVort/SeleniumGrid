using FluentAssertions;
using YourLogo.Tests.Interfaces;
using YourLogo.Tests.TestsInfo;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using YourLogo.Tests.Utils;
using YourLogo.Tests.Framework.Browser;
using AventStack.ExtentReports;

namespace YourLogo.Tests.Pages
{
    public abstract class BasePage : IPage
    {
        protected WebDriverWait wait;
        // protected Reporter reporter;
        protected ExtentTest test;
        protected IWebDriver driver { get; set; }
        protected Logger logger { get; set; }
        private Actions actions;

        private TimeSpan secondsToWait = TimeSpan.FromSeconds(10);

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetCurrentURL()
        {
            return driver.Url;
        }
        public string GetAttributeValue(IWebElement e, string attribute)
        {

            return e.GetAttribute(attribute);

        }

        public void WaitUntilCondition(Func<IWebDriver, object> condtionToWait, int sec)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sec));

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.Elapsed.TotalSeconds < sec)
            {
                wait.Until(condtionToWait);
            }
        }

        public void SetLoggerInstance(Logger log)
        {
            logger = log;
        }
        public void IsElementSelected(IWebElement element)
        {
            if (!element.Selected)
            {
                element.Click();
            }
        }

        public void ScrollToElement(IWebDriver driver, IWebElement elementToScroll)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", elementToScroll);
        }

        public void Click(IWebElement el)
        {
            el.Click();
        }

        public void FillTheField(IWebElement fieldToFill, string dataToFillTheFieldWith)
        {
            wait = new WebDriverWait(driver, secondsToWait);
            if (fieldToFill.GetAttribute("value") != "")
                fieldToFill.Clear();
            fieldToFill.SendKeys(dataToFillTheFieldWith);
        }
        public void MouseHover(IWebDriver driver, IWebElement el)
        {
            actions = new Actions(driver);
            actions.MoveToElement(el).Build();
        }
        public IWebDriver GetDriver()
        {
            return driver;
        }

        public bool ValidateURL(string urlToValidate, ExtentTest test, uint timeOutSec = 10)
        {
            bool result = driver.ValidateURLContains(test, urlToValidate, timeOutSec);
            if (result == false)
            {
                test.Log(Status.Fail, $"Page URL [{driver.Url}] does not contain [{urlToValidate}].");
            }
            return result;
        }
    }
}

