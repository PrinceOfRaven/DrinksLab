using System;
using System.Collections.Generic;
using System.Text;

namespace DrinksLab
{
    internal class Water : Ingredient
    {
        internal override Water Clone()
        {
            return new Water { Mass = this.Mass };
        }
    }
}
