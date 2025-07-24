namespace Minesweeper.Common
{
    public interface IObserver<T>
    {
        void UpdateObserver(T subject);
    }
}
