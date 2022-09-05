using UnityEngine;

// INHERITANCE
public class UFO : Enemy
{
    private float midpointX = 0;
    private float xRange = 14;
    private Vector3 travelDirection;

    // POLYMORPHISM
    protected override void Setup()
    {
        // The UFO will move left or right depending on where it spawns.
        if (transform.position.x < midpointX)
        {
            travelDirection = Vector3.right;
        }
        else
        {
            travelDirection = Vector3.left;
        }
    }

    protected override void Move()
    {
        transform.Translate(travelDirection * Time.deltaTime * speed);
    }

    protected override void DestroyOutOfBounds()
    {
        if (transform.position.x < -xRange || transform.position.x > xRange)
        {
            Destroy(gameObject);
            // Decrease player health by 1.
            playerController.DecreaseHealth();
        }
    }
}
