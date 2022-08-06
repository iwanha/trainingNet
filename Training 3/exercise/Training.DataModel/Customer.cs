using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.DataModel
{
    [Serializable]
    public class Customer
    {
        public string Name { get; set; }
        public string CustType { get; set; }
        public string IDNo { get; set; }
    }
}
