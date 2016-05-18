using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class Stock
    {
        public int Amount { get; private set; }

        public int ProductId { get; private set; }

        public Stock(int amount, int productId)
        {
            this.Amount = amount;
            this.ProductId = productId;
        }

        public void Decrement()
        {
            Amount -= 1;
        }
    }
}
