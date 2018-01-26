using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamWeb.Models.Domain.UserInfoDomain
{
    public class UserInfo
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string Name { set; get; }
        public string Sex { set; get; }
        public string UserType { set; get; }
        public string Email { set; get; }
        public string QQ { set; get; }
        public string Headimage { set; get; }
        public string Phone { set; get; }
        public string Wx { set; get; }
        public string Power { set; get; }
    }
}