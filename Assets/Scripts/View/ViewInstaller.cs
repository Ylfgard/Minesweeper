using Minesweeper.View.Ui;
using UnityEngine;
using Zenject;

namespace Minesweeper.View
{
    internal class ViewInstaller : MonoInstaller
    {
        [SerializeField] private GameScreen gameScreen;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameScreen>().FromInstance(gameScreen).AsSingle();
        }
    }
}
