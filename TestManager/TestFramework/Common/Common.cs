using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;

using TestFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;

namespace TestFramework.Common
{
	public class Common
	{
		#region Type specific properties

		public static string webBrowser
		{
			get;
			set;
		}

		public static string localeEnvironment
		{
			get;
			set;
		}

		#endregion

		#region Type specific methods

		/// <summary>
		/// Returns an element found by its cascading stylesheet (CSS) selector.
		/// </summary>
		public static IWebElement GetElementByCSS(IWebDriver driver, string element, string additionalLocatorPath = "")
		{
			element = element.Replace("css=", string.Empty);

			return driver.FindElement(By.CssSelector(string.Format(element, additionalLocatorPath)));
		}

		/// <summary>
		/// Returns a list of elements by their cascading stylesheet (CSS) selector.
		/// </summary>
		/// <returns></returns>
		public static IList<IWebElement> GetElementsByCSS(IWebDriver driver, string element, string additionalLocatorPath = "")
        {
			element = element.Replace("css=", string.Empty);

			IList<IWebElement> elements = driver.FindElements(By.CssSelector(string.Format(element, additionalLocatorPath)));

			return elements;
		}

		/// <summary>
		/// Returns an element found by its ID.
		/// </summary>
		public static IWebElement GetElementByID(IWebDriver driver, string element, string additionalLocatorPath = "")
		{
			return driver.FindElement(By.Id(string.Format(element, additionalLocatorPath)));
		}

		/// <summary>
		/// Returns a list of elements by their ID.
		/// </summary>
		/// <returns></returns>
		public static IList<IWebElement> GetElementsByID(IWebDriver driver, string element, string additionalLocatorPath = "")
		{
			IList<IWebElement> elements = driver.FindElements(By.Id(string.Format(element, additionalLocatorPath)));

			return elements;
		}

		/// <summary>
		/// Returns an element found by its XPath query.
		/// </summary>
		public static IWebElement GetElementByXPath(IWebDriver driver, string element, string additionalLocatorPath = "")
		{
			return driver.FindElement(By.XPath(string.Format(element, additionalLocatorPath)));
		}

		/// <summary>
		/// Returns a list of elements by their XPath.
		/// </summary>
		/// <returns></returns>
		public static IList<IWebElement> GetElementsByXPath(IWebDriver driver, string element, string additionalLocatorPath = "")
		{
			IList<IWebElement> elements = driver.FindElements(By.XPath(string.Format(element, additionalLocatorPath)));

			return elements;
		}

		/// <summary>
		/// Returns an element found by either CSS, ID or XPath based on the locator file.
		/// </summary>
		public static IWebElement GetElement(IWebDriver driver, string element, string additionalLocatorPath = "")
		{
			if(element.StartsWith("//"))
			{
				return GetElementByXPath(driver, element, additionalLocatorPath);
			}
			else if(element.StartsWith("css"))
			{
				return GetElementByCSS(driver, element, additionalLocatorPath);
			}
			else
			{
				return GetElementByID(driver, element, additionalLocatorPath);
			}	
		}

		/// <summary>
		/// Returns a list of elements found by either CSS, ID or XPath based on the locator file.
		/// </summary>
		public static IList<IWebElement> GetElements(IWebDriver driver, string element, string additionalLocatorPath = "")
		{
			if(element.StartsWith("//"))
			{
				return GetElementsByXPath(driver, element, additionalLocatorPath);
			}
			else if(element.StartsWith("css"))
			{
				return GetElementsByCSS(driver, element, additionalLocatorPath);
			}
			else
			{
				return GetElementsByID(driver, element, additionalLocatorPath);
			}
		}		

		/// <summary>
		/// Returns an element found by its cascading stylesheet (CSS) selector.
		/// </summary>
		public static IWebElement GetElementByCSS(IWebDriver driver, LocatorReader reader, string locatorPath, string additionalLocatorPath = "")
		{
			locatorPath = locatorPath.Replace("css=", string.Empty);

			return driver.FindElement(By.CssSelector(string.Format(reader.GetLocator(locatorPath), additionalLocatorPath)));
		}

		/// <summary>
		/// Returns a list of elements by their cascading stylesheet (CSS) selector.
		/// </summary>
		/// <returns></returns>
		public static IList<IWebElement> GetElementsByCSS(IWebDriver driver, LocatorReader reader, string locatorPath, string additionalLocatorPath = "")
		{
			locatorPath = locatorPath.Replace("css=", string.Empty);

			IList<IWebElement> elements = driver.FindElements(By.CssSelector(string.Format(reader.GetLocator(locatorPath), additionalLocatorPath)));

			return elements;
		}

		/// <summary>
		/// Returns an element found by its ID.
		/// </summary>
		public static IWebElement GetElementByID(IWebDriver driver, LocatorReader reader, string locatorPath, string additionalLocatorPath = "")
		{
			return driver.FindElement(By.Id(string.Format(reader.GetLocator(locatorPath), additionalLocatorPath)));
		}

		/// <summary>
		/// Returns a list of elements by their ID.
		/// </summary>
		/// <returns></returns>
		public static IList<IWebElement> GetElementsByID(IWebDriver driver, LocatorReader reader, string locatorPath, string additionalLocatorPath = "")
		{
			IList<IWebElement> elements = driver.FindElements(By.Id(string.Format(reader.GetLocator(locatorPath), additionalLocatorPath)));

			return elements;
		}

		/// <summary>
		/// Returns an element found by its XPath query.
		/// </summary>
		public static IWebElement GetElementByXPath(IWebDriver driver, LocatorReader reader, string locatorPath, string additionalLocatorPath = "")
		{
			return driver.FindElement(By.XPath(string.Format(reader.GetLocator(locatorPath), additionalLocatorPath)));
		}

		/// <summary>
		/// Returns a list of elements by their ID.
		/// </summary>
		/// <returns></returns>
		public static IList<IWebElement> GetElementsByXPath(IWebDriver driver, LocatorReader reader, string locatorPath, string additionalLocatorPath = "")
		{
			IList<IWebElement> elements = driver.FindElements(By.XPath(string.Format(reader.GetLocator(locatorPath), additionalLocatorPath)));

			return elements;
		}

		/// <summary>
		/// Returns an element found by either CSS, ID or XPath based on the locator file.
		/// </summary>
		public static IWebElement GetElement(IWebDriver driver, LocatorReader reader, string locatorPath, string additionalLocatorPath = "")
		{
			if(reader.GetLocator(locatorPath).StartsWith("//"))
			{
				return GetElementByXPath(driver, reader, locatorPath, additionalLocatorPath);
			}
			else if(reader.GetLocator(locatorPath).StartsWith("css"))
			{
				return GetElementByCSS(driver, reader, locatorPath, additionalLocatorPath);
			}
			else
			{
				return GetElementByID(driver, reader, locatorPath, additionalLocatorPath);
			}
		}

		/// <summary>
		/// Returns a list of elements found by either CSS, ID or XPath based on the locator file.
		/// </summary>
		public static IList<IWebElement> GetElements(IWebDriver driver, LocatorReader reader, string locatorPath, string additionalLocatorPath = "")
		{
			if(reader.GetLocator(locatorPath).StartsWith("//"))
			{
				return GetElementsByXPath(driver, reader, locatorPath, additionalLocatorPath);
			}
			else if(reader.GetLocator(locatorPath).StartsWith("css"))
			{
				return GetElementsByCSS(driver, reader, locatorPath, additionalLocatorPath);
			}
			else
			{
				return GetElementsByID(driver, reader, locatorPath, additionalLocatorPath);
			}
		}

		#endregion
	}
}
