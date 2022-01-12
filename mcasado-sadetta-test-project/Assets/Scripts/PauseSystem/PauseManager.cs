using UnityEngine;
using MCasado.Events;
using MCasado.PauseSystem;

public class PauseManager : MonoBehaviour
{

    [SerializeField] private VoidEventChannelSO onGameOver = default;
    public BoolEventChannelSO _onOpenCanvas;

    private void OnEnable()
    {
        if (onGameOver != null)
        {
            onGameOver.OnEventRaised += ChangeGameState;
        }
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;

    }

    private void OnDisable()
    {
        if (onGameOver != null)
        {
            onGameOver.OnEventRaised -= ChangeGameState;
        }
    }
    private void ChangeGameState()
    {
        //GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        //GameState newGameState = currentGameState == GameState.Gameplay
        //? GameState.Paused
        //: GameState.Gameplay;

        GameStateManager.Instance.SetState(GameState.Paused);
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;

    }
    private void OnGameStateChanged(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.Gameplay:
                Time.timeScale = 1;
                break;
            case GameState.Paused:
                break;
            default:
                Time.timeScale = 1;
                break;

        }
    }
}
