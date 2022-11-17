// Written By: Noah Braasch
// September 26 2022

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Beverage_Collection
{
    class Beverage
    {
        // Variables
        string _id = "";
        string _name = "";
        string _pack = "";
        decimal _price = 0.0m;
        bool _active = true;

        // Properties
        // Constructors
        public Beverage(string ID, string Name, string Pack, decimal Price, bool Active) 
        {
            this._id = ID;
            this._name = Name;
            this._pack = Pack;
            this._price = Price;
            this._active = Active;
        }

        // Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// returns formatted string of objectm for easy readability
        /// </returns>
        public override string ToString()
        {
            return _id + " " + _name + " " + _pack + " " + _price + " " + _active;
        }
        /// <summary>
        /// gets the string Id for use in beverage collection search
        /// </summary>
        /// <returns>object id</returns>
        public string GetID() {
            return _id;
        }
    }
}
