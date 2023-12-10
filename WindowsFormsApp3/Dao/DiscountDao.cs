﻿using QuanLyCuaHangSach.Configs;
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
    public class DiscountDao : ICrudDao<Discount>
    {
        public string TableName { get; set; } = "discount";
        public DiscountDao() { }
        public List<Discount> getAll()
        {

            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where IsDeleted = 0;");

            var list = new List<Discount>();

            foreach (DataRow row in dt.Rows)
            {
                var tmp = new Discount
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = (string)row["Name"],
                    Quantity = (int)row["Quantity"],
                    Value = (float)row["Value"],
                    StartDate = (DateTime)row["StartDate"],
                    EndDate = (DateTime)row["EndDate"],
                    IsDeleted = (bool)row["IsDeleted"],
                    CreatedAt = (DateTime)row["CreatedAt"],
                    UpdatedAt = (DateTime)row["UpdatedAt"],
                };

                list.Add(tmp);
            }
            return list;
        }

        public Discount getFirstById(string id)
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where  IsDeleted = 0 and id = '{id}'");

            Discount tmp = null;
            foreach (DataRow row in dt.Rows)
            {
                tmp = new Discount
                {
                    Id = (int)row["Id"],
                    Name =(string) row["Name"],
                    Quantity = (int)row["Quantity"],
                    Value = (float)row["Value"],
                    StartDate = (DateTime)row["StartDate"],
                    EndDate = (DateTime)row["EndDate"],
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
        public bool UpdateById(Discount discount)
        {
            string query = $"UPDATE {TableName} SET " +
                $"`Name` = '{discount.Name}', " +
                $"`Quantity` = '{discount.Quantity}', " +
                $"`Value` = '{discount.Value}', " +
                $"`StartDate` = '{discount.StartDate}', " +
                $"`EndDate` = '{discount.EndDate}', " +
                $"UpdatedAt = '{Utils.Util.FormatDateTime(discount?.UpdatedAt)}' " +
                $"where IsDeleted = 0 and Id = {discount.Id}";
            return ConnectDb.ExecuteNonQuery(query);
        }

        public bool DeleteById(string id)
        {
            string strQuery = $"UPDATE {TableName} set IsDeleted = 1 where id='{id}'";

            return ConnectDb.ExecuteNonQuery(strQuery);
        }

        public bool Add(Discount discount)
        {
            discount.IsDeleted = false;
            discount.CreatedAt = DateTime.Now;
            discount.UpdatedAt = DateTime.Now;
            string query = $"Insert into {TableName}(Name,Quantity,Value,StartDate,EndDate, CreatedAt, IsDeleted, UpdatedAt) " +
                            $"VALUES ('{discount.Name}', " +
                            $"'{discount.Quantity}', " +
                            $"'{discount.Value}', " +
                            $"'{discount.StartDate.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'{discount.EndDate.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'{discount.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'0', " +
                            $"'{discount.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")}')";
            return ConnectDb.ExecuteNonQuery(query); ;
        }
    }
}
