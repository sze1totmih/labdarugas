using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labdarugas.Models
{
    class Context
    {
        public List<Focista> Focistak { get; set; }
        public List<FociClub> FociKlubok { get; set; }

        public Context()
        {
            Focistak = new List<Focista>();
            FociKlubok = new List<FociClub>();

            DateTime datum = new DateTime(1902, 04, 16);
            FociClub RealMadrid = new FociClub(datum, "Real Madrid", 577.7);
            FociClub BayernMunchen = new FociClub(new DateTime(1900, 02, 27), "Bayern München", 474.4);

            FociKlubok.Add(RealMadrid);
            FociKlubok.Add(BayernMunchen);

            Focistak.Add(new Focista("Sergio Ramos", 4, 184, 82, true, RealMadrid));
            Focistak.Add(new Focista("Edan Hazard", 7, 175, 74, true, RealMadrid));
            Focistak.Add(new Focista("Thibaut Courtois", 1, 199, 96, false, RealMadrid));

            Focistak.Add(new Focista("Benamin Pavard", 5, 186, 76, true, BayernMunchen));
            Focistak.Add(new Focista("Robert Levandowski", 9, 184, 80, true, BayernMunchen));
            Focistak.Add(new Focista("Joshua Kimmich", 6, 176, 73, true, BayernMunchen));

            RealMadrid.Focistak = Focistak.Where(f => f.FociClub == RealMadrid).ToList();
            BayernMunchen.Focistak = Focistak.Where(f => f.FociClub == BayernMunchen).ToList();
        }
    }
}