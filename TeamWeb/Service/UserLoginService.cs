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
using TeamWeb.Models.Domain.NewsInfoDomain;
using TeamWeb.Models.Domain.ProjectInfoDomain;
using TeamWeb.Models.Domain.PaperInfoDomain;
using System.Net;
using System.Net.Mail;
using TeamWeb.Service;

namespace TeamWeb.Service
{
    public class UserLoginService
    {
        public bool CreatUser(TeacherInfo teacherInfo)
        {
            return new UserLoginDAO().SaveUser(teacherInfo);
        }
        public bool CreatTeam(TeamInfo teamInfo)
        {
            return new UserLoginDAO().SaveTeam(teamInfo);
        }
        public bool CreatNews(NewsInfo newsInfo)
        {
            return new UserLoginDAO().SaveNews(newsInfo);
        }
        public bool CreatWorkUser(WorkInfo workInfo)
        {
            return new UserLoginDAO().SaveWorkUser(workInfo);
        }
        public IList<TeacherInfo> FindUser()
        {
            return new UserLoginDAO().FindName();
        }
        public IList<PaperInfo> FindPaper()
        {
            return new UserLoginDAO().FindPaper();
        }
        public IList<WorkInfo> FindWorkStudent()
        {
            return new UserLoginDAO().FindWorkStudentName();
        }
        public IList<NewsInfo> FindNews()
        {
            return new UserLoginDAO().FindNews();
        }
        public IList<ProjectInfo> FindProjrct()
        {
            return new UserLoginDAO().FindProject();
        }
        public IList<TeamInfo> FindTeamField()
        {
            return new UserLoginDAO().FindTeamField();
        }
        public IList<StudentInfo> FindStudent()
        {
            return new UserLoginDAO().FindStudentName();
        }

