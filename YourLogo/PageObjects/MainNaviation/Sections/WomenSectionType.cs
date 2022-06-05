using YourLogo.Tests.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLogo.Tests.TestsInfo;
using AventStack.ExtentReports;

namespace YourLogo.Tests.PageObjects.Sections.Decorators
{
    public  class WomenSectionType : SectionsTypes
    {
        public WomenSectionType(IWebDriver driver ,ISectionType section, ExtentTest test) : base(section, driver, test)
        {
            this.test = test;
        }

    }
}
