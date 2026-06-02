using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace WpfApp4
{
    public class MainVM : BaseVM
    {
        private int _id = 0;
        public int ID
        {
            get { return _id; }
            set
            {
                if (!Equals(_id, value))
                {
                    _id = value;
                    OnPropertyChanged("ID");
                }
            }
        }
    }
}
