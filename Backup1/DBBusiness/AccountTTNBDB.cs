using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;
namespace DBBusiness
{
    public class AccountTTNBDB
    {
        DBLayer db;
        public AccountTTNBDB()
        {
            db = new DBLayer();
        }


        public bool update(ref string err, AccountTTNB td)
        {
            return db.MyExecuteNonQuery("update AccountTTNB set Password=@Password where ID=@ID", CommandType.Text, ref err,
                new SqlParameter("@ID", td.ID),
                new SqlParameter("@Password", td.Password)
                );
        }
       
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
