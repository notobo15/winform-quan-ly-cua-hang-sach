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
    public class ImportDetailDao : ICrudDao<ImportDetail>
    {
        public string TableName { get; set; } = "importdetail";
        public ImportDetailDao() { }
        public List<ImportDetail> getAll()
        {

            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where IsDeleted = 0;");

            var list = new List<ImportDetail>();

            foreach (DataRow row in dt.Rows)
            {
                var tmp = new ImportDetail
                {
                    Id = Convert.ToInt32(row["Id"]),
                    ImportId = Convert.ToInt32(row["ImportId"]),
                    BuyQuantity = Convert.ToInt32(row["BuyQuantity"]),
                    BookDetailId = Convert.ToInt32(row["BookDetailId"]),
                    Price = Convert.ToDouble(row["Price"]),
                    IsDeleted = Convert.ToBoolean(row["IsDeleted"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]),
                };

                list.Add(tmp);
            }
            return list;
        }

        public ImportDetail getFirstById(string id)
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where  IsDeleted = 0 and id = '{id}'");

            ImportDetail tmp = null;
            foreach (DataRow row in dt.Rows)
            {
                tmp = new ImportDetail
                {
                    Id = Convert.ToInt32(row["Id"]),
                    ImportId = Convert.ToInt32(row["ImportId"]),
                    BuyQuantity = Convert.ToInt32(row["BuyQuantity"]),
                    BookDetailId = Convert.ToInt32(row["BookDetailId"]),
                    Price = Convert.ToDouble(row["Price"]),
                    IsDeleted = Convert.ToBoolean(row["IsDeleted"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]),
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
        public bool UpdateById(ImportDetail role)
        {
            string query = $"UPDATE {TableName} SET " +
                $"`Price` = '{role.Price}', " +
                $"UpdatedAt = '{Utils.Util.FormatDateTime(role?.UpdatedAt)}' " +
                $"where IsDeleted = 0 and Id = {role.Id}";
            return ConnectDb.ExecuteNonQuery(query);
        }

        public bool DeleteById(string id)
        {
            string strQuery = $"UPDATE {TableName} set IsDeleted = 1 where id='{id}'";

            return ConnectDb.ExecuteNonQuery(strQuery);
        }

        public bool Add(ImportDetail orderDetail)
        {
            orderDetail.CreatedAt = DateTime.Now;
            orderDetail.UpdatedAt = DateTime.Now;
            string query = $"Insert into {TableName}(ImportId,BookDetailId, Price, BuyQuantity, CreatedAt, IsDeleted, UpdatedAt) " +
                            $"VALUES (" +
                            $"'{orderDetail.ImportId}', " +
                            $"'{orderDetail.BookDetailId}', " +
                            $"'{orderDetail.Price}', " +
                            $"'{orderDetail.BuyQuantity}', " +
                            $"'{orderDetail.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'0', " +
                            $"'{orderDetail.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")}')";
            return ConnectDb.ExecuteNonQuery(query);
        }
    }
}
