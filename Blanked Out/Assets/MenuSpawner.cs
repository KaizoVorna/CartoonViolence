using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour
{
        public GameObject prefabToSpawn;
        public Transform spawnPoint;
        public int maxSpawnCount = 1;
        private int currentSpawnCount = 0;

        public void SpawnObject()
        {
            if(currentSpawnCount >= maxSpawnCount)
                {
            Debug.Log("Spawn limit reached.");
                return;
                } 

            Vector2 spawnPos = spawnPoint ? spawnPoint.position : Vector2.zero;
            Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
            currentSpawnCount++;
        }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SpawnObject();
        }
    }
}
