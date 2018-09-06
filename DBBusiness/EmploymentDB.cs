using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;

namespace DBBusiness
{
    public class EmploymentDB
    {
        DBLayer db;
        public EmploymentDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, Employment td)
        {
            return db.MyExecuteNonQuery("insert into Employment (Content) values(@Content)", CommandType.Text, ref err,
                new SqlParameter("@Content", td.Content)
                );
        }
       
        public bool update(ref string err, Employment td)
        {
            return db.MyExecuteNonQuery("Update Employment set Content=@Content where ID=@id", CommandType.Text, ref err, 
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
