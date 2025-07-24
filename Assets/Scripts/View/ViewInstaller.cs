using UnityEngine;
using Zenject;

namespace Minesweeper.View
{
    internal class ViewInstaller : MonoInstaller
    {
        [SerializeField] private CellImageViewProvider cellImageViewProvider;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CellImageViewProvider>().FromInstance(cellImageViewProvider).AsSingle();
        }
    }
}
