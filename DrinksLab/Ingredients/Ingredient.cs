using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

        internal abstract Ingredient Clone();

        public void PrintElement() 
        {
            Console.Write($"{this.GetType().Name}\n");
        }
    }
}