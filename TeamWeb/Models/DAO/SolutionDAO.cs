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
    public class SolutionDAO
    {
        public string ListType()
        {
            OracleConnection conn = new OracleConnection(@"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.70.228)(PORT=15211)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User ID=lyw;Password=njust8015");
            conn.Open();
            string sql = string.Format("select distinct projectsmallclass from projectinfo");
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
                    response += myds.Tables[0].Rows[i][0].ToString();
                }
                else
                {
                    response += myds.Tables[0].Rows[i][0].ToString()+",";
                }
            }
            return response;
        }
        public string ListCont(string small, string big)
        {
            OracleConnection conn = new OracleConnection(@"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.70.228)(PORT=15211)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User ID=lyw;Password=njust8015");
            conn.Open();
            string sql = string.Format("select projectname,projectimage,rrojecttitle from projectinfo where projectbigclass='{0}' and projectsmallclass='{1}' ", big, small);
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataAdapter myda = new OracleDataAdapter(cmd);
            DataSet myds = new DataSet();
            myda.Fill(myds);
            conn.Close();
            int count = Convert.ToInt32(myds.Tables[0].Rows.Count);
            string[] Message = new string[count];
            string response = "";
            for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                {
                    response += "{\"projectname\":\"" + myds.Tables[0].Rows[i][0].ToString() +
                                "\",\"projectimage\":\"" + myds.Tables[0].Rows[i][1].ToString() +
                                "\",\"projectpage\":\"" + myds.Tables[0].Rows[i][2].ToString() + "\"}";
                }
                else
                {
                    response += "{\"projectname\":\"" + myds.Tables[0].Rows[i][0].ToString() +
                                "\",\"projectimage\":\"" + myds.Tables[0].Rows[i][1].ToString() +
                                "\",\"projectpage\":\"" + myds.Tables[0].Rows[i][2].ToString() + "\"},";
                }
            }
            string responsetext = "[" + response + "]";
            return responsetext;
        }
        public string ListYear(string type)
        {
            string papertype = "";
            if (type == "china") { papertype = "中文文献"; }
            else if (type == "english") { papertype = "英文文献"; }
            else { papertype = "专利"; };
            OracleConnection conn = new OracleConnection(@"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.70.228)(PORT=15211)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User ID=lyw;Password=njust8015");
            conn.Open();
            string sql = string.Format("select distinct paperyear from paperinfo where papertype='{0}' order by paperyear desc", papertype);
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
                    response += "{\"year\":\"" + myds.Tables[0].Rows[i][0].ToString() + "\"}";
                }
                else
                {
                    response += "{\"year\":\"" + myds.Tables[0].Rows[i][0].ToString() + "\"},";
                }
            }
            string responsetext = "[" + response + "]";
            return responsetext;
        }
        public string listcontent(string year, string papertype, string type)
        {
            string papertype1 = "";
            if (papertype == "china") { papertype1 = "中文文献"; }
            else if (papertype == "english") { papertype1 = "英文文献"; }
            else { papertype1 = "专利"; };
            OracleConnection conn = new OracleConnection(@"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.70.228)(PORT=15211)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User ID=lyw;Password=njust8015");
            conn.Open();
            string sql = "";
            if (type == "simple")
            {
                sql = string.Format("select paperdescribe,paperaddress from paperinfo  where papertype='{0}'and paperyear='{1}'  order by uploadtime desc", papertype1, year);
            }
            else if (type == "multi")
            {
                string[] str=year.Split(',');
                string range="";
                for(int i=0;i<str.Count();i++){
                   if(i==str.Count()-1)
                   {
                    range+="\""+str[i]+"\"";
                   }
                   else
                   {
                       range+="\""+str[i]+"\",";
                   }
                }
                range="("+range+")";
                sql = string.Format("select paperdescribe,paperaddress from paperinfo where papertype='{0}'and paperyear in '{1}'  order by uploadtime desc", papertype1, range);
            }
            else{return null;};
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataAdapter myda = new OracleDataAdapter(cmd);
            DataSet myds = new DataSet();
            myda.Fill(myds);
            conn.Close();
            int count = Convert.ToInt32(myds.Tables[0].Rows.Count);
            string[] Message = new string[count];
            string response = "";
           for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                {
                    response += "{\"paperdescribe\":\"" + myds.Tables[0].Rows[i][0].ToString() +
                                "\",\"paperaddress\":\"" + myds.Tables[0].Rows[i][1].ToString() +"\"}";
                }
                else
                {
                    response += "{\"paperdescribe\":\"" + myds.Tables[0].Rows[i][0].ToString() +
                                "\",\"paperaddress\":\"" + myds.Tables[0].Rows[i][1].ToString() + "\"},";
                }
            }
            string responsetext = "[" + response + "]";
            return responsetext;
        }
    }
}