using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        AxyPhysicsController.WinConditionNotification += AxyPhysicsController_WinConditionNotification;
    }

    private void AxyPhysicsController_WinConditionNotification(string obj)
    {
        if(obj == "Exit")
        {
            Debug.Log("You win");
        }
    }

    private void OnDisable()
    {
        AxyPhysicsController.WinConditionNotification -= AxyPhysicsController_WinConditionNotification;

    }
}
