using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class Coin : Money
    {
        public decimal Denomination { get; private set; }

        public string Name { get; private set; }

        public Coin(decimal denomination, string name)
        {
            Denomination = denomination;
            Name = name;
        }
    }
}
