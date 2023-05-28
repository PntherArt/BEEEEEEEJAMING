using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedSpawnner : MonoBehaviour
{
    public GameObject seedPrefab;
    public int spawnCount;

    private void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-15, 16), 0, Random.Range(-15, 16));
            Instantiate(seedPrefab, randomSpawnPosition, Quaternion.identity);
        }
        
    }

}
