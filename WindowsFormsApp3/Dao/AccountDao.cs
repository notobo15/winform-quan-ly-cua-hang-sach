using QuanLyCuaHangSach.Configs;
using QuanLyCuaHangSach.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Dao
{
    public class AccountDao
    {
        ConnectDb db = new ConnectDb();
        public string TableName { get; set; } = "accounts";
        public AccountDao() { }
       

        public List<Account> getAll()
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where IsDeleted = 0;");
            List<Account> list = new List<Account>();
            foreach (DataRow row in dt.Rows)
            {
                Account tmp = new Account()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name =  row["Name"]?.ToString(),
                    UserName = row["UserName"]?.ToString(),
                    Password = row["Password"]?.ToString(),
                    Gender = row["Gender"]?.ToString(),
                    Phone = row["Phone"]?.ToString(),
                    RoleId = Convert.ToInt32(row["RoleId"]),
                    BirthDay = (DateTime)row["BirthDay"],
                    IsDeleted = (bool)row["IsDeleted"],
                    CreatedAt = (DateTime)row["CreatedAt"],
                    UpdatedAt = (DateTime)row["UpdatedAt"],
                };

                list.Add(tmp);
            }
            return list;
        }

        public Account getFirstById(string id)
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where id = '{id}'");

            Account tmp = null;
            foreach (DataRow row in dt.Rows)
            {
                tmp = new Account
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"]?.ToString(),
                    UserName = row["UserName"]?.ToString(),
                    Password = row["Password"]?.ToString(),
                    Gender = row["Gender"]?.ToString(),
                    Phone = row["Phone"]?.ToString(),
                    RoleId = Convert.ToInt32(row["RoleId"]),
                    BirthDay = (DateTime)row["BirthDay"],
                    IsDeleted = (bool)row["IsDeleted"],
                    CreatedAt = (DateTime)row["CreatedAt"],
                    UpdatedAt = (DateTime)row["UpdatedAt"],
                };
            }
            return tmp;
        }
        public bool UpdateById(Account account)
        {
            string query = $"Update {TableName} set Name = '{account.Name}',Phone = '{account.Phone}',BirthDay = '{account.BirthDay.ToString("yyyy-MM-dd")}' where id = {account.Id}";
            return ConnectDb.ExecuteNonQuery(query);
        }

        public bool DeleteById(string id)
        {
            string strQuery = $"UPDATE {TableName} set IsDeleted = 1 where Id='{id}'";

            return ConnectDb.ExecuteNonQuery(strQuery);
        }

        public bool Add(Account account)
        {
            string query = $"Insert into {TableName}(Name, Gender, Phone,BirthDay, IsDeleted, CreatedAt, UpdatedAt) " +
                            $"VALUES ('{account.Name}', " +
                            $"'{account.Gender}', " +
                            $"'{account.Phone}', " +
                            $"'{account.BirthDay.ToString("yyyy-MM-dd")}', " +
                            $"'{account.IsDeleted}', " +
                            $"'{account.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'{account.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")}')";
            return ConnectDb.ExecuteNonQuery(query); ;
        }

        public Account Login(string username, string password)
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where username = '{username}' and password = '{password}'");

            Account tmp = null;
            foreach (DataRow row in dt.Rows)
            {
                tmp = new Account
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"]?.ToString(),
                    UserName = row["UserName"]?.ToString(),
                    Password = row["Password"]?.ToString(),
                    Gender = row["Gender"]?.ToString(),
                    Phone = row["Phone"]?.ToString(),
                    RoleId = Convert.ToInt32(row["RoleId"]),
                    BirthDay = (DateTime)row["BirthDay"],
                    IsDeleted = (bool)row["IsDeleted"],
                    CreatedAt = (DateTime)row["CreatedAt"],
                    UpdatedAt = (DateTime)row["UpdatedAt"],
                };
            }
           return tmp;
        }
    }
}
