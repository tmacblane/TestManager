using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using TestFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;
using Selenium;

namespace TestFramework.Common
{
	public class WebBrowser
	{
		#region Fields

		public EnvironmentSettings environment;
		// public UserAccounts userData;
		private FirefoxProfile _ffp;
		DesiredCapabilities capabilities;

		#endregion

		#region Constructors

		public WebBrowser()
		{
			this.environment = new EnvironmentSettings();
			// this.userData = new UserAccounts();			
		}

		#endregion

		#region Type specific methods

		/// <summary>
		/// Launches the Selenium RC and browser specified in the Environments.cs file
		/// </summary>
		public ISelenium LaunchBrowser(ISelenium browser)
		{
			browser = new DefaultSelenium(this.environment.host, this.environment.port, this.environment.browser, this.environment.baseURL);
			browser.Start();
			browser.SetTimeout(this.environment.timeout);
			browser.WindowMaximize();
			browser.WindowFocus();

			return browser;
		}

		/// <summary>
		/// Launches the Selenium WebDriver driven browser specified in the Environments.cs file
		/// </summary>
		public IWebDriver LaunchBrowser(IWebDriver driver)
		{			
			switch(this.environment.browser)
			{
				case "*firefox":
					_ffp = new FirefoxProfile();
					_ffp.AcceptUntrustedCertificates = true;
					driver = new FirefoxDriver(_ffp);
					break;
				case "*iexplore":
					driver = new InternetExplorerDriver();
					break;
				case "*googlechrome":
					driver = new ChromeDriver();
					break;
				case "Android":
					capabilities = new DesiredCapabilities("android", "", null);
					capabilities.IsJavaScriptEnabled = true;
					driver = new RemoteWebDriver(new Uri(string.Format("http://{0}:{1}/hub", environment.host, environment.port)), capabilities);
					break;
				case "RemoteWebDriver":
					capabilities = DesiredCapabilities.Firefox();
					var remoteAddress = new Uri(string.Format("http://{0}:{1}/wd/hub", environment.host, environment.port));
					driver = new RemoteWebDriver(remoteAddress, capabilities);
					break;
			}

			return driver;
		}

		#endregion
	}
}