using System.Linq;
using Minesweeper.Model;
using System.Threading.Tasks;
using UnityEngine;
using System.Text;

namespace Minesweeper.Controller.Services
{
    internal class MinefieldUseCase : IMinefieldUseCase
    {
        private readonly IMinefieldProvider _minefieldProvider;

        private IMinefieldConfig _config;

        public MinefieldUseCase(IMinefieldProvider minefieldProvider)
        {
            _minefieldProvider = minefieldProvider;
        }

        public async Task Initialize(IMinefieldConfig config)
        {
            _config = config;
            await GenerateNewMinefield();
        }

        public Task GenerateNewMinefield()
        {
            var model = _minefieldProvider.CreateNewMinefield(_config.HorizontalSize, _config.VerticalSize);
            var cells = model.Cells.Cast<ICellModel>().ToList();
            for (int i = 0; i < _config.MinesAmount; i++)
            {
                var cell = cells[Random.Range(0, cells.Count)];
                cell.IsMine = true;
                cells.Remove(cell);
            }

            var sb = new StringBuilder();
            for (int y = 0; y < _config.VerticalSize; y++)
            {
                for (int x = 0; x < _config.HorizontalSize; x++)
                    sb.Append(model.Cells[y, x].IsMine ? '*' : '0');
                sb.Append("\n");
            }
            Debug.Log($"Generated minefield \n{sb.ToString()}");

            return Task.CompletedTask;
        }

        public int GetAdjacentMinesCount(Vector2Int coordinates)
        {
            var model = _minefieldProvider.GetModel();
            int yMin = Mathf.Clamp(coordinates.y - 1, 0, model.VerticalSize - 1);
            int yMax = Mathf.Clamp(coordinates.y + 1, 0, model.VerticalSize - 1);
            int xMin = Mathf.Clamp(coordinates.x - 1, 0, model.HorizontalSize - 1);
            int xMax = Mathf.Clamp(coordinates.x + 1, 0, model.HorizontalSize - 1);

            int result = 0;
            for (var y = yMin; y <= yMax; y++)
                for (var x = xMin; x <= xMax; x++)
                    if (model.Cells[y, x].IsMine)
                        result++;
            return result;
        }
    }
}
