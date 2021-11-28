using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memóriajáték
{
    class Program
    {
        // az alábbó kódrészlethez felhasználtam a következő megoldást: https://www.geeksforgeeks.org/shuffle-a-deck-of-cards-3/
        private static void KartyaKeveres(int[] kartyak)
        {
            const int kartyakSzama = 10;
            Random rnd = new Random();

            //Végig iterálok az összes kártyán.
            for (int i = 0; i < kartyakSzama; i++)
            {
                //Kiválasztok a tömb még meg nem kevert kártyái közül egyet.
                int r = i + rnd.Next(kartyakSzama - i);

                //A fenti kártyát megcserélem a tömb elején álló kártyával.
                int tarolo = kartyak[r];
                kartyak[r] = kartyak[i];
                kartyak[i] = tarolo;

                //A kártyákat kiírom a konzolra, vigyázva, hogy egy sorba csak 5 kártya kerüljön.
                if (kartyakSzama / 2 - 1 == i)
                {
                    Console.WriteLine("X");
                }
                else
                {
                    Console.Write("X ");
                }
            }
        }

        static void Main(string[] args)
        {

            int[] kartyak = new int[] { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4 };

            KartyaKeveres(kartyak);

            int x = 0;
            int y = 0;
            int kor = 0;
            int elsoKartyaXPozicioja = 0;
            int elsoKartyaYPozicioja = 0;
            bool elsoJatekos = true;
            int elsoJatekosParjai = 0;
            int masodikJatekosParjai = 0;

            //A 3. sorba kiírom hogy ki kezdi a játékot.
            Console.SetCursorPosition(0, 3);
            Console.Write("Az 1. játékos következik.");

            //Visszaállok a játéktér 0,0 pozíciójába.
            Console.SetCursorPosition(0, 0);

            do
            {
                //Figyelem a billentyűleütéseket és mozgatom a kurzort azok hatására.
                switch (Console.ReadKey(true).Key)
                {
                    //Föl nyíl
                    case ConsoleKey.UpArrow:
                        if (y > 0)
                        {
                            y--;
                            Console.SetCursorPosition(x, y);
                        }
                        break;

                    //Le nyíl
                    case ConsoleKey.DownArrow:
                        if (y < 1)
                        {
                            y++;
                            Console.SetCursorPosition(x, y);
                        }
                        break;

                    //Jobbra nyíl
                    case ConsoleKey.RightArrow:
                        if (x < 8)
                        {
                            //Mivel minden kártya után van egy szóköz ezért kettessével növelem a pozíciókat.
                            x += 2;
                            Console.SetCursorPosition(x, y);
                        }
                        break;

                    //Balra nyíl
                    case ConsoleKey.LeftArrow:
                        if (x > 0)
                        {
                            x -= 2;
                            Console.SetCursorPosition(x, y);
                        }
                        break;

                    //Szóköz(kártya fordítása)
                    case ConsoleKey.Spacebar:
                        //Leképezem a játékterem a kartyak tömbömre, ezzel végül is felfordítom a kártyát ahol éppen állok.
                        Console.Write(kartyak[y * 5 + x / 2]);
                        Console.SetCursorPosition(x, y);

                        //Nyilvántartom a körök számát
                        kor++;
                        //Minden második kártyafordításnál vizsgálatokat kell végeznem.
                        if (kor % 2 == 0)
                        {
                            //Mielőtt bármit tennék a felfordított kártyákkal várok egy kicsit.
                            System.Threading.Thread.Sleep(2000);

                            //Ha az elsőnek és másodiknak felfordított kártya nem egyezik meg...
                            if (kartyak[y * 5 + x / 2] != kartyak[elsoKartyaYPozicioja * 5 + elsoKartyaXPozicioja / 2])
                            {
                                //...akkor visszafordítom azokat.
                                Console.Write("X");
                                Console.SetCursorPosition(elsoKartyaXPozicioja, elsoKartyaYPozicioja);
                                Console.Write("X");
                            }
                            else
                            {
                                //...vagy ha egyezik, akkor leveszem azokat a játéktérről.
                                Console.Write(" ");
                                Console.SetCursorPosition(elsoKartyaXPozicioja, elsoKartyaYPozicioja);
                                Console.Write(" ");

                                //Nyilvántartom, hogy melyik játékos talált meg egy kártyapárt.
                                if (elsoJatekos)
                                {
                                    elsoJatekosParjai++;
                                }
                                else
                                {
                                    masodikJatekosParjai++;
                                }
                            }

                            //Beállok a 3. sorba.
                            Console.SetCursorPosition(0, 3);
                            //Nyilvántartom, hogy melyik játékos lesz a következő.
                            elsoJatekos = !elsoJatekos;
                            //Ha megtaláltuk az összes párt, akkor...
                            if (elsoJatekosParjai + masodikJatekosParjai == 5)
                            {
                                //...vége a játéknak.
                                Console.Write("Vége a játéknak! Gratulálunk a " + (elsoJatekosParjai > masodikJatekosParjai ? 1 : 2) + ". játékosnak!");
                            }
                            else
                            {
                                //...ha még nem, akkor csak azt írom ki, hogy ki következik.
                                Console.Write("Az " + (elsoJatekos ? 1 : 2) + ". játékos következik.");
                            }
                            //Visszaállok oda ahonnan kiindultam, ahol az utolsó kártyalapot megfordítottam.
                            Console.SetCursorPosition(x, y);
                        }
                        //Eltárolom az elsőnek felfordított kártya pozícióját.
                        elsoKartyaXPozicioja = x;
                        elsoKartyaYPozicioja = y;
                        break;
                }
                // A játék addig tart, amíg meg nincs az összes kártya.
            } while (elsoJatekosParjai + masodikJatekosParjai < 5);

            Console.ReadLine();
        }
    }
}
