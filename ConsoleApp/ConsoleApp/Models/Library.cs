using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Models
{
    public class Library : IEnumerable
    {
        private string _name;
        private string _locatedCity;
        private Book[] _book;
        public static Library[] libraries;
        public Library this[int index] 
        {
            get { return _book[index]; }
            private set { _book[index] = (Book)value; }
        }
        public Library(string plug) { }
        static Library()
        {
            libraries = new Library[0];
        }
        private Library()
        {
            _book = new Book[0];
            Array.Resize(ref libraries, libraries.Length + 1);
            libraries[^1] = this;
        }
        public Library(string name, string locatedCity) : this()
        {
            _name = name;
            _locatedCity = locatedCity;
        }
        public static void CreateLibraryFromConsole()
        {
            Console.Clear();
        TryLibraryName:
            Console.Write("Type the name of library: ");
            string name = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(name))
            {
                Console.Clear();
                Console.WriteLine("Name can't be empty!");
                goto TryLibraryName;
            }
        TryLibrarylocation:
            Console.Write("In which city located library? : ");
            string locatedCity = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(locatedCity))
            {
                Console.Clear();
                Console.WriteLine("Name can't be empty!");
                goto TryLibrarylocation;
            }
            Library library = new Library(name, locatedCity);
            Console.WriteLine("----------------------------------------\nLibrary created successfully\n----------------------------------------");
        }
        public static void GetInfo()
        {
            Console.Clear();
            if (libraries.Length is 0)
            {
                Console.WriteLine("You don't have any libraries");
            }
            foreach (var library in libraries)
            {
                Console.WriteLine($"Name: {library._name}\nLocated city: {library._locatedCity}\n");
            }
        }
        public void AddBook(Book book)
        {
            Array.Resize(ref _book, _book.Length + 1);
            _book[^1] = book;
        }
        public static void OwnBook()
        {
            Console.Clear();
            Console.WriteLine("Libraries:\n");
            if (libraries.Length is 0)
            {
                Console.WriteLine("You don't have any libraries");
            }
            foreach (var library in libraries)
            {
                Console.WriteLine(library._name);
            }
            Console.Write("Choose the library: ");
            string input = Console.ReadLine();
            int i = 0;
            foreach (var library in libraries)
            {
                if ((input == library._name))
                {
                    library.AddBook(Book.books[i]);
                    i++;
                }
            }
        }
        public static void SeeBooksOfLibrary()
        {
            Console.Clear();
            Console.WriteLine("Libraries:\n");
            if (libraries.Length is 0)
            {
                Console.WriteLine("You don't have any libraries");
            }
            foreach (var library in libraries)
            {
                Console.WriteLine(library._name);
            }
            Console.Write("Choose the library: ");
            string input = Console.ReadLine();
            foreach (var library in libraries)
            {
                if ((input == library._name))
                {
                    foreach (Book book in library)
                    {
                        Console.WriteLine(book);
                    }
                }
            }
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < libraries.Length; i++)
            {
                yield return _book[i];
            }
        }
    }
}
