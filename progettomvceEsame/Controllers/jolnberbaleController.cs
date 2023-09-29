using progettomvceEsame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace progettomvceEsame.Controllers
{
    public class jolnberbaleController : Controller
    {
        // GET: jolnberbale
        public ActionResult Index()
        {
            return View(jolnberbale.conteggio());
        }
    }
}