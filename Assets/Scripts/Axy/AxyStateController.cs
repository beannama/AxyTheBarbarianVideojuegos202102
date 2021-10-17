using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxyStateController : MonoBehaviour
{
    [Min(0)]
    public float speed = 1;

    Vector3 pos;
    Vector3 lastPos;

    public bool isMoving = false;
    public bool isColliding = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
