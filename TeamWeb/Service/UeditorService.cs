using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamWeb.Models.DAO.UserLoginDAO;
using TeamWeb.Models.Domain.UserInfoDomain;
using TeamWeb.Models.Domain.TeacherInfoDomain;
using TeamWeb.Models.Domain.StudentDomain;
using TeamWeb.Models.Domain.WorkDomain;
using TeamWeb.Models.Domain.TeamInfoDomain;
using System.Net;
using System.Net.Mail;
using TeamWeb.Service;
using System.IO;

namespace TeamWeb.Service
{
    public class UeditorService
    {
        public string CreatHtml(string content)
        {
            string name = DateTime.Now.ToString("yyyyMMddHHmmss") + ".html";
            string prepath = @"D:\MVCRoot\teamweb\common\staticpage\";
            string path = prepath + name;
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("<!DOCTYPE html>"+
"<html lang='en'>"+
"<head>"+
    "<meta charset='UTF-8'>"+
    "<meta name='viewport' content='width=device-width, initial-scale=1.0'>"+
    "<meta http-equiv='X-UA-Compatible' content='ie=edge'>"+
    "<title>南理工自动化研究所</title>"+
    "<link rel='stylesheet' href='http://egov.jinyuc.com/teamweb/common/jscss/amazeui.css' />"+
    "<link rel='stylesheet' href='http://egov.jinyuc.com/teamweb/common/jscss/common.min.css' />"+
    "<link rel='stylesheet' href='http://egov.jinyuc.com/teamweb/common/jscss/news.min.css' />"+
"</head>"+
"<body>"+
    "<div class='layout'>"+
        "<div class='layout-header am-hide-sm-only'>"+
            "<!--topbar start-->"+
            
                
            "</div>"+

            "<!--pc端导航栏-->"+
            "<div class='header-box' data-am-sticky>"+
                "<div class='nav-contain'>"+
                    "<div class='nav-inner'>"+
                        "<ul class='am-nav am-nav-pills am-nav-justify'>"+
                            "<li class=''><a href='http://egov.jinyuc.com/teamweb/twqd/Index/index'>首页</a></li>"+
                            "<li style='text-align:center'>"+
                                "科研成果"+
                                "<ul class='sub-menu'>"+
                                    "<li class='menu-item'><a href='http://egov.jinyuc.com/teamweb/twqd/Solution/theory'>理论研究</a></li>"+
                                    "<li class='menu-item'><a href='http://egov.jinyuc.com/teamweb/twqd/Solution/solution'>项目研究</a></li>"+
                                "</ul>"+
                            "</li>"+
                            "<li>"+
                                "<a href='http://egov.jinyuc.com/teamweb/twqd/Reaserch/reaserch'>研究领域</a>"+
                            "</li>"+
                            "<li>"+
                                "<a href='http://egov.jinyuc.com/teamweb/twqd/We/about'>"+
                                    "团队介绍"+

                                "</a>"+
                            "</li>"+
                            "<li><a href='http://egov.jinyuc.com/teamweb/twqd/We/join'>加入我们</a></li>"+
                            "<li><a href='http://egov.jinyuc.com/teamweb/twqd/We/contact'>联系我们</a></li>"+
                        "</ul>"+
                    "</div>"+
                "</div>"+
            "</div>"+
        "</div>"+
        "<div class='m-header'>"+
            "<div class='am-g am-show-sm-only'>"+
                "<div class='am-u-sm-2'>"+
                    "<a href='http://egov.jinyuc.com/teamweb/twqd/#mheader' class='am-menu-toggle-icon am-icon-bars'></a>"+
                    "<div class='menu-bars'>"+
                        "<nav data-am-widget='menu' class='am-menu  am-menu-dropdown1"+
                             "data-am-menu-collapse>"+
                            "<a href='http://egov.jinyuc.com/teamweb/twqd/javascript: void(0)' class='am-menu-toggle'>"+"</a>"+
                            "<ul class='am-menu-nav am-avg-sm-1 am-collapse' id='mheader'>"+
                                "<li class='am-active'><a href='http://egov.jinyuc.com/teamweb/twqd/Index/index' class=''>首页</a>"+"</li>"+
                                "<li class='am-parent'>"+
                                    "<a href='http://egov.jinyuc.com/teamweb/twqd/##' class=''>科研成果</a>"+
                                    "<ul class='am-menu-sub am-collapse  am-avg-sm-3 '>"+
                                        "<li class=''>"+
                                            "<a href='http://egov.jinyuc.com/teamweb/twqd/Solution/theory' class=''>理论研究</a>"+
                                        "</li>"+
                                        "<li class=''>"+
                                            "<a href='http://egov.jinyuc.com/teamweb/twqd/Solution/solution' class=''>项目研究</a>"+
                                        "</li>"+
                                    "</ul>"+
                                "</li>"+
                                "<li class=''>"+
                                    "<a href='http://egov.jinyuc.com/teamweb/twqd/Reaserch/reaserch' class=''>研究领域</a>"+
                                "</li>"+
                                "<li class=''>"+
                                    "<a href='http://egov.jinyuc.com/teamweb/twqd/We/about' class=''>团队介绍</a>"+
                                "</li>"+
                                "<li class=''>"+
                                    "<a href='http://egov.jinyuc.com/teamweb/twqd/We/join' class=''>加入我们</a>"+
                                "</li>"+
                                "<li class=''>"+
                                    "<a href='http://egov.jinyuc.com/teamweb/twqd/We/contact' class=''>联系我们</a>"+
                                "</li>"+
                            "</ul>"+
                        "</nav>"+
                    "</div>"+
                "</div>"+
                "<div class='am-u-sm-5 am-u-end'>"+
                    "<div class='m-logo'>"+
                        "<a href='http://egov.jinyuc.com/teamweb/twqd/'>"+"<img src='../jscss/logo.png' alt='' />"+"</a>"+
                    "</div>"+
                "</div>"+
            "</div>"+
        "</div>"+

        "<!--侧栏主要内容-->"+
        "<div class='am-g am-show-sm-only'>"+
            "<div class='am-u-sm-2'>"+
                "<div class='menu-bars'>"+
                    "<nav data-am-widget='menu' class='am-menu  am-menu-offcanvas1' data-am-menu-offcanvas>"+
                        "<!--   "+   "<a href='http://egov.jinyuc.com/teamweb/twqd/javascript: void(0)' class='am-menu-toggle'></a>"+ "-->"+
                        "<div class='am-offcanvas' id='doc-oc-demo1'>"+
                            "<div class='am-offcanvas-bar'>"+
                                "<nav class='scrollspy-nav' data-am-scrollspynav data-am-sticky>"+
                                    "<ul class='am-menu-nav am-avg-sm-1'>"+
                                        "<li><a href='http://egov.jinyuc.com/teamweb/twqd/#team' class=''>团队简介</a>"+"</li>"+
                                        "<li class=''><a href='http://egov.jinyuc.com/teamweb/twqd/#welcome' class=''>期待你的加入</a>"+"</li>"+
                                        "<li class=''><a href='http://egov.jinyuc.com/teamweb/twqd/#contact' class=''>联系方式</a>"+"</li>"+
                                    "</ul>"+
                                "</nav>"+
                            "</div>"+
                        "</div>"+
                    "</nav>"+
                "</div>"+
            "</div>"+

        "</div>"+


        "<!--===========layout-container================-->"+
        "<div class='layout-container'>"+
            "<div class='page-header'>"+
                "<div class='am-container'>"+
                    "<h1 class='page-header-title'>正文</h1>"+
                "</div>"+
            "</div>"+

            "<div class='breadcrumb-box'>"+
                "<div class='am-container'>"+
                    "<ol class='am-breadcrumb'>"+
                        "<li><a href='http://egov.jinyuc.com/teamweb/twqd/Index/index'>首页</a>"+"</li>"+
                        "<li class='am-active'>正文</li>"+
                    "</ol>"+
                "</div>"+
            "</div>"+
        "</div>"+

        "<div class='section news-section'>"+
            "<div class='container'>"+
                "<!--news-section left start-->"+

                "<div class='article'>"+
                    "<header class='article--header'>"+
                        "<h2 class='article--title'><a href='http://egov.jinyuc.com/teamweb/twqd/#' rel=''>二维电子罗盘</a></h2>"+
                    "</header><div class='article--content'>"
                    );
                    sw.WriteLine(content);
                    sw.WriteLine("</div>"+
                "</div>"+
            "</div>"+
        "</div>"+
    "</div>"+
    "<!--===========layout-container================-->"+
    "<div class='layout-footer'>"+
        "<div class='footer'>"+
            "<div style='background-color:#383d61' class='footer--bg'>"+"</div>"+
            "<div class='footer--inner'>"+
                "<div class='container'>"+
                    "<div class='footer_main'>"+
                        "<div class='am-g'>"+

                            "<div class='footer_main--column'>"+
                                "<strong class='footer_main--column_title'>南理工自动化研究所</strong>"+
                                "<div class='footer_about'>"+
                                    "<p class='footer_about--text'>"+
                                        "云适配(AllMobilize Inc.) 是全球领先的HTML5企业移动化解决方案供应商，由前微软美国总部IE浏览器核心研发团队成员及移动互联网行业专家在美国西雅图创立."+
                                    "</p>"+
                                    "<p class='footer_about--text'>"+
                                        "云适配跨屏云也成功应用于超过30万家企业网站，包括微软、联想等世界500强企业"+
                                    "</p>"+
                                "</div>"+
                            "</div>"+



                        "</div>"+
                    "</div>"+
                "</div>"+
            "</div>"+
        "</div>"+
    "</div>"+
    "<!--右下角图标-->"+

    "<div class='amz-toolbar' id='amz-toolbar' style='right:10px'>"+
        
    "</div>"+
    "<script src='../jscss/jquery-2.1.0.js' charset='utf-8'>"+"</script>"+
    "<script src='../jscss/amazeui.js' charset='utf-8'>"+"</script>"+
"</body>"+
"</html>"
                        );
                }
            }
            return name;
        }
    }
}