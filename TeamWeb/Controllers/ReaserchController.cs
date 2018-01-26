using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamWeb.Service;
using TeamWeb.Models.Domain.UserDomain;
using System.Net.Mail;
using System.Net;

namespace TeamWeb.Controllers
{
    public class ReaserchController : Controller
    {
        // GET: Reaserch
        public ActionResult reaserch()
        {
            return View();
        }
        public ActionResult ListReaserch()
        {
            return Content(new ReaserchService().ListReaserch());
        }
    }
}