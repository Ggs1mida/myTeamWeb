using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamWeb.Models.Domain.NewsInfoDomain
{
    public class NewsInfo
    {
        public string Id { set; get; }
        public string Title { get; set; }
        public DateTime Time { set; get; }
        public string Introduce { set; get; }
        public string Name { set; get; }
    
    }
}