using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamWeb.Models.DAO.StudentDAO;
using TeamWeb.Models.Domain.PaperInfoDomain;
using TeamWeb.Models.DAO.UserInfoDAO;
using TeamWeb.Models.Domain.StudentDomain;
using TeamWeb.Models.Domain.UserInfoDomain;
using TeamWeb.Models.Domain.TeacherInfoDomain;

namespace TeamWeb.Service
{
    public class StudentInfoService
    {
        public bool SaveStudentInfo(StudentInfo studentInfo)
        {
            return new StudentDAO().SaveStudentInfo(studentInfo);
        }

        public bool CheckStudentInfo(string UserCode)
        {
            IList<StudentInfo> user = new StudentDAO().FindStudentInfo(UserCode);
            return user.Count() == 0 ? false : true;
        }

        public IList<UserInfo> FindAllUserInfo()
        {
            return new StudentDAO().FindUserByUserName();
        }

        public IList<StudentInfo> FindStudentUser()
        {
            return new StudentDAO().FindStudentName();
        }


        public IList<UserInfo> FindStudentsName(string Id)
        {
            return new StudentDAO().FindName(Id);
        }


        public IList<StudentInfo> FindAllStudentMessage(string USERCODE)
        {
            return new StudentDAO().FindALLStudent(USERCODE);
        }
        public bool CheckNewPaperInfo(string USERCODE, string PAPERAUTHOR, string PAPERDESCRIBE, string PAPERNAME, string PAPERYEAR, string UPLOADTIME, string PAPERTYPE)
        {
            IList<PaperInfo> user = new StudentDAO().CheckNewPaperInfo(USERCODE, PAPERAUTHOR, PAPERDESCRIBE, PAPERNAME, PAPERYEAR, UPLOADTIME, PAPERTYPE);
            return user.Count() == 0 ? false : true;
        }
        public bool CheckNewStudentInfo(string USERCODE, string NAME, string INTRODUCE, string SCHOOLSTART, string END, string MAJOR, string DEGREE, string GRADUATE)
        {
            IList<StudentInfo> user = new StudentDAO().FoundStudentInfo(USERCODE, NAME, INTRODUCE, SCHOOLSTART, END, MAJOR, DEGREE, GRADUATE);
            return user.Count() == 0 ? false : true;
        }
        public bool CheckNewStudentInfo2(string UserCode, string Name, string sex, string email,string qq, string phone, string wx, string Headimage)
        {
            IList<UserInfo> user = new StudentDAO().FoundStudentInfo2(UserCode, Name, sex, email, qq, phone, wx, Headimage);
            return user.Count() == 0 ? false : true;
        }


        public bool CheckNewStudentInfo3(string UserCode, string Name, string DEGREE, string GRADUATE, string SCHOOLSTART, string END, string INTRODUCE, string MAJOR, string photo)
        {
            IList<StudentInfo> user = new StudentDAO().FoundStudentInfo3(UserCode, Name, DEGREE, GRADUATE, SCHOOLSTART, END, INTRODUCE, MAJOR, photo);
            return user.Count() == 0 ? false : true;
        }

        public bool CheckNewTeacherInfo(string UserCode, string Name, string title, string direction, string introduce, string credit, string photo)
        {
            IList<TeacherInfo> user = new StudentDAO().FoundTeacherInfo(UserCode, Name, title, direction, introduce, credit, photo);
            return user.Count() == 0 ? false : true;
        }
        //修改密码
        public bool savepassword(string UserCode, string pwd)
        {
            IList<UserInfo> user = new StudentDAO().password(UserCode, pwd);
            return user.Count() == 0 ? false : true;
        }



    }
}