using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

using TestFramework.Extensions;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;
using Selenium;

namespace OpenQA.Selenium
{
    public class WebDriverExtensions : GenericExtensions
    {
        #region Fields

        public IWebDriver Driver;

        #endregion

        #region Constructors

        public WebDriverExtensions(IWebDriver driver)
        {
            this.Driver = driver;
        }

        #endregion

		#region Type specific methods
		
        public override void Click(string element, string additionalLocatorPath = "")
        {
        }
		
        public override void DoubleClick(string element, string additionalLocatorPath = "")
        {
        }
		
        public override string GetText(string element, string additionalLocatorPath = "")
        {
			return null;
        }

        public override string GetValue(string element, string additionalLocatorPath = "")
		{
			return null;
        }
		
        public override void MouseDown(string element)
        {
        }

        public override void MouseOver(string element)
        {            
        }

        public override void Open(string url)
        {
            this.Driver.Navigate().GoToUrl(url);
        }

        public override void Select(string element, string optionText, string additionalLocatorPath = "")
        {
        }
		
        public override void Type(string element, string value, string additionalLocatorPath = "")
        {
        }

        #endregion
    }
}