using System;
using System.Collections.Generic;
using System.Text;

namespace DrinksLab
{
    internal abstract class Action : Element
    {
        private readonly List<Element> _elements = new();
        public Element? Parent { get; set; }
        internal IReadOnlyList<Element> Elements => _elements;

        internal int IndexOf(Element element) 
        {
            return _elements.IndexOf(element);
        }

        internal void AddElement(Element child)
        {
            child.Parent = this;
            _elements.Add(child);
        }

        internal void AddChildAt(int index, Element child)
        {
            child.Parent = this;
            _elements.Insert(index, child);
        }

        internal void RemoveChildAt(int index)
        {
            if (index >= 0 && index < _elements.Count)
            {
                _elements[index].Parent = null;
                _elements.RemoveAt(index);
            }
        }

        internal void Execute(Element element)
        {
            element.Parent = this;
            _elements.Add(element);
        }

        public void PrintElement(int indent)
        {
            string output = "";
            for (int i = 0; i < indent; i++)
            {
                output += " ";
            }
            output += $"{this.GetType().Name}";
            Console.WriteLine(output);

            for (int i = 0; i < _elements.Count; i++)
            {
                _elements[i].PrintElement(indent + 3);
            }
        }
    }
}
