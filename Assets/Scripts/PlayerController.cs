using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float xRange = 13;
    private float yRange = 4;
    private SpawnManager spawnManager;
    private AudioSource playerAudio;
    public AudioClip shootSound;
    public AudioClip deathSound;
    public GameObject projectilePrefab;
    public List<GameObject> hearts;

    // Start is called before the first frame update.
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnManager.isGameActive)
        {
            CheckPositionBounds();

            // Player movement.
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);

            // Shoot a projectile when space is pressed.
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Get an object object from the pool
                GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
                if (pooledProjectile != null)
                {
                    pooledProjectile.SetActive(true); // activate it
                    pooledProjectile.transform.position = transform.position; // position it at player
                    playerAudio.PlayOneShot(shootSound, 1.0f);
                }
            }
        }
    }

    void CheckPositionBounds()
    {
        // Check for left and right bounds.
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Check for forward and back bounds.
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }

        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
    }

    public void DecreaseHealth()
    {
        if (spawnManager.isGameActive)
        {
            // Destroy one heart. If we're out of hearts, it's game over.
            Destroy(hearts[hearts.Count - 1]);
            hearts.RemoveAt(hearts.Count - 1);
            if (hearts.Count == 0)
            {
                spawnManager.GameOver();
            }
        }

    }

}
