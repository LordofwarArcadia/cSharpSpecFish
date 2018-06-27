using FishAutomatedTests.Framework.Generic;
using Coypu;

namespace FishAutomatedTests.UIObjects.Sections
{
    public class Footer : Section
    {
        public Footer(string css = ".row.footer") : base(css)
        {
        }

        private ElementScope ItemByName(string _) => Scope.FindXPath($"//div[@class='row footer']//p/a[.='{_}']");

        public ElementScope CopyRight
        {
            get { return Scope.FindCss(".copyright"); }
        }
        public ElementScope CompanyAddress
        {
            get { return Scope.FindCss(".company-address"); }
        }
        
        public void ClickItem(string _) => ItemByName(_).Click();
        public bool ItemExists(string _) => ItemByName(_).Exists();
    }
}


