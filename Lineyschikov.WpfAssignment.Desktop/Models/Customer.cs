using System.Collections.Generic;

namespace Lineyschikov.WpfAssignment.Desktop.Models
{
    public class Customer : Entity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public bool Vip { get; set; }

        public virtual IList<Order> Orders { get; set; }
    }
}