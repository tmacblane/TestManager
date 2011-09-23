using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace TestFramework.Common
{
	public class EnvironmentSettings
	{
		#region Fields

		public string localeEnvironment;
		public string browser;
		public string host;
		public int port;
		public string baseURL;
		public string vdeURL;
		public string timeout;
		public string testRunner;
		public string baseTestProjectDirectory;
		public bool logToDatabase;

		#endregion

		#region Constructors

		public EnvironmentSettings()
		{
			this.SetLocaleEnvironment();
			this.SetHost();
			this.SetPort();
			this.SetBrowser();
			this.SetBaseURL(this.localeEnvironment);
			this.SetVDEURL(this.localeEnvironment);
			this.SetTimeout();
			this.SetTestRunner();
			this.SetLocaleEnvironment();
			this.SetLogToDatabase();
		}

		#endregion

		#region Type specific methods

		/// <summary>
		/// Sets the local environment to be used for automated tests
		/// </summary>
		public void SetLocaleEnvironment()
		{
			XDocument environmentDocument = XDocument.Load("environmentSettings.xml");
			XElement environmentsNode = environmentDocument.Element("Configurations").Element("EnvironmentSettings");

			Common.localeEnvironment = environmentsNode.Element("Locale").Value;

			switch(Common.localeEnvironment)
			{
				case "US":
					this.localeEnvironment = "US";
					break;

				case "UK":
					this.localeEnvironment = "UK";
					break;

				default:
					this.localeEnvironment = "US";
					break;
			}
		}

		/// <summary>
		/// Sets the host of the Selenium Remote Control
		/// </summary>
		public void SetHost()
		{
			XDocument environmentDocument = XDocument.Load("environmentSettings.xml");
			XElement environmentsNode = environmentDocument.Element("Configurations");

			this.host = environmentsNode.Element("SeleniumRCSettings").Element("Host").Value;
		}

		/// <summary>
		/// Sets the port of the Selenium Remote Control
		/// </summary>
		public void SetPort()
		{
			XDocument environmentDocument = XDocument.Load("environmentSettings.xml");
			XElement environmentsNode = environmentDocument.Element("Configurations");

			this.port = Convert.ToInt16(environmentsNode.Element("SeleniumRCSettings").Element("Port").Value);
		}

		/// <summary>
		/// Sets the browser to be used for testing
		/// </summary>
		public void SetBrowser()
		{
			XDocument environmentDocument = XDocument.Load("environmentSettings.xml");
			XElement environmentsNode = environmentDocument.Element("Configurations");

			Common.webBrowser = environmentsNode.Element("EnvironmentSettings").Element("Browser").Value;

			switch(Common.webBrowser)
			{
				case "GoogleChrome":
					this.browser = environmentsNode.Element("Browsers").Element(Common.webBrowser).Value;
					break;

				case "Firefox":
					this.browser = environmentsNode.Element("Browsers").Element(Common.webBrowser).Value;
					break;

				case "InternetExplorer8":
					this.browser = environmentsNode.Element("Browsers").Element(Common.webBrowser).Value;
					break;

				case "InternetExplorer9":
					this.browser = environmentsNode.Element("Browsers").Element(Common.webBrowser).Value;
					break;

				case "SauceLabs":
					this.browser = environmentsNode.Element("Browsers").Element(Common.webBrowser).Value;
					break;

				case "RemoteWebDriver":
					this.browser = environmentsNode.Element("Browsers").Element(Common.webBrowser).Value;
					break;

				default:
					this.browser = "Firefox";
					break;
			}
		}

		/// <summary>
		/// Method for setting the URL based on the specified locale environment.
		/// </summary>
		public void SetBaseURL(string localeEnvironment)
		{
			XDocument environmentDocument = XDocument.Load("environmentSettings.xml");
			XElement environmentsNode = environmentDocument.Element("Configurations").Element("EnvironmentSettings");

			string instance = environmentsNode.Element("Instance").Value;
			string testEnvironment = environmentsNode.Element("Environment").Value;
			string virtualDirectory = environmentsNode.Element("VirtualDirectory").Value;

			if(testEnvironment != string.Empty)
			{
				testEnvironment = "." + testEnvironment;
			}

			switch(localeEnvironment)
			{
				case "US":
					this.baseURL = string.Format("http://{0}{1}.mimeo.com/{2}", instance, testEnvironment, virtualDirectory);
					break;

				case "UK":
					this.baseURL = string.Format("http://{0}{1}.mimeo.co.uk/{2}", instance, testEnvironment, virtualDirectory);
					break;
			}
		}

		/// <summary>
		/// Sets the VDE URL of the site under test determined by the locale environment of the test suite
		/// </summary>
		public void SetVDEURL(string localeEnvironment)
		{
			this.vdeURL = string.Empty;
		}

		/// <summary>
		/// Sets the default timeout for the Selenium Remote Control actions
		/// </summary>
		public void SetTimeout()
		{
			XDocument environmentDocument = XDocument.Load("environmentSettings.xml");
			XElement environmentsNode = environmentDocument.Element("Configurations");

			this.timeout = environmentsNode.Element("SeleniumRCSettings").Element("Timeout").Value;
		}

		/// <summary>
		/// Sets the test runner for the automated test suite
		/// </summary>
		/// <returns></returns>
		public void SetTestRunner()
		{
			XDocument environmentDocument = XDocument.Load("environmentSettings.xml");
			XElement environmentsNode = environmentDocument.Element("Configurations");

			this.testRunner = environmentsNode.Element("EnvironmentSettings").Element("TestRunner").Value;
		}


		public void SetLogToDatabase()
		{
			XDocument environmentDocument = XDocument.Load("environmentSettings.xml");
			XElement environmentsNode = environmentDocument.Element("Configurations");

			this.logToDatabase = Convert.ToBoolean(environmentsNode.Element("EnvironmentSettings").Element("LogToDatabase").Value);
		}

		#endregion
	}
}