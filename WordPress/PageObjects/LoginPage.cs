using OpenQA.Selenium;
using System;
using System.Linq;

namespace PageObjects
{
    /// <summary>
    /// An object representation of log in page
    /// </summary>
    public class LoginPage
    {
        /// <summary>
        /// Page title
        /// </summary>
        public readonly string title = "MyBlog › Log In";

        /// <summary>
        /// An object representation of login text field
        /// </summary>
        public IWebElement LoginTextField
        {
            get;private set;
        }

        /// <summary>
        /// An object representation of submit button
        /// </summary>
        public IWebElement SubmitButton
        {
            get;private set;
        }

        /// <summary>
        /// An object representation of password text field
        /// </summary>
        public IWebElement PasswordTextField
        {
            get;private set;
        }

        /// <summary>
        /// Driver for this page
        /// </summary>
        public IWebDriver Driver
        {
            get;private set;
        }

        /// <summary>
        /// Find and initialize login and password text field and submit button
        /// </summary>
        /// <returns>This page</returns>
        private LoginPage GetElements()
        {
            LoginTextField = Driver.FindElement(By.XPath("//input[@id=\"user_login\"]"));
            PasswordTextField = Driver.FindElement(By.XPath("//input[@id=\"user_pass\"]"));
            SubmitButton = Driver.FindElement(By.XPath("//input[@type=\"submit\"]"));
            return this;
        }

        /// <summary>
        /// Set driver and execute method to find and initialize needed elements from the page
        /// </summary>
        /// <param name="driver">Driver for this page</param>
        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
            GetElements();
        }

        /// <summary>
        /// Try to log in by user name and password.
        /// Throws Invalid operation exception if login or password are not right
        /// </summary>
        /// <param name="userName">string with user name</param>
        /// <param name="userPassword">string with user password</param>
        /// <returns>Next page, if log in is correct</returns>
        public WorkspacePage LogIn(string userName, string userPassword)
        {
            LoginTextField.SendKeys(userName);
            PasswordTextField.SendKeys(userPassword);
            while ( LoginTextField.GetAttribute("value") != userName ) 
            {
                LoginTextField.Clear();
                LoginTextField.SendKeys(userName);
            }
            SubmitButton.Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            if ( Driver.Title == title )
            {
                throw new InvalidOperationException();
            }
            return new WorkspacePage(Driver);
        }
    }
}
