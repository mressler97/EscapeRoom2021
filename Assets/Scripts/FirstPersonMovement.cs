using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 4;
    Vector2 velocity;

    void FixedUpdate()
    {
        velocity.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(velocity.x, 0, velocity.y);
    }
}
