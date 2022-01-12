using System.Collections;
using UnityEngine;
using MCasado.Events;
using MCasado.AudioSystem;
using MCasado.PauseSystem;
using MCasado.Scoreboards;

namespace MCasado.Gameplay
{
    public class GameplayManager : MonoBehaviour
    {
        public BoolEventChannelSO _onOpenCanvas;
        public BoolEventChannelSO _onOpenCanvasLevel;
        [SerializeField] private VoidEventChannelSO onGameOver = default;
        [SerializeField] private IntEventChannelSO _points = default;
        [SerializeField] private IntEventChannelSO _onAddPoint = default;
        private ScoreBoard scoreBoard = default;

        public int points = 0;

        private void OnEnable()
        {
            if (onGameOver != null)
            {
                onGameOver.OnEventRaised += GameIsOver;
            }

            if (_onAddPoint != null)
            {
                _onAddPoint.OnEventRaised += OnAddPoint;
            }

            scoreBoard = GameObject.FindObjectOfType<ScoreBoard>();
        }

        private void OnDisable()
        {
            if (onGameOver != null)
            {
                onGameOver.OnEventRaised -= GameIsOver;
            }
            if (_onAddPoint != null)
            {
                _onAddPoint.OnEventRaised -= OnAddPoint;
            }
        }

        private void Awake()
        {
            StartCoroutine(WaitForStart());
        }

        private void GameIsOver()
        {
            GetComponent<AudioCue>().PlayAudioCue();
            scoreBoard.AddTestEntry();
            _onOpenCanvasLevel.RaiseEvent(true);
            _onOpenCanvas.RaiseEvent(true);
        }

        private void OnAddPoint(int point)
        {
            points += point;
            _points.RaiseEvent(points);
        }

        private void Update()
        {
            if (!scoreBoard)
                scoreBoard = GameObject.FindObjectOfType<ScoreBoard>();
        }

        private IEnumerator WaitForStart()
        {
            GameStateManager.Instance.SetState(GameState.Paused);
            yield return new WaitForSeconds(1.5f);
            GameStateManager.Instance.SetState(GameState.Gameplay);
        }
    }
}
