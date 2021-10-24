using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AxyPhysicsController : MonoBehaviour
{
    Collider2D col;

    AxyStateController state;
    AxySoundController sound;

    public static event Action<string> WinConditionNotification = delegate { };

    public static event Action<string> CollisionNotification = delegate { };

    void Start()
    {
        state = GetComponent<AxyStateController>();
        col = GetComponent<Collider2D>();
        sound = GetComponent<AxySoundController>();
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, state.objectivePos, Time.deltaTime * state.speed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Wall")
        {
            CollisionNotification("Wall");
        }

        if(col.gameObject.name == "DrunkenSkeleton" || col.gameObject.name == "Gazer" || col.gameObject.name == "Arrow")
        {
            //lose condition
            Debug.Log("You are dead.");
            SceneManager.LoadScene("SampleScene");
        }

        if (col.gameObject.name == "Exit")
        {
            //win condition
            WinConditionNotification("Exit");
            //SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "Wall" || col.gameObject.name == "DrunkenSkeleton" || col.gameObject.name == "Gazer")
        {
            state.isColliding = false;
        }
    }
}
