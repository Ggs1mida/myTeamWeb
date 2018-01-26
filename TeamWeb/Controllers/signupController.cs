using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamWeb.Service;
using TeamWeb.Models.Domain.UserInfoDomain;
using System.Net.Mail;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace TeamWeb.Controllers
{
    public class signupController : Controller
    {
        // GET: signup
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult revisepassword()
        {
            string a = Session["UserType"].ToString();
            string b = Session["UserPower"].ToString();
            if (a == "教师")
            {
                ViewBag.d1 = "inline";
                ViewBag.d2 = "none";
                ViewBag.d3 = "none";
                ViewBag.d4 = "inline";
            }
            else if (a == "学生")
            {
                ViewBag.d1 = "none";
                ViewBag.d2 = "inline";
            }
            else
            {
                ViewBag.d1 = "none";
                ViewBag.d2 = "none";
            }
            if (b == "超级管理员")
            {
                ViewBag.d3 = "inline";
                ViewBag.d4 = "none";
                ViewBag.d5 = "false";
            }
            else if (b == "管理员")
            {
                ViewBag.d3 = "inline";
                ViewBag.d4 = "inline";
                ViewBag.d5 = "true";
            }
            else
            {
                ViewBag.d3 = "none";
                ViewBag.d4 = "inline";
                ViewBag.d5 = "false";
            }
            return View();
        }
        public ActionResult CreatNewUser()
        {
            string path = "";
            bool isExist = false;
            string UserCode = Session["UserId"].ToString();
            string Headimage = "";
            var Name = Request["Name"];
            var sex = Request["Sex"];
            var email = Request["Email"];
            var qq = Request["QQ"];
            var phone = Request["Phone"];
            var wx = Request["user-weibo"];

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
                    string filepath = Server.MapPath("../../common/userimg/" + path + fileExt);
                    hpf.SaveAs(filepath);
                    Headimage = path + fileExt;
                }

            }
            catch (Exception e)
            {
                return Content("<script>alert('项目图片上传失败');history.go(-1);</script>");
            }
            try
            {
                isExist = new StudentInfoService().CheckNewStudentInfo2(UserCode, Name, sex, email, qq, phone, wx, Headimage);
                if (isExist)
                    return Content("<script>alert('提交失败');history.go(-1);</script>");
                else
                    return Content("<script>alert('提交成功');history.go(-1);</script>");
            }
            catch (Exception e)
            {
                return Content("<script>alert('提交失败');history.go(-1);</script>");
            }

            // }

        }

        //保存学生个人信息配置
        public ActionResult savestuddentperfect()
        {
            string path = "";
            bool isExist = false;
            string UserCode = Session["UserId"].ToString();
            string photo = "";
            var Name = Request["NAME"];
            var DEGREE = Request["DEGREE"];
            var GRADUATE = Request["GRADUATE"];
            var SCHOOLSTART = Request["SCHOOLSTART"];
            var END = Request["END"];
            var INTRODUCE = Request["INTRODUCE"];
            var MAJOR = Request["MAJOR"];

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
                    string filepath = Server.MapPath("../../common/studentimg/" + path + fileExt);
                    hpf.SaveAs(filepath);
                    photo = path + fileExt;
                }

            }
            catch (Exception e)
            {
                return Content("<script>alert('项目图片上传失败');history.go(-1);</script>");
            }
            try
            {
                isExist = new StudentInfoService().CheckNewStudentInfo3(UserCode, Name, DEGREE, GRADUATE, SCHOOLSTART, END, INTRODUCE, MAJOR, photo);
                if (isExist)
                    return Content("<script>alert('提交失败');history.go(-1);</script>");
                else
                    return Content("<script>alert('提交成功');history.go(-1);</script>");
            }
            catch (Exception e)
            {
                return Content("<script>alert('提交失败');history.go(-1);</script>");
            }



        }


        //保存教师个人信息配置
        public ActionResult saveteacherperfect()
        {
            string path = "";
            bool isExist = false;
            string UserCode = Session["UserId"].ToString();
            string photo = "";
            var Name = Request["name"];
            var title = Request["title"];
            var direction = Request["direction"];
            var introduce = Request["introduce"];
            var credit = Request["credit"];


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
                    string filepath = Server.MapPath("../../common/teacherimg/" + path + fileExt);
                    hpf.SaveAs(filepath);
                    photo = path + fileExt;
                }

            }
            catch (Exception e)
            {
                return Content("<script>alert('项目图片上传失败');history.go(-1);</script>");
            }
            try
            {
                isExist = new StudentInfoService().CheckNewTeacherInfo(UserCode, Name, title, direction, introduce, credit, photo);
                if (isExist)
                    return Content("<script>alert('提交失败');history.go(-1);</script>");
                else
                    return Content("<script>alert('提交成功');history.go(-1);</script>");
            }
            catch (Exception e)
            {
                return Content("<script>alert('提交失败');history.go(-1);</script>");
            }
        }


        //修改密码
        public ActionResult savepassword()
        {
            
            bool isExist = false;
            string UserCode = Session["UserId"].ToString();
            var a = Request["Pwd1"];
            var b = Request["Pwd2"];



            if (a != b)
            {
                return Content("<script>alert('两次密码输出不一致！');history.go(-1);</script>");
            }
            else
            {
               
                var pwd = Request["Pwd1"];
             
               

             
              
                try
                {
                    isExist = new StudentInfoService().savepassword(UserCode, pwd);
                    if (isExist)
                        return Content("<script>alert('提交失败');history.go(-1);</script>");
                    else
                        return Content("<script>alert('提交成功');history.go(-1);</script>");
                }
               

                catch (Exception e)
                {
                    return Content("<script>alert('提交失败');history.go(-1);</script>");
                }

            }

        }




    }
}
