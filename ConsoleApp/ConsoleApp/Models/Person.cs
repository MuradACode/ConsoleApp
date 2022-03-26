using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Models
{
    public class Person
    {
        private string _name;
        private string _surname;
        private int _age;
        public static Person[] people;
        public string Name { get { return _name; } set { } }
        public string Surname { get { return _surname; } set { } }
        public int Age { get { return _age; } set { if (Age > 0 && Age < 150) _age = value; } }
        static Person()
        {
            people = new Person[0];
        }
        private Person()
        {
            Array.Resize(ref people, people.Length + 1);
            people[^1] = this;
        }
        public Person(string name, string surname, int age) : this()
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
        public static void CreatePersonFromConsole()
        {
            Console.Clear();
        TryName:
            Console.Write("Type the name: ");
            string name = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(name))
            {
                Console.Clear();
                Console.WriteLine("Name can't be empty!");
                goto TryName;
            }
        TrySurname:
            Console.Write("Type the surname: ");
            string surname = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(surname))
            {
                Console.Clear();
                Console.WriteLine("Surname can't be empty!");
                goto TrySurname;
            }
        TryAge:
            Console.Write("Type the age: ");
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
            Console.WriteLine("----------------------------------------\nPerson created successfully\n----------------------------------------");
        }
    }
}
