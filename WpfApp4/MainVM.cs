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
        private int _id1 = 1000;
        public int ID1
        {
            get { return _id1; }
            set
            {
                if (!Equals(_id1, value))
                {
                    _id1 = value;
                    OnPropertyChanged("ID1");
                }
            }
        }
    }
}
