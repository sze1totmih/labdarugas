using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labdarugas.Models
{
    public class Focista
    {
        public string Nev { get; set; }
        public int Mezszam { get; set; }
        public int Magassag { get; set; }
        public int Suly { get; set; }
        public bool Jobblabas { get; set; }
        public FociClub FociClub { get; set; }

        public Focista(string nev, int mezszam, int magassag, int suly, bool jobblabas, FociClub fociClub)
        {
            Nev = nev;
            Mezszam = mezszam;
            Magassag = magassag;
            Suly = suly;
            Jobblabas = jobblabas;
            FociClub = fociClub;
        }
    }

}
