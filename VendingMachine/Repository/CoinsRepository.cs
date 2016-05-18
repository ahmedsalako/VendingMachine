using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Interfaces;
using VendingMachine.Models;

namespace VendingMachine.Repository
{
    public class CoinsRepository : ICoinsRepository
    {
        //Once paid for, returns change(if applicable & can just be printed values) obeying the rules of the currency, 
        //e.g.only return £2, £1, 50p, 20p, 10p and 5p coins.  1p and 2p coins need not be supported.
        List<Coin> _coins = new List<Coin>
        {
            new Coin(2.00M, "£2"),
            new Coin(1.00M, "£1"),
            new Coin(00.50M, "50p"),
            new Coin(00.20M, "20p"),
            new Coin(00.10M, "10p"),
            new Coin(00.5M, "5p")
        };

        public List<Coin> GetAll()
        {
            return _coins;
        }
    }
}
