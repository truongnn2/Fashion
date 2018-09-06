using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;

namespace DBBusiness
{
    public class GiamgiaDB
    {
        DBLayer db;
        public GiamgiaDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, Giamgia td)
        {
            return db.MyExecuteNonQuery("insert into Giamgia (Content) values(@Content)", CommandType.Text, ref err,
                new SqlParameter("@Content", td.Content)
                );
        }
        public bool updatePhoto(ref string err, Giamgia td)
        {
            return db.MyExecuteNonQuery("update Giamgia set Photo=@Photo where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Photo", td.Photo)
                );
        }
        public bool update(ref string err, Giamgia td)
        {
            return db.MyExecuteNonQuery("update Giamgia set Content=@Content where ID=@id", CommandType.Text, ref err, 
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Content", td.Content)
                );
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
