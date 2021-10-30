using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovementController : MonoBehaviour
{
    RatStateController state;
    public int moveDistance = 3;
    public float speed = 2.0f;

    public Vector2 objectivePos;
    public Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {

        objectivePos = transform.position;
        pos = transform.position;
        state = GetComponent<RatStateController>();
    }

    // Update is called once per frame
    void Update()
    {
        state.isMoving = IsMoving();


        if (state.isMoving) ; //IsMoving, do nothing
        else
        {
            MoveRandom();
        }

    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectivePos, Time.deltaTime * speed);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            state.isFleeing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        state.isFleeing = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        CancelMovement();
        state.isColliding = true;
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        state.isColliding = false;
        
    }

    bool IsMoving()
    {
        bool returnedBoolean = false;

        if (Vector3.Distance(transform.position, objectivePos) > 0f)
        {
            returnedBoolean = true;
        }

        if (state.isColliding)
        {
            //CancelMovement();
        }
        return returnedBoolean;
    }
    public void CancelMovement()
    {
        state.isMoving = false;
        objectivePos = transform.position;
    }

    public void MoveRandom()
    {
        int choise = Random.Range(0, 4);
        Vector2 position2d = transform.position;
        if (position2d == objectivePos)
        {
            if (choise == 0)
            {
                position2d += Vector2.right;
            }
            else if (choise == 1)
            {
                position2d += Vector2.left;
            }
            else if (choise == 2)
            {
                position2d += Vector2.up;
            }
            else if (choise == 3)
            {
                position2d += Vector2.down;
            }
        }
        objectivePos = position2d;
    }

}
