using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Collections
{
    public class DeliveryCollection : ObservableCollection<string>
    {
        public DeliveryCollection()
        {
            Add("Самовывоз");
            Add("Доставка курьером");
            Add("Доставка такси");
        }
    }
}
