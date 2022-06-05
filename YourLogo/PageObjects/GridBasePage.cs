using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLogo.PageObjects
{
    public abstract class GridBasePage
    {
        protected WebDriverWait wait;
        protected IWebDriver Driver { get; set; }

        public GridBasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void WaitUntilCondition(Func<IWebDriver, object> condtionToWait, int sec = 10)
        {
            IWait<IWebDriver> wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(sec));

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.Elapsed.TotalSeconds < sec)
            {
                wait.Until(condtionToWait);
            }
        }
    }
}
