using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    /// <summary>
    /// A Change in the real world is refered to as money
    /// </summary>
    public class Change : Money, IEnumerable<ChangeItem>
    {
        List<ChangeItem> _items = new List<ChangeItem>();

        public void Add(ChangeItem item)
        {
            _items.Add(item);
        }

        public IEnumerator<ChangeItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
