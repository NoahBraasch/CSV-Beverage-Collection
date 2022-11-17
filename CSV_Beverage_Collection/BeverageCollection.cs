// Written By: Noah Braasch
// September 26 2022

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Beverage_Collection
{
    class BeverageCollection
    {
        // Property?
        int currentSize = 0;
        Beverage[] beverages = new Beverage[4000];
        // Attributes
        // Methods
        /// <summary>
        /// Converts the collection of beverages to a string and prints
        /// </summary>
        /// <returns>the output string</returns>
        public override string ToString()
        {
            string outputString = "";
            foreach (Beverage beverage in beverages)
            {
                if (beverage != null) 
                {
                    outputString += beverage.ToString() + Environment.NewLine;
                }
            }
            return outputString;
        }
        /// <summary>
        /// Adds a beverage object to the array 
        /// </summary>
        /// <param name="beverage"></param>
        public void Add(Beverage beverage)
        {
            beverages[currentSize++] = beverage;
        }
        
        /// <summary>
        /// Performs the linear search function on the colelction
        /// </summary>
        /// <param name="query"></param>
        /// <returns>the beverage found</returns>
        public Beverage Search(string query) 
        {
            int index = 0;
            foreach (Beverage beverage in beverages) 
            {
                if (beverages[index] != null)
                {
                    if (beverages[index].GetID() == query)
                    {
                        return beverage;
                    }

                }
                ++index;
            }
            return null;
        }
        /// <summary>
        /// Clears the beverage array for importing from csv
        /// </summary>
        public void Clear() 
        {
            int index = 0;
            foreach (Beverage beverage in beverages) 
            {
                beverages[index] = null;
                ++index;
            }
        }
    }
}
