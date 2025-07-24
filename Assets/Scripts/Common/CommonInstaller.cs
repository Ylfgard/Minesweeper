using Minesweeper.Common;
using UnityEngine;
using Zenject;

namespace Minesweeper.Common
{
    internal class CommonInstaller : MonoInstaller
    {
        [SerializeField] private LoadingScreen loadingScreen;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LoadingScreen>().FromInstance(loadingScreen).AsSingle();
        }
    }
}
