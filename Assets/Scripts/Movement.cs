using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 pos;                        // For movement
    public float speed = 2.0f;          // Speed of movement
    private bool isMoving = false;

    void Start()
    {
        pos = transform.position;       // Take the initial position
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        if (isMoving)
        {
            //WAIT FOR THE PLAYER TO GET TO THE PLACE
        }
        else
        {
            if (xInput > 0.01f && transform.position == pos)
            {
                pos += Vector3.right;
            }
            else if (xInput < -0.01f && transform.position == pos)
            {
                pos += Vector3.left;
            }
            else if (yInput > 0.01f && transform.position == pos)
            {
                pos += Vector3.up;
            }
            else if (yInput < -0.01f && transform.position == pos)
            {
                pos += Vector3.down;
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

        if (Vector3.Distance(initialPos, targetPos)< 0.1f)
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
