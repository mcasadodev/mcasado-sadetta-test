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
        [SerializeField] private VoidEventChannelSO _onGameOver = default;
        [SerializeField] private IntEventChannelSO _score = default;
        [SerializeField] private IntEventChannelSO _onAddScore = default;
        private ScoreBoard scoreBoard = default;

        public int score = 0;

        private void OnEnable()
        {
            if (_onGameOver != null)
            {
                _onGameOver.OnEventRaised += OnGameOver;
            }

            if (_onAddScore != null)
            {
                _onAddScore.OnEventRaised += OnAddScore;
            }

            scoreBoard = GameObject.FindObjectOfType<ScoreBoard>();
        }

        private void OnDisable()
        {
            if (_onGameOver != null)
            {
                _onGameOver.OnEventRaised -= OnGameOver;
            }
            if (_onAddScore != null)
            {
                _onAddScore.OnEventRaised -= OnAddScore;
            }
        }

        private void Awake()
        {
            StartCoroutine(WaitForStart());
        }

        private void OnGameOver()
        {
            GetComponent<AudioCue>().PlayAudioCue();
            scoreBoard.AddTestEntry();
            _onOpenCanvasLevel.RaiseEvent(true);
            _onOpenCanvas.RaiseEvent(true);
        }

        private void OnAddScore(int scoreAdd)
        {
            score += scoreAdd;
            _score.RaiseEvent(score);
        }

        private void Update()
        {
            if (!scoreBoard)
                scoreBoard = GameObject.FindObjectOfType<ScoreBoard>();
        }

        private IEnumerator WaitForStart()
        {
            GameStateManager.Instance.SetState(GameState.Paused);
            yield return new WaitForSeconds(1);
            GameStateManager.Instance.SetState(GameState.Gameplay);
        }
    }
}
