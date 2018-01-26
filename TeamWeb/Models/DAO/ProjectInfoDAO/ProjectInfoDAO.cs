using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamWeb.Models.DAO.ProjectInfoDAO;
using TeamWeb.Models.Domain.ProjectInfoDomain;
using TeamWeb.Util;
using NHibernate;
using NHibernate.Bytecode;
using NHibernate.Cfg;

namespace TeamWeb.Models.DAO.ProjectInfoDAO
{
    public class ProjectInfoDAO
    {
        private ISession session;

        public bool SaveProjectInfo(ProjectInfo projectInfo)
        {
            session = NhibernateUtils.getSession();
            ITransaction tsc = session.BeginTransaction();
            try
            {
                session.Save(projectInfo);
                tsc.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            { session.Close(); }
            return true;
        }
    }
}