using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamWeb.Service;
using TeamWeb.Models.Domain.PaperInfoDomain;
using TeamWeb.Models.Domain.UserInfoDomain;

namespace TeamWeb.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /index/
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult paperPage()
        //{
        //    IList<String> userList = new PaperInfoService().FindAllUserInfo();
        //    List<SelectListItem> list1 = new List<SelectListItem>();
        //    for (int i = 0; i < userList.Count; i++)
        //    {
        //    //    list1.Add(new SelectListItem { Text = userList[i].ToString(), Value = userList[i].ToString() });
        //    }            
        //    ViewBag.list1 = list1;
        //    List<SelectListItem> list2 = new List<SelectListItem>();
        //    list2.Add(new SelectListItem { Text = "中文文献", Value = "中文文献" });
        //    list2.Add(new SelectListItem { Text = "英文文献", Value = "英文文献" });
        //    list2.Add(new SelectListItem { Text = "专利", Value = "专利" });
        //    ViewBag.list2 = list2;
        //    return View();
        //}
        //public ActionResult projectPage()
        //{
        //    IList<String> userList = new PaperInfoService().FindAllUserInfo();
        //    List<SelectListItem> list1 = new List<SelectListItem>();
        //    for (int i = 0; i < userList.Count; i++)
        //    {
        //        list1.Add(new SelectListItem { Text = userList[i].ToString(), Value = userList[i].ToString() });
        //    }
        //    ViewBag.list1 = list1;
        //    List<SelectListItem> list2 = new List<SelectListItem>();
        //    list2.Add(new SelectListItem { Text = "软件", Value = "软件" });
        //    list2.Add(new SelectListItem { Text = "硬件", Value = "硬件" });
        //    list2.Add(new SelectListItem { Text = "系统", Value = "系统" });
        //    ViewBag.list2 = list2;
        //    List<SelectListItem> list3 = new List<SelectListItem>();
        //    list3.Add(new SelectListItem { Text = "军用", Value = "军用" });
        //    list3.Add(new SelectListItem { Text = "民用", Value = "民用" });
        //    ViewBag.list3 = list3;
        //    return View();
        //}
	}
}