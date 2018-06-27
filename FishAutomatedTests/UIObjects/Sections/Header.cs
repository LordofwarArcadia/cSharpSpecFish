using FishAutomatedTests.Framework.Generic;
using Coypu;


namespace FishAutomatedTests.UIObjects.Sections
{
    public class Header : Section
    {
        public Header(string css = "div.row.header") : base(css)
        {
        }

        private ElementScope Logo => Scope.FindCss("li.brand-primary>a");


        private ElementScope SocialButtons (string _) => Scope.FindCss($".icon-{_.ToLower()}");
        
        private ElementScope MenuItemByName(string _) => Scope.FindXPath($"//li[@class='']/a[span[.='{_}']]");

        private ElementScope MenuTopForLoggedUsers(string _)
            => Scope.FindXPath($"//ul[@ng-controller='']//a[span[.='{_}']]");

        public void ClickMenuForLoggedUsers(string subitem)
        {
            MenuTopForLoggedUsers(subitem).Click();
        }

        private ElementScope MyAccount => Scope.FindXPath("$//a[i[@class='icon-user']]");
        private ElementScope MySettings => Scope.FindXPath("$//a[.='Settings']");
        private ElementScope LogOut => Scope.FindXPath("$//a[.='Logout']");

        public void ClickLogout()
        {
            MyAccount.Click();
            LogOut.Click();
        }
        public void ClickMySettings()
        {
            MyAccount.Click();
            MySettings.Click();
        }
        public void ClickSocial(string _) => SocialButtons(_).Click();
        public void ClickLogo() => Logo.Click();

        public void ClickHeaderButton(string _) => MenuItemByName(_).Click();

        public bool MenuItemExists(string _) => MenuItemByName(_).Exists();
    }
}

