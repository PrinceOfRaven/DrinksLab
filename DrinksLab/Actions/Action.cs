using System;
using System.Collections.Generic;
using System.Text;

namespace DrinksLab
{
    internal abstract class Action : Element
    {
        private readonly List<Element> _children = new();
        public Element? Parent { get; set; }

        public IReadOnlyList<Element> Elements => _children;

        public void AddChild(Element child)
        {
            child.Parent = this;
            _children.Add(child);
        }

        public void AddChildAt(int index, Element child)
        {
            child.Parent = this;
            _children.Insert(index, child);
        }

        public void RemoveChild(Element child)
        {
            _children.Remove(child);
            child.Parent = null;
        }

        public void RemoveChildAt(int index)
        {
            if (index >= 0 && index < _children.Count)
            {
                _children[index].Parent = null;
                _children.RemoveAt(index);
            }
        }

        public void Execute(Element? element) { }

        public void PrintElement()
        {
            Console.WriteLine(this.GetType().Name);

            foreach (var child in _children)
            {
                child.PrintElement();
            }
        }
    }
}
