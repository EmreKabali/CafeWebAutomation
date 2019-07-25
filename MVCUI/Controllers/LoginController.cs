using Core.Entity.Enums;
using Model.Entities;
using MVCUI.SecurityLogin;
using MVCUI.Validation.FluentValidation;
using NLog;
using Service.ClassOption;
using Service.MyService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCUI.Controllers
{
    public class LoginController : Controller
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        UserService us;
        LoginUser log = new LoginUser();


        public LoginController()
        {
            logger.Debug("UserLogin Debug");
            
             us = new UserService();
        }

       
        // GET: Login
        public ActionResult Index()
        {



            return View();
        }

       
        [HttpPost]
        public ActionResult Index(LoginVM _user)
        {
           
                if (_user == null)
                {
                    logger.Error("Kullanıcı girişi yapılmadı");
                    TempData["error"] = "Lütfen Giriş Yapınız";
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    User kullanici = us.GetByDefault(x => x.Email == _user.Email && x.Sifre == _user.Password);
                    if (kullanici == null)
                    {
                        logger.Error($"Sistemde böyle bir kullanıcı bulunamadı.Girilen kullanıcı maili:{_user.Email} ");
                        TempData["error2"] = "Lütfen Giriş Yapınız";
                        return View("Index");
                    }
                    else
                    {
                        if (kullanici.KullaniciRolu == Roles.Admin)
                        {
                        log.Adi = kullanici.Adi;
                        TempData["login"] = "Hoşgeldin";
                            return RedirectToAction("Index", "Admin/Home",log);
                        }
                        else if (kullanici.KullaniciRolu==Roles.Garson)
                        {
                        log.Adi = kullanici.Adi;
                         TempData["login"] = "Hoşgeldin";
                         return RedirectToAction("Index","Garson/Home",log);


                        }

                    }
                }

            

            
              
               



               

           
            return View();

        }

       
    }
}