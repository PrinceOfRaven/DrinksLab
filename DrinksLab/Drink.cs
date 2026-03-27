using DrinksLab;
using System;
using System.Collections.Generic;
public class Drink
{
    private readonly Element _root;
    private Element? _currentElement;
    private DrinksLab.Action? _currentAction;  

    public Drink()
    {
        _root = new Adding();
        _currentElement = _root;
        _currentAction = _root as DrinksLab.Action;
    }

    public void DrinkManager()
    {
        bool worked = true;
        while (worked)
        {
            Console.Clear();
            PrintCurrentPath();
            PrintCurrentChildren();

            Console.WriteLine("1. Навигация по дереву");
            Console.WriteLine("2. Добавить узел");
            Console.WriteLine("3. Заменить текущий узел");
            Console.WriteLine("4. Показать всё дерево");
            Console.WriteLine("5. Завершить");
            Console.Write("Выберите действие: ");

            switch (Console.ReadLine())
            {
                case "1": WalkOnRecipe(); break;
                case "2": AddNode(); break;
                case "3": ReplaceNode(); break;
                case "4": _root.PrintElement(0); WaitForInput(); break;
                case "5": worked = false; break;
            }
        }
    }

    private Element? SelectElement(string title)
    {
        Console.WriteLine($"\n{title}");
        Console.WriteLine("1. Ингредиент");
        Console.WriteLine("2. Действие");
        Console.Write("Выберите действие: ");

        return Console.ReadLine() switch
        {
            "1" => SelectIngredient(),
            "2" => SelectAction(),
            _ => null
        };
    }

    private Element? SelectIngredient()
    {
        Storage.PrintIngredients();
        Console.Write("Выберите ингредиент: ");
        if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0)
        {
            return Storage.GetIngredient(idx - 1);
        }
        return null;
    }

    private Element? SelectAction()
    {
        Console.WriteLine("1. Вскипятить");
        Console.WriteLine("2. Перемолоть");
        Console.WriteLine("3. Перемешать");
        Console.WriteLine("4. Пролить");
        Console.WriteLine("5. Взбить");
        Console.Write("Выберите дейтсвие: ");

        return Console.ReadLine() switch
        {
            "1" => new Boiling(),
            "2" => new Grinding(),
            "3" => new Mixing(),
            "4" => new Pouring(),
            "5" => new Whipping(),
            _ => null
        };
    }

    private void AddNode()
    {
        if (_currentAction == null)
        {
            Console.WriteLine("Нельзя добавить новый элемент к этому элементу");
            WaitForInput();
            return;
        }

        Element? selected = SelectElement("Выберите тип добавляемого элемента:");
        if (selected != null)
        {
            _currentAction.Execute(selected);
            Console.WriteLine($"Добавлено: {selected.GetType().Name}");
        }
        WaitForInput();
    }


    private void ReplaceNode()
    {
        if (_currentElement == null || _currentElement == _root)
        {
            Console.WriteLine("Нельзя заменить корневой элемент");
            WaitForInput();
            return;
        }

        Element? selected = SelectElement("Выберите элемент для замены:");
        if (selected != null)
        {
            if (_currentElement is DrinksLab.Action oldAction && selected is DrinksLab.Action newAction)
            {
                foreach (var child in oldAction.Elements)
                {
                    newAction.Execute(child);
                }
            }

            if (_currentElement.Parent is DrinksLab.Action parent)
            {
                int index = parent.IndexOf(_currentElement);
                if (index >= 0)
                {
                    parent.RemoveChildAt(index);
                    parent.AddChildAt(index, selected);
                    _currentElement = selected;
                    _currentAction = selected as DrinksLab.Action;
                    Console.WriteLine($"Заменено на: {selected.GetType().Name}");
                }
            }
        }
        WaitForInput();
    }


    private void WalkOnRecipe()
    {
        bool walked = true;
        while (walked)
        {
            Console.Clear();
            PrintCurrentPath();
            PrintCurrentChildren();

            Console.WriteLine("\n1. Вверх");
            Console.WriteLine("2. Вниз");
            Console.WriteLine("3. Завершить навигацию");
            Console.Write("> ");

            switch (Console.ReadLine())
            {
                case "1":
                    if (_currentElement?.Parent != null)
                    {
                        UpdateCurrent(_currentElement.Parent);
                    }
                    else
                    {
                        Console.WriteLine("Вы уже на верхнем уровне");
                    }
                    break;

                case "2":
                    if (_currentAction != null)
                    {
                        var children = _currentAction.Elements;
                        if (children.Count > 0)
                        {
                            for (int i = 0; i < children.Count; i++)
                            {
                                Console.WriteLine($"  {i + 1}. {children[i].GetType().Name}");
                            }
                            Console.Write("Выберите номер: ");
                            if (int.TryParse(Console.ReadLine(), out int idx) &&
                                idx > 0 && idx <= children.Count)
                            {
                                UpdateCurrent(children[idx - 1]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Нет дочерних элементов");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Текущий элемент не может иметь детей");
                    }
                    break;

                case "3":
                    walked = false;
                    break;
            }
        }
    }

    private void UpdateCurrent(Element element)
    {
        _currentElement = element;
        _currentAction = element as DrinksLab.Action;
    }

    private void PrintCurrentPath()
    {
        var path = new List<string>();
        var el = _currentElement;
        while (el != null)
        {
            path.Insert(0, el.GetType().Name);
            el = el.Parent;
        }
        Console.WriteLine("Путь: " + string.Join(" -> ", path));
    }

    private void PrintCurrentChildren()
    {
        Console.Write("\nДочерние элементы:");
        if (_currentAction != null)
        {
            var children = _currentAction.Elements;
            if (children.Count == 0)
            {
                Console.Write(" (нет)\n");
                return;
            }
            Console.WriteLine();
            for (int i = 0; i < children.Count; i++)
            {
                Console.WriteLine($" {i + 1}. {children[i].GetType().Name}");
            }
            Console.WriteLine();
        }
    }

    private void WaitForInput()
    {
        Console.WriteLine("\nНажмите Enter для продолжения...");
        Console.ReadLine();
    }
}