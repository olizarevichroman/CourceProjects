using System;
using NUnit.Framework;
using PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTests
{
    [TestFixture]
    class LogInNegativeTests
    {
        private static LoginPage loginPage;
        private static IWebDriver driver;

        private static object[] incorrectPasswords =
        {
            new object[] {"admin", "9786961rom"},
            new object[] { "superman", "86961roma"},
            new object[] { "Batmn", "9786961roma"},
            new object[] { "Anatasiya", "9786961roma"}
        };

        [SetUp]
        public void TestsSetUp()
        {
            driver = new ChromeDriver();
            NavigateHelper navigator = new NavigateHelper(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
            loginPage = navigator.GoToLoginPage();
        }

        [Test, TestCaseSource("incorrectPasswords")]
        public void TestIncorrectPasswordsAndLogins(string userName, string userPassword)
        {         
            Assert.Throws<InvalidOperationException>(delegate { loginPage.LogIn(userName, userPassword); });
        }

        [TearDown]
        public void TestsTearDown()
        {
            driver.Quit();
        }

    }
}
