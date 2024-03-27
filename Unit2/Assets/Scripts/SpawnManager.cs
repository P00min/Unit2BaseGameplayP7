using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 15;
    private float spawnPosZ = 15;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private string[] directions = { "top", "left", "right" };

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        string spawnDirection = directions[Random.Range(0, directions.Length)];
        Vector3 spawnPos = Vector3.zero;
        Quaternion rotation = new Quaternion();

        switch (spawnDirection)
        {
            case "left":
                spawnPos = new Vector3(-30, 0, Random.Range(-1, 16));
                rotation = Quaternion.LookRotation(Vector3.right);
                break;
            case "right":
                spawnPos = new Vector3(30, 0, Random.Range(-1, 16));
                rotation = Quaternion.LookRotation(Vector3.left);
                break;
            default:
                spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
                rotation = animalPrefabs[animalIndex].transform.rotation;
                break;
        }

        Instantiate(animalPrefabs[animalIndex], spawnPos, rotation);
    }
}
