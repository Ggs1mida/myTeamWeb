using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamWeb.Models.Domain.ProjectInfoDomain
{
    public class ProjectInfo
    {
        public string PROJECTCODE { get; set; }
        public string PROJECTNAME { get; set; }
        public string PROJECTBIGCLASS { get; set; }
        public string PROJECTSMALLCLASS { set; get; }
        public string PROJECTMANAGER { set; get; }
        public string PROJECTGROUPER { set; get; }
        public string PROJECTMEMBER { set; get; }
        public DateTime PROJECTSTART { set; get; }
        public DateTime PROJECTEND { set; get; }
         public string PROJECTPAGE { set; get; }
         public string PROJECTIMAGE { set; get; }
         public string RROJECTTITLE { set; get; }
   }

}