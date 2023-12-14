using QuanLyCuaHangSach.Configs;
using QuanLyCuaHangSach.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp3.Gui.Forms;

namespace QuanLyCuaHangSach.Dao
{
    public class ImportDao : ICrudDao<Import>
    {
        public string TableName { get; set; } = "imports";
        public ImportDao() { }
        public List<Import> getAll()
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where IsDeleted = 0;");
            var list = new List<Import>();
            foreach (DataRow row in dt.Rows)
            {
                Import tmp = new Import()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    AccountId = Convert.ToInt32(row["AccountId"]),
                    Status = row["Status"].ToString(),
                    ImportDate = Convert.ToDateTime(row["ImportDate"]),
                    IsDeleted = Convert.ToBoolean(row["IsDeleted"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]),
                };

                list.Add(tmp);
            }
            return list;
        }

        public Import getFirstById(string id)
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where  IsDeleted = 0 and id = '{id}'");

            Import tmp = null;
            foreach (DataRow row in dt.Rows)
            {
                tmp = new Import()
                {

                    Id = Convert.ToInt32(row["Id"]),
                    AccountId = Convert.ToInt32(row["AccountId"]),
                    Status = row["Status"].ToString(),
                    ImportDate = Convert.ToDateTime(row["ImportDate"]),
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
        public bool UpdateById(Import role)
        {
            string query = $"UPDATE {TableName} SET " +
                $"`Status` = '{role.Status}', " +
                $"UpdatedAt = '{Utils.Util.FormatDateTime(role?.UpdatedAt)}' " +
                $"where IsDeleted = 0 and Id = {role.Id}";
            return ConnectDb.ExecuteNonQuery(query);
        }

        public bool DeleteById(string id)
        {
            string strQuery = $"UPDATE {TableName} set IsDeleted = 1 where id='{id}'";

            return ConnectDb.ExecuteNonQuery(strQuery);
        }

        public bool Add(Import role)
        {
            role.IsDeleted = false;
            role.CreatedAt = DateTime.Now;
            role.UpdatedAt = DateTime.Now;
            string query = $"Insert into {TableName}(Status, CreatedAt, IsDeleted, UpdatedAt) " +
                            $"VALUES ('{role.Status}', " +
                            $"'{role.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'0', " +
                            $"'{role.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")}')";
            return ConnectDb.ExecuteNonQuery(query); ;
        }

        internal int CreateImport(Import import)
        {
            import.IsDeleted = false;
            import.CreatedAt = DateTime.Now;
            import.UpdatedAt = DateTime.Now;
            string query = $"Insert into {TableName}( Status, AccountId, ImportDate, CreatedAt, IsDeleted, UpdatedAt) " +
                            $"VALUES ('{import.Status}', " +
                            $"'{import.AccountId}', " +
                            $"'{import.ImportDate.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'{import.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'0', " +
                            $"'{import.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")}'); SELECT LAST_INSERT_ID();";
            return ConnectDb.ExecuteScalar(query);
        }

        internal bool DeleteHardById(int id)
        {
            string strQuery = $" DELETE FROM {TableName} where id='{id}'";

            return ConnectDb.ExecuteNonQuery(strQuery);
        }

        public List<FOrder.CustomBook> getListOrder(string orderId)
        {

            DataTable dt = ConnectDb.ExecuteReaderTable($@"
                            SELECT  T4.Id AS BooId, T2.Price, T2.BuyQuantity, T3.Barcode, T4.Name
                             FROM imports T1 
                             JOIN importdetail T2 ON T1.Id = T2.ImportId
                             JOIN bookdetail T3 ON T3.Id = T2.BookDetailId
                             JOIN book T4 ON T4.Id = T3.BookId
                             WHERE T1.Id = '{orderId}'
                    ");

            var list = new List<FOrder.CustomBook>();

            foreach (DataRow row in dt.Rows)
            {
                var tmp = new FOrder.CustomBook
                {
                    BookId = Convert.ToInt32(row["BooId"]),
                    Price = Convert.ToDouble(row["Price"]),
                    Quantity = Convert.ToInt32(row["BuyQuantity"]),
                    Barcode = (row["Barcode"].ToString()),
                    Name = (row["Name"].ToString()),
                };
                tmp.TotalCost = tmp.Price * tmp.Quantity;
                //tmp.SetTotalCost();

                list.Add(tmp);
            }
            return list;
        }

    }
}
