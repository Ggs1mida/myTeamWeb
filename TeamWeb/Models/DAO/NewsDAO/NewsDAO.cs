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

namespace TeamWeb.Models.DAO.PaperDAO
{
    public class NewsDAO
    {
        public string List()
        {
            OracleConnection conn = new OracleConnection(@"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.70.228)(PORT=15211)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User ID=lyw;Password=njust8015");
            conn.Open();
            string sql = string.Format("select to_char(time,'YYYY-MM-DD'),name,title from newsinfo order by time desc");
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataAdapter myda = new OracleDataAdapter(cmd);
            DataSet myds = new DataSet();
            myda.Fill(myds);
            conn.Close();
            int count = Convert.ToInt32(myds.Tables[0].Rows.Count);
            string response = "";        
                for (int j = 0; j < myds.Tables[0].Rows.Count-1; j++)
                {
                    if (j == myds.Tables[0].Rows.Count-1)
                    {
                        response += "{\"time\":\"" + myds.Tables[0].Rows[j][0].ToString() +
                                "\",\"name\":\"" + myds.Tables[0].Rows[j][1].ToString() +
                                "\",\"title\":\"" + myds.Tables[0].Rows[j][2].ToString() + "\"}";
                    }
                    else
                    {
                        response += "{\"time\":\"" + myds.Tables[0].Rows[j][0].ToString() +
                                "\",\"name\":\"" + myds.Tables[0].Rows[j][1].ToString() +
                                "\",\"title\":\"" + myds.Tables[0].Rows[j][2].ToString() + "\"},";
                    }            
                }
            
           
            string responsetext = "[" + response + "]";
            return responsetext;
        }
    }
}