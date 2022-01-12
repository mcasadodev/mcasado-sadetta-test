using UnityEngine;

namespace MCasado.SceneSystem
{
    using MCasado.Events;
    using MCasado.PauseSystem;

    /// <summary>
    /// This class goes on a trigger which, when entered, sends the player to another Location
    /// </summary>

    public class SceneChange : MonoBehaviour
    {
        [Header("Loading settings")]
        [SerializeField] private GameSceneSO[] _locationsToLoad = default;
        [SerializeField] private bool _showLoadScreen = default;
        [SerializeField] private bool _fade = default;
        //[SerializeField] private PathAnchor _pathTaken = default;
        //[SerializeField] private PathSO _exitPath = default;

        [Header("Broadcasting on")]
        [SerializeField] private LoadEventChannelSO _SceneChangeLoadChannel = default;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //UpdatePathTaken();
                _SceneChangeLoadChannel.RaiseEvent(_locationsToLoad, _showLoadScreen, _fade);
            }
        }

        //private void UpdatePathTaken()
        //{
        //    if (_pathTaken != null)
        //        _pathTaken.Path = _exitPath;
        //}

        // ESTA FUNCION ES MIA DE PRUEBA
        public void LoadFromButton()
        {
            GameStateManager.Instance.SetState(GameState.Gameplay);
            //UpdatePathTaken();
            _SceneChangeLoadChannel.RaiseEvent(_locationsToLoad, _showLoadScreen, _fade);
        }
    }
}
