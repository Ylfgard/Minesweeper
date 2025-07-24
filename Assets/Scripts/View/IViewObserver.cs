namespace Minesweeper.View
{
    public interface IViewObserver<T>
    {
        void UpdateView(T viewModel);
    }
}
