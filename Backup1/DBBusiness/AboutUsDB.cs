using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;

namespace DBBusiness
{
    public class AboutUsDB
    {
        DBLayer db;
        public AboutUsDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, AboutUs td)
        {
            return db.MyExecuteNonQuery("insert into AboutUs (Content,ContentE) values(@Content,@ContentE)", CommandType.Text, ref err,
                new SqlParameter("@Content", td.Content),
                new SqlParameter("@ContentE", td.ContentE)
                );
        }
        public bool updatePhoto(ref string err, AboutUs td)
        {
            return db.MyExecuteNonQuery("update AboutUs set Photo=@Photo where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Photo", td.Photo)
                );
        }
        public bool update(ref string err, AboutUs td)
        {
            return db.MyExecuteNonQuery("update AboutUs set Content=@Content,ContentE=@ContentE where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Content", td.Content),
                new SqlParameter("@ContentE", td.ContentE)
                );
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
