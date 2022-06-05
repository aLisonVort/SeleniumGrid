using YourLogo.Tests.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLogo.Tests.Utils;
using YourLogo.Tests.TestsInfo;
using AventStack.ExtentReports;

namespace YourLogo.Tests.PageObjects.Sections.Decorators
{
    class WomenSubsectionDresses: WomenSectionType
    {
        public WomenSubsectionDresses( IWebDriver driver, ISectionType section, ExtentTest test) : base(driver, section, test)
        {
            this.test = test;
        }

        public IWebElement dressesSection
            => driver.FindElement(By.LinkText("Dresses"));
        public override dynamic SelectSubSection()
        {
            try
            {
                dressesSection.ClickWrapper(driver, test, nameof(dressesSection));
            }catch(NoSuchElementException e)
            {
                Console.WriteLine(nameof(dressesSection) + $" element is not present on the {nameof(WomenSubsectionDresses)}page");
            }
            return new TopsSubSection(driver);
        }
    }
}
