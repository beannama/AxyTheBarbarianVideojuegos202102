using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazerMovement : MonoBehaviour
{
    Vector2 position;
    float initialY;
    bool isGoingUp = true;
    public int moveDistance = 3;
    public float speed = 2f;
    void Start()
    {
        position = transform.position;
        initialY = position.y;
    }

    private void Update()
    {
        if(transform.position.y>=initialY+moveDistance)
        {
            isGoingUp = false;
        }
        if(transform.position.y <= initialY)
        {
            isGoingUp = true;
        }
    }
    void FixedUpdate()
    {
        if (isGoingUp)
        {
            position.y += speed/100f;

        }
        else
        {
            position.y -= speed/100f;
        }
        transform.position = position;
    }
}
