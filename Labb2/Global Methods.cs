using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2;

public class Global
{
    //Cleara skärmen och hoppa ner lite
    public void NewScreen()
    {
        Console.Clear();
        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine();
        }
    }

    // centrera och printa
    public void Print(string printIt)
    {
        Console.SetCursorPosition((Console.WindowWidth - printIt.Length)/ 2, Console.CursorTop); 
        Console.WriteLine(printIt);
    }

    //centrera innan 
    public void Center()
    {
        Console.SetCursorPosition(Console.WindowWidth / 2, Console.CursorTop);
    }
    //centrera och printa i rött
    public void PrintRed(string printIt)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.SetCursorPosition((Console.WindowWidth - printIt.Length) / 2, Console.CursorTop);
        Console.WriteLine(printIt);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    //pixelkost banner
    public void PrintBanner()
    {

        int[] row1 = new int[]{ 1 ,2 , 3,  6 , 9  ,11  ,12,  13 ,14, 21, 22 ,23, 24 
            ,26 , 29,  31 ,32  ,33 , 34 , 36 , 37,  38, 39 };
        int[] row2 = new int[] { 2, 6, 7, 8, 9, 11, 12, 13, 21, 22, 26, 27, 28, 29, 31, 34, 36, 39 };
        int[] row3 = new int[] { 2, 6, 9, 11, 23, 24, 26, 29, 31, 34, 36, 37, 38, 39 };
        int[] row4 = new int[] { 2, 6, 9, 11, 12, 13, 14, 21, 22, 23, 24, 26, 29, 31, 32, 33, 34, 36 };
        Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.CursorTop);
        for (int i = 1; i < 40; i++)
        {
            if (row1.Contains(i))
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write(' ');
                Console.ResetColor();
            }
            else
            {
                Console.Write(' ');
            }
        }
        
        Console.WriteLine("");
        Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.CursorTop);
        for (int i = 1; i < 40; i++)
        {
            if (row2.Contains(i))
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write(' ');
                Console.ResetColor();
            } else
            {
                Console.Write(' ');
            }
        }

        Console.WriteLine("");
        Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.CursorTop);
        for (int i = 1; i < 40; i++)
        {
            if (row3.Contains(i))
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write(' ');
                Console.ResetColor();
            }
            else
            {
                Console.Write(' ');
            }
        }

        Console.WriteLine("");
        Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.CursorTop);
        for (int i = 1; i < 40; i++)
        {
            if (row4.Contains(i))
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write(' ');
                Console.ResetColor();
            }
            else
            {
                Console.Write(' ');
            }
        }

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("");
        }

    }

    
}