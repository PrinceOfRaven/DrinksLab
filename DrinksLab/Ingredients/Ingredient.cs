using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DrinksLab
{
    internal abstract class Ingredient : Element
    {
        private double _mass;
        public Element? Parent { get; set; }

        internal double Mass
        {
            get { return _mass; }
            set { _mass = value; }
        }

        internal abstract Ingredient Clone();

        public void PrintElement(int indent) 
        {
            string output = "";
            for (int i = 0; i < indent; i++) 
            {
                output += " ";
            }

            output += $"{this.GetType().Name}";
            Console.WriteLine(output);
        }
    }
}