using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamWeb.Service;
using TeamWeb.Models.Domain.PaperInfoDomain;
using TeamWeb.Models.Domain.UserInfoDomain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace TeamWeb.Controllers
{
    public class PaperController : Controller
    {
        // GET: Paper
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult USERINFO()
        //{
        //    IList<String> userList = new PaperInfoService().FindAllUserInfo();
        //    ViewBag.list1 = userList;
            
            
        //}
        public ActionResult SavePaper()
        {
            string path = "";
          
            bool isExist = false;
            var paperType = Request["paperType"];
            var paperYear = Request["paperYear"];
            var paperName = Request["paperName"];
            var PAPERAUTHOR = Request["PAPERAUTHOR"];
            var PAPERDESCRIBE = Request["PAPERDESCRIBE"];
            PaperInfo paperInfo = new PaperInfo();
            paperInfo.PAPERAUTHOR = PAPERAUTHOR;
            
            paperInfo.PAPERDESCRIBE = PAPERDESCRIBE;
            paperInfo.PAPERNAME = paperName;
            paperInfo.PAPERYEAR =Convert.ToInt32(paperYear.Substring(0, 4));                     
            paperInfo.UPLOADTIME = DateTime.Now.ToString();
            paperInfo.PAPERTYPE=paperType;
            try
            {
                Random r = new Random(100);
                foreach (string file1 in Request.Files)
                {
                    string realpath = String.Empty;
                    HttpPostedFileBase file = Request.Files[file1] as HttpPostedFileBase;
                    path = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-ffff") + r.Next();
                    //if (file != null && file.ContentLength > 0)
                    {
                        realpath = Server.MapPath("../Content/PaperInfo/" + path + ".pdf");                                     
                        file.SaveAs(realpath);
                        paperInfo.PAPERADDRESS = path + ".pdf";
                    }
                }
            }
            catch (Exception e)
            {            
                return Content("<script>alert('论文上传失败');history.go(-1);</script>");
            }
            try
            {
                isExist = new PaperInfoService().SavePaperInfo(paperInfo);
                if (isExist)
                    return Content("<script>alert('提交成功');history.go(-1);</script>");
                else
                    return Content("<script>alert('提交失败');history.go(-1);</script>");
            }
            catch (Exception e)
            {
                return Content("<script>alert('提交失败');history.go(-1);</script>");
            }
            
        }
    }
}