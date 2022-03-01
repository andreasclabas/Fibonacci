//
// Author: Andrea Sclabas
// Date  : 01/03/2022 
//
// Task: Write a c# program to print Fibonacci series without using recursion and using recursion.

namespace Fibonacci
{
    class FibonacciPrint
    {
        /// <summary>
        /// Entry point of the program
        /// </summary>
        private static void Main()
        {
            int FibonacciNumbers;
            int FibonacciMethod;
            bool firstCycle = true;
            string? input;

            do
            {
                // Error message visible only from the second cycle
                if (!firstCycle)
                {
                    Console.WriteLine("Invalid number! Retry or digit EXIT to close.");
                }

                // Ask how many numbers print
                Console.Write("Number of items: ");
                input = Console.ReadLine();

                // Exit condition
                if (input == "EXIT")
                    return;

                firstCycle = false;

                // Exit if a valid number has been provided
            } while (!int.TryParse(input, out FibonacciNumbers));

            // Reset variable
            firstCycle = true;

            do
            {
                // Error message visible only from the second cycle
                if (!firstCycle)
                {
                    Console.WriteLine("Invalid choice! Retry or digit EXIT to close.");
                }

                Console.WriteLine("");
                Console.WriteLine("Choose which method do you prefer:");
                Console.WriteLine("1. Non Recursive");
                Console.WriteLine("2. Recursive");

                // Ask for selection
                Console.Write("Selection: ");
                input = Console.ReadLine();

                // Exit condition
                if (input == "EXIT")
                    return;

                firstCycle = false;

                // Exit if a valid choice has been provided
            } while (!int.TryParse(input, out FibonacciMethod) || (FibonacciMethod < 1) || (FibonacciMethod > 2));

            Console.WriteLine($"Ok! Will be printed {FibonacciNumbers} numbers using method {FibonacciMethod}.");

            Console.Write("Output: ");

            switch (FibonacciMethod)
            {
                case 1:
                    NonRecursive_Fibonacci(FibonacciNumbers);
                    break;
                case 2:
                    Recursive_Fibonacci(1, FibonacciNumbers, 0, 1);
                    break;
                default:
                    break;
            }

            Console.WriteLine("");
            
            return;
        }

        /// <summary>
        /// Fibonacci series printer using the non-recursive method
        /// </summary>
        /// <param name="items">Number of items to print</param>
        static void NonRecursive_Fibonacci(int items)
        {
            int num1 = 0;
            int num2 = 1;
            int num3;

            for (int i = 1; i <= items; i++)
            {
                if (i == 1)
                {
                    Console.Write($" {num1}");
                }
                else if (i == 2)
                {
                    Console.Write($" {num2}");
                }
                else
                {
                    Console.Write($" {num3 = num1 + num2}");

                    num1 = num2;
                    num2 = num3;
                }
            }

            return;
        }

        /// <summary>
        /// Fibonacci series printer using the recursive method
        /// </summary>
        /// <param name="iter">Iteration number</param>
        /// <param name="items">Number of items to print</param>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        static void Recursive_Fibonacci(int iter, int items, int num1, int num2)
        {
            int num3;

            // Stop recursion condition
            if (iter > items) return;

            if (iter == 1)
            {
                Console.Write($" {num1}");
                Recursive_Fibonacci(++iter, items, 0, 1);
            }
            else if (iter == 2)
            {
                Console.Write($" {num2}");
                Recursive_Fibonacci(++iter, items, 0, 1);
            }
            else
            {
                Console.Write($" {num3 = num1 + num2}");

                Recursive_Fibonacci(++iter, items, num2, num3);
            }
        }
    }
}