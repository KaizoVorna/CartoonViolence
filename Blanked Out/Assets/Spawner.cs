using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;

    public void SpawnObject()
        {
        Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
        }

}
