using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new DiskBook("Guilherme's Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter is {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            do
            {
                Console.WriteLine("Type a grade: ");
                var input = Console.ReadLine();
                if (input == "Q" || input == "q") break;

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);
        }      

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("A grade is ADDED");
        }
    }
}
