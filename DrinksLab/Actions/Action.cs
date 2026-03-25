using System;
using System.Collections.Generic;
using System.Text;

namespace DrinksLab
{
    internal abstract class Action : Element
    {
        private readonly List<Element> _children = new();
        public Element? Parent { get; set; }
        internal IReadOnlyList<Element> Elements => _children;

        internal int IndexOf(Element element) 
        {
            return _children.IndexOf(element);
        }

        internal void AddElement(Element child)
        {
            child.Parent = this;
            _children.Add(child);
        }

        internal void AddChildAt(int index, Element child)
        {
            child.Parent = this;
            _children.Insert(index, child);
        }

        internal void RemoveChild(Element child)
        {
            _children.Remove(child);
            child.Parent = null;
        }

        internal void RemoveChildAt(int index)
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
