using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempElementsLib.Interfaces;
using TempElementsLib.src.Interfaces;

namespace TempElementsLib.src.Classes
{
    public class TempElementsList : ITempElements, IDisposable
    {
        private readonly List<ITempElement> _elements = new List<ITempElement>();
        public IReadOnlyCollection<ITempElement> Elements => _elements;

        ~TempElementsList() { Dispose(); }
        public T AddElement<T>() where T : ITempElement, new()
        {
            T element = new T();

            _elements.Add(element);

            return element;
        }



        public void Dispose()
        {
            _elements.RemoveAll((element) => { element.Dispose(); return true; });
        }



        public void MoveElementTo<T>(T element, string newPath) where T : IMovableElement
        {
            element.MoveTo(newPath);

            Console.WriteLine("Moved element to new path: {0}", newPath);
        }



        public void RemoveDestroyed() => _elements.RemoveAll((element) => element.IsDestroyed);
    }
}

