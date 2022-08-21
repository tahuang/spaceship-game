using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Deactivate the missile and destroy the enemy.
        other.gameObject.SetActive(false);
        Destroy(gameObject);
    }

}

