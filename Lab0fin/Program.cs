using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Security.Permissions;


namespace Lab0
{
    internal class Program
    {

        static void Main(string[] args)

        {
            double low, high;

            while (true)
            {
                Console.WriteLine("Input lower number:");
                if (double.TryParse(Console.ReadLine(), out low) && inputCheck(low))
                    break;
                else
                    Console.WriteLine("Invalid input, please enter a valid number.");
            }

            while(true)
            {
                Console.WriteLine("Input higher number;");
                if (double.TryParse(Console.ReadLine(), out high) && inputCheck(high))
                    break;
                else
                    Console.WriteLine("Invalid input, please enter a valid number");
            }

            double difference = high - low;

            Console.WriteLine("The difference between high and low is" + difference);






            while (low <= 0)
            {
                Console.WriteLine("Enter low number again");
                low = Convert.ToDouble(Console.ReadLine());

            }

            while (high < low)
            {
                Console.WriteLine("Enter high number again");
                high = Convert.ToDouble(Console.ReadLine());
            }
            List<double> numbersList = new List<double>();

            for (double i = low + 1; i <= high - 1; i++)
            {
                numbersList.Add(i);
            }

            String filepath = @"C:\Users\Ultam\source\repos\Lab0fin\Lab0fin\numbers.txt";
            Console.WriteLine("Prime numbers are:");
            foreach (double num in numbersList)
            {
                if (checkPrime(num))
                {
                    Console.WriteLine(num);
                }
            }
            numbersList.Reverse();
            string numbersString = string.Join("\n", numbersList);
            File.WriteAllText(filepath, numbersString);
            List<double> lines = File.ReadAllLines(filepath)
                                 .Select(double.Parse)
                                 .ToList();
            double total = 0;

            foreach (double line in lines)
            {
                total = total + line;
            }
            Console.WriteLine(total);

            Console.ReadLine();



        }


        static bool inputCheck(object value)
        {
            if (value == null)
                return false;


            Type valueType = value.GetType();
            return valueType == typeof(int) || valueType == typeof(double);

        }






        static bool checkPrime(double num)
        {
            if (num <= 1)
            {
                return false;
            }

            else if (num == 2)
            {
                return true;
            }
            for (int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;

        }

    }
}