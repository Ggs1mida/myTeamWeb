using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamWeb.Service;
using TeamWeb.Models.Domain.NewsInfoDomain;
using TeamWeb.Models.Domain.ProjectInfoDomain;
using System.IO;

namespace TeamWeb.Controllers
{
    public class ueditorController : Controller
    {
        // GET: ueditor
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
       public ActionResult CreatNews2(FormCollection fc)
        {
            bool isExist = false;
            var Time = Request["Time"];
            var Title = Request["Title"];
            var content = fc["editor"];
            var Name = new UeditorService().CreatHtml(content);
            string n = Session["id"].ToString();
            isExist = new UserLoginService().CheckNews2(Time, Title, content, Name, n);
            if (isExist)
            {
                return Content("<script>alert('修改失败');history.go(-1);</script>");
            }
            else
            {
                return Content("<script>alert('修改成功');history.go(-1);</script>");
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreatNews(FormCollection fc)
        {
            bool isExist = false;
            var Time = Request["Time"];
            var Title = Request["Title"];
            var content = fc["editor"];
            var Name = new UeditorService().CreatHtml(content);
            NewsInfo newsInfo = new NewsInfo();
            newsInfo.Time = Convert.ToDateTime(Time); 
            newsInfo.Title = Title;
            newsInfo.Introduce = content;
            newsInfo.Name = Name;
            isExist = new UserLoginService().CreatNews(newsInfo);
            if (isExist)
            {
                return Content("<script>alert('新增成功');history.go(-1);</script>");
            }
            else
            {
                return Content("<script>alert('新增失败');history.go(-1);</script>");
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreatProject1(FormCollection fc)
        {
            string path = "";
            bool isExist = false;
              var content = fc["editor"];
              var Name = new UeditorService().CreatHtml(content);
            var PROJECTNAME = Request["PROJECTNAME"];
            var PROJECTBIGCLASS = Request["PROJECTBIGCLASS"];
            var PROJECTSMALLCLASS = Request["PROJECTSMALLCLASS"];
            var PROJECTMANAGER = Request["PROJECTMANAGER"];
            var PROJECTGROUPER = Request["PROJECTGROUPER"];
            var PROJECTMEMBER = Request["PROJECTMEMBER"];
            var PROJECTSTART = Request["PROJECTSTART"];
            var PROJECTEND = Request["PROJECTEND"];
            var PROJECTPAGE = content;
            ProjectInfo projectInfo = new ProjectInfo();
            projectInfo.PROJECTBIGCLASS = PROJECTBIGCLASS;
            projectInfo.PROJECTEND = Convert.ToDateTime(PROJECTEND);
            projectInfo.PROJECTMANAGER = PROJECTMANAGER;
            projectInfo.PROJECTMEMBER = PROJECTMEMBER;
            projectInfo.PROJECTNAME = PROJECTNAME;
            projectInfo.PROJECTPAGE = PROJECTPAGE;
            projectInfo.PROJECTSMALLCLASS = PROJECTSMALLCLASS;
            projectInfo.PROJECTSTART = Convert.ToDateTime(PROJECTSTART); ;
            projectInfo.PROJECTGROUPER = PROJECTGROUPER;
            projectInfo.RROJECTTITLE = Name;
            try
            {
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
                    string filepath = Server.MapPath("../../common/projectimg/" + path + fileExt);
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
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreatProject2(FormCollection fc)
        {
            string n = Session["PrijectId"].ToString();
            string path = "";
            string PROJECTIMAGE = "";           
            bool isExist = false;
            var content = fc["editor"];
            var Name = new UeditorService().CreatHtml(content);
            var PROJECTNAME = Request["PROJECTNAME"];
            var PROJECTBIGCLASS = Request["PROJECTBIGCLASS"];
            var PROJECTSMALLCLASS = Request["PROJECTSMALLCLASS"];
            var PROJECTMANAGER = Request["PROJECTMANAGER"];
            var PROJECTGROUPER = Request["PROJECTGROUPER"];
            var PROJECTMEMBER = Request["PROJECTMEMBER"];
            var PROJECTSTART = Request["PROJECTSTART"];
            var PROJECTEND = Request["PROJECTEND"];
            var PROJECTPAGE = content;
            try
            {
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
                    string filepath = Server.MapPath("../../common/projectimg/" + path + fileExt);
                    hpf.SaveAs(filepath);
                  PROJECTIMAGE = path + fileExt;
                }

            }
            catch (Exception e)
            {
                return Content("<script>alert('项目图片上传失败');history.go(-1);</script>");
            }
            try
            {
                
                isExist = new UserLoginService().CheckProject2(n, PROJECTNAME, PROJECTBIGCLASS, PROJECTSMALLCLASS, PROJECTMANAGER, PROJECTGROUPER, PROJECTMEMBER, PROJECTSTART, PROJECTEND, PROJECTPAGE, Name, PROJECTIMAGE);
                if (isExist)
                {
                    return Content("<script>alert('修改失败');history.go(-1);</script>");
                }
                else
                {
                    return Content("<script>alert('修改成功');history.go(-1);</script>");
                }
            }
            catch (Exception e)
            {
                return Content("<script>alert('提交失败');history.go(-1);</script>");
            }

        }
    }
}