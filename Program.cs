using System;
using System.Threading;
namespace Lab05
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = ReadNum();
            string factorial = CalculateFactorial(input);
            FadeText(factorial);
        }
        static int ReadNum()
        {
            int num;
            string input = Console.ReadLine();
            bool result = int.TryParse(input, out num);
            if (!result)
            {
                Console.WriteLine("Это не число");
                Console.ReadKey();
                Environment.Exit(0);
            }
           
            if (num < 0)
            {
                Console.WriteLine("Невозможно найти факториал от отрицательного числа.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            return num;
        }
        static string CalculateFactorial (int num)
        {
            int factorial = 1;
            if (num != 0)
            {
                for (int i = 1; i <= num; i++)
                    factorial *= i;
            }
            string fact = factorial.ToString();
            return fact;
        }
        static void Output(string factorial)
        {
            int num = factorial.Length;
            num += 2; // увеличиваем num на 2 для отсупов

            WriteBoxLine(num, '╔', '═', '╗');
            WriteBoxLine(num, '║', ' ', '║');
            WriteBoxLine(num, '║', ' ', '║', factorial);
            WriteBoxLine(num, '║', ' ', '║');
            WriteBoxLine(num, '╚', '═', '╝');
        }
        static void WriteBoxLine(int num, char beginSym, char indentSym, char endSym)
        {
            Console.Write(beginSym);
            for (int i = 0; i < num; i++)
                Console.Write(indentSym);
            Console.WriteLine(endSym);
        }

        static void WriteBoxLine(int num, char beginSym, char indentSym, char endSym, string str)
        {
            Console.Write(beginSym);
            Console.Write(indentSym);
            Console.Write(str);
            int spaceNum = num - str.Length - 1;
            for (int i = 0; i < spaceNum; i++)
                Console.Write(indentSym);

            Console.WriteLine(endSym);
        }
        static void FadeText(string factorial)
        {
            int time = 150;
            do
            {
                do
                {
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Output(factorial);
                    Thread.Sleep(time);

                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Output(factorial);
                    Thread.Sleep(time);

                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Output(factorial);
                    Thread.Sleep(time);

                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Output(factorial);
                    Thread.Sleep(time);

                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Output(factorial);
                    Thread.Sleep(time);
                    
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Output(factorial);
                    Thread.Sleep(time);

                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Output(factorial);
                    Thread.Sleep(time);
                } while (!Console.KeyAvailable);

                //обработка события нажатия на клавишу
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            

            
        }
    }
}
