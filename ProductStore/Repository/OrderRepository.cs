using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using ProductStore.Interface;
using ProductStore.Models;
using ProductStore.DataContext;

namespace ProductStore.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private OrdersContext db = new OrdersContext();
        public IEnumerable<Order> GetOrders()
        {
            return db.Orders;
        }

        public Order GetOrder(int id,string name)
        {
            return db.Orders.Include("OrderDetails.Product").First(o => o.Id == id && o.Customer == name);
             
        }

        public void PostOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();

        }

    }
}