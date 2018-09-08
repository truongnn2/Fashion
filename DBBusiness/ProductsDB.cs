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
            return db.MyExecuteNonQuery("insert into Products (Title,TitleE,Content,ContentE,Category,CategoryDetail,CategoryDetailSub,DateCreate,Status,IsHot,Price,IsShowPrice,Location,Intro,IsShowDefault,PromotionPrice,IsNew,IsMostView) values(@Title,@TitleE,@Content,@ContentE,@Category,@CategoryDetail,@CategoryDetailSub,@DateCreate,@Status,@IsHot,@Price,@IsShowPrice,@Location,@Intro,@IsShowDefault,@PromotionPrice,@IsNew,@IsMostView)", CommandType.Text, ref err,
                new SqlParameter("@Title", td.Title),
                new SqlParameter("@TitleE", td.TitleE),
                new SqlParameter("@Content", td.Content),
                new SqlParameter("@ContentE", td.ContentE),
                new SqlParameter("@Category", td.Category),
                new SqlParameter("@CategoryDetail", td.CategoryDetail),
                new SqlParameter("@CategoryDetailSub", td.CategoryDetailSub),
                new SqlParameter("@DateCreate", td.DateCreate),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@IsHot", td.IsHot),
                new SqlParameter("@Price", td.Price),
                new SqlParameter("@IsShowPrice", td.IsShowPrice),
                new SqlParameter("@Location", td.Location),
                new SqlParameter("@Intro", td.Intro),
                new SqlParameter("@IsShowDefault", td.IsShowDefault),
                new SqlParameter("@PromotionPrice", td.PromotionPrice),
                new SqlParameter("@IsNew", td.IsNew),
                new SqlParameter("@IsMostView", td.IsMostView)
                );
        }
        public bool updatePhoto(ref string err, Products td)
        {
            return db.MyExecuteNonQuery("update Products set Photo=@Photo where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Photo", td.Photo)
                );
        }
        public bool updateFile(ref string err, Products td)
        {
            return db.MyExecuteNonQuery("update Products set FileAttach=@FileAttach where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@FileAttach", td.FileAttach)
                );
        }
        public bool update(ref string err, Products td)
        {
            return db.MyExecuteNonQuery("update Products set Title=@Title,TitleE=@TitleE,Content=@Content,ContentE=@ContentE,Category=@Category,CategoryDetail=@CategoryDetail,CategoryDetailSub=@CategoryDetailSub,Status=@Status,IsHot=@IsHot,IsShowPrice=@IsShowPrice,Price=@Price,Location=@Location,Intro=@Intro,IsShowDefault=@IsShowDefault,PromotionPrice=@PromotionPrice,IsNew=@IsNew,IsMostView=@IsMostView where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Title", td.Title),
                new SqlParameter("@TitleE", td.TitleE),
                new SqlParameter("@Content", td.Content),
                new SqlParameter("@ContentE", td.ContentE),
                new SqlParameter("@Category", td.Category),
                new SqlParameter("@CategoryDetail", td.CategoryDetail),
                new SqlParameter("@CategoryDetailSub", td.CategoryDetailSub),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@IsHot", td.IsHot),
                new SqlParameter("@Price", td.Price),
                new SqlParameter("@IsShowPrice", td.IsShowPrice),
                new SqlParameter("@Location", td.Location),
                new SqlParameter("@Intro", td.Intro),
                new SqlParameter("@IsShowDefault", td.IsShowDefault),
                new SqlParameter("@PromotionPrice", td.PromotionPrice),
                new SqlParameter("@IsNew", td.IsNew),
                new SqlParameter("@IsMostView", td.IsMostView)
                );
        }
        public bool updateStatus(ref string err, Products td)
        {
            return db.MyExecuteNonQuery("update Products set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }
        public bool updateViewCount(ref string err, string id, int count)
        {
            return db.MyExecuteNonQuery("update Products set ViewCount=@ViewCount where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", id),
                new SqlParameter("@ViewCount", count)
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
