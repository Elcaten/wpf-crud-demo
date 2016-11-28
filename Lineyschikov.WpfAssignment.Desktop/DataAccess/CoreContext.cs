using System.Data.Entity;
using Lineyschikov.WpfAssignment.Desktop.Models;

namespace Lineyschikov.WpfAssignment.Desktop.DataAccess
{
    public class CoreContext : DbContext
    {
        public CoreContext() : base("name=LineyschikovCoreContext")
        {
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
}