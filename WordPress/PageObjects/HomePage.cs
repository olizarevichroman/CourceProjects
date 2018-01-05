using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace PageObjects
{
    /// <summary>
    /// An object representation of the home page
    /// </summary>
    public class HomePage
    {
        /// <summary>
        /// Page title
        /// </summary>
        public readonly string Title = "MyBlog | Just another WordPress site";

        /// <summary>
        /// List of all posts on the page
        /// </summary>
        public List<IWebElement> Posts
        {
            get;private set;
        }
        /// <summary>
        /// Stores driver for this page
        /// </summary>
        public IWebDriver Driver
        {
            get;private set;
        }
        /// <summary>
        /// Set driver for this page and get posts list
        /// </summary>
        /// <param name="driver">Driver for this page</param>
        public HomePage(IWebDriver driver)
        {
            Driver = driver;
            Posts = Driver.FindElements(By.XPath("//article")).ToList();
        }
        /// <summary>
        /// Try to edit post. Throws Argument Exception, if posts amount = 0 or
        /// post with this number don't exist
        /// </summary>
        /// <param name="postNumber">Number of post, which we want to edit</param>
        /// <returns>An object representation of this page</returns>
        public PostEditPage EditPost(int postNumber)
        {
            if ( postNumber > Posts.Count || postNumber == 0 )
            {
                throw new ArgumentException();
            }
            Posts[postNumber - 1].FindElement(By.XPath("//a[@class=\"post-edit-link\"]")).Click();
            return new PostEditPage(Driver);
        }
    }
}
