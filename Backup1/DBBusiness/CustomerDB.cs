using System;
using System.Data;
using System.Data.SqlClient;
using DataProvider;
using System.Collections;

namespace DBBusiness
{
    public class CustomerDB
    {
        DBLayer db;
        public CustomerDB()
        {
            db = new DBLayer();
        }
        public bool insert(ref string err, Customer td)
        {
            return db.MyExecuteNonQuery("insert into Customer (Name, Phone, Email, Address, Status, Type, Location) values(@Name, @Phone, @Email, @Address, @Status, @Type, @Location)", CommandType.Text, ref err,
                new SqlParameter("@Name", td.Name),
                new SqlParameter("@Phone", td.Phone),
                new SqlParameter("@Email", td.Email),
                new SqlParameter("@Address", td.Address),
                new SqlParameter("@Type", td.Type),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Location", td.Location)
                );
        }

        public bool update(ref string err, Customer td)
        {
            return db.MyExecuteNonQuery("update Customer set Name=@Name,Phone=@Phone,Email=@Email,Address=@Address,Type=@Type,Status=@Status,Location=@Location where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                 new SqlParameter("@Name", td.Name),
                new SqlParameter("@Phone", td.Phone),
                new SqlParameter("@Email", td.Email),
                new SqlParameter("@Address", td.Address),
                new SqlParameter("@Type", td.Type),
                new SqlParameter("@Status", td.Status),
                new SqlParameter("@Location", td.Location)
                );
        }
        public bool updateStatus(ref string err, Customer td)
        {
            return db.MyExecuteNonQuery("update Customer set Status=@Status where ID=@id", CommandType.Text, ref err,
                new SqlParameter("@id", td.ID),
                new SqlParameter("@Status", td.Status)
                );
        }

        public bool delete(ref string err, string id)
        {
            return db.MyExecuteNonQuery("Delete from Customer where ID=@id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public IList getList(string sql)
        {
            return db.getList(sql);
        }
    }
}
