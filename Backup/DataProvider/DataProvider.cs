using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
namespace DataProvider
{
    public class DBLayer
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataAdapter adp;
        SqlDataReader objSqlDataReader;
        string strConnect = System.Configuration.ConfigurationManager.AppSettings["Connectstring"];

        public DBLayer()
        {
            cnn = new SqlConnection(strConnect);

            //cnn.Open();
        }

        public DataSet ExecuteQueryDataSet(string strSQL, CommandType ct, params SqlParameter[] p)
        {
            cmd = cnn.CreateCommand();
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            cmd.CommandText = strSQL;
            cmd.CommandType = ct;
            adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            cnn.Close();
            return ds;
        }

        public string ExecuteQueryXML(string strSQL, CommandType ct, params SqlParameter[] param)
        {
            cmd = cnn.CreateCommand();
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            cmd.CommandText = strSQL;
            cmd.CommandType = ct;
            foreach (SqlParameter p in param)
                cmd.Parameters.Add(p);
            adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            cnn.Close();
            return ds.GetXml();
        }

        public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error, params SqlParameter[] param)
        {
            cmd = cnn.CreateCommand();
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            bool f = false;
            cmd.Parameters.Clear();
            cmd.CommandText = strSQL;
            cmd.CommandType = ct;
            foreach (SqlParameter p in param)
                cmd.Parameters.Add(p);
            try
            {
                cmd.ExecuteNonQuery();
                f = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                cnn.Close();
            }
            return f;
        }
        public IList getList(string sSqlString)
        {
            cnn.Open();
            // cmd.Parameters.Clear()
            ArrayList list = null;
            try
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
                else if (cnn.State == ConnectionState.Open)
                {
                    this.cmd = new SqlCommand(sSqlString, cnn);
                    this.objSqlDataReader = this.cmd.ExecuteReader();
                    int iFieldCount = this.objSqlDataReader.FieldCount;
                    list = new ArrayList();
                    while (this.objSqlDataReader.Read())
                    {
                        object[] object_ = new object[iFieldCount];
                        for (int k = 0; k < iFieldCount; k++)
                        {
                            object_[k] = this.objSqlDataReader.IsDBNull(k) == true ? "" : this.objSqlDataReader.GetValue(k);
                        }
                        list.Add(object_);
                    }
                }
            }
            catch //(Exception ex)
            {
                //throw new Exception( ex.Message );
                this.cnn.Close();
            }
            finally
            {
                cnn.Close();
            }
            return list;
        }
        public object MyExecuteScalar(string strSQL, CommandType ct, params SqlParameter[] p)
        {
            cmd = cnn.CreateCommand();
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            cmd.CommandText = strSQL;
            cmd.CommandType = ct;
            foreach (SqlParameter param in p)
                cmd.Parameters.Add(param);
            object obj = cmd.ExecuteScalar();
            cnn.Close();
            return obj;
        }

    }
}
