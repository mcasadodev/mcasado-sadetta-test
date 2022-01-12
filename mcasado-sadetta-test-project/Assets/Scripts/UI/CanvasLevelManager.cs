using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MCasado.Events;

namespace MCasado.UI
{
    public class CanvasLevelManager : MonoBehaviour
    {
        [SerializeField] private BoolEventChannelSO _ToggleCanvas = default;

        public GameObject canvas;

        private void OnEnable()
        {
            if (_ToggleCanvas != null)
            {
                _ToggleCanvas.OnEventRaised += ToggleCanvas;
            }
        }

        private void OnDisable()
        {
            if (_ToggleCanvas != null)
            {
                _ToggleCanvas.OnEventRaised -= ToggleCanvas;
            }
        }

        private void ToggleCanvas(bool state)
        {
            canvas.SetActive(state);
        }
    }
}