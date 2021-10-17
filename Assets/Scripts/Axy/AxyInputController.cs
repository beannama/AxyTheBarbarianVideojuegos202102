using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxyInputController : MonoBehaviour
{
    AxyPhysicsController ph;
    AxyStateController state;
    void Start()
    {
        ph = GetComponent<AxyPhysicsController>();
        state = GetComponent<AxyStateController>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        if (state.isMoving)
        {
        }
        else
        {
            Vector2 position2d = transform.position;
            if(position2d == state.objectivePos)
            {
                if (xInput > 0.01f)
                {
                    position2d += Vector2.right;
                }
                else if (xInput < -0.01f)
                {
                    position2d += Vector2.left;
                }
                else if (yInput > 0.01f)
                {
                    position2d += Vector2.up;
                }
                else if (yInput < -0.01f)
                {
                    position2d += Vector2.down;
                }
            }
            state.objectivePos = position2d;
        }
    }
}
