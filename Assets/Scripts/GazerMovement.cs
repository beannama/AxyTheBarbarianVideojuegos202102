using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazerMovement : MonoBehaviour
{
    Vector3 pos;
    public float speed = 2.0f;


    Vector2 position;
    float initialY;
    bool isGoingUp = true;
    //public int moveDistance = 3;

    void Start()
    {
        pos = transform.position;
        initialY = pos.y;
    }

    private void Update()
    {
        Vector3 current_position = transform.position;

        if(current_position.y >= initialY)
        {
            pos += Vector3.down;
        }
        else if(current_position.y <= initialY)
        {
            pos += Vector3.up;
        }

        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * speed);    // Move there


        //if(transform.position.y>=initialY+moveDistance)
        //{
        //    isGoingUp = false;
        //}
        //if(transform.position.y <= initialY)
        //{
        //    isGoingUp = true;
        //}


    }
    //void FixedUpdate()
    //{
    //    if (isGoingUp)
    //    {
    //        position.y += speed/100f;
    //    }
    //    else
    //    {
    //        position.y -= speed/100f;
    //    }
    //    transform.position = position;
    //}
}
