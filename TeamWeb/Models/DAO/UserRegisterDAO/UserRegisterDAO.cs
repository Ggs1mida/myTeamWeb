using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamWeb.Models.Domain.UserInfoDomain;
using TeamWeb.Util;
using NHibernate;
using NHibernate.Bytecode;
using NHibernate.Cfg;

namespace TeamWeb.Models.DAO.UserRegisterDAO
{
    public class UserRegisterDAO
    {
        private ISession session;
        public IList<UserInfo> FindUserByUserName(string userName)
        {
            session = NhibernateUtils.getSession();
            IList<UserInfo> userList = session.CreateQuery("from User u where u.UserName='" + userName + "'").List<UserInfo>();
            session.Close();
            return userList;         
        }

       

        public bool SaveUser(UserInfo userinfo)
        {
            session = NhibernateUtils.getSession();
            ITransaction tsc = session.BeginTransaction();
            try
            {
                session.Save(userinfo);
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