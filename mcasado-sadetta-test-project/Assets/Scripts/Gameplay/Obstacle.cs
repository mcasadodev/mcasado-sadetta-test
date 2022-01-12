using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MCasado.Events;

namespace MCasado.Gameplay
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private VoidEventChannelSO onGameOver = default;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                onGameOver.RaiseEvent();

            }
        }
    }
}