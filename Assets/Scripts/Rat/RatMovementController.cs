using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovementController : MonoBehaviour
{
    RatStateController state;
    GameObject axy;

    public float speed = 3.0f;

    public Vector2 objectivePos;
    public Vector2 pos;
    public int fleeDistance = 2;
    public int agressiveDistance = 6;
    public int notAgressiveDistance = 3;

    Vector2 lastPos;
    Vector2 lastPosChanged;
    int randNum;
    Collision2D wallHitted;

    // Start is called before the first frame update
    void Start()
    {
        axy = GameObject.Find("Player");
        objectivePos = transform.position;
        pos = transform.position;
        state = GetComponent<RatStateController>();
        lastPos = transform.position;
        lastPosChanged = transform.position;
        wallHitted = new Collision2D();
        randNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StateManager();
    }

    void StateManager()
    {
        if (state.isAgressive)
        {
            fleeDistance = agressiveDistance;
        }
        else
        {
            fleeDistance = notAgressiveDistance;
        }

        if (state.isIdle)
        {
            if (Vector2.Distance(axy.transform.position, transform.position) < fleeDistance)
            {
                state.isIdle = false;
            }
        }
        else
        {
            if (Vector2.Distance(axy.transform.position, transform.position) >= fleeDistance)
            {
                state.isIdle = true;
            }
        }
    }

    private void FixedUpdate()
    {
        DecisionTree();
    }

    void DecisionTree()
    {
        if (state.isAgressive)
        {
            if (state.isIdle)
            {
                if (state.isColliding)
                {
                    GetAwayFromWall();
                }
                else
                {
                    Idle();
                }
            }
            else
            {
                if (state.isColliding)
                {
                    GetAwayFromWall();
                }
                else
                {
                    Attack();
                }
            }
        }
        else
        {
            if (state.isIdle)
            {
                if (state.isColliding)
                {
                    GetAwayFromWall();
                }
                else
                {
                    Idle();
                }
            }
            else
            {
                if (state.isColliding)
                {
                    FleeRandom();
                }
                else
                {
                    Flee();
                }
            }
        }
    }

    void Attack()
    {
        Vector3 axyPosition = axy.transform.position;
        Vector3 dir = transform.position - axyPosition;
        Vector2 position2d = transform.position;
        if ((dir.x * dir.x) <= (dir.y * dir.y))
        {
            if (dir.y >= 0)
            {
                position2d += Vector2.down;
            }
            else if (dir.y < 0)
            {
                position2d += Vector2.up;
            }
        }
        else
        {
            if (dir.x >= 0)
            {
                position2d += Vector2.left;
            }
            else if (dir.x < 0)
            {
                position2d += Vector2.right;
            }
        }
        objectivePos = position2d;
        transform.position = Vector3.MoveTowards(transform.position, objectivePos, Time.deltaTime * speed);
    }

    void Flee()
    {
        Vector3 axyPosition = axy.transform.position;
        Vector3 dir = transform.position - axyPosition;
        Vector2 position2d = transform.position;
        if((dir.x*dir.x)<=(dir.y*dir.y))
        {
            if (dir.y >= 0)
            {
                position2d += Vector2.up;
            }
            else if (dir.y < 0)
            {
                position2d += Vector2.down;
            }
        }
        else
        {
            if (dir.x >= 0)
            {
                position2d += Vector2.right;
            }
            else if (dir.x < 0)
            {
                position2d += Vector2.left;
            }
        }
        objectivePos = position2d;
        transform.position = Vector3.MoveTowards(transform.position, objectivePos, Time.deltaTime * speed);
    }

    void FleeRandom()
    {
        if(Vector2.Distance(lastPos,transform.position)<0.0001)
        {
            randNum = Random.Range(0, 4);
        }
        Vector2 position2d = transform.position;
        if (randNum == 0)
        {
            position2d += Vector2.up;
        }
        else if (randNum == 1)
        {
            position2d += Vector2.down;
        }
        else if (randNum == 2)
        {
            position2d += Vector2.right;
        }
        else if (randNum == 3)
        {
            position2d += Vector2.left;
        }
        objectivePos = position2d;
        lastPos = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, objectivePos, Time.deltaTime * speed);
    }

    void GetAwayFromWall()
    {
        Vector3 dir = transform.position - wallHitted.transform.position;
        Vector2 position2d = transform.position;
        if ((dir.x * dir.x) <= (dir.y * dir.y))
        {
            if (dir.y >= 0)
            {
                position2d += Vector2.up;
            }
            else if (dir.y < 0)
            {
                position2d += Vector2.down;
            }
        }
        else
        {
            if (dir.x >= 0)
            {
                position2d += Vector2.right;
            }
            else if (dir.x < 0)
            {
                position2d += Vector2.left;
            }
        }
        objectivePos = position2d;
        transform.position = Vector3.MoveTowards(transform.position, objectivePos, Time.deltaTime * speed);
    }

    void Idle()
    {
        if (Vector2.Distance(lastPosChanged, transform.position) > 2 || Vector2.Distance(lastPos, transform.position) < 0.0001)
        {
            randNum = Random.Range(0,4);
            lastPosChanged = transform.position;
        }
        Vector2 position2d = transform.position;
        if (randNum == 0)
        {
            position2d += Vector2.up;
        }
        else if (randNum == 1)
        {
            position2d += Vector2.down;
        }
        else if (randNum == 2)
        {
            position2d += Vector2.right;
        }
        else if (randNum == 3)
        {
            position2d += Vector2.left;
        }
        objectivePos = position2d;
        lastPos = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, objectivePos, Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        wallHitted = collision;
        if (collision.transform.name == "Wall")
        {
            state.isColliding = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        wallHitted = collision;
        if (collision.transform.name == "Wall")
        {
            state.isColliding = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.name == "Wall")
        {
            state.isColliding = false;
        }
    }
}
