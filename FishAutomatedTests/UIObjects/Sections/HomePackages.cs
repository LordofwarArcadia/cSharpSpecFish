using FishAutomatedTests.Framework.Generic;
using System;

namespace FishAutomatedTests.UIObjects.Sections
{
    public class HomePackages : Section
    {
        public HomePackages(string css = "#pricing>div") : base(css)
        {
        }

        private string SelectPackage(string package)
        {
           switch (package)
            {
                case "Basic":
                    return "package productfree";
                case "Advanced":
                    return "package product1";
                case "Premium":
                    return "package product2";
                default:
                    throw new ArgumentNullException("You must enter a valid package string."); ;
            }
        }

        public void ClickSignUpForSelectedPackage(string _)
        {
            Scope.FindXPath($"//li[@class='{SelectPackage(_)}']/a").Click();
        }
    }
}
