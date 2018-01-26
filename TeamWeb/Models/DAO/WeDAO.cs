using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamWeb.Models.DAO.PaperDAO;
using TeamWeb.Models.Domain.PaperInfoDomain;
using TeamWeb.Util;
using NHibernate;
using NHibernate.Bytecode;
using NHibernate.Cfg;
using System.Data.OracleClient;
using System.Data;

namespace TeamWeb.Models.DAO
{
    public class WeDAO
    {
        public string ListTeacher()
        {
            OracleConnection conn = new OracleConnection(@"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.70.228)(PORT=15211)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User ID=lyw;Password=njust8015");
            conn.Open();
            string sql = string.Format("select title,direction,introduce,photo,name,credit from teacherinfo");
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataAdapter myda = new OracleDataAdapter(cmd);
            DataSet myds = new DataSet();
            myda.Fill(myds);
            conn.Close();
            int count = Convert.ToInt32(myds.Tables[0].Rows.Count);
            string response = "";
            for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                {
                    response += "{\"title\":\"" + myds.Tables[0].Rows[i][0].ToString() +
                                "\",\"direction\":\"" + myds.Tables[0].Rows[i][1].ToString() +
                                "\",\"introduce\":\"" + myds.Tables[0].Rows[i][2].ToString() +
                                "\",\"photo\":\"" + myds.Tables[0].Rows[i][3].ToString() +
                                "\",\"name\":\"" + myds.Tables[0].Rows[i][4].ToString() +
                                "\",\"credit\":\"" + myds.Tables[0].Rows[i][5].ToString() + "\"}";
                }
                else
                {
                    response += "{\"title\":\"" + myds.Tables[0].Rows[i][0].ToString() +
                                "\",\"direction\":\"" + myds.Tables[0].Rows[i][1].ToString() +
                                "\",\"introduce\":\"" + myds.Tables[0].Rows[i][2].ToString() +
                                "\",\"photo\":\"" + myds.Tables[0].Rows[i][3].ToString() +
                                "\",\"name\":\"" + myds.Tables[0].Rows[i][4].ToString() +
                                "\",\"credit\":\"" + myds.Tables[0].Rows[i][5].ToString() + "\"},";
                }
            }
            string responsetext = "[" + response + "]";
            return responsetext;
        }
        public string ListStudent(string graduate)
        {
            OracleConnection conn = new OracleConnection(@"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.70.228)(PORT=15211)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User ID=lyw;Password=njust8015");
            conn.Open();
            string sql = string.Format("select introduce,major,photo,name,degree from studentinfo  where graduate='{0}' ", graduate);
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataAdapter myda = new OracleDataAdapter(cmd);
            DataSet myds = new DataSet();
            myda.Fill(myds);
            conn.Close();
            int count = Convert.ToInt32(myds.Tables[0].Rows.Count);
            string response = "";
            for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                {
                    response += "{\"introduce\":\"" + myds.Tables[0].Rows[i][0].ToString() +
                                "\",\"major\":\"" + myds.Tables[0].Rows[i][1].ToString() +
                                "\",\"photo\":\"" + myds.Tables[0].Rows[i][2].ToString() +
                                "\",\"name\":\"" + myds.Tables[0].Rows[i][3].ToString() +
                                "\",\"degree\":\"" + myds.Tables[0].Rows[i][4].ToString() + "\"}";
                }
                else
                {
                    response += "{\"introduce\":\"" + myds.Tables[0].Rows[i][0].ToString() +
                                "\",\"major\":\"" + myds.Tables[0].Rows[i][1].ToString() +
                                "\",\"photo\":\"" + myds.Tables[0].Rows[i][2].ToString() +
                                "\",\"name\":\"" + myds.Tables[0].Rows[i][3].ToString() +
                                "\",\"degree\":\"" + myds.Tables[0].Rows[i][4].ToString() + "\"},";
                }
            }
            string responsetext = "[" + response + "]";
            return responsetext;
        }
    }
}