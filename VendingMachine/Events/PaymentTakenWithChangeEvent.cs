using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Models;

namespace VendingMachine.Events
{
    public class PaymentTakenWithChangeEvent : DomainEvent
    {
        public Change Change { get; private set; }

        public int ProductId { get; private set; }

        public PaymentTakenWithChangeEvent(Change change, int productId)
        {
            this.Change = change;
            this.ProductId = productId;
        }
    }
}
