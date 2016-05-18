using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Interfaces;
using VendingMachine.Repository;

namespace VendingMachine
{
    public static class DependencyContainer
    {
        public static IUnityContainer Configure()
        {
            IUnityContainer unityContainer = new UnityContainer();

            unityContainer.RegisterType<ICoinsRepository, CoinsRepository>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IEventBus, EventBus>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IProductRepository, ProductRepository>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IStockRepository, StockRepository>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IUserInterfaceManager, UserInterfaceManager>();
            unityContainer.RegisterType<IVendingMachineWorkflow, VendingMachineWorkflow>();
            unityContainer.RegisterType<StockManager>();
            unityContainer.RegisterType<PricingManager>();

            return unityContainer;
        } 
    }
}
