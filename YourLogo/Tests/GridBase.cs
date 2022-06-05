using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using YourLogo.Tests.Framework.Browser;

namespace YourLogo.Tests
{
    public sealed class GridBase
    {
        public IWebDriver Driver { get; private set; }
        public TestCaseResult TestContextResult { get; set; }
        private readonly Browser _driverBase;
        private readonly DateTime _testStartTime;
        private readonly TestContext _currentTestCtx = null;
        public GridBase(string browser)
        {
            _driverBase = new Browser(browser);
            Initialize();
        }

        private void Initialize()
        {
            Driver = _driverBase.GetWebDriver();
        }

        private void DisposeWebDriverInstance()
        {
            try
            {

                Driver.Quit();
                Driver.Dispose();
                Driver = null;
            }
            catch { }
            }
        }
    }

