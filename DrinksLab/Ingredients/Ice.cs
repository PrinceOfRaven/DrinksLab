using System;
using System.Collections.Generic;
using System.Text;

namespace DrinksLab
{
    internal class Ice : Ingredient
    {
        internal override Ice Clone()
        {
            return new Ice { Mass = this.Mass };
        }
    }
}
