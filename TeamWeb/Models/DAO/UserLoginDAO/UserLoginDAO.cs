using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamWeb.Models.DAO.UserLoginDAO;
using TeamWeb.Models.Domain.UserInfoDomain;
using TeamWeb.Models.Domain.TeacherInfoDomain;
using TeamWeb.Models.Domain.StudentDomain;
using TeamWeb.Models.Domain.WorkDomain;
using TeamWeb.Models.Domain.TeamInfoDomain;
using TeamWeb.Models.Domain.NewsInfoDomain;
using TeamWeb.Models.Domain.ProjectInfoDomain;
using TeamWeb.Models.Domain.PaperInfoDomain;
using TeamWeb.Util;
using NHibernate;
using NHibernate.Bytecode;
using NHibernate.Cfg;

namespace TeamWeb.Models.DAO.UserLoginDAO
{
    public class UserLoginDAO
    {
        private ISession session;
        public IList<PaperInfo> FindPaper()
        {
            session = NhibernateUtils.getSession();
            //  IList<UserInfo> userList = session.CreateQuery("from UserInfo").List<UserInfo>();
            IList<PaperInfo> userList = session.CreateQuery("from PaperInfo").List<PaperInfo>();　　//获取所有名字的IList集合
            session.Close();
            return userList;
        }
        public IList<TeacherInfo> FindName()
        {
            session = NhibernateUtils.getSession();
            //  IList<UserInfo> userList = session.CreateQuery("from UserInfo").List<UserInfo>();
            IList<TeacherInfo> userList = session.CreateQuery("from TeacherInfo").List<TeacherInfo>();　　//获取所有名字的IList集合
            session.Close();
            return userList;
        }
        public IList<NewsInfo> FindNews()
        {
            session = NhibernateUtils.getSession();
            //  IList<UserInfo> userList = session.CreateQuery("from UserInfo").List<UserInfo>();
            IList<NewsInfo> userList = session.CreateQuery("from NewsInfo").List<NewsInfo>();　　//获取所有名字的IList集合
            session.Close();
            return userList;
        }
        public IList<ProjectInfo> FindProject()
        {
            session = NhibernateUtils.getSession();
            //  IList<UserInfo> userList = session.CreateQuery("from UserInfo").List<UserInfo>();
            IList<ProjectInfo> userList = session.CreateQuery("from ProjectInfo").List<ProjectInfo>();　　//获取所有名字的IList集合
            session.Close();
            return userList;
        }
        public IList<WorkInfo> FindWorkStudentName()
        {
            session = NhibernateUtils.getSession();
            //  IList<UserInfo> userList = session.CreateQuery("from UserInfo").List<UserInfo>();
            IList<WorkInfo> userList = session.CreateQuery("from WorkInfo").List<WorkInfo>();　　//获取所有名字的IList集合
            session.Close();
            return userList;
        }
        public IList<TeamInfo> FindTeamField()
        {
            session = NhibernateUtils.getSession();
            IList<TeamInfo> userList = session.CreateQuery("from TeamInfo").List<TeamInfo>();　　//获取所有名字的IList集合
            session.Close();
            return userList;
        }
        public IList<StudentInfo> FindStudentName()
        {
            session = NhibernateUtils.getSession();
            string sql = @"select * from StudentInfo where GRADUATE = '是' and USERCODE  not IN (SELECT USERCODE FROM WORKINFO)";

            IList<StudentInfo> userStudentList = session.CreateSQLQuery(sql).AddEntity(typeof(StudentInfo)).List<StudentInfo>();

            session.Close();
            return userStudentList;
        }
        public IList<UserInfo> FindTeachersInfo()
        {
            session = NhibernateUtils.getSession();

            //  IList<UserInfo> userList = session.CreateQuery("from UserInfo").List<UserInfo>();
      
           // IList<UserInfo> userNameList = session.CreateQuery("from UserInfo where UserType = '教师' " ).List<UserInfo>();　　//获取所有名字的IList集合

            string sql = @"select * from UserInfo where UserType = '教师' and USERCODE  not IN (SELECT USERCODE FROM TEACHERINFO)";

            IList<UserInfo> userNameList= session.CreateSQLQuery(sql).AddEntity(typeof(UserInfo)).List<UserInfo>();

            session.Close();                   
            return userNameList;
           
        }
        public IList<UserInfo> FindTeacherName(string Id)
        {
            session = NhibernateUtils.getSession();
            IList<UserInfo> userList = session.CreateQuery("from UserInfo where USERCODE = '" + Id + "'").List<UserInfo>();
            session.Close();
            return userList;
        }
        public IList<StudentInfo> FindStudentUser(string Id)
        {
            session = NhibernateUtils.getSession();
            IList<StudentInfo> userStudentList = session.CreateQuery("from StudentInfo where USERCODE = '" + Id + "'").List<StudentInfo>();
            session.Close();
            return userStudentList;
        }
        public IList<TeacherInfo> FindTeacherInfo(string Id)
        {
            session = NhibernateUtils.getSession();
            IList<TeacherInfo> userList = session.CreateQuery("from TeacherInfo where USERCODE = '" + Id + "'").List<TeacherInfo>();
            session.Close();
            return userList;
        }
        public IList<UserInfo> FindUserMessage(string Id)
        {
            session = NhibernateUtils.getSession();
            IList<UserInfo> userList = session.CreateQuery("from UserInfo where USERCODE = '" + Id + "'").List<UserInfo>();
            session.Close();
            return userList;
        }
        public IList<TeacherInfo> FindTeacherMessage(string Id)
        {
            session = NhibernateUtils.getSession();
            IList<TeacherInfo> userList = session.CreateQuery("from TeacherInfo where USERCODE = '" + Id + "'").List<TeacherInfo>();
            session.Close();
            return userList;
        }
        public IList<StudentInfo> FindStudentMessage(string Id)
        {
            session = NhibernateUtils.getSession();
            IList<StudentInfo> userList = session.CreateQuery("from StudentInfo where USERCODE = '" + Id + "'").List<StudentInfo>();
            session.Close();
            return userList;
        }
        public IList<UserInfo> FindUsers(string userName)
        {
            session = NhibernateUtils.getSession();
            IList<UserInfo> userList = session.CreateQuery("from UserInfo where UserName = '" + userName + "'").List<UserInfo>();
            session.Close();
            return userList;
        }
        public IList<WorkInfo> FindStudentInfo(string Id)
        {
            session = NhibernateUtils.getSession();
            IList<WorkInfo> userList = session.CreateQuery("from WorkInfo where UserCode = '" + Id + "'").List<WorkInfo>();
            session.Close();
            return userList;
        }
        public IList<NewsInfo> FindAllNews(string Id)
        {
            session = NhibernateUtils.getSession();
            IList<NewsInfo> userList = session.CreateQuery("from NewsInfo where ID = '" + Id + "'").List<NewsInfo>();
            session.Close();
            return userList;
        }
        public IList<ProjectInfo> FindAllProject(string Id)
        {
            session = NhibernateUtils.getSession();
            IList<ProjectInfo> userList = session.CreateQuery("from ProjectInfo where PROJECTCODE = '" + Id + "'").List<ProjectInfo>();
            session.Close();
            return userList;
        }
        public IList<TeamInfo> FindAllTeam(string Id)
        {
            session = NhibernateUtils.getSession();
            IList<TeamInfo> userList = session.CreateQuery("from TeamInfo where ID = '" + Id + "'").List<TeamInfo>();
            session.Close();
            return userList;
        }
        public IList<UserInfo> FindAccountInfo(string userName, string pwd)
        {
            session = NhibernateUtils.getSession();
            IList<UserInfo> userList = session.CreateQuery("from UserInfo where USERNAME = '" + userName + "' and PASSWORD = '" + pwd + "'").List<UserInfo>();
            session.Close();
            return userList;
        }
        public IList<UserInfo> FindUserName(string userName)
        {
            session = NhibernateUtils.getSession();
            IList<UserInfo> userList = session.CreateQuery("from UserInfo where USERNAME = '" + userName + "'").List<UserInfo>();
            session.Close();
            return userList;
        }
        public IList<UserInfo> FoundUserInfo(string UserCode, string userName, string Name, string sex, string pwd, string email, string usertype, string qq, string phone, string Wx,string Power)
        {
            session = NhibernateUtils.getSession();
            IList<UserInfo> userList = session.CreateSQLQuery(" Update UserInfo SET userNAME =  '" + userName + "',realName =  '" + Name + "',sex =  '" + sex + "',password =  '" + pwd + "',email =  '" + email + "',usertype =  '" + usertype + "',qq =  '" + qq + "',phone =  '" + phone + "',WX =  '" + Wx + "',Power =  '" + Power + "' where USERCODE = '" + UserCode + "'").AddEntity(typeof(UserInfo)).List<UserInfo>();
            session.Close();
            return userList;
        }
        public IList<NewsInfo> FoundNews2(string Time, string Title, string content, string Name, string n)
        {
            session = NhibernateUtils.getSession();
            IList<NewsInfo> userList = session.CreateSQLQuery(" Update NewsInfo SET Time = to_date('" + Time + "','YYYY-MM-DD'),Title =  '" + Title + "',Introduce =  '" + content + "',Name =  '" + Name + "' where ID = '" + n + "'").AddEntity(typeof(NewsInfo)).List<NewsInfo>();
            session.Close();
            return userList;
        }
        public IList<ProjectInfo> CheckProject2(string n, string PROJECTNAME, string PROJECTBIGCLASS, string PROJECTSMALLCLASS, string PROJECTMANAGER, string PROJECTGROUPER, string PROJECTMEMBER, string PROJECTSTART, string PROJECTEND, string PROJECTPAGE, string Name, string PROJECTIMAGE)
        {
            session = NhibernateUtils.getSession();
            IList<ProjectInfo> userList = session.CreateSQLQuery(" Update ProjectInfo SET PROJECTMANAGER =  '" + PROJECTMANAGER + "',PROJECTSMALLCLASS =  '" + PROJECTSMALLCLASS + "',PROJECTBIGCLASS =  '" + PROJECTBIGCLASS + "',PROJECTNAME =  '" + PROJECTNAME + "',PROJECTEND = to_date('" + PROJECTEND + "','YYYY-MM-DD'),PROJECTSTART = to_date('" + PROJECTSTART + "','YYYY-MM-DD'),PROJECTIMAGE =  '" + PROJECTIMAGE + "',PROJECTPAGE =  '" + PROJECTPAGE + "',RROJECTTITLE =  '" + Name + "',PROJECTMEMBER =  '" + PROJECTMEMBER + "',PROJECTGROUPER =  '" + PROJECTGROUPER + "' where PROJECTCODE = '" + n + "'").AddEntity(typeof(ProjectInfo)).List<ProjectInfo>();
            session.Close();
            return userList;
        }
        public IList<UserInfo> FoundUserName(string userName,string HeadImage)
        {
            session = NhibernateUtils.getSession();
            IList<UserInfo> userList = session.CreateSQLQuery(" Update UserInfo SET HeadImage =  '" + HeadImage + "' where userNAME =  '" + userName + "'").AddEntity(typeof(UserInfo)).List<UserInfo>();
            session.Close();
            return userList;
        }
        public IList<TeamInfo> CheckTeamImage(string Id, string Image)
        {
            session = NhibernateUtils.getSession();
            IList<TeamInfo> userList = session.CreateSQLQuery(" Update TeamInfo SET Image =  '" + Image + "' where Teamfield =  '" + Id + "'").AddEntity(typeof(TeamInfo)).List<TeamInfo>();
            session.Close();
            return userList;
        }
        public IList<TeacherInfo> FoundTeacherName(string UserCode, string Photo)
        {
            session = NhibernateUtils.getSession();
            IList<TeacherInfo> userList = session.CreateSQLQuery(" Update TeacherInfo SET Photo =  '" + Photo + "' where UserCode =  '" + UserCode + "'").AddEntity(typeof(TeacherInfo)).List<TeacherInfo>();
            session.Close();
            return userList;
        }
        public IList<PaperInfo> CheckPaper(string UserCode, string PAPERADDRESS)
        {
            session = NhibernateUtils.getSession();
            IList<PaperInfo> userList = session.CreateSQLQuery(" Update PaperInfo SET PAPERADDRESS =  '" + PAPERADDRESS + "' where Id =  '" + UserCode + "'").AddEntity(typeof(PaperInfo)).List<PaperInfo>();
            session.Close();
            return userList;
        }
        public IList<StudentInfo> CheckStudent(string UserCode, string Photo)
        {
            session = NhibernateUtils.getSession();
            IList<StudentInfo> userList = session.CreateSQLQuery(" Update StudentInfo SET Photo =  '" + Photo + "' where UserCode =  '" + UserCode + "'").AddEntity(typeof(StudentInfo)).List<StudentInfo>();
            session.Close();
            return userList;
        }
        public IList<UserInfo> DelUserInfo(string UserCode)
        {
            session = NhibernateUtils.getSession();
            IList<UserInfo> userList = session.CreateSQLQuery("delete userinfo where USERCODE = '" + UserCode + "'").AddEntity(typeof(UserInfo)).List<UserInfo>();
            session.Close();
            return userList;
        }
        public IList<StudentInfo> DelStudentInfo(string UserCode)
        {
            session = NhibernateUtils.getSession();
            IList<StudentInfo> userList = session.CreateSQLQuery("delete StudentInfo where Id = '" + UserCode + "'").AddEntity(typeof(StudentInfo)).List<StudentInfo>();
            session.Close();
            return userList;
        }
        public IList<PaperInfo> DelPaperInfo(string UserCode)
        {
            session = NhibernateUtils.getSession();
            IList<PaperInfo> userList = session.CreateSQLQuery("delete PaperInfo where Id = '" + UserCode + "'").AddEntity(typeof(PaperInfo)).List<PaperInfo>();
            session.Close();
            return userList;
        }
        public IList<TeamInfo> DelTeamInfo(string UserCode)
        {
            session = NhibernateUtils.getSession();
            IList<TeamInfo> userList = session.CreateSQLQuery("delete TeamInfo where Id = '" + UserCode + "'").AddEntity(typeof(TeamInfo)).List<TeamInfo>();
            session.Close();
            return userList;
        }
        public IList<WorkInfo> DelWorkInfo(string UserCode)
        {
            session = NhibernateUtils.getSession();
            IList<WorkInfo> userList = session.CreateSQLQuery("delete WorkInfo where Id = '" + UserCode + "'").AddEntity(typeof(WorkInfo)).List<WorkInfo>();
            session.Close();
            return userList;
        }
        public IList<NewsInfo> DelNewsInfo(string UserCode)
        {
            session = NhibernateUtils.getSession();
            IList<NewsInfo> userList = session.CreateSQLQuery("delete NewsInfo where Id = '" + UserCode + "'").AddEntity(typeof(NewsInfo)).List<NewsInfo>();
            session.Close();
            return userList;
        }
        public IList<ProjectInfo> DelProjectInfo(string UserCode)
        {
            session = NhibernateUtils.getSession();
            IList<ProjectInfo> userList = session.CreateSQLQuery("delete ProjectInfo where PROJECTCODE = '" + UserCode + "'").AddEntity(typeof(ProjectInfo)).List<ProjectInfo>();
            session.Close();
            return userList;
        }
        public IList<TeacherInfo> DelTeacherInfo(string UserCode)
        {
            session = NhibernateUtils.getSession();
            IList<TeacherInfo> userList = session.CreateSQLQuery("delete TeacherInfo where Id = '" + UserCode + "'").AddEntity(typeof(TeacherInfo)).List<TeacherInfo>();
            session.Close();
            return userList;
        }
        public IList<TeacherInfo> FoundInfo(string UserCode, string Name, string Title, string Credit, string Directon, string Introduce)
        {
            session = NhibernateUtils.getSession();
            IList<TeacherInfo> userList = session.CreateSQLQuery(" Update TeacherInfo SET NAME =  '" + Name + "',TITLE =  '" + Title + "',CREDIT =  '" + Credit + "',DIRECTION =  '" + Directon + "',INTRODUCE =  '" + Introduce + "' where USERCODE = '" + UserCode + "'").AddEntity(typeof(TeacherInfo)).List<TeacherInfo>();
            session.Close();
            return userList;
        }
        public IList<TeamInfo> FoundTeamInfo(string UserCode, string TeamField, string TeamIntroduce)
        {
            session = NhibernateUtils.getSession();
            IList<TeamInfo> userList = session.CreateSQLQuery(" Update TeamInfo SET TeamField =  '" + TeamField + "',TeamIntroduce =  '" + TeamIntroduce + "'where Id = '" + UserCode + "'").AddEntity(typeof(TeamInfo)).List<TeamInfo>();
            session.Close();
            return userList;
        }
        public IList<WorkInfo> FoundWorkInfo(string UserCode, string Company)
        {
            session = NhibernateUtils.getSession();
            IList<WorkInfo> userList = session.CreateSQLQuery(" Update WorkInfo SET COMPANY =  '" + Company + "' where USERCODE = '" + UserCode + "'").AddEntity(typeof(WorkInfo)).List<WorkInfo>();
            session.Close();
            return userList;
        }
        public bool SaveUser(TeacherInfo teacherInfo)
        {
            session = NhibernateUtils.getSession();
            ITransaction tsc = session.BeginTransaction();
            try
            {
                session.Save(teacherInfo);
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
        public bool SaveNews(NewsInfo newsInfo)
        {
            session = NhibernateUtils.getSession();
            ITransaction tsc = session.BeginTransaction();
            try
            {
                session.Save(newsInfo);
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
        public bool SaveTeam(TeamInfo teamInfo)
        {
            session = NhibernateUtils.getSession();
            ITransaction tsc = session.BeginTransaction();
            try
            {
                session.Save(teamInfo);
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
        public bool SaveWorkUser(WorkInfo workInfo)
        {
            session = NhibernateUtils.getSession();
            ITransaction tsc = session.BeginTransaction();
            try
            {
                session.Save(workInfo);
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
    }
}