using Minesweeper.Common;
using System.Collections.Generic;

namespace Minesweeper.Model.Implementation
{
    internal abstract class BaseModel<T> : IModel<T>
    {
        private readonly List<IObserver<T>> _observers = new();

        protected abstract T Model { get; }

        public void Attach(IObserver<T> observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver<T> observer)
        {
            _observers.Add(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
                observer.UpdateObserver(Model);
        }
    }
}
