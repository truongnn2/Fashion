using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;

namespace DBBusiness
{
    public class QADB
    {
        DBLayer db;
        public QADB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, QA td)
        {
            return db.MyExecuteNonQuery("insert into QA (Title,Question,DatePost,Status,Name,Address,Phone,Email) values(@Title,@Question,@DatePost,@Status,@Name,@Address,@Phone,@Email)", CommandType.Text, ref err,
                new SqlParameter("@Title", td.Title),
                new SqlParameter("@Question", td.Question),
                new SqlParameter("@DatePost", td.DatePost),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Name", td.Name),
                new SqlParameter("@Address", td.Address),
                new SqlParameter("@Phone", td.Phone),
                new SqlParameter("@Email", td.Email)
                );
        }

        public bool update(ref string err, QA td)
        {
            return db.MyExecuteNonQuery("update QA set Answer=@Answer,DateAnswer=@DateAnswer,Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Answer", td.Answer),
                new SqlParameter("@DateAnswer", td.DateAnswer),
                new SqlParameter("@Status", td.Status)
                );
        }
        public bool updateStatus(ref string err, QA td)
        {
            return db.MyExecuteNonQuery("update QA set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }

        public bool delete(ref string err, string id)
        {
            return db.MyExecuteNonQuery("Delete from QA where ID=@id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
