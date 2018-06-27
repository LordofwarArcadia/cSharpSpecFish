using System;
using Coypu;
using Coypu.Drivers;
using TechTalk.SpecFlow;

namespace FishAutomatedTests.Framework
{
    using static Browser;

    using static TimeSpan;

    using static Tools;

    using static Config;

    [Binding]
    public class Crawler
    {
        public static BrowserSession Session { get; set; }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            var sessionConfiguration = new SessionConfiguration
            {
                Browser = Chrome,
                AppHost = QaAppHost,
                WaitBeforeClick = FromSeconds(1)
            };
            Session = new BrowserSession(sessionConfiguration/*, new CustomPhantomJsSeleniumWebDriver()*/);
            ResizeWindow(1600,900);
            Session.Visit("/");
            AddAcceptanceCookie(QaAppHost);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Session.Dispose();
        }
    }
}
