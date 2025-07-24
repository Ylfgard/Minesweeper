using Minesweeper.Model.Implementation;
using System.Runtime.CompilerServices;
using Zenject;

[assembly: InternalsVisibleTo("Minesweeper.Composition")]
namespace Minesweeper.Model
{
    internal class ModelInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MinefieldProvider>().AsSingle();
        }
    }
}
