using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxyStateController : MonoBehaviour
{
    [Min(0)]
    public float speed = 1;
    public bool isColliding = false;
    public bool isMoving = false;
    public Vector2 objectivePos;
    public bool isDead = false;
    private void Start()
    {
        objectivePos = transform.position;
    }

    private void Update()
    {
        isMoving = IsMoving();
        
    }

    public void CancelMovement()
    {
        isMoving = false;
        objectivePos = transform.position;
    }

    bool IsMoving()
    {
        bool returnedBoolean = false;

        if (Vector3.Distance(transform.position, objectivePos) > 0f)
        {
            returnedBoolean = true;
        }

        if (isColliding)
        {
            //CancelMovement();
        }
        return returnedBoolean;
    }
}
