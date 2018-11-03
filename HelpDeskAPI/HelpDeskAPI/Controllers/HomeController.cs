using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDeskAPI.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";

			return View();
		}
		public ActionResult HelpDeskAgent()
		{
			ViewBag.Title = "HelpDeskAgent";

			return View();
		}
		public ActionResult Add()
		{
			ViewBag.Title = "HelpDeskAgent";

			return View();
		}
		
	}
}
