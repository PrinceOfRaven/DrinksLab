using System;
using System.Collections.Generic;
using System.Text;

namespace DrinksLab
{
    internal class Syrup : Ingredient
    {
        internal override Syrup Clone()
        {
            return new Syrup { Mass = this.Mass };
        }
    }
}
