using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamWeb.Service;
using TeamWeb.Models.Domain.StudentDomain;
using TeamWeb.Models.Domain.UserInfoDomain;
using TeamWeb.Models.Domain.TeacherInfoDomain;
using TeamWeb.Models.Domain.StudentDomain;
using System.IO;
namespace TeamWeb.Controllers
{
    public class StudentController : Controller
    {
        // GET: Introduce
        public ActionResult studentPage()
        {
            //IList<UserInfo> userList = new StudentInfoService().FindAllUserInfo();
            //List<SelectListItem> list1 = new List<SelectListItem>();
            //for (int i = 0; i < userList.Count; i++)
            //{
            //    list1.Add(new SelectListItem { Text = userList[i].Name.ToString(), Value = userList[i].Id.ToString() });
            //}
            //ViewBag.list1 = list1;
            // List<SelectListItem> list2 = new List<SelectListItem>();
           
            //list2.Add(new SelectListItem { Text = "博士", Value = "博士" });
            //list2.Add(new SelectListItem { Text = "研究生", Value = "研究生" });
            //ViewBag.list2 = list2;
            string ID = Session["UserId"].ToString();
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
                IList<StudentInfo> userList = new UserLoginService().FindStudentMessage(ID);
                if (userList[0].NAME != null) ViewBag.NAME = userList[0].NAME.ToString();
                if (userList[0].GRADUATE != null) ViewBag.GRADUATE = userList[0].GRADUATE.ToString();
                if (userList[0].INTRODUCE != null) ViewBag.INTRODUCE = userList[0].INTRODUCE.ToString();
                if (userList[0].SCHOOLSTART != null)
                {
                    string SCHOOLSTART = userList[0].SCHOOLSTART.ToString().Replace("/", "-");
                    String d = SCHOOLSTART.Replace(" 0:00:00", "");
                    ViewBag.SCHOOLSTART = d;
                }
                if (userList[0].END != null) 
                {
                    string END = userList[0].END.ToString().Replace("/", "-");
                    String e = END.Replace(" 0:00:00", "");
                    ViewBag.END = e;
                }
                if (userList[0].MAJOR != null) ViewBag.MAJOR = userList[0].MAJOR.ToString();
                if (userList[0].PHOTO != null) ViewBag.PHOTO = userList[0].PHOTO.ToString();
                if (userList[0].DEGREE != null) ViewBag.DEGREE = userList[0].DEGREE.ToString();
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
            }
            else if (b == "管理员")
            {
                ViewBag.d3 = "inline";
                ViewBag.d4 = "inline";
            }
            else
            {
                ViewBag.d3 = "none";
                ViewBag.d4 = "inline";
            }
            return View();
        }


        public ActionResult teacherPerfect()
        {
            string ID = Session["UserId"].ToString();
            string a = Session["UserType"].ToString();
            string b = Session["UserPower"].ToString();
            if (a == "教师")
            {
                ViewBag.d1 = "inline";
                ViewBag.d2 = "none";
                ViewBag.d3 = "none";
                ViewBag.d4 = "inline";
                IList<TeacherInfo> userList = new UserLoginService().FindTeacherMessage(ID);
                if (userList[0].Name != null) ViewBag.Name = userList[0].Name.ToString();
                if (userList[0].Title != null) ViewBag.Title = userList[0].Title.ToString();
                if (userList[0].Credit != null) ViewBag.Credit = userList[0].Credit.ToString();
                if (userList[0].Direction != null) ViewBag.Direction = userList[0].Direction.ToString();
                if (userList[0].Introduce != null) ViewBag.Introduce = userList[0].Introduce.ToString();
                if (userList[0].Photo != null) ViewBag.Photo = userList[0].Photo.ToString();
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
            }
            else if (b == "管理员")
            {
                ViewBag.d3 = "inline";
                ViewBag.d4 = "inline";
            }
            else
            {
                ViewBag.d3 = "none";
                ViewBag.d4 = "inline";
            }
            return View();
        }





