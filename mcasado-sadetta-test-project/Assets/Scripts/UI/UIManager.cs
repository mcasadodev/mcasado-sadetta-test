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
        public IntEventChannelSO score;
        public BoolEventChannelSO _onOpenCanvas;

        public GameObject canvas;
        public TextMeshProUGUI scoreText;

        public GameObject modalWindowPrefab;

        private void OnEnable()
        {
            if (score != null)
            {
                score.OnEventRaised += Updatescore;
            }
            if (_onOpenCanvas != null)
            {
                _onOpenCanvas.OnEventRaised += OpenCanvas;
            }
        }
        private void OnDisable()
        {
            if (score != null)
            {
                score.OnEventRaised -= Updatescore;
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

        private void Updatescore(int score)
        {
            scoreText.text = score.ToString();
        }

        private void OpenCanvas(bool state)
        {
            canvas.SetActive(state);
        }
    }
}
