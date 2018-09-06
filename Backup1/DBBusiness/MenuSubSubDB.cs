using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;

namespace DBBusiness
{
    public class MenuSubSubDB
    {
        DBLayer db;
        public MenuSubSubDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, MenuSubSub td)
        {
            return db.MyExecuteNonQuery("insert into MenuSubSub (Name,NameE,IDMenu,IDMenuSub,Status,Location) values(@Name,@NameE,@IDMenu,@IDMenuSub,@Status,@Location)", CommandType.Text, ref err,
                new SqlParameter("@Name", td.Name),
                new SqlParameter("@NameE", td.NameE),
                new SqlParameter("@IDMenu", td.IDMenu),
                new SqlParameter("@IDMenuSub", td.IDMenuSub),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Location", td.Location)
                );
        }

        public bool update(ref string err, MenuSubSub td)
        {
            return db.MyExecuteNonQuery("update MenuSubSub set Name=@Name,NameE=@NameE,Status=@Status,IDMenu=@IDMenu,IDMenuSub=@IDMenuSub,Location=@Location where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Name", td.Name),
                new SqlParameter("@NameE", td.NameE),
                new SqlParameter("@IDMenu", td.IDMenu),
                 new SqlParameter("@IDMenuSub", td.IDMenuSub),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Location", td.Location)
                );
        }
        public bool updateStatus(ref string err, MenuSubSub td)
        {
            return db.MyExecuteNonQuery("update MenuSubSub set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }

        public bool delete(ref string err, string id)
        {
            return db.MyExecuteNonQuery("Delete from MenuSubSub where ID=@id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
