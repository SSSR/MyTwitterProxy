using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterProxy.Models;

namespace TwitterProxy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult History()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Twitter(TwitterRequest model)
        {
            return View();
        }

    }
}