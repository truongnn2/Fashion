using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;
namespace DBBusiness
{
    public class DownloadDB
    {
        DBLayer db;
        public DownloadDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, Download td)
        {
            return db.MyExecuteNonQuery("insert into Download (Name,Namefile,Status) values(@Name,@Namefile,@Status)", CommandType.Text, ref err,
                new SqlParameter("@Name", td.Name),
                new SqlParameter("@Namefile", td.Namefile),
                new SqlParameter("@Status", td.Status)
                );
        }

        public bool delete(ref string err, string namefile)
        {
            return db.MyExecuteNonQuery("Delete from Download where Namefile=@Namefile", CommandType.Text, ref err, new SqlParameter("@Namefile", namefile));
        }
        public bool updateStatus(ref string err, Download td)
        {
            return db.MyExecuteNonQuery("update Download set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
