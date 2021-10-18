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
        state = GetComponent<GazerStateController>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDirection();
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectivePos, Time.deltaTime * speed);
    }

    public void ChangeDirection()
    {
        if(state.isMoving)
        {
            if (state.isGoingUp)
            {
                objectivePos.y = transform.position.y + moveDistance;
            }
            else
            {
                objectivePos.y = transform.position.y - moveDistance;
            }
        }
    }
}
