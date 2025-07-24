using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Minesweeper.View
{
    internal class CellView : MonoBehaviour, IViewObserver<ICellViewModel>
    {
        [Inject] private readonly CellImageViewProvider _cellImageViewProvider;

        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI minesCountText;

        public void UpdateView(ICellViewModel viewModel)
        {

        }
    }

    public interface ICellViewModel : IViewModel<ICellViewModel>
    {
        bool IsMine { get; }
        bool IsRevealed { get; }
        bool IsFlagged { get; }
    }
}
