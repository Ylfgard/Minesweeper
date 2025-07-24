namespace Minesweeper.Controller.Api
{
    public interface IMineFieldConfig
    {
        int HorizontalSize { get; }
        int VerticalSize { get; }
        int MinesAmount { get; }
    }
}
