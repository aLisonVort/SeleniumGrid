using YourLogo.Tests.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLogo.Tests.PageObjects.Sections
{
    class DressesSubSection:BasePage
    {
        public DressesSubSection(IWebDriver driver): base(driver)
        {
            this.driver = driver;
        }
    }
}
