using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace TestFramework.Extensions
{
	public class GenericExtensions
    {
		#region Type specific methods

		public virtual void ClearText(string element, string additionalLocatorPath = "")
		{
		}	

		public virtual void Click(string element, string additionalLocatorPath = "")
		{
		}
		
		public virtual void DoubleClick(string element, string additionalLocatorPath = "")
		{
		}
		
		public virtual string GetText(string element, string additionalLocatorPath = "")
		{
			return string.Empty;
		}		

		public virtual string GetValue(string element, string additionalLocatorPath = "")
		{
			return string.Empty;
		}
		
		public virtual void MouseDown(string element)
		{
		}

		public virtual void MouseOver(string element)
		{
		}

		public virtual void Open(string url)
		{
		}

		public virtual void Select(string element, string optionText, string additionalLocatorPath = "")
		{
		}

		public virtual void Type(string element, string value, string additionalLocatorPath = "")
		{
		}

		#endregion
    }
}
