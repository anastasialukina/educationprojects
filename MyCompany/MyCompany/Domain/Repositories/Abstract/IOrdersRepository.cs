using System;
using System.Linq;
using MyCompany.Domain.Entities;

namespace MyCompany.Domain.Repositories.Abstract
{
    public interface IOrdersRepository
    {
        IQueryable<Order> GetOrders();
        IQueryable<Order> GetOpenOrders();
        IQueryable<Order> GetOrdersByCustomer(string id);
        IQueryable<Order> GetOrdersByExecutor(string id);
        Order GetOrderById(Guid id);
        void SaveOrder(Order entity);
        void DeleteOrder(Guid id);
    }
}