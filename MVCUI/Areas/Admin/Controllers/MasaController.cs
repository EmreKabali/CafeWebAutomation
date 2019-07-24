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
    public class MasaController : Controller
    {
        private NLog.Logger logger = LogManager.GetCurrentClassLogger();

        MasaService ms = new MasaService();
        // GET: Admin/Masa
        public ActionResult Index()
        {
            logger.Info("Masa Service started");
            return View(ms.GetirListe());
        }

        public ActionResult AddMasa()
        {


            return View();
        }



        [HttpPost]
        public ActionResult AddMasa(Masa _masa)
        {
            if (ModelState.IsValid)
            {
                if (_masa == null)
                {
                    logger.Error($"{_masa} is empty|Error|");
                }
                else
                {
                    var karar = ms.Any(x => x.Not == _masa.Not);
                    if (!karar)
                    {
                        ms.Add(_masa);
                        ms.Save();
                        logger.Info($"{_masa.Not}:isimli masa eklendi-MasaID: {_masa.ID}");
                        TempData["added"] = "added";
                        return RedirectToAction("Index", "Masa");
                    }
                    else
                    {
                        logger.Error($"{_masa.Not}:isimli bir masa bulunmaktadır.|Error|");
                        return View(TempData["hata"] = "Eklediğiniz isimde masa bulunmaktadır.Farklı bir isim ile yeniden deneyiniz.");
                    }
                }


                return View("AddMasa",_masa);
            }
            else
            {
                return View();
            }
           

            
        }
        public ActionResult deletedMasa(Masa _masa)
        {

            Masa deleted = ms.GetByDefault(x => x.ID == _masa.ID);
            ms.Delete(deleted.ID);

            TempData["delete"] = "delete";
            return RedirectToAction("Index");
        }





    }
}