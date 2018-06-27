using System;
using TechTalk.SpecFlow;
using FishAutomatedTests.Framework;
using FishAutomatedTests.UIObjects.Pages;
using OpenQA.Selenium;
using NUnit.Framework;

namespace FishAutomatedTests.Steps
{
    using static Assert;

    using static Crawler;

    using static String;

    using static Tools;

    [Binding]
    public sealed class CommonSteps
    {
        private readonly HomePage _homePage = new HomePage();

        [AfterStep]
        public static void TakeScreenshotAfterStep()
        {
            TakeScreenshot();
        }

        // "GIVEN" section--------------------------------------------------------------------------------------------------------


        [Given(@"I go to the site as anonymous")]
        public void GivenIGoToTheSiteAsAnonymous()
        {
            Session.Visit("/");
        }

        // "WHEN" section--------------------------------------------------------------------------------------------------------
        [When(@"I navigate to the (.*) page by the (.*) url")]
        public void WhenINavigateToThePageByTheUrl(string page, string url)
        {
            Session.Visit(url);
        }

        // "THEN" section--------------------------------------------------------------------------------------------------------


        /*
        * binding for all URLs which are BELONG to the current project, like LinkedIn, CapConf, etc.
        */
        [Then(@"I am redirected to the (.*) page")]
        public void ThenIAmRedirectedToThePage(string page)
        {
            switch (page)
            {
                case "/identity/login": IsTrue(_homePage.Url.Contains(Concat("https://", Config.QaAuthHost, page))); break;
                case "/User/Register": IsTrue(_homePage.Url.Contains(Concat("https://", Config.QaAuthHost, page))); break;
                default: IsTrue(_homePage.Url.Contains(Concat("https://", Config.QaAppHost, page))); break;
            }
        }

        /*
         * binding for all URLs which are NOT BELONG to the current project, like LinkedIn, CapConf, etc.
         */
        [Then(@"The (.*) should be opened")] 
        public void ThenTheURLShouldBeOpenedIn(string url)
        {
            IsTrue(Session.Location.AbsoluteUri.Equals(url));
        }

        [Then(@"The (.*) should be opened in the next tab")]
        public void ThenTheURLShouldBeOpenedInTheNextTab(string url)
        {
            var driver = (IWebDriver)Crawler.Session.Native;
            string _currentWindow = driver.CurrentWindowHandle;
            var linkWindow = driver.WindowHandles[1];
            driver.SwitchTo().Window(linkWindow);
            IsTrue(driver.Url.Equals(url));
            driver.Close();
            driver.SwitchTo().Window(_currentWindow);
        }

        [Then(@"the (.*) title should be correct")]
        public void ThenThePageTitleShouldBeCorrect(string _)
        {
            IsTrue(Session.Title.Contains(_));
        }
    }
}
