using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects;

namespace NUnitTests
{
    [TestFixture]
    class DeletePostsNegativeTests
    {

        private LoginPage loginPage;
        private IWebDriver driver;
        private NavigateHelper navigator;
        private HomePage homePage;

        private static object[] usersWithoutDeleteRights =
        {
            new object[] {"superman", "9786961roma"},
            new object[] { "Anastasiya", "9786961roma"}
        };

        private static object[] tryToDeleteNonExistentPosts =
        {
            new object[] {"Batman", "9786961roma"},
            new object[] { "admin", "9786961roma"}
        };

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

        [Test, TestCaseSource("usersWithoutDeleteRights")]
        public void CheckForException(string userName, string userPassword)
        {
            int postsCount;
            loginPage.LogIn(userName, userPassword);
            homePage = navigator.GoToHomePage();
            postsCount = homePage.Posts.Count;
            Assert.Throws<NoSuchElementException>(delegate { homePage.EditPost(1); });
        }

        [Test, TestCaseSource("tryToDeleteNonExistentPosts")]
        public void TryToDeleteNonExistentPost(string userName, string userPassword)
        {
            int postsCount;
            loginPage.LogIn(userName, userPassword);
            homePage = navigator.GoToHomePage();
            postsCount = homePage.Posts.Count;
            Assert.Throws<ArgumentException>(delegate { homePage.EditPost(postsCount+1); });
        }
    }
}
