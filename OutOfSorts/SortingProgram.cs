///<summary>
///I, Andrew Evboifo, 000909727 certify that this material is my original work. No other person's work has been used without due acknowledgement.
///</summary>
using System;
using System.IO;


namespace OutOfSorts
{
    internal class SortingProgram
    {
        /// <summary>
        /// Maximum number of employees that can be stored in the array
        /// </summary>
        private const int MaxEmployees = 100;

        /// <summary>
        /// Array to hold Employee objects
        /// </summary>
        private static Employee[] employees = new Employee[MaxEmployees];


        /// <summary>
        /// Prompts the user for a choice of sorting method
        /// </summary>
        /// <returns>User's choice as an integer between 1 and 6</returns>
        public static int UserPrompt()
        {
            int userChoice;
            bool check;
            do
            {
                Console.WriteLine("Choose one option:");
                Console.WriteLine("1. Sort by Employee Name (ascending)");
                Console.WriteLine("2. Sort by Employee Number (ascending)");
                Console.WriteLine("3. Sort by Employee Pay Rate (descending)");
                Console.WriteLine("4. Sort by Employee Hours (descending)");
                Console.WriteLine("5. Sort by Employee Gross Pay (descending)");
                Console.WriteLine("6. Exit");

                string userInput = Console.ReadLine();
                check = int.TryParse(userInput, out userChoice) && userChoice >= 1 && userChoice <= 6;

                if (!check)
                {
                    Console.WriteLine("Invalid Input, please choose number within range(1-6)");
                }

            } while (!check);
            return userChoice;


        }

        /// <summary>
        /// Counter to keep track of the number of employees read from the file
        /// </summary>
        private static int count = 0;


        /// <summary>
        /// Read method that reads all employee information from employee.txt file
        /// and stores them into an array while checking for exceptions
        /// </summary>
        public static void Read()
        {
            try
            {
                string[] employeeInformation = File.ReadAllLines("employees.txt"); // reads all lines from text file
                foreach (string info in employeeInformation)
                {

                    if (count >= MaxEmployees)// ensures that record does not exceed 100
                    {
                        break;
                    }

                    string[] splitArray = info.Split(',');
                    ///<summary>
                    ///checks to make sure that the number of parts in splitArray match with our employee field 
                    /// </summary>
                    if (splitArray.Length == 4)
                    {
                        string name = splitArray[0];
                        int number = int.Parse(splitArray[1]);
                        decimal rate = decimal.Parse(splitArray[2]);
                        double hours = double.Parse(splitArray[3]);

                        // create new employee object
                        employees[count++] = new Employee(name, number, rate, hours);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }

        }

        /// <summary>
        /// Implements selection sort algorithm to sort the employees array based on the provided comparison delegate.
        /// </summary>
        /// <param name="comparison">Comparison delegate that defines the sorting criteria.</param>
        public static void Sort(Comparison<Employee> comparison)
        {
            for (int f = 0; f < count - 1; f++)
            {
                int firstIndex = f;
                for (int s = f + 1; s < count; s++)
                {
                    if (comparison(employees[s], employees[firstIndex]) < 0)
                    {
                        firstIndex = s;
                    }
                }
                if (firstIndex != f) // avoids unnecessary swaps in case where current item is already the smallest.
                {
                    Employee value = employees[f];
                    employees[f] = employees[firstIndex];
                    employees[firstIndex] = value;
                }
            }
        }

        ///<summary>
        ///Main program entry point
        /// </summary>
        public static void Main()
        {
            Read();
            int userChoice;

            do
            {
                userChoice = UserPrompt();
                switch (userChoice)
                {
                    case 1:
                        Sort((x, y) => x.GetName().CompareTo(y.GetName()));
                        Display();
                        break;

                    case 2:
                        Sort((x, y) => x.GetNumber().CompareTo(y.GetNumber()));
                        Display();
                        break;

                    case 3:
                        Sort((x, y) => y.GetRate().CompareTo(x.GetRate()));
                        Display();
                        break;

                    case 4:
                        Sort((x, y) => y.GetHours().CompareTo(x.GetHours()));
                        Display();
                        break;

                    case 5:
                        Sort((x, y) => y.GetGross().CompareTo(x.GetGross()));
                        Display();
                        break;
                }

            } while (userChoice != 6);
        }

        /// <summary>
        /// Displays all employee records tored in the employees array.
        /// </summary>
        public static void Display()
        {
            Console.WriteLine(new string('_', 100));
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(employees[i]);
            }
            Console.WriteLine(new string('_', 100));
        }
    }
}

