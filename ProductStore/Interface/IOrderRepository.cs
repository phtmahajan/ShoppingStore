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
        #region Save,Upadate,Delete,Dispose Method.
        void PostOrder(Order order);
        void Dispose();
        #endregion

        #region Get Method.
        IEnumerable<Order> GetOrders();
        Order GetOrder(int id, string name);
        #endregion

    }
}
