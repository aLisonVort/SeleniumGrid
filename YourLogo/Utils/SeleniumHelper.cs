using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using YourLogo.Tests.TestsInfo;
using YourLogo.Tests.UI;

namespace YourLogo.Tests.Utils
{
    public static class SeleniumHelper
    {
        public static string CaptureScreen(this IWebDriver driver)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            return screenshot.AsBase64EncodedString;
        }

    }
    public static class WebElementExtension
    {
        public static bool ControlDisplayed(this IWebElement element, IWebDriver driver, ExtentReport extentReportsHelper, string elementName, bool displayed = true, uint timeoutInSeconds = 60)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(Exception));
            return wait.Until(drv =>
            {
                if (!displayed && !element.Displayed || displayed && element.Displayed)
                {
                    extentReportsHelper.SetStepStatusPass($"[{elementName}] is displayed on the page.");
                    return true;

                }
                extentReportsHelper.SetStepStatusPass($"[{elementName}] is displayed on the page.");
                return false;
            });
        }
        public static void ClearWrapper(this IWebElement element, ExtentReport extentReportsHelper, string elementName)
        {
            element.Clear();
            if (element.Text.Equals(string.Empty))
            {
                extentReportsHelper.SetStepStatusPass($"Cleared element [{elementName}] content.");
            }
            else
            {
                extentReportsHelper.SetStepStatusWarning($"Element [{elementName}] content is not cleared. Element value is [{element.Text}]");
            }
        }

        public static void ClickWrapper(this IWebElement element, IWebDriver driver, ExtentTest test, string elementName)
        {
           try
            {
                element.Click();
                test.Log(Status.Pass, $"Clicked on the {elementName} element.");
                //extentReportsHelper.SetStepStatusPass($"Clicked on the {elementName} element.");
            }
            catch
            {
                throw new Exception($"Element [{elementName}] is not displayed");
            }
        }
        public static void SendKeysWrapper(this IWebElement element, ExtentReport extentReportsHelper, string value, string elementName)
        {
            element.SendKeys(value);
            extentReportsHelper.SetStepStatusPass($"SendKeys value [{value}] to  element [{elementName}].");
        }
        public static bool ValidatePageTitle(this IWebDriver driver, ExtentReport extentReportsHelper, string title, uint timeoutInSeconds = 300)
        {
            bool result = false;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(Exception));
            return result = wait.Until(drv =>
            {
                if (drv.Title.Contains(title))
                {
                    extentReportsHelper.SetStepStatusPass($"Page title [{drv.Title}] contains [{title}].");
                    return true;
                }
                extentReportsHelper.SetStepStatusWarning($"Page title [{drv.Title}] does not contain [{title}].");
                return false;
            });
        }
        public static bool ValidateURLContains(this IWebDriver driver, ExtentTest test, string urlPart, uint timeoutInSeconds = 120)
        {
            bool result = false;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(Exception), typeof(WebDriverTimeoutException));
            int counter = 0;
            result = wait.Until(drv =>
            {
                if (drv.Url.Contains(urlPart))
                {
                   test.Log(Status.Pass, $"Page URL [{drv.Url}] contains [{urlPart}].");
                    return true;
                }
                if (counter < 1)
                {
                    test.Log(Status.Fatal, $"Page URL [{drv.Url}] does not contain [{urlPart}].");
                    counter++;
                }
                return  false;
            });
            return result;
        }
    }
}
