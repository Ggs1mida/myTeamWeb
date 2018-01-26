using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWeb.Models.Domain.UserDomain;
using TeamWeb.Models.DAO.PaperDAO;

namespace TeamWeb.Service
{
    //interface Newsservice
    //{
    //    IList<User> FindUserByUserName(string userName);
    //    bool CheckAccountInfo(string userName, string pwd);
    //    bool CreatUser(User user);
    //    bool SendMail(string to);

    //}
    public  class NewsService{
        public string List(){
            return new NewsDAO().List();
        }
    }

}

