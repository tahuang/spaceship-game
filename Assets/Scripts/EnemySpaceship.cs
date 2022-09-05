using UnityEngine;

public class EnemySpaceship : Enemy
{
    protected override void Move()
    {
        // The enemy spaceship is rotated 180 degrees so it will move "up", which will be down the screen.
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
