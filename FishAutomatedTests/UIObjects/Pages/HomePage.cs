using FishAutomatedTests.Framework.Generic;
using FishAutomatedTests.UIObjects.Sections;

namespace FishAutomatedTests.UIObjects.Pages
{
    public class HomePage : Page
    {
        public readonly Footer Footer;
        public readonly Header Header;
        public readonly Main Main;

        public HomePage()
        {
            Footer = new Footer();
            Header = new Header();
            Main = new Main();
        }
    }
}
