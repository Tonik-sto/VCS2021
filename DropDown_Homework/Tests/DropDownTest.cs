using DropDown_Homework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropDown_Homework.Tests
{
    public class DropDownTest
    {
        private static DropDownPage _page;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new DropDownPage(driver);
        }

        [OneTimeTearDown]

        public static void TearDown()
        {
            //_page.CloseBrowser();
        }
        
        [TestCase("New Jersey", "California", TestName = "Pasirenkame 2 reiksmes ir patikriname First Selected")]
        [TestCase("New Jersey", "California", "Ohio", TestName = "Pasirenkame 3 reiksmes ir patikriname First Selected")]
        public void TestMultipleDropdown1Selected(params string[] selectedElements)
        {
            _page.SelectFromMultipleDropdownByValue(selectedElements.ToList())
                .VerifyFirstSelected(selectedElements[0].ToString());
        }
        
        [TestCase("New Jersey", "California", TestName = "Pasirenkame 2 reiksmes ir patikriname Get All Selected")]
        [TestCase("New Jersey", "California", "Ohio", "Washington", TestName = "Pasirenkame 4 reiksmes ir patikriname Get All Selected")]
        public void TestMultipleDropdownAllSelected(params string[] selectedElements)
        {
            _page.SelectFromMultipleDropdownByValue(selectedElements.ToList())
                            .ClickGetAllButton()
                            .VerifyAllSelected(selectedElements.ToString());
        }


        //1) Pažymime 2 valstijas, spaudžiame "First Selected" mygtuką - patikrinam, ar rezultatas teisingas, rodo pirmą pažymėtą valstiją.
        //2) Pažymime 2 valstijas, spaudžiame "Get All Selected" mygtuką - patikrinam, ar rezultatas teisingas, rodo visas užžymėtas valstijas.
        //3) Pažymime 3 valstijas, spaudžiame "First Selected" mygtuką - patikrinam, ar rezultatas teisingas, rodo pirmą pažymėtą valstiją.
        //4) Pažymime 4 valstijas, spaudžiame "Get All Selected" mygtuką - patikrinam, ar rezultatas teisingas, rodo visas užžymėtas valstijas.
    }
}
