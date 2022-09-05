using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 5;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > topBound)
        {
            // Deactivate the projectile when it leaves the screen.
            gameObject.SetActive(false);

        }

    }
}

