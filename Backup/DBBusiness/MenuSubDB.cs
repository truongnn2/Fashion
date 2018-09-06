using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;

namespace DBBusiness
{
    public class MenuSubDB
    {
        DBLayer db;
        public MenuSubDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, MenuSub td)
        {
            return db.MyExecuteNonQuery("insert into MenuSub (Name,NameE,IDMenu,Status,Location) values(@Name,@NameE,@IDMenu,@Status,@Location)", CommandType.Text, ref err,
                new SqlParameter("@Name", td.Name),
                new SqlParameter("@NameE", td.NameE),
                new SqlParameter("@IDMenu", td.IDMenu),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Location", td.Location)
                );
        }

        public bool update(ref string err, MenuSub td)
        {
            return db.MyExecuteNonQuery("update MenuSub set Name=@Name,NameE=@NameE,Status=@Status,IDMenu=@IDMenu,Location=@Location where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Name", td.Name),
                new SqlParameter("@NameE", td.NameE),
                new SqlParameter("@IDMenu", td.IDMenu),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Location", td.Location)
                );
        }
        public bool updateStatus(ref string err, MenuSub td)
        {
            return db.MyExecuteNonQuery("update MenuSub set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }

        public bool delete(ref string err, string id)
        {
            return db.MyExecuteNonQuery("Delete from MenuSub where ID=@id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
