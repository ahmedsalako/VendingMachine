using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Interfaces;
using VendingMachine.Models;

namespace VendingMachine.Repository
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products = new List<Product>
        {
            new Product(id:1, name:"Coca Cola", price:0.80M, description:"330ml"),
            new Product(id:2, name:"Coke Zero", price:0.80M, description:"330ml"),
            new Product(id:3, name:"Fanta",     price:0.80M, description:"330ml"),
            new Product(id:4, name:"Sprite",    price:0.80M, description:"330ml"),
            new Product(id:5, name:"Coca Cola", price:1.20M, description:"500ml"),
            new Product(id:6, name:"Coke Zero", price:1.20M, description:"500ml"),
            new Product(id:7, name:"Fanta",     price:1.20M, description:"500ml"),
            new Product(id:8, name:"Sprite",    price:1.20M, description:"500ml"),
            new Product(id:9, name:"Water",     price:1.00M, description:"500ml"),
        };

        public Product FindById(int id)
        {
            return _products.FirstOrDefault(c => c.Id == id);
        }

        public bool Exists(int id)
        {
            return _products.Any(c => c.Id == id);
        }

        public List<Product> GetAll()
        {
            return _products;
        }
    }
}
