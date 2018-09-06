using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;

namespace DBBusiness
{
    public class ProductsDB
    {
        DBLayer db;
        public ProductsDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, Products td)
        {
            return db.MyExecuteNonQuery("insert into Products (Title,TitleE,Content,ContentE,Category,CategoryDetail,DateCreate,Status,IsHot,Price,IsShowPrice,Location,Intro,IsShowDefault) values(@Title,@TitleE,@Content,@ContentE,@Category,@CategoryDetail,@DateCreate,@Status,@IsHot,@Price,@IsShowPrice,@Location,@Intro,@IsShowDefault)", CommandType.Text, ref err,
                new SqlParameter("@Title", td.Title),
                new SqlParameter("@TitleE", td.TitleE),
                new SqlParameter("@Content", td.Content),
                new SqlParameter("@ContentE", td.ContentE),
                new SqlParameter("@Category", td.Category),
                new SqlParameter("@CategoryDetail", td.CategoryDetail),
                new SqlParameter("@DateCreate", td.DateCreate),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@IsHot", td.IsHot),
                new SqlParameter("@Price", td.Price),
                new SqlParameter("@IsShowPrice", td.IsShowPrice),
                new SqlParameter("@Location", td.Location),
                new SqlParameter("@Intro", td.Intro),
                new SqlParameter("@IsShowDefault", td.IsShowDefault)
                );
        }
        public bool updatePhoto(ref string err, Products td)
        {
            return db.MyExecuteNonQuery("update Products set Photo=@Photo where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Photo", td.Photo)
                );
        }
        public bool update(ref string err, Products td)
        {
            return db.MyExecuteNonQuery("update Products set Title=@Title,TitleE=@TitleE,Content=@Content,ContentE=@ContentE,Category=@Category,CategoryDetail=@CategoryDetail,Status=@Status,IsHot=@IsHot,IsShowPrice=@IsShowPrice,Price=@Price,Location=@Location,Intro=@Intro,IsShowDefault=@IsShowDefault where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Title", td.Title),
                new SqlParameter("@TitleE", td.TitleE),
                new SqlParameter("@Content", td.Content),
                new SqlParameter("@ContentE", td.ContentE),
                new SqlParameter("@Category", td.Category),
                new SqlParameter("@CategoryDetail", td.CategoryDetail),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@IsHot", td.IsHot),
                new SqlParameter("@Price", td.Price),
                new SqlParameter("@IsShowPrice", td.IsShowPrice),
                new SqlParameter("@Location", td.Location),
                new SqlParameter("@Intro", td.Intro),
                new SqlParameter("@IsShowDefault", td.IsShowDefault)
                );
        }
        public bool updateStatus(ref string err, Products td)
        {
            return db.MyExecuteNonQuery("update Products set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }
        
        public bool delete(ref string err, string id)
        {
            return db.MyExecuteNonQuery("Delete from Products where ID=@id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
