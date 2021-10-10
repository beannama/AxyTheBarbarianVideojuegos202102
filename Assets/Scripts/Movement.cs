using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Movement : MonoBehaviour
{
    Vector3 pos;                        // For movement
    Vector3 lastPos;
    public float speed = 2.0f;          // Speed of movement
    private bool isMoving = false;

    Vector3 facing;

    public Rigidbody2D rb2D;

    void Start()
    {
        pos = transform.position;       // Take the initial position
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        if (isMoving)
        {
            //WAIT FOR THE PLAYER TO GET TO THE PLACE
            //DO NOTHING
        }
        else
        {
            lastPos = transform.position;
            if (xInput > 0.01f && transform.position == pos)
            {
                pos += Vector3.right;
                IsFacingRight();
            }
            else if (xInput < -0.01f && transform.position == pos)
            {
                pos += Vector3.left;
                IsFacingLeft();
            }
            else if (yInput > 0.01f && transform.position == pos)
            {
                pos += Vector3.up;
                IsFacingUp();
            }
            else if (yInput < -0.01f && transform.position == pos)
            {
                pos += Vector3.down;
                IsFacingDown();
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

    void IsFacingRight()
    {
        facing = new Vector3(1, 0, 0);
    }
    void IsFacingLeft()
    {
        facing = new Vector3(-1, 0, 0);
    }
    void IsFacingUp()
    {
        facing = new Vector3(0, 1, 0);
    }
    void IsFacingDown()
    {
        facing = new Vector3(0, -1, 0);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Wall" || col.gameObject.name == "DrunkenSkeleton" || col.gameObject.name == "Gazer")
        {
            Debug.Log("CollisionEnter2D");
            EditorApplication.Beep();
            transform.position = lastPos;
            //transform.position = Vector3.MoveTowards(transform.position, lastPos, Time.deltaTime * speed);
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Wall")
        {
           
        }
    }



}
