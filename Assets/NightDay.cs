using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightDay : MonoBehaviour
{
    public bool isDay;
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        isDay = false;
        InvokeRepeating("Change", 0, 40);
    }

    // Update is called once per frame
    void Change()
    {
        isDay = !isDay;
        if(isDay)
        {
            mainCamera.backgroundColor = Color.white;
        }
        else
        {
            mainCamera.backgroundColor = Color.black;
        }
    }
}
