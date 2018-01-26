using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamWeb.Service;
using TeamWeb.Models.Domain.UserInfoDomain;
using TeamWeb.Models.Domain.TeacherInfoDomain;
using TeamWeb.Models.Domain.StudentDomain;
using TeamWeb.Models.Domain.WorkDomain;
using TeamWeb.Models.Domain.TeamInfoDomain;
using TeamWeb.Models.Domain.NewsInfoDomain;
using TeamWeb.Models.Domain.ProjectInfoDomain;
using TeamWeb.Models.Domain.ClassInfoDomain;
using System.IO;
using System.Net.Mail;
using System.Net;
using TeamWeb.PUBLIC;
namespace TeamWeb.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message

        public ActionResult GetJson6()
        {
            IList<ProjectInfo> userList = new UserLoginService().FindProjrct();
            //return Json(list,JsonRequestBehavior.AllowGet);     //.Net还是很威武的，这行代码是可以运行并得到正确结果的，然后注释来看看前辈们的List<T>转Json的代码//
            String strJson6 = publicMethod.ObjToJson<IList<ProjectInfo>>(userList);       //泛泛型？    这代码怎么感觉怪怪的。
            return Content(strJson6);
        }
        public ActionResult GetJson5()
        {
            IList<NewsInfo> userList = new UserLoginService().FindNews();
            //return Json(list,JsonRequestBehavior.AllowGet);     //.Net还是很威武的，这行代码是可以运行并得到正确结果的，然后注释来看看前辈们的List<T>转Json的代码//
            string strJson5 = publicMethod.ObjToJson<IList<NewsInfo>>(userList);       //泛泛型？    这代码怎么感觉怪怪的。
            return Content(strJson5);
        }
        public ActionResult GetJson4()
        {
            IList<WorkInfo> userList = new UserLoginService().FindWorkStudent();
            //return Json(list,JsonRequestBehavior.AllowGet);     //.Net还是很威武的，这行代码是可以运行并得到正确结果的，然后注释来看看前辈们的List<T>转Json的代码//
            string strJson4 = publicMethod.ObjToJson<IList<WorkInfo>>(userList);       //泛泛型？    这代码怎么感觉怪怪的。
            return Content(strJson4);
        }
        public ActionResult GetJson3()
        {
            IList<StudentInfo> userList = new StudentInfoService().FindStudentUser();
            //return Json(list,JsonRequestBehavior.AllowGet);     //.Net还是很威武的，这行代码是可以运行并得到正确结果的，然后注释来看看前辈们的List<T>转Json的代码//
            string strJson3 = publicMethod.ObjToJson<IList<StudentInfo>>(userList);       //泛泛型？    这代码怎么感觉怪怪的。
            return Content(strJson3);
        }
        public ActionResult GetJson2()
        {
            IList<TeamInfo> userList = new UserLoginService().FindTeamField();
            //return Json(list,JsonRequestBehavior.AllowGet);     //.Net还是很威武的，这行代码是可以运行并得到正确结果的，然后注释来看看前辈们的List<T>转Json的代码//
            string strJson2 = publicMethod.ObjToJson<IList<TeamInfo>>(userList);       //泛泛型？    这代码怎么感觉怪怪的。
            return Content(strJson2);
        }
        public ActionResult GetJson1()
        {
            IList<TeacherInfo> userList = new UserLoginService().FindUser();
            //return Json(list,JsonRequestBehavior.AllowGet);     //.Net还是很威武的，这行代码是可以运行并得到正确结果的，然后注释来看看前辈们的List<T>转Json的代码//
            string strJson1 = publicMethod.ObjToJson<IList<TeacherInfo>>(userList);       //泛泛型？    这代码怎么感觉怪怪的。
            return Content(strJson1);
        }
        public ActionResult GetJson()
        {
            string strJson = "";
            string b = Session["UserPower"].ToString();
            if (b == "超级管理员")
            {
                IList<UserInfo> userList = new PaperInfoService().FindAllUser();
                //return Json(list,JsonRequestBehavior.AllowGet);     //.Net还是很威武的，这行代码是可以运行并得到正确结果的，然后注释来看看前辈们的List<T>转Json的代码//
                 strJson = publicMethod.ObjToJson<IList<UserInfo>>(userList);       //泛泛型？    这代码怎么感觉怪怪的。
            }
            else if (b == "管理员")
            {
                IList<UserInfo> userList = new PaperInfoService().FindAllUser2();

                //return Json(list,JsonRequestBehavior.AllowGet);     //.Net还是很威武的，这行代码是可以运行并得到正确结果的，然后注释来看看前辈们的List<T>转Json的代码//
                 strJson = publicMethod.ObjToJson<IList<UserInfo>>(userList);       //泛泛型？    这代码怎么感觉怪怪的。
               
            }
            return Content(strJson);
        }

        public ActionResult CreatImage()
        {
            bool isExist = false;
            string HeadImage = "";
            string fileExt = "";
            Random r = new Random(100);
            string path = "";
            var userName = Request["UserName"];
            UserInfo userinfo = new UserInfo();
            int cnt = Request.Files.Count;
            foreach (string file1 in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file1] as HttpPostedFileBase;

                fileExt = Path.GetExtension(hpf.FileName).ToLower();//带.的后缀
                if (fileExt == "")
                {
                    return Content("");

                }
                else
                {
                    //if ((hpf.ContentLength > 4 * 1024 * 1024))
                    //    continue;
                    path = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-ffff") + r.Next();
                    string filepath = Server.MapPath("../../common/userimg/" + path + fileExt);
                    hpf.SaveAs(filepath);
                    HeadImage = path + fileExt;
                    isExist = new UserLoginService().CheckUser(userName, HeadImage);
                    if (isExist)
                    {
                        return Content("<script>alert('头像上传失败请重新编辑头像');history.go(-1);</script>");
                    }
                    else
                    {

                        return Content("头像上传成功");
                    }
                }
            }
            return Content("头像上传失败请重新选择");
        }
        public ActionResult CreatPhoto()
        {
            bool isExist = false;
            string Photo = "";
            string fileExt = "";
            Random r = new Random(100);
            string path = "";
            var UserCode = Request["UserCode"];
            TeacherInfo userinfo = new TeacherInfo();
            int cnt = Request.Files.Count;
            foreach (string file1 in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file1] as HttpPostedFileBase;

                fileExt = Path.GetExtension(hpf.FileName).ToLower();//带.的后缀
                if (fileExt == "")
                {
                    return Content("");

                }
                else
                {
                    //if ((hpf.ContentLength > 4 * 1024 * 1024))
                    //    continue;
                    path = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-ffff") + r.Next();
                    string filepath = Server.MapPath("../../common/teacherimg/" + path + fileExt);
                    hpf.SaveAs(filepath);
                    Photo = path + fileExt;
                    isExist = new UserLoginService().CheckTeacher(UserCode, Photo);
                    if (isExist)
                    {
                        return Content("<script>alert('头像上传失败请重新编辑头像');history.go(-1);</script>");
                    }
                    else
                    {

                        return Content("头像上传成功");
                    }
                }
            }
            return Content("头像上传失败请重新选择");
        }
        public ActionResult CreatStudentPhoto()
        {
            bool isExist = false;
            string Photo = "";
            string fileExt = "";
            Random r = new Random(100);
            string path = "";
            var UserCode = Request["USERCODE"];
            StudentInfo studentInfo = new StudentInfo();
            int cnt = Request.Files.Count;
            foreach (string file1 in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file1] as HttpPostedFileBase;

                fileExt = Path.GetExtension(hpf.FileName).ToLower();//带.的后缀
                if (fileExt == "")
                {
                    return Content("");

                }
                else
                {
                    //if ((hpf.ContentLength > 4 * 1024 * 1024))
                    //    continue;
                    path = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-ffff") + r.Next();
                    string filepath = Server.MapPath("../../common/studentimg/" + path + fileExt);
                    hpf.SaveAs(filepath);
                    Photo = path + fileExt;
                    isExist = new UserLoginService().CheckStudent(UserCode, Photo);
                    if (isExist)
                    {
                        return Content("<script>alert('头像上传失败请重新编辑头像');history.go(-1);</script>");
                    }
                    else
                    {

                        return Content("头像上传成功");
                    }
                }
            }
            return Content("头像上传失败请重新选择");
        }
        public ActionResult SaveTeacherInfo()
        {
            string b = Request["oper"];
            string UserCode = Request["editId"];
            bool isExist = false;
            var Name = Request["Name"];
            var Title = Request["TITLE"];
            var Credit = Request["Credit"];
            var Directon = Request["Directon"];
            var Introduce = Request["Introduce"];
            try
            {
                if (b == "edit")
                {
                    isExist = new UserLoginService().CheckNewInfo(UserCode, Name, Title, Credit, Directon, Introduce);
                    if (isExist)
                    {
                        return Content("编辑失败");
                    }
                    else
                    {

                        return Content("编辑成功");
                    }
                }
                else
                {
                    isExist = new UserLoginService().DelTeacherInfo(UserCode);
                    if (isExist)
                    {
                        return Content("删除失败");
                    }
                    else
                    {
                        return Content("删除成功");
                    }
                }
            }
            catch
            {
                return Content("提交失败");
            }
        }
        public ActionResult SaveStudent()
        {
            string b = Request["oper"];
            string USERCODE = Request["editId"];
            bool isExist = false;
            var NAME = Request["NAME"];
            var DEGREE = Request["DEGREE"];
            var SCHOOLSTART = Request["SCHOOLSTART"];
            var END = Request["END"];
            var GRADUATE = Request["GRADUATE"];
            var MAJOR = Request["MAJOR"];
            var INTRODUCE = Request["INTRODUCE"];
            StudentInfo studentInfo = new StudentInfo();
            try
            {
                if (b == "add")
                {

                    studentInfo.NAME = NAME;
                    studentInfo.DEGREE = DEGREE;
                    studentInfo.SCHOOLSTART = Convert.ToDateTime(SCHOOLSTART);
                    studentInfo.GRADUATE = GRADUATE;
                    studentInfo.END = Convert.ToDateTime(END);
                    studentInfo.INTRODUCE = INTRODUCE;
                    studentInfo.MAJOR = MAJOR;
                    isExist = new StudentInfoService().SaveStudentInfo(studentInfo);
                        if (isExist)
                        {
                            IList<StudentInfo> userList = new UserLoginService().FindStudent();
                            for (int i = 0; i < userList.Count; i++)
                            {
                                //var name = userList[i].NAME.ToString(); 
                                WorkInfo workInfo = new WorkInfo();
                                if (userList[i].NAME != null)
                                {
                                    var name = userList[i].NAME.ToString();
                                    workInfo.Name = name;
                                }
                                var g = userList[i].USERCODE.ToString();
                                //
                                workInfo.UserCode = g;
                                isExist = new UserLoginService().CreatWorkUser(workInfo);
                            }
                            return Content("基础信息新增成功");
                        }
                        else
                        {
                            return Content("基础信息新增失败");
                        }
                    }
                
                else if (b == "edit")
                {
                    isExist = new StudentInfoService().CheckNewStudentInfo(USERCODE, NAME, INTRODUCE, SCHOOLSTART, END, MAJOR, DEGREE, GRADUATE);
                    if (isExist)
                    {
                        return Content("修改失败");
                    }
                    else
                    {

                        return Content("修改成功");
                    }
                }
                else
                {
                    isExist = new UserLoginService().DelStudentInfo(USERCODE);
                    if (isExist)
                    {
                        return Content("删除失败");
                    }
                    else
                    {
                        return Content("删除成功");
                    }
                }
            }
            catch
            {
                return Content("提交失败");
            }

        }
        public ActionResult CreatNewUser()
        {
            string b = Request["oper"];
            string UserCode = Request["editId"];
            bool isExist = false;
            var userName = Request["UserName"];

            var Name = Request["Name"];
            var sex = Request["Sex"];
            var pwd = Request["Pwd"];
            var email = Request["Email"];
            var usertype = Request["Usertype"];
            var qq = Request["QQ"];
            var phone = Request["Phone"];
            var Wx = Request["Wx"];
            var Power = Request["Power"];
            if (userName == "" || pwd == "") { return Content("用户名和密码不能为空"); }
            UserInfo userinfo = new UserInfo();
            try
            {
                if (b == "add")
                {
                    bool isexist = false;
                    isexist = new UserLoginService().CheckUserInfo(userName);
                    if (isexist)
                    {
                        return Content("用户名已存在请重新填写");
                    }
                    else
                    {
                        userinfo.Name = Name;
                        userinfo.Sex = sex;
                        userinfo.UserName = userName;
                        userinfo.Pwd = pwd;
                        userinfo.Email = email;
                        userinfo.UserType = usertype;
                        userinfo.QQ = qq;
                        userinfo.Phone = phone;
                        userinfo.Wx = Wx;
                        userinfo.Power = Power;
                        isExist = new UserRegisterService().CreatUser(userinfo);
                        if (isExist)
                        {
                            IList<UserInfo> userList = new UserLoginService().FindTeachers();
                            List<SelectListItem> list1 = new List<SelectListItem>();
                            for (int i = 0; i < userList.Count; i++)
                            {
                                TeacherInfo teacherInfo = new TeacherInfo();
                                if (userList[i].Name != null)
                                {
                                    var name = userList[i].Name.ToString();
                                    teacherInfo.Name = name;
                                }
                                var Id = userList[i].Id.ToString();
                                //TeacherInfo teacherInfo = new TeacherInfo();
                                //if (userList[i].Name != null) { teacherInfo.Name = name; }//
                                teacherInfo.UserCode = Id;
                                new UserLoginService().CreatUser(teacherInfo);
                            }
                            IList<UserInfo> userList1 = new StudentInfoService().FindAllUserInfo();
                            for (int i = 0; i < userList1.Count; i++)
                            {
                                StudentInfo studentInfo = new StudentInfo();
                                if (userList1[i].Name != null)
                                {
                                    var name = userList1[i].Name.ToString();
                                    studentInfo.NAME = name;
                                }
                                // 
                                var USERCODE = userList1[i].Id.ToString();

                                // 
                                studentInfo.USERCODE = USERCODE;
                                studentInfo.SCHOOLSTART = Convert.ToDateTime("2017-01-01");
                                studentInfo.END = Convert.ToDateTime("2017-01-01");
                                new StudentInfoService().SaveStudentInfo(studentInfo);
                            }
                            return Content("基础信息新增成功");
                        }
                        else
                        {
                            return Content("基础信息新增失败");
                        }
                    }
                }
                else if (b == "edit")
                {
                    isExist = new UserLoginService().CheckNewUserInfo(UserCode, userName, Name, sex, pwd, email, usertype, qq, phone, Wx, Power);
                    if (isExist)
                    {
                        return Content("修改失败");
                    }
                    else
                    {

                        return Content("修改成功");
                    }
                }
                else
                {
                    isExist = new UserLoginService().DelUserInfo(UserCode);
                    if (isExist)
                    {
                        return Content("删除失败");
                    }
                    else
                    {
                        return Content("删除成功");
                    }
                }
            }
            catch
            {
                return Content("提交失败");
            }

        }

        public ActionResult CreatProjectPage()
        {
            string a = Request["PROJECTCODE"];
            Session.Add("PrijectId", a);
            return Content("成功");
        }
        public ActionResult CreatNewsPage()
        {
            string a = Request["Id"];
            Session.Add("id",a);         
            return Content("成功");
        }
        //[HttpPost]
        //[ValidateInput(false)]
        public ActionResult NewsPage()
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
        public ActionResult ProjectPage1()
        {
            IList<ClassInfo> userList = new PaperInfoService().FindAllClassInfo();
            List<SelectListItem> list1 = new List<SelectListItem>();
            List<SelectListItem> list2 = new List<SelectListItem>();
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].Big != null)
                {
                    list1.Add(new SelectListItem { Text = userList[i].Big.ToString(), Value = userList[i].Big.ToString() });
                }
                if (userList[i].Small != null)
                {
                    list2.Add(new SelectListItem { Text = userList[i].Small.ToString(), Value = userList[i].Small.ToString() });
                }
            }
            ViewBag.list1 = list1;
             ViewBag.list2 = list2;
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
        public ActionResult ProjectPage2()
        {
            string n = Session["PrijectId"].ToString();
            IList<ClassInfo> userList = new PaperInfoService().FindAllClassInfo();
            List<SelectListItem> list1 = new List<SelectListItem>();
            List<SelectListItem> list2 = new List<SelectListItem>();
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].Big != null)
                {
                    list1.Add(new SelectListItem { Text = userList[i].Big.ToString(), Value = userList[i].Big.ToString() });
                }
                if (userList[i].Small != null)
                {
                    list2.Add(new SelectListItem { Text = userList[i].Small.ToString(), Value = userList[i].Small.ToString() });
                }
            }
            ViewBag.list1 = list1;
            ViewBag.list2 = list2;
            IList<ProjectInfo> userList1 = new UserLoginService().FindAllProject(n);
            string PROJECTSTART = userList1[0].PROJECTSTART.ToString().Replace("/", "-");
            String d = PROJECTSTART.Replace(" 0:00:00", "");
            string PROJECTEND = userList1[0].PROJECTEND.ToString().Replace("/", "-");
            String e = PROJECTEND.Replace(" 0:00:00", "");
            ViewBag.PROJECTSTART = d;
            ViewBag.PROJECTEND = e;
            ViewBag.PROJECTGROUPER = userList1[0].PROJECTGROUPER.ToString();
            ViewBag.PROJECTMEMBER = userList1[0].PROJECTMEMBER.ToString();
            ViewBag.PROJECTMANAGER = userList1[0].PROJECTMANAGER.ToString();
            ViewBag.PROJECTPAGE = userList1[0].PROJECTPAGE.ToString();
            ViewBag.PROJECTIMAGE = userList1[0].PROJECTIMAGE.ToString();
            ViewBag.PROJECTNAME = userList1[0].PROJECTNAME.ToString();
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
        public ActionResult NewsPage1()
        {
                string n = Session["id"].ToString();
                IList<NewsInfo> userList = new UserLoginService().FindAllNews(n);
                ViewBag.Title = userList[0].Title.ToString();
                string Time = userList[0].Time.ToString().Replace("/", "-");
                String e = Time.Replace(" 0:00:00", "");
                ViewBag.Time = e;
                ViewBag.Introduce = userList[0].Introduce.ToString();
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

        public ActionResult TeamMessage()
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
        public ActionResult StudentMessage()
        {
            IList<UserInfo> userList = new StudentInfoService().FindAllUserInfo();
            List<SelectListItem> list1 = new List<SelectListItem>();
            for (int i = 0; i < userList.Count; i++)
            {
                bool isExist = false;
                StudentInfo studentInfo = new StudentInfo();
                if (userList[i].Name != null)
                {
                    var name = userList[i].Name.ToString();
                    studentInfo.NAME = name;
                }
                // 
                var USERCODE = userList[i].Id.ToString();

                // 
                studentInfo.USERCODE = USERCODE;
                studentInfo.SCHOOLSTART = Convert.ToDateTime("2017-01-01");
                studentInfo.END = Convert.ToDateTime("2017-01-01");
                isExist = new StudentInfoService().SaveStudentInfo(studentInfo);
            }
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
        public ActionResult TeamReviseMessage()
        {

            var message = Request["Team"];
            IList<TeamInfo> userList = new UserLoginService().FindAllTeam(message);
            List<SelectListItem> list1 = new List<SelectListItem>();
            ViewBag.Id = message;
            ViewBag.TeamField = userList[0].TeamField.ToString();
            ViewBag.TeamIntroduce = userList[0].TeamIntroduce.ToString();
            ViewBag.Image = userList[0].Image.ToString();
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
        public ActionResult WorkMessage()
        {
            //IList<StudentInfo> userList = new UserLoginService().FindStudent();
            //List<SelectListItem> list1 = new List<SelectListItem>();
            //for (int i = 0; i < userList.Count; i++)
            //{
            //    list1.Add(new SelectListItem { Text = userList[i].NAME.ToString(), Value = userList[i].USERCODE.ToString() });

            //}
            //ViewBag.list1 = list1;

            IList<StudentInfo> userList = new UserLoginService().FindStudent();
            List<SelectListItem> list1 = new List<SelectListItem>();
            for (int i = 0; i < userList.Count; i++)
            {
                bool isExist = false;
                //var name = userList[i].NAME.ToString(); 
                WorkInfo workInfo = new WorkInfo();
                if (userList[i].NAME != null)
                {
                    var name = userList[i].NAME.ToString();
                    workInfo.Name = name;
                }
                var USERCODE = userList[i].USERCODE.ToString();
                //
                workInfo.UserCode = USERCODE;
                isExist = new UserLoginService().CreatWorkUser(workInfo);
            }
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
        public ActionResult NewsMessage()
        {
            //IList<WorkInfo> userList = new UserLoginService().FindWorkStudent();
            //List<SelectListItem> list1 = new List<SelectListItem>();
            //for (int i = 0; i < userList.Count; i++)
            //{
            //    list1.Add(new SelectListItem { Text = userList[i].Name.ToString(), Value = userList[i].UserCode.ToString() });

            //}
            //ViewBag.list1 = list1;

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
        public ActionResult delNews()
        {
            bool isExist = false;
            var UserCode = Request["editId"];
            isExist = new UserLoginService().DelNewsInfo(UserCode);
            if (isExist)
            {
                return Content("删除失败");
            }
            else
            {
                return Content("删除成功");
            }
        }
        public ActionResult delProject()
        {
            bool isExist = false;
            var UserCode = Request["editId"];
            isExist = new UserLoginService().DelProjectInfo(UserCode);
            if (isExist)
            {
                return Content("删除失败");
            }
            else
            {
                return Content("删除成功");
            }
        }
        public ActionResult projectPage()
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
        public ActionResult WorkReviseMessage()
        {
            var message = Request["WorkName"];
            IList<WorkInfo> userList = new UserLoginService().FindAllWork(message);
            List<SelectListItem> list1 = new List<SelectListItem>();
            ViewBag.UserCode = message;
            ViewBag.Name = userList[0].Name.ToString();
            ViewBag.Company = userList[0].Company.ToString();
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
        public ActionResult Message()
        {
            IList<TeacherInfo> userList = new UserLoginService().FindUser();
            List<SelectListItem> list1 = new List<SelectListItem>();
            for (int i = 0; i < userList.Count; i++)
            {
                list1.Add(new SelectListItem { Text = userList[i].Name.ToString(), Value = userList[i].UserCode.ToString() });

            }
            ViewBag.list1 = list1;
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
       
        public ActionResult SaveStudentInfo()
        {
            bool isExist = false;
            var UserCode = Request["editId"];
         
                //IList<UserInfo> userList = new UserLoginService().FindName(UserCode);

                IList<StudentInfo> userList = new UserLoginService().FindStudentUser(UserCode);
                string name = userList[0].NAME.ToString();
                var Company = Request["Company"];
                WorkInfo workInfo = new WorkInfo();
                workInfo.UserCode = UserCode;
                workInfo.Company = Company;
                workInfo.Name = name;
                try
                {
                    isExist = new UserLoginService().CreatWorkUser(workInfo);
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
        public ActionResult RevisePage()
        {
            IList<UserInfo> userList = new UserLoginService().FindTeachers();
            List<SelectListItem> list1 = new List<SelectListItem>();
            for (int i = 0; i < userList.Count; i++)
            {
                bool isExist = false;
                TeacherInfo teacherInfo = new TeacherInfo();
                if (userList[i].Name != null)
                {
                    var name = userList[i].Name.ToString();
                    teacherInfo.Name = name;
                }
                var Id = userList[i].Id.ToString();
                //TeacherInfo teacherInfo = new TeacherInfo();
                //if (userList[i].Name != null) { teacherInfo.Name = name; }//
                teacherInfo.UserCode = Id;
                isExist = new UserLoginService().CreatUser(teacherInfo);
            }
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
        public ActionResult SaveWorkMessage()
        {
            string b = Request["oper"];
            string UserCode = Request["editId"];
            bool isExist = false;
            var Company = Request["Company"];
            isExist = new UserLoginService().CheckWorkInfo(UserCode, Company);
            if (b == "edit")
            {
                isExist = new UserLoginService().CheckWorkInfo(UserCode, Company);
                if (isExist)
                {
                    return Content("编辑失败");
                }
                else
                {
                    return Content("编辑成功");
                }
            }
            else
            {
                isExist = new UserLoginService().DelWorkInfo(UserCode);
                if (isExist)
                {
                    return Content("删除失败");
                }
                else
                {
                    return Content("删除成功");
                }
            }
        }
        public ActionResult SaveMessage()
        {
            string Photo = "";
            string path = "";
            bool isExist = false;
            var UserCode = Request["UserCode"];
            var Name = Request["Name"];
            var Title = Request["TITLE"];
            var Credit = Request["teachercredit"];
            var Directon = Request["direction"];
            var Introduce = Request["teacherintro"];
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
                    Photo = path + fileExt;
                }

            }
            catch (Exception e)
            {
                return Content("<script>alert('项目图片上传失败');history.go(-1);</script>");
            }

            isExist = new UserLoginService().CheckNewInfo(UserCode, Name, Title, Credit, Directon, Introduce);
            if (isExist)
                return Content("<script>alert('修改失败');history.go(-1);</script>");
            else
                return Content("<script>alert('修改成功');history.go(-1);</script>");
        }
        public ActionResult SaveTeamMessage()
        {
            string b = Request["oper"];
            string UserCode = Request["editId"];
            bool isExist = false;
            var TeamField = Request["TeamField"];
            var TeamIntroduce = Request["TeamIntroduce"];
            TeamInfo teamInfo = new TeamInfo();
            try
            {
                if (b == "add")
                {
                    bool isexist = false;
                    isexist = new UserLoginService().CheckUserInfo(TeamField);
                    if (isexist)
                    {
                        return Content("所填研究方向已存在请重新添加");
                    }
                    else if (TeamField == "" || TeamIntroduce == "") { return Content("研究方向和介绍不可为空"); }
                    else
                    {
                        teamInfo.TeamField = TeamField;
                        teamInfo.TeamIntroduce = TeamIntroduce;
                        isExist = new UserLoginService().CreatTeam(teamInfo);
                        if (isExist)
                        {
                            return Content("基础信息新增成功");
                        }
                        else
                        {
                            return Content("基础信息新增失败");
                        }
                    }
                }
                else if (b == "edit")
                {
                    isExist = new UserLoginService().CheckNewTeamInfo(UserCode, TeamField, TeamIntroduce);
                    if (isExist)
                    {
                        return Content("编辑失败");
                    }
                    else
                    {
                        return Content("编辑成功");
                    }
                }
                else
                {
                    isExist = new UserLoginService().DelTeamInfo(UserCode);
                    if (isExist)
                    {
                        return Content("删除失败");
                    }
                    else
                    {
                        return Content("删除成功");
                    }
                }
            }
            catch
            {
                return Content("提交失败");
            }
        }
        public ActionResult SaveTeamInfo()
        {
            bool isExist = false;
            string Image = "";
            string fileExt = "";
            Random r = new Random(100);
            string path = "";
            var Id = Request["TeamField"];
            UserInfo userinfo = new UserInfo();
            int cnt = Request.Files.Count;
            foreach (string file1 in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file1] as HttpPostedFileBase;

                fileExt = Path.GetExtension(hpf.FileName).ToLower();//带.的后缀
                if (fileExt == "")
                {
                    return Content("");

                }
                else
                {
                    //if ((hpf.ContentLength > 4 * 1024 * 1024))
                    //    continue;
                    path = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-ffff") + r.Next();
                    string filepath = Server.MapPath("../../common/teamimg/" + path + fileExt);
                    hpf.SaveAs(filepath);
                    Image = path + fileExt;
                    isExist = new UserLoginService().CheckTeamImage(Id, Image);
                    if (isExist)
                    {
                        return Content("<script>alert('图片上传失败请重新编辑头像');history.go(-1);</script>");
                    }
                    else
                    {

                        return Content("图片上传成功");
                    }
                }
            }
            return Content("图片上传失败请重新选择");
        }
    }
}
         
 
    