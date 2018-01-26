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
    public class WeService
    {
        public string ListTeacher()
        {
            return new WeDAO().ListTeacher();
        }
        public string ListStudent(string graduate)
        {
            return new WeDAO().ListStudent(graduate);
        }
    }
}