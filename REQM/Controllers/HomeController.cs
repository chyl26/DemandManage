using REQM.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace REQM.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authentication]
        public ActionResult Index()
        {
            return View();
        }
    }
}