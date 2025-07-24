using Minesweeper.Controller.Services;
using Zenject;

namespace Minesweeper.Controller
{
    internal class ControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MinefieldUseCase>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameScreenPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputPresenter>().AsSingle();
        }
    }
}
