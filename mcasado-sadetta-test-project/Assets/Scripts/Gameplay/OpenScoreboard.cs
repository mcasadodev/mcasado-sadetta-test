using System.Collections;
using UnityEngine;
using MCasado.Events;

namespace MCasado.Gameplay
{
    public class OpenScoreboard : MonoBehaviour
    {
        public BoolEventChannelSO _onOpenCanvas;
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.5f);
            _onOpenCanvas.RaiseEvent(true);
        }
    }
}
