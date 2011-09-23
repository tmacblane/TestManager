using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace TestManager.Models
{
	public class Actions
	{
		public List<SelectListItem> GetActionList()
		{
			List<SelectListItem> actionList = new List<SelectListItem>();

			TestFramework.Extensions.GenericExtensions genericExtensions = new TestFramework.Extensions.GenericExtensions();

			MethodInfo[] methodInfos = typeof(TestFramework.Extensions.GenericExtensions).GetMethods();

			foreach(MethodInfo method in methodInfos)
			{
				if(method.Name != "Equals" && method.Name != "GetHashCode" && method.Name != "GetType" && method.Name != "ToString")
				{
					SelectListItem listItem = new SelectListItem();
					listItem.Text = System.Text.RegularExpressions.Regex.Replace(method.Name, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim();
					listItem.Value = method.Name;

					actionList.Add(listItem);	
				}
			}

			return actionList;
		}
	}
}