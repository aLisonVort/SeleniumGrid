using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace YourLogo.Tests.Framework.Browser
{
    public class Chrome : Browser
    {
        public Chrome(bool headless = false, string workDir = "")
        {
           _StartChrome(headless, workDir);
        }
        private void _StartChrome(bool headless = false, string workDir = "")
        {
            ChromeOptions options = new ChromeOptions();

            if (!string.IsNullOrEmpty(workDir))
                options.AddUserProfilePreference("download.default_directory", workDir);


            if (headless)
            {
                options.AddArgument("headless");
            }
            _driver = new ChromeDriver(@"C:\Users\alisa.voronych\Downloads\chromedriver_win32");
            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            ////chDriver = new ChromeDriver();
            //_driver= new ChromeDriver(@"C:\Matrix\S1\YourLogo\YourLogo\Framework\Browser", options);
        }

    }
}
