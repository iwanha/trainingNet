using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.DataModel
{
    [Serializable]
    public class Cust
    {
        public string Nama {get;set;}
        public string JenisKelamin {get;set;}
        public string TanggalLahir {get;set;}
        public string TempatLahir {get;set;}
        public string Alamat {get;set;}
    }
}
