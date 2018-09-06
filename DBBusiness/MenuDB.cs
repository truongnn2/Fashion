using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;

namespace DBBusiness
{
    public class MenuDB
    {
        DBLayer db;
        public MenuDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, Menu td)
        {
            return db.MyExecuteNonQuery("insert into Menu (Name,NameE,Status,Location) values(@Name,@NameE,@Status,@Location)", CommandType.Text, ref err,
                new SqlParameter("@Name", td.Name),
                new SqlParameter("@NameE", td.NameE),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Location", td.Location)
                );
        }

        public bool update(ref string err, Menu td)
        {
            return db.MyExecuteNonQuery("update Menu set Name=@Name,NameE=@NameE,Status=@Status,Location=@Location where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Name", td.Name),
                new SqlParameter("@NameE", td.NameE),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Location", td.Location)
                );
        }
        public bool updateStatus(ref string err, Menu td)
        {
            return db.MyExecuteNonQuery("update Menu set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }

        public bool delete(ref string err, string id)
        {
            return db.MyExecuteNonQuery("Delete from Menu where ID=@id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
