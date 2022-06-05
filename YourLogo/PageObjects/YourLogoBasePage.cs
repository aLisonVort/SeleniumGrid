using YourLogo.Tests.Framework.Constants;
using YourLogo.Tests.Interfaces;
using YourLogo.Tests.PageObjects.Sections;
using YourLogo.Tests.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLogo.Tests.PageObjects
{
    public class YourLogoBasePage : BasePage
    {
        public YourLogoBasePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            driver.Navigate().GoToUrl(Url.BaseUrl);
        }

        public IWebElement womenSection
            => driver.FindElement(By.LinkText("Women"));
        

        public WomenSection SelectWomenSection()
        {
            Click(womenSection);
            return new WomenSection(driver);
        }
    }
}
