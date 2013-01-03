using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductStore.Models;

namespace ProductStore.Interface
{
    interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetOrder(int id, string name);
        void PostOrder(Order order);
        void Dispose();
    }
}
