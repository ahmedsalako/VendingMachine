using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Events;

namespace VendingMachine.Interfaces
{
    public interface IEventBus
    {
        void RegisterListener(IEventListener<PaymentTakenWithChangeEvent> eventListener);
        void RegisterListener(IEventListener<PaymentTakenEvent> eventListener);
        void RegisterListener(IEventListener<ProductAvailableEvent> eventListener);
        void RegisterListener(IEventListener<VendingProcessRestartingEvent> eventListener);
        void RegisterListener(IEventListener<VendingProcessStartingEvent> eventListener);
        void RegisterListener(IEventListener<ProductOutOfStockEvent> eventListener);


        void RaiseEvent(VendingProcessStartingEvent @event);
        void RaiseEvent(VendingProcessRestartingEvent @event);
        void RaiseEvent(ProductAvailableEvent @event);
        void RaiseEvent(ProductOutOfStockEvent @event);
        void RaiseEvent(PaymentTakenWithChangeEvent @event);
        void RaiseEvent(PaymentTakenEvent @event);
    }
}
