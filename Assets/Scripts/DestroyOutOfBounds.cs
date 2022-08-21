using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 5;
    private float lowerBound = -5;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            // Deactivate the projectile when it leaves the screen.
            gameObject.SetActive(false);

        }
        else if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }

    }
}

