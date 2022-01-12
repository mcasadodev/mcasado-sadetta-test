using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MCasado.Gameplay
{
    public class FollowTarget : MonoBehaviour
    {
        public GameObject target;
        public float smoothLerp = 5f;
        public bool smoothON;

        private void Awake()
        {
            if (!target)
                target = GameObject.FindObjectOfType<Player>().gameObject;
        }

        void LateUpdate()
        {
            float offset = 10;
            Vector3 newPosition = new Vector3(target.transform.position.x, 0, -offset);
            if (smoothON)
                transform.position = Vector3.Lerp(transform.position, newPosition, smoothLerp * Time.deltaTime);
            else
                transform.position = newPosition;
        }
    }
}
