namespace Minesweeper.View
{
    public interface IMinefieldViewModel : IViewModel<IMinefieldViewModel>
    {
        int HorizontalSize { get; }
        int VerticalSize { get; }
        ICellViewModel[,] Cells { get; }
    }
}
