using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Commands
{
    public class UpdateStockCommand : BusinessCommand
    {
        public int ProductId
        {
            get; private set;
        }

        public UpdateStockCommand(int productId)
        {
            this.ProductId = productId;
        }
    }
}
