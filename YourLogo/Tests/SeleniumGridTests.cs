using NUnit.Framework;
using YourLogo.Data;
using YourLogo.PageObjects;

namespace YourLogo.Tests
{
    [TestFixtureSource(typeof(FixtureArgs))]
    public class SeleniumGridTests
    {
        string _browserName = string.Empty;
        GridBase testBase;
        TestAutomationWiki testAutomation;
        ApiDrivenTesting drivenTesting;

        public SeleniumGridTests(string browser)
        {
            _browserName = browser;
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            testBase = new GridBase(_browserName);
            testAutomation = new TestAutomationWiki(testBase.Driver).Open();

        }

        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void Test()
        {
           Assert.IsTrue(testAutomation.TestAutomationHeader.Displayed);
        }


        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void Test2()
        {
            testAutomation.ClickTheApiDrivenTesting();
        }
    }
}
