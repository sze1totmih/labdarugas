using Labdarugas.Models;
using System;
using System.Linq;

namespace Labdarugas
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new Context();
            //Console.WriteLine(ctx);

            Console.WriteLine("Hány fociklub szerepel a listában?");
            Console.WriteLine(ctx.FociKlubok.Count());
            Console.WriteLine();

            //Összeadás
            Console.WriteLine("Összesen hány millió a klubbok költségvetése?");
            var osszeg = ctx.FociKlubok.Sum(x => x.Koltsegvetes);
            Console.WriteLine(osszeg);
            Console.WriteLine();

            //Maximum
            Console.WriteLine("Hány cm a legmagasabb focista?");
            var magassag = ctx.Focistak.Max(x => x.Magassag);
            Console.WriteLine(magassag);
            Console.WriteLine();

            //Szűrés, iterálás
            Console.WriteLine("Mely focisták magassága kisseb, mint 180cm?");
            var alacsonyak = ctx.Focistak.Where(x => x.Magassag < 180);
            alacsonyak.ToList().ForEach(x => Console.WriteLine(x.Nev));
            Console.WriteLine();

            //Sorbarendezés
            Console.WriteLine("Rendezze mezszámok szerint a focistákat!");
            var mezlista = ctx.Focistak.OrderBy(x => x.Mezszam).ToList();
            //ThenBy -- második rendezési elv/mező
            mezlista.ForEach(x => Console.WriteLine(x.Mezszam + ", " + x.Nev));
            Console.WriteLine();

            //Csoportosítás
            Console.WriteLine("Csoportosítsa a focistákat klubok alapján és számolja meg a tagokat!");
            var csapatok = ctx.Focistak.GroupBy(x => x.FociClub).ToList();
            csapatok.ForEach(x => Console.WriteLine(x.Key.Name + " klub tagjainak száma: " + x.Count()));
            Console.WriteLine();

            //Egyedi elem megtalálása
            Console.WriteLine("Melyik az a klub, akinek az alapítási éve kisebb, mint 1950 és a költségvetése 500 millió felett van?");
            // SingleOrDefault = 1 elemre igaz a feltétel, több esetén hibát dob
            // FirstOrDefault = Az első elemet adja vissza, ami megfelel a feltételnek
            // FirstOrDefault = kulcs értékre használjuk
            // try + TAB + TAB
            try
            {
                var klub = ctx.FociKlubok.SingleOrDefault(x => x.Alapitas.Year < 1950 && x.Koltsegvetes > 500);
                Console.WriteLine(klub.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }

            //Kiválasztás
            Console.WriteLine("Írja ki a páros mezszámokat!");
            var paros = ctx.Focistak.Where(x => x.Mezszam % 2 == 0).Select(x => x.Mezszam).ToList();
            paros.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            //Anoním típus
            Console.WriteLine("Írja ki a bal rúgólábas focistáknak és klubjának neveit!");
            var ballabas = ctx.Focistak.Where(x => x.Jobblabas == false).Select(x => new { JatekosNev = x.Nev, KlubNev = x.FociClub.Name }).ToList();
            ballabas.ForEach(x => Console.WriteLine(x.JatekosNev + ", klubja " +x.KlubNev));
            Console.WriteLine();

            //Feltételes (többszintű) keresés
            Console.WriteLine("Játszik valamelyik csapatban Sergio Ramos? ");
            // Any = bool érték, amikor teljesül akkor nem megy tovább
            var ramos = ctx.FociKlubok.Any(x => x.Focistak.Any(y=> y.Nev == "Sergio Ramos"));
            Console.WriteLine(ramos);
            Console.WriteLine();
        }
    }
}
