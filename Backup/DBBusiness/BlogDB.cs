using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;

namespace DBBusiness
{
    public class BlogDB
    {
        DBLayer db;
        public BlogDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, Blog td)
        {
            return db.MyExecuteNonQuery("insert into Blog (Title,Content,Status,DateCreate,Location,DisplayDefault,Category) values(@Title,@Content,@Status,@DateCreate,@Location,@DisplayDefault,@Category)", CommandType.Text, ref err,
                new SqlParameter("@Title", td.Title),
                new SqlParameter("@Content", td.Content),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@DateCreate", td.DateCreate),
                new SqlParameter("@Location", td.Location),
                new SqlParameter("@DisplayDefault", td.DisplayDefault),
                new SqlParameter("@Category", td.Category)
                );
        }
        public bool update(ref string err, Blog td)
        {
            return db.MyExecuteNonQuery("update Blog set Title=@Title,Content=@Content,Status=@Status,Location=@Location,DisplayDefault=@DisplayDefault where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Title", td.Title),
                new SqlParameter("@Content", td.Content),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Location", td.Location),
                new SqlParameter("@DisplayDefault", td.DisplayDefault)
                );
        }
        public bool updatePhoto(ref string err, Blog td)
        {
            return db.MyExecuteNonQuery("update Blog set Photo=@Photo where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Photo", td.Photo)
                );
        }

        public bool updateStatus(ref string err, Blog td)
        {
            return db.MyExecuteNonQuery("update Blog set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }
        public bool updateChangeDefault(ref string err, Blog td)
        {
            return db.MyExecuteNonQuery("update Blog set DisplayDefault=@DisplayDefault where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@DisplayDefault", td.DisplayDefault)
                );
        }
        public bool delete(ref string err, string id)
        {
            return db.MyExecuteNonQuery("Delete from Blog where ID=@id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
