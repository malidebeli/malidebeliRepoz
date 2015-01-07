using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;


namespace WebLibrary
{
    public class DBObjects
    {
        public class DataObjects
        {
        }

        public class DB
        {

            #region Fields
            static string _strCnStr = ConfigurationManager.AppSettings["dbconn"];
            #endregion

            #region Ctor



            #endregion

            /*
  * 			rowsOnPage=Int32.Parse(cmd.Parameters["@rows"].Value.ToString());	////ukupan broj zapisa
			pageNum=Int32.Parse(cmd.Parameters["@pageCount"].Value.ToString());	//ukupan broj stranica
  */

            public static DataTable GetPagedData(SqlCommand prmCmd, ref int rowsOnPage, ref int pageNum)
            {
                using (SqlConnection cn = new SqlConnection(_strCnStr))
                {
                    cn.Open();
                    DataSet ds = new DataSet();
                    prmCmd.Connection = cn;

                    prmCmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(prmCmd);

                    da.Fill(ds);

                    rowsOnPage = Int32.Parse(prmCmd.Parameters["@rows"].Value.ToString());	////ukupan broj zapisa
                    pageNum = Int32.Parse(prmCmd.Parameters["@pageCount"].Value.ToString());	//ukupan broj stranica

                    if (ds.Tables.Count == 0)
                    {
                        return null;
                    }

                    return ds.Tables[0];
                }
            }

            public static DataTable GetData(SqlCommand prmCmd)
            {
                using (SqlConnection cn = new SqlConnection(_strCnStr))
                {
                    cn.Open();
                    DataSet ds = new DataSet();
                    prmCmd.Connection = cn;

                    prmCmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(prmCmd);

                    da.Fill(ds);

                    if (ds.Tables.Count == 0)
                    {
                        return null;
                    }

                    return ds.Tables[0];
                }
            }

            //preko string selecta
            public static DataTable GetData1(SqlCommand prmCmd)
            {
                using (SqlConnection cn = new SqlConnection(_strCnStr))
                {
                    cn.Open();
                    DataSet ds = new DataSet();
                    prmCmd.Connection = cn;

                    prmCmd.CommandType = CommandType.Text;
                    DataTable dt = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(prmCmd);

                    da.Fill(ds);

                    if (ds.Tables.Count == 0)
                    {
                        return null;
                    }

                    return ds.Tables[0];
                }
            }

            public static DataSet GetDataSet(SqlCommand prmCmd)
            {
                using (SqlConnection cn = new SqlConnection(_strCnStr))
                {
                    cn.Open();
                    DataSet ds = new DataSet();
                    prmCmd.Connection = cn;

                    prmCmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(prmCmd);

                    da.Fill(ds);


                    return ds;
                }
            }

            public static int ExecCommand(SqlCommand prmCmd)
            {

                using (SqlConnection cn = new SqlConnection(_strCnStr))
                {
                    cn.Open();
                    int retVal = 0;

                    prmCmd.Connection = cn;
                    prmCmd.CommandType = CommandType.StoredProcedure;

                    prmCmd.ExecuteNonQuery();

                    retVal = int.Parse(prmCmd.Parameters["@retval"].Value.ToString());

                    return retVal;
                }

            }

            public static object ExecScalar(SqlCommand prmCmd)
            {

                using (SqlConnection cn = new SqlConnection(_strCnStr))
                {
                    cn.Open();

                    prmCmd.Connection = cn;
                    prmCmd.CommandType = CommandType.StoredProcedure;

                    return prmCmd.ExecuteScalar();

                }
            }
        }

    }
}
