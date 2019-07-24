using Model.Entities;
using MVCUI.SecurityLogin;
using NLog;
using Service.ClassOption;
using Service.MyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Model.Entities.Urun;

namespace MVCUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {

        private Logger logger = LogManager.GetCurrentClassLogger();
        UrunService us = new UrunService();
        
        KategoriService kt = new KategoriService();
        // GET: Admin/Product
        public ActionResult Index()
        {




            
            return View(us.GetirListe());
           
        }

        

        




        //Get
        public ActionResult Add()
        {


            return View(kt.GetirListe());
        }


        [HttpPost]
        public ActionResult Add(Urun _urun,HttpPostedFileBase image)
        {
            try
            {
                
                _urun.Resimyolu = ResimYukle.UploadSingleImage("~/img/", image);
                us.Add(_urun);
                us.Save();
                logger.Info($"Product added : Product name :{_urun.Ad}- Count:{_urun.StokMiktari}");

                TempData["message"] = "Added";


                return RedirectToAction("Index", "Product");
            }
            catch (Exception ex)
            {
                logger.Error($"Product Add Line:{ex}|Error|");

                throw ;
            }
            
        }

        public ActionResult Guncelle(Kategori _ıd)
        {
            try
            {
                
                Urun selecturun = us.GetByDefault(x => x.ID == _ıd.ID);
                logger.Info($"Start update product: Request product:{selecturun.Ad}");


                return View(selecturun);

            }
            catch (Exception ex)
            {
                logger.Error($"Product update failed:| Request product: {_ıd.ID} | Detail:{ex}");
                throw;
            }
          
        }

        [HttpPost]
        public ActionResult Guncelle(Urun uruns)
        {
            try
            {
                logger.Info($"Product update:| Update product name:{uruns.Ad}");
                us.Update(uruns);
                us.Save();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.Error($"Product update failed:Detail:{ex}");
                throw;
            }
           
        }

        //Silme 
        public ActionResult Delete(Urun urunp)
        {
            try
            {
                logger.Info($"Start product delete: Request product:{urunp.Ad},ID:{urunp.ID}");
                Urun urunn = us.GetByDefault(x => x.ID == urunp.ID);
                us.Remove(urunn.ID);
                TempData["deleted"] = "deleted";


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.Error($"Product deleted fail: Detail:{ex}");

                throw;
            }
         
        }

        public ActionResult StokArttir(Masa _urun)
        {
            Urun select = us.GetByDefault(x => x.ID == _urun.ID);
            
            return View(select);

        }


        [HttpPost]
        public ActionResult StokArttir(Urun urun)
        {

            us.Update(urun);
            us.Save();

            TempData["stock"] = "stock";

            return RedirectToAction("Index");
        }
        

        
    }
}