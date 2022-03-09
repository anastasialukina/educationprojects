using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;

namespace MyCompany.Domain.Repositories.EntityFramework
{
    public class EFOrdersRepository : IOrdersRepository
    {
        private readonly AppDbContext context;

        public EFOrdersRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Order> GetOrders()
        {
            return context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Executor);
        }

        public IQueryable<Order> GetOpenOrders()
        {
            return context.Orders
                .Where(o => o.Status == OrderStatus.Created)
                .Include(o => o.Customer)
                .Include(o => o.Executor);
        }

        public IQueryable<Order> GetOrdersByCustomer(string id)
        {
            return context.Orders
                .Where(o => o.CustomerId == id)
                .Include(o => o.Customer)
                .Include(o => o.Executor);
        }

        public IQueryable<Order> GetOrdersByExecutor(string id)
        {
            return context.Orders
                .Where(o => o.ExecutorId == id)
                .Include(o => o.Customer)
                .Include(o => o.Executor);
            ;
        }

        public Order GetOrderById(Guid id)
        {
            return context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Executor)
                .FirstOrDefault(x => x.Id == id);
        }

        public void SaveOrder(Order entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }


        public void DeleteOrder(Guid id)
        {
            context.Orders.Remove(new Order() { Id = id });
            context.SaveChanges();
        }
    }
}