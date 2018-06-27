using FishAutomatedTests.Framework.Generic;
using Coypu;

namespace FishAutomatedTests.UIObjects.Sections
{
    public class Main : Section
    {
        public readonly HomeAbout AboutSection;
        public readonly HomePackages PackageSection;

        public Main(string css = ".row.anon-content") : base(css)
        {
            AboutSection = new HomeAbout();
            PackageSection = new HomePackages();
        }

        private ElementScope SectionByName(string _)
        {
            if (_ == "About us") return Scope.FindCss(".container.about>div").Hover();
            if (_ == "Trial") return Scope.FindCss(".free-trial-panel").Hover();
            return Scope.FindXPath($"//div[h2='{_}']").Hover();
        }
        public bool SectionExists(string _) => SectionByName(_).Exists();
        
    }
}
