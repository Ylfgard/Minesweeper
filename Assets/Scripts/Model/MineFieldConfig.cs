using Minesweeper.Controller.Api;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Minesweeper.Model
{
    [CreateAssetMenu(fileName = "MineFieldConfig", menuName = "Configs/MineFieldConfig", order = 1)]
    internal class MineFieldConfig : ScriptableObject, IMineFieldConfig
    {
        [SerializeField][Range(1, 30)] private int horizontalSize;
        [SerializeField][Range(1, 16)] private int verticalSize;
        [SerializeField][Range(1, 99)] private int minesAmount;

        public int HorizontalSize => horizontalSize;
        public int VerticalSize => verticalSize;
        public int MinesAmount => minesAmount;

        private void OnValidate()
        {
            var cellsCount = horizontalSize * verticalSize;
            if (minesAmount >= cellsCount)
                minesAmount = cellsCount - 1;
        }
    }
}
