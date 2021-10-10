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

    private bool isMoving = false;

    //public int moveDistance = 3;

    void Start()
    {
        pos = transform.position;
        initialY = pos.y;
    }

    private void Update()
    {
        Vector3 current_position = transform.position;

        if (isMoving)
        {
            //Wait for movement to stop
        }
        else
        {
            if (current_position.y >= initialY)
            {
                pos += Vector3.down;
            }
            else if (current_position.y <= initialY)
            {
                pos += Vector3.up;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there

    }

    private void LateUpdate()
    {
        isMoving = IsMoving(transform.position, pos);
    }

    bool IsMoving(Vector3 initialPos, Vector3 targetPos)
    {
        bool returnedBoolean;

        if (Vector3.Distance(initialPos, targetPos) < 0.1f)
        {
            returnedBoolean = false;
        }
        else
        {
            returnedBoolean = true;
        }
        return returnedBoolean;
    }

}
