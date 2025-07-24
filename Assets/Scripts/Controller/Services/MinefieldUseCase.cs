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

        public MinefieldUseCase(IMinefieldProvider minefieldProvider)
        {
            _minefieldProvider = minefieldProvider;
        }

        public Task GenerateMinefield(IMinefieldConfig config)
        {
            var model = _minefieldProvider.CreateNewMinefieldModel(config.HorizontalSize, config.VerticalSize);
            var cells = model.Cells.Cast<ICellModel>().ToList();
            for (int i = 0; i < config.MinesAmount; i++)
            {
                var cell = cells[Random.Range(0, cells.Count)];
                cell.IsMine = true;
                cells.Remove(cell);
            }

            var sb = new StringBuilder();
            for (int y = 0; y < config.VerticalSize; y++)
            {
                for (int x = 0; x < config.HorizontalSize; x++)
                    sb.Append(model.Cells[x, y].IsMine ? "|*|" : "| |");
                sb.Append("\n");
            }
            Debug.Log($"Minefield: {sb.ToString()}");

            return Task.CompletedTask;
        }
    }
}
