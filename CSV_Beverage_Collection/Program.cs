// Written By: Noah Braasch
// September 26 2022

using System;

namespace CSV_Beverage_Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            bool terminate = false;
            bool fileLoaded = false;
            string pathToCSV = "../../../../datafiles/beverage_list.csv";
            BeverageCollection collection = new BeverageCollection();

            //Program loop checking which menu option was selected
            while (terminate != true)
            {
                switch (UserInterface.GetUserInput())
                {
                    case 1:
                        if (UserInterface.ClearWarning(collection) == true)
                        {
                            if (fileLoaded == false)
                            {
                                CSVProcessor.ImportCSV(pathToCSV, collection);
                                UserInterface.PrintLoadComplete();
                                fileLoaded = true;
                            }
                            else 
                            {
                                UserInterface.PrintLoadFailed();
                            }
                        }
                            break;
                    case 2:
                        UserInterface.PrintList(collection);
                        break;
                    case 3:
                        UserInterface.Search(collection);
                        break;
                    case 4:
                        UserInterface.AddBeverage(collection);
                        break;
                    case 5:
                        Console.Clear();
                        break;
                    case 6:
                        terminate = true;
                        break;
                }
            }
        }
    }
}
