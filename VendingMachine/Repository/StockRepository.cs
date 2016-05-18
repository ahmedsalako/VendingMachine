using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Interfaces;
using VendingMachine.Models;

namespace VendingMachine.Repository
{
    public class StockRepository : IStockRepository
    {
        private List<Stock> _stocks = new List<Stock>
        {
            new Stock(10, 1),
            new Stock(13, 2),
            new Stock(11, 3),
            new Stock(12, 4),
            new Stock(5, 5),
            new Stock(4, 6),
            new Stock(10, 7),
            new Stock(8, 8),
            new Stock(05, 9)
        };

        public Stock FindByProductId(int productId)
        {
            return _stocks.FirstOrDefault(c => c.ProductId == productId);
        }

        public List<Stock> GetAll()
        {
            return _stocks;
        }

        public void UpdateStock(int productId)
        {
            Stock stock = _stocks.FirstOrDefault(c => c.ProductId == productId);
            stock.Decrement();
        }
    }
}
