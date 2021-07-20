using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropDown_Homework.Pages 
{
    public class DropDownPage : BasePage
    {
        private const string PageAddress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private const string ResultText = "Options selected are : ";
        private SelectElement _MultiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private IWebElement _FirstSelectedButton => Driver.FindElement(By.Id("printMe"));
        private IWebElement _GetAllSelectedButton => Driver.FindElement(By.Id("printAll"));
        private IWebElement _Selected => Driver.FindElement(By.CssSelector(".getall-selected"));

        public DropDownPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }

        public DropDownPage SelectFromMultipleDropdownByValue(List<string> listOfStates)
        {
            _MultiDropDown.DeselectAll();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.LeftControl);
            foreach (string state in listOfStates)
            {
                foreach (IWebElement option in _MultiDropDown.Options)
                {
                    if (state.Equals(option.GetAttribute("value")))
                    {
                        action.Click(option);
                        break;
                    }
                }
            }
            action.KeyUp(Keys.LeftControl);
            action.Build().Perform();
            _MultiDropDown.DeselectAll();
            action.Click(_FirstSelectedButton);
            action.Build().Perform();
            return this;
        }
        public DropDownPage ClickGetAllButton()
        {
            _GetAllSelectedButton.Click();
            return this;
        }
        /*
        public void SelectFromMultipleDropDownByValue1(string firstValue, string secondValue)
        {
            Actions actions = new Actions(Driver);
            _MultiDropDown.SelectByValue(firstValue);
            actions.KeyDown(Keys.Control);
            _MultiDropDown.SelectByValue(secondValue);
            actions.KeyUp(Keys.Control);
            actions.Build().Perform();
        }
        public DropDownPage ClickFirstSelectedButton()
        {
            _FirstSelectedButton.Click();
            return this;
        }

        public DropDownPage ClickAllSelectedButton()
        {
            _GetAllSelectedButton.Click();
            return this;
        */

        public DropDownPage VerifyFirstSelected(string selectedCountry)
        {
            Assert.IsTrue(_Selected.Text.Equals(ResultText + selectedCountry), $"Result is wrong, not {selectedCountry}");
            return this;
        }

        public DropDownPage VerifyAllSelected(params string[] selectedElements)
        {
            Assert.IsTrue(_Selected.Text.Equals(ResultText + selectedElements), $"Result is wrong, not {selectedElements}");
            return this;
        }
    }
}
