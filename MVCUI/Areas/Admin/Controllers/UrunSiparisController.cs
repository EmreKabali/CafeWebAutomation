using Model.Entities;
using Service.ClassOption;
using Service.MyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUI.Areas.Admin.Controllers
{
    public class UrunSiparisController : Controller
    {
        MasaService ms = new MasaService();
       
        UrunService us = new UrunService();
        AdisyonService svc = new AdisyonService();
        FisService fss = new FisService();
        Random rnd = new Random();
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        
        // GET: Admin/UrunSiparis
        public ActionResult Index(Masa _id)
        {

            
            Adisyon ads = new Adisyon();
            ads.MasaId = _id.ID;
            ads.siparis = rnd.Next();
            svc.Add(ads);
            Masa masa  =ms.GetById(_id.ID);
            masa.AdisyonId = ads.ID;
           
            
            


            return View(Tuple.Create(us.GetirListe(), masa));
        }

        public ActionResult addProduct(Urun _urun,Masa _adisyon)
        {
            try
            {
                logger.Info($"Siparis Ekleniyor: adison id: {_adisyon.AdisyonId}, Eklenen masa:{_adisyon.ID}");
                Adisyon yn = svc.GetByDefault(x => x.ID == _adisyon.AdisyonId);
                Urun urn = us.GetByDefault(x => x.ID == _urun.ID);

                if (urn.StokMiktari == 0 && urn == null)
                {

                    TempData["error"] = "Ürün stokta kalmadı veya eksik geldi.Kontrol ediniz.";

                    return View();
                }


                yn.UrunId = urn.ID;
                urn.StokMiktari = urn.StokMiktari - 1;
                if (urn.StokMiktari < 10)
                {
                    logger.Info($"Mail started:{urn.StokMiktari}");
                    MailPush.ToMail("Stok Azaldı", $"{urn.Ad},isimli ürün stok sayısı: {urn.StokMiktari} adet kalmıştır.Lütfen satın alma gerçekleştiriniz.");
                }
                svc.Add(yn);
                svc.Save();
                us.Save();
                Masa masa = ms.GetById(yn.MasaId);

                return View(Tuple.Create(us.GetirListe(), masa));
            }
            catch (Exception ex)
            {
                logger.Error($"Siparis addproduct failed : Detail:{ex}");
                throw;
            }
         
        }

        [HttpPost]
        public ActionResult addProduct()
        {

            

            return View(us.GetirListe());
        }

        public ActionResult Siparis(Masa _masa)
        {
            Masa x = ms.GetByDefault(a => a.ID == _masa.ID);

            List<Adisyon> aliste = svc.GetDefault(a => a.MasaId == x.ID);
            List<Adisyon> aktif = aliste.FindAll(a => a.Statu == Core.Entity.Enums.Status.Active);

            return View(Tuple.Create(aktif,us.GetirListe(),x));
        }

        public ActionResult Disable(Fis _masa)
        {
            Masa x = ms.GetByDefault(a => a.ID == _masa.ID);

            List<Adisyon> aliste = svc.GetDefault(a => a.MasaId == x.ID);
            
            aliste.Select(a => { a.Statu = Core.Entity.Enums.Status.Deleted; return a; }).ToList();
            Fis kapat = new Fis();
            kapat.OdemeSekli = _masa.OdemeSekli;
            kapat.toplamfiyat = _masa.toplamfiyat;
            
            fss.Add(kapat);
            fss.Save();

            svc.Save();
            TempData["odendi"] = "odendi";
            return RedirectToAction("Index","Home");
        }

        public ActionResult uruncikar(Masa id,Adisyon adisyon)
        {

            Adisyon deleteA = svc.GetByDefault(x => x.ID == adisyon.ID);
            Urun urn = us.GetByDefault(x => x.ID == deleteA.UrunId);
            urn.StokMiktari = urn.StokMiktari+1;
            deleteA.Statu = Core.Entity.Enums.Status.Deleted;
            us.Save();

            svc.Save();


            TempData["Urunİptal"] = "Urunİptal";
            return RedirectToAction("Index","Home");
        }

      
        
        

    }
}