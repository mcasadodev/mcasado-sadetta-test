using UnityEngine.Events;
using UnityEngine;

namespace MCasado.Events
{
    [CreateAssetMenu(menuName = "Events/String Event Channel")]
    public class StringEventChannelSO : ScriptableObject
    {
        public UnityAction<string> OnEventRaised;
        public void RaiseEvent(string value)
        {
            OnEventRaised.Invoke(value);
        }
    }
}
