using Minesweeper.Common;
using Minesweeper.View;
using System.Collections.Generic;

namespace Minesweeper.Controller.ViewModels
{
    internal abstract class BaseViewModel<TViewModel, TModel> : IViewModel<TViewModel>, IObserver<TModel>
    {
        private readonly List<IObserver<TViewModel>> _observers = new();

        protected abstract TViewModel ViewModel { get; }

        public void Attach(IObserver<TViewModel> observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver<TViewModel> observer)
        {
            _observers.Add(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
                observer.UpdateObserver(ViewModel);
        }

        public abstract void UpdateObserver(TModel viewModel);
    }
}
