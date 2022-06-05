using YourLogo.Tests.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLogo.Tests.TestsInfo;
using YourLogo.Tests.Utils;
using AventStack.ExtentReports;

namespace YourLogo.Tests.PageObjects.Sections.Decorators
{
    class WomenSubsectionTops: WomenSectionType
    {
        public WomenSubsectionTops(IWebDriver driver, ISectionType section, ExtentTest test) : base(driver, section, test)
        {

        }

        public IWebElement topsSection
            => driver.FindElement(By.LinkText("Tops"));

        public override dynamic SelectSubSection()
        {
            try
            {
                topsSection.ClickWrapper(driver, test, nameof(topsSection));
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(nameof(topsSection) + $" element is not present on the {nameof(WomenSubsectionTops)}page");
            }
            return new TopsSubSection(driver);
        } 
    }
}
