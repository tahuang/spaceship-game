using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 3.0f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
