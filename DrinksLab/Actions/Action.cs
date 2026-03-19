using System;
using System.Collections.Generic;
using System.Text;

namespace DrinksLab
{
    internal abstract class Action : Element
    {
        internal virtual void Execute() { }
    }
}
