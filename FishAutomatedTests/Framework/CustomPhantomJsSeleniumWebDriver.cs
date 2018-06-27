using System;

using Coypu.Drivers;
using Coypu.Drivers.Selenium;

using OpenQA.Selenium.PhantomJS;

namespace FishAutomatedTests.Framework
{
    using static Browser;

    using static PhantomJSDriverService;

    public class CustomPhantomJsSeleniumWebDriver : SeleniumWebDriver
    {
        private static readonly Func<PhantomJSDriverService> CustomDriverService = () =>
        {
            var service = CreateDefaultService();
            service.HideCommandPromptWindow = true;
            service.LoadImages = false;
            service.IgnoreSslErrors = true;
            return service;
        };

        private static readonly Func<PhantomJSOptions> CustomOptions = () =>
        {
            var options = new PhantomJSOptions();
            options.AddAdditionalCapability("phantomjs.page.settings.userAgent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36");
            return options;
        };

        public CustomPhantomJsSeleniumWebDriver()
            : base(new PhantomJSDriver(CustomDriverService(), CustomOptions()), PhantomJS)
        {
        }
    }
}
