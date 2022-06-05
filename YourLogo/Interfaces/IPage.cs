using YourLogo.Tests.Pages;
using YourLogo.Tests.TestsInfo;
using OpenQA.Selenium;

namespace YourLogo.Tests.Interfaces
{
    public interface IPage
    {
        //IPage GetAttributeValue(IWebElement e, string attribute);
        //IPage FixFormat(string actual, string desired);
        //IPage ElementIsSelected(IWebElement e);
        //IPage True();
        void SetLoggerInstance(Logger logger);
    }
}
