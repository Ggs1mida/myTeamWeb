using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    public class ReaserchDAO
    {
        public string ListReaserch()
        {
            OracleConnection conn = new OracleConnection(@"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.70.228)(PORT=15211)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User ID=lyw;Password=njust8015");
            conn.Open();
            string sql = string.Format("select teamfield,image,teamintroduce from teaminfo");
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
                    response += "{\"teamfield\":\"" + myds.Tables[0].Rows[i][0].ToString() + 
                                "\",\"image\":\"" + myds.Tables[0].Rows[i][1].ToString() + 
                                "\",\"teamintroduce\":\"" + myds.Tables[0].Rows[i][2].ToString()+ "\"}";
                }
                else
                {
                    response += "{\"teamfield\":\"" + myds.Tables[0].Rows[i][0].ToString() +
                                "\",\"image\":\"" + myds.Tables[0].Rows[i][1].ToString() +
                                "\",\"teamintroduce\":\"" + myds.Tables[0].Rows[i][2].ToString() + "\"},";
                }
            }         
            string responsetext = "[" + response + "]";
            return responsetext;
        }
    }
}