using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MCasado.PauseSystem;

namespace MCasado.Gameplay
{
    using MCasado.InputActions;

    public class Player : MonoBehaviour
    {
        InputActions inputActions;
        private bool turnBtnOn;

        [SerializeField] private float speed;
        [SerializeField] private float rotationSpeed;

        private float turning;

        bool playing;

        private void OnEnable()
        {
            inputActions.Enable();
            GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
            OnGameStateChanged(GameStateManager.Instance.CurrentGameState);
        }

        private void OnDisable()
        {
            inputActions.Disable();
            GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
        }

        void Awake()
        {
            inputActions = new InputActions();
            inputActions.Gameplay.Turn.started += x => turning = x.ReadValue<float>();
            inputActions.Gameplay.Turn.canceled += x =>
            {
                turning = 0;
            };

        }

        private void OnMove()
        {
            if (!playing)
                return;
            transform.position += transform.right * speed * Time.deltaTime;
        }

        private void OnTurn()
        {
            if (!playing)
                return;
            if (turning > 0)
            {
                transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);

            }
            else
            {
                transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            }
        }


        private void OnGameStateChanged(GameState newGameState)
        {
            switch (newGameState)
            {
                case GameState.Gameplay:
                    playing = true;
                    break;

                case GameState.Paused:
                    playing = false;
                    break;
                default:
                    break;
            }
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        private void Update()
        {
            OnMove();
            OnTurn();
        }
    }
}
