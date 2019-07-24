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
    public class KullaniciController : Controller
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        UserService us = new UserService();
        // GET: Admin/Kullanici
        public ActionResult Index()
        {
            logger.Info("Started:Kullanici Controller");
            return View(us.GetirListe());
        }


        public ActionResult Add()
        {



            return View();
        }

        [HttpPost]
        public ActionResult Add(User _user)
        {
            try
            {
                User user = _user;

                us.Add(user);
                us.Save();

                logger.Info($"{user.Adi}: user added. | User info:{user.Email}:{user.KullaniciRolu}:{user.Statu}");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                logger.Error($"Kullanıcı Controller failed| Line | {ex} |Error|");

                throw;
            }
          

        }

        
        public ActionResult Pasif(User user)
        {
            try
            {
                logger.Info($"User passive started|Request user:{user.Email}");
                User ddd = us.GetById(user.ID);
                ddd.Statu = Core.Entity.Enums.Status.Deleted;
                us.Update(ddd);
                us.Save();

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                logger.Error($"User passive failed| error user:{user.Email} | Detail:{ex}");

                throw;
            }
           
        }

        public ActionResult Delete(User user)
        {
            try
            {
                logger.Info($"User Deleted start:request user:{user.Email}");
                User ddd = us.GetById(user.ID);
                ddd.IsDeleted = Core.Entity.Enums.IsDeleted.delete;
                us.Update(ddd);
                us.Save();
            }
            catch (Exception ex)
            {
                logger.Error($"User deleted failed| error user:{user.Email}| Detail:{ex}");
                throw;
            }
           

            return RedirectToAction("Index");
        }

            
       
    }
}