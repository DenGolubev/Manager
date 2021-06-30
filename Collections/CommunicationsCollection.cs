using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Collections
{
    public class CommunicationsCollection: ObservableCollection<string>
    {
        public CommunicationsCollection()
        {
            Add("none");
            Add("Whatsapp");
            Add("Skype");
            Add("Viber");
            Add("Telegram");
        }
    }
}
