using Minesweeper.Common;
using Minesweeper.Controller;
using Minesweeper.Model;
using Minesweeper.View;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Minesweeper
{
    public class Bootstrap : MonoBehaviour
    {
        [Inject] private readonly IGameScreen _gameScreen;
        [Inject] private readonly ILoadingScreen _loadingScreen;
        [Inject] private readonly IMinefieldGenerator _minefieldGenerator;

        private void Awake()
        {
            RunGame();
        }

        private async void RunGame()
        {
            _loadingScreen.Show();

            await InitializeMinefield();
            await _gameScreen.Initialize();

            _loadingScreen.Hide();
        }

        private async Task InitializeMinefield()
        {
            Log("Minefield initialization started");

            var configLoadProcess = Addressables.LoadAssetAsync<IMinefieldConfig>(Constants.MinefieldConfigPath);
            await configLoadProcess.Task;
            if (configLoadProcess.Status == AsyncOperationStatus.Failed)
                throw new Exception($"Can't load {nameof(IMinefieldConfig)} from path {Constants.MinefieldConfigPath}");
            var config = configLoadProcess.Result;
            Log($"Minefield config loaded. Field size {config.HorizontalSize}x{config.VerticalSize}. Mines amount: {config.MinesAmount}");

            await _minefieldGenerator.Initialize(config);
            Log("Minefield initialized");
        }

        private void Log(string message)
        {
            Debug.Log($"[BOOT] {message}");
        }
    }
}
