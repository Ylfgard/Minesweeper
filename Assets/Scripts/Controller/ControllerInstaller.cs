using Minesweeper.Controller.Services;
using System.Runtime.CompilerServices;
using Zenject;

[assembly: InternalsVisibleTo("Minesweeper.Composition")]
namespace Minesweeper.Controller
{
    internal class ControllerInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MinefieldUseCase>().AsSingle();
        }
    }
}
