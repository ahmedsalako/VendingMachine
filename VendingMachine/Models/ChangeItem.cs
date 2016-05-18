using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class ChangeItem
    {
        public Coin Coin { get; private set; }

        public int Count { get; private set; }

        public ChangeItem(Coin coin, int count)
        {
            this.Coin = coin;
            this.Count = count;
        }
    }
}
