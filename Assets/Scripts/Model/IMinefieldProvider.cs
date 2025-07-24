namespace Minesweeper.Model
{
    public interface IMinefieldProvider
    {
        IMinefieldModel CreateNewMinefieldModel(int horizontalSize, int verticalSize);

        IMinefieldModel GetModel();
        ICellModel GetCell(int x, int y);
    }
}
