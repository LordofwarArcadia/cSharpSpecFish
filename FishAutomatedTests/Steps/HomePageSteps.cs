using TechTalk.SpecFlow;
using FishAutomatedTests.Framework;
using FishAutomatedTests.UIObjects.Pages;
using NUnit.Framework;


namespace FishAutomatedTests
{
    using static Assert;

    using static Crawler;

    [Binding]
    public class HomePageSteps
    {
        HomePage _homePage = new HomePage();

        // "WHEN" section--------------------------------------------------------------------------------------------------------

        [When(@"I click button (.*) at the header")]
        public void WhenIClickContactAtTheHeader(string button)
        {
            _homePage.Header.ClickHeaderButton(button);
        }

        [When(@"I click (.*) in the footer section")]
        public void WhenIClickTermsAndConditionsInTheFooterSection(string _)
        {
            IsTrue(_homePage.Footer.ItemExists(_));
            _homePage.Footer.ClickItem(_);
        }

        [When(@"I select a (.*) and click Sign Up Now in the packages section")]
        public void WhenISelectAPackageAndClickSignUpNowInThePackagesSection(string _)
        {
            _homePage.Main.PackageSection.ClickSignUpForSelectedPackage(_);
        }

        [When(@"I click (.*) in About us section")]
        public void WhenIClickLinkInAboutUsSection(string _)
        {
            Session.ClickLink(_);
        }

        [When(@"I click social (.*)")]
        public void WhenIClickSocialButton(string button)
        {
            _homePage.Header.ClickSocial(button);
        }


        // "THEN" section--------------------------------------------------------------------------------------------------------
        
        [Then(@"element (.*) should be visible")]
        public void ThenElementShouldBeVisible(string element)
        {
            IsTrue(Session.FindCss(element).Exists());
        }

        [Then(@"The (.*) section should exist")]
        public void ThenTheSectionShouldExist(string section)
        {
            IsTrue(_homePage.Main.SectionExists(section));
        }

        [Then(@"(.*) in the footer should has valid (.*)")]
        public void ThenCopyrightsAndCompanyAddressShouldHaveValidValue(string item, string text)
        {
            _homePage.Footer.CompanyAddress.Hover();
            if (item == "Copyrights") IsTrue(_homePage.Footer.CopyRight.Text.Equals(text));
            if (item == "Company address") IsTrue(_homePage.Footer.CompanyAddress.Text.Equals(text));
        }
    }
}
