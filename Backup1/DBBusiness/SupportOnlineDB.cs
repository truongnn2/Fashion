using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;

namespace DBBusiness
{
    public class SupportOnlineDB
    {
        DBLayer db;
        public SupportOnlineDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, SupportOnline td)
        {
            return db.MyExecuteNonQuery("insert into SupportOnline (Name,NickName,NickSkype,Status,Phone) values(@Name,@NickName,@NickSkype,@Status,@Phone)", CommandType.Text, ref err,
                new SqlParameter("@Name", td.Name),
                new SqlParameter("@NickName", td.NickName),
                new SqlParameter("@NickSkype", td.NickSkype),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Phone", td.Phone)
                );
        }

        public bool update(ref string err, SupportOnline td)
        {
            return db.MyExecuteNonQuery("update SupportOnline set Name=@Name,NickName=@NickName,NickSkype=@NickSkype,Status=@Status,Phone=@Phone where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Name", td.Name),
                new SqlParameter("@NickName", td.NickName),
                new SqlParameter("@NickSkype", td.NickSkype),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Phone", td.Phone)
                );
        }
        public bool updateStatus(ref string err, SupportOnline td)
        {
            return db.MyExecuteNonQuery("update SupportOnline set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }

        public bool delete(ref string err, string id)
        {
            return db.MyExecuteNonQuery("Delete from SupportOnline where ID=@id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
