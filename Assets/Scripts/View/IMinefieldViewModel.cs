namespace Minesweeper.View
{
    public interface IMinefieldViewModel : IViewModel<IMinefieldViewModel>
    {
        ICellViewModel[,] Cells { get; }
    }
}
