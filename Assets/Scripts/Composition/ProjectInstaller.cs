using Minesweeper.Composition;
using Minesweeper.Controller;
using Minesweeper.Model;
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

            Container.Install<ControllerInstaller>();
            Container.Install<ModelInstaller>();
        }
    }
}
