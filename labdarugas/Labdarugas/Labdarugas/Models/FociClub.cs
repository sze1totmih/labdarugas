using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labdarugas.Models
{
    public class FociClub
    {
        public DateTime Alapitas { get; set; }
        public string Name { get; set; }
        public double Koltsegvetes { get; set; }
        public List<Focista> Focistak { get; set; }

        public FociClub(DateTime alapitas, string name, double koltsegvetes)
        {
            Alapitas = alapitas;
            Name = name;
            Koltsegvetes = koltsegvetes;
            Focistak = new List<Focista>();
        }









    }
}
