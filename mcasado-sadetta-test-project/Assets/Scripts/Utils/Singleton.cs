using UnityEngine;

namespace MCasado.Utils
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    // Just in case the instance was somehow not attached
                    instance = FindObjectOfType<T>();

                    if (instance == null)
                    {
                        var obj = new GameObject();
                        obj.hideFlags = HideFlags.HideAndDontSave;
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }
    }
}