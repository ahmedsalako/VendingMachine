using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Models;

namespace VendingMachine.Interfaces
{
    public interface IUserInterfaceManager
    {
        void ListProductCatalog();

        int GetProductNumber();

        void PrintOutOfStockMessage(int productId);

        decimal GetPayment(int productId);

        void ThankYou();

        void ThankYou(Change change);
    }
}
