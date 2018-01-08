using System;
using NUnit.Framework;
using PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace NUnitTests
{
    [TestFixture]
    public class LogInPositiveTests
    {
        private static LoginPage loginPage;
        private static IWebDriver driver;

        private static object[] usersData =
        {
            new object[] {"admin", "9786961roma"},
            new object[] { "superman", "9786961roma"},
            new object[] { "Batman", "9786961roma"},
            new object[] { "Anastasiya", "9786961roma"}
        };

        [SetUp]
        public void TestsSetUp()
        {
            driver = new ChromeDriver();
            NavigateHelper navigator = new NavigateHelper(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            loginPage = navigator.GoToLoginPage();
        }

        [TearDown]
        public void TestsTearDown()
        {
            driver.Quit();
        }

        [Test, TestCaseSource("usersData")]
        public void TestLogIn(string userName, string userPassword)
        {
            WorkspacePage workspacePage = loginPage.LogIn(userName, userPassword);
            Assert.IsTrue(driver.Title.EndsWith(workspacePage.Title));
            
        }
    }
}
