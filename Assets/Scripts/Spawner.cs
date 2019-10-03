using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float nextActionTime = 0.0f;

    [Header("Spawning Rate Adjustables")]
    public float timeBetweenSpawns = 1.0f;
    
    [Header("Tha Object")]
    public GameObject toBeSpawned;
    public Transform spawnPosition;
    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextActionTime) {
            nextActionTime += timeBetweenSpawns;
            Instantiate(toBeSpawned, spawnPosition.position, spawnPosition.rotation);
        }  
    }
}
