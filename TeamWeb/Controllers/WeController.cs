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
    public class WeController : Controller
    {
        // GET: We
        public ActionResult about()
        {
            return View();
        }
        public ActionResult contact()
        {
            return View();
        }
        public ActionResult join()
        {
            return View();
        }
        public ActionResult ListTeacher()
        {
            return Content(new WeService().ListTeacher());
        }
        public ActionResult ListStudent(string graduate)
        {
            return Content(new WeService().ListStudent(graduate));
        }
    }
}