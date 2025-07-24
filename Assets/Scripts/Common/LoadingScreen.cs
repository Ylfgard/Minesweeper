using UnityEngine;

namespace Minesweeper.Common
{
    internal class LoadingScreen : MonoBehaviour, ILoadingScreen
    {
        [SerializeField] private Transform loadingIcon;
        [SerializeField] private float rotateSpeed = 180;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void Update()
        {
            loadingIcon.Rotate(loadingIcon.forward, rotateSpeed * Time.deltaTime);
        }
    }
}
