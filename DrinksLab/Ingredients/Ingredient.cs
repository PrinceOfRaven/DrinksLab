using System;
using System.Collections.Generic;
using System.Text;

namespace DrinksLab
{
    internal abstract class Ingredient : Element
    {
        private double _mass;

        internal double Mass
        {
            get { return _mass; }
            set { _mass = value; }

        }
    }
}