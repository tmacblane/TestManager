using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TestManager.Models;

namespace TestManager.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			Actions actions = new Actions();

			ViewData["Actions"] = actions.GetActionList();

			return View();
		}

		public ActionResult About()
		{
			return View();
		}
	}
}
