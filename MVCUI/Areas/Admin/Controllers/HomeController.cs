using Model.Entities;
using NLog;
using Service.ClassOption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private NLog.Logger logger = LogManager.GetCurrentClassLogger();

        MasaService ms = new MasaService();
        UrunService us = new UrunService();
        AdisyonService ads = new AdisyonService();
        
        // GET: Admin/Home
        public ActionResult Index(User kullanici)
        {
            logger.Info("MasaService Started: Adisyon get Status Active: Urun get Isdeleted Active");
           

            return View(Tuple.Create(ms.GetirListe(),ads.GetDefault(x=>x.Statu==Core.Entity.Enums.Status.Active),us.GetirListe(),kullanici));//Adisyon döneceğimiz zaman statusu active olacak,hesabı kapatılan adisyonun statüsü deletede çekilecek
        }

        //Siparişlerin listelendiği nokta
      

       public ActionResult modal()
        {


            return PartialView();
        }
        

        [HttpPost]
        public ActionResult modal(Adisyon ads)
        {


            return View();
        }
    }
}