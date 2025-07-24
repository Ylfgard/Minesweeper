using Minesweeper.Controller.Services;
using Zenject;

namespace Minesweeper.Controller
{
    internal class ControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MinefieldGenerator>().AsSingle();

            Container.BindInterfacesAndSelfTo<GameScreenPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputPresenter>().AsSingle();

            Container.BindInterfacesAndSelfTo<RestartUseCase>().AsSingle();
            Container.BindInterfacesAndSelfTo<MinefieldUseCase>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameFlowUseCase>().AsSingle();
        }
    }
}
