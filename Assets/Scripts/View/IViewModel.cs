namespace Minesweeper.View
{
    public interface IViewModel<T>
    {
        void Attach(IViewObserver<T> observer);
        void Detach(IViewObserver<T> observer);
        void Notify();
    }
}
