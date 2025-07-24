using UnityEngine;

namespace Minesweeper.View
{
    internal class CellImageViewProvider : MonoBehaviour
    {
        [field: SerializeField] public Sprite HiddenSprite { get; private set; }
        [field: SerializeField] public Sprite RevealedSprite { get; private set; }
        [field: SerializeField] public Sprite MineSprite { get; private set; }
        [field: SerializeField] public Sprite FlagSprite { get; private set; }

    }
}
