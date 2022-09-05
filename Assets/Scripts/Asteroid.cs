using UnityEngine;

public class Asteroid : Enemy
{
    protected override void Move()
    {
        // The asteroid will fall downwards.
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
