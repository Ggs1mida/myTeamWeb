using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace TeamWeb.Models.Domain.PaperInfoDomain
{
    public class PaperInfo
    {
        public string ID { get; set; }
        public string PAPERNAME { get; set; }
        public string PAPERDESCRIBE { get; set; }
        public string PAPERAUTHOR { set; get; }
        public Int32 PAPERYEAR { set; get; }
        public string PAPERADDRESS { set; get; }
        public string PAPERTYPE { set; get; }
        public string UPLOADTIME { set; get; }

      
       
    }
    
}