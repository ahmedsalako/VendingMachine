using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Events;

namespace VendingMachine.Interfaces
{
    public interface IEventListener<T> where T : DomainEvent
    {
        void Handle(T eventArgs);
    }
}
