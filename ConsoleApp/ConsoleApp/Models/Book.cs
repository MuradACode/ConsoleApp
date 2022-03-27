using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Models
{
    public class Book : Library
    {
        private string _name;
        private int _publishYear;
        public static Book[] books;
        public Person author;
        public string Name { get { return _name; } set { } }
        public int PublishYear { get { return _publishYear; } set { if (PublishYear > 0 && PublishYear < 2023) _publishYear = value; } }
        static Book()
        {
            books = new Book[0];
        }
        public Book(string name, int publishYear, Person author) : base("")
        {
            Name = name;
            PublishYear = publishYear;
            this.author = author;
            books = new Book[0];
            Array.Resize(ref books, books.Length + 1);
            books[^1] = this;
        }
        public static void CreateBookFromConsole()
        {
            Console.Clear();
        TryBookName:
            Console.Write("Type the name of the book: ");
            string bookName = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(bookName))
            {
                Console.Clear();
                Console.WriteLine("Name can't be empty!");
                goto TryBookName;
            }
        TryPublishYear:
            Console.Write("What year was this book published? : ");
            int publishYear;
            try
            {
                publishYear = Convert.ToInt32(Console.ReadLine().Trim());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input try again!");
                goto TryPublishYear;
            }
        TryName:
            Console.Write("\nType the author's name: ");
            string name = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(name))
            {
                Console.Clear();
                Console.WriteLine("Name can't be empty!");
                goto TryName;
            }
        TrySurname:
            Console.Write("Type the author's surname: ");
            string surname = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(surname))
            {
                Console.Clear();
                Console.WriteLine("Surname can't be empty!");
                goto TrySurname;
            }
        TryAge:
            Console.Write("Type the author's age: ");
            int age;
            try
            {
                age = Convert.ToInt32(Console.ReadLine().Trim());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input try again!");
                goto TryAge;
            }
            Person person = new Person(name, surname, age);
            Book book = new Book(bookName, publishYear, person);
            Console.WriteLine("----------------------------------------\nBook created successfully\n----------------------------------------");
        }
        public string GetBookInfo(int index)
        {
            return "Book's name: " + books[index]._name + "\nPublish year: " + books[index]._publishYear + "\nAuthor:\n" + Person.GetPersonInfo(author); 
        }
    }
}
