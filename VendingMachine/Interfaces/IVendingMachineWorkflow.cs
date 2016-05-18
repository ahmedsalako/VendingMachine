using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Events;

namespace VendingMachine.Interfaces
{
    public interface IVendingMachineWorkflow :

        IEventListener<ProductAvailableEvent>,
        IEventListener<ProductOutOfStockEvent>,
        IEventListener<VendingProcessRestartingEvent>,
        IEventListener<VendingProcessStartingEvent>,
        IEventListener<PaymentTakenWithChangeEvent>,
        IEventListener<PaymentTakenEvent>
    {
        void Begin();
    }
}
