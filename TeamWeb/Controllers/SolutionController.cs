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
    public class SolutionController : Controller
    {
        // GET: Solution
        public ActionResult solution()
        {
            return View();
        }
        public ActionResult theory()
        {
            return View();
        }
        public ActionResult ListType()
        {
            return Content(new SolutionService().ListType());
        }
        public ActionResult ListCont(string small, string big)
        {
            return Content(new SolutionService().ListCont(small, big));
        }
        public ActionResult ListYear(string papertype)
        {
            return Content(new SolutionService().ListYear(papertype));
        }
        public ActionResult listcontent(string year, string papertype, string type)
        {
            return Content(new SolutionService().listcontent(year, papertype, type));
        }
    }
}