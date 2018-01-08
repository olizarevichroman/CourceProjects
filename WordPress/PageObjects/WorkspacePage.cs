using OpenQA.Selenium;

namespace PageObjects
{
    /// <summary>
    /// An object representation of workspace page
    /// </summary>
    public class WorkspacePage
    {
        /// <summary>
        /// Page title
        /// </summary>
        public readonly string Title =  "MyBlog — WordPress";

        /// <summary>
        /// Stores for this page
        /// </summary>
        public IWebDriver Driver
        {
            get;private set;
        }

        /// <summary>
        /// Set driver for this page
        /// </summary>
        /// <param name="driver">Driver for this page</param>
        public WorkspacePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
