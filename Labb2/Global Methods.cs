using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    public class Global
    {
        public void NewScreen()
        {
            Console.Clear();
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine();
            }
        }
        public void Print(string printIt)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.CursorTop);
            Console.WriteLine(printIt);
        }

        public void Center()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.CursorTop);
        }
        public void PrintRed(string printIt)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.CursorTop);
            Console.WriteLine(printIt);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
