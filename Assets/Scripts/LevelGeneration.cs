using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField] private Transform proceduralGeneration_1;
    private void Awake()
    {
        SpawnLevelPart(new Vector3(13,-1));
        SpawnLevelPart(new Vector3(13,-1)+ new Vector3(1,0));
    }
    private void SpawnLevelPart(Vector3 spawnPosition)
    {
        Instantiate(proceduralGeneration_1, spawnPosition, Quaternion.identity);
    }
}
