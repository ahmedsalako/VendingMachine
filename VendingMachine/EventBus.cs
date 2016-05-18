using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Events;
using VendingMachine.Interfaces;

namespace VendingMachine
{
    //This is a mini eventbus, an enterprise level eventBus will handle the registrations and invovation reducing the amount of coding
    public class EventBus : IEventBus
    {
        //dont call us, we will call you "Hollywood principle"
        private Action<PaymentTakenWithChangeEvent> _paymentTakenWithChangeEventHandlers;
        private Action<PaymentTakenEvent> _paymentTakenEventHandlers;
        private Action<VendingProcessRestartingEvent> _vendingProcessRestartingEventHandlers;
        private Action<VendingProcessStartingEvent> _vendingProcessStartingEventHandlers;
        private Action<ProductAvailableEvent> _productsAvailableEventHandlers;
        private Action<ProductOutOfStockEvent> _productOutOfStockEventHandlers;

        public void RegisterListener(IEventListener<PaymentTakenWithChangeEvent> eventListener)
        {
            _paymentTakenWithChangeEventHandlers += eventListener.Handle;
        }

        public void RegisterListener(IEventListener<PaymentTakenEvent> eventListener)
        {
            _paymentTakenEventHandlers += eventListener.Handle;
        }

        public void RegisterListener(IEventListener<ProductAvailableEvent> eventListener)
        {
            this._productsAvailableEventHandlers += eventListener.Handle;
        }

        public void RegisterListener(IEventListener<VendingProcessRestartingEvent> eventListener)
        {
            this._vendingProcessRestartingEventHandlers += eventListener.Handle;
        }

        public void RegisterListener(IEventListener<VendingProcessStartingEvent> eventListener)
        {
            this._vendingProcessStartingEventHandlers += eventListener.Handle;
        }

        public void RegisterListener(IEventListener<ProductOutOfStockEvent> eventListener)
        {
            this._productOutOfStockEventHandlers += eventListener.Handle;
        }

        public void RaiseEvent(ProductAvailableEvent @event)
        {
            _productsAvailableEventHandlers(@event);
        }

        public void RaiseEvent(VendingProcessRestartingEvent @event)
        {
            _vendingProcessRestartingEventHandlers(@event);
        }

        public void RaiseEvent(VendingProcessStartingEvent @event)
        {
            _vendingProcessStartingEventHandlers(@event);
        }

        public void RaiseEvent(PaymentTakenWithChangeEvent @event)
        {
            _paymentTakenWithChangeEventHandlers(@event);
        }

        public void RaiseEvent(PaymentTakenEvent @event)
        {
            _paymentTakenEventHandlers(@event);
        }

        public void RaiseEvent(ProductOutOfStockEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
