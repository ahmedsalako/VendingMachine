using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Commands;
using VendingMachine.Events;
using VendingMachine.Interfaces;
using VendingMachine.Models;

namespace VendingMachine
{
    public class StockManager
    {
        private IStockRepository stockRepository;
        private IEventBus eventBus;

        public StockManager(
            IStockRepository stockRepository,
            IEventBus eventBus
            )
        {
            this.stockRepository = stockRepository;
            this.eventBus = eventBus;
        }

        public void Handle(CheckProductAvailabilityCommand command)
        {
            Stock stock = stockRepository.FindByProductId(command.ProductId);

            //its a vending machine, its singleton no point in checking concurrency

            if (stock.Amount > 0)
            {
                eventBus.RaiseEvent(new ProductAvailableEvent(command.ProductId));
            }
            else
            {
                eventBus.RaiseEvent(new ProductOutOfStockEvent(command.ProductId));
            }
        }

        public void Handle(UpdateStockCommand command)
        {
            //deduct from the stock
            stockRepository.UpdateStock(command.ProductId);
        }
    }
}
