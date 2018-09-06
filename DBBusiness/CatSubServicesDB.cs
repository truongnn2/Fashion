using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;

namespace DBBusiness
{
    public class CatSubServicesDB
    {
        DBLayer db;
        public CatSubServicesDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, CatSubServices td)
        {
            return db.MyExecuteNonQuery("insert into CatSubServices (Name,NameE,IDCatServices,Status,Location) values(@Name,@NameE,@IDCatServices,@Status,@Location)", CommandType.Text, ref err,
                new SqlParameter("@Name", td.Name),
                new SqlParameter("@NameE", td.NameE),
                new SqlParameter("@IDCatServices", td.IDCatServices),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Location", td.Location)
                );
        }

        public bool update(ref string err, CatSubServices td)
        {
            return db.MyExecuteNonQuery("update CatSubServices set Name=@Name,NameE=@NameE,Status=@Status,IDCatServices=@IDCatServices,Location=@Location where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Name", td.Name),
                new SqlParameter("@NameE", td.NameE),
                new SqlParameter("@IDCatServices", td.IDCatServices),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Location", td.Location)
                );
        }
        public bool updateStatus(ref string err, CatSubServices td)
        {
            return db.MyExecuteNonQuery("update CatSubServices set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }

        public bool delete(ref string err, string id)
        {
            return db.MyExecuteNonQuery("Delete from CatSubServices where ID=@id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
