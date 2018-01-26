using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Bytecode;

namespace TeamWeb.Util
{
    public class NhibernateUtils
    {
        private static readonly  ISessionFactory sessionFactory;
        private static string HibernateHbmXmlFileName = System.AppDomain.CurrentDomain.BaseDirectory + @"hibernate.cfg.xml";      
        //private static ISession session

        static NhibernateUtils()
        {
            try
            {
                sessionFactory = new Configuration().Configure(HibernateHbmXmlFileName).BuildSessionFactory();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public static ISessionFactory getSessionFactory()
        {
            return sessionFactory;
        }

        //public static ISessionFactory getSessionFactory()
        //{
        //    if (sessionFactory == null)
        //    {
        //        Configuration cfg = new Configuration();
        //        cfg.Configure(HibernateHbmXmlFileName);
        //        sessionFactory = cfg.BuildSessionFactory();
        //    }
        //    return sessionFactory;
        //}

       

        public static ISession getSession()
        {
            return sessionFactory.OpenSession();
        }

        public static void closeSessionFactory()
        {
            
        }
    }
}