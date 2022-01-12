using UnityEngine;
using MCasado.Events;

namespace MCasado.Gameplay
{
    public class AddPoint : MonoBehaviour
    {
        [SerializeField] private IntEventChannelSO _onAddPoint = default;

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                _onAddPoint.RaiseEvent(1);

            }
        }
    }

}
