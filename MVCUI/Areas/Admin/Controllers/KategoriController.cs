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
    public class KategoriController : Controller
    {
        private NLog.Logger logger = LogManager.GetCurrentClassLogger();
        KategoriService kt = new KategoriService();
        
        // GET: Admin/Kategori
        public ActionResult Index()
        {
            logger.Info("Category controller debugging");
            return View(kt.GetirListe());
        }

        

        [HttpPost]
        public ActionResult Index2(Kategori _kategori)
        {
            if (_kategori==null)
            {
                logger.Error("Category parameter is null");
                TempData["error"] = "Category is null";

                return View("Index");

            }
            else
            {
                if (kt.Any(x => x.KategoriAdı == _kategori.KategoriAdı))
                {
                    logger.Error("Girilen isimde kategori bulunmaktadır");
                    TempData["error2"] = "Farklı bir isimde kategori deneyiniz";
                    return View("Index");
                }
                else
                {
                    kt.Add(_kategori);
                    kt.Save();
                }
               
            }
           


            return View();



        }
        
    }
}