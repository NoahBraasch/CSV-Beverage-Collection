// Written By: Noah Braasch
// September 26 2022

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSV_Beverage_Collection
{
    static class CSVProcessor
    {
        // No vars
        // Properties
        // No constructors

        // Methods
        /// <summary>
        /// Imports a csv from file to the beverage collection
        /// </summary>
        /// <param name="pathToCSVFile"></param>
        /// <param name="beverages"></param>
        /// <returns>true or fale based on the success of the operation</returns>
        public static bool ImportCSV(string pathToCSVFile, BeverageCollection beverages) 
        {
            StreamReader streamReader = null;
            try
            {
                string line;

                streamReader = new StreamReader(pathToCSVFile);

                int counter = 1;

                while ((line = streamReader.ReadLine()) != null)
                {
                    ProcessLine(line, beverages, ++counter);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine();
                Console.WriteLine(e.StackTrace);

                return false;
            }
            finally 
            {
                if (streamReader != null) 
                {
                    streamReader.Close();
                }
            }
        }
        /// <summary>
        /// Parses the lines gathered from the stream reader into parameters that can be placed into beverage objects
        /// </summary>
        /// <param name="line"></param>
        /// <param name="beverages"></param>
        /// <param name="index"></param>
        private static void ProcessLine(string line, BeverageCollection beverages, int index) 
        {
            string[] parts = line.Split(',');

            string id = parts[0];
            string name = parts[1];
            string pack = parts[2];
            decimal price = decimal.Parse(parts[3]);
            bool active = bool.Parse(parts[4]);

            beverages.Add(new Beverage(id, name, pack, price, active));
        }
    }
}
