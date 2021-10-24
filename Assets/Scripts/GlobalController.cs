using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GlobalController : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject axyGameObject;

    AxyStateController state;

    AxySoundController sound;

    // Start is called before the first frame update
    void Start()
    {
        axyGameObject = GameObject.Find("Player");
        state = axyGameObject.GetComponent<AxyStateController>();
        sound = GetComponent<AxySoundController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        AxyPhysicsController.WinConditionNotification += AxyPhysicsController_WinConditionNotification;

        AxyPhysicsController.CollisionNotification += AxyPhysicsController_CollisionNotification;
    }



    private void AxyPhysicsController_WinConditionNotification(string obj)
    {
        if(obj == "Exit")
        {
            Debug.Log("You win");
        }
    }

    private void AxyPhysicsController_CollisionNotification(string obj)
    {
        if (obj == "Wall")
        {
            EditorApplication.Beep();

            state.isColliding = true;
        }
    }

    private void OnDisable()
    {
        AxyPhysicsController.WinConditionNotification -= AxyPhysicsController_WinConditionNotification;

        AxyPhysicsController.CollisionNotification -= AxyPhysicsController_WinConditionNotification;

    }
}
