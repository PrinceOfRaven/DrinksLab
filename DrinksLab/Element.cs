using System;
using System.Collections.Generic;
using System.Text;

namespace DrinksLab
{
    internal interface Element
    {
        Element? Parent { get; set; }
        void PrintElement(int indent);
    }  
}
