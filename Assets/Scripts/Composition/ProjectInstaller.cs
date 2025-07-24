using Minesweeper.Composition;
using UnityEngine;
using Zenject;

namespace Minesweeper
{
    internal class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private LoadingScreen loadingScreen;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LoadingScreen>().FromInstance(loadingScreen).AsSingle();
        }
    }
}
