using System;
using System.Text.RegularExpressions;

namespace StudentExceptionDemo
{
    // Custom Exception for Negative Marks
    class NegativeNumberException : Exception
    {
        public NegativeNumberException(string message) : base(message) { }
    }

    // Person Class
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || !Regex.IsMatch(firstName, "^[A-Za-z]+$"))
                throw new Exception("Invalid First Name. Only alphabets allowed and cannot be empty.");

            if (string.IsNullOrWhiteSpace(lastName) || !Regex.IsMatch(lastName, "^[A-Za-z]+$"))
                throw new Exception("Invalid Last Name. Only alphabets allowed and cannot be empty.");

            FirstName = firstName;
            LastName = lastName;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine();

                Console.Write("Enter Last Name: ");
                string lastName = Console.ReadLine();

                Person p = new Person(firstName, lastName);

                int[] marks = new int[3];

                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"Enter mark {i + 1}: ");
                    string input = Console.ReadLine();

                    int value = int.Parse(input);   // FormatException handled here

                    if (value < 0)
                        throw new NegativeNumberException("Marks cannot be negative.");

                    marks[i] = value;
                }

                Console.WriteLine("\nStudent Details:");
                Console.WriteLine($"Name: {p.FirstName} {p.LastName}");
                Console.WriteLine($"Marks: {marks[0]}, {marks[1]}, {marks[2]}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter only integer values for marks.");
            }
            catch (NegativeNumberException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
