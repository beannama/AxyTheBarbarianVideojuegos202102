using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazerMovementController : MonoBehaviour
{
    GazerStateController state;
    public float moveDistance = 3f;
    public float speed = 2.0f;
    public Vector2 objectivePos;

    // Start is called before the first frame update
    void Start()
    {
        objectivePos = transform.position;
        objectivePos.y += moveDistance;
        state = GetComponent<GazerStateController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state.isGoingUp)
        {
            if (objectivePos.y <= transform.position.y)
            {
                ChangeDirection();
            }
        }
        else
        {
            if (objectivePos.y >= transform.position.y)
            {
                ChangeDirection();
            }
        }
        
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectivePos, Time.deltaTime * speed);
    }

    public void ChangeDirection()
    {
        if (!state.isGoingUp)
        {
            objectivePos.y = transform.position.y + moveDistance;
            state.isGoingUp = true;
        }
        else
        {
            objectivePos.y = transform.position.y - moveDistance;
            state.isGoingUp = false;
        }
    }
}
