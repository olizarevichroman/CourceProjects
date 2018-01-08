using System.Linq;
using OpenQA.Selenium;

namespace PageObjects
{
    /// <summary>
    /// Сlass for navigation by pages
    /// </summary>
    public class NavigateHelper
    {
        /// <summary>
        /// Driver for navigating
        /// </summary>
        public IWebDriver Driver
        {
            get;private set;
        }

        /// <summary>
        /// Set driver for navigating
        /// </summary>
        /// <param name="driver">Driver for navigating</param>
        public NavigateHelper(IWebDriver driver)
        {
            Driver = driver;
        }

        /// <summary>
        /// Navigate to log in page
        /// </summary>
        /// <returns>Log in page</returns>
        public LoginPage GoToLoginPage()
        {
            Driver.Navigate().GoToUrl("http://localhost:8080/wp-login.php");
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            return new LoginPage(Driver);
        }

        /// <summary>
        /// Navigate to home page
        /// </summary>
        /// <returns>Home page</returns>
        public HomePage GoToHomePage()
        {
            Driver.Navigate().GoToUrl("http://localhost:8080/");
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            return new HomePage(Driver);
        }
    }
}
