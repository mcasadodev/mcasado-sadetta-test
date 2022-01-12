using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MCasado.Events;

namespace MCasado.SceneSystem
{
    using MCasado.InputActions;

    public class GameExit : MonoBehaviour
    {
        [SerializeField] private VoidEventChannelSO _onQuitGame;
        InputActions inputActions;
        float quit;

        private void OnEnable()
        {
            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }
        void Awake()
        {
            inputActions = new InputActions();
            inputActions.Gameplay.Quit.started += x =>
            {
                OnQuitGame();
            };
        }

        private void OnQuitGame()
        {
            _onQuitGame.RaiseEvent();
        }
    }
}