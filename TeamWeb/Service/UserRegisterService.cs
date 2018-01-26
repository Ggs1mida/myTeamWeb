using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamWeb.Models.DAO.UserRegisterDAO;
using TeamWeb.Models.Domain.UserInfoDomain;
using System.Net;
using System.Net.Mail;
using TeamWeb.Service;

namespace TeamWeb.Service
{
    public class UserRegisterService
    {
        public IList<UserInfo> FindUserByUserName(string username)
        {
            return new UserRegisterDAO().FindUserByUserName(username);
        }
        public bool CreatUser(UserInfo userinfo)
        {
            return new UserRegisterDAO().SaveUser(userinfo);
        }
    }
}