using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Events;
using VendingMachine.Interfaces;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = DependencyContainer.Configure();

            IVendingMachineWorkflow workflow = container.Resolve<IVendingMachineWorkflow>();
            IEventBus eventBus = container.Resolve<IEventBus>();

            eventBus.RegisterListener(workflow as IEventListener<PaymentTakenWithChangeEvent>);
            eventBus.RegisterListener(workflow as IEventListener<PaymentTakenEvent>);
            eventBus.RegisterListener(workflow as IEventListener<VendingProcessRestartingEvent>);
            eventBus.RegisterListener(workflow as IEventListener<VendingProcessStartingEvent>);
            eventBus.RegisterListener(workflow as IEventListener<ProductAvailableEvent>);
            eventBus.RegisterListener(workflow as IEventListener<ProductOutOfStockEvent>);

            workflow.Begin();
        }
    }
}
