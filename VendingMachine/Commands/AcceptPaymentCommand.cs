using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Commands
{
    public class AcceptPaymentCommand : BusinessCommand
    {
        public decimal Payment { get; private set; }
        public int ProductId { get; private set; }

        public AcceptPaymentCommand(int productId, decimal payment)
        {
            this.ProductId = productId;
            this.Payment = payment;
        }
    }
}
