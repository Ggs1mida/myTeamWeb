using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamWeb.Models.DAO.StudentDAO;
using TeamWeb.Models.Domain.UserInfoDomain;
using TeamWeb.Models.Domain.StudentDomain;
using TeamWeb.Models.Domain.PaperInfoDomain;
using TeamWeb.Models.Domain.TeacherInfoDomain;
using TeamWeb.Util;
using NHibernate;
using NHibernate.Bytecode;
using NHibernate.Cfg;

namespace TeamWeb.Models.DAO.StudentDAO
{
    public class StudentDAO
    {
        private ISession session;

        public IList<UserInfo> FindUserByUserName()
        {
            session = NhibernateUtils.getSession();

            //  IList<UserInfo> userList = session.CreateQuery("from UserInfo").List<UserInfo>();

            // IList<UserInfo> userNameList = session.CreateQuery("from UserInfo where UserType = '教师' " ).List<UserInfo>();　　//获取所有名字的IList集合

            string sql = @"select * from UserInfo where UserType = '学生' and USERCODE  not IN (SELECT USERCODE FROM STUDENTINFO)";

            IList<UserInfo> userList = session.CreateSQLQuery(sql).AddEntity(typeof(UserInfo)).List<UserInfo>();

            session.Close();
            return userList;

        }

        public IList<UserInfo> FindAccountInfo(string userName, string pwd)
        {
            session = NhibernateUtils.getSession();
            IList<UserInfo> userList = session.CreateQuery("from User u where u.UserName = '" + userName + "' and u.Pwd = '" + pwd + "'").List<UserInfo>();
            session.Close();
            return userList;
        }

