using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine($"Sum: {numbers.Sum()}");

            //TODO: Print the Average of numbers
            Console.WriteLine($"Average: {numbers.Average()}");

            //TODO: Order numbers in ascending order and print to the console

            Console.WriteLine("Ascending Order");
            var orderedNumbers = numbers.OrderBy( num => num );
            foreach ( var number in orderedNumbers ) 
            {
                Console.WriteLine( number );
            }

            //TODO: Order numbers in descending order and print to the console
            Console.WriteLine("Decending Order:");
            var orderedNumber = numbers.OrderByDescending( a => a );
            foreach (var number in orderedNumber)
            {           
                Console.WriteLine(number);
            }

            //TODO: Print to the console only the numbers greater than 6
            /////// I tried the trick you used in the lecture but did not work for me////////
            Console.WriteLine("Numbers Greater than 6");
            var numsAboveSix = numbers.Where(number => number > 6);
            foreach ( var number in numsAboveSix ) { Console.WriteLine(number); }

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Print numbers");
            foreach ( var number in numbers.OrderBy(y => y).Take(4)) 
            {
                Console.WriteLine(number);
            }

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order

            Console.WriteLine("Change the value at index 4 to your age");
            numbers.Select((number, index) => index == 4 ? 25 : number).OrderByDescending(numbers => numbers).ToList().ForEach(x => Console.WriteLine(x));


            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("Name of the employees that starts with C and S");
            var asceningEmployees = employees.Where(x => x.FirstName.StartsWith('C') || x.FirstName.StartsWith('S')).OrderBy(x => x.FirstName);

            foreach( var x in asceningEmployees) 
            {
                Console.WriteLine($"{x.FirstName} {x.LastName}");
            }

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            
            var overTwentySix = employees.Where(employee => employee.Age > 26).OrderBy(employee => employee.Age).ThenBy(employee => employee.FirstName).ThenBy(employee => employee.YearsOfExperience);

            foreach (var x in overTwentySix) 
            {
                Console.WriteLine($"Fullname: {x.FirstName} Age: {x.Age}");
            }
            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            
            var specialEmployees = employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age <= 35);
            Console.WriteLine($" The total years of experience: {specialEmployees.Sum(employee => employee.YearsOfExperience)}");

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine($"The average years of experience: {specialEmployees.Average(employee => employee.YearsOfExperience)}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("FirstName", "LastName", 25, 10)).ToList();
            foreach(var employee in employees) 
            {
                Console.WriteLine($"{employee.FirstName} {employee.Age}");
            }


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
