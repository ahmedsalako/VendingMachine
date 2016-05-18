using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Events
{ 
    public class PaymentTakenEvent : DomainEvent
    {
        public int ProductId { get; private set; }

        public PaymentTakenEvent(int productId)
        {
            this.ProductId = productId;
        }
    }
}
