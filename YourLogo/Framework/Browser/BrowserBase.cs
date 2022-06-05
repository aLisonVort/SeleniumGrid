using YourLogo.Tests.Framework.Constants;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace YourLogo.Tests.Framework.Browser
{
    public class Browser
    {
        protected IWebDriver _driver { get; set; }
        protected static string browserType { get; set; }

        private Browser _browser;

        public Browser() { }

        public Browser(string browserT)
        {
            browserType = browserT;
            // Start the driver
            //switch (browserType)
            //{
            //    case Browsers.Chrome:
            //        _browser = new Chrome();
            //        this._driver = _browser._driver;
            //        break;

            //    case Browsers.FireFox:
            //        _browser = new FireFox();
            //        this._driver = _browser._driver;
            //        break;

            //    default:
            //        throw new Exception("Browser type is not impletenmed: " + browserType);
           // }
            //try
            //{
                _driver = SetUpRemoteWebDriver(browserT);
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Const.ImplicitWait);
                _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Const.PageLoadWait);
            //    //this._driver = _browser._driver;
            //}
            //catch (Exception)
            //{

            //}
        }


        //public WebDriverWait GetWait()
        //    => Wait;
        public IWebDriver GetWebDriver()
        {
            return _driver;
        }

        protected IWebDriver SetUpRemoteWebDriver(string browserType)
        {
            var capabilities = GetCapabilitiesByBrowserType(browserType);

            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capabilities);
            return driver;
        }

        private dynamic GetCapabilitiesByBrowserType(string browser)
        {
            switch (browser)
            {
                case Browsers.Chrome:
                    var options  = new ChromeOptions();
                    options.AddArgument("no-sandbox");
                    //options.AddArguments("headless");
                    return options;

                case Browsers.FireFox:
                    return new FirefoxOptions();

                default:
                    throw new Exception("Browser type is not impletenmed: " + browserType);
            }
        }

    }
}
