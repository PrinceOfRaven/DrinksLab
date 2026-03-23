using System;
using System.Collections.Generic;
using System.Text;

namespace DrinksLab
{
    internal abstract class Action : Element
    {
        protected readonly List<Element> _elements = new();

        protected bool HasIngredients
        {
            get
            {
                foreach (var e in _elements)
                {
                    if (e is Ingredient) return true;

                    if (e is Action subAction && subAction.HasIngredients) return true;
                }
                return false;
            }
        }

        internal virtual void Execute(Element element)
        {
            if (element != null)
            {
                if ((element is Action action && action.HasIngredients) || element is Ingredient)
                {
                    _elements.Add(element);
                }
            }
        }

        public void PrintElement() 
        {
            Console.Write($"{this.GetType().Name}: ");

            foreach (var element in _elements) 
            {
                Console.Write(" ");
                element.PrintElement();
            }
        }
    }
}
