using System;
using System.Collections.Generic;
using System.Text;

namespace DrinksLab
{
    internal class CoffeBean : Ingredient
    {
        internal override CoffeBean Clone()
        {
            return new CoffeBean { Mass = this.Mass };
        }
    }
}
