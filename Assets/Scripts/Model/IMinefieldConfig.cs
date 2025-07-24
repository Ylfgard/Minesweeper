namespace Minesweeper.Model
{
    public interface IMinefieldConfig
    {
        int HorizontalSize { get; }
        int VerticalSize { get; }
        int MinesAmount { get; }
    }
}
