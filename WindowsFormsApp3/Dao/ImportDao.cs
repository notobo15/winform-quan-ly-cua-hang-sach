using QuanLyCuaHangSach.Configs;
using QuanLyCuaHangSach.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Dao
{
    public class ImportDao : ICrudDao<Role>
    {
        public string TableName { get; set; } = "role";
        public ImportDao() { }
        public List<Role> getAll()
        {

            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where IsDeleted = 0;");

            var list = new List<Role>();

            foreach (DataRow row in dt.Rows)
            {
                var tmp = new Role
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = (string)row["Name"],
                    IsDeleted = (bool)row["IsDeleted"],
                    CreatedAt = (DateTime)row["CreatedAt"],
                    UpdatedAt = (DateTime)row["UpdatedAt"],
                };

                list.Add(tmp);
            }
            return list;
        }

        public Role getFirstById(string id)
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where  IsDeleted = 0 and id = '{id}'");

            Role tmp = null;
            foreach (DataRow row in dt.Rows)
            {
                tmp = new Role
                {
                    Id = (int)row["Id"],
                    Name = row["Name"].ToString(),
                    IsDeleted = (bool)row["IsDeleted"],
                    CreatedAt = (DateTime)row["CreatedAt"],
                    UpdatedAt = (DateTime)row["UpdatedAt"],
                };
            }
            return tmp;
        }

        public bool existsById(string id)
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where  IsDeleted = 0 and id = '{id}'");

           if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateById(Role role)
        {
            string query = $"UPDATE {TableName} SET " +
                $"`Name` = '{role.Name}', " +
                $"UpdatedAt = '{Utils.Util.FormatDateTime(role?.UpdatedAt)}' " +
                $"where IsDeleted = 0 and Id = {role.Id}";
            return ConnectDb.ExecuteNonQuery(query);
        }

        public bool DeleteById(string id)
        {
            string strQuery = $"UPDATE {TableName} set IsDeleted = 1 where id='{id}'";

            return ConnectDb.ExecuteNonQuery(strQuery);
        }

        public bool Add(Role role)
        {
            role.IsDeleted = false;
            role.CreatedAt = DateTime.Now;
            role.UpdatedAt = DateTime.Now;
            string query = $"Insert into {TableName}(Name, CreatedAt, IsDeleted, UpdatedAt) " +
                            $"VALUES ('{role.Name}', " +
                            $"'{role.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'0', " +
                            $"'{role.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")}')";
            return ConnectDb.ExecuteNonQuery(query); ;
        }
    }
}
