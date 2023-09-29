using progettomvceEsame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace progettomvceEsame.Controllers
{
    public class ViolazioneController : Controller
    {
        // GET: Violazione
        public ActionResult Index()
        {
            return View(Violazione.tutteViolazioni());
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Violazione v)
        {

            if (ModelState.IsValid)
            { Violazione.CreaViolazione(v.descrizione); }
            return RedirectToAction("Index");
        }
    }
}