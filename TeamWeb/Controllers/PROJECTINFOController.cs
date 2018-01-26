using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using TeamWeb.Models.Domain.ProjectInfoDomain;
using TeamWeb.Models.Domain.UserInfoDomain;
using Newtonsoft.Json;
using TeamWeb.Service;
using Newtonsoft.Json.Linq;

namespace TeamWeb.Controllers
{
    public class PROJECTINFOController : Controller
    {
        // GET: PROJECTINFO
      
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult TestList()
        {
              IList<String> userList = new PaperInfoService().FindAllUserInfo();
         
            JsonResult json = new JsonResult
            {
                Data = userList
            };
            return Json(json);
            //return Json(json, JsonRequestBehavior.AllowGet);//前台AJAX如果是GET用这句
            //什么时候用GET请求呢，当我们直接在浏览器中输入网址时，其实就是一个GET请求
            //如果我们直接输入/Home/TestList这个网址，它会提示我们下载这个JSON格式的文档
        }
        public ActionResult SaveProjectInfo()
        {
            string path = "";
            bool isExist = false;
            var PROJECTNAME = Request["PROJECTNAME"];
            var PROJECTBIGCLASS = Request["PROJECTBIGCLASS"];
            var PROJECTSMALLCLASS = Request["PROJECTSMALLCLASS"];
            var PROJECTMANAGER = Request["PROJECTMANAGER"];
            var PROJECTGROUPER = Request["PROJECTGROUPER"];

           

            var PROJECTMEMBER = Request["Jszzdm"];
            var PROJECTSTART = Request["PROJECTSTART"];
            var PROJECTEND = Request["PROJECTEND"];
            var PROJECTPAGE = Request["PROJECTPAGE"];
            ProjectInfo projectInfo = new ProjectInfo();
            projectInfo.PROJECTBIGCLASS = PROJECTBIGCLASS;
            projectInfo.PROJECTEND =Convert.ToDateTime(PROJECTEND);
            projectInfo.PROJECTMANAGER = PROJECTMANAGER;
            projectInfo.PROJECTMEMBER = PROJECTMEMBER;
            projectInfo.PROJECTNAME = PROJECTNAME;
            projectInfo.PROJECTPAGE = PROJECTPAGE;
            projectInfo.PROJECTSMALLCLASS = PROJECTSMALLCLASS;
            projectInfo.PROJECTSTART = Convert.ToDateTime(PROJECTSTART); ;
            projectInfo.PROJECTGROUPER = PROJECTGROUPER;
            try
            {

                //上传照片
                //其实就是cnt=1
                //int cnt = Request.Files.Count;
                //string fileExt = "";
                //Random r = new Random(100);
                //for (int i = 0; i < cnt; i++)
                //{
                //    HttpPostedFileBase hpf = Request.Files[i];
                //    fileExt = Path.GetExtension(hpf.FileName).ToLower();//带.的后缀
                //    string fileFilt = ".jpg|.png|.JPG|.PNG|......";
                //    if ((fileFilt.IndexOf(fileExt) <= -1) || (fileExt == "") || (hpf.ContentLength > 4 * 1024 * 1024))
                //        continue;
                //    path = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-ffff") + r.Next();
                //    string filepath = Server.MapPath("../Content/Images/projectImage/" + path + fileExt);
                //    hpf.SaveAs(filepath);
                //    projectInfo.PROJECTIMAGE = path + fileExt;
                //}

                string fileExt = "";
                Random r = new Random(100);

                int cnt = Request.Files.Count;
                foreach (string file1 in Request.Files)
                {
                    HttpPostedFileBase hpf = Request.Files[file1] as HttpPostedFileBase;

                    fileExt = Path.GetExtension(hpf.FileName).ToLower();//带.的后缀
                 
                    //if ((hpf.ContentLength > 4 * 1024 * 1024))
                    //    continue;
                    path = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-ffff") + r.Next();
                    string filepath = Server.MapPath("../Content/Images/projectImage/" + path + fileExt);
                    hpf.SaveAs(filepath);
                    projectInfo.PROJECTIMAGE = path + fileExt;
                }

            }
            catch (Exception e)
            {
                return Content("<script>alert('项目图片上传失败');history.go(-1);</script>");
            }
            try
            {
                isExist = new ProjectInfoService().SaveProjectInfo(projectInfo);
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