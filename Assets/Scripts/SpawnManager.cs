using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;
    private float startPosXPlatform = 25.0f;
    private float[] posYPlatform = {-8.0f, -4.0f, 0.0f, 4.0f};

    private float spawnDelay = 0;
    private float[] spawnInterval = {0.7f, 1.0f, 1.3f, 1.5f};
    private int indexPosY;
    private int lastPosY = 0;
    private int indexPlatform;
    private int lastIndexPlatform;
    private Vector2 spawnPos;
    void Start()
    {
        InvokeRepeating("SpawnPlatforms", spawnDelay, spawnInterval[Random.Range(0,spawnInterval.Length)]);
    }

    void SpawnPlatforms(){
        indexPosY = Random.Range(0,posYPlatform.Length);
        /* while (true)
        {
            indexPosY = Random.Range(0,posYPlatform.Length);
            if(indexPosY != lastPosY){
                break;
            }
        } */
        
        do
        {
            indexPosY = Random.Range(0,posYPlatform.Length);
        } while (indexPosY == lastPosY);
        
        lastPosY = indexPosY;

        spawnPos = new Vector2(startPosXPlatform, posYPlatform[indexPosY]);

        indexPlatform = Random.Range(0, platformPrefabs.Length);
        do
        {
            indexPlatform = Random.Range(0, platformPrefabs.Length);
        } while (indexPlatform == lastIndexPlatform);

        lastIndexPlatform = indexPlatform;
        
        Instantiate(platformPrefabs[indexPlatform], spawnPos, platformPrefabs[indexPlatform].transform.rotation);
    }
}
