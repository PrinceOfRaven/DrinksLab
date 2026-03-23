using DrinksLab;
using System;
using System.Collections.Generic;
using System.Reflection;



public class Drink
{
    private readonly List<Element> _drinkElements = new();
    private Element _currentElement = null;

    private void Print()
    {
        Console.WriteLine("=== НАПИТОК ===");
        if (_drinkElements.Count == 0)
        {
            Console.WriteLine("Состав: Ничего не добавлено");
        }
        else
        {
            Console.WriteLine("Текущий состав:");
            for (int i = 0; i < _drinkElements.Count; i++)
            {
                Console.Write($"{i+1}. ");
                _drinkElements[i].PrintElement();
            }
        }

        if (_currentElement != null) 
        {
            Console.WriteLine("\nТекущий настраиваемый элемент:");
            _currentElement.PrintElement();
        }

        
    }

    private void ApplyAction(string choice)
    {
        DrinksLab.Action action = null;

        switch (choice)
        {
            case "1":
                Storage.PrintIngredients();
                Console.Write("Выберите ингредиент: ");
                int idx = int.Parse(Console.ReadLine());

                Element selected = Storage.GetIngredient(idx - 1);
                action = new Adding();
                action.Execute(selected);
                _currentElement = action;
                return;
            case "2": action = new Boiling(); break;
            case "3": action = new Grinding(); break;
            case "4": action = new Mixing(); break;
            case "5": action = new Pouring(); break;
            case "6": action = new Whipping(); break;
        }

        if (action != null)
        {
            action.Execute(_currentElement);
            _currentElement = action;
        }
    }

    private void CommitToDrink()
    {
        if (_currentElement != null)
        {
            _drinkElements.Add(_currentElement);
            _currentElement = null; 
            Console.WriteLine("состав напитка обновлён");
        }
    }

    public void DrinkManager()
    {
        bool editing = true;
        while (editing)
        {
            Console.Clear();
            Print();

            Console.WriteLine("\nВозможные действия:");
            if (_currentElement == null)Console.WriteLine("1. Выбрать новый ингредиент");
            else 
            {
                Console.WriteLine("2. Вскипятить ингрдеиент");
                Console.WriteLine("3. Перемолоть ингредиент");
                Console.WriteLine("4. Перемешать ингредиент");
                Console.WriteLine("5. Пролить ингредиент");
                Console.WriteLine("6. Взбить ингрдеиент");
                Console.WriteLine("7. Завершить настройку ингредиента");
            }
            
            Console.WriteLine("0. Закончить и выйти");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine()?.Trim() ?? "";

            switch (choice)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                    ApplyAction(choice);
                    break;
                case "7":
                    CommitToDrink();
                    break;
                case "0":
                    editing = false;
                    break;
            }
        }
    }
}