        public IList<UserInfo> FindUserMessage(string Id)
        {
            return new UserLoginDAO().FindUserMessage(Id);
        }
        public IList<TeacherInfo> FindTeacherMessage(string Id)
        {
            return new UserLoginDAO().FindTeacherMessage(Id);
        }
        public IList<StudentInfo> FindStudentMessage(string Id)
        {
            return new UserLoginDAO().FindStudentMessage(Id);
        }
        public IList<UserInfo> FindTeachers()
        {
            return new UserLoginDAO().FindTeachersInfo();
        }
        public IList<UserInfo> FindName(string Id)
        {
            return new UserLoginDAO().FindTeacherName(Id);
        }
        public IList<StudentInfo> FindStudentUser(string Id)
        {
            return new UserLoginDAO().FindStudentUser(Id);
        }
        public IList<TeacherInfo> FindAllMessage(string UserCode)
        {
            return new UserLoginDAO().FindTeacherInfo(UserCode);
        }
        public IList<WorkInfo> FindAllWork(string UserCode)
        {
            return new UserLoginDAO().FindStudentInfo(UserCode);
        }
        public IList<TeamInfo> FindAllTeam(string Id)
        {
            return new UserLoginDAO().FindAllTeam(Id);
        }
        public IList<NewsInfo> FindAllNews(string Id)
        {
            return new UserLoginDAO().FindAllNews(Id);
        }
        public IList<ProjectInfo> FindAllProject(string Id)
        {
            return new UserLoginDAO().FindAllProject(Id);
        }
        public bool CheckTeacherInfo(string Id)
        {
            IList<TeacherInfo> user = new UserLoginDAO().FindTeacherInfo(Id);
            return user.Count() == 0 ? false : true;
        }
        public bool CheckUserInfo(string userName)
        {
            IList<UserInfo> user = new UserLoginDAO().FindUsers(userName);
            return user.Count() == 0 ? false : true;
        }
        public bool CheckStudentInfo(string Id)
        {
            IList<WorkInfo> user = new UserLoginDAO().FindStudentInfo(Id);
            return user.Count() == 0 ? false : true;
        }
        public bool CheckAccountInfo(string userName, string pwd)
        {
            IList<UserInfo> user = new UserLoginDAO().FindAccountInfo(userName, pwd);
            return user.Count() == 0 ? false : true;
        }
        public IList<UserInfo> FindUserName(string userName)
        {
            return new UserLoginDAO().FindUserName(userName);
        }
        public bool CheckNewUserInfo(string UserCode, string userName, string Name, string sex, string pwd, string email, string usertype, string qq, string phone, string Wx,string Power)
        {
            IList<UserInfo> user = new UserLoginDAO().FoundUserInfo(UserCode, userName, Name, sex, pwd, email, usertype, qq, phone, Wx, Power);
            return user.Count() == 0 ? false : true;
        }
        public bool CheckNews2(string Time, string Title, string content, string Name, string n)
        {
            IList<NewsInfo> user = new UserLoginDAO().FoundNews2(Time, Title, content, Name, n);
            return user.Count() == 0 ? false : true;
        }
        public bool CheckProject2(string n, string PROJECTNAME, string PROJECTBIGCLASS, string PROJECTSMALLCLASS, string PROJECTMANAGER, string PROJECTGROUPER, string PROJECTMEMBER, string PROJECTSTART, string PROJECTEND, string PROJECTPAGE, string Name, string PROJECTIMAGE)
        {
            IList<ProjectInfo> user = new UserLoginDAO().CheckProject2(n, PROJECTNAME, PROJECTBIGCLASS, PROJECTSMALLCLASS, PROJECTMANAGER, PROJECTGROUPER, PROJECTMEMBER, PROJECTSTART, PROJECTEND, PROJECTPAGE, Name, PROJECTIMAGE);
            return user.Count() == 0 ? false : true;
        }
        public bool CheckUser(string userName,string HeadImage)
        {
            IList<UserInfo> user = new UserLoginDAO().FoundUserName(userName,  HeadImage);
            return user.Count() == 0 ? false : true;
        }
        public bool CheckTeamImage(string Id, string Image)
        {
            IList<TeamInfo> user = new UserLoginDAO().CheckTeamImage(Id, Image);
            return user.Count() == 0 ? false : true;
        }
        public bool CheckTeacher(string UserCode, string Photo)
        {
            IList<TeacherInfo> user = new UserLoginDAO().FoundTeacherName(UserCode, Photo);
            return user.Count() == 0 ? false : true;
        }
        public bool CheckPaper(string UserCode, string PAPERADDRESS)
        {
            IList<PaperInfo> user = new UserLoginDAO().CheckPaper(UserCode, PAPERADDRESS);
            return user.Count() == 0 ? false : true;
        }
        public bool CheckStudent(string UserCode, string Photo)
        {
            IList<StudentInfo> user = new UserLoginDAO().CheckStudent(UserCode, Photo);
            return user.Count() == 0 ? false : true;
        }
        public bool DelTeacherInfo(string UserCode)
        {
            IList<TeacherInfo> user = new UserLoginDAO().DelTeacherInfo(UserCode);
            return user.Count() == 0 ? false : true;
        }
        public bool DelUserInfo(string UserCode)
        {
            IList<UserInfo> user = new UserLoginDAO().DelUserInfo(UserCode);
            return user.Count() == 0 ? false : true;
        }
        public bool DelStudentInfo(string UserCode)
        {
            IList<StudentInfo> user = new UserLoginDAO().DelStudentInfo(UserCode);
            return user.Count() == 0 ? false : true;
        }
        public bool DelPaperInfo(string UserCode)
        {
            IList<PaperInfo> user = new UserLoginDAO().DelPaperInfo(UserCode);
            return user.Count() == 0 ? false : true;
        }
        public bool DelWorkInfo(string UserCode)
        {
            IList<WorkInfo> user = new UserLoginDAO().DelWorkInfo(UserCode);
            return user.Count() == 0 ? false : true;
        }
        public bool DelNewsInfo(string UserCode)
        {
            IList<NewsInfo> user = new UserLoginDAO().DelNewsInfo(UserCode);
            return user.Count() == 0 ? false : true;
        }
        public bool DelProjectInfo(string UserCode)
        {
            IList<ProjectInfo> user = new UserLoginDAO().DelProjectInfo(UserCode);
            return user.Count() == 0 ? false : true;
        }
        public bool DelTeamInfo(string UserCode)
        {
            IList<TeamInfo> user = new UserLoginDAO().DelTeamInfo(UserCode);
            return user.Count() == 0 ? false : true;
        }
        public bool CheckNewInfo(string UserCode, string Name, string Title, string Credit, string Directon, string Introduce)
        {
            IList<TeacherInfo> user = new UserLoginDAO().FoundInfo(UserCode, Name, Title, Credit, Directon, Introduce);
            return user.Count() == 0 ? false : true;
        }
        public bool CheckNewTeamInfo(string UserCode, string TeamField, string TeamIntroduce)
        {
            IList<TeamInfo> user = new UserLoginDAO().FoundTeamInfo(UserCode,TeamField, TeamIntroduce);
            return user.Count() == 0 ? false : true;
        }
        public bool CheckWorkInfo(string UserCode,  string Company)
        {
            IList<WorkInfo> user = new UserLoginDAO().FoundWorkInfo(UserCode,Company);
            return user.Count() == 0 ? false : true;
        }
        public bool SendMail(string to)
        {
            //1.check for email

            //2.if exists then do follows
            System.Net.Mail.SmtpClient client = new SmtpClient("smtp.163.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("mcclanelee@163.com", "lihuilr");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailAddress addressFrom = new MailAddress("mcclanelee@163.com", "查询");
            MailAddress addressTo = new MailAddress(to);

            System.Net.Mail.MailMessage message = new MailMessage(addressFrom, addressTo);
            message.Subject = "忘记密码";
            message.Body = "正文";
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
            //message.Attachments.Add(new Attachment(@"c:\1.txt"));
            message.Sender = new MailAddress("mcclanelee@163.com");
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = false;
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

    }
}