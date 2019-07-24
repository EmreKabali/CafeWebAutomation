using Service.ClassOption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUI.Areas.Admin.Controllers
{
    public class RaporController : Controller
    {
        AdisyonService ads = new AdisyonService();
        FisService fss = new FisService();
        // GET: Admin/Rapor
        public ActionResult Index()
        {


            return View(fss.GetirListe());
        }
    }
}