//using FluentAssertions;
//using FluentAssertions.Execution;
//using YourLogo.Tests.Framework.Constants;
//using YourLogo.Tests.PageObjects;
//using YourLogo.Tests.PageObjects.Sections;
//using YourLogo.Tests.PageObjects.Sections.Decorators;
//using NUnit.Framework;
//using YourLogo.Tests.Tests;

//namespace YourLogo.Tests.UI
//{
//    [TestFixture]
//    [Parallelizable(ParallelScope.All)]
//    public class SectionNavigation : UIBaseTest
//    {
//        YourLogoBasePage startPage;
//        WomenSection womenSection;
//        SectionsTypes sectionType;

//        public override void ExtendedSetUp()
//        {
//            startPage = new YourLogoBasePage(driver);
//            womenSection = startPage.SelectWomenSection();
//        }

//        public override void ExtendedOneTimeTearDown()
//        {
//            SetDriverInstance(sectionType.GetDriver());
//        }



//        //[Test]
//        //[TestCase("Women", "Tops")]

//        //public void NavigateToTopsSubSection(string section, string subSection)
//        //{
//        //    sectionType = new WomenSectionType(driver, womenSection, test);
//        //    sectionType.SelectSubSection();
//        //    using (new AssertionScope())
//        //    {

//        //        sectionType.GeTypeOfSelectedProductSection().Should().BeEquivalentTo(section);
//        //        sectionType.ValidateURL(Url.BaseUrl + Url.WomenSection, test).Should().BeTrue();
//        //    }

//        //    sectionType = new WomenSubsectionTops(driver, sectionType, test);
//        //    sectionType.SelectSubSection();
//        //    using (new AssertionScope())
//        //    {
//        //        sectionType.GeTypeOfSelectedProductSection().Should().BeEquivalentTo(subSection);
//        //        sectionType.ValidateURL(Url.BaseUrl + Url.TopsSubSection + "test", test).Should().BeTrue();
//        //    }
//        //}



       
//        [Test]
//        [TestCase("Women", "Dresses")]

//        public void NavigateToDressesSubSection(string section, string subSection)
//        {
//            sectionType = new WomenSectionType(driver, womenSection, test);
//            sectionType.SelectSubSection();
//            using (new AssertionScope())
//            {

//                sectionType.GeTypeOfSelectedProductSection().Should().BeEquivalentTo(section);
//                sectionType.ValidateURL(Url.BaseUrl + Url.WomenSection, test).Should().BeTrue();
//            }

//            sectionType = new WomenSubsectionDresses(driver, sectionType, test);
//            sectionType.SelectSubSection();
//            using (new AssertionScope())
//            {
//                sectionType.GeTypeOfSelectedProductSection().Should().BeEquivalentTo(subSection);
//                sectionType.ValidateURL(Url.BaseUrl + Url.DressesSubSection, test).Should().BeTrue();
//            }

//        }
//    }

//    //[TestFixture]
//    //public class SectionNavigation : ExtentReport
//    //{
//    //    YourLogoBasePage startPage;
//    //    WomenSection womenSection;
//    //    SectionsTypes sectionType;

//    //    //public override void ExtendedSetUp()
//    //    //{
//    //    //    startPage = new YourLogoBasePage(driver);
//    //    //    womenSection = startPage.SelectWomenSection();
//    //    //}

//    //    //public override void ExtendedOneTimeTearDown()
//    //    //{
//    //    //    SetDriverInstance(sectionType.GetDriver());
//    //    //}



//    //    [Test]
//    //    [TestCase("Women", "Tops")]

//    //    public void NavigateToTopsSubSection(string section, string subSection)
//    //    {
//    //        sectionType = new WomenSectionType(driver, womenSection, test);
//    //        sectionType.SelectSubSection();
//    //        using (new AssertionScope())
//    //        {

//    //            sectionType.GeTypeOfSelectedProductSection().Should().BeEquivalentTo(section);
//    //            sectionType.ValidateURL(Url.BaseUrl + Url.WomenSection, test).Should().BeTrue();
//    //        }

//    //        sectionType = new WomenSubsectionTops(driver, sectionType, test);
//    //        sectionType.SelectSubSection();
//    //        using (new AssertionScope())
//    //        {
//    //            sectionType.GeTypeOfSelectedProductSection().Should().BeEquivalentTo(subSection);
//    //            sectionType.ValidateURL(Url.BaseUrl + Url.TopsSubSection + "test", test).Should().BeTrue();
//    //        }

//    //        //    test = extent.CreateTest("Test");
//    //        //    test.Pass("Pass");
//    //        //    Assert.Pass();
//    //        }
//    //        [TestFixture]
//    //    public class Test : ExtentReport
//    //    {
//    //        YourLogoBasePage startPage;
//    //        WomenSection womenSection;
//    //        SectionsTypes sectionType;

//    //        //public override void ExtendedSetUp()
//    //        //{
//    //        //    startPage = new YourLogoBasePage(driver);
//    //        //    womenSection = startPage.SelectWomenSection();
//    //        //}

//    //        //public override void ExtendedOneTimeTearDown()
//    //        //{
//    //        //    SetDriverInstance(sectionType.GetDriver());
//    //        //}


//    //        [Test]
//    //        [TestCase("Women", "Dresses")]

//    //        public void NavigateToDressesSubSection(string section, string subSection)
//    //        {
//    //            //test = extent.CreateTest("Test");
//    //            ////report.CreateTest(nameof(MethodBase.Name));
//    //            sectionType = new WomenSectionType(driver, womenSection, test);
//    //            sectionType.SelectSubSection();
//    //            using (new AssertionScope())
//    //            {

//    //                sectionType.GeTypeOfSelectedProductSection().Should().BeEquivalentTo(section);
//    //                sectionType.ValidateURL(Url.BaseUrl + Url.WomenSection, test).Should().BeTrue();
//    //            }

//    //            sectionType = new WomenSubsectionDresses(driver, sectionType, test);
//    //            sectionType.SelectSubSection();
//    //            using (new AssertionScope())
//    //            {
//    //                sectionType.GeTypeOfSelectedProductSection().Should().BeEquivalentTo(subSection);
//    //                sectionType.ValidateURL(Url.BaseUrl + Url.DressesSubSection, test).Should().BeTrue();
//    //            }
//    //            //test.Fail("fail");
//    //            //Assert.Fail();

//    //        }
//    //    }

//    // }
//}
