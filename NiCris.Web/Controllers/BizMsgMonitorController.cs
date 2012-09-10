using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NiCris.Web.Controllers
{
    public class BizMsgMonitorController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Your BizMsg Monitor page.";
            return View();
        }
    }
}
