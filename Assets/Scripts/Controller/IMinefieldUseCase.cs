using Minesweeper.Model;
using System.Threading.Tasks;

namespace Minesweeper.Controller
{
    public interface IMinefieldUseCase
    {
        Task GenerateMinefield(IMinefieldConfig config);
    }
}
