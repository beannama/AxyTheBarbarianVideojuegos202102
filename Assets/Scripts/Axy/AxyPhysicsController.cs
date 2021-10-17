using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxyPhysicsController : MonoBehaviour
{
    public float horizontalMovement = 0;
    public float verticalMovement = 0;

    Rigidbody2D rb;
    Collider2D col;

    AxyStateController state;
    AxySoundController sound;

    void Start()
    {
        state = GetComponent<AxyStateController>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        sound = GetComponent<AxySoundController>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement * state.speed, verticalMovement * state.speed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Wall" || col.gameObject.name == "DrunkenSkeleton" || col.gameObject.name == "Gazer")
        {
            state.isColliding = true;
            sound.MakeSound("Collision with "+col.gameObject.name+".");
        }

    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "Wall" || col.gameObject.name == "DrunkenSkeleton" || col.gameObject.name == "Gazer")
        {
            state.isColliding = false;
        }
    }
}
