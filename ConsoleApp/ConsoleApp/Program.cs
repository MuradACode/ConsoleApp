using ConsoleApp.Models;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        public static void Menu()
        {
            string commands = "-----------------------------\n1: Create a library\n2: See all libraries\n3: Add book\n4: See books of library\n-----------------------------";
            Console.WriteLine("WELCOME");
        Menu:
            Console.WriteLine("\n----------------------------------------\nChoose the command\nType 0 to get information about commands\n----------------------------------------");
            string input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    Console.WriteLine(commands);
                    goto Menu;
                case "1":
                    Library.CreateLibraryFromConsole();
                    goto Menu;
                case "2":
                    Library.GetInfo();
                    goto Menu;
                case "3":
                    Book.CreateBookFromConsole();
                    Library.OwnBook();
                    goto Menu;
                case "4":
                    Library.SeeBooksOfLibrary();
                    goto Menu;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input try again!");
                    goto Menu;
            }
        }
    }
}