        public bool SaveStudentInfo(StudentInfo studentInfo)
        {
            session = NhibernateUtils.getSession();
            ITransaction tsc = session.BeginTransaction();
            try
            {
                session.Save(studentInfo);
                tsc.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            { session.Close(); }
            return true;
        }


        public IList<StudentInfo> FindStudentInfo(string Id)
        {
            session = NhibernateUtils.getSession();
            IList<StudentInfo> userList = session.CreateQuery("from StudentInfo where USERCODE = '" + Id + "'").List<StudentInfo>();
            session.Close();
            return userList;
        }

        public IList<StudentInfo> FindStudentName()
        {
            session = NhibernateUtils.getSession();
            //string sql = @"select to_char(END,'yyyy-mm-dd'),DEGREE,ID,USERCODE,to_char(SCHOOLSTART,'yyyy-mm-dd'),PHOTO,MAJOR,NAME,GRADUATE,INTRODUCE from STUDENTINFO";
            //IList<StudentInfo> userList = session.CreateSQLQuery(sql).AddEntity(typeof(StudentInfo)).List<StudentInfo>();
            IList<StudentInfo> userList = session.CreateQuery("from StudentInfo").List<StudentInfo>();
            session.Close();
            return userList;
        }

        public IList<StudentInfo> FindALLStudent(string Id)
        {
            session = NhibernateUtils.getSession();
            IList<StudentInfo> userList = session.CreateQuery("from StudentInfo where USERCODE = '" + Id + "'").List<StudentInfo>();
            session.Close();
            return userList;
        }
        public IList<UserInfo> FoundStudentInfo2(string UserCode, string Name, string sex, string email, string qq, string phone, string wx, string Headimage)
        {
            session = NhibernateUtils.getSession();
            IList<UserInfo> userList = session.CreateSQLQuery(" Update UserInfo SET REALNAME =  '" + Name + "',sex =  '" + sex + "',email =  '" + email + "' ,qq =  '" + qq + "',phone =  '" + phone + "' ,wx =  '" + wx + "' ,Headimage =  '" + Headimage + "' where USERCODE = '" + UserCode + "'").AddEntity(typeof(UserInfo)).List<UserInfo>();
            session.Close();
            return userList;
        }
        //修改密码
        public IList<UserInfo> password(string UserCode, string pwd)
        {
            session = NhibernateUtils.getSession();
            IList<UserInfo> userList = session.CreateSQLQuery(" Update UserInfo SET  Password =  '" + pwd + "' where USERCODE = '" + UserCode + "'").AddEntity(typeof(UserInfo)).List<UserInfo>();
            session.Close();
            return userList;
        }


        public IList<StudentInfo> FoundStudentInfo3(string UserCode, string Name, string DEGREE, string GRADUATE, string SCHOOLSTART, string END, string INTRODUCE, string MAJOR, string photo)
        {
            session = NhibernateUtils.getSession();
            IList<StudentInfo> userList = session.CreateSQLQuery(" Update StudentInfo SET NAME =  '" + Name + "',DEGREE =  '" + DEGREE + "',GRADUATE =  '" + GRADUATE + "' ,SCHOOLSTART =  to_date('" + SCHOOLSTART + "','YYYY-MM-DD'),END = to_date ('" + END + "','YYYY-MM-DD'),INTRODUCE =  '" + INTRODUCE + "' ,MAJOR =  '" + MAJOR + "' ,photo =  '" + photo + "' where USERCODE = '" + UserCode + "'").AddEntity(typeof(StudentInfo)).List<StudentInfo>();
            session.Close();
            return userList;
        }


        public IList<TeacherInfo> FoundTeacherInfo(string UserCode, string Name, string title, string direction, string introduce, string credit, string photo)
        {
            session = NhibernateUtils.getSession();
            IList<TeacherInfo> userList = session.CreateSQLQuery(" Update TeacherInfo SET Name =  '" + Name + "',title =  '" + title + "',direction =  '" + direction + "' ,introduce =  '" + introduce + "',credit =  '" + credit + "' ,photo =  '" + photo + "' where USERCODE = '" + UserCode + "'").AddEntity(typeof(TeacherInfo)).List<TeacherInfo>();
            session.Close();
            return userList;
        }







        public IList<StudentInfo> FoundStudentInfo(string USERCODE, string NAME, string INTRODUCE, string SCHOOLSTART, string END, string MAJOR, string DEGREE, string GRADUATE)
        {
            session = NhibernateUtils.getSession();
            IList<StudentInfo> userList = session.CreateSQLQuery(" Update StudentInfo SET NAME =  '" + NAME + "',INTRODUCE =  '" + INTRODUCE + "',SCHOOLSTART =  to_date('" + SCHOOLSTART + "','YYYY-MM-DD'),END = to_date ('" + END + "','YYYY-MM-DD'),MAJOR =  '" + MAJOR + "' ,DEGREE =  '" + DEGREE + "'  where USERCODE = '" + USERCODE + "'").AddEntity(typeof(StudentInfo)).List<StudentInfo>();
            session.Close();
            return userList;
        }
        public IList<PaperInfo> CheckNewPaperInfo(string USERCODE, string PAPERAUTHOR, string PAPERDESCRIBE, string PAPERNAME, string PAPERYEAR, string UPLOADTIME, string PAPERTYPE)
        {
            session = NhibernateUtils.getSession();
            IList<PaperInfo> userList = session.CreateSQLQuery(" Update PaperInfo SET PAPERAUTHOR =  '" + PAPERAUTHOR + "',PAPERDESCRIBE =  '" + PAPERDESCRIBE + "',PAPERNAME =  '" + PAPERNAME + "',PAPERYEAR =  '" + PAPERYEAR + "',UPLOADTIME =  '" + UPLOADTIME + "' ,PAPERTYPE =  '" + PAPERTYPE + "'  where ID = '" + USERCODE + "'").AddEntity(typeof(PaperInfo)).List<PaperInfo>();
            session.Close();
            return userList;
        }

        public IList<UserInfo> FindName(string Id)
        {
            session = NhibernateUtils.getSession();
            IList<UserInfo> userList = session.CreateQuery("from UserInfo where USERCODE = '" + Id + "'").List<UserInfo>();
            session.Close();
            return userList;
        }
    }
}