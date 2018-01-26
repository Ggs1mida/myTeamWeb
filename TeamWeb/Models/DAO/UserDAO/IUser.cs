using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWeb.Models.Domain.UserDomain;

namespace TeamWeb.Models.DAO.UserDAO
{
    interface IUser
    {
       IList<User> FindUserByUserName(string userName);
       IList<User> FindAccountInfo(string userName, string pwd);
       bool SaveUser(User user);
    }
}
