using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] powerUps; 
    public Transform spawnLocation; 

    private float spawnDelay = 10f;
    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnDelay;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnPowerUp();
            nextSpawnTime = Time.time + spawnDelay;
        }
    }

    void SpawnPowerUp()
    {
        int index = Random.Range(0, powerUps.Length);
        Instantiate(powerUps[index], spawnLocation.position, Quaternion.identity);
    }
}
