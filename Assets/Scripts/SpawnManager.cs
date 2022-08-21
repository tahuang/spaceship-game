using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 13.0f;
    private float spawnRangeLowerY = 2.0f;
    private float spawnRangeUpperY = 4.0f;
    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn enemies repeatedly throughout the game.
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
    }

    void SpawnRandomEnemy()
    {
        // Spawn a random enemy.
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);

        // Choose a random spawn position at the top, left or right of the screen.
        Vector3 spawnTop = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnRangeUpperY, 0);
        Vector3 spawnLeft = new Vector3(-spawnRangeX, Random.Range(spawnRangeLowerY, spawnRangeUpperY), 0);
        Vector3 spawnRight = new Vector3(spawnRangeX, Random.Range(spawnRangeLowerY, spawnRangeUpperY), 0);
        Vector3[] spawnPositions = { spawnTop, spawnLeft, spawnRight };
        int spawnIndex = Random.Range(0, spawnPositions.Length);

        Instantiate(enemyPrefabs[enemyIndex], spawnPositions[spawnIndex], enemyPrefabs[enemyIndex].transform.rotation);
    }
}

