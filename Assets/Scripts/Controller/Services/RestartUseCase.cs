using Minesweeper.Common;
using System.Threading.Tasks;

namespace Minesweeper.Controller.Services
{
    internal class RestartUseCase
    {
        private readonly ILoadingScreen _loadingScreen;
        private readonly MinefieldGenerator _minefieldGenerator;

        public RestartUseCase(ILoadingScreen loadingScreen, 
            MinefieldGenerator minefieldGenerator)
        {
            _loadingScreen = loadingScreen;
            _minefieldGenerator = minefieldGenerator;
        }

        public async Task RestartGame()
        {
            _loadingScreen.Show();

            await _minefieldGenerator.GenerateNewMinefield();

            _loadingScreen.Hide();
        }
    }
}
