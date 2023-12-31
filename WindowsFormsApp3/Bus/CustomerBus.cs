﻿using QuanLyCuaHangSach.Dao;
using QuanLyCuaHangSach.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Bus
{
    public class CustomerBus
    {
        public CustomerDao Dao { get; set; } = new CustomerDao();
        public CustomerBus() { }

        public List<Customer> getList()
        {
            return Dao.getAll();
        }

        public Customer getFirstById(string id)
        {
            return Dao.getFirstById(id);
        }
        public bool UpdateById(Customer author)
        {
            return Dao.UpdateById(author);
        }
        public bool DeleteById(string id)
        {
            return Dao.DeleteById(id);
        }
        public bool Add(Customer author)
        {
            return Dao.Add(author);
        }
    }
}
