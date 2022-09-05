using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float speed;
    public int scoreValue;
    private float lowerBound = -5;
    private SpawnManager spawnManager;
    protected PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        Setup();
    }

    // Update is called once per frame. Move and check out of bounds.
    void Update()
    {
        Move();
        DestroyOutOfBounds();
    }

    // If the enemy is hit, destroy the enemy and add to the score.
    void OnTriggerEnter2D(Collider2D other)
    {
        // If an enemy hits the player, decrease player health.
        if (other.tag == "Player")
        {
            playerController.DecreaseHealth();
        }
        else if (other.tag == "Projectile")
        {
            // Deactivate the missile.
            other.gameObject.SetActive(false);
        }

        Destroy(gameObject);

        // Add to the score.
        spawnManager.UpdateScore(scoreValue);
    }

    // Implement this function if some startup procedure is needed.
    protected virtual void Setup()
    {

    }

    // Override this function to implement movement of the enemy.
    protected abstract void Move();

    // Override this function to implement a different destruction out of bounds. 
    // Default behavior is destruction when the object goes below the playable area.
    protected virtual void DestroyOutOfBounds()
    {
        if (transform.position.y < lowerBound)
        {
            Destroy(gameObject);
            // Decrease player health by 1.
            playerController.DecreaseHealth();
        }
    }
}
