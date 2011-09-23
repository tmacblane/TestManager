using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Reflection;

namespace TestFramework.Common
{
	public class LocatorReader
	{
		#region Fields

		private XDocument readerDocument;

		#endregion

		#region Constructors

		public LocatorReader(string xmlReaderFile)
		{
			this.readerDocument = XDocument.Load(xmlReaderFile);
		}

		public LocatorReader(string applicationName, string xmlReaderFile)
		{
			Assembly asm = Assembly.GetExecutingAssembly();

			this.readerDocument = XDocument.Load(asm.GetManifestResourceStream("TestFramework.Applications." + applicationName + ".Locators." + xmlReaderFile));
		}

		#endregion

		#region Type specific methods

		/// <summary>
		/// Gets the value of the locator
		/// </summary>
		public string GetLocator(string nodePath)
		{
			string result = string.Empty;

			XElement locatorRootNode = this.readerDocument.Element("Locators");

			XElement locatorElement = locatorRootNode.XPathSelectElement(this.ConvertToXPath(nodePath));

			result = locatorElement.Value;

			return result;
		}

		#endregion

		#region Helper methods

		/// <summary>
		/// Converts the locator string to XPath
		/// </summary>
		private string ConvertToXPath(string locatorPath)
		{
			string nodePath = "//" + locatorPath.Replace(".", "/");

			return nodePath;
		}

		#endregion
	}
}
