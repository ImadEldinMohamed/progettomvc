using progettomvceEsame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace progettomvceEsame.Controllers
{
    public class VerbaleController : Controller
    {

        public List<SelectListItem> IDanagrafica
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                SelectListItem item = new SelectListItem { Text = "pippo", Value = "1" };
                SelectListItem item2 = new SelectListItem { Text = "topolino", Value = "2" };
                SelectListItem item3 = new SelectListItem { Text = "paperino", Value = "3" };

                list.Add(item);
                list.Add(item2);
                list.Add(item3);

                return list;
            }
        }

        public List<SelectListItem> IDviolazione
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                SelectListItem item = new SelectListItem { Text = "guida in stato di ebbrezza", Value = "1" };
                SelectListItem item2 = new SelectListItem { Text = "guida senza patente", Value = "2" };
                SelectListItem item3 = new SelectListItem { Text = "semaforo rosso", Value = "3" };

                list.Add(item);
                list.Add(item2);
                list.Add(item3);

                return list;
            }
        }


        // GET: Verbale
        public ActionResult Index()
        {
            return View(Verbale.tuttiVerbali());
        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Listanuovotrasgressore = IDanagrafica;
            ViewBag.Listanuovaviolazione = IDviolazione;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Verbale v)
        {
            if (ModelState.IsValid)
            { Verbale.CreaVerbale(v.dataviolazione,v.indirizzoViolazione,v.nominativo_agente,v.DataTrascrizioneVerbale,v.importo,v.DecurtamentoPunti,v.IDanagrafica,v.IDviolazione); }

            ViewBag.Listanuovotrasgressore = IDanagrafica;
            ViewBag.Listanuovaviolazione = IDviolazione;
            return RedirectToAction("Index");
        }


       
    }

}
