using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Collections
{
    class CelebrationCollection : ObservableCollection<string>
    {
        public CelebrationCollection()
        {
            Add("День рождения");
            Add("Новый год");
            Add("Рождество Христово");
            Add("День защитника Отечества");
            Add("Международный женский день");
            Add("Праздник весны и труда");
            Add("День Победы");
            Add("День России");
            Add("День народного единства");
            Add("День знаний");
        }
    }
}
