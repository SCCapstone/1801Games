//By Yiqian Sun

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerated : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 100f;

    [SerializeField] private Transform proceduralGeneration_start;
    //[SerializeField] private Transform pfTestingPlateform;
    [SerializeField] private List<Transform> proceduralGenerationEZ_list;
    [SerializeField] private List<Transform> proceduralGenerationMD_list;
    [SerializeField] private List<Transform> proceduralGenerationHard_list;
    [SerializeField] private List<Transform> proceduralGenerationImp_list;
    [SerializeField] private Transform player;

    private int levelPartSpawned;
    private Vector3 lastEndPosition;
    private enum Difficulty
    {
        EZ,
        MD,
        Hard,
        Imp
    }

    private void Awake()
    {
        lastEndPosition = proceduralGeneration_start.Find("EndPosition").position;

        //if (pfTestingPlateform!= null)
        //{
         //   Debug.Log("Using Debug Testing Platform!");
        //}
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
        List<Transform> DifficultyLevelPartList;
        switch (GetDifficulty())
        {
            default:
            case Difficulty.EZ: DifficultyLevelPartList = proceduralGenerationEZ_list; break;
            case Difficulty.MD: DifficultyLevelPartList = proceduralGenerationMD_list; break;
            case Difficulty.Hard: DifficultyLevelPartList = proceduralGenerationHard_list; break;
            case Difficulty.Imp: DifficultyLevelPartList = proceduralGenerationImp_list; break;
        }
        Transform chosenLevelPart = DifficultyLevelPartList[Random.Range(0,DifficultyLevelPartList.Count)];
    
       // if (pfTestingPlateform!= null)
        //{
         //   chosenLevelPart = pfTestingPlateform;
        //}
        Transform lastProGenTransform = SpawProcGen(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastProGenTransform.Find("EndPosition").position;
        levelPartSpawned++;
    }
    private Transform SpawProcGen(Transform levelPart, Vector3 spawnPosition)
    {
        Transform procGenTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return procGenTransform;
    }
    private Difficulty GetDifficulty()
    {
        if (levelPartSpawned >= 24) return Difficulty.Imp;
        if (levelPartSpawned >= 16) return Difficulty.Hard;
        if (levelPartSpawned >= 8) return Difficulty.MD;
        return Difficulty.EZ;
    }
}
