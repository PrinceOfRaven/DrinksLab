using System;
using System.Collections.Generic;
using System.Text;

namespace DrinksLab
{
    internal static class Storage
    {
        internal static List<Ingredient> Store { get; } = new()
        {
            new Milk {Mass = 200},
            new Water {Mass = 100},
            new Syrup {Mass = 150},
            new Ice {Mass = 50},
            new CoffeBean {Mass = 120},
        };

        internal static Ingredient GetIngredient(int index) 
        {
               return Store[index].Clone(); 
        }

        internal static void PrintIngredients() 
        {
            Console.WriteLine("\nДоступные ингредиенты:");
            for (int i = 0; i < Store.Count; i++) 
            {
                Console.Write($"{i + 1}. ");
                Store[i].PrintElement(0);
            }
        }

    }
}
