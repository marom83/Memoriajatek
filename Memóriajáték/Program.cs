using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memóriajáték
{
    class Program
    {
        const int kartyakSzama = 10;
        static void Main(string[] args)
        {

            //Console.WriteLine("Memóriajáték\n");

            int[] kartyak = new int[] { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4};

            Random rnd = new Random();

            int x = 0, y = 0;

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
                        break;
                }
            } while (true);

            Console.ReadLine();
        }
    }
}
