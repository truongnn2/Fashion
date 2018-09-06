using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;
namespace DBBusiness
{
    public class BoxAdDB
    {
        DBLayer db;
        public BoxAdDB()
        {
            db = new DBLayer();
        }

        public bool insert(ref string err, BoxAd td)
        {
            return db.MyExecuteNonQuery("insert into BoxAd (Url,Status,Category,Location) values(@Url,@Status,@Category,@Location)", CommandType.Text, ref err,
                new SqlParameter("@Url", td.Url),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Category", td.Category),
                new SqlParameter("@Location", td.Location)
                );
        }
        public bool update(ref string err, BoxAd td)
        {
            return db.MyExecuteNonQuery("update BoxAd set Status=@Status,Url=@Url,Category=@Category,Location=@Location where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Url", td.Url),
                new SqlParameter("@Category", td.Category),
                new SqlParameter("@Location", td.Location)
                );
        }
        public bool updateStatus(ref string err, BoxAd td)
        {
            return db.MyExecuteNonQuery("update BoxAd set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }
        public bool updatePhoto(ref string err, BoxAd td)
        {
            return db.MyExecuteNonQuery("update BoxAd set Photo=@Photo where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Photo", td.Photo)
                );
        }
        public bool delete(ref string err, string id)
        {
            return db.MyExecuteNonQuery("Delete from BoxAd where ID=@id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }

    }
}
