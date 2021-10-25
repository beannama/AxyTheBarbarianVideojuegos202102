using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class GlobalController
{
    //public AudioSource audioSource;
    public static GameObject axyGameObject;

    static AxyStateController state;

    static AxySoundController sound;

    // Start is called before the first frame update
    public static void Instantiate()
    {
        axyGameObject = GameObject.Find("Player");
        state = axyGameObject.GetComponent<AxyStateController>();
        sound = axyGameObject.GetComponent<AxySoundController>();
        AxyPhysicsController.WinConditionNotification += AxyPhysicsController_WinConditionNotification;
        AxyPhysicsController.CollisionNotification += AxyPhysicsController_CollisionNotification;
        Debug.Log("Listeners Attached");
    }



    private static void AxyPhysicsController_WinConditionNotification(string obj)
    {
        if(obj == "Exit")
        {
            Debug.Log("You win");
        }
    }

    private static void AxyPhysicsController_CollisionNotification(string obj)
    {
        if (obj == "Wall")
        {
            state.CancelMovement();
            sound.MakeSound("You collide with a wall");
        }
    }

    public static void DisableListeners()
    {
        AxyPhysicsController.WinConditionNotification -= AxyPhysicsController_WinConditionNotification;

        AxyPhysicsController.CollisionNotification -= AxyPhysicsController_WinConditionNotification;

    }
}
