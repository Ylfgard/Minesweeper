using Minesweeper.Controller.Api;
using UnityEngine;
using Zenject;

namespace Minesweeper.View
{
    public class MineFieldView : MonoBehaviour
    {
        [Inject] private readonly IMineFieldPresenter _mineFieldPresenter;
    }
}
