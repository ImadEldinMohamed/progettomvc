using Microsoft.Ajax.Utilities;
using progettomvceEsame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace progettomvceEsame.Controllers
{
    public class AnagraficaController : Controller
    {
        public ActionResult Index()
        {
           
            return View(Anagrafica.tuttitrasgressori());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Anagrafica a)
        {

            if(ModelState .IsValid)
            { Anagrafica.CreaTrasgressore(a.cognome,a.nome,a.indirizzo,a.citta,a.cap,a.codicefiscale); }
            return RedirectToAction("Index");
        }

      

    }



}
     
    
