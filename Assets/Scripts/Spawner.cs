using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] powerUps; // Pole prefabů powerUpů
    public Transform spawnLocation; // Umístění spawnu

    private float spawnDelay = 10f; // Čas mezi spawnováními
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
        // Náhodný výběr powerUpu
        int index = Random.Range(0, powerUps.Length);
        // Spawnování powerUpu
        Instantiate(powerUps[index], spawnLocation.position, Quaternion.identity);
    }
}
