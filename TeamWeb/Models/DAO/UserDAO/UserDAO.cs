using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamWeb.Models.Domain.UserDomain;
using TeamWeb.Util;
using NHibernate;
using NHibernate.Bytecode;
using NHibernate.Cfg;

namespace TeamWeb.Models.DAO.UserDAO
{
    public class UserDAO:IUser
    {
        private ISession session;
        public IList<User> FindUserByUserName(string userName)
        {
            session = NhibernateUtils.getSession();
            IList<User> userList = session.CreateQuery("from User u where u.UserName='" + userName + "'").List<User>();
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