using Minesweeper.Model;
using System.Threading.Tasks;
using UnityEngine;

namespace Minesweeper.Controller
{
    public interface IMinefieldUseCase
    {
        Task GenerateMinefield(IMinefieldConfig config);
        int GetAdjacentMinesCount(Vector2Int coordinates);
    }
}
