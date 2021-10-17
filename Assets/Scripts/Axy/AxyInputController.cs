using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxyInputController : MonoBehaviour
{
    AxyPhysicsController ph;
    void Start()
    {
        ph = GetComponent<AxyPhysicsController>();
    }

    // Update is called once per frame
    void Update()
    {
        ph.horizontalMovement = Input.GetAxisRaw("Horizontal");
        ph.verticalMovement = Input.GetAxisRaw("Vertical");
    }
}
