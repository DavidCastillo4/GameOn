using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace slnGameOn.db
{
	public class GetData
	{
		public static string ConStr()
		{
			return System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cnSql"].ConnectionString;
		}
		public static DataSet ReturnDataSet(String Qry)
		{
			string Con = ConStr();
			SqlConnection SqlCon = new SqlConnection(Con);
			SqlCommand SqlCmd = new SqlCommand(Qry, SqlCon);
			SqlDataAdapter SqlDA = new SqlDataAdapter(SqlCmd);
			DataSet DS = new DataSet();
			try
			{
				SqlCon.Open();
				SqlDA.Fill(DS);
			}
			finally
			{
				SqlCon.Close();
			}
			return DS;
		}


	}
}