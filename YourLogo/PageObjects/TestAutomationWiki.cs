using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLogo.PageObjects
{
    public class TestAutomationWiki : GridBasePage
    {
        public IWebElement TestAutomationHeader
            => Driver.FindElement(By.Id("firstHeading"));
        private IWebElement APIDriverTesting
            => Driver.FindElement(By.XPath("//a[text()= 'API driven testing']"));
        public TestAutomationWiki(IWebDriver driver) : base(driver)
        {

        }

        public TestAutomationWiki Open()
        {
            Driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Test_automation");
            return this;
        }



        public ApiDrivenTesting ClickTheApiDrivenTesting()
        {
            WaitUntilCondition(ExpectedConditions.ElementToBeClickable(Driver.FindElement(By.XPath("//a[text()= 'API driven testing']"))));
            APIDriverTesting.Click();
            return new ApiDrivenTesting(Driver);
        }
    }
}
