using UnityEngine;

namespace MCasado.SceneSystem
{
    using MCasado.Events;

    public class LoadingScreenManager : MonoBehaviour
    {
        [Header("Loading screen Event")]
        [SerializeField] private BoolEventChannelSO _ToggleLoadingScreen = default;

        [Header("Loading screen ")]
        public GameObject loadingInterface;

        private void OnEnable()
        {
            if (_ToggleLoadingScreen != null)
            {
                _ToggleLoadingScreen.OnEventRaised += ToggleLoadingScreen;
            }
        }

        private void OnDisable()
        {
            if (_ToggleLoadingScreen != null)
            {
                _ToggleLoadingScreen.OnEventRaised -= ToggleLoadingScreen;
            }
        }

        private void ToggleLoadingScreen(bool state)
        {
            loadingInterface.SetActive(state);
        }

    }
}
