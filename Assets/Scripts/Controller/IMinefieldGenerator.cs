using Minesweeper.Model;
using System.Threading.Tasks;

namespace Minesweeper.Controller
{
    public interface IMinefieldGenerator
    {
        Task Initialize(IMinefieldConfig config);
    }
}
