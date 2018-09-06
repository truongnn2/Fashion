using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;

namespace DBBusiness
{
    public class GioiThieuDB
    {
        DBLayer db;
        public GioiThieuDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, GioiThieu td)
        {
            return db.MyExecuteNonQuery("insert into GioiThieu (Title, Content, Status, Location) values(@Title, @Content, @Status, @Location)", CommandType.Text, ref err,
                new SqlParameter("@Title", td.Title),
                new SqlParameter("@Content", td.Content),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Location", td.Location)
                );
        }

        public bool update(ref string err, GioiThieu td)
        {
            return db.MyExecuteNonQuery("update GioiThieu set Title=@Title,Content=@Content,Status=@Status,Location=@Location where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Title", td.Title),
                new SqlParameter("@Content", td.Content),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Location", td.Location)
                );
        }
        public bool updateStatus(ref string err, GioiThieu td)
        {
            return db.MyExecuteNonQuery("update GioiThieu set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }

        public bool delete(ref string err, string id)
        {
            return db.MyExecuteNonQuery("Delete from GioiThieu where ID=@id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
