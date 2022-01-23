using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HostelSuggestionSystem_WE.Controllers
{
    public class HostelsController : Controller
    {
        // GET: Hostels
        public ActionResult Index()
        {
            return View();
        }
    }
}