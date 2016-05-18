using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Interfaces;
using VendingMachine.Models;

namespace VendingMachine
{
    public class UserInterfaceManager : IUserInterfaceManager
    {
        private IProductRepository productRepository;
        private IStockRepository stockRepository;

        public UserInterfaceManager
            (IProductRepository productRepository, IStockRepository stockRepository)
        {
            this.productRepository = productRepository;
            this.stockRepository = stockRepository;
        }

        public void ListProductCatalog()
        {
            Console.WriteLine("Number \t\t Stock \t\t Price \t\t Product");
            foreach (Product product in productRepository.GetAll().OrderBy(c => c.Id)){
                Stock stock = stockRepository.FindByProductId(product.Id);

                Console.WriteLine("{0} \t\t {1} \t\t {2} \t\t {3}", 
                                            product.Id,
                                            stock.Amount,
                                            product.Price.ToString("C", CultureInfo.CurrentCulture),
                                            string.Format("{0} {1}", product.Name, product.Description)
                                        );
            }
        }

        public int GetProductNumber()
        {
            Console.WriteLine("please select a product:");

            int value = 0;

            do
            {
                string number = Console.ReadLine();
                if (!int.TryParse(number, out value) || !productRepository.Exists(value))
                {
                    Console.WriteLine("Invalid product number, please select from the product range!");
                }
            }
            while (value == 0);

            return value;
        }

        public void PrintOutOfStockMessage(int productId)
        {
            Product product = productRepository.FindById(productId);

            Console.WriteLine("{0} {0} is currently out of stock!", product.Name, product.Description);
        }

        public decimal GetPayment(int productId)
        {
            Product product = productRepository.FindById(productId);
            Console.WriteLine("Please insert coin(s): ");
            decimal value = 0;
            decimal total = 0;

            do
            {
                string money = Console.ReadLine();

                if (!decimal.TryParse(money.Replace(":", "."), NumberStyles.Currency, System.Globalization.CultureInfo.CurrentCulture, out value))
                {
                    Console.WriteLine("Invalid amount entered. Please enter a valid amount!");
                }
                else
                {
                    total += value;
                }

                if(total > 0 && total != product.Price && total < product.Price)
                {
                    Console.WriteLine("{0} remaning", product.Price - value);
                }
            }
            while (total != product.Price && total < product.Price);

            return total;
        }

        public void ThankYou()
        {
            Console.WriteLine("Vending product... Thank you");
        }

        public void ThankYou(Change change)
        {
            Console.WriteLine("Vending product... Thank you, please take your change");
            foreach (ChangeItem item in change)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    Console.WriteLine(item.Coin.Name);
                }
            }
        }
    }
}
