using Model.Entities;
using MVCUI.SecurityLogin;
using NLog;
using Service.ClassOption;
using Service.MyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCUI.Areas.Garson.Controllers
{
    public class HomeController : Controller
    {
        private NLog.Logger logger = LogManager.GetCurrentClassLogger();
        MasaService ms = new MasaService();
        UrunService us = new UrunService();
        AdisyonService ads = new AdisyonService();
        
        // GET: Garson/Home
        public ActionResult Index(LoginUser kullanici)
        {
            
            
            logger.Info("MasaService Started: Adisyon get Status Active: Urun get Isdeleted Active");

            

            return View(Tuple.Create(ms.GetirListe(), ads.GetDefault(x => x.Statu == Core.Entity.Enums.Status.Active), us.GetirListe(),kullanici));
        }

        //Garsonun ekstra durumlarda kasaya mail gönderdiği alan
        public ActionResult mesaj(String Mesaj)
        {
            logger.Info("Garson message is sending|");
            MailPush.ToMail("Garsondan Mesaj", Mesaj);


            return RedirectToAction("Index");
        }
    }
}