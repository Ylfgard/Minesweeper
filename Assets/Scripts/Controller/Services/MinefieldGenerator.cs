using System.Linq;
using Minesweeper.Model;
using System.Threading.Tasks;
using UnityEngine;
using System.Text;

namespace Minesweeper.Controller.Services
{
    internal class MinefieldGenerator : IMinefieldGenerator
    {
        private readonly IMinefieldProvider _minefieldProvider;

        private IMinefieldConfig _config;

        public MinefieldGenerator(IMinefieldProvider minefieldProvider)
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
                {
                    var cell = model.Cells[y, x];
                    cell.AdjacentMinesCount = GetAdjacentMinesCount(cell.Coordinates, model);
                    sb.Append(cell.IsMine ? '*' : cell.AdjacentMinesCount.ToString());
                    sb.Append(' ');
                }
                sb.Append("\n");
            }
            Debug.Log($"Generated minefield \n{sb.ToString()}");

            return Task.CompletedTask;
        }

        public int GetAdjacentMinesCount(Vector2Int coordinates, IMinefieldModel model)
        {
            int result = 0;
            void HandleCall(ICellModel cell)
            {
                if (cell.IsMine)
                    result++;
            }

            model.ForEachAdjacentCell(coordinates, HandleCall);
            return result;
        }
    }
}
