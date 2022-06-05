//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using YourLogo.Tests.UI;
////[assembly: Parallelizable(ParallelScope.Fixtures)]

//namespace YourLogo.Tests
//{
//    [TestFixture]
//    [Parallelizable(ParallelScope.All)]
//    public class SectionNavigation : ExtentReport
//        {

           
//            [Test]
//            [TestCase("Women", "Tops")]

//            public void NavigateToTopsSubSection(string section, string subSection)
//            {
//            //report.CreateTest(nameof(MethodBase.Name));
//            //sectionType = new WomenSectionType(driver, womenSection, test);
//            //sectionType.SelectSubSection();
//            //using (new AssertionScope())
//            //{

//            //    sectionType.GeTypeOfSelectedProductSection().Should().BeEquivalentTo(section);
//            //    sectionType.ValidateURL(Url.BaseUrl + Url.WomenSection, test).Should().BeTrue();
//            //}

//            //sectionType = new WomenSubsectionTops(driver, sectionType, test);
//            //sectionType.SelectSubSection();
//            //using (new AssertionScope())
//            //{
//            //    sectionType.GeTypeOfSelectedProductSection().Should().BeEquivalentTo(subSection);
//            //    sectionType.ValidateURL(Url.BaseUrl + Url.TopsSubSection + "test", test).Should().BeTrue();
//            //}
//            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Test_automation");
//                test = extent.CreateTest("Test");
//                test.Pass("Pass");
//                Assert.Pass();
//            }

//            [Test]
//            [TestCase("Women", "Tops")]

//            public void TestFail(string section, string subSection)
//            {
//                test = extent.CreateTest("Test");
//                test.Fail("Tests");
//                Assert.Fail();
//            }
//        }
//    }


