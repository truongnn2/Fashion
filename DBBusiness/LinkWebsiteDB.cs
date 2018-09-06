using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;
namespace DBBusiness
{
    public class LinkWebsiteDB
    {
        DBLayer db;
        public LinkWebsiteDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, LinkWebsite td)
        {
            return db.MyExecuteNonQuery("insert into LinkWebsite (Website,Url,Status) values(@Website,@Url,@Status)", CommandType.Text, ref err,
                new SqlParameter("@Website", td.Website),
                new SqlParameter("@Url", td.Url),
                new SqlParameter("@Status", td.Status)
                );
        }

        public bool updateStatus(ref string err, LinkWebsite td)
        {
            return db.MyExecuteNonQuery("update LinkWebsite set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }
        public bool delete(ref string err, string id)
        {
            return db.MyExecuteNonQuery("Delete from LinkWebsite where ID=@id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
