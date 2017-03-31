using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using Lineyschikov.WpfAssignment.Desktop.DataAccess;
using Lineyschikov.WpfAssignment.Desktop.Models;

namespace Lineyschikov.WpfAssignment.Desktop.Services
{
    public class CustomersService : IApplicationService
    {
        private readonly CoreContext _dbContext;

        public CustomersService(CoreContext dbContext)
        {
            if (dbContext == null) throw new ArgumentException("dbContext");
            _dbContext = dbContext;
        }

        public Task<List<Customer>> GetAll()
        {
            return _dbContext.Customers.Include(c => c.Orders).ToListAsync();
        }

        public Task Create(Customer customer)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(2000);
                _dbContext.Customers.Add(customer);
                _dbContext.SaveChangesAsync();
            });
        }

        public Task Delete(int id)
        {   
            return Task.Run(() =>
            {
                Thread.Sleep(2000);
                Customer customer = _dbContext.Customers.Find(id);
                _dbContext.Customers.Remove(customer);
                _dbContext.SaveChangesAsync();
            });
        }
    }
}