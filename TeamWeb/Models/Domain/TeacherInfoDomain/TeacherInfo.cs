using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamWeb.Models.Domain.TeacherInfoDomain
{
    public class TeacherInfo
    {
        public string Id { set; get; }
        public string UserCode { get; set; }
        public string Name { set; get; }
        public string Title { set; get; }
        public string Credit { set; get; }
        public string Direction { set; get; }
        public string Introduce { set; get; }
        public string Photo { set; get; }
    }
}