using UnityEngine;
using MCasado.Events;

namespace MCasado.Gameplay
{
    public class AddScore : MonoBehaviour
    {
        [SerializeField] private IntEventChannelSO _onAddScore = default;

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                _onAddScore.RaiseEvent(1);

            }
        }
    }

}
