using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using TeamWeb.Models.Domain.UserDomain;
using TeamWeb.Models.DAO;
namespace TeamWeb.Service
{
    public class SolutionService
    {
        public string ListType()
        {
            return new SolutionDAO().ListType();
        }
        public string ListCont(string small, string big)
        {
            return new SolutionDAO().ListCont(small, big);
        }
        public string ListYear(string type)
        {
            return new SolutionDAO().ListYear(type);
        }
        public string listcontent(string year, string papertype, string type)
        {
            return new SolutionDAO().listcontent(year, papertype, type);
        }
    }
}