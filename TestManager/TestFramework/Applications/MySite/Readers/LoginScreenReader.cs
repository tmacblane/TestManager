using System;

using TestFramework.Common;
using TestFramework.Extensions;

namespace TestFramework.Applications.MySite.Readers
{
	/// <summary>
	/// Gets the Reader class for all elements on the main login screen.
	/// </summary>
	public class LoginScreenReader
	{
		#region Fields

		private LocatorReader loginScreenReader;

		private string application = "MySite"; // Application name for the embedded xml files

		#endregion

		#region Constructors

		public LoginScreenReader()
		{
			this.loginScreenReader = new LocatorReader(this.application, "LoginScreen.xml");
		}

		#endregion

		#region Type specific properties

		/// <summary>
		/// Gets the email address textbox
		/// </summary>
		public string Email_Address_Textbox
		{
			get
			{
				return this.loginScreenReader.GetLocator("LoginPanel.EmailAddressTextbox");
			}
		}

		/// <summary>
		/// Gets the Error image for a missing email address
		/// </summary>	
		public string Email_Address_Missing_Error_Image
		{
			get
			{
				return this.loginScreenReader.GetLocator("LoginPanel.EmailAddressMissingErrorImage");
			}
		}

		/// <summary>
		/// Gets the Hover over text for the error image when an email address has not been entered
		/// </summary>
		public string Email_Address_Missing_Error_Image_Text
		{
			get
			{
				return this.loginScreenReader.GetLocator("LoginPanel.EmailAddressMissingErrorImageText");
			}
		}

		/// <summary>
		/// Gets the Error image for an incorrectly entered email address		
		/// </summary>
		public string Email_Address_Incorrect_Error_Image
		{
			get
			{
				return this.loginScreenReader.GetLocator("LoginPanel.EmailAddressIncorrectErrorImage");
			}
		}

		/// <summary>
		/// Gets the Hover over text for the error image when an email address has been entered incorrectly
		/// </summary>
		public string Email_Address_Incorrect_Error_Image_Text
		{
			get
			{
				return this.loginScreenReader.GetLocator("LoginPanel.EmailAddressIncorrectErrorImageText");
			}
		}

		/// <summary>
		/// Gets the Password textbox		
		/// </summary>
		public string Password_Textbox
		{
			get
			{
				return this.loginScreenReader.GetLocator("LoginPanel.PasswordTextbox");
			}
		}

		/// <summary>
		/// Gets the Error image for a missing password	
		/// </summary>	
		public string Password_Missing_Error_Image
		{
			get
			{
				return this.loginScreenReader.GetLocator("LoginPanel.PasswordMissingErrorImage");
			}
		}

		/// <summary>
		/// Gets the Hover over text for the error image when a password has not been entered	
		/// </summary>	
		public string Password_Missing_Error_Image_Text
		{
			get
			{
				return this.loginScreenReader.GetLocator("LoginPanel.PasswordMissingErrorImageText");
			}
		}

		/// <summary>
		/// Gets the Login button	
		/// </summary>	
		public string Login_Button
		{
			get
			{
				return this.loginScreenReader.GetLocator("LoginPanel.LoginButton");
			}
		}

		/// <summary>
		/// Gets the Forgot password link		
		/// </summary>
		public string Forgot_Password_Link
		{
			get
			{
				return this.loginScreenReader.GetLocator("LoginPanel.ForgotPasswordLink");
			}
		}

		/// <summary>
		/// Gets the Sign up now link
		/// </summary>	
		public string Sign_Up_Now_Link
		{
			get
			{
				return this.loginScreenReader.GetLocator("LoginPanel.SignUpNowLink");
			}
		}		

		/// <summary>
		/// Gets the Contact us link	
		/// </summary>	
		public string Contact_Us_Link
		{
			get
			{
				return this.loginScreenReader.GetLocator("ContactUsLink");
			}
		}

		/// <summary>
		/// Gets the Show and Hide all messages link	
		/// </summary>	
		public string Show_Hide_Messages_Link
		{
			get
			{
				return this.loginScreenReader.GetLocator("MessagePanel.ShowHideMessagesLink");
			}
		}

		/// <summary>
		/// Gets the Show all messages link
		/// </summary>
		public string Show_Messages_Link
		{
			get
			{
				return this.loginScreenReader.GetLocator("MessagePanel.ShowMessagesLink");
			}
		}

		/// <summary>
		/// Gets the Hide all messages link
		/// </summary>
		public string Hide_Messages_Link
		{
			get
			{
				return this.loginScreenReader.GetLocator("MessagePanel.HideMessagesLink");
			}
		}

		#endregion
	}
}