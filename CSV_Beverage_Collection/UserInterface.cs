// Written By: Noah Braasch
// September 26 2022

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Beverage_Collection
{
    /// <summary>
    /// Service class that encapsulates all console input and output
    /// </summary>
    static class UserInterface
    {
        /// <summary>
        /// gets and validates user input
        /// </summary>
        /// <returns>
        /// Returns input converted to integer
        /// </returns>
        public static int GetUserInput() 
        {
            PrintMenu();
            string input = Console.ReadLine();
            // Is there a more elegant way to implement this? Yeah probably just do a switch where the default case doesnt have a break out of the while
            while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5" && input != "6")
            {
                PrintErrorMessage();
                PrintMenu();
                input = Console.ReadLine();
            }
            return Int32.Parse(input);
        }

        /// <summary>
        /// Prints the menu for the user to select an option from
        /// </summary>
        private static void PrintMenu()
        {
            Console.WriteLine("1. Load File");
            Console.WriteLine("2. Print List");
            Console.WriteLine("3. Search List");
            Console.WriteLine("4. Add New Beverage");
            Console.WriteLine("5. Clear Window");
            Console.WriteLine("6. Exit");
        }
        /// <summary>
        /// Prints the entire collection, prints a message if there are no beverages in the collection
        /// </summary>
        /// <param name="collection"></param>
        public static void PrintList(BeverageCollection collection) 
        {
            if (collection.ToString() != "")
            {
                Console.WriteLine(collection.ToString());
            }
            else 
            {
                Console.WriteLine("Hmm theres nothing here.");
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Takes input from the user, validates for validity, responds with a message if the input field is empty for clarity, adds all fields to a new beverage and adds said beverage to the collection
        /// </summary>
        /// <param name="collection"></param>
        public static void AddBeverage(BeverageCollection collection) 
        {
            Console.WriteLine("Please Enter a valid beverage ID: ");
            string id = Console.ReadLine();
            if (id == "")
                Console.WriteLine("No data entered, moving to next field");
            Console.WriteLine();

            while (collection.Search(id) != null)
            {
                Console.WriteLine("Error: Please enter a unique beverage ID, that one is already taken.");
                id = Console.ReadLine();
            }

            Console.WriteLine("Please Enter a beverage name: ");
            string name = Console.ReadLine();
            if (name == "")
                Console.WriteLine("No data entered, moving to next field");
            Console.WriteLine();

            Console.WriteLine("Please Enter a beverage pack quanitity: ");
            string pack = Console.ReadLine();
            if (pack == "")
                Console.WriteLine("No data entered, moving to next field");
            Console.WriteLine();

            Console.WriteLine("Please Enter a valid beverage price: ");
            decimal price = 0.0m;
            // Is this bad practice?
            while (true)
            {
                try
                {
                    price = Decimal.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    /*
                    Console.WriteLine(e.ToString());
                    Console.WriteLine();
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine();
                    */
                    Console.WriteLine("Error: Please Enter a valid beverage price: ");
                    continue;
                }
                break;
            }

            Console.WriteLine("Is the beverage active? Y/N: ");
            bool active = true;
            while (true)
            {
                string response = Console.ReadLine();
                if (response == "y" || response == "Y")
                {
                    active = true;
                    break;
                }
                else if (response == "n" || response == "N")
                {
                    active = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Please enter Y/N");
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            collection.Add(new Beverage(id, name, pack, price, active));
            
        }
        /// <summary>
        /// Calls for the collection search function and prints the results on screen, prints a message if nothing was found.
        /// </summary>
        /// <param name="collection"></param>
        public static void Search(BeverageCollection collection) 
        {
            Beverage enteredBeverage;
            Console.WriteLine("Enter a beverage ID to search for:");
            if ((enteredBeverage = collection.Search(Console.ReadLine())) == null)
            {
                Console.WriteLine("Nothing was found for that ID.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(enteredBeverage.ToString());
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Acts as a warning double check for clearing the collection before loading the new lsit from the csv.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns>true or false indicating if the list was cleared or not</returns>
        public static bool ClearWarning(BeverageCollection collection) 
        {
            Console.WriteLine("WARNING: This will clear all data from the current list. Proceed? Y/N");
            while (true)
            {
                string response = Console.ReadLine();
                if (response == "y" || response == "Y")
                {
                    collection.Clear();
                    return true;
                }
                else if (response == "n" || response == "N")
                {
                    Console.WriteLine("Action aborted.");
                    Console.WriteLine();
                    return false;
                }
                else
                {
                    Console.WriteLine("Error: Please enter Y/N");
                    Console.WriteLine();
                }
            }
        }
        /// <summary>
        /// Prints load complete
        /// </summary>
        public static void PrintLoadComplete() 
        {
            Console.WriteLine("Load Complete.");
            Console.WriteLine();
        }
        /// <summary>
        /// Prints load failed
        /// </summary>
        public static void PrintLoadFailed() 
        {
            Console.WriteLine("Error: File already loaded.");
            Console.WriteLine();
        }
        /// <summary>
        /// Prints invalid input error message
        /// </summary>
        private static void PrintErrorMessage()
        {
            Console.WriteLine("This is not valid input");
            Console.WriteLine("Please enter a valid option");
            Console.WriteLine();
        }
    }
}
