using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MCasado.Gameplay
{
    public class LevelGenerator : MonoBehaviour
    {
        private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;

        [SerializeField] private Transform levelPart_Start;
        [SerializeField] private List<Transform> levelPartList;
        [SerializeField] private Player player;

        private Vector3 lastEndPosition;

        private void Awake()
        {
            lastEndPosition = levelPart_Start.Find("EndPosition").position;

            int startingSpawnLevelParts = 2;
            for (int i = 0; i < startingSpawnLevelParts; i++)
            {
                SpawnLevelPart();
            }
        }
        private void Update()
        {
            if (Vector3.Distance(player.GetPosition(), lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
            {
                //Spawn another level part
                SpawnLevelPart();
            }
        }

        private void SpawnLevelPart()
        {
            Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
            Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
            lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        }
        private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
        {
            Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
            levelPartTransform.transform.SetParent(this.transform, false);
            return levelPartTransform;
        }
    }
}