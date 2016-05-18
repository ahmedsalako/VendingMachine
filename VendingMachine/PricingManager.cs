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
    public class PricingManager
    {
        private IProductRepository productRepository;
        private ICoinsRepository coinsRepository;
        private IEventBus eventBus;

        public PricingManager(ICoinsRepository coinsRepository, IEventBus eventBus, IProductRepository productRepository)
        {
            this.eventBus = eventBus;
            this.coinsRepository = coinsRepository;
            this.productRepository = productRepository;
        }

        public void Handle(AcceptPaymentCommand command)
        {
            Product product = productRepository.FindById(command.ProductId);

            if(product.Price == command.Payment){
                //raise payment completed no change event
                eventBus.RaiseEvent(new PaymentTakenEvent(command.ProductId));
            }
            else if(command.Payment > product.Price)
            {
                Change change = new Change();
                decimal changeAmount = command.Payment - product.Price;

                //order the coins by the denomination in descending order
                //this will work out, how many of the same denomination is given as change
                foreach(Coin coin in coinsRepository.GetAll().OrderByDescending(c => c.Denomination))
                {
                    if (coin.Denomination <= changeAmount) {
                        //operator overloading can be leveraged here
                        decimal remainder = changeAmount % coin.Denomination;

                        decimal count = Math.Min(100, (changeAmount - remainder) / coin.Denomination);
                        changeAmount = remainder;

                        change.Add(new ChangeItem(coin, (int)count));                 
                     }
                }

                eventBus.RaiseEvent(new PaymentTakenWithChangeEvent(change, command.ProductId));
            }
        }
    }
}
