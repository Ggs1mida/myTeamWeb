using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamWeb.Models.Domain.TeamInfoDomain
{
    public class TeamInfo
    {
        public string Id { set; get; }
        public string TeamField { get; set; }
        public string TeamIntroduce { set; get; }
        public string Image { set; get; }
    }
}