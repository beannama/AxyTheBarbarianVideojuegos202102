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
    private bool isColliding = false;

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

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Wall" || col.gameObject.name == "DrunkenSkeleton" || col.gameObject.name == "Gazer")
        {
            isColliding = true;
            Debug.Log("CollisionEnter2D");
            EditorApplication.Beep();
        }
        
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "Wall" || col.gameObject.name == "DrunkenSkeleton" || col.gameObject.name == "Gazer")
        {
            isColliding = false;
        }
    }



}
