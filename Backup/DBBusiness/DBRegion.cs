using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;
namespace DBBusiness
{
    public class DBRegion
    {
        DBLayer db;
        public DBRegion()
        {
            db = new DBLayer();
        }
        public DataSet getRegion()
        {
            return db.ExecuteQueryDataSet("select * from Region", CommandType.Text, null);
        }
        public bool insertRegion(ref string err, string id, string desc)
        {
            return db.MyExecuteNonQuery("spInsertRegion", CommandType.StoredProcedure, ref err, new SqlParameter("@id", id), new SqlParameter("@desc", desc));
        }
        public bool deleteRegion(ref string err, string id)
        {
            return db.MyExecuteNonQuery("spDeleteRegion", CommandType.StoredProcedure, ref err, new SqlParameter("@id", id));
        }
        public bool updateRegion(ref string err, string id, string desc)
        {
            return db.MyExecuteNonQuery("spUpdateRegion", CommandType.StoredProcedure, ref err, new SqlParameter("@id", id), new SqlParameter("@desc", desc));
        }
        public bool insertRegion1(ref string err, string id, string desc)
        {
            return db.MyExecuteNonQuery("insert into Region values(@id,@desc)", CommandType.Text, ref err, new SqlParameter("@id", id), new SqlParameter("@desc", desc));
        }
        public bool deleteRegion1(ref string err, string id)
        {
            return db.MyExecuteNonQuery("Delete from Region where RegionID=@id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public bool updateRegion1(ref string err, string id, string desc)
        {
            return db.MyExecuteNonQuery("update Region set RegionDescription=@desc where RegionID=@id", CommandType.Text, ref err, new SqlParameter("@id", id), new SqlParameter("@desc", desc));
        }
        public IList getRegion(string sql)
        {
            return db.getList(sql);
        }
        
    }
}
