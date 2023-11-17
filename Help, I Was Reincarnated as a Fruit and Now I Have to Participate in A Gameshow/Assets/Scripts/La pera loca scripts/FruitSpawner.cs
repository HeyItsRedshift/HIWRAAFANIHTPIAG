using UnityEngine;
using System.Collections.Generic;

public class FruitSpawner : MonoBehaviour
{
    public List<FruitSpawnData> intervalList = new List<FruitSpawnData>();
    public List<GameObject> fruitPrefabs; // Array of fruit prefabs to spawn
    public Transform spawnPoint; // Transform to define spawn location
    private float timeElapsed = 0f; // Time elapsed since the start of spawning
    private int totalFruitsToSpawn = 60; // Total fruits to spawn
    private float spawnInterval = 0.5f; // Time interval between beats
    public float totalGameTime = 120f;
    private int fruitsSpawned = 0;
    private void Start()
    {
        RandomIntervalAssigner();
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime; // Update the elapsed time

        // Check if there are still intervals to process and if the time for the next fruit spawn has been reached
        if (intervalList.Count > 0 && intervalList[0].timeToSpawn <= timeElapsed)
        {
            // Check if a fruit should be spawned at this interval
            if (intervalList[0].spawnFruit)
            {
                // Instantiate the fruit at the spawn point
                Instantiate(intervalList[0].fruitToSpawn, spawnPoint.position, spawnPoint.rotation);
            }

            // Remove the first interval after processing it
            intervalList.RemoveAt(0);
        }
    }




    private void GenerateSpawnIntervals()
    {
        // Create a list of 120 potential spawn times (0.5-second intervals for 60 seconds)
        for (int i = 0; i < totalGameTime / spawnInterval; i++)
        {
            int randoIndex = Random.Range(0, fruitPrefabs.Count);
            FruitSpawnData currentBeat = new FruitSpawnData(Time.time + (i * spawnInterval), false, fruitPrefabs[randoIndex]);
            intervalList.Add(currentBeat);
        }
    }
    public void RandomIntervalAssigner()
    {
        intervalList.Clear();
        GenerateSpawnIntervals();
        int startingPoint = 0;
        while (totalFruitsToSpawn > fruitsSpawned)
        {
            int medianInterval;
            medianInterval = intervalList.Count / (totalFruitsToSpawn / 2);
            int step = medianInterval;
            for (int i = startingPoint; i < intervalList.Count; i += step)
            {
                step = Random.Range(medianInterval, medianInterval + 2);
                print(step);
                if (intervalList[i].spawnFruit == false)
                {
                    intervalList[i].spawnFruit = true;
                    fruitsSpawned++;

                }
            }
            startingPoint++;
        }
    }
}