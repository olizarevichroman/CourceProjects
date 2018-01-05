using NUnit.Framework;
using PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTests
{
    [TestFixture]
    class DeletePostsPositiveTests
    {
        private static object[] positiveTestsDataSource =
        {
            new object[] {"admin", "9786961roma"},
            new object[] { "Batman", "9786961roma"}
        };

        private LoginPage loginPage;
        private IWebDriver driver;
        private NavigateHelper navigator;
        private HomePage homePage;

        [SetUp]
        public void PositiveTestsSetUp()
        {
            driver = new ChromeDriver();
            navigator = new NavigateHelper(driver);
            loginPage = navigator.GoToLoginPage();
        }
        
        [TearDown]
        public void PositiveTearDownTests()
        {
            driver.Quit();
        }

        [Test, TestCaseSource("positiveTestsDataSource")]
        public void CheckIsPostDeleted(string userName, string userPassword)
        {
            int postsCount;
            loginPage.LogIn(userName, userPassword);
            homePage = navigator.GoToHomePage();
            postsCount = homePage.Posts.Count;
            PostEditPage editPage = homePage.EditPost(1);
            editPage.TryToDeletePost();
            homePage = navigator.GoToHomePage();
            Assert.AreEqual(postsCount - 1, homePage.Posts.Count);
        }

        private static object[] negativeTestsDataSource =
        {
            new object[] {"superman", "9786961roma"},
            new object[] { "Anastasiya", "9786961roma"}
        };

        [Test, TestCaseSource("negativeTestsDataSource")]
        public void CheckForException(string userName, string userPassword)
        {
            int postsCount;
            loginPage.LogIn(userName, userPassword);
            homePage = navigator.GoToHomePage();
            postsCount = homePage.Posts.Count;
            Assert.Throws<NoSuchElementException>(delegate { homePage.EditPost(1); });
        }
    }
}