        public ActionResult SaveStudentInfo()
        {
            string path = "";
            bool isExist = false;
            var UserCode = Request["NAME"];
            bool isexist = false;
            isexist = new StudentInfoService().CheckStudentInfo(UserCode);
            if (isexist)
            {
                return Content("<script>alert('该用户已经存在无法提交');history.go(-1);</script>");
            }
            else

            {
                IList<UserInfo> userList = new StudentInfoService().FindStudentsName(UserCode);
                List<SelectListItem> list3 = new List<SelectListItem>();
                string name = userList[0].Name.ToString();
                var INTRODUCE = Request["INTRODUCE"];
                var GRADUATE = Request["GRADUATE"];
                var DEGREE = Request["DEGREE"];
                var SCHOOLSTART = Request["SCHOOLSTART"];
                var END = Request["END"];
                var MAJOR = Request["MAJOR"];

                StudentInfo studentInfo = new StudentInfo();
                studentInfo.NAME = name;
                studentInfo.GRADUATE = GRADUATE;
                studentInfo.DEGREE = DEGREE;
                studentInfo.USERCODE = UserCode;
                studentInfo.INTRODUCE = INTRODUCE;
                studentInfo.SCHOOLSTART = Convert.ToDateTime(SCHOOLSTART);
                studentInfo.END = Convert.ToDateTime(END);
                studentInfo.MAJOR = MAJOR;
                
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
                        string filepath = Server.MapPath("../../common/studentimg" + path + fileExt);
                        hpf.SaveAs(filepath);
                        studentInfo.PHOTO = path + fileExt;
                    }

                }
                catch (Exception e)
                {
                    return Content("<script>alert('项目图片上传失败');history.go(-1);</script>");
                }



                try
                {
                    isExist = new StudentInfoService().SaveStudentInfo(studentInfo);
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

        public ActionResult revisestudent()
        {
            string ID = Session["UserId"].ToString();
            string a = Session["UserType"].ToString();
            string b = Session["UserPower"].ToString();
            if (a == "教师")
            {
                ViewBag.d1="inline";
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
            }
            else if (b == "管理员")
            {
                ViewBag.d3 = "inline";
                ViewBag.d4 = "inline";
            }
            else
            {
                ViewBag.d3 = "none";
                ViewBag.d4 = "inline";
            }
            IList<UserInfo> userList = new UserLoginService().FindUserMessage(ID);
            if (userList[0].Name!=null) ViewBag.Name = userList[0].Name.ToString();
            if (userList[0].Sex != null) ViewBag.Sex = userList[0].Sex.ToString();
            if (userList[0].Phone != null) ViewBag.Phone = userList[0].Phone.ToString();
            if (userList[0].Email != null) ViewBag.Email = userList[0].Email.ToString();
            if (userList[0].QQ != null) ViewBag.QQ = userList[0].QQ.ToString();
            if (userList[0].Wx != null) ViewBag.Wx = userList[0].Wx.ToString();
            if (userList[0].Headimage != null) ViewBag.HeadImage = userList[0].Headimage.ToString();
            return View();
        }
        public ActionResult revisestudentPage()
        {
            var message = Request["StudentName"];
            IList<StudentInfo> userList = new StudentInfoService().FindAllStudentMessage(message);
            List<SelectListItem> list1 = new List<SelectListItem>();
            ViewBag.USERCODE = message;          
            ViewBag.PHOTO = userList[0].PHOTO.ToString();
            ViewBag.DEGREE = userList[0].DEGREE.ToString();
            ViewBag.NAME = userList[0].NAME.ToString();
            ViewBag.INTRODUCE = userList[0].INTRODUCE.ToString();
            string SchoolStart = userList[0].SCHOOLSTART.ToString().Replace("/","-");
            String b = SchoolStart.Replace(" 0:00:00", "");
            ViewBag.SCHOOLSTART = b;
            string End = userList[0].END.ToString().Replace("/", "-");
            String a = End.Replace(" 0:00:00", "");
            ViewBag.END = a;
            ViewBag.MAJOR = userList[0].MAJOR.ToString();
            return View();
        }
        public ActionResult SaveMessage()
        {
            string PHOTO = "";
            string path = "";
            bool isExist = false;
            var USERCODE = Request["USERCODE"];
            var NAME = Request["NAME"];
            var DEGREE = Request["DEGREE"];
            var INTRODUCE = Request["INTRODUCE"];
            var SCHOOLSTART = Request["SCHOOLSTART"];
            var END = Request["END"];
            var MAJOR = Request["MAJOR"];
            var GRADUATE = Request["GRADUATE"];
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
                    string filepath = Server.MapPath("../Content/Images/signupImage/" + path + fileExt);
                    hpf.SaveAs(filepath);
                    PHOTO = path + fileExt;
                }

            }
            catch (Exception e)
            {
                return Content("<script>alert('项目图片上传失败');history.go(-1);</script>");
            }

           // isExist = new StudentInfoService().CheckNewStudentInfo(USERCODE, NAME, INTRODUCE, SCHOOLSTART, END, MAJOR, PHOTO, DEGREE, GRADUATE);
            if (isExist)
                return Content("<script>alert('修改失败');history.go(-1);</script>");
            else
                return Content("<script>alert('修改成功');history.go(-1);</script>");
        }

    }

 }