using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public TextMeshProUGUI gameTitleText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button startButton;
    public Button restartButton;
    private float spawnRangeX = 13.0f;
    private float spawnRangeLowerY = 2.0f;
    private float spawnRangeUpperY = 4.0f;
    private int waveNumber = 1;
    private bool waveComplete = false;
    private int score = 0;
    public bool isGameActive = false;

    // Start is called before the first frame update
    public void StartGame()
    {
        isGameActive = true;
        gameTitleText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);

        // Spawn enemies repeatedly throughout the game.
        StartCoroutine(SpawnEnemyWave(waveNumber));
    }

    void Update()
    {
        if (isGameActive && waveComplete)
        {
            waveNumber++;
            waveComplete = false;
            StartCoroutine(SpawnEnemyWave(waveNumber));
        }
    }

    // ABSTRACTION
    IEnumerator SpawnEnemyWave(int waveNumber)
    {
        // Number of enemies increases as wave number increases.
        int numEnemies = waveNumber + 3;

        for (int i = 0; i < numEnemies; ++i)
        {
            // Spawn a random enemy.
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyType = enemyPrefabs[enemyIndex];

            // Choose a random spawn position at the top if not a UFO and left or right of the screen for UFOs.
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnRangeUpperY, 0);
            if (enemyType.name == "UFO")
            {
                Vector3 spawnLeft = new Vector3(-spawnRangeX, Random.Range(spawnRangeLowerY, spawnRangeUpperY), 0);
                Vector3 spawnRight = new Vector3(spawnRangeX, Random.Range(spawnRangeLowerY, spawnRangeUpperY), 0);
                Vector3[] spawnPositions = { spawnLeft, spawnRight };
                int spawnIndex = Random.Range(0, spawnPositions.Length);
                spawnPosition = spawnPositions[spawnIndex];
            }

            Instantiate(enemyPrefabs[enemyIndex], spawnPosition, enemyPrefabs[enemyIndex].transform.rotation);

            // Wait a random amount of time.
            float time = Random.Range(0.5f, 3);
            yield return new WaitForSeconds(time);
        }
        waveComplete = true;
    }

    // ENCAPSULATION
    // Updates the score.
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // Activates the "Game Over" text.
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

