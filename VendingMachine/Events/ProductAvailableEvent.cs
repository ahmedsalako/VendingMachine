using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Events
{
    public class ProductAvailableEvent : DomainEvent
    {
        public int ProductId { get; private set; }

        public ProductAvailableEvent(int productId)
        {
            this.ProductId = productId;
        }
    }
}
