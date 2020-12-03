using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerated : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;

    [SerializeField] private Transform proceduralGeneration_start;
    [SerializeField] private List<Transform> proceduralGeneration_list;
    [SerializeField] private Transform player;

    private Vector3 lastEndPosition;
    private void Awake()
    {
        lastEndPosition = proceduralGeneration_start.Find("EndPosition").position;

        int startingSpawnLevelParts = 5;
        for( int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawProcGen();
        }
    }
    private void Update()
    {
        if(Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawProcGen();
        }
    }
    private void SpawProcGen()
    {
        Transform chosenLevelPart = proceduralGeneration_list[Random.Range(0,proceduralGeneration_list.Count)];
        Transform lastProGenTransform = SpawProcGen(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastProGenTransform.Find("EndPosition").position;
    }
    private Transform SpawProcGen(Transform levelPart, Vector3 spawnPosition)
    {
        Transform procGenTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return procGenTransform;
    }
}
