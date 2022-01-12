using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MCasado.UI
{
    using MCasado.Events;

    public class UIManager : MonoBehaviour
    {
        public IntEventChannelSO points;
        public BoolEventChannelSO _onOpenCanvas;

        public GameObject canvas;
        public TextMeshProUGUI pointsText;

        public GameObject modalWindowPrefab;

        private void OnEnable()
        {
            if (points != null)
            {
                points.OnEventRaised += UpdatePoints;
            }
            if (_onOpenCanvas != null)
            {
                _onOpenCanvas.OnEventRaised += OpenCanvas;
            }
        }
        private void OnDisable()
        {
            if (points != null)
            {
                points.OnEventRaised -= UpdatePoints;
            }
            if (_onOpenCanvas != null)
            {
                _onOpenCanvas.OnEventRaised -= OpenCanvas;
            }
        }

        private void Start()
        {
            GameObject ModalWindow = Instantiate(modalWindowPrefab);
            ModalWindow.transform.SetParent(canvas.transform.parent.transform, false);
        }

        private void UpdatePoints(int points)
        {
            pointsText.text = points.ToString();
        }

        private void OpenCanvas(bool state)
        {
            canvas.SetActive(state);
        }
    }
}
