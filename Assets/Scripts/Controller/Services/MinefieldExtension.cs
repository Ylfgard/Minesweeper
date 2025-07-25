using Minesweeper.Model;
using System;
using UnityEngine;

namespace Minesweeper.Controller.Services
{
    internal static class MinefieldExtension
    {
        public static void ForEachAdjacentCell(this IMinefieldModel model,
            Vector2Int coordinates, Action<ICellModel> handleCall)
        {
            int yMin = Mathf.Clamp(coordinates.y - 1, 0, model.VerticalSize - 1);
            int yMax = Mathf.Clamp(coordinates.y + 1, 0, model.VerticalSize - 1);
            int xMin = Mathf.Clamp(coordinates.x - 1, 0, model.HorizontalSize - 1);
            int xMax = Mathf.Clamp(coordinates.x + 1, 0, model.HorizontalSize - 1);

            for (var y = yMin; y <= yMax; y++)
                for (var x = xMin; x <= xMax; x++)
                    handleCall.Invoke(model.Cells[y, x]);
        }
    }
}
