using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace TeamWeb.Models.Domain.StudentDomain
{
    public class StudentInfo
    {
        public string ID { get; set; }
        public string GRADUATE { get; set; }
        public string NAME { get; set; }
        public string USERCODE { get; set; }
        public string INTRODUCE { get; set; }
        public DateTime SCHOOLSTART { get; set; }
        public DateTime END { get; set; }
        public string MAJOR { get; set; }
        public string PHOTO { get; set; }
        public string DEGREE { get; set; }
    }
}