using UnityEngine;
[System.Serializable]
public class FruitSpawnData
{
    public float timeToSpawn; // Time at which the fruit should spawn
    public bool spawnFruit;    // Whether a fruit should spawn at this interval
    public GameObject fruitToSpawn; // The fruit GameObject to spawn

    public FruitSpawnData(float time, bool spawn, GameObject fruit)
    {
        timeToSpawn = time;
        spawnFruit = spawn;
        fruitToSpawn = fruit;
    }
}
