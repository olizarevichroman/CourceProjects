using OpenQA.Selenium;

namespace PageObjects
{
    /// <summary>
    /// An object representation of post edit page
    /// </summary>
    public class PostEditPage
    {
        /// <summary>
        /// Stores driver for this page
        /// </summary>
        public IWebDriver Driver
        {
            get;private set;
        }

        /// <summary>
        /// Stores move to trash button
        /// </summary>
        public IWebElement MoveToTrashButton
        {
            get;set;
        }

        /// <summary>
        /// Set driver and find move to trash button
        /// </summary>
        /// <param name="driver">Driver for this page</param>
        public PostEditPage(IWebDriver driver)
        {
            Driver = driver;
            MoveToTrashButton = Driver.FindElement(By.XPath("//div[@id=\"delete-action\"]/a[@class=\"submitdelete deletion\"]"));
        }

        /// <summary>
        /// Method click to move to trash button and delete this post
        /// </summary>
        /// <returns>Workspace page after removal</returns>
        public WorkspacePage TryToDeletePost()
        {
            MoveToTrashButton.Click();
            return new WorkspacePage(Driver);
        }
    }
}
