using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memóriajáték
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Console.WriteLine("Memóriajáték\n");

            int[] kartyak = new int[] { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4};

            const int kartyakSzama = 10;
            Random rnd = new Random();

            for (int i = 0; i < kartyakSzama; i++)
            {
                // Random for remaining positions.
                int r = i + rnd.Next(kartyakSzama - i);

                //swapping the elements
                int tarolo = kartyak[r];
                kartyak[r] = kartyak[i];
                kartyak[i] = tarolo;

                if (kartyakSzama / 2 - 1 == i)
                {
                    Console.WriteLine("X");
                }
                else
                {
                    Console.Write("X ");
                }
            }

            int x = 0;
            int y = 0;
            int kor = 0;
            int elsoKartyaXPozicioja = 0;
            int elsoKartyaYPozicioja = 0;
            bool elsoJatekos = true;
            int elsoJatekosParjai = 0;
            int masodikJatekosParjai = 0;

            Console.SetCursorPosition(0, 3);
            Console.Write("Az 1. játékos következik.");
            Console.SetCursorPosition(0, 0);

            do
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (y > 0) {
                            y--;
                            Console.SetCursorPosition(x, y);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (y < 1)
                        {
                            y++;
                            Console.SetCursorPosition(x, y);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (x < 8)
                        {
                            x+=2;
                            Console.SetCursorPosition(x, y);
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (x > 0)
                        {
                            x-=2;
                            Console.SetCursorPosition(x, y);
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        Console.Write(kartyak[y * 5 + x / 2]);
                        Console.SetCursorPosition(x, y);
                        kor++;
                        if (kor % 2 == 0)
                        {
                            System.Threading.Thread.Sleep(2000);

                            if (kartyak[y * 5 + x / 2] != kartyak[elsoKartyaYPozicioja * 5 + elsoKartyaXPozicioja / 2])
                            {
                                Console.Write("X");
                                Console.SetCursorPosition(elsoKartyaXPozicioja, elsoKartyaYPozicioja);
                                Console.Write("X");
                            } else
                            {
                                Console.Write(" ");
                                Console.SetCursorPosition(elsoKartyaXPozicioja, elsoKartyaYPozicioja);
                                Console.Write(" ");
                                if (elsoJatekos) { 
                                    elsoJatekosParjai++; 
                                } else
                                {
                                    masodikJatekosParjai++;
                                }
                                
                            }
                            Console.SetCursorPosition(x, y);

                            Console.SetCursorPosition(0, 3);
                            elsoJatekos = !elsoJatekos;
                            if (elsoJatekosParjai + masodikJatekosParjai == 5)
                            {
                                Console.Write("Vége a játéknak! Gratulálunk a " + (elsoJatekosParjai > masodikJatekosParjai ? 1 : 2) + ". játékosnak!");
                            }
                            else
                            {
                                Console.Write("Az " + (elsoJatekos ? 1 : 2) + ". játékos következik.");
                            }
                            Console.SetCursorPosition(x, y);
                        }
                        elsoKartyaXPozicioja = x;
                        elsoKartyaYPozicioja = y;
                        break;
                }
            } while (elsoJatekosParjai + masodikJatekosParjai < 5);

           

            Console.ReadLine();
        }
    }
}
