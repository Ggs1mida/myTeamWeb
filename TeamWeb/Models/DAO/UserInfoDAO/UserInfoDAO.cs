using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamWeb.Models.Domain.UserDomain;
using TeamWeb.Models.Domain.UserInfoDomain;
using TeamWeb.Models.Domain.ClassInfoDomain;
using TeamWeb.Util;
using NHibernate;
using NHibernate.Bytecode;
using NHibernate.Cfg;

namespace TeamWeb.Models.DAO.UserInfoDAO
{
    public class UserInfoDAO
    {
        private ISession session;
        public IList<String> FindUserByUserName()
        {
            session = NhibernateUtils.getSession();
          //  IList<UserInfo> userList = session.CreateQuery("from UserInfo").List<UserInfo>();
            IList<String> userNameList = session.QueryOver<UserInfo>().Select(p => p.Name).List<String>();　　//获取所有名字的IList集合
            session.Close();
            return userNameList;         
        }
        public IList<ClassInfo> FindAllClassInfo()
        {
            session = NhibernateUtils.getSession();
            //  IList<UserInfo> userList = session.CreateQuery("from UserInfo").List<UserInfo>();
            IList<ClassInfo> userList = session.CreateQuery("from ClassInfo").List<ClassInfo>();        　　//获取所有名字的IList集合
            session.Close();
            return userList;
        }
        //public IList<String> FindAllClassInfo2()
        //{
        //    session = NhibernateUtils.getSession();
        //    //  IList<UserInfo> userList = session.CreateQuery("from UserInfo").List<UserInfo>();
        //    IList<String> userList = session.QueryOver<ClassInfo>().Select(p => p.Small).List<String>();　　//获取所有名字的IList集合
        //    session.Close();
        //    return userList;
        //}
        public IList<UserInfo> FindUser()
        {
            session = NhibernateUtils.getSession();
            IList<UserInfo> userList = session.CreateQuery("from UserInfo").List<UserInfo>();        
            session.Close();
            return userList;         
        }
        public IList<UserInfo> FindUser2()
        {
            session = NhibernateUtils.getSession();
            IList<UserInfo> userList = session.CreateQuery("from UserInfo where power = '用户'").List<UserInfo>();
            session.Close();
            return userList;
        }
        public IList<User> FindAccountInfo(string userName, string pwd)
        {
            session = NhibernateUtils.getSession();
            IList<User> userList = session.CreateQuery("from User u where u.UserName = '" + userName + "' and u.Pwd = '" + pwd + "'").List<User>();
            session.Close();
            return userList;
        }

        public bool SaveUser(User user)
        {
            session = NhibernateUtils.getSession();
            ITransaction tsc = session.BeginTransaction();
            try
            {
                session.Save(user);
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