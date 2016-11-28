using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Lineyschikov.WpfAssignment.Desktop.DataAccess;
using Lineyschikov.WpfAssignment.Desktop.Models;

namespace Lineyschikov.WpfAssignment.Desktop.Services
{
    public class OrdersService : IApplicationService
    {
        private readonly CoreContext _dbContext;

        public OrdersService(CoreContext dbContext)
        { 
            if (dbContext == null) throw new ArgumentException("dbContext");
            _dbContext = dbContext;
        }

        public Task<List<Order>> GetOrders(int customerId)
        {
            return _dbContext.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
        }

        public async Task<int> Create(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order.Id;
        }
        public Task Update(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }

        public Task Delete(int orderId)
        {
            Order order = _dbContext.Orders.Find(orderId);
            _dbContext.Orders.Remove(order);
            return _dbContext.SaveChangesAsync();
        }
    }
}