using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Commands;
using VendingMachine.Events;
using VendingMachine.Interfaces;

namespace VendingMachine
{
    public class VendingMachineWorkflow : IVendingMachineWorkflow
    {
        private IUserInterfaceManager userInterfaceManager;
        private PricingManager pricingManager;
        private StockManager stockManager;
        private IEventBus eventBus;

        public VendingMachineWorkflow
            (StockManager stockManager, PricingManager pricingManager, IEventBus eventBus, IUserInterfaceManager userInterfaceManager)
        {
            this.userInterfaceManager = userInterfaceManager;
            this.pricingManager = pricingManager;
            this.stockManager = stockManager;
            this.eventBus = eventBus;
        }

        public void Begin()
        {
            eventBus.RaiseEvent(new VendingProcessStartingEvent());
        }

        public void Handle(VendingProcessStartingEvent eventArgs)
        {
            userInterfaceManager.ListProductCatalog();

            int productId = userInterfaceManager.GetProductNumber();

            stockManager.Handle(new CheckProductAvailabilityCommand(productId));
        }

        public void Handle(VendingProcessRestartingEvent eventArgs)
        {
            int productId = userInterfaceManager.GetProductNumber();

            stockManager.Handle(new CheckProductAvailabilityCommand(productId));
        }

        public void Handle(ProductAvailableEvent productAvailableEvent)
        {
            decimal payment = userInterfaceManager.GetPayment(productAvailableEvent.ProductId);

            pricingManager.Handle(new AcceptPaymentCommand(productAvailableEvent.ProductId, payment));
        }

        public void Handle(ProductOutOfStockEvent productOutOfStockEvent)
        {
            userInterfaceManager.PrintOutOfStockMessage(productOutOfStockEvent.ProductId);

            eventBus.RaiseEvent(new VendingProcessRestartingEvent());
        }

        public void Handle(PaymentTakenEvent eventArgs)
        {
            userInterfaceManager.ThankYou();

            stockManager.Handle(new UpdateStockCommand(eventArgs.ProductId));

            eventBus.RaiseEvent(new VendingProcessStartingEvent());
        }

        public void Handle(PaymentTakenWithChangeEvent eventArgs)
        {
            userInterfaceManager.ThankYou(eventArgs.Change);

            stockManager.Handle(new UpdateStockCommand(eventArgs.ProductId));

            eventBus.RaiseEvent(new VendingProcessStartingEvent());
        }
    }
}
