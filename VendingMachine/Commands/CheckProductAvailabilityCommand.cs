using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Commands
{
    public class CheckProductAvailabilityCommand : BusinessCommand
    {
        public int ProductId { get; private set; }

        public CheckProductAvailabilityCommand(int productId)
        {
            this.ProductId = productId;
        }
    }
}